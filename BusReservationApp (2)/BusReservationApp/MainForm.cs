using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BusReservationApp
{
    public partial class MainForm : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=;database=bus_reservation");

        public MainForm()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM tickets";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadData Error: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO tickets (name, bus_number, destination, date) VALUES (@name, @bus, @dest, @date)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@bus", txtBusNumber.Text);
                cmd.Parameters.AddWithValue("@dest", txtDestination.Text);
                cmd.Parameters.AddWithValue("@date", datePicker.Value);
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "UPDATE tickets SET name=@name, bus_number=@bus, destination=@dest, date=@date WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@bus", txtBusNumber.Text);
                cmd.Parameters.AddWithValue("@dest", txtDestination.Text);
                cmd.Parameters.AddWithValue("@date", datePicker.Value);
                cmd.Parameters.AddWithValue("@id", txtId.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM tickets WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", txtId.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtBusNumber.Text = dataGridView1.Rows[e.RowIndex].Cells["Bus_Number"].Value.ToString();
                txtDestination.Text = dataGridView1.Rows[e.RowIndex].Cells["Destination"].Value.ToString();
                datePicker.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["Date"].Value);
            }
        }

        void ClearForm()
        {
            txtId.Clear();
            txtName.Clear();
            txtBusNumber.Clear();
            txtDestination.Clear();
            datePicker.Value = DateTime.Now;
        }
    }
}