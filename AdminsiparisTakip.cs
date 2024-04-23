using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace yemekotomasyonu
{
    public partial class siparisTakip : Form
    {
        string connectionString = "Server=DESKTOP-OF8K7QI\\MSSQL;Database=yemekotomasyonu;Trusted_Connection=True;";

        public siparisTakip()
        {
            InitializeComponent();
        }

        private void siparisTakip_Load(object sender, EventArgs e)
        {
            // Verileri çekmek için SQL sorgusu
            string query = "SELECT siparisID, siparis.ID, Kullanicilar.ad AS ad, Kullanicilar.soyad AS soyad, Kullanicilar.adres AS adres, Kullanicilar.telefon AS telefon, siparis.yemek AS yemek, siparis.menu AS menu, siparis.icecek AS icecek, siparis.durum AS durum FROM siparis INNER JOIN Kullanicilar ON siparis.ID = Kullanicilar.ID";

            // SQL bağlantısı ve komutu oluşturma
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                // Veri tablosu oluşturma ve verileri doldurma
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                // DataGridView'e verileri bağlama
                dataGridView1.DataSource = dataTable;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                txtID.Text = selectedRow.Cells["ID"].Value.ToString();
                spr_ID.Text = selectedRow.Cells["siparisID"].Value.ToString();
                txtAd.Text = selectedRow.Cells["ad"].Value.ToString();
                txtSoyad.Text = selectedRow.Cells["soyad"].Value.ToString();
                txtAdres.Text = selectedRow.Cells["adres"].Value.ToString();
                txtTel.Text = selectedRow.Cells["telefon"].Value.ToString();
                yemek2.Text = selectedRow.Cells["yemek"].Value.ToString();
                menu2.Text = selectedRow.Cells["menu"].Value.ToString();
                icecek2.Text = selectedRow.Cells["icecek"].Value.ToString();
                islem.Text = selectedRow.Cells["durum"].Value.ToString(); // Durum verisini label'a aktar
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteSelectedRow();
        }

        private void UpdateData()
        {
            // Kullanıcı tarafından yapılan değişiklikleri al
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string adres = txtAdres.Text;
            string telefon = txtTel.Text;
            string yemek = yemek2.Text;
            string menu = menu2.Text;
            string icecek = icecek2.Text;
            string durum = islem.Text;

            // Seçilen siparişin ID'sini al
            int siparisID = Convert.ToInt32(spr_ID.Text);
            int ID = Convert.ToInt32(txtID.Text);

            // Veritabanına bağlan
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Verileri güncellemek için SQL komutunu oluştur
                string sql = "UPDATE siparis SET yemek = @yemek, menu = @menu, icecek = @icecek, durum = @durum WHERE siparisID = @siparisID";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Parametreleri ekle
                    command.Parameters.AddWithValue("@yemek", yemek);
                    command.Parameters.AddWithValue("@menu", menu);
                    command.Parameters.AddWithValue("@icecek", icecek);
                    command.Parameters.AddWithValue("@durum", durum);
                    command.Parameters.AddWithValue("@siparisID", siparisID);

                    // Komutu çalıştır
                    command.ExecuteNonQuery();
                }

                // Kullanıcı bilgilerini güncellemek için ayrı bir SQL komutu oluştur
                string updateQuery = "UPDATE Kullanicilar SET ad = @ad, soyad = @soyad, adres = @adres, telefon = @telefon WHERE ID = @ID";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    // Parametreleri ekle
                    command.Parameters.AddWithValue("@ad", ad);
                    command.Parameters.AddWithValue("@soyad", soyad);
                    command.Parameters.AddWithValue("@adres", adres);
                    command.Parameters.AddWithValue("@telefon", telefon);
                    command.Parameters.AddWithValue("@ID", siparisID);

                    // Komutu çalıştır
                    command.ExecuteNonQuery();
                }
            }

            // Kullanıcıya işlemin başarıyla gerçekleştirildiğini bildir
            MessageBox.Show("Değişiklikler kaydedildi.");
        }

        private void DeleteSelectedRow()
        {
            // Seçili satırı al
            DataGridViewRow selectedRow = null;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedRow = dataGridView1.SelectedRows[0];
            }

            // Seçili satır varsa, kullanıcıyı sil
            if (selectedRow != null)
            {
                int siparisID = Convert.ToInt32(selectedRow.Cells["siparisID"].Value);

                // Veritabanından silme işlemi
                string query = "DELETE FROM siparis WHERE siparisID = @siparisID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@siparisID", siparisID);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                // Kullanıcıya geri bildirim ver
                MessageBox.Show("Seçilen sipariş başarıyla silindi.");

                // DataGridView'i yenile
                RefreshDataGridView();
            }
        }

        private void RefreshDataGridView()
        {
            // DataGridView'i yenileme işlemi
            string query = "SELECT siparisID, siparis.ID, Kullanicilar.ad AS ad, Kullanicilar.soyad AS soyad, Kullanicilar.adres AS adres, Kullanicilar.telefon AS telefon, siparis.yemek AS yemek, siparis.menu AS menu, siparis.icecek AS icecek, siparis.durum AS durum FROM siparis INNER JOIN Kullanicilar ON siparis.ID = Kullanicilar.ID";

            // SQL bağlantısı ve komutu oluşturma
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                // Veri tablosu oluşturma ve verileri doldurma
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                // DataGridView'e verileri bağlama
                dataGridView1.DataSource = dataTable;
            }
        }
    }
}

