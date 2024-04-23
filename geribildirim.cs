using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace yemekotomasyonu
{
    public partial class geribildirim : Form
    {
        string connectionString = "Server=DESKTOP-OF8K7QI\\MSSQL;Database=yemekotomasyonu;Trusted_Connection=True;";

        public geribildirim()
        {
            InitializeComponent();
        }

        private void geribildirim_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            string query = "SELECT mesajID, Kullanicilar.ID, Kullanicilar.ad AS ad, Kullanicilar.soyad AS soyad, Kullanicilar.adres AS adres, Kullanicilar.telefon AS telefon, Mesajlar.mesaj AS mesaj FROM Mesajlar INNER JOIN Kullanicilar ON Mesajlar.kullaniciID = Kullanicilar.ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                txtID.Text = selectedRow.Cells["ID"].Value.ToString();
                spr_ID.Text = selectedRow.Cells["mesajID"].Value.ToString();
                txtAd.Text = selectedRow.Cells["ad"].Value.ToString();
                txtSoyad.Text = selectedRow.Cells["soyad"].Value.ToString();
                txtAdres.Text = selectedRow.Cells["adres"].Value.ToString();
                txtTel.Text = selectedRow.Cells["telefon"].Value.ToString();
                textBox1.Text = selectedRow.Cells["mesaj"].Value.ToString();
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
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string adres = txtAdres.Text;
            string telefon = txtTel.Text;
            string mesaj = textBox1.Text;

            int mesajID = Convert.ToInt32(spr_ID.Text);
            int kullaniciID = Convert.ToInt32(txtID.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "UPDATE Mesajlar SET mesaj = @mesaj WHERE mesajID = @mesajID";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@mesaj", mesaj);
                    command.Parameters.AddWithValue("@mesajID", mesajID);

                    command.ExecuteNonQuery();
                }

                string updateQuery = "UPDATE Kullanicilar SET ad = @ad, soyad = @soyad, adres = @adres, telefon = @telefon WHERE ID = @ID";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@ad", ad);
                    command.Parameters.AddWithValue("@soyad", soyad);
                    command.Parameters.AddWithValue("@adres", adres);
                    command.Parameters.AddWithValue("@telefon", telefon);
                    command.Parameters.AddWithValue("@ID", kullaniciID);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Değişiklikler kaydedildi.");
        }

        private void DeleteSelectedRow()
        {
            DataGridViewRow selectedRow = null;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedRow = dataGridView1.SelectedRows[0];
            }

            if (selectedRow != null)
            {
                int mesajID = Convert.ToInt32(selectedRow.Cells["mesajID"].Value);

                string query = "DELETE FROM Mesajlar WHERE mesajID = @mesajID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@mesajID", mesajID);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Seçilen mesaj başarıyla silindi.");

                RefreshDataGridView();
            }
        }
    }
}
