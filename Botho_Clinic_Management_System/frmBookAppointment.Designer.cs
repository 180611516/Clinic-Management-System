using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Botho_Clinic_Management_System
{
    partial class frmBookAppointment
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlMain;
        private Panel pnlHeader;
        private Panel pnlCalendar;
        private Panel pnlDetails;
        private MonthCalendar monthCalendar1;
        private ComboBox cmbProvider;
        private ListBox lstTimeSlots;
        private TextBox txtReason;
        private RoundedButton btnBook;
        private Label lblProvider;
        private Label lblTimeSlot;
        private Label lblReason;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblCalendarTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new Panel();
            this.pnlHeader = new Panel();
            this.pnlCalendar = new Panel();
            this.pnlDetails = new Panel();
            this.monthCalendar1 = new MonthCalendar();
            this.cmbProvider = new ComboBox();
            this.lstTimeSlots = new ListBox();
            this.txtReason = new TextBox();
            this.btnBook = new RoundedButton();
            this.lblProvider = new Label();
            this.lblTimeSlot = new Label();
            this.lblReason = new Label();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.lblCalendarTitle = new Label();

            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlCalendar.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.BackColor = Color.FromArgb(236, 240, 241);
            this.pnlMain.Controls.Add(this.btnBook);
            this.pnlMain.Controls.Add(this.pnlDetails);
            this.pnlMain.Controls.Add(this.pnlCalendar);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Location = new Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new Padding(30);
            this.pnlMain.Size = new Size(900, 650);

            // pnlHeader
            this.pnlHeader.BackColor = Color.White;
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(30, 30);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(840, 90);
            this.pnlHeader.Paint += new PaintEventHandler(this.pnlCard_Paint);

            // lblTitle
            this.lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(400, 40);
            this.lblTitle.Text = "📅 Book Appointment";

            // lblSubtitle
            this.lblSubtitle.Font = new Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblSubtitle.Location = new Point(25, 55);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new Size(400, 25);
            this.lblSubtitle.Text = "Select date, provider, and time for your appointment";

            // pnlCalendar
            this.pnlCalendar.BackColor = Color.White;
            this.pnlCalendar.Controls.Add(this.lblCalendarTitle);
            this.pnlCalendar.Controls.Add(this.monthCalendar1);
            this.pnlCalendar.Location = new Point(30, 140);
            this.pnlCalendar.Name = "pnlCalendar";
            this.pnlCalendar.Size = new Size(400, 330);
            this.pnlCalendar.Paint += new PaintEventHandler(this.pnlCard_Paint);

            // lblCalendarTitle
            this.lblCalendarTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblCalendarTitle.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblCalendarTitle.Location = new Point(20, 20);
            this.lblCalendarTitle.Name = "lblCalendarTitle";
            this.lblCalendarTitle.Size = new Size(250, 25);
            this.lblCalendarTitle.Text = "📆 Select Date";

            // monthCalendar1
            this.monthCalendar1.Location = new Point(35, 60);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.BackColor = Color.White;
            this.monthCalendar1.TitleBackColor = Color.FromArgb(52, 152, 219);
            this.monthCalendar1.TitleForeColor = Color.White;
            this.monthCalendar1.TrailingForeColor = Color.FromArgb(150, 150, 150);
            this.monthCalendar1.Font = new Font("Segoe UI", 10F);
            this.monthCalendar1.DateChanged += new DateRangeEventHandler(this.monthCalendar1_DateChanged);

            // pnlDetails
            this.pnlDetails.BackColor = Color.White;
            this.pnlDetails.Controls.Add(this.lblProvider);
            this.pnlDetails.Controls.Add(this.cmbProvider);
            this.pnlDetails.Controls.Add(this.lblTimeSlot);
            this.pnlDetails.Controls.Add(this.lstTimeSlots);
            this.pnlDetails.Controls.Add(this.lblReason);
            this.pnlDetails.Controls.Add(this.txtReason);
            this.pnlDetails.Location = new Point(450, 140);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new Size(420, 330);
            this.pnlDetails.Paint += new PaintEventHandler(this.pnlCard_Paint);

            // lblProvider
            this.lblProvider.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblProvider.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblProvider.Location = new Point(20, 20);
            this.lblProvider.Name = "lblProvider";
            this.lblProvider.Size = new Size(200, 25);
            this.lblProvider.Text = "👨‍⚕️ Select Provider";

            // cmbProvider
            this.cmbProvider.BackColor = Color.FromArgb(245, 247, 250);
            this.cmbProvider.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbProvider.FlatStyle = FlatStyle.Flat;
            this.cmbProvider.Font = new Font("Segoe UI", 11F);
            this.cmbProvider.ForeColor = Color.FromArgb(44, 62, 80);
            this.cmbProvider.Location = new Point(20, 50);
            this.cmbProvider.Name = "cmbProvider";
            this.cmbProvider.Size = new Size(380, 28);
            this.cmbProvider.SelectedIndexChanged += new EventHandler(this.cmbProvider_SelectedIndexChanged);

            // lblTimeSlot
            this.lblTimeSlot.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTimeSlot.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblTimeSlot.Location = new Point(20, 90);
            this.lblTimeSlot.Name = "lblTimeSlot";
            this.lblTimeSlot.Size = new Size(250, 25);
            this.lblTimeSlot.Text = "🕐 Available Time Slots";

            // lstTimeSlots
            this.lstTimeSlots.BackColor = Color.FromArgb(245, 247, 250);
            this.lstTimeSlots.BorderStyle = BorderStyle.None;
            this.lstTimeSlots.Font = new Font("Segoe UI", 10F);
            this.lstTimeSlots.ForeColor = Color.FromArgb(44, 62, 80);
            this.lstTimeSlots.ItemHeight = 22;
            this.lstTimeSlots.Location = new Point(20, 120);
            this.lstTimeSlots.Name = "lstTimeSlots";
            this.lstTimeSlots.Size = new Size(380, 88);

            // lblReason
            this.lblReason.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblReason.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblReason.Location = new Point(20, 220);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new Size(200, 25);
            this.lblReason.Text = "📝 Reason for Visit";

            // txtReason
            this.txtReason.BackColor = Color.FromArgb(245, 247, 250);
            this.txtReason.BorderStyle = BorderStyle.None;
            this.txtReason.Font = new Font("Segoe UI", 11F);
            this.txtReason.ForeColor = Color.Gray;
            this.txtReason.Location = new Point(20, 250);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Padding = new Padding(10);
            this.txtReason.Size = new Size(380, 60);
            this.txtReason.Text = "Enter reason for visit...";
            this.txtReason.GotFocus += new EventHandler(this.txtReason_GotFocus);
            this.txtReason.LostFocus += new EventHandler(this.txtReason_LostFocus);

            // btnBook
            this.btnBook.BackColor = Color.FromArgb(46, 204, 113);
            this.btnBook.Cursor = Cursors.Hand;
            this.btnBook.FlatAppearance.BorderSize = 0;
            this.btnBook.FlatStyle = FlatStyle.Flat;
            this.btnBook.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.btnBook.ForeColor = Color.White;
            this.btnBook.Location = new Point(30, 490);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new Size(840, 50);
            this.btnBook.Text = "✅ Confirm Appointment";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new EventHandler(this.btnBook_Click);
            this.btnBook.MouseEnter += new EventHandler(this.btnBook_MouseEnter);
            this.btnBook.MouseLeave += new EventHandler(this.btnBook_MouseLeave);

            // frmBookAppointment
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.ClientSize = new Size(900, 600);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmBookAppointment";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Book Appointment - Botho Clinic";

            this.pnlMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlCalendar.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.ResumeLayout(false);
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

        // Placeholder behavior for txtReason
        private void txtReason_GotFocus(object sender, EventArgs e)
        {
            if (txtReason.Text == "Enter reason for visit...")
            {
                txtReason.Text = "";
                txtReason.ForeColor = Color.FromArgb(44, 62, 80);
            }
        }

        private void txtReason_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                txtReason.Text = "Enter reason for visit...";
                txtReason.ForeColor = Color.Gray;
            }
        }

        // Button hover effects
        private void btnBook_MouseEnter(object sender, EventArgs e)
        {
            btnBook.BackColor = Color.FromArgb(39, 174, 96);
        }

        private void btnBook_MouseLeave(object sender, EventArgs e)
        {
            btnBook.BackColor = Color.FromArgb(46, 204, 113);
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