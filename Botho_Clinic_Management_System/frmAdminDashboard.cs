using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Botho_Clinic_Management_System
{
    public partial class frmAdminDashboard : Form
    {
        private int _userId;
        private readonly string _connStr = "server=localhost;user=root;password=;database=botho_clinic_management_system;";

        public frmAdminDashboard(int userId)
        {
            InitializeComponent();
            _userId = userId;
            lblWelcome.Text = $"👋 Welcome, Admin";

            LoadDashboardData();
            LoadDiagnosisChart();
        }

        #region Form Load
        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, MMM dd, yyyy  •  hh:mm tt");
        }
        #endregion

        #region Sidebar Navigation

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            frmStaffManagement staffForm = new frmStaffManagement();
            staffForm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frmReporting reportsForm = new frmReporting();
            reportsForm.ShowDialog();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            frmUserProfile profileForm = new frmUserProfile(_userId, "Administrator");
            profileForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Confirm Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
            LoadDiagnosisChart();
            MessageBox.Show("Dashboard refreshed successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region KPI & Chart Data

        private void LoadDashboardData()
        {
            try
            {
                using (var conn = new MySqlConnection(_connStr))
                {
                    conn.Open();

                    // 1. Patients Seen Today (Completed Consultations today)
                    lblPatientsSeen.Text = ExecuteScalar(conn,
                        @"SELECT COUNT(DISTINCT c.appointment_id)
                          FROM consultations c
                          JOIN appointments a ON c.appointment_id = a.appointment_id
                          WHERE DATE(a.appointment_date) = CURDATE()").ToString();

                    // 2. Appointments Today
                    lblAppointmentsToday.Text = ExecuteScalar(conn,
                        @"SELECT COUNT(*) FROM appointments 
                          WHERE DATE(appointment_date) = CURDATE()").ToString();

                    // 3. Pending Appointments
                    lblPendingAppointments.Text = ExecuteScalar(conn,
                        @"SELECT COUNT(*) FROM appointments 
                          WHERE status = 'Pending'").ToString();

                    // 4. Total Completed Consultations Today
                    lblCompletedConsultations.Text = ExecuteScalar(conn,
                        @"SELECT COUNT(*) FROM consultations c
                          JOIN appointments a ON c.appointment_id = a.appointment_id
                          WHERE DATE(a.appointment_date) = CURDATE()").ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDiagnosisChart()
        {
            try
            {
                using (var conn = new MySqlConnection(_connStr))
                {
                    conn.Open();

                    string query = @"
                        SELECT diagnosis, COUNT(*) AS count 
                        FROM consultations 
                        WHERE MONTH(recorded_at) = MONTH(CURDATE())
                          AND YEAR(recorded_at) = YEAR(CURDATE())
                          AND diagnosis IS NOT NULL 
                          AND TRIM(diagnosis) != ''
                        GROUP BY diagnosis 
                        ORDER BY count DESC 
                        LIMIT 5";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);

                        var series = chartAilments.Series["Diagnoses"];
                        series.Points.Clear();

                        if (dt.Rows.Count == 0)
                        {
                            series.Points.AddXY("No Data", 0);
                            return;
                        }

                        foreach (DataRow row in dt.Rows)
                        {
                            string diag = row["diagnosis"].ToString();
                            int count = Convert.ToInt32(row["count"]);
                            series.Points.AddXY(diag, count);
                        }

                        chartAilments.ChartAreas[0].AxisX.Interval = 1;
                        chartAilments.ChartAreas[0].AxisY.Interval = 1;
                        series.ToolTip = "#VALX: #VALY cases";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading chart: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private object ExecuteScalar(MySqlConnection conn, string sql)
        {
            using (var cmd = new MySqlCommand(sql, conn))
            {
                var result = cmd.ExecuteScalar();
                return result ?? 0;
            }
        }

        #endregion

        #region Timer Events
        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, MMM dd, yyyy  •  hh:mm tt");
        }
        #endregion

        #region Paint Events

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

            // Logo area
            Rectangle logoRect = new Rectangle(15, 20, 250, 70);
            using (GraphicsPath path = GetRoundedRect(logoRect, 8))
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

            // Separator line
            using (Pen pen = new Pen(Color.FromArgb(50, 255, 255, 255), 1))
            {
                e.Graphics.DrawLine(pen, 20, 290, 260, 290);
            }
        }

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw subtle shadow
            for (int i = 5; i > 0; i--)
            {
                using (GraphicsPath shadowPath = GetRoundedRect(
                    new Rectangle(i, i, panel.Width - 1, panel.Height - 1), 12))
                using (Pen shadowPen = new Pen(Color.FromArgb(8 - i, 0, 0, 0), 1))
                {
                    e.Graphics.DrawPath(shadowPen, shadowPath);
                }
            }

            // Draw card
            using (GraphicsPath path = GetRoundedRect(
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
                using (GraphicsPath shadowPath = GetRoundedRect(
                    new Rectangle(i, i, panel.Width - 1, panel.Height - 1), 12))
                using (Pen shadowPen = new Pen(Color.FromArgb(8 - i, 0, 0, 0), 1))
                {
                    e.Graphics.DrawPath(shadowPen, shadowPath);
                }
            }

            // Draw card with gradient
            using (GraphicsPath path = GetRoundedRect(
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

        #endregion

        #region Mouse Hover Events

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is RoundedButton button && button != btnLogout)
            {
                button.BackColor = ControlPaint.Light(button.BackColor, 0.2f);
            }
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is RoundedButton button)
            {
                // Restore original colors
                if (button == btnUserManagement)
                    button.BackColor = Color.FromArgb(52, 152, 219);
                else if (button == btnReports)
                    button.BackColor = Color.FromArgb(52, 73, 94);
                else if (button == btnProfile)
                    button.BackColor = Color.FromArgb(155, 89, 182);
                else if (button == btnRefresh)
                    button.BackColor = Color.FromArgb(46, 204, 113);
            }
        }

        private void btnLogout_MouseEnter(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(231, 76, 60);
        }

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(192, 57, 43);
        }

        private void btnRefresh_MouseEnter(object sender, EventArgs e)
        {
            btnRefresh.BackColor = Color.FromArgb(39, 174, 96);
        }

        private void btnRefresh_MouseLeave(object sender, EventArgs e)
        {
            btnRefresh.BackColor = Color.FromArgb(46, 204, 113);
        }

        private void pnlStatCard_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.Cursor = Cursors.Hand;
                Color c = panel.BackColor;
                panel.BackColor = Color.FromArgb(
                    Math.Min(255, c.R + 15),
                    Math.Min(255, c.G + 15),
                    Math.Min(255, c.B + 15));
            }
        }

        private void pnlStatCard_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null) return;

            panel.Cursor = Cursors.Default;

            // Reset to original colors
            if (panel == pnlKPI1)
                panel.BackColor = Color.FromArgb(52, 152, 219);
            else if (panel == pnlKPI2)
                panel.BackColor = Color.FromArgb(46, 204, 113);
            else if (panel == pnlKPI3)
                panel.BackColor = Color.FromArgb(241, 196, 15);
            else if (panel == pnlKPI4)
                panel.BackColor = Color.FromArgb(155, 89, 182);
        }

        #endregion

        #region Helper Methods

        private GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
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

        #endregion
    }
}