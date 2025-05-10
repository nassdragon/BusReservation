using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BusReservationSystem
{
    public partial class MainForm : Form
    {
        private string connectionString = "server=localhost;user=root;password=;database=bus_app";
        private PrintDocument printDocument = new PrintDocument();
        private DataTable currentTicketData;

        public MainForm()
        {
            InitializeComponent();
            LoadData();
            printDocument.PrintPage += PrintTicketPage;
        }

        private void LoadData()
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT t.id, t.name, t.bus_number, b.route_name, t.destination, 
                                   DATE_FORMAT(t.date, '%Y-%m-%d') as date, t.seat_number, t.status
                                   FROM tickets t
                                   JOIN buses b ON t.bus_number = b.bus_number
                                   ORDER BY t.date, t.bus_number";
                    var adapter = new MySqlDataAdapter(query, conn);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO tickets (name, bus_number, destination, date, seat_number)
                                   VALUES (@name, @bus, @dest, @date, @seat)";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@bus", txtBusNumber.Text);
                    cmd.Parameters.AddWithValue("@dest", txtDestination.Text);
                    cmd.Parameters.AddWithValue("@date", datePicker.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@seat", txtSeatNumber.Text);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding reservation: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Please select a reservation to update");
                return;
            }

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE tickets SET name=@name, bus_number=@bus, 
                                   destination=@dest, date=@date, seat_number=@seat
                                   WHERE id=@id";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@bus", txtBusNumber.Text);
                    cmd.Parameters.AddWithValue("@dest", txtDestination.Text);
                    cmd.Parameters.AddWithValue("@date", datePicker.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@seat", txtSeatNumber.Text);
                    cmd.Parameters.AddWithValue("@id", txtId.Text);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating reservation: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Please select a reservation to delete");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this reservation?", 
                "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM tickets WHERE id=@id";
                        var cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", txtId.Text);
                        cmd.ExecuteNonQuery();
                    }
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting reservation: " + ex.Message);
                }
            }
        }

        private void btnCheckTicketQuota_Click(object sender, EventArgs e)
        {
            using (var form = new Form())
            {
                form.Text = "Check Ticket Quota";
                form.Size = new Size(400, 250);
                form.StartPosition = FormStartPosition.CenterParent;

                var lblBus = new Label { Text = "Bus Number:", Left = 20, Top = 20, Width = 100 };
                var txtBus = new TextBox { Left = 130, Top = 20, Width = 100 };
                var lblDate = new Label { Text = "Date:", Left = 20, Top = 60, Width = 100 };
                var dtpDate = new DateTimePicker { Left = 130, Top = 60, Width = 120 };
                var btnCheck = new Button { Text = "Check", Left = 150, Top = 100, Width = 100 };
                var txtResult = new TextBox { Left = 20, Top = 140, Width = 350, Height = 60, 
                                            Multiline = true, ReadOnly = true };

                btnCheck.Click += (s, args) =>
                {
                    try
                    {
                        using (var conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();
                            
                            // Get bus capacity
                            string capacityQuery = "SELECT capacity FROM buses WHERE bus_number = @bus";
                            var capacityCmd = new MySqlCommand(capacityQuery, conn);
                            capacityCmd.Parameters.AddWithValue("@bus", txtBus.Text);
                            int capacity = Convert.ToInt32(capacityCmd.ExecuteScalar());
                            
                            // Get booked tickets count
                            string bookedQuery = @"SELECT COUNT(*) FROM tickets 
                                                  WHERE bus_number = @bus AND date = @date 
                                                  AND status = 'booked'";
                            var bookedCmd = new MySqlCommand(bookedQuery, conn);
                            bookedCmd.Parameters.AddWithValue("@bus", txtBus.Text);
                            bookedCmd.Parameters.AddWithValue("@date", dtpDate.Value.ToString("yyyy-MM-dd"));
                            int booked = Convert.ToInt32(bookedCmd.ExecuteScalar());
                            
                            txtResult.Text = $"Ticket Quota for Bus {txtBus.Text} on {dtpDate.Value.ToShortDateString()}:\n" +
                                            $"Total Capacity: {capacity}\n" +
                                            $"Booked Seats: {booked}\n" +
                                            $"Available Seats: {capacity - booked}";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error checking ticket quota: " + ex.Message);
                    }
                };

                form.Controls.AddRange(new Control[] { lblBus, txtBus, lblDate, dtpDate, btnCheck, txtResult });
                form.ShowDialog(this);
            }
        }

        private void btnCheckBusQuota_Click(object sender, EventArgs e)
        {
            using (var form = new Form())
            {
                form.Text = "Check Bus Quota";
                form.Size = new Size(500, 350);
                form.StartPosition = FormStartPosition.CenterParent;

                var lblBus = new Label { Text = "Bus Number:", Left = 20, Top = 20, Width = 100 };
                var txtBus = new TextBox { Left = 130, Top = 20, Width = 100 };
                var btnCheck = new Button { Text = "Check", Left = 150, Top = 60, Width = 100 };
                var txtResult = new TextBox { Left = 20, Top = 100, Width = 450, Height = 200, 
                                            Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical };

                btnCheck.Click += (s, args) =>
                {
                    try
                    {
                        using (var conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();
                            
                            // Get bus information
                            string busQuery = @"SELECT bus_number, route_name, capacity, 
                                              departure_time, arrival_time, price 
                                              FROM buses WHERE bus_number = @bus";
                            var busCmd = new MySqlCommand(busQuery, conn);
                            busCmd.Parameters.AddWithValue("@bus", txtBus.Text);
                            
                            using (var reader = busCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int busNumber = reader.GetInt32("bus_number");
                                    string route = reader.GetString("route_name");
                                    int capacity = reader.GetInt32("capacity");
                                    TimeSpan departureTime = reader.GetTimeSpan("departure_time");
                                    TimeSpan arrivalTime = reader.GetTimeSpan("arrival_time");
                                    decimal price = reader.GetDecimal("price");
                                    
                                    reader.Close();
                                    
                                    // Get total bookings
                                    string totalQuery = @"SELECT COUNT(*) FROM tickets 
                                                        WHERE bus_number = @bus 
                                                        AND status = 'booked'";
                                    var totalCmd = new MySqlCommand(totalQuery, conn);
                                    totalCmd.Parameters.AddWithValue("@bus", busNumber);
                                    int totalBookings = Convert.ToInt32(totalCmd.ExecuteScalar());
                                    
                                    // Get next departure
                                    string nextQuery = @"SELECT MIN(date) FROM tickets 
                                                       WHERE bus_number = @bus 
                                                       AND date >= CURDATE() 
                                                       AND status = 'booked'";
                                    var nextCmd = new MySqlCommand(nextQuery, conn);
                                    nextCmd.Parameters.AddWithValue("@bus", busNumber);
                                    object nextDate = nextCmd.ExecuteScalar();
                                    
                                    txtResult.Text = $"Bus Quota Information:\n\n" +
                                                    $"Bus Number: {busNumber}\n" +
                                                    $"Route: {route}\n" +
                                                    $"Capacity: {capacity}\n" +
                                                    $"Departure Time: {departureTime}\n" +
                                                    $"Arrival Time: {arrivalTime}\n" +
                                                    $"Ticket Price: {price:C}\n" +
                                                    $"Total Active Bookings: {totalBookings}\n" +
                                                    $"Next Departure: {(nextDate != DBNull.Value ? Convert.ToDateTime(nextDate).ToShortDateString() : "None")}\n\n";
                                    
                                    // Get recent trips
                                    string tripsQuery = @"SELECT destination, date, COUNT(*) as passengers 
                                                        FROM tickets 
                                                        WHERE bus_number = @bus 
                                                        AND status = 'completed'
                                                        GROUP BY destination, date 
                                                        ORDER BY date DESC 
                                                        LIMIT 5";
                                    var tripsCmd = new MySqlCommand(tripsQuery, conn);
                                    tripsCmd.Parameters.AddWithValue("@bus", busNumber);
                                    
                                    using (var tripsReader = tripsCmd.ExecuteReader())
                                    {
                                        txtResult.Text += "Recent Completed Trips:\n";
                                        while (tripsReader.Read())
                                        {
                                            txtResult.Text += $"{tripsReader["date"]} - {tripsReader["destination"]} " +
                                                             $"(Passengers: {tripsReader["passengers"]})\n";
                                        }
                                    }
                                }
                                else
                                {
                                    txtResult.Text = "Bus not found!";
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error checking bus quota: " + ex.Message);
                    }
                };

                form.Controls.AddRange(new Control[] { lblBus, txtBus, btnCheck, txtResult });
                form.ShowDialog(this);
            }
        }

        private void btnPrintTicket_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Please select a reservation first!");
                return;
            }

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT t.id, t.name, t.bus_number, b.route_name, t.destination, 
                                   t.date, b.departure_time, b.arrival_time, b.price, t.seat_number
                                   FROM tickets t
                                   JOIN buses b ON t.bus_number = b.bus_number
                                   WHERE t.id = @id";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtId.Text);
                    
                    var adapter = new MySqlDataAdapter(cmd);
                    currentTicketData = new DataTable();
                    adapter.Fill(currentTicketData);
                    
                    if (currentTicketData.Rows.Count > 0)
                    {
                        PrintPreviewDialog preview = new PrintPreviewDialog();
                        preview.Document = printDocument;
                        preview.ShowDialog(this);
                    }
                    else
                    {
                        MessageBox.Show("Ticket not found!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error preparing ticket for printing: " + ex.Message);
            }
        }

        private void PrintTicketPage(object sender, PrintPageEventArgs e)
        {
            if (currentTicketData == null || currentTicketData.Rows.Count == 0) return;
            
            DataRow ticket = currentTicketData.Rows[0];
            
            // Create fonts
            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 10);
            
            // Draw ticket
            int yPos = 50;
            
            // Ticket header
            e.Graphics.DrawString("BUS TICKET", titleFont, Brushes.Black, 100, yPos);
            yPos += 40;
            
            // Ticket details
            e.Graphics.DrawString($"Ticket ID: {ticket["id"]}", headerFont, Brushes.Black, 50, yPos);
            yPos += 30;
            e.Graphics.DrawString($"Passenger: {ticket["name"]}", normalFont, Brushes.Black, 50, yPos);
            yPos += 20;
            e.Graphics.DrawString($"Bus: {ticket["bus_number"]} ({ticket["route_name"]})", normalFont, Brushes.Black, 50, yPos);
            yPos += 20;
            e.Graphics.DrawString($"Seat Number: {ticket["seat_number"]}", normalFont, Brushes.Black, 50, yPos);
            yPos += 20;
            e.Graphics.DrawString($"Date: {Convert.ToDateTime(ticket["date"]).ToShortDateString()}", normalFont, Brushes.Black, 50, yPos);
            yPos += 20;
            e.Graphics.DrawString($"Departure: {ticket["departure_time"]}", normalFont, Brushes.Black, 50, yPos);
            yPos += 20;
            e.Graphics.DrawString($"Arrival: {ticket["arrival_time"]}", normalFont, Brushes.Black, 50, yPos);
            yPos += 20;
            e.Graphics.DrawString($"Price: {Convert.ToDecimal(ticket["price"]):C}", headerFont, Brushes.Black, 50, yPos);
            yPos += 40;
            
            // QR code placeholder
            e.Graphics.DrawRectangle(Pens.Black, 100, yPos, 100, 100);
            e.Graphics.DrawString("QR CODE", normalFont, Brushes.Black, 120, yPos + 40);
            
            // Footer
            yPos += 120;
            e.Graphics.DrawString("Thank you for traveling with us!", normalFont, Brushes.Black, 70, yPos);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtId.Text = row.Cells["id"].Value.ToString();
                txtName.Text = row.Cells["name"].Value.ToString();
                txtBusNumber.Text = row.Cells["bus_number"].Value.ToString();
                datePicker.Value = DateTime.Parse(row.Cells["date"].Value.ToString());
                txtSeatNumber.Text = row.Cells["seat_number"].Value?.ToString() ?? "";
            }
        }

        private void ClearForm()
        {
            txtId.Clear();
            txtName.Clear();
            txtBusNumber.Clear();
            txtSeatNumber.Clear();
            datePicker.Value = DateTime.Now;
        }
    }
}
