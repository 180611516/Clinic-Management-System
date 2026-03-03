using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Botho_Clinic_Management_System
{
    partial class frmProviderDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Timer timerDateTime;
        private RoundedButton btnAppointments;
        private RoundedButton btnConsultations;
        private RoundedButton btnPrescriptions;
        private RoundedButton btnReminders;
        private RoundedButton btnUserProfile;
        private RoundedButton btnLogout;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Label lblTodayTitle;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Panel pnlCard4;
        private System.Windows.Forms.Label lblCard1Title;
        private System.Windows.Forms.Label lblCard1Value;
        private System.Windows.Forms.Label lblCard1Icon;
        private System.Windows.Forms.Label lblCard2Title;
        private System.Windows.Forms.Label lblCard2Value;
        private System.Windows.Forms.Label lblCard2Icon;
        private System.Windows.Forms.Label lblCard3Title;
        private System.Windows.Forms.Label lblCard3Value;
        private System.Windows.Forms.Label lblCard3Icon;
        private System.Windows.Forms.Label lblCard4Title;
        private System.Windows.Forms.Label lblCard4Value;
        private System.Windows.Forms.Label lblCard4Icon;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new RoundedButton();
            this.btnUserProfile = new RoundedButton();
            this.btnReminders = new RoundedButton();
            this.btnPrescriptions = new RoundedButton();
            this.btnConsultations = new RoundedButton();
            this.btnAppointments = new RoundedButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.lblCard1Icon = new System.Windows.Forms.Label();
            this.lblCard1Value = new System.Windows.Forms.Label();
            this.lblCard1Title = new System.Windows.Forms.Label();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblCard2Icon = new System.Windows.Forms.Label();
            this.lblCard2Value = new System.Windows.Forms.Label();
            this.lblCard2Title = new System.Windows.Forms.Label();
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.lblCard3Icon = new System.Windows.Forms.Label();
            this.lblCard3Value = new System.Windows.Forms.Label();
            this.lblCard3Title = new System.Windows.Forms.Label();
            this.pnlCard4 = new System.Windows.Forms.Panel();
            this.lblCard4Icon = new System.Windows.Forms.Label();
            this.lblCard4Value = new System.Windows.Forms.Label();
            this.lblCard4Title = new System.Windows.Forms.Label();
            this.lblTodayTitle = new System.Windows.Forms.Label();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);

            this.pnlSidebar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.pnlCard4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();

            // ========== SIDEBAR ==========
            this.pnlSidebar.BackColor = Color.FromArgb(44, 62, 80);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnUserProfile);
            this.pnlSidebar.Controls.Add(this.btnReminders);
            this.pnlSidebar.Controls.Add(this.btnPrescriptions);
            this.pnlSidebar.Controls.Add(this.btnConsultations);
            this.pnlSidebar.Controls.Add(this.btnAppointments);
            this.pnlSidebar.Dock = DockStyle.Left;
            this.pnlSidebar.Size = new Size(280, 700);
            this.pnlSidebar.Paint += new PaintEventHandler(this.pnlSidebar_Paint);

            // Appointments Button
            this.btnAppointments.BackColor = Color.FromArgb(52, 152, 219);
            this.btnAppointments.FlatAppearance.BorderSize = 0;
            this.btnAppointments.FlatStyle = FlatStyle.Flat;
            this.btnAppointments.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnAppointments.ForeColor = Color.White;
            this.btnAppointments.Location = new Point(20, 120);
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.Size = new Size(240, 55);
            this.btnAppointments.TabIndex = 0;
            this.btnAppointments.Text = "📅  Appointments";
            this.btnAppointments.TextAlign = ContentAlignment.MiddleLeft;
            this.btnAppointments.Padding = new Padding(20, 0, 0, 0);
            this.btnAppointments.UseVisualStyleBackColor = false;
            this.btnAppointments.Cursor = Cursors.Hand;
            this.btnAppointments.Click += new EventHandler(this.btnAppointments_Click);
            this.btnAppointments.MouseEnter += new EventHandler(this.btn_MouseEnter);
            this.btnAppointments.MouseLeave += new EventHandler(this.btn_MouseLeave);

            // Consultations Button
            this.btnConsultations.BackColor = Color.FromArgb(52, 73, 94);
            this.btnConsultations.FlatAppearance.BorderSize = 0;
            this.btnConsultations.FlatStyle = FlatStyle.Flat;
            this.btnConsultations.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnConsultations.ForeColor = Color.White;
            this.btnConsultations.Location = new Point(20, 190);
            this.btnConsultations.Name = "btnConsultations";
            this.btnConsultations.Size = new Size(240, 55);
            this.btnConsultations.TabIndex = 1;
            this.btnConsultations.Text = "🩺  Consultations";
            this.btnConsultations.TextAlign = ContentAlignment.MiddleLeft;
            this.btnConsultations.Padding = new Padding(20, 0, 0, 0);
            this.btnConsultations.UseVisualStyleBackColor = false;
            this.btnConsultations.Cursor = Cursors.Hand;
            this.btnConsultations.Click += new EventHandler(this.btnConsultations_Click);
            this.btnConsultations.MouseEnter += new EventHandler(this.btn_MouseEnter);
            this.btnConsultations.MouseLeave += new EventHandler(this.btn_MouseLeave);

            // Prescriptions Button
            this.btnPrescriptions.BackColor = Color.FromArgb(52, 73, 94);
            this.btnPrescriptions.FlatAppearance.BorderSize = 0;
            this.btnPrescriptions.FlatStyle = FlatStyle.Flat;
            this.btnPrescriptions.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnPrescriptions.ForeColor = Color.White;
            this.btnPrescriptions.Location = new Point(20, 260);
            this.btnPrescriptions.Name = "btnPrescriptions";
            this.btnPrescriptions.Size = new Size(240, 55);
            this.btnPrescriptions.TabIndex = 2;
            this.btnPrescriptions.Text = "💊  Prescriptions";
            this.btnPrescriptions.TextAlign = ContentAlignment.MiddleLeft;
            this.btnPrescriptions.Padding = new Padding(20, 0, 0, 0);
            this.btnPrescriptions.UseVisualStyleBackColor = false;
            this.btnPrescriptions.Cursor = Cursors.Hand;
            this.btnPrescriptions.Click += new EventHandler(this.btnPrescriptions_Click);
            this.btnPrescriptions.MouseEnter += new EventHandler(this.btn_MouseEnter);
            this.btnPrescriptions.MouseLeave += new EventHandler(this.btn_MouseLeave);

            // Reminders Button
            this.btnReminders.BackColor = Color.FromArgb(52, 73, 94);
            this.btnReminders.FlatAppearance.BorderSize = 0;
            this.btnReminders.FlatStyle = FlatStyle.Flat;
            this.btnReminders.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnReminders.ForeColor = Color.White;
            this.btnReminders.Location = new Point(20, 330);
            this.btnReminders.Name = "btnReminders";
            this.btnReminders.Size = new Size(240, 55);
            this.btnReminders.TabIndex = 4;
            this.btnReminders.Text = "🔔  Reminders";
            this.btnReminders.TextAlign = ContentAlignment.MiddleLeft;
            this.btnReminders.Padding = new Padding(20, 0, 0, 0);
            this.btnReminders.UseVisualStyleBackColor = false;
            this.btnReminders.Cursor = Cursors.Hand;
            this.btnReminders.Click += new EventHandler(this.btnReminders_Click);
            this.btnReminders.MouseEnter += new EventHandler(this.btn_MouseEnter);
            this.btnReminders.MouseLeave += new EventHandler(this.btn_MouseLeave);

            // User Profile Button
            this.btnUserProfile.BackColor = Color.FromArgb(52, 73, 94);
            this.btnUserProfile.FlatAppearance.BorderSize = 0;
            this.btnUserProfile.FlatStyle = FlatStyle.Flat;
            this.btnUserProfile.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnUserProfile.ForeColor = Color.White;
            this.btnUserProfile.Location = new Point(20, 400);
            this.btnUserProfile.Name = "btnUserProfile";
            this.btnUserProfile.Size = new Size(240, 55);
            this.btnUserProfile.TabIndex = 5;
            this.btnUserProfile.Text = "👤  My Profile";
            this.btnUserProfile.TextAlign = ContentAlignment.MiddleLeft;
            this.btnUserProfile.Padding = new Padding(20, 0, 0, 0);
            this.btnUserProfile.UseVisualStyleBackColor = false;
            this.btnUserProfile.Cursor = Cursors.Hand;
            this.btnUserProfile.Click += new EventHandler(this.btnUserProfile_Click);
            this.btnUserProfile.MouseEnter += new EventHandler(this.btn_MouseEnter);
            this.btnUserProfile.MouseLeave += new EventHandler(this.btn_MouseLeave);

            // Logout Button
            this.btnLogout.BackColor = Color.FromArgb(192, 57, 43);
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.Location = new Point(20, 620);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new Size(240, 55);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "🚪  Logout";
            this.btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            this.btnLogout.Padding = new Padding(20, 0, 0, 0);
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Cursor = Cursors.Hand;
            this.btnLogout.Click += new EventHandler(this.btnLogout_Click);
            this.btnLogout.MouseEnter += new EventHandler(this.btnLogout_MouseEnter);
            this.btnLogout.MouseLeave += new EventHandler(this.btnLogout_MouseLeave);

            // ========== MAIN PANEL ==========
            this.pnlMain.BackColor = Color.FromArgb(243, 246, 249);
            this.pnlMain.Controls.Add(this.dgvAppointments);
            this.pnlMain.Controls.Add(this.lblTodayTitle);
            this.pnlMain.Controls.Add(this.pnlStats);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Location = new Point(280, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new Padding(0);
            this.pnlMain.Size = new Size(1040, 700);

            // ========== HEADER PANEL ==========
            this.pnlHeader.BackColor = Color.White;
            this.pnlHeader.Controls.Add(this.lblDateTime);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Location = new Point(25, 25);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(990, 110);
            this.pnlHeader.Paint += new PaintEventHandler(this.pnlCard_Paint);

            // Welcome Label
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblWelcome.Location = new Point(25, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Text = "👋 Welcome, Provider";

            // Subtitle Label
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblSubtitle.Location = new Point(30, 60);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "Here's your overview for today";

            // DateTime Label
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDateTime.ForeColor = Color.FromArgb(52, 152, 219);
            this.lblDateTime.Location = new Point(650, 40);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new Size(150, 19);

            // Timer
            this.timerDateTime.Enabled = true;
            this.timerDateTime.Interval = 1000;
            this.timerDateTime.Tick += new EventHandler(this.timerDateTime_Tick);

            // ========== STATS PANEL ==========
            this.pnlStats.BackColor = Color.Transparent;
            this.pnlStats.Controls.Add(this.pnlCard1);
            this.pnlStats.Controls.Add(this.pnlCard2);
            this.pnlStats.Controls.Add(this.pnlCard3);
            this.pnlStats.Controls.Add(this.pnlCard4);
            this.pnlStats.Location = new Point(25, 155);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new Size(990, 130);

            // Card 1 - Today's Appointments
            SetupStatCard(this.pnlCard1, this.lblCard1Icon, this.lblCard1Title, this.lblCard1Value,
                new Point(0, 0), "📅", "Today's Appointments", Color.FromArgb(52, 152, 219));

            // Card 2 - Completed Today
            SetupStatCard(this.pnlCard2, this.lblCard2Icon, this.lblCard2Title, this.lblCard2Value,
                new Point(250, 0), "✅", "Completed Today", Color.FromArgb(46, 204, 113));

            // Card 3 - Pending
            SetupStatCard(this.pnlCard3, this.lblCard3Icon, this.lblCard3Title, this.lblCard3Value,
                new Point(500, 0), "⏱️", "Pending", Color.FromArgb(241, 196, 15));

            // Card 4 - Total Appointments
            SetupStatCard(this.pnlCard4, this.lblCard4Icon, this.lblCard4Title, this.lblCard4Value,
                new Point(750, 0), "📊", "Total Appointments", Color.FromArgb(155, 89, 182));

            // ========== TODAY'S APPOINTMENTS TITLE ==========
            this.lblTodayTitle.AutoSize = true;
            this.lblTodayTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTodayTitle.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblTodayTitle.Location = new Point(30, 310);
            this.lblTodayTitle.Name = "lblTodayTitle";
            this.lblTodayTitle.Text = "📋 Today's Schedule";

            // ========== DATAGRIDVIEW ==========
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.BackgroundColor = Color.White;
            this.dgvAppointments.BorderStyle = BorderStyle.None;
            this.dgvAppointments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAppointments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvAppointments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            this.dgvAppointments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvAppointments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.dgvAppointments.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            this.dgvAppointments.ColumnHeadersHeight = 50;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAppointments.DefaultCellStyle.BackColor = Color.White;
            this.dgvAppointments.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            this.dgvAppointments.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvAppointments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            this.dgvAppointments.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvAppointments.DefaultCellStyle.Padding = new Padding(10, 8, 10, 8);
            this.dgvAppointments.EnableHeadersVisualStyles = false;
            this.dgvAppointments.GridColor = Color.FromArgb(236, 240, 241);
            this.dgvAppointments.Location = new Point(25, 350);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersVisible = false;
            this.dgvAppointments.RowTemplate.Height = 45;
            this.dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.Size = new Size(990, 325);
            this.dgvAppointments.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvAppointments_CellDoubleClick);

            // ========== FORM ==========
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(243, 246, 249);
            this.ClientSize = new Size(1320, 700);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "frmProviderDashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Provider Dashboard - Botho Clinic";

            this.pnlSidebar.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard1.PerformLayout();
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard2.PerformLayout();
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard3.PerformLayout();
            this.pnlCard4.ResumeLayout(false);
            this.pnlCard4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
        }

        // ========== STAT CARD SETUP ==========
        private void SetupStatCard(Panel panel, Label icon, Label title, Label value,
            Point location, string iconText, string titleText, Color bgColor)
        {
            panel.BackColor = bgColor;
            panel.Controls.Add(icon);
            panel.Controls.Add(title);
            panel.Controls.Add(value);
            panel.Location = location;
            panel.Size = new Size(235, 130);
            panel.Cursor = Cursors.Hand;
            panel.Paint += new PaintEventHandler(this.pnlStatCard_Paint);
            panel.MouseEnter += new EventHandler(this.pnlStatCard_MouseEnter);
            panel.MouseLeave += new EventHandler(this.pnlStatCard_MouseLeave);

            // Icon
            icon.Font = new Font("Segoe UI Emoji", 40F);
            icon.ForeColor = Color.FromArgb(60, 255, 255, 255);
            icon.Location = new Point(170, 35);
            icon.Size = new Size(60, 60);
            icon.Text = iconText;
            icon.TextAlign = ContentAlignment.MiddleCenter;

            // Title
            title.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(250, 255, 255, 255);
            title.Location = new Point(20, 20);
            title.AutoSize = true;
            title.MaximumSize = new Size(140, 0);
            title.Text = titleText;

            // Value
            value.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            value.ForeColor = Color.White;
            value.Location = new Point(20, 50);
            value.AutoSize = true;
            value.Text = "0";
        }

        // ========== PAINT EVENTS ==========

        private void pnlSidebar_Paint(object sender, PaintEventArgs e)
        {
            // Gradient background
            using (LinearGradientBrush brush = new LinearGradientBrush(
                pnlSidebar.ClientRectangle,
                Color.FromArgb(44, 62, 80),
                Color.FromArgb(52, 73, 94),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, pnlSidebar.ClientRectangle);
            }

            Rectangle logoRect = new Rectangle(15, 20, 250, 70);
            using (GraphicsPath path = GetRoundedRectangle(logoRect, 8))
            using (SolidBrush bgBrush = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(bgBrush, path);
            }

            // Logo text
            using (Font logoFont = new Font("Segoe UI", 18F, FontStyle.Bold))
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                e.Graphics.DrawString("🏥 Botho Clinic", logoFont, brush, new PointF(25, 35));
            }
           
            using (Pen pen = new Pen(Color.FromArgb(50, 255, 255, 255), 1))
            {
                e.Graphics.DrawLine(pen, 20, 480, 260, 480);
            }
        }

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

        private void pnlStatCard_Paint(object sender, PaintEventArgs e)
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

            // Draw card with gradient
            using (GraphicsPath path = GetRoundedRectangle(
                new Rectangle(0, 0, panel.Width - 1, panel.Height - 1), 12))
            using (LinearGradientBrush brush = new LinearGradientBrush(
                panel.ClientRectangle,
                panel.BackColor,
                ControlPaint.Dark(panel.BackColor, 0.1f),
                LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillPath(brush, path);
            }
        }

        // ========== MOUSE EVENTS ==========

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
                btn.BackColor = Color.FromArgb(52, 152, 219);
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn != btnAppointments)
                btn.BackColor = Color.FromArgb(52, 73, 94);
        }

        private void btnLogout_MouseEnter(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(231, 76, 60);
        }

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(192, 57, 43);
        }

        private void pnlStatCard_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
                panel.BackColor = ControlPaint.Light(panel.BackColor, 0.15f);
        }

        private void pnlStatCard_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null) return;

            // Reset to original colors
            if (panel == pnlCard1)
                panel.BackColor = Color.FromArgb(52, 152, 219);
            else if (panel == pnlCard2)
                panel.BackColor = Color.FromArgb(46, 204, 113);
            else if (panel == pnlCard3)
                panel.BackColor = Color.FromArgb(241, 196, 15);
            else if (panel == pnlCard4)
                panel.BackColor = Color.FromArgb(155, 89, 182);
        }

        // ========== TIMER ==========

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy  •  hh:mm tt");
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