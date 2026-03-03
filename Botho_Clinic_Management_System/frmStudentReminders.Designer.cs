using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Botho_Clinic_Management_System
{
    partial class frmStudentReminders
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlMain;
        private Panel pnlContainer;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlStats;
        private Panel pnlStatCard1;
        private Panel pnlStatCard2;
        private Panel pnlStatCard3;
        private Panel pnlStatCard4;
        private Label lblTotalReminders;
        private Label lblTotalCount;
        private Label lblUnreadReminders;
        private Label lblUnreadCount;
        private Label lblOverdueReminders;
        private Label lblOverdueCount;
        private Label lblTodayReminders;
        private Label lblTodayCount;
        private DataGridView dgvReminders;
        private RoundedButton btnRefresh;
        private RoundedButton btnMarkAllRead;
        private RoundedButton btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlMain = new Panel();
            this.pnlContainer = new Panel();
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.pnlStats = new Panel();
            this.pnlStatCard1 = new Panel();
            this.lblTotalReminders = new Label();
            this.lblTotalCount = new Label();
            this.pnlStatCard2 = new Panel();
            this.lblUnreadReminders = new Label();
            this.lblUnreadCount = new Label();
            this.pnlStatCard3 = new Panel();
            this.lblOverdueReminders = new Label();
            this.lblOverdueCount = new Label();
            this.pnlStatCard4 = new Panel();
            this.lblTodayReminders = new Label();
            this.lblTodayCount = new Label();
            this.dgvReminders = new DataGridView();
            this.btnRefresh = new RoundedButton();
            this.btnMarkAllRead = new RoundedButton();
            this.btnClose = new RoundedButton();

            this.pnlMain.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlStatCard1.SuspendLayout();
            this.pnlStatCard2.SuspendLayout();
            this.pnlStatCard3.SuspendLayout();
            this.pnlStatCard4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReminders)).BeginInit();
            this.SuspendLayout();

            // ===== FORM =====
            this.ClientSize = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "My Reminders - Botho Clinic";
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // ===== MAIN PANEL =====
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.BackColor = Color.FromArgb(248, 249, 250);
            this.pnlMain.Padding = new Padding(20);

            // ===== CONTAINER PANEL =====
            this.pnlContainer.Size = new Size(960, 660);
            this.pnlContainer.Location = new Point(20, 20);
            this.pnlContainer.BackColor = Color.White;
            this.pnlContainer.Paint += new PaintEventHandler(this.pnlContainer_Paint);

            // ===== HEADER PANEL =====
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Size = new Size(960, 100);
            this.pnlHeader.BackColor = Color.FromArgb(0, 123, 255);
            this.pnlHeader.Paint += new PaintEventHandler(this.pnlHeader_Paint);

            // Title Label
            this.lblTitle.Text = "My Health Reminders";
            this.lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(30, 25);
            this.lblTitle.Size = new Size(900, 35);
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            // Subtitle Label
            this.lblSubtitle.Text = "View and manage all reminders from your healthcare providers";
            this.lblSubtitle.Font = new Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = Color.FromArgb(230, 240, 255);
            this.lblSubtitle.Location = new Point(30, 60);
            this.lblSubtitle.Size = new Size(900, 25);
            this.lblSubtitle.TextAlign = ContentAlignment.MiddleLeft;

            // ===== STATS PANEL =====
            this.pnlStats.Location = new Point(20, 120);
            this.pnlStats.Size = new Size(920, 100);
            this.pnlStats.BackColor = Color.Transparent;

            // Stat Card 1 - Total
            this.pnlStatCard1.Location = new Point(0, 0);
            this.pnlStatCard1.Size = new Size(220, 90);
            this.pnlStatCard1.BackColor = Color.FromArgb(0, 123, 255);
            this.pnlStatCard1.Paint += new PaintEventHandler(this.pnlStatCard_Paint);

            this.lblTotalReminders.Text = "TOTAL REMINDERS";
            this.lblTotalReminders.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblTotalReminders.ForeColor = Color.FromArgb(230, 240, 255);
            this.lblTotalReminders.Location = new Point(15, 15);
            this.lblTotalReminders.Size = new Size(190, 20);

            this.lblTotalCount.Text = "0";
            this.lblTotalCount.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            this.lblTotalCount.ForeColor = Color.White;
            this.lblTotalCount.Location = new Point(15, 35);
            this.lblTotalCount.Size = new Size(190, 45);
            this.lblTotalCount.TextAlign = ContentAlignment.MiddleLeft;

            // Stat Card 2 - Unread
            this.pnlStatCard2.Location = new Point(235, 0);
            this.pnlStatCard2.Size = new Size(220, 90);
            this.pnlStatCard2.BackColor = Color.FromArgb(40, 167, 69);
            this.pnlStatCard2.Paint += new PaintEventHandler(this.pnlStatCard_Paint);

            this.lblUnreadReminders.Text = "UNREAD";
            this.lblUnreadReminders.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblUnreadReminders.ForeColor = Color.FromArgb(230, 255, 240);
            this.lblUnreadReminders.Location = new Point(15, 15);
            this.lblUnreadReminders.Size = new Size(190, 20);

            this.lblUnreadCount.Text = "0";
            this.lblUnreadCount.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            this.lblUnreadCount.ForeColor = Color.White;
            this.lblUnreadCount.Location = new Point(15, 35);
            this.lblUnreadCount.Size = new Size(190, 45);
            this.lblUnreadCount.TextAlign = ContentAlignment.MiddleLeft;

            // Stat Card 3 - Overdue
            this.pnlStatCard3.Location = new Point(470, 0);
            this.pnlStatCard3.Size = new Size(220, 90);
            this.pnlStatCard3.BackColor = Color.FromArgb(255, 193, 7);
            this.pnlStatCard3.Paint += new PaintEventHandler(this.pnlStatCard_Paint);

            this.lblOverdueReminders.Text = "OVERDUE";
            this.lblOverdueReminders.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblOverdueReminders.ForeColor = Color.FromArgb(102, 77, 3);
            this.lblOverdueReminders.Location = new Point(15, 15);
            this.lblOverdueReminders.Size = new Size(190, 20);

            this.lblOverdueCount.Text = "0";
            this.lblOverdueCount.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            this.lblOverdueCount.ForeColor = Color.White;
            this.lblOverdueCount.Location = new Point(15, 35);
            this.lblOverdueCount.Size = new Size(190, 45);
            this.lblOverdueCount.TextAlign = ContentAlignment.MiddleLeft;

            // Stat Card 4 - Today
            this.pnlStatCard4.Location = new Point(705, 0);
            this.pnlStatCard4.Size = new Size(220, 90);
            this.pnlStatCard4.BackColor = Color.FromArgb(220, 53, 69);
            this.pnlStatCard4.Paint += new PaintEventHandler(this.pnlStatCard_Paint);

            this.lblTodayReminders.Text = "TODAY";
            this.lblTodayReminders.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblTodayReminders.ForeColor = Color.FromArgb(255, 230, 230);
            this.lblTodayReminders.Location = new Point(15, 15);
            this.lblTodayReminders.Size = new Size(190, 20);

            this.lblTodayCount.Text = "0";
            this.lblTodayCount.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            this.lblTodayCount.ForeColor = Color.White;
            this.lblTodayCount.Location = new Point(15, 35);
            this.lblTodayCount.Size = new Size(190, 45);
            this.lblTodayCount.TextAlign = ContentAlignment.MiddleLeft;

            // ===== DATAGRIDVIEW =====
            this.dgvReminders.Location = new Point(20, 240);
            this.dgvReminders.Size = new Size(920, 330);
            this.dgvReminders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReminders.BackgroundColor = Color.White;
            this.dgvReminders.BorderStyle = BorderStyle.None;
            this.dgvReminders.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReminders.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvReminders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 58, 64);
            this.dgvReminders.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvReminders.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.dgvReminders.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            this.dgvReminders.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 58, 64);
            this.dgvReminders.ColumnHeadersHeight = 45;
            this.dgvReminders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReminders.DefaultCellStyle.BackColor = Color.White;
            this.dgvReminders.DefaultCellStyle.ForeColor = Color.FromArgb(73, 80, 87);
            this.dgvReminders.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            this.dgvReminders.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 123, 255);
            this.dgvReminders.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvReminders.DefaultCellStyle.Padding = new Padding(10, 6, 10, 6);
            this.dgvReminders.EnableHeadersVisualStyles = false;
            this.dgvReminders.GridColor = Color.FromArgb(222, 226, 230);
            this.dgvReminders.ReadOnly = true;
            this.dgvReminders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvReminders.MultiSelect = false;
            this.dgvReminders.RowHeadersVisible = false;
            this.dgvReminders.AllowUserToAddRows = false;
            this.dgvReminders.AllowUserToDeleteRows = false;
            this.dgvReminders.RowTemplate.Height = 40;
            this.dgvReminders.ScrollBars = ScrollBars.Vertical;
            this.dgvReminders.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);

            // ===== BUTTONS =====
            // Refresh Button
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.Location = new Point(20, 590);
            this.btnRefresh.Size = new Size(160, 45);
            this.btnRefresh.BackColor = Color.FromArgb(40, 167, 69);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.btnRefresh.MouseEnter += new EventHandler(this.btnRefresh_MouseEnter);
            this.btnRefresh.MouseLeave += new EventHandler(this.btnRefresh_MouseLeave);

            // Mark All Read Button
            this.btnMarkAllRead.Text = "MARK ALL READ";
            this.btnMarkAllRead.Location = new Point(195, 590);
            this.btnMarkAllRead.Size = new Size(180, 45);
            this.btnMarkAllRead.BackColor = Color.FromArgb(255, 193, 7);
            this.btnMarkAllRead.ForeColor = Color.FromArgb(52, 58, 64);
            this.btnMarkAllRead.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.btnMarkAllRead.FlatStyle = FlatStyle.Flat;
            this.btnMarkAllRead.FlatAppearance.BorderSize = 0;
            this.btnMarkAllRead.Cursor = Cursors.Hand;
            this.btnMarkAllRead.Click += new EventHandler(this.btnMarkAllRead_Click);
            this.btnMarkAllRead.MouseEnter += new EventHandler(this.btnMarkAllRead_MouseEnter);
            this.btnMarkAllRead.MouseLeave += new EventHandler(this.btnMarkAllRead_MouseLeave);

            // Close Button
            this.btnClose.Text = "CLOSE";
            this.btnClose.Location = new Point(780, 590);
            this.btnClose.Size = new Size(160, 45);
            this.btnClose.BackColor = Color.FromArgb(108, 117, 125);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new EventHandler(this.btnClose_MouseLeave);

            // ===== ADD CONTROLS TO STAT CARDS =====
            this.pnlStatCard1.Controls.Add(this.lblTotalReminders);
            this.pnlStatCard1.Controls.Add(this.lblTotalCount);
            this.pnlStatCard2.Controls.Add(this.lblUnreadReminders);
            this.pnlStatCard2.Controls.Add(this.lblUnreadCount);
            this.pnlStatCard3.Controls.Add(this.lblOverdueReminders);
            this.pnlStatCard3.Controls.Add(this.lblOverdueCount);
            this.pnlStatCard4.Controls.Add(this.lblTodayReminders);
            this.pnlStatCard4.Controls.Add(this.lblTodayCount);

            // ===== ADD STAT CARDS TO STATS PANEL =====
            this.pnlStats.Controls.Add(this.pnlStatCard1);
            this.pnlStats.Controls.Add(this.pnlStatCard2);
            this.pnlStats.Controls.Add(this.pnlStatCard3);
            this.pnlStats.Controls.Add(this.pnlStatCard4);

            // ===== ADD CONTROLS TO HEADER =====
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            // ===== ADD CONTROLS TO CONTAINER =====
            this.pnlContainer.Controls.Add(this.pnlHeader);
            this.pnlContainer.Controls.Add(this.pnlStats);
            this.pnlContainer.Controls.Add(this.dgvReminders);
            this.pnlContainer.Controls.Add(this.btnRefresh);
            this.pnlContainer.Controls.Add(this.btnMarkAllRead);
            this.pnlContainer.Controls.Add(this.btnClose);

            // ===== ADD CONTAINER TO MAIN =====
            this.pnlMain.Controls.Add(this.pnlContainer);

            // ===== ADD MAIN TO FORM =====
            this.Controls.Add(this.pnlMain);

            this.pnlMain.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlStats.ResumeLayout(false);
            this.pnlStatCard1.ResumeLayout(false);
            this.pnlStatCard2.ResumeLayout(false);
            this.pnlStatCard3.ResumeLayout(false);
            this.pnlStatCard4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReminders)).EndInit();
            this.ResumeLayout(false);
        }

        // Header gradient paint
        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                panel.ClientRectangle,
                Color.FromArgb(0, 123, 255),
                Color.FromArgb(0, 95, 204),
                LinearGradientMode.Horizontal))
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 15;
                    path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                    path.AddArc(panel.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
                    path.AddLine(panel.Width, panel.Height, 0, panel.Height);
                    path.CloseFigure();
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

        // Container card with shadow
        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw shadow layers
            for (int i = 0; i < 3; i++)
            {
                int offset = 4 + (i * 2);
                int alpha = 25 - (i * 5);
                using (GraphicsPath shadowPath = GetRoundedRectangle(
                    new Rectangle(offset, offset, panel.Width - 1, panel.Height - 1), 15))
                using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(alpha, 0, 0, 0)))
                {
                    e.Graphics.FillPath(shadowBrush, shadowPath);
                }
            }

            // Draw card
            using (GraphicsPath path = GetRoundedRectangle(
                new Rectangle(0, 0, panel.Width - 1, panel.Height - 1), 15))
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                e.Graphics.FillPath(brush, path);
            }
        }

        // Stat cards paint
        private void pnlStatCard_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw subtle shadow
            using (GraphicsPath shadowPath = GetRoundedRectangle(
                new Rectangle(2, 2, panel.Width - 1, panel.Height - 1), 8))
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(20, 0, 0, 0)))
            {
                e.Graphics.FillPath(shadowBrush, shadowPath);
            }

            // Draw card
            using (GraphicsPath path = GetRoundedRectangle(
                new Rectangle(0, 0, panel.Width - 1, panel.Height - 1), 8))
            using (SolidBrush brush = new SolidBrush(panel.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }
        }

        // Helper method for rounded rectangles
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

        // Button hover effects
        private void btnRefresh_MouseEnter(object sender, EventArgs e)
        {
            btnRefresh.BackColor = Color.FromArgb(33, 136, 56);
        }

        private void btnRefresh_MouseLeave(object sender, EventArgs e)
        {
            btnRefresh.BackColor = Color.FromArgb(40, 167, 69);
        }

        private void btnMarkAllRead_MouseEnter(object sender, EventArgs e)
        {
            btnMarkAllRead.BackColor = Color.FromArgb(230, 174, 6);
        }

        private void btnMarkAllRead_MouseLeave(object sender, EventArgs e)
        {
            btnMarkAllRead.BackColor = Color.FromArgb(255, 193, 7);
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(90, 98, 104);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(108, 117, 125);
        }

        // Custom rounded button
        private class RoundedButton : Button
        {
            protected override void OnPaint(PaintEventArgs pevent)
            {
                GraphicsPath path = new GraphicsPath();
                int radius = 8;
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