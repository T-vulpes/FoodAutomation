using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace yemekotomasyonu
{
    public partial class gecmisSiparis : Form
    {
        string connectionString = "Server=DESKTOP-OF8K7QI\\MSSQL;Database=yemekotomasyonu;Trusted_Connection=True;";
        public int Kullanici_ID { get; set; }
        public gecmisSiparis()
        {
            InitializeComponent();
        }

        private void gecmisSiparis_Load(object sender, EventArgs e)
        {
            // DataGridView'in sütunlarını belirle
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Ad", "Ad");
            dataGridView1.Columns.Add("Soyad", "Soyad");
            dataGridView1.Columns.Add("Menu", "Menu");
            dataGridView1.Columns.Add("Yemek", "Yemek");
            dataGridView1.Columns.Add("Icecek", "Icecek");
            dataGridView1.Columns.Add("Tutar", "Tutar");
            dataGridView1.Columns.Add("Not", "Not");
            dataGridView1.Columns.Add("durum", "Durum");

            // Siparişleri çek
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT siparis.ID, Kullanicilar.Ad, Kullanicilar.Soyad, siparis.menu, siparis.yemek, siparis.icecek, siparis.tutar, siparis.[not], siparis.durum FROM siparis INNER JOIN Kullanicilar ON siparis.ID = Kullanicilar.ID";
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
                        string durum = reader["durum"].ToString();

                        if (ID.ToString() == this.Kullanici_ID.ToString())
                        {
                            dataGridView1.Rows.Add(ID, ad, soyad, menu, yemek, icecek, tutar, notlar, durum);
                        }
                    }

                    reader.Close();
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırın verilerini al
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string menu = selectedRow.Cells["Menu"].Value.ToString();
                string yemek = selectedRow.Cells["Yemek"].Value.ToString();
                string icecek = selectedRow.Cells["Icecek"].Value.ToString();
                int tutar = Convert.ToInt32(selectedRow.Cells["Tutar"].Value);
                string not = selectedRow.Cells["Not"].Value.ToString();
                string durum = selectedRow.Cells["Durum"].Value.ToString();

                // ListBox'a verileri ekleyelim
                ListBox1.Items.Clear(); // ListBox'ı temizleyelim
                ListBox1.Items.Add($"Menu: {menu}");
                ListBox1.Items.Add($"Yemek: {yemek}");
                ListBox1.Items.Add($"Icecek: {icecek}");
                ListBox1.Items.Add($"Tutar: {tutar}");
                ListBox1.Items.Add($"Not: {not}");
                ListBox1.Items.Add($"Durum: {durum}");
            }
        }
    }
}
