using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Botho_Clinic_Management_System
{
    partial class frmReporting
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlMain;
        private Panel pnlHeader;
        private Panel pnlFilters;
        private Panel pnlChartContainer;
        private DataGridView dgvReports;
        private RoundedButton btnLoadReport;
        private RoundedButton btnExportCsv;
        private RoundedButton btnExportPdf;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Label lblFrom;
        private Label lblTo;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblReportTitle;
        private Label lblChartTitle;

        private Panel pnlKPI1, pnlKPI2, pnlKPI3, pnlKPI4;
        private Label lblKPI1Title, lblKPI1Value, lblKPI1Icon;
        private Label lblKPI2Title, lblKPI2Value, lblKPI2Icon;
        private Label lblKPI3Title, lblKPI3Value, lblKPI3Icon;
        private Label lblKPI4Title, lblKPI4Value, lblKPI4Icon;

        private Chart chartDiagnoses;

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
            this.pnlMain = new Panel();
            this.pnlHeader = new Panel();
            this.pnlFilters = new Panel();
            this.pnlChartContainer = new Panel();

            this.pnlKPI1 = new Panel();
            this.pnlKPI2 = new Panel();
            this.pnlKPI3 = new Panel();
            this.pnlKPI4 = new Panel();

            this.lblKPI1Title = new Label();
            this.lblKPI1Value = new Label();
            this.lblKPI1Icon = new Label();
            this.lblKPI2Title = new Label();
            this.lblKPI2Value = new Label();
            this.lblKPI2Icon = new Label();
            this.lblKPI3Title = new Label();
            this.lblKPI3Value = new Label();
            this.lblKPI3Icon = new Label();
            this.lblKPI4Title = new Label();
            this.lblKPI4Value = new Label();
            this.lblKPI4Icon = new Label();

            this.dtpFrom = new DateTimePicker();
            this.dtpTo = new DateTimePicker();
            this.lblFrom = new Label();
            this.lblTo = new Label();
            this.btnLoadReport = new RoundedButton();
            this.btnExportCsv = new RoundedButton();
            this.btnExportPdf = new RoundedButton();

            this.dgvReports = new DataGridView();
            this.chartDiagnoses = new Chart();

            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.lblReportTitle = new Label();
            this.lblChartTitle = new Label();

            // Begin initialization
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDiagnoses)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.pnlChartContainer.SuspendLayout();
            this.pnlKPI1.SuspendLayout();
            this.pnlKPI2.SuspendLayout();
            this.pnlKPI3.SuspendLayout();
            this.pnlKPI4.SuspendLayout();
            this.SuspendLayout();

            // ========== MAIN PANEL ==========
            this.pnlMain.BackColor = Color.FromArgb(243, 246, 249);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Padding = new Padding(0);
            this.pnlMain.Controls.Add(this.pnlChartContainer);
            this.pnlMain.Controls.Add(this.dgvReports);
            this.pnlMain.Controls.Add(this.lblReportTitle);
            this.pnlMain.Controls.Add(this.pnlKPI4);
            this.pnlMain.Controls.Add(this.pnlKPI3);
            this.pnlMain.Controls.Add(this.pnlKPI2);
            this.pnlMain.Controls.Add(this.pnlKPI1);
            this.pnlMain.Controls.Add(this.pnlFilters);
            this.pnlMain.Controls.Add(this.pnlHeader);

            // ========== HEADER PANEL ==========
            this.pnlHeader.BackColor = Color.White;
            this.pnlHeader.Location = new Point(25, 25);
            this.pnlHeader.Size = new Size(1150, 100);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Paint += pnlCard_Paint;

            // Title
            this.lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(30, 20);
            this.lblTitle.Text = "📊 Clinic Reporting";

            // Subtitle
            this.lblSubtitle.Font = new Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new Point(35, 60);
            this.lblSubtitle.Text = "Generate comprehensive reports and analyze clinic performance";

            // ========== FILTERS PANEL ==========
            this.pnlFilters.BackColor = Color.White;
            this.pnlFilters.Location = new Point(25, 145);
            this.pnlFilters.Size = new Size(1150, 90);
            this.pnlFilters.Controls.Add(this.btnExportPdf);
            this.pnlFilters.Controls.Add(this.btnExportCsv);
            this.pnlFilters.Controls.Add(this.btnLoadReport);
            this.pnlFilters.Controls.Add(this.dtpTo);
            this.pnlFilters.Controls.Add(this.lblTo);
            this.pnlFilters.Controls.Add(this.dtpFrom);
            this.pnlFilters.Controls.Add(this.lblFrom);
            this.pnlFilters.Paint += pnlCard_Paint;

            // From Date Label
            this.lblFrom.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblFrom.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new Point(30, 20);
            this.lblFrom.Text = "📅 From Date";

            // From DateTimePicker
            this.dtpFrom.Font = new Font("Segoe UI", 10F);
            this.dtpFrom.Location = new Point(30, 45);
            this.dtpFrom.Size = new Size(280, 30);
            this.dtpFrom.Format = DateTimePickerFormat.Long;

            // To Date Label
            this.lblTo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTo.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new Point(340, 20);
            this.lblTo.Text = "📅 To Date";

            // To DateTimePicker
            this.dtpTo.Font = new Font("Segoe UI", 10F);
            this.dtpTo.Location = new Point(340, 45);
            this.dtpTo.Size = new Size(280, 30);
            this.dtpTo.Format = DateTimePickerFormat.Long;

            // Load Report Button
            this.btnLoadReport.BackColor = Color.FromArgb(52, 152, 219);
            this.btnLoadReport.FlatStyle = FlatStyle.Flat;
            this.btnLoadReport.FlatAppearance.BorderSize = 0;
            this.btnLoadReport.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnLoadReport.ForeColor = Color.White;
            this.btnLoadReport.Location = new Point(750, 40);
            this.btnLoadReport.Size = new Size(120, 40);
            this.btnLoadReport.Text = "📈 Load";
            this.btnLoadReport.Cursor = Cursors.Hand;
            this.btnLoadReport.Click += btnLoadReport_Click;
            this.btnLoadReport.MouseEnter += btnLoad_MouseEnter;
            this.btnLoadReport.MouseLeave += btnLoad_MouseLeave;

            // Export CSV Button
            this.btnExportCsv.BackColor = Color.FromArgb(46, 204, 113);
            this.btnExportCsv.FlatStyle = FlatStyle.Flat;
            this.btnExportCsv.FlatAppearance.BorderSize = 0;
            this.btnExportCsv.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnExportCsv.ForeColor = Color.White;
            this.btnExportCsv.Location = new Point(880, 40);
            this.btnExportCsv.Size = new Size(120, 40);
            this.btnExportCsv.Text = "📄 CSV";
            this.btnExportCsv.Cursor = Cursors.Hand;
            this.btnExportCsv.Click += btnExportCsv_Click;
            this.btnExportCsv.MouseEnter += btnExport_MouseEnter;
            this.btnExportCsv.MouseLeave += btnExport_MouseLeave;

            // Export PDF Button
            this.btnExportPdf.BackColor = Color.FromArgb(231, 76, 60);
            this.btnExportPdf.FlatStyle = FlatStyle.Flat;
            this.btnExportPdf.FlatAppearance.BorderSize = 0;
            this.btnExportPdf.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnExportPdf.ForeColor = Color.White;
            this.btnExportPdf.Location = new Point(1010, 40);
            this.btnExportPdf.Size = new Size(110, 40);
            this.btnExportPdf.Text = "📕 PDF";
            this.btnExportPdf.Cursor = Cursors.Hand;
            this.btnExportPdf.Click += btnExportPdf_Click;
            this.btnExportPdf.MouseEnter += btnExportPdf_MouseEnter;
            this.btnExportPdf.MouseLeave += btnExportPdf_MouseLeave;

            // ========== KPI CARDS ==========
            SetupKPICard(pnlKPI1, lblKPI1Icon, lblKPI1Title, lblKPI1Value,
                         new Point(25, 255), "👥", "Patients Seen", Color.FromArgb(52, 152, 219));
            SetupKPICard(pnlKPI2, lblKPI2Icon, lblKPI2Title, lblKPI2Value,
                         new Point(310, 255), "📅", "Appointments", Color.FromArgb(46, 204, 113));
            SetupKPICard(pnlKPI3, lblKPI3Icon, lblKPI3Title, lblKPI3Value,
                         new Point(595, 255), "⏱️", "Pending", Color.FromArgb(241, 196, 15));
            SetupKPICard(pnlKPI4, lblKPI4Icon, lblKPI4Title, lblKPI4Value,
                         new Point(880, 255), "✅", "Completed", Color.FromArgb(155, 89, 182));

            // ========== REPORT DATA TITLE ==========
            this.lblReportTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblReportTitle.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Location = new Point(30, 410);
            this.lblReportTitle.Text = "📋 Report Data";

            // ========== DATAGRIDVIEW ==========
            this.dgvReports.AllowUserToAddRows = false;
            this.dgvReports.AllowUserToDeleteRows = false;
            this.dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReports.BackgroundColor = Color.White;
            this.dgvReports.BorderStyle = BorderStyle.None;
            this.dgvReports.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReports.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvReports.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            this.dgvReports.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvReports.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.dgvReports.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            this.dgvReports.ColumnHeadersHeight = 50;
            this.dgvReports.DefaultCellStyle.BackColor = Color.White;
            this.dgvReports.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            this.dgvReports.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvReports.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            this.dgvReports.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvReports.DefaultCellStyle.Padding = new Padding(10, 8, 10, 8);
            this.dgvReports.EnableHeadersVisualStyles = false;
            this.dgvReports.GridColor = Color.FromArgb(236, 240, 241);
            this.dgvReports.Location = new Point(25, 450);
            this.dgvReports.ReadOnly = true;
            this.dgvReports.RowHeadersVisible = false;
            this.dgvReports.RowTemplate.Height = 45;
            this.dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvReports.Size = new Size(1150, 350);

            // ========== CHART CONTAINER ==========
            this.pnlChartContainer.BackColor = Color.White;
            this.pnlChartContainer.Location = new Point(25, 820);
            this.pnlChartContainer.Size = new Size(1150, 320);
            this.pnlChartContainer.Controls.Add(this.lblChartTitle);
            this.pnlChartContainer.Controls.Add(this.chartDiagnoses);
            this.pnlChartContainer.Paint += pnlCard_Paint;

            // Chart Title
            this.lblChartTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblChartTitle.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Location = new Point(30, 20);
            this.lblChartTitle.Text = "📊 Top 5 Diagnoses";

            // ========== CHART ==========
            this.chartDiagnoses.BackColor = Color.Transparent;
            this.chartDiagnoses.Location = new Point(20, 60);
            this.chartDiagnoses.Size = new Size(1110, 240);
            this.chartDiagnoses.BorderlineColor = Color.Transparent;

            // Chart Area
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.BackColor = Color.Transparent;
            chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(236, 240, 241);
            chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(236, 240, 241);
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 10F);
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 10F);
            chartArea.AxisX.LabelStyle.ForeColor = Color.FromArgb(127, 140, 141);
            chartArea.AxisY.LabelStyle.ForeColor = Color.FromArgb(127, 140, 141);
            chartArea.AxisX.LineColor = Color.FromArgb(189, 195, 199);
            chartArea.AxisY.LineColor = Color.FromArgb(189, 195, 199);
            this.chartDiagnoses.ChartAreas.Add(chartArea);

            // Chart Series
            Series series = new Series("Diagnoses");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            series.LabelForeColor = Color.FromArgb(44, 62, 80);
            series.Color = Color.FromArgb(52, 152, 219);
            this.chartDiagnoses.Series.Add(series);

            // ========== FORM ==========
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(243, 246, 249);
            this.ClientSize = new Size(1200, 800);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "frmReporting";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Clinic Reporting - Botho Clinic";

            // End initialization
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDiagnoses)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
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
            this.ResumeLayout(false);
        }

        // ========== KPI CARD SETUP ==========
        private void SetupKPICard(Panel panel, Label icon, Label title, Label value,
                                  Point location, string iconText, string titleText, Color bg)
        {
            panel.BackColor = bg;
            panel.Location = location;
            panel.Size = new Size(275, 130);
            panel.Cursor = Cursors.Hand;
            panel.Controls.Add(icon);
            panel.Controls.Add(title);
            panel.Controls.Add(value);
            panel.Paint += pnlStatCard_Paint;
            panel.MouseEnter += pnlStatCard_MouseEnter;
            panel.MouseLeave += pnlStatCard_MouseLeave;

            // Icon
            icon.Font = new Font("Segoe UI Emoji", 40F);
            icon.ForeColor = Color.FromArgb(60, 255, 255, 255);
            icon.Location = new Point(190, 35);
            icon.Size = new Size(70, 70);
            icon.Text = iconText;
            icon.TextAlign = ContentAlignment.MiddleCenter;

            // Title
            title.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(250, 255, 255, 255);
            title.Location = new Point(20, 20);
            title.AutoSize = true;
            title.Text = titleText;

            // Value
            value.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            value.ForeColor = Color.White;
            value.Location = new Point(20, 50);
            value.AutoSize = true;
            value.Text = "0";
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