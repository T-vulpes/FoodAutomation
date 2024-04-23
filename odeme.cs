using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace yemekotomasyonu
{
    public partial class odeme : Form
    {
        public string Adi { get; set; }
        public string iD;
        string connectionString = "Server=DESKTOP-OF8K7QI\\MSSQL;Database=yemekotomasyonu;Trusted_Connection=True;";
        public double indirimlitutar;
        public int Tutar { get; set; }

        public odeme()
        {
            InitializeComponent();
        }

        private void odeme_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Adi))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    KullaniciBilgileriniGetir(connection);
                    OdemeBilgileriniGetir(connection);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı belirtilmemiş!");
            }
        }

        private void KullaniciBilgileriniGetir(SqlConnection connection)
        {
            string query = "SELECT ID, Ad, Soyad FROM Kullanicilar WHERE Ad = @ad";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ad", this.Adi);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    id.Text = reader["ID"].ToString();
                    iD = id.Text;
                    adi.Text = reader["Ad"].ToString();
                    soyadi.Text = reader["Soyad"].ToString();
                }

                reader.Close();
            }
        }

        private void OdemeBilgileriniGetir(SqlConnection connection)
        {
            string query1 = "SELECT tutar, durum FROM siparis WHERE durum = 'Beklemede' AND ID = @ID";

            using (SqlCommand command = new SqlCommand(query1, connection))
            {
                command.Parameters.AddWithValue("@ID", iD);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    tl.Text = Tutar.ToString();
                }

                reader.Close();
            }
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            // Ödeme bilgilerini kaydetmek için veritabanına gönder
            string odemeYontemi = nakit.Checked ? "Nakit" : "Kredi Kartı";
            double indirimliTutar = Convert.ToDouble(lblIndirimliTutar.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO odemetablosu (KullaniciID, Ad, Soyad, Odeme, İndirimliOdeme, OdemeYontemi) VALUES (@KullaniciID, @Ad, @Soyad, @Odeme, @İndirimliOdeme, @OdemeYontemi)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@KullaniciID", iD);
                    command.Parameters.AddWithValue("@Ad", adi.Text);
                    command.Parameters.AddWithValue("@Soyad", soyadi.Text);
                    command.Parameters.AddWithValue("@Odeme", Convert.ToDouble(tl.Text));
                    command.Parameters.AddWithValue("@İndirimliOdeme", indirimliTutar);
                    command.Parameters.AddWithValue("@OdemeYontemi", odemeYontemi);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Ödeme işlemi başarıyla tamamlandı.");
            btnFatura.Enabled = true;

        }
        

        private void radioButtonNakit_CheckedChanged(object sender, EventArgs e)
        {
            OdemeBilgileriniGetir(new SqlConnection(connectionString));
        }

        private void radioButtonKrediKarti_CheckedChanged(object sender, EventArgs e)
        {
            OdemeBilgileriniGetir(new SqlConnection(connectionString));
        }

        private void nakit_Click(object sender, EventArgs e)
        {
            indirimlitutar = Tutar - (Tutar * 0.1);
            lblIndirimliTutar.Text = indirimlitutar.ToString();
        }

        private void k_karti_CheckedChanged(object sender, EventArgs e)
        {
            indirimlitutar = Tutar - (Tutar *  0.03);
            lblIndirimliTutar.Text = indirimlitutar.ToString();
        }

        private void btnFatura_Click(object sender, EventArgs e)
        {                // Fatura bilgilerini içerecek olan metin dosyasının adı ve yolu
            string dosyaAdi = "fatura.txt";
            string dosyaYolu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + dosyaAdi;

            // Fatura bilgilerini metin dosyasına yazma işlemi
            using (System.IO.StreamWriter dosya = new System.IO.StreamWriter(dosyaYolu))
            {
                dosya.WriteLine("ID No: " + iD);
                dosya.WriteLine("Adı: " + adi.Text);
                dosya.WriteLine("Soyadı: " + soyadi.Text);
                dosya.WriteLine("Toplam Tutar: " + tl.Text);
                dosya.WriteLine("İndirimli Tutar: " + lblIndirimliTutar.Text);
                dosya.WriteLine("Ödeme Yöntemi: " + (nakit.Checked ? "Nakit" : "Kredi Kartı"));
            }

            MessageBox.Show("Fatura başarıyla oluşturuldu.");
        }
    }
}

