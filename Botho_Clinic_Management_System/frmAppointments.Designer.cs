namespace Botho_Clinic_Management_System
{
    partial class frmAppointments
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Button btnLoadAppointments;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.Button btnOpenConsultation;
        private System.Windows.Forms.ComboBox cmbStudents;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.btnLoadAppointments = new System.Windows.Forms.Button();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.btnOpenConsultation = new System.Windows.Forms.Button();
            this.cmbStudents = new System.Windows.Forms.ComboBox(); 

            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();

            // dgvAppointments
            this.dgvAppointments.Location = new System.Drawing.Point(20, 110);
            this.dgvAppointments.Size = new System.Drawing.Size(760, 320);
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.MultiSelect = false;

            // cmbStudents
            this.cmbStudents.Location = new System.Drawing.Point(20, 20);
            this.cmbStudents.Size = new System.Drawing.Size(200, 30);
            this.cmbStudents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // btnLoadAppointments
            this.btnLoadAppointments.Text = "Load Appointments";
            this.btnLoadAppointments.Location = new System.Drawing.Point(240, 20);
            this.btnLoadAppointments.Click += new System.EventHandler(this.btnLoadAppointments_Click);

            // btnAddAppointment
            this.btnAddAppointment.Text = "Add Appointment";
            this.btnAddAppointment.Location = new System.Drawing.Point(400, 20);
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);

            // btnOpenConsultation
            this.btnOpenConsultation.Text = "Open Consultation";
            this.btnOpenConsultation.Location = new System.Drawing.Point(560, 20);
            this.btnOpenConsultation.Click += new System.EventHandler(this.btnOpenConsultation_Click);

            // frmAppointments
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.cmbStudents);
            this.Controls.Add(this.btnLoadAppointments);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.btnOpenConsultation);
            this.Text = "Appointments";

            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
