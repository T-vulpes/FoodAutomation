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
using pizzaotomasyondenemesi;

namespace yemekotomasyonu
{

    public partial class musteriPanel : Form
    {
        public string Kullanici_Adi { get; set; }
        public int Kullanici_ID;
        public musteriPanel()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            siparişler siparisal = new siparişler();
            siparisal.Kullanici_ID = this.Kullanici_ID; // Kullanıcı ID'yi aktar
            siparisal.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            siparisGoster siparisgoster = new siparisGoster();
            siparisgoster.Kullanici_ID = this.Kullanici_ID;
            siparisgoster.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            gecmisOdemeler gecmisodemeler = new gecmisOdemeler();
            gecmisodemeler.Kullanici_ID = this.Kullanici_ID;
            gecmisodemeler.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            gecmisSiparis gecmissiparisler = new gecmisSiparis();
            gecmissiparisler.Kullanici_ID = this.Kullanici_ID;
            gecmissiparisler.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            musteriBilgi bilgiler = new musteriBilgi();
            bilgiler.Kullanici_Adi = this.Kullanici_Adi;
            bilgiler.Show();
        }

        private void musteriPanel_Load(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            musteribildirim geribildirim =new musteribildirim();
            geribildirim.Kullanici_ID = this.Kullanici_ID;
            geribildirim.Show();
        }

   
    }
}
