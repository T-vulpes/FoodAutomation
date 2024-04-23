using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace yemekotomasyonu
{
    public partial class gecmisOdemeler : Form
    {
        string connectionString = "Server=DESKTOP-OF8K7QI\\MSSQL;Database=yemekotomasyonu;Trusted_Connection=True;";
        public int Kullanici_ID { get; set; }
        double toplamOdeme = 0;
        double toplamIndirimliOdeme = 0;

        public gecmisOdemeler()
        {
            InitializeComponent();
        }

        private void gecmisOdemeler_Load(object sender, EventArgs e)
        {
            // DataGridView'in sütunlarını belirle
            DataGridView1.Columns.Add("odemeID", "odeme ID");
            DataGridView1.Columns.Add("KullaniciID", "Kullanıcı ID");
            DataGridView1.Columns.Add("Ad", "Ad");
            DataGridView1.Columns.Add("Soyad", "Soyad");
            DataGridView1.Columns.Add("Odeme", "Ödeme");
            DataGridView1.Columns.Add("IndirimliOdeme", "İndirimli Ödeme");
            DataGridView1.Columns.Add("OdemeYontemi", "Ödeme Yöntemi");

            // Ödemeleri çek
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM odemetablosu WHERE KullaniciID = @KullaniciID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@KullaniciID", Kullanici_ID);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // DataGridView'e satır ekle
                        string musteriID = reader["odemeID"].ToString();
                        string kullaniciID = reader["KullaniciID"].ToString();
                        string ad = reader["Ad"].ToString();
                        string soyad = reader["Soyad"].ToString();
                        double odeme = Convert.ToDouble(reader["Odeme"]);
                        double indirimliOdeme = Convert.ToDouble(reader["İndirimliOdeme"]);
                        string odemeYontemi = reader["OdemeYontemi"].ToString();

                        DataGridView1.Rows.Add(musteriID, kullaniciID, ad, soyad, odeme, indirimliOdeme, odemeYontemi);

                        // Toplam ödemeleri hesapla
                        toplamOdeme += odeme;
                        toplamIndirimliOdeme += indirimliOdeme;
                    }

                    reader.Close();
                }
            }

            // Toplam ödemeleri göster
            
            toplamodeme.Text = toplamOdeme.ToString();
            toplamindirimodeme.Text = toplamIndirimliOdeme.ToString();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırın verilerini al
                DataGridViewRow selectedRow = DataGridView1.SelectedRows[0];
                string ad = selectedRow.Cells["Ad"].Value.ToString();
                string soyad = selectedRow.Cells["Soyad"].Value.ToString();
                double odeme = Convert.ToDouble(selectedRow.Cells["Odeme"].Value);
                double indirimliOdeme = Convert.ToDouble(selectedRow.Cells["IndirimliOdeme"].Value);
                string odemeYontemi = selectedRow.Cells["OdemeYontemi"].Value.ToString();

                // Verileri üstteki labellerda göster
                lblAdiSoyadi.Text = ad + " " + soyad;
                id.Text = this.Kullanici_ID.ToString();
                lblodeme.Text = odeme.ToString();
                ıodeme.Text = indirimliOdeme.ToString();
                o_yontemi.Text = odemeYontemi;
            }
        }
    }
}
