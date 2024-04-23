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
    public partial class musteribildirim : Form
    {
        public int Kullanici_ID { get; set; }

        public musteribildirim()
        {
            InitializeComponent();
        }

        private void musteribildirim_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-OF8K7QI\\MSSQL;Database=yemekotomasyonu;Trusted_Connection=True;";

            // Kullanıcıdan girdileri al
            string mesaj = txtmesaj.Text;

            // Veritabanında ekleme işlemi
            string query = "INSERT INTO mesajlar (kullaniciID , mesaj) VALUES (@kullaniciID, @mesaj)";

            bool success = false; // Başlangıçta işlem başarısız olarak kabul edilir

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@kullaniciID", Kullanici_ID);
                    command.Parameters.AddWithValue("@mesaj", mesaj);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0) // Eğer en az bir satır etkilenmişse, işlem başarılıdır
                    {
                        success = true;
                    }
                }
            }

            if (success)
            {
                MessageBox.Show("Mesaj Gönderildi!");
            }
            else
            {
                MessageBox.Show("Bir hata oluştu, mesaj gönderilemedi.");
            }

            // Ekleme işlemi tamamlandıktan sonra temizle
            txtmesaj.Clear();
        }

    }
}
