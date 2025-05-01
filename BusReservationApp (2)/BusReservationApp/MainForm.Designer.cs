namespace BusReservationApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtBusNumber;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblBusNumber;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Label lblDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtBusNumber = new System.Windows.Forms.TextBox();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblBusNumber = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "Bus Ticket Reservation";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(180, 10);
            this.lblTitle.Size = new System.Drawing.Size(300, 40);

            // lblId
            this.lblId.Text = "ID";
            this.lblId.Location = new System.Drawing.Point(20, 45);
            this.lblId.Size = new System.Drawing.Size(100, 15);

            // txtId
            this.txtId.Location = new System.Drawing.Point(20, 75);  // Posisi teks sedikit lebih jauh
            this.txtId.Size = new System.Drawing.Size(200, 22);
            this.txtId.ReadOnly = true;

            // lblName
            this.lblName.Text = "Name";
            this.lblName.Location = new System.Drawing.Point(20, 105);
            this.lblName.Size = new System.Drawing.Size(100, 15);

            // txtName
            this.txtName.Location = new System.Drawing.Point(20, 135);  // Posisi teks sedikit lebih jauh
            this.txtName.Size = new System.Drawing.Size(200, 22);

            // lblBusNumber
            this.lblBusNumber.Text = "Bus Number";
            this.lblBusNumber.Location = new System.Drawing.Point(20, 165);
            this.lblBusNumber.Size = new System.Drawing.Size(100, 15);

            // txtBusNumber
            this.txtBusNumber.Location = new System.Drawing.Point(20, 195);  // Posisi teks sedikit lebih jauh
            this.txtBusNumber.Size = new System.Drawing.Size(200, 22);

            // lblDestination
            this.lblDestination.Text = "Destination";
            this.lblDestination.Location = new System.Drawing.Point(20, 225);
            this.lblDestination.Size = new System.Drawing.Size(100, 15);

            // txtDestination
            this.txtDestination.Location = new System.Drawing.Point(20, 255);  // Posisi teks sedikit lebih jauh
            this.txtDestination.Size = new System.Drawing.Size(200, 22);

            // lblDate
            this.lblDate.Text = "Date";
            this.lblDate.Location = new System.Drawing.Point(20, 285);
            this.lblDate.Size = new System.Drawing.Size(100, 15);

            // datePicker
            this.datePicker.Location = new System.Drawing.Point(20, 315);  // Posisi teks sedikit lebih jauh
            this.datePicker.Size = new System.Drawing.Size(200, 22);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(250, 60);
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.Text = "Add";
            this.btnAdd.BackColor = System.Drawing.Color.LightGreen;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnUpdate
            this.btnUpdate.Location = new System.Drawing.Point(250, 100);
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(250, 140);
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.Text = "Delete";
            this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // dataGridView1
            this.dataGridView1.Location = new System.Drawing.Point(20, 350);
            this.dataGridView1.Size = new System.Drawing.Size(500, 200);
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            // MainForm
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblBusNumber);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtBusNumber);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridView1);
            this.Text = "Bus Ticket Reservation";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
