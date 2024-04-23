using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace yemekotomasyonu
{
    public partial class kullanıcıbilgileri : Form
    {
        string connectionString = "Server=DESKTOP-OF8K7QI\\MSSQL;Database=yemekotomasyonu;Trusted_Connection=True;";

        public kullanıcıbilgileri()
        {
            InitializeComponent();
        }


        private void kullanıcıbilgileri_Load(object sender, EventArgs e)
        {
            // DataGridView'e sütunlar ekleniyor
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Ad", "Ad");
            dataGridView1.Columns.Add("Soyad", "Soyad");
            dataGridView1.Columns.Add("Telefon", "Telefon");
            dataGridView1.Columns.Add("Adres", "Adres");
            dataGridView1.Columns.Add("kullaniciadi", "Kullanıcı Adı");
            dataGridView1.Columns.Add("parola", "Parola");
            dataGridView1.Columns.Add("yetki", "Yetki");

            // Verileri çekmek için SQL sorgusu
            string query = "SELECT * FROM Kullanicilar";

            // SQL bağlantısı oluştur
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Sorguyu çalıştırmak için bir komut oluştur
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Bağlantıyı aç
                    connection.Open();

                    // Verileri almak için bir veri okuyucu oluştur
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Veri okuyucudan verileri satır olarak al
                        while (reader.Read())
                        {
                            // DataGridView'e bir satır ekle
                            dataGridView1.Rows.Add(reader["ID"], reader["Ad"], reader["Soyad"], reader["Telefon"], reader["Adres"], reader["kullaniciadi"], reader["parola"], reader["yetki"]);
                        }
                    }
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Seçili satırı al
            DataGridViewRow selectedRow = null;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedRow = dataGridView1.SelectedRows[0];
            }

            // Seçili satır varsa, label ve combobox'a değerleri yükle
            if (selectedRow != null)
            {
                txtID.Text = selectedRow.Cells["ID"].Value.ToString();
                sifre.Text = selectedRow.Cells["parola"].Value.ToString();
                txtAd.Text = selectedRow.Cells["Ad"].Value.ToString();
                txtSoyad.Text = selectedRow.Cells["Soyad"].Value.ToString();
                txtAdres.Text = selectedRow.Cells["Adres"].Value.ToString();
                txtTel.Text = selectedRow.Cells["Telefon"].Value.ToString();
                k_adi.Text = selectedRow.Cells["kullaniciadi"].Value.ToString();

                // Yetkiyi combobox'a yükle
                string yetki = selectedRow.Cells["yetki"].Value.ToString();
                if (yetki == "üye")
                {
                    ComboBox1.SelectedIndex = 0;
                }
                else if (yetki == "admin")
                {
                    ComboBox1.SelectedIndex = 1;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Seçili satırı al
            DataGridViewRow selectedRow = null;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedRow = dataGridView1.SelectedRows[0];
            }

            // Seçili satır varsa, veritabanında güncelle
            if (selectedRow != null)
            {
                string id = selectedRow.Cells["ID"].Value.ToString();
                string ad = txtAd.Text;
                string soyad = txtSoyad.Text;
                string telefon = txtTel.Text;
                string adres = txtAdres.Text;
                string kullaniciAdi = k_adi.Text;
                string parola = sifre.Text;
                string yetki = ComboBox1.SelectedItem.ToString();

                // Veritabanında güncelleme işlemi
                string query = "UPDATE Kullanicilar SET Ad = @Ad, Soyad = @Soyad, Telefon = @Telefon, Adres = @Adres, kullaniciadi = @KullaniciAdi, parola = @Parola, yetki = @Yetki WHERE ID = @ID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Ad", ad);
                        command.Parameters.AddWithValue("@Soyad", soyad);
                        command.Parameters.AddWithValue("@Telefon", telefon);
                        command.Parameters.AddWithValue("@Adres", adres);
                        command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                        command.Parameters.AddWithValue("@Parola", parola);
                        command.Parameters.AddWithValue("@Yetki", yetki);
                        command.Parameters.AddWithValue("@ID", id);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                // Güncelleme işlemi tamamlandıktan sonra DataGridView'deki mevcut satırı güncelle
                selectedRow.Cells["Ad"].Value = ad;
                selectedRow.Cells["Soyad"].Value = soyad;
                selectedRow.Cells["Telefon"].Value = telefon;
                selectedRow.Cells["Adres"].Value = adres;
                selectedRow.Cells["kullaniciadi"].Value = kullaniciAdi;
                selectedRow.Cells["parola"].Value = parola;
                selectedRow.Cells["yetki"].Value = yetki;

                // DataGridView'i yenile
                dataGridView1.Refresh();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Seçili satırı al
            DataGridViewRow selectedRow = null;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedRow = dataGridView1.SelectedRows[0];
            }

            // Seçili satır varsa, kullanıcıyı sil
            if (selectedRow != null)
            {
                string id = selectedRow.Cells["ID"].Value.ToString();

                // Veritabanından silme işlemi
                string query = "DELETE FROM Kullanicilar WHERE ID = @ID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                // DataGridView'i yenile
                dataGridView1.Refresh();
            }
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            kullanıcıEkle kulekle = new kullanıcıEkle();
            kulekle.ShowDialog();
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {
            // TextBox2'de girilen metni al
            string arananAd = TextBox2.Text;

            // Veritabanından verileri çekme sorgusu
            string query = "SELECT * FROM Kullanicilar WHERE Ad LIKE @ArananAd";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Parametreyi ekleyerek sorguyu hazırla
                    command.Parameters.AddWithValue("@ArananAd", "%" + arananAd + "%");

                    // Bağlantıyı aç
                    connection.Open();

                    // Verileri almak için bir veri okuyucu oluştur
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // DataGridView'deki satırları temizle
                        dataGridView1.Rows.Clear();

                        // Veri okuyucudan verileri satır olarak al
                        while (reader.Read())
                        {
                            // DataGridView'e bir satır ekle
                            dataGridView1.Rows.Add(reader["ID"], reader["Ad"], reader["Soyad"], reader["Telefon"], reader["Adres"], reader["kullaniciadi"], reader["parola"], reader["yetki"]);
                        }
                    }
                }
            }
        }

    }
}
