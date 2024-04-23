using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace yemekotomasyonu
{
    public partial class siparişler : Form
    {
        public string Kullanici_Adi { get; set; }
        public int Kullanici_ID { get; set; }
        string connectionString = "Server=DESKTOP-OF8K7QI\\MSSQL;Database=yemekotomasyonu;Trusted_Connection=True;";
        double toplamfiyat = 0;
        public siparişler()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ComboBox2.SelectedIndex = -1;
            ComboBox3.SelectedIndex = -1;
            comboBoxIcecek.SelectedIndex = -1;

            // NumericUpDown'ların değerlerini sıfırlama
            numericUpDownyemek.Value = 0;
            NumericUpDownMenu.Value = 0;
            numericUpDownIcecek.Value = 0;
        }

        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            string urunBilgisi = "";

            // Sadece yemek seçilmişse
            if (ComboBox2.SelectedItem != null && numericUpDownyemek.Value > 0)
            {
                string yemekadi = ComboBox2.SelectedItem.ToString();
                int yemekadet = (int)numericUpDownyemek.Value;
                urunBilgisi += $"{yemekadi} - Adet: {yemekadet}";
                toplamfiyat += (yemekadet * 150); // Her bir yemek için 150 TL ekleyelim
            }

            // Sadece menü seçilmişse
            if (ComboBox3.SelectedItem != null && NumericUpDownMenu.Value > 0)
            {
                if (urunBilgisi != "")
                {
                    urunBilgisi += " - ";
                }
                string menuadi = ComboBox3.SelectedItem.ToString();
                int menuadet = (int)NumericUpDownMenu.Value;
                urunBilgisi += $"{menuadi} - Adet: {menuadet}";
                toplamfiyat += (menuadet * 200); // Her bir menü için 200 TL ekleyelim
            }

            // Sadece içecek seçilmişse
            if (comboBoxIcecek.SelectedItem != null && numericUpDownIcecek.Value > 0)
            {
                if (urunBilgisi != "")
                {
                    urunBilgisi += " - ";
                }
                string icecek = comboBoxIcecek.SelectedItem.ToString();
                int icecekadet = (int)numericUpDownIcecek.Value;
                urunBilgisi += $"{icecek} - Adet: {icecekadet}";
                toplamfiyat += (icecekadet * 15); // Her bir içecek için 15 TL ekleyelim
            }

            // Eğer hiçbir şey seçilmemişse
            if (urunBilgisi == "")
            {
                MessageBox.Show("Lütfen en az bir ürün seçin.");
                return;
            }

            // ListBox'a ürün bilgisini ekle
            listBox1.Items.Add(urunBilgisi);

            // Toplam fiyatı göster
            lblToplam.Text = toplamfiyat.ToString();
        }



        private void lstbxtmz_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            lblToplam.Text = "";
        }

        private void siparişler_Load(object sender, EventArgs e)
        {
            // Tarih ve saat bilgisini uygun biçime dönüştür
            lblTarih.Text = DateTime.Today.ToString("d"); // "d" formatı, kısa tarih formatını temsil eder
            lblSaat.Text = DateTime.Now.ToString("HH:mm:ss"); // Saat, dakika ve saniye için format belirtildi


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Ad, Soyad, Adres, Telefon FROM Kullanicilar WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", this.Kullanici_ID); // Kullanici_ID özelliğini kullan

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string isim = reader["Ad"].ToString();
                        string soyisim = reader["Soyad"].ToString();
                        string adres = reader["Adres"].ToString();
                        string telefon = reader["Telefon"].ToString();

                        // Verileri kullanın veya ekrana yazdırın
                        lblID.Text = this.Kullanici_ID.ToString();
                        txtAdi.Text = isim;
                        txtSoyadi.Text = soyisim;
                        txtAdres.Text = adres;
                        txtTel.Text = telefon;

                    }
                    else
                    {
                        Console.WriteLine("Kullanıcı bulunamadı.");
                    }

                    reader.Close();
                }
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            // Sipariş bilgilerini al
            int tutar = Convert.ToInt32(lblToplam.Text);
            string notlar = txtNot.Text;
            string yemek = ComboBox2.SelectedItem?.ToString();
            int yemekAdet = (int)numericUpDownyemek.Value;
            string menu = ComboBox3.SelectedItem?.ToString();
            int menuAdet = (int)NumericUpDownMenu.Value;
            string icecek = comboBoxIcecek.SelectedItem?.ToString();
            int icecekAdet = (int)numericUpDownIcecek.Value;

            // Sipariş bilgilerini oluştur
            string siparisBilgisi = "";
            if (!string.IsNullOrEmpty(yemek))
            {
                siparisBilgisi += $"{yemek} - Adet: {yemekAdet}\n";
                toplamfiyat += (yemekAdet * 150); // Her bir yemek için 150 TL ekleyelim
            }
            if (!string.IsNullOrEmpty(menu))
            {
                siparisBilgisi += $"{menu} - Adet: {menuAdet}\n";
                toplamfiyat += (menuAdet * 200); // Her bir menü için 200 TL ekleyelim
            }
            if (!string.IsNullOrEmpty(icecek))
            {
                siparisBilgisi += $"{icecek} - Adet: {icecekAdet}\n";
                toplamfiyat += (icecekAdet * 15); // Her bir içecek için 15 TL ekleyelim
            }

            // Eğer hiçbir şey seçilmemişse
            if (string.IsNullOrEmpty(siparisBilgisi))
            {
                MessageBox.Show("Lütfen en az bir ürün seçin.");
                return;
            }

            // Toplam fiyatı göster
            //lblToplam.Text = toplamfiyat.ToString();

            // Veritabanına bağlan
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Verileri eklemek için SQL komutunu oluştur
                string sql = "INSERT INTO siparis (ID, tutar, [not], yemek, menu, icecek) VALUES (@ID, @tutar, @not, @yemek, @menu, @icecek)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Parametreleri ekle
                    command.Parameters.AddWithValue("@ID", Kullanici_ID);
                    command.Parameters.AddWithValue("@siparis", siparisBilgisi);
                    command.Parameters.AddWithValue("@tutar", tutar);
                    command.Parameters.AddWithValue("@not", notlar);

                    if (!string.IsNullOrEmpty(yemek)) // Eğer yemek seçilmişse
                    {
                        command.Parameters.AddWithValue("@yemek", yemek); // Parametreyi ekle
                    }
                    else // Eğer yemek seçilmemişse
                    {
                        command.Parameters.AddWithValue("@yemek", DBNull.Value); // Null değer olarak ekle
                    }

                    if (!string.IsNullOrEmpty(menu)) // Eğer menu seçilmişse
                    {
                        command.Parameters.AddWithValue("@menu", menu); // Parametreyi ekle
                    }
                    else // Eğer menu seçilmemişse
                    {
                        command.Parameters.AddWithValue("@menu", DBNull.Value); // Null değer olarak ekle
                    }


                    if (!string.IsNullOrEmpty(icecek)) // Eğer içecek seçilmişse
                    {
                        command.Parameters.AddWithValue("@icecek", icecek); // Parametreyi ekle
                    }
                    else // Eğer içecek seçilmemişse
                    {
                        command.Parameters.AddWithValue("@icecek", DBNull.Value); // Null değer olarak ekle
                    }
                    // Komutu çalıştır
                    command.ExecuteNonQuery();
                }
            }

            // Kullanıcıya işlemin başarıyla gerçekleştirildiğini bildir
            MessageBox.Show("Sipariş başarıyla eklendi.");
            odeme odemeler = new odeme();
            odemeler.Tutar = Convert.ToInt32(this.lblToplam.Text);
            odemeler.Adi = this.txtAdi.Text;
            odemeler.ShowDialog();
        }






    }
}
