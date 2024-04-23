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
    public partial class kullanıcıEkle : Form
    {
        public kullanıcıEkle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-OF8K7QI\\MSSQL;Database=yemekotomasyonu;Trusted_Connection=True;";

            // Kullanıcıdan girdileri al
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string telefon = txtTel.Text;
            string adres = txtAdres.Text;
            string kullaniciAdi = k_adi.Text;
            string parola = sifre.Text;
            string yetki = ComboBox1.SelectedItem.ToString();

            // Veritabanında ekleme işlemi
            string query = "INSERT INTO Kullanicilar (Ad, Soyad, Telefon, Adres, kullaniciadi, parola, yetki) VALUES (@Ad, @Soyad, @Telefon, @Adres, @KullaniciAdi, @Parola, @Yetki)";

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

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            // Ekleme işlemi tamamlandıktan sonra temizle
            txtAd.Clear();
            txtSoyad.Clear();
            txtTel.Clear();
            txtAdres.Clear();
            k_adi.Clear();
            sifre.Clear();
            ComboBox1.SelectedIndex = -1; // ComboBox'ı temizle
        }
    }
}
