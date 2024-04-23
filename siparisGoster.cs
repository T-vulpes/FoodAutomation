using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace yemekotomasyonu
{
    public partial class siparisGoster : Form
    {
        string connectionString = "Server=DESKTOP-OF8K7QI\\MSSQL;Database=yemekotomasyonu;Trusted_Connection=True;";
        public int Kullanici_ID { get; set; }

        public siparisGoster()
        {
            InitializeComponent();
        }

        private void siparisGoster_Load(object sender, EventArgs e)
        {
            // DataGridView'in sütunlarını belirle
            DataGridView1.Columns.Add("ID", "ID");
            DataGridView1.Columns.Add("Ad", "Ad");
            DataGridView1.Columns.Add("Soyad", "Soyad");
            DataGridView1.Columns.Add("Menu", "Menu");
            DataGridView1.Columns.Add("Yemek", "Yemek");
            DataGridView1.Columns.Add("Icecek", "Icecek");
            DataGridView1.Columns.Add("Tutar", "Tutar");
            DataGridView1.Columns.Add("Not", "Not");
            islem.Text = "Beklemede";
            // Siparişleri çek
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT siparis.ID, Kullanicilar.Ad, Kullanicilar.Soyad, siparis.menu, siparis.yemek, siparis.icecek, siparis.tutar, siparis.[not] FROM siparis INNER JOIN Kullanicilar ON siparis.ID = Kullanicilar.ID WHERE siparis.durum = 'Beklemede'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {

                        // DataGridView'e satır ekle
                        string ID = reader["ID"].ToString();
                        string ad = reader["Ad"].ToString();
                        string soyad = reader["Soyad"].ToString();
                        string menu = reader["menu"].ToString();
                        string yemek = reader["yemek"].ToString();
                        string icecek = reader["icecek"].ToString();
                        int tutar = Convert.ToInt32(reader["tutar"]);
                        string notlar = reader["not"].ToString();

                        if (ID.ToString() == this.Kullanici_ID.ToString())
                        {
                            DataGridView1.Rows.Add(ID, ad, soyad, menu, yemek, icecek, tutar, notlar);
                        }
                        id.Text = ID.ToString();
                    }

                    reader.Close();
                }
            }
        }


        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırın verilerini al
                DataGridViewRow selectedRow = DataGridView1.SelectedRows[0];
                string ad = selectedRow.Cells["Ad"].Value.ToString();
                string soyad = selectedRow.Cells["Soyad"].Value.ToString();
                string menu = selectedRow.Cells["Menu"].Value.ToString();
                string yemek = selectedRow.Cells["Yemek"].Value.ToString();
                string icecek = selectedRow.Cells["Icecek"].Value.ToString();
                int tutar = Convert.ToInt32(selectedRow.Cells["Tutar"].Value);
                string not = selectedRow.Cells["Not"].Value.ToString();

                // ListBox'a verileri ekleyelim
                ListBox1.Items.Clear(); // ListBox'ı temizleyelim
                ListBox1.Items.Add($"Ad: {ad}");
                ListBox1.Items.Add($"Soyad: {soyad}");
                ListBox1.Items.Add($"Menu: {menu}");
                ListBox1.Items.Add($"Yemek: {yemek}");
                ListBox1.Items.Add($"Icecek: {icecek}");
                ListBox1.Items.Add($"Tutar: {tutar}");
                ListBox1.Items.Add($"Not: {not}");
            }
        }

    }
}
