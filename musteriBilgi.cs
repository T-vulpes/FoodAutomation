using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace yemekotomasyonu
{
    public partial class musteriBilgi : Form
    {
        public string Kullanici_Adi { get; set; }
        public musteriBilgi()
        {
            InitializeComponent();
        }

        private void musteriBilgi_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-OF8K7QI\\MSSQL;Database=yemekotomasyonu;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ID ,Ad,Soyad, Telefon, kullaniciadi, adres, parola, yetki FROM Kullanicilar WHERE KullaniciAdi = @kullaniciadi";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@kullaniciadi", Kullanici_Adi);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        lblID.Text = reader["ID"].ToString();
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

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
