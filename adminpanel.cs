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

    public partial class adminpaneş : Form
    {
        public string Kullanici_Adi { get; set; }
        public int Kullanici_ID;
        public adminpaneş()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            musteriGecmisSiparis mgsiparis = new musteriGecmisSiparis();
            mgsiparis.Show();
        }

        private void adminpaneş_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-OF8K7QI\\MSSQL;Database=yemekotomasyonu;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ID ,Ad,Soyad, Telefon, kullaniciadi, adres, parola, yetki FROM Kullanicilar WHERE KullaniciAdi = @kullaniciadi";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Kullanıcı adını burada kendi kullanıcı adınız ile değiştirmeniz gerekmektedir.
                    command.Parameters.AddWithValue("@kullaniciadi", Kullanici_Adi);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Verileri okuyarak ilgili kontrollere yerleştirme
                        lblID.Text = reader["ID"].ToString();
                        Kullanici_ID = Convert.ToInt32(reader["ID"]);
                        lblAdi.Text = reader["Ad"].ToString();
                        lblSoyad.Text = reader["Soyad"].ToString();
                        lblTel.Text = reader["Telefon"].ToString();
                        lblK_adi.Text = reader["kullaniciadi"].ToString();
                        lblAdres.Text = reader["adres"].ToString();
                        lblSifre.Text = reader["parola"].ToString();
                        lblyetki.Text = reader["yetki"].ToString();

                    }


                    reader.Close();
                }
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            kullanıcıbilgileri kullanicibilgiler = new kullanıcıbilgileri();
            kullanicibilgiler.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            siparisTakip siparisadmin = new siparisTakip();
            siparisadmin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            geribildirim geri = new geribildirim();
            geri.Show();
        }
    }
}
