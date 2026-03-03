using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Botho_Clinic_Management_System
{
    partial class frmAdminDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlSidebar;
        private Panel pnlMain;
        private Panel pnlHeader;
        private Panel pnlChartContainer;
        private RoundedButton btnUserManagement;
        private RoundedButton btnReports;
        private RoundedButton btnLogout;
        private RoundedButton btnRefresh;
        private RoundedButton btnProfile; 
        private Label lblWelcome;
        private Label lblSubtitle;
        private Label lblDateTime;
        private Label lblChartTitle;
        private Timer timerDateTime;
        private Panel pnlKPI1, pnlKPI2, pnlKPI3, pnlKPI4;
        private Label lblPatientsSeen, lblAppointmentsToday, lblPendingAppointments, lblCompletedConsultations;
        private Label lblKPI1Title, lblKPI2Title, lblKPI3Title, lblKPI4Title;
        private Label lblKPI1Icon, lblKPI2Icon, lblKPI3Icon, lblKPI4Icon;
        private Chart chartAilments;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Initialize controls
            this.pnlSidebar = new Panel();
            this.pnlMain = new Panel();
            this.pnlHeader = new Panel();
            this.pnlChartContainer = new Panel();
            this.btnUserManagement = new RoundedButton();
            this.btnReports = new RoundedButton();
            this.btnLogout = new RoundedButton();
            this.btnRefresh = new RoundedButton();
            this.btnProfile = new RoundedButton();
            this.lblWelcome = new Label();
            this.lblSubtitle = new Label();
            this.lblDateTime = new Label();
            this.lblChartTitle = new Label();
            this.timerDateTime = new Timer(this.components);

            this.pnlKPI1 = new Panel();
            this.lblKPI1Title = new Label();
            this.lblKPI1Icon = new Label();
            this.lblPatientsSeen = new Label();

            this.pnlKPI2 = new Panel();
            this.lblKPI2Title = new Label();
            this.lblKPI2Icon = new Label();
            this.lblAppointmentsToday = new Label();

            this.pnlKPI3 = new Panel();
            this.lblKPI3Title = new Label();
            this.lblKPI3Icon = new Label();
            this.lblPendingAppointments = new Label();

            this.pnlKPI4 = new Panel();
            this.lblKPI4Title = new Label();
            this.lblKPI4Icon = new Label();
            this.lblCompletedConsultations = new Label();

            this.chartAilments = new Chart();

            // Begin initialization
            this.pnlSidebar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlChartContainer.SuspendLayout();
            this.pnlKPI1.SuspendLayout();
            this.pnlKPI2.SuspendLayout();
            this.pnlKPI3.SuspendLayout();
            this.pnlKPI4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAilments)).BeginInit();
            this.SuspendLayout();

            // ========== SIDEBAR ==========
            this.pnlSidebar.BackColor = Color.FromArgb(44, 62, 80);
            this.pnlSidebar.Controls.Add(this.btnProfile); 
            this.pnlSidebar.Controls.Add(this.btnUserManagement);
            this.pnlSidebar.Controls.Add(this.btnReports);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Dock = DockStyle.Left;
            this.pnlSidebar.Size = new Size(280, 800);
            this.pnlSidebar.Paint += pnlSidebar_Paint;

            // Profile Button - NEW
            this.btnProfile.BackColor = Color.FromArgb(155, 89, 182); 
            this.btnProfile.FlatStyle = FlatStyle.Flat;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnProfile.ForeColor = Color.White;
            this.btnProfile.Location = new Point(20, 290);
            this.btnProfile.Size = new Size(240, 60);
            this.btnProfile.Text = "👤 My Profile";
            this.btnProfile.TextAlign = ContentAlignment.MiddleLeft;
            this.btnProfile.Padding = new Padding(20, 0, 0, 0);
            this.btnProfile.Cursor = Cursors.Hand;
            this.btnProfile.Click += btnProfile_Click;
            this.btnProfile.MouseEnter += btn_MouseEnter;
            this.btnProfile.MouseLeave += btn_MouseLeave;

            // User Management Button
            this.btnUserManagement.BackColor = Color.FromArgb(52, 152, 219);
            this.btnUserManagement.FlatStyle = FlatStyle.Flat;
            this.btnUserManagement.FlatAppearance.BorderSize = 0;
            this.btnUserManagement.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnUserManagement.ForeColor = Color.White;
            this.btnUserManagement.Location = new Point(20, 140);
            this.btnUserManagement.Size = new Size(240, 60);
            this.btnUserManagement.Text = "👥 User Management";
            this.btnUserManagement.TextAlign = ContentAlignment.MiddleLeft;
            this.btnUserManagement.Padding = new Padding(20, 0, 0, 0);
            this.btnUserManagement.Cursor = Cursors.Hand;
            this.btnUserManagement.Click += btnUserManagement_Click;
            this.btnUserManagement.MouseEnter += btn_MouseEnter;
            this.btnUserManagement.MouseLeave += btn_MouseLeave;

            // Reports Button
            this.btnReports.BackColor = Color.FromArgb(52, 73, 94);
            this.btnReports.FlatStyle = FlatStyle.Flat;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnReports.ForeColor = Color.White;
            this.btnReports.Location = new Point(20, 215);
            this.btnReports.Size = new Size(240, 60);
            this.btnReports.Text = "📊 Reports";
            this.btnReports.TextAlign = ContentAlignment.MiddleLeft;
            this.btnReports.Padding = new Padding(20, 0, 0, 0);
            this.btnReports.Cursor = Cursors.Hand;
            this.btnReports.Click += btnReports_Click;
            this.btnReports.MouseEnter += btn_MouseEnter;
            this.btnReports.MouseLeave += btn_MouseLeave;

            // Logout Button
            this.btnLogout.BackColor = Color.FromArgb(192, 57, 43);
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.Location = new Point(20, 710);
            this.btnLogout.Size = new Size(240, 60);
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            this.btnLogout.Padding = new Padding(20, 0, 0, 0);
            this.btnLogout.Cursor = Cursors.Hand;
            this.btnLogout.Click += btnLogout_Click;
            this.btnLogout.MouseEnter += btnLogout_MouseEnter;
            this.btnLogout.MouseLeave += btnLogout_MouseLeave;

            // ========== MAIN PANEL ==========
            this.pnlMain.BackColor = Color.FromArgb(243, 246, 249);
            this.pnlMain.Controls.Add(this.pnlChartContainer);
            this.pnlMain.Controls.Add(this.pnlKPI4);
            this.pnlMain.Controls.Add(this.pnlKPI3);
            this.pnlMain.Controls.Add(this.pnlKPI2);
            this.pnlMain.Controls.Add(this.pnlKPI1);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Location = new Point(280, 0);
            this.pnlMain.Padding = new Padding(0);
            this.pnlMain.Size = new Size(1120, 800);

            // ========== HEADER PANEL ==========
            this.pnlHeader.BackColor = Color.White;
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Controls.Add(this.lblDateTime);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Location = new Point(25, 25);
            this.pnlHeader.Size = new Size(1070, 110);
            this.pnlHeader.Paint += pnlCard_Paint;

            // Welcome Label
            this.lblWelcome.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new Point(30, 20);
            this.lblWelcome.Text = "👋 Welcome, Admin";

            // Subtitle Label
            this.lblSubtitle.Font = new Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new Point(35, 65);
            this.lblSubtitle.Text = "System overview and analytics dashboard";

            // DateTime Label
            this.lblDateTime.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDateTime.ForeColor = Color.FromArgb(52, 152, 219);
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Location = new Point(720, 30);
            this.lblDateTime.Text = "";

            // Refresh Button
            this.btnRefresh.BackColor = Color.FromArgb(46, 204, 113);
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new Point(950, 65);
            this.btnRefresh.Size = new Size(105, 35);
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.Click += btnRefresh_Click;
            this.btnRefresh.MouseEnter += btnRefresh_MouseEnter;
            this.btnRefresh.MouseLeave += btnRefresh_MouseLeave;

            // ========== TIMER ==========
            this.timerDateTime.Enabled = true;
            this.timerDateTime.Interval = 1000;
            this.timerDateTime.Tick += timerDateTime_Tick;

            // ========== KPI CARDS ==========
            SetupKPICard(pnlKPI1, lblKPI1Icon, lblKPI1Title, lblPatientsSeen,
                new Point(25, 155), "👥", "Patients Seen Today", Color.FromArgb(52, 152, 219));
            SetupKPICard(pnlKPI2, lblKPI2Icon, lblKPI2Title, lblAppointmentsToday,
                new Point(295, 155), "📅", "Appointments Today", Color.FromArgb(46, 204, 113));
            SetupKPICard(pnlKPI3, lblKPI3Icon, lblKPI3Title, lblPendingAppointments,
                new Point(565, 155), "⏱️", "Pending Appointments", Color.FromArgb(241, 196, 15));
            SetupKPICard(pnlKPI4, lblKPI4Icon, lblKPI4Title, lblCompletedConsultations,
                new Point(835, 155), "✅", "Completed Today", Color.FromArgb(155, 89, 182));

            // ========== CHART CONTAINER ==========
            this.pnlChartContainer.BackColor = Color.White;
            this.pnlChartContainer.Location = new Point(25, 305);
            this.pnlChartContainer.Size = new Size(1070, 470);
            this.pnlChartContainer.Controls.Add(this.lblChartTitle);
            this.pnlChartContainer.Controls.Add(this.chartAilments);
            this.pnlChartContainer.Paint += pnlCard_Paint;

            // Chart Title
            this.lblChartTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblChartTitle.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Location = new Point(30, 20);
            this.lblChartTitle.Text = "📊 Common Ailments This Month";

            // ========== CHART ==========
            this.chartAilments.BackColor = Color.Transparent;
            this.chartAilments.Location = new Point(20, 60);
            this.chartAilments.Size = new Size(1030, 390);
            this.chartAilments.BorderlineColor = Color.Transparent;

            // Chart Area
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.BackColor = Color.Transparent;
            chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(236, 240, 241);
            chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(236, 240, 241);
            chartArea.AxisX.Title = "Diagnosis";
            chartArea.AxisX.TitleFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 9F);
            chartArea.AxisX.LabelStyle.ForeColor = Color.FromArgb(127, 140, 141);
            chartArea.AxisY.Title = "Number of Cases";
            chartArea.AxisY.TitleFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 9F);
            chartArea.AxisY.LabelStyle.ForeColor = Color.FromArgb(127, 140, 141);
            chartArea.AxisX.LineColor = Color.FromArgb(189, 195, 199);
            chartArea.AxisY.LineColor = Color.FromArgb(189, 195, 199);
            this.chartAilments.ChartAreas.Add(chartArea);

            // Chart Series
            Series series = new Series("Diagnoses");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            series.LabelForeColor = Color.FromArgb(44, 62, 80);
            series.Color = Color.FromArgb(52, 152, 219);
            this.chartAilments.Series.Add(series);

            // ========== FORM ==========
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(243, 246, 249);
            this.ClientSize = new Size(1400, 800);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "frmAdminDashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard - Botho Clinic";
            this.Load += frmAdminDashboard_Load;

            // End initialization
            this.pnlSidebar.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlChartContainer.ResumeLayout(false);
            this.pnlChartContainer.PerformLayout();
            this.pnlKPI1.ResumeLayout(false);
            this.pnlKPI1.PerformLayout();
            this.pnlKPI2.ResumeLayout(false);
            this.pnlKPI2.PerformLayout();
            this.pnlKPI3.ResumeLayout(false);
            this.pnlKPI3.PerformLayout();
            this.pnlKPI4.ResumeLayout(false);
            this.pnlKPI4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAilments)).EndInit();
            this.ResumeLayout(false);
        }

        // ========== KPI CARD SETUP ==========
        private void SetupKPICard(Panel panel, Label icon, Label title, Label value, Point location,
            string iconText, string titleText, Color bgColor)
        {
            panel.BackColor = bgColor;
            panel.Controls.Add(icon);
            panel.Controls.Add(title);
            panel.Controls.Add(value);
            panel.Location = location;
            panel.Size = new Size(260, 130);
            panel.Cursor = Cursors.Hand;
            panel.Paint += pnlStatCard_Paint;
            panel.MouseEnter += pnlStatCard_MouseEnter;
            panel.MouseLeave += pnlStatCard_MouseLeave;

            // Icon
            icon.Font = new Font("Segoe UI Emoji", 40F);
            icon.ForeColor = Color.FromArgb(60, 255, 255, 255);
            icon.Location = new Point(185, 35);
            icon.Size = new Size(60, 60);
            icon.Text = iconText;
            icon.TextAlign = ContentAlignment.MiddleCenter;

            // Title
            title.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(250, 255, 255, 255);
            title.Location = new Point(20, 20);
            title.AutoSize = true;
            title.MaximumSize = new Size(150, 0);
            title.Text = titleText;

            // Value
            value.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            value.ForeColor = Color.White;
            value.Location = new Point(20, 50);
            value.AutoSize = true;
            value.Text = "0";
        }

        // ========== ROUNDED BUTTON CLASS ==========
        private class RoundedButton : Button
        {
            protected override void OnPaint(PaintEventArgs pevent)
            {
                GraphicsPath path = new GraphicsPath();
                Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                int radius = 10;

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