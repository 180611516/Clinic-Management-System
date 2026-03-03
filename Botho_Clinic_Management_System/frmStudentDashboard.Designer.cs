using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Botho_Clinic_Management_System
{
    partial class frmStudentDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlSidebar;
        private RoundedButton btnBookAppointment;
        private RoundedButton btnAppointmentHistory;
        private RoundedButton btnReminders;
        private RoundedButton btnProfile; 
        private RoundedButton btnLogout;
        private Panel pnlMain;
        private Panel pnlHeader;
        private Label lblWelcome;
        private Label lblSubtitle;
        private Label lblDateTime;
        private Timer timerDateTime;

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
            this.btnLogout = new Botho_Clinic_Management_System.frmStudentDashboard.RoundedButton();
            this.btnProfile = new Botho_Clinic_Management_System.frmStudentDashboard.RoundedButton();
            this.btnReminders = new Botho_Clinic_Management_System.frmStudentDashboard.RoundedButton();
            this.btnAppointmentHistory = new Botho_Clinic_Management_System.frmStudentDashboard.RoundedButton();
            this.btnBookAppointment = new Botho_Clinic_Management_System.frmStudentDashboard.RoundedButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.pnlSidebar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnProfile);
            this.pnlSidebar.Controls.Add(this.btnReminders);
            this.pnlSidebar.Controls.Add(this.btnAppointmentHistory);
            this.pnlSidebar.Controls.Add(this.btnBookAppointment);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(240, 607);
            this.pnlSidebar.TabIndex = 1;
            this.pnlSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSidebar_Paint);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(17, 499);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(17, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(206, 48);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "🚪  Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            this.btnLogout.MouseEnter += new System.EventHandler(this.btnLogout_MouseEnter);
            this.btnLogout.MouseLeave += new System.EventHandler(this.btnLogout_MouseLeave);
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.Location = new System.Drawing.Point(17, 269);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Padding = new System.Windows.Forms.Padding(17, 0, 0, 0);
            this.btnProfile.Size = new System.Drawing.Size(206, 48);
            this.btnProfile.TabIndex = 4;
            this.btnProfile.Text = "👤  My Profile";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            this.btnProfile.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnProfile.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnReminders
            // 
            this.btnReminders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnReminders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReminders.FlatAppearance.BorderSize = 0;
            this.btnReminders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReminders.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReminders.ForeColor = System.Drawing.Color.White;
            this.btnReminders.Location = new System.Drawing.Point(17, 208);
            this.btnReminders.Name = "btnReminders";
            this.btnReminders.Padding = new System.Windows.Forms.Padding(17, 0, 0, 0);
            this.btnReminders.Size = new System.Drawing.Size(206, 48);
            this.btnReminders.TabIndex = 1;
            this.btnReminders.Text = "🔔  Reminders";
            this.btnReminders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReminders.UseVisualStyleBackColor = false;
            this.btnReminders.Click += new System.EventHandler(this.btnReminders_Click);
            this.btnReminders.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnReminders.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnAppointmentHistory
            // 
            this.btnAppointmentHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnAppointmentHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAppointmentHistory.FlatAppearance.BorderSize = 0;
            this.btnAppointmentHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppointmentHistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAppointmentHistory.ForeColor = System.Drawing.Color.White;
            this.btnAppointmentHistory.Location = new System.Drawing.Point(17, 147);
            this.btnAppointmentHistory.Name = "btnAppointmentHistory";
            this.btnAppointmentHistory.Padding = new System.Windows.Forms.Padding(17, 0, 0, 0);
            this.btnAppointmentHistory.Size = new System.Drawing.Size(206, 48);
            this.btnAppointmentHistory.TabIndex = 2;
            this.btnAppointmentHistory.Text = "📋  History";
            this.btnAppointmentHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAppointmentHistory.UseVisualStyleBackColor = false;
            this.btnAppointmentHistory.Click += new System.EventHandler(this.btnAppointmentHistory_Click);
            this.btnAppointmentHistory.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnAppointmentHistory.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnBookAppointment
            // 
            this.btnBookAppointment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnBookAppointment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBookAppointment.FlatAppearance.BorderSize = 0;
            this.btnBookAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookAppointment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBookAppointment.ForeColor = System.Drawing.Color.White;
            this.btnBookAppointment.Location = new System.Drawing.Point(17, 87);
            this.btnBookAppointment.Name = "btnBookAppointment";
            this.btnBookAppointment.Padding = new System.Windows.Forms.Padding(17, 0, 0, 0);
            this.btnBookAppointment.Size = new System.Drawing.Size(206, 48);
            this.btnBookAppointment.TabIndex = 3;
            this.btnBookAppointment.Text = "📅  Book Appointment";
            this.btnBookAppointment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBookAppointment.UseVisualStyleBackColor = false;
            this.btnBookAppointment.Click += new System.EventHandler(this.btnBookAppointment_Click);
            this.btnBookAppointment.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnBookAppointment.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(240, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(26);
            this.pnlMain.Size = new System.Drawing.Size(789, 607);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblDateTime);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(26, 26);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(737, 95);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCard_Paint);
            // 
            // lblDateTime
            // 
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblDateTime.Location = new System.Drawing.Point(514, 39);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(206, 17);
            this.lblDateTime.TabIndex = 0;
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblSubtitle.Location = new System.Drawing.Point(26, 61);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(343, 17);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Manage your appointments and health records";
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblWelcome.Location = new System.Drawing.Point(21, 17);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(429, 39);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "Welcome, Student";
            // 
            // timerDateTime
            // 
            this.timerDateTime.Enabled = true;
            this.timerDateTime.Interval = 1000;
            this.timerDateTime.Tick += new System.EventHandler(this.timerDateTime_Tick);
            // 
            // frmStudentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1029, 607);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "frmStudentDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Dashboard - Botho Clinic";
            this.Load += new System.EventHandler(this.frmStudentDashboard_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        // Sidebar gradient paint
        private void pnlSidebar_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                pnlSidebar.ClientRectangle,
                Color.FromArgb(44, 62, 80),
                Color.FromArgb(52, 73, 94),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, pnlSidebar.ClientRectangle);
            }

            Rectangle logoRect = new Rectangle(15, 15, 250, 65);
            using (GraphicsPath path = GetRoundedRectangle(logoRect, 8))
            using (SolidBrush bgBrush = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(bgBrush, path);
            }

            using (Font logoFont = new Font("Segoe UI", 18F, FontStyle.Bold))
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                e.Graphics.DrawString("🏥 Botho Clinic", logoFont, brush, new PointF(25, 30));
            }

            using (Pen pen = new Pen(Color.FromArgb(50, 255, 255, 255), 1))
            {
                e.Graphics.DrawLine(pen, 20, 320, 260, 320);
            }
        }

        // Card paint with shadow
        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath shadowPath = GetRoundedRectangle(new Rectangle(3, 3, panel.Width - 1, panel.Height - 1), 12))
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(20, 0, 0, 0)))
            {
                e.Graphics.FillPath(shadowBrush, shadowPath);
            }

            using (GraphicsPath path = GetRoundedRectangle(new Rectangle(0, 0, panel.Width - 1, panel.Height - 1), 12))
            using (SolidBrush brush = new SolidBrush(Color.White))
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
        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is RoundedButton button && button != btnLogout)
            {
                button.BackColor = ControlPaint.Light(button.BackColor, 0.2f);
            }
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is RoundedButton button)
            {
                // Restore original colors
                if (button == btnBookAppointment)
                    button.BackColor = Color.FromArgb(52, 152, 219);
                else if (button == btnAppointmentHistory || button == btnReminders)
                    button.BackColor = Color.FromArgb(52, 73, 94);
                else if (button == btnProfile)
                    button.BackColor = Color.FromArgb(155, 89, 182);
            }
        }

        private void BtnLogout_MouseEnter(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(231, 76, 60);
        }

        private void BtnLogout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(192, 57, 43);
        }

        // Update date/time
        private void TimerDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, MMM dd, yyyy  •  hh:mm tt");
        }

        // Form load
        private void FrmStudentDashboard_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, MMM dd, yyyy  •  hh:mm tt");
        }

        // Profile button click event handler
        private void BtnProfile_Click(object sender, EventArgs e)
        {
            frmUserProfile profileForm = new frmUserProfile(_userId, "Student");
            profileForm.ShowDialog();
        }

        // Custom rounded button class
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