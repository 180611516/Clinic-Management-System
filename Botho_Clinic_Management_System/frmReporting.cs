using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;          
using System.Drawing.Imaging;         
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

// iText7
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Geom;

namespace Botho_Clinic_Management_System
{
    public partial class frmReporting : Form
    {
        private readonly string connectionString =
            "server=localhost;database=botho_clinic_management_system;uid=root;pwd=;";

        public frmReporting()
        {
            InitializeComponent();
        }

        #region Load Report & Data

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            LoadReportAndChart();
            LoadKPIs();
        }

        private void LoadReportAndChart()
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    lblReportTitle.Text = $"Report Data: {dtpFrom.Value:dd MMM yyyy} - {dtpTo.Value:dd MMM yyyy}";

                    string sqlTable = @"
                        SELECT 
                            a.appointment_id AS 'Appointment ID',
                            s.full_name AS 'Student',
                            p.full_name AS 'Provider',
                            DATE_FORMAT(a.appointment_date, '%Y-%m-%d') AS 'Date',
                            DATE_FORMAT(a.appointment_time, '%l:%i %p') AS 'Time',
                            a.reason AS 'Reason',
                            COALESCE(a.status, 'Pending') AS 'Status',
                            COALESCE(c.diagnosis, 'No Diagnosis') AS 'Diagnosis'
                        FROM appointments a
                        LEFT JOIN students s ON a.student_id = s.student_id
                        LEFT JOIN providers p ON a.provider_id = p.provider_id
                        LEFT JOIN consultations c ON a.appointment_id = c.appointment_id
                        WHERE a.appointment_date BETWEEN @from AND @to
                        ORDER BY a.appointment_date DESC, a.appointment_time DESC";

                    using (var cmd = new MySqlCommand(sqlTable, conn))
                    {
                        cmd.Parameters.AddWithValue("@from", dtpFrom.Value.Date);
                        cmd.Parameters.AddWithValue("@to", dtpTo.Value.Date);
                        var da = new MySqlDataAdapter(cmd);
                        var dt = new DataTable();
                        da.Fill(dt);
                        dgvReports.DataSource = dt;

                        if (dgvReports.Columns["Appointment ID"] != null)
                            dgvReports.Columns["Appointment ID"].Visible = false;
                    }

                    LoadDiagnosisChart(conn, dtpFrom.Value.Date, dtpTo.Value.Date);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDiagnosisChart(MySqlConnection conn, DateTime from, DateTime to)
        {
            try
            {
                string sqlChart = @"
                    SELECT c.diagnosis, COUNT(*) AS cnt
                    FROM consultations c
                    INNER JOIN appointments a ON c.appointment_id = a.appointment_id
                    WHERE a.appointment_date BETWEEN @from AND @to
                      AND c.diagnosis IS NOT NULL 
                      AND TRIM(c.diagnosis) <> ''
                      AND c.diagnosis <> 'No Diagnosis'
                    GROUP BY c.diagnosis
                    ORDER BY cnt DESC
                    LIMIT 5";

                using (var cmd = new MySqlCommand(sqlChart, conn))
                {
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                    using (var reader = cmd.ExecuteReader())
                    {
                        var series = chartDiagnoses.Series["Diagnoses"];
                        series.Points.Clear();

                        if (!reader.HasRows)
                        {
                            series.Points.AddXY("No Data", 0);
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                string diag = reader["diagnosis"].ToString();
                                int cnt = Convert.ToInt32(reader["cnt"]);
                                series.Points.AddXY(diag, cnt);
                            }
                        }
                    }
                }

                chartDiagnoses.ChartAreas[0].AxisX.Interval = 1;
                chartDiagnoses.ChartAreas[0].AxisY.Interval = 1;
                chartDiagnoses.Series["Diagnoses"].ToolTip = "#VALX: #VALY cases";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chart error: " + ex.Message, "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadKPIs()
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    var from = dtpFrom.Value.Date;
                    var to = dtpTo.Value.Date;

                    lblKPI1Value.Text = ExecuteScalar(conn,
                        @"SELECT COUNT(DISTINCT a.student_id)
                          FROM consultations c
                          INNER JOIN appointments a ON c.appointment_id = a.appointment_id
                          WHERE a.appointment_date BETWEEN @from AND @to", from, to) ?? "0";

                    lblKPI2Value.Text = ExecuteScalar(conn,
                        @"SELECT COUNT(*) FROM appointments a
                          WHERE a.appointment_date BETWEEN @from AND @to", from, to) ?? "0";

                    lblKPI3Value.Text = ExecuteScalar(conn,
                        @"SELECT COUNT(*) FROM appointments a
                          WHERE a.status='Pending' AND a.appointment_date BETWEEN @from AND @to",
                        from, to) ?? "0";

                    lblKPI4Value.Text = ExecuteScalar(conn,
                        @"SELECT COUNT(*) FROM consultations c
                          INNER JOIN appointments a ON c.appointment_id = a.appointment_id
                          WHERE a.appointment_date BETWEEN @from AND @to",
                        from, to) ?? "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading KPIs: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ExecuteScalar(MySqlConnection conn, string sql, DateTime from, DateTime to)
        {
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@to", to);
                return cmd.ExecuteScalar()?.ToString();
            }
        }

        #endregion

        #region Export Functions

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            if (dgvReports.Rows.Count == 0)
            {
                MessageBox.Show("No data to export. Please load a report first.", "No Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var sfd = new SaveFileDialog
            {
                Filter = "CSV file (*.csv)|*.csv",
                FileName = $"clinic_report_{dtpFrom.Value:yyyyMMdd}_{dtpTo.Value:yyyyMMdd}.csv"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (var sw = new StreamWriter(sfd.FileName))
                {
                    for (int i = 0; i < dgvReports.Columns.Count; i++)
                    {
                        if (dgvReports.Columns[i].Visible)
                        {
                            sw.Write(dgvReports.Columns[i].HeaderText);
                            if (i < dgvReports.Columns.Count - 1) sw.Write(",");
                        }
                    }
                    sw.WriteLine();

                    foreach (DataGridViewRow row in dgvReports.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < dgvReports.Columns.Count; i++)
                            {
                                if (dgvReports.Columns[i].Visible)
                                {
                                    var cellValue = row.Cells[i].Value?.ToString()?.Replace(",", ";") ?? "";
                                    sw.Write($"\"{cellValue}\"");
                                    if (i < dgvReports.Columns.Count - 1) sw.Write(",");
                                }
                            }
                            sw.WriteLine();
                        }
                    }
                }

                MessageBox.Show("CSV exported successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (MessageBox.Show("Open file now?", "Open", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    System.Diagnostics.Process.Start(sfd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CSV Export Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (dgvReports.Rows.Count == 0)
            {
                MessageBox.Show("No data to export. Please load a report first.", "No Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var sfd = new SaveFileDialog
            {
                Filter = "PDF file (*.pdf)|*.pdf",
                FileName = $"clinic_report_{dtpFrom.Value:yyyyMMdd}_{dtpTo.Value:yyyyMMdd}.pdf"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                ExportToPdf(sfd.FileName);
                MessageBox.Show("PDF exported successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (MessageBox.Show("Open PDF now?", "Open", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    System.Diagnostics.Process.Start(sfd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF Export Failed: " + ex.Message + "\n\nStack: " + ex.StackTrace,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToPdf(string filePath)
        {
            try
            {
                using (var writer = new PdfWriter(filePath))
                using (var pdf = new PdfDocument(writer))
                using (var doc = new Document(pdf, PageSize.A4))
                {
                    doc.SetMargins(30, 30, 30, 30);

                    var bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    var regular = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                    var italic = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_OBLIQUE);

                    // Title
                    doc.Add(new Paragraph("Botho Clinic - Activity Report")
                        .SetFont(bold).SetFontSize(20).SetTextAlignment(TextAlignment.CENTER)
                        .SetMarginBottom(5));

                    // Date Range
                    doc.Add(new Paragraph($"{dtpFrom.Value:dd MMM yyyy} to {dtpTo.Value:dd MMM yyyy}")
                        .SetFont(regular).SetFontSize(12).SetTextAlignment(TextAlignment.CENTER)
                        .SetMarginBottom(15));

                    // KPI Table
                    var kpiTable = new Table(UnitValue.CreatePercentArray(new float[] { 25, 25, 25, 25 }))
                        .UseAllAvailableWidth().SetMarginBottom(15);

                    AddKpiCell(kpiTable, "Patients Seen", lblKPI1Value.Text, bold, regular);
                    AddKpiCell(kpiTable, "Appointments", lblKPI2Value.Text, bold, regular);
                    AddKpiCell(kpiTable, "Pending", lblKPI3Value.Text, bold, regular);
                    AddKpiCell(kpiTable, "Completed", lblKPI4Value.Text, bold, regular);

                    doc.Add(kpiTable);

                    // Data Table
                    int visibleCols = 0;
                    foreach (DataGridViewColumn col in dgvReports.Columns)
                        if (col.Visible) visibleCols++;

                    var dataTable = new Table(visibleCols).UseAllAvailableWidth().SetFontSize(9);

                    foreach (DataGridViewColumn col in dgvReports.Columns)
                    {
                        if (col.Visible)
                        {
                            dataTable.AddHeaderCell(new Cell()
                                .Add(new Paragraph(col.HeaderText).SetFont(bold))
                                .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                                .SetTextAlignment(TextAlignment.CENTER)
                                .SetPadding(5));
                        }
                    }

                    foreach (DataGridViewRow row in dgvReports.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (dgvReports.Columns[cell.ColumnIndex].Visible)
                                {
                                    dataTable.AddCell(new Cell()
                                        .Add(new Paragraph(cell.Value?.ToString() ?? "").SetFont(regular))
                                        .SetPadding(4));
                                }
                            }
                        }
                    }

                    doc.Add(dataTable);

                    // Chart Section
                    doc.Add(new Paragraph(" "));
                    doc.Add(new Paragraph("Top 5 Diagnoses")
                        .SetFont(bold).SetFontSize(14).SetTextAlignment(TextAlignment.CENTER));

                    try
                    {
                        chartDiagnoses.Update();
                        Application.DoEvents();

                        using (var bmp = new Bitmap(chartDiagnoses.Width, chartDiagnoses.Height))
                        {
                            chartDiagnoses.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));

                            using (var ms = new MemoryStream())
                            {
                                bmp.Save(ms, ImageFormat.Png);
                                var imgData = ImageDataFactory.Create(ms.ToArray());
                                var image = new iText.Layout.Element.Image(imgData)
                                    .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER)
                                    .ScaleToFit(520, 220);
                                doc.Add(image);
                            }
                        }
                    }
                    catch
                    {
                        doc.Add(new Paragraph("[Chart could not be rendered]")
                            .SetFont(italic).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER));
                    }

                    // Footer
                    doc.Add(new Paragraph($"Generated on {DateTime.Now:dd MMM yyyy, hh:mm tt}")
                        .SetFont(italic).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)
                        .SetMarginTop(10));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PDF generation failed: " + ex.Message, ex);
            }
        }

        private void AddKpiCell(Table table, string label, string value, PdfFont bold, PdfFont regular)
        {
            var cell = new Cell()
                .Add(new Paragraph(label).SetFont(regular).SetFontSize(10))
                .Add(new Paragraph(value).SetFont(bold).SetFontSize(18).SetFontColor(ColorConstants.BLUE))
                .SetTextAlignment(TextAlignment.CENTER)
                .SetPadding(10)
                .SetBackgroundColor(new DeviceRgb(240, 244, 248));
            table.AddCell(cell);
        }

        #endregion

        #region UI Paint & Hover

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            if (panel == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            for (int i = 5; i > 0; i--)
            {
                using (var path = GetRoundedRect(new System.Drawing.Rectangle(i, i, panel.Width - 1, panel.Height - 1), 12))
                using (var pen = new Pen(System.Drawing.Color.FromArgb(8 - i, 0, 0, 0), 1))
                    e.Graphics.DrawPath(pen, path);
            }

            using (var path = GetRoundedRect(new System.Drawing.Rectangle(0, 0, panel.Width - 1, panel.Height - 1), 12))
            using (var brush = new SolidBrush(System.Drawing.Color.White))
                e.Graphics.FillPath(brush, path);
        }

        private void pnlStatCard_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            if (panel == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            for (int i = 5; i > 0; i--)
            {
                using (var path = GetRoundedRect(new System.Drawing.Rectangle(i, i, panel.Width - 1, panel.Height - 1), 12))
                using (var pen = new Pen(System.Drawing.Color.FromArgb(8 - i, 0, 0, 0), 1))
                    e.Graphics.DrawPath(pen, path);
            }

            using (var path = GetRoundedRect(new System.Drawing.Rectangle(0, 0, panel.Width - 1, panel.Height - 1), 12))
            using (var brush = new LinearGradientBrush(
                panel.ClientRectangle,
                panel.BackColor,
                ControlPaint.Dark(panel.BackColor, 0.1f),
                LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillPath(brush, path);
            }
        }

        private GraphicsPath GetRoundedRect(System.Drawing.Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void pnlStatCard_MouseEnter(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            if (panel != null) panel.BackColor = ControlPaint.Light(panel.BackColor, 0.15f);
        }

        private void pnlStatCard_MouseLeave(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            if (panel == null) return;

            if (panel == pnlKPI1) panel.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            else if (panel == pnlKPI2) panel.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            else if (panel == pnlKPI3) panel.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            else if (panel == pnlKPI4) panel.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
        }

        private void btnLoad_MouseEnter(object sender, EventArgs e) =>
            btnLoadReport.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);

        private void btnLoad_MouseLeave(object sender, EventArgs e) =>
            btnLoadReport.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);

        private void btnExport_MouseEnter(object sender, EventArgs e) =>
            btnExportCsv.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);

        private void btnExport_MouseLeave(object sender, EventArgs e) =>
            btnExportCsv.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);

        private void btnExportPdf_MouseEnter(object sender, EventArgs e) =>
            btnExportPdf.BackColor = System.Drawing.Color.FromArgb(240, 90, 70);

        private void btnExportPdf_MouseLeave(object sender, EventArgs e) =>
            btnExportPdf.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);

        #endregion
    }
}