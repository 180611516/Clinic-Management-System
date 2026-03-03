using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Botho_Clinic_Management_System
{
    partial class frmConsultation
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TabControl tabConsultation;
        private System.Windows.Forms.TabPage tabVitals;
        private System.Windows.Forms.TabPage tabHistory;
        private System.Windows.Forms.TabPage tabPrescriptions;

        // Vitals & Notes Controls
        private System.Windows.Forms.Panel pnlPatientInfo;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblAppointmentTime;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.Label lblBloodPressure;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblPulse;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblDiagnosis;

        private System.Windows.Forms.TextBox txtTemperature;
        private System.Windows.Forms.TextBox txtBloodPressure;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.TextBox txtPulse;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TextBox txtDiagnosis;

        // Medical History Controls
        private System.Windows.Forms.DataGridView dgvMedicalHistory;

        // Prescriptions Controls
        private System.Windows.Forms.Label lblMedication;
        private System.Windows.Forms.Label lblDosage;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.ComboBox cmbMedications;
        private System.Windows.Forms.TextBox txtDosage;
        private System.Windows.Forms.TextBox txtQuantity;
        private RoundedButton btnAddPrescription;
        private System.Windows.Forms.DataGridView dgvPrescriptions;

        // Save Button
        private RoundedButton btnSaveConsultation;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Initialize all controls
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.tabConsultation = new System.Windows.Forms.TabControl();
            this.tabVitals = new System.Windows.Forms.TabPage();
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.tabPrescriptions = new System.Windows.Forms.TabPage();

            this.pnlPatientInfo = new System.Windows.Forms.Panel();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblAppointmentTime = new System.Windows.Forms.Label();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.lblBloodPressure = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblPulse = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblDiagnosis = new System.Windows.Forms.Label();

            this.txtTemperature = new System.Windows.Forms.TextBox();
            this.txtBloodPressure = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtPulse = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();

            this.dgvMedicalHistory = new System.Windows.Forms.DataGridView();

            this.lblMedication = new System.Windows.Forms.Label();
            this.lblDosage = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cmbMedications = new System.Windows.Forms.ComboBox();
            this.txtDosage = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnAddPrescription = new RoundedButton();
            this.dgvPrescriptions = new System.Windows.Forms.DataGridView();

            this.btnSaveConsultation = new RoundedButton();

            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicalHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptions)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlPatientInfo.SuspendLayout();
            this.tabConsultation.SuspendLayout();
            this.tabVitals.SuspendLayout();
            this.tabHistory.SuspendLayout();
            this.tabPrescriptions.SuspendLayout();
            this.SuspendLayout();

            // ========== FORM ==========
            this.Text = "Patient Consultation - Botho Clinic";
            this.ClientSize = new Size(1100, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(243, 246, 249);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;

            // ========== HEADER PANEL ==========
            this.pnlHeader.BackColor = Color.White;
            this.pnlHeader.Location = new Point(25, 25);
            this.pnlHeader.Size = new Size(1050, 100);
            this.pnlHeader.Paint += new PaintEventHandler(this.pnlCard_Paint);

            // Title
            this.lblTitle.Text = "🩺 Patient Consultation";
            this.lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(25, 20);

            // Subtitle
            this.lblSubtitle.Text = "Record patient vitals, diagnosis, and prescriptions";
            this.lblSubtitle.Font = new Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new Point(30, 60);

            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            // ========== TAB CONTROL ==========
            this.tabConsultation.Location = new Point(25, 145);
            this.tabConsultation.Size = new Size(1050, 520);
            this.tabConsultation.Font = new Font("Segoe UI", 11F);
            this.tabConsultation.Controls.Add(this.tabVitals);
            this.tabConsultation.Controls.Add(this.tabHistory);
            this.tabConsultation.Controls.Add(this.tabPrescriptions);

            // ========== VITALS TAB ==========
            this.tabVitals.Text = "   📋 Vitals & Notes   ";
            this.tabVitals.BackColor = Color.White;
            this.tabVitals.Padding = new Padding(25);

            // Patient Info Panel
            this.pnlPatientInfo.BackColor = Color.FromArgb(52, 152, 219);
            this.pnlPatientInfo.Location = new Point(25, 20);
            this.pnlPatientInfo.Size = new Size(980, 80);
            this.pnlPatientInfo.Paint += new PaintEventHandler(this.pnlPatientInfo_Paint);

            this.lblPatientName.Text = "Patient: Loading...";
            this.lblPatientName.Location = new Point(20, 15);
            this.lblPatientName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblPatientName.ForeColor = Color.White;
            this.lblPatientName.AutoSize = true;

            this.lblAppointmentTime.Text = "Appointment: Loading...";
            this.lblAppointmentTime.Location = new Point(20, 45);
            this.lblAppointmentTime.Font = new Font("Segoe UI", 10F);
            this.lblAppointmentTime.ForeColor = Color.FromArgb(240, 248, 255);
            this.lblAppointmentTime.AutoSize = true;

            this.pnlPatientInfo.Controls.Add(this.lblPatientName);
            this.pnlPatientInfo.Controls.Add(this.lblAppointmentTime);

            // Vitals Section - Left Column
            this.lblTemperature.Text = "Temperature (°C):";
            this.lblTemperature.Location = new Point(25, 130);
            this.lblTemperature.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTemperature.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblTemperature.AutoSize = true;

            this.txtTemperature.Location = new Point(180, 127);
            this.txtTemperature.Size = new Size(280, 27);
            this.txtTemperature.Font = new Font("Segoe UI", 11F);
            this.txtTemperature.BorderStyle = BorderStyle.FixedSingle;

            this.lblBloodPressure.Text = "Blood Pressure:";
            this.lblBloodPressure.Location = new Point(25, 175);
            this.lblBloodPressure.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblBloodPressure.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblBloodPressure.AutoSize = true;

            this.txtBloodPressure.Location = new Point(180, 172);
            this.txtBloodPressure.Size = new Size(280, 27);
            this.txtBloodPressure.Font = new Font("Segoe UI", 11F);
            this.txtBloodPressure.BorderStyle = BorderStyle.FixedSingle;

            // Vitals Section - Right Column
            this.lblWeight.Text = "Weight (kg):";
            this.lblWeight.Location = new Point(525, 130);
            this.lblWeight.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblWeight.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblWeight.AutoSize = true;

            this.txtWeight.Location = new Point(640, 127);
            this.txtWeight.Size = new Size(280, 27);
            this.txtWeight.Font = new Font("Segoe UI", 11F);
            this.txtWeight.BorderStyle = BorderStyle.FixedSingle;

            this.lblPulse.Text = "Pulse (bpm):";
            this.lblPulse.Location = new Point(525, 175);
            this.lblPulse.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblPulse.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblPulse.AutoSize = true;

            this.txtPulse.Location = new Point(640, 172);
            this.txtPulse.Size = new Size(280, 27);
            this.txtPulse.Font = new Font("Segoe UI", 11F);
            this.txtPulse.BorderStyle = BorderStyle.FixedSingle;

            // Clinical Notes Section
            this.lblNotes.Text = "📝 Clinical Notes:";
            this.lblNotes.Location = new Point(25, 230);
            this.lblNotes.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblNotes.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblNotes.AutoSize = true;

            this.txtNotes.Location = new Point(25, 260);
            this.txtNotes.Size = new Size(970, 80);
            this.txtNotes.Multiline = true;
            this.txtNotes.Font = new Font("Segoe UI", 10F);
            this.txtNotes.BorderStyle = BorderStyle.FixedSingle;
            this.txtNotes.ScrollBars = ScrollBars.Vertical;

            // Diagnosis Section
            this.lblDiagnosis.Text = "🔍 Diagnosis:";
            this.lblDiagnosis.Location = new Point(25, 360);
            this.lblDiagnosis.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblDiagnosis.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblDiagnosis.AutoSize = true;

            this.txtDiagnosis.Location = new Point(25, 390);
            this.txtDiagnosis.Size = new Size(970, 80);
            this.txtDiagnosis.Multiline = true;
            this.txtDiagnosis.Font = new Font("Segoe UI", 10F);
            this.txtDiagnosis.BorderStyle = BorderStyle.FixedSingle;
            this.txtDiagnosis.ScrollBars = ScrollBars.Vertical;

            this.tabVitals.Controls.AddRange(new Control[] {
                pnlPatientInfo,
                lblTemperature, txtTemperature,
                lblBloodPressure, txtBloodPressure,
                lblWeight, txtWeight,
                lblPulse, txtPulse,
                lblNotes, txtNotes,
                lblDiagnosis, txtDiagnosis
            });

            // ========== MEDICAL HISTORY TAB ==========
            this.tabHistory.Text = "   📚 Medical History   ";
            this.tabHistory.BackColor = Color.White;
            this.tabHistory.Padding = new Padding(25);

            this.dgvMedicalHistory.Location = new Point(25, 25);
            this.dgvMedicalHistory.Size = new Size(980, 440);
            this.dgvMedicalHistory.ReadOnly = true;
            this.dgvMedicalHistory.AllowUserToAddRows = false;
            this.dgvMedicalHistory.AllowUserToDeleteRows = false;
            this.dgvMedicalHistory.BackgroundColor = Color.White;
            this.dgvMedicalHistory.BorderStyle = BorderStyle.None;
            this.dgvMedicalHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMedicalHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvMedicalHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            this.dgvMedicalHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvMedicalHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.dgvMedicalHistory.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            this.dgvMedicalHistory.ColumnHeadersHeight = 45;
            this.dgvMedicalHistory.DefaultCellStyle.BackColor = Color.White;
            this.dgvMedicalHistory.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            this.dgvMedicalHistory.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvMedicalHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            this.dgvMedicalHistory.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvMedicalHistory.DefaultCellStyle.Padding = new Padding(8);
            this.dgvMedicalHistory.EnableHeadersVisualStyles = false;
            this.dgvMedicalHistory.GridColor = Color.FromArgb(236, 240, 241);
            this.dgvMedicalHistory.RowHeadersVisible = false;
            this.dgvMedicalHistory.RowTemplate.Height = 40;
            this.dgvMedicalHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicalHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.tabHistory.Controls.Add(this.dgvMedicalHistory);

            // ========== PRESCRIPTIONS TAB ==========
            this.tabPrescriptions.Text = "   💊 Prescriptions   ";
            this.tabPrescriptions.BackColor = Color.White;
            this.tabPrescriptions.Padding = new Padding(25);

            // Labels
            this.lblMedication.Text = "Medication:";
            this.lblMedication.Location = new Point(25, 25);
            this.lblMedication.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblMedication.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblMedication.AutoSize = true;

            this.lblDosage.Text = "Dosage:";
            this.lblDosage.Location = new Point(330, 25);
            this.lblDosage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDosage.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblDosage.AutoSize = true;

            this.lblQuantity.Text = "Quantity:";
            this.lblQuantity.Location = new Point(560, 25);
            this.lblQuantity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblQuantity.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblQuantity.AutoSize = true;

            // Input Controls
            this.cmbMedications.Location = new Point(25, 50);
            this.cmbMedications.Size = new Size(290, 27);
            this.cmbMedications.Font = new Font("Segoe UI", 11F);
            this.cmbMedications.DropDownStyle = ComboBoxStyle.DropDownList;

            this.txtDosage.Location = new Point(330, 50);
            this.txtDosage.Size = new Size(215, 27);
            this.txtDosage.Font = new Font("Segoe UI", 11F);
            this.txtDosage.BorderStyle = BorderStyle.FixedSingle;

            this.txtQuantity.Location = new Point(560, 50);
            this.txtQuantity.Size = new Size(130, 27);
            this.txtQuantity.Font = new Font("Segoe UI", 11F);
            this.txtQuantity.BorderStyle = BorderStyle.FixedSingle;

            this.btnAddPrescription.Text = "➕ Add";
            this.btnAddPrescription.Location = new Point(710, 48);
            this.btnAddPrescription.Size = new Size(120, 35);
            this.btnAddPrescription.BackColor = Color.FromArgb(46, 204, 113);
            this.btnAddPrescription.ForeColor = Color.White;
            this.btnAddPrescription.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnAddPrescription.FlatStyle = FlatStyle.Flat;
            this.btnAddPrescription.FlatAppearance.BorderSize = 0;
            this.btnAddPrescription.Cursor = Cursors.Hand;
            this.btnAddPrescription.Click += new EventHandler(btnAddPrescription_Click);
            this.btnAddPrescription.MouseEnter += new EventHandler(btnAdd_MouseEnter);
            this.btnAddPrescription.MouseLeave += new EventHandler(btnAdd_MouseLeave);

            this.dgvPrescriptions.Location = new Point(25, 105);
            this.dgvPrescriptions.Size = new Size(980, 360);
            this.dgvPrescriptions.AllowUserToAddRows = false;
            this.dgvPrescriptions.BackgroundColor = Color.White;
            this.dgvPrescriptions.BorderStyle = BorderStyle.None;
            this.dgvPrescriptions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPrescriptions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvPrescriptions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 204, 113);
            this.dgvPrescriptions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvPrescriptions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.dgvPrescriptions.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            this.dgvPrescriptions.ColumnHeadersHeight = 45;
            this.dgvPrescriptions.DefaultCellStyle.BackColor = Color.White;
            this.dgvPrescriptions.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            this.dgvPrescriptions.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvPrescriptions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 204, 113);
            this.dgvPrescriptions.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvPrescriptions.DefaultCellStyle.Padding = new Padding(8);
            this.dgvPrescriptions.EnableHeadersVisualStyles = false;
            this.dgvPrescriptions.GridColor = Color.FromArgb(236, 240, 241);
            this.dgvPrescriptions.RowHeadersVisible = false;
            this.dgvPrescriptions.RowTemplate.Height = 40;
            this.dgvPrescriptions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrescriptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrescriptions.ColumnCount = 3;
            this.dgvPrescriptions.Columns[0].Name = "Medication";
            this.dgvPrescriptions.Columns[1].Name = "Dosage";
            this.dgvPrescriptions.Columns[2].Name = "Quantity";

            this.tabPrescriptions.Controls.AddRange(new Control[] {
                lblMedication, lblDosage, lblQuantity,
                cmbMedications, txtDosage, txtQuantity,
                btnAddPrescription, dgvPrescriptions
            });

            // ========== SAVE BUTTON ==========
            this.btnSaveConsultation.Text = "💾 Save Consultation";
            this.btnSaveConsultation.Location = new Point(850, 680);
            this.btnSaveConsultation.Size = new Size(225, 50);
            this.btnSaveConsultation.BackColor = Color.FromArgb(52, 152, 219);
            this.btnSaveConsultation.ForeColor = Color.White;
            this.btnSaveConsultation.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.btnSaveConsultation.FlatStyle = FlatStyle.Flat;
            this.btnSaveConsultation.FlatAppearance.BorderSize = 0;
            this.btnSaveConsultation.Cursor = Cursors.Hand;
            this.btnSaveConsultation.Click += new EventHandler(btnSaveConsultation_Click);
            this.btnSaveConsultation.MouseEnter += new EventHandler(btnSave_MouseEnter);
            this.btnSaveConsultation.MouseLeave += new EventHandler(btnSave_MouseLeave);

            // ========== ADD CONTROLS TO FORM ==========
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.tabConsultation);
            this.Controls.Add(this.btnSaveConsultation);

            // End initialization
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicalHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptions)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlPatientInfo.ResumeLayout(false);
            this.pnlPatientInfo.PerformLayout();
            this.tabConsultation.ResumeLayout(false);
            this.tabVitals.ResumeLayout(false);
            this.tabVitals.PerformLayout();
            this.tabHistory.ResumeLayout(false);
            this.tabPrescriptions.ResumeLayout(false);
            this.tabPrescriptions.PerformLayout();
            this.ResumeLayout(false);
        }

        // ========== PAINT EVENTS ==========

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw shadow
            for (int i = 5; i > 0; i--)
            {
                using (GraphicsPath shadowPath = GetRoundedRectangle(
                    new Rectangle(i, i, panel.Width - 1, panel.Height - 1), 12))
                using (Pen shadowPen = new Pen(Color.FromArgb(8 - i, 0, 0, 0), 1))
                {
                    e.Graphics.DrawPath(shadowPen, shadowPath);
                }
            }

            // Draw card
            using (GraphicsPath path = GetRoundedRectangle(
                new Rectangle(0, 0, panel.Width - 1, panel.Height - 1), 12))
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                e.Graphics.FillPath(brush, path);
            }
        }

        private void pnlPatientInfo_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw with gradient
            using (GraphicsPath path = GetRoundedRectangle(
                new Rectangle(0, 0, panel.Width - 1, panel.Height - 1), 10))
            using (LinearGradientBrush brush = new LinearGradientBrush(
                panel.ClientRectangle,
                Color.FromArgb(52, 152, 219),
                Color.FromArgb(41, 128, 185),
                LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillPath(brush, path);
            }
        }

        // ========== HELPER METHODS ==========

        private GraphicsPath GetRoundedRectangle(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        // ========== BUTTON HOVER EFFECTS ==========

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSaveConsultation.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSaveConsultation.BackColor = Color.FromArgb(52, 152, 219);
        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAddPrescription.BackColor = Color.FromArgb(39, 174, 96);
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAddPrescription.BackColor = Color.FromArgb(46, 204, 113);
        }

        // ========== ROUNDED BUTTON ==========

        private class RoundedButton : Button
        {
            protected override void OnPaint(PaintEventArgs pevent)
            {
                GraphicsPath path = new GraphicsPath();
                int radius = 10;
                Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

                path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
                path.AddArc(rect.Width - (radius * 2), rect.Y, radius * 2, radius * 2, 270, 90);
                path.AddArc(rect.Width - (radius * 2), rect.Height - (radius * 2), radius * 2, radius * 2, 0, 90);
                path.AddArc(rect.X, rect.Height - (radius * 2), radius * 2, radius * 2, 90, 90);
                path.CloseFigure();

                this.Region = new Region(path);
                pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                base.OnPaint(pevent);
            }
        }
    }
}