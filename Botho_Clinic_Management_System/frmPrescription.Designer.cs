namespace Botho_Clinic_Management_System
{
    partial class frmPrescription
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvPrescriptions;
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
            this.dgvPrescriptions = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptions)).BeginInit();
            this.SuspendLayout();

            // dgvPrescriptions
            this.dgvPrescriptions.Location = new System.Drawing.Point(20, 60);
            this.dgvPrescriptions.Size = new System.Drawing.Size(760, 350);
            this.dgvPrescriptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrescriptions.ReadOnly = true;
            this.dgvPrescriptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrescriptions.MultiSelect = false;

            // btnRefresh
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(20, 20);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // frmPrescription
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvPrescriptions);
            this.Controls.Add(this.btnRefresh);
            this.Text = "Provider Prescriptions";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptions)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
