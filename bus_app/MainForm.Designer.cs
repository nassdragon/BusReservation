using System;
using System.Windows.Forms;

namespace BusReservationSystem
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dataGridView1;
        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtBusNumber;
        private TextBox txtDestination;
        private TextBox txtSeatNumber;
        private DateTimePicker datePicker;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnCheckTicketQuota;
        private Button btnCheckBusQuota;
        private Button btnPrintTicket;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtId = new TextBox();
            this.txtName = new TextBox();
            this.txtBusNumber = new TextBox();
            this.txtDestination = new TextBox();
            this.txtSeatNumber = new TextBox();
            this.datePicker = new DateTimePicker();
            this.btnAdd = new Button();
            this.btnUpdate = new Button();
            this.btnDelete = new Button();
            this.btnCheckTicketQuota = new Button();
            this.btnCheckBusQuota = new Button();
            this.btnPrintTicket = new Button();
            this.dataGridView1 = new DataGridView();

            Label lblId = new Label();
            Label lblName = new Label();
            Label lblBus = new Label();
            Label lblDest = new Label();
            Label lblSeat = new Label();
            Label lblDate = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // Label ID
            lblId.Text = "ID:";
            lblId.Location = new System.Drawing.Point(30, 20);
            lblId.AutoSize = true;

            // TextBox ID
            txtId.Location = new System.Drawing.Point(130, 20);
            txtId.Width = 200;
            txtId.ReadOnly = true;

            // Label Name
            lblName.Text = "Name:";
            lblName.Location = new System.Drawing.Point(30, 60);
            lblName.AutoSize = true;

            // TextBox Name
            txtName.Location = new System.Drawing.Point(130, 60);
            txtName.Width = 200;

            // Label Bus Number
            lblBus.Text = "Bus Number:";
            lblBus.Location = new System.Drawing.Point(30, 100);
            lblBus.AutoSize = true;

            // TextBox Bus Number
            txtBusNumber.Location = new System.Drawing.Point(130, 100);
            txtBusNumber.Width = 200;

            // Label Destination
            lblDest.Text = "Destination:";
            lblDest.Location = new System.Drawing.Point(30, 140);
            lblDest.AutoSize = true;

            // TextBox Destination
            txtDestination.Location = new System.Drawing.Point(130, 140);
            txtDestination.Width = 200;

            // Label Seat Number
            lblSeat.Text = "Seat Number:";
            lblSeat.Location = new System.Drawing.Point(30, 180);
            lblSeat.AutoSize = true;

            // TextBox Seat Number
            txtSeatNumber.Location = new System.Drawing.Point(130, 180);
            txtSeatNumber.Width = 200;

            // Label Date
            lblDate.Text = "Date:";
            lblDate.Location = new System.Drawing.Point(30, 220);
            lblDate.AutoSize = true;

            // DatePicker
            datePicker.Location = new System.Drawing.Point(130, 220);
            datePicker.Width = 200;

            // Button Add
            btnAdd.Text = "Add";
            btnAdd.Location = new System.Drawing.Point(400, 40);
            btnAdd.Width = 100;

            // Button Update
            btnUpdate.Text = "Update";
            btnUpdate.Location = new System.Drawing.Point(400, 80);
            btnUpdate.Width = 100;

            // Button Delete
            btnDelete.Text = "Delete";
            btnDelete.Location = new System.Drawing.Point(400, 120);
            btnDelete.Width = 100;

            // Button Check Ticket Quota
            btnCheckTicketQuota.Text = "Check Ticket Quota";
            btnCheckTicketQuota.Location = new System.Drawing.Point(520, 40);
            btnCheckTicketQuota.Width = 150;

            // Button Check Bus Quota
            btnCheckBusQuota.Text = "Check Bus Quota";
            btnCheckBusQuota.Location = new System.Drawing.Point(520, 80);
            btnCheckBusQuota.Width = 150;

            // Button Print Ticket
            btnPrintTicket.Text = "Print Ticket";
            btnPrintTicket.Location = new System.Drawing.Point(520, 120);
            btnPrintTicket.Width = 150;

            // DataGridView
            dataGridView1.Location = new System.Drawing.Point(30, 260);
            dataGridView1.Size = new System.Drawing.Size(740, 300);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Add controls to the Form
            this.Controls.Add(lblId);
            this.Controls.Add(txtId);
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblBus);
            this.Controls.Add(txtBusNumber);
            this.Controls.Add(lblDest);
            this.Controls.Add(txtDestination);
            this.Controls.Add(lblSeat);
            this.Controls.Add(txtSeatNumber);
            this.Controls.Add(lblDate);
            this.Controls.Add(datePicker);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnCheckTicketQuota);
            this.Controls.Add(btnCheckBusQuota);
            this.Controls.Add(btnPrintTicket);
            this.Controls.Add(dataGridView1);

            // Form settings
            this.Text = "Bus Reservation System";
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Events
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            this.btnCheckTicketQuota.Click += new EventHandler(this.btnCheckTicketQuota_Click);
            this.btnCheckBusQuota.Click += new EventHandler(this.btnCheckBusQuota_Click);
            this.btnPrintTicket.Click += new EventHandler(this.btnPrintTicket_Click);
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
