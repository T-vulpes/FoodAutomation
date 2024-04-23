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
    public partial class kayıtol : Form
    {
        public kayıtol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Ad = txtAd.Text;
            string Soyad = txtSoyad.Text;
            string telefon = txtTel.Text;
            string kullaniciAdi = txtKullaniciAdi.Text;
            string adres = txtAdres.Text;
            string parola = sifre.Text;
            string yetki = "üye"; // Sabit üye yetkisi
            string connectionString = "Server=DESKTOP-OF8K7QI\\MSSQL;Database=yemekotomasyonu;Trusted_Connection=True;";

            // Bağlantı oluşturma
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // SQL komutunu oluşturma
                    string query = "INSERT INTO Kullanicilar (Ad, Soyad, Telefon, kullaniciadi, adres, parola, yetki) " +
                                   "VALUES (@Ad, @Soyad, @Telefon, @kullaniciadi, @adres, @parola, @yetki)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parametreleri ekleme
                        command.Parameters.AddWithValue("@Ad", Ad);
                        command.Parameters.AddWithValue("@Soyad", Soyad);
                        command.Parameters.AddWithValue("@Telefon", telefon);
                        command.Parameters.AddWithValue("@kullaniciadi", kullaniciAdi);
                        command.Parameters.AddWithValue("@adres", adres);
                        command.Parameters.AddWithValue("@parola", parola);
                        command.Parameters.AddWithValue("@yetki", yetki);

                        // Bağlantıyı açma
                        connection.Open();

                        // Komutu çalıştırma
                        int result = command.ExecuteNonQuery();

                        // Sonucu kontrol etme
                        if (result > 0)
                        {
                            MessageBox.Show("Kayıt başarıyla eklendi.");
                        }
                        else
                        {
                            MessageBox.Show("Kayıt eklenirken hata oluştu.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void kayıtol_Load(object sender, EventArgs e)
        {

        }
    }
}
