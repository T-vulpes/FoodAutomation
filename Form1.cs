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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            kayıtol kayitForm = new kayıtol();

            // "kayıtol" formunu göster
            kayitForm.Show();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string parola = sifre.Text;

            string connectionString = "Server=DESKTOP-OF8K7QI\\MSSQL;Database=yemekotomasyonu;Trusted_Connection=True;";
            string query = "SELECT COUNT(1) FROM Kullanicilar WHERE KullaniciAdi = @KullaniciAdi AND Parola = @Parola";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    command.Parameters.AddWithValue("@Parola", parola);

                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Giriş başarılı!");

                        string yetkiQuery = "SELECT Yetki FROM Kullanicilar WHERE KullaniciAdi = @KullaniciAdi";
                        using (SqlCommand yetkiCommand = new SqlCommand(yetkiQuery, connection))
                        {
                            yetkiCommand.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                            string yetki = yetkiCommand.ExecuteScalar().ToString();

                            if (yetki == "admin")
                            {
                                adminpaneş adminpanel = new adminpaneş();
                                adminpanel.Kullanici_Adi = kullaniciAdi;
                                adminpanel.Show();
                            }
                            else
                            {
                                musteriPanel form = new musteriPanel();
                                form.Kullanici_Adi = kullaniciAdi;
                                form.Show();
                            }
                        }

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya parola yanlış!");
                    }
                }
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
