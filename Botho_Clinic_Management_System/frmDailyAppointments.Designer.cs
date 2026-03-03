namespace Botho_Clinic_Management_System
{
    partial class frmDailyAppointments
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();

            // dgvAppointments
            this.dgvAppointments.Location = new System.Drawing.Point(20, 60);
            this.dgvAppointments.Size = new System.Drawing.Size(760, 350);
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.MultiSelect = false;
            this.dgvAppointments.ReadOnly = true;

            // btnRefresh
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(20, 20);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // frmDailyAppointments
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.btnRefresh);
            this.Text = "Daily Appointments";

            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
