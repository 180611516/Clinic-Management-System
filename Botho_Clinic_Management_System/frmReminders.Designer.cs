using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Botho_Clinic_Management_System
{
    partial class frmReminders
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlMain;
        private Panel pnlHeader;
        private Panel pnlForm;
        private DataGridView dgvReminders;
        private ComboBox cmbStudent;
        private TextBox txtMessage;
        private DateTimePicker dtpReminderDate;
        private RoundedButton btnAddReminder;
        private RoundedButton btnRefresh;
        private Label lblStudent;
        private Label lblMessage;
        private Label lblDate;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblRemindersTitle;

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
            this.pnlForm = new Panel();
            this.dgvReminders = new DataGridView();
            this.cmbStudent = new ComboBox();
            this.txtMessage = new TextBox();
            this.dtpReminderDate = new DateTimePicker();
            this.btnAddReminder = new RoundedButton();
            this.btnRefresh = new RoundedButton();
            this.lblStudent = new Label();
            this.lblMessage = new Label();
            this.lblDate = new Label();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.lblRemindersTitle = new Label();

            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReminders)).BeginInit();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.BackColor = Color.FromArgb(236, 240, 241);
            this.pnlMain.Controls.Add(this.dgvReminders);
            this.pnlMain.Controls.Add(this.lblRemindersTitle);
            this.pnlMain.Controls.Add(this.pnlForm);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Padding = new Padding(30);
            this.pnlMain.Size = new Size(1000, 700);

            // pnlHeader
            this.pnlHeader.BackColor = Color.White;
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Location = new Point(30, 30);
            this.pnlHeader.Size = new Size(940, 90);
            this.pnlHeader.Paint += new PaintEventHandler(this.pnlCard_Paint);

            // lblTitle
            this.lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Text = "🔔 Provider Reminders";

            // lblSubtitle
            this.lblSubtitle.Font = new Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new Point(25, 55);
            this.lblSubtitle.Text = "Create and manage student appointment reminders";

            // pnlForm
            this.pnlForm.BackColor = Color.White;
            this.pnlForm.Controls.Add(this.btnRefresh);
            this.pnlForm.Controls.Add(this.btnAddReminder);
            this.pnlForm.Controls.Add(this.dtpReminderDate);
            this.pnlForm.Controls.Add(this.lblDate);
            this.pnlForm.Controls.Add(this.txtMessage);
            this.pnlForm.Controls.Add(this.lblMessage);
            this.pnlForm.Controls.Add(this.cmbStudent);
            this.pnlForm.Controls.Add(this.lblStudent);
            this.pnlForm.Location = new Point(30, 140);
            this.pnlForm.Size = new Size(940, 180);
            this.pnlForm.Paint += new PaintEventHandler(this.pnlCard_Paint);

            // lblStudent
            this.lblStudent.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblStudent.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblStudent.AutoSize = true;
            this.lblStudent.Location = new Point(20, 20);
            this.lblStudent.Text = "👤 Select Student";

            // cmbStudent
            this.cmbStudent.BackColor = Color.FromArgb(245, 247, 250);
            this.cmbStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStudent.FlatStyle = FlatStyle.Flat;
            this.cmbStudent.Font = new Font("Segoe UI", 11F);
            this.cmbStudent.ForeColor = Color.FromArgb(44, 62, 80);
            this.cmbStudent.Location = new Point(20, 45);
            this.cmbStudent.Size = new Size(280, 28);

            // lblMessage
            this.lblMessage.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblMessage.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new Point(320, 20);
            this.lblMessage.Text = "📝 Reminder Message";

            // txtMessage
            this.txtMessage.BackColor = Color.FromArgb(245, 247, 250);
            this.txtMessage.BorderStyle = BorderStyle.None;
            this.txtMessage.Font = new Font("Segoe UI", 11F);
            this.txtMessage.ForeColor = Color.FromArgb(44, 62, 80);
            this.txtMessage.Location = new Point(320, 45);
            this.txtMessage.Multiline = true;
            this.txtMessage.Padding = new Padding(10);
            this.txtMessage.Size = new Size(280, 80);

            // lblDate
            this.lblDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblDate.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new Point(20, 90);
            this.lblDate.Text = "📅 Reminder Date";

            // dtpReminderDate
            this.dtpReminderDate.Font = new Font("Segoe UI", 11F);
            this.dtpReminderDate.Location = new Point(20, 115);
            this.dtpReminderDate.Size = new Size(280, 27);
            this.dtpReminderDate.Format = DateTimePickerFormat.Long;

            // btnAddReminder
            this.btnAddReminder.BackColor = Color.FromArgb(46, 204, 113);
            this.btnAddReminder.FlatStyle = FlatStyle.Flat;
            this.btnAddReminder.FlatAppearance.BorderSize = 0;
            this.btnAddReminder.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnAddReminder.ForeColor = Color.White;
            this.btnAddReminder.Location = new Point(630, 45);
            this.btnAddReminder.Size = new Size(280, 45);
            this.btnAddReminder.Text = "➕ Add Reminder";
            this.btnAddReminder.Cursor = Cursors.Hand;
            this.btnAddReminder.Click += new EventHandler(this.btnAddReminder_Click);
            this.btnAddReminder.MouseEnter += new EventHandler(this.btnAdd_MouseEnter);
            this.btnAddReminder.MouseLeave += new EventHandler(this.btnAdd_MouseLeave);

            // btnRefresh
            this.btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new Point(630, 100);
            this.btnRefresh.Size = new Size(280, 45);
            this.btnRefresh.Text = "🔄 Refresh List";
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.btnRefresh.MouseEnter += new EventHandler(this.btnRefresh_MouseEnter);
            this.btnRefresh.MouseLeave += new EventHandler(this.btnRefresh_MouseLeave);

            // lblRemindersTitle
            this.lblRemindersTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblRemindersTitle.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblRemindersTitle.AutoSize = true;
            this.lblRemindersTitle.Location = new Point(35, 340);
            this.lblRemindersTitle.Text = "📋 Active Reminders";

            // dgvReminders
            this.dgvReminders.AllowUserToAddRows = false;
            this.dgvReminders.AllowUserToDeleteRows = false;
            this.dgvReminders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReminders.BackgroundColor = Color.White;
            this.dgvReminders.BorderStyle = BorderStyle.None;
            this.dgvReminders.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReminders.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvReminders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            this.dgvReminders.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvReminders.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.dgvReminders.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            this.dgvReminders.ColumnHeadersHeight = 45;
            this.dgvReminders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReminders.DefaultCellStyle.BackColor = Color.White;
            this.dgvReminders.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            this.dgvReminders.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvReminders.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            this.dgvReminders.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvReminders.DefaultCellStyle.Padding = new Padding(8);
            this.dgvReminders.EnableHeadersVisualStyles = false;
            this.dgvReminders.GridColor = Color.FromArgb(189, 195, 199);
            this.dgvReminders.Location = new Point(30, 380);
            this.dgvReminders.MultiSelect = false;
            this.dgvReminders.Name = "dgvReminders";
            this.dgvReminders.ReadOnly = true;
            this.dgvReminders.RowHeadersVisible = false;
            this.dgvReminders.RowTemplate.Height = 40;
            this.dgvReminders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvReminders.Size = new Size(940, 290);

            // frmReminders
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.ClientSize = new Size(1000, 700);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "frmReminders";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Provider Reminders - Botho Clinic";

            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReminders)).EndInit();
            this.ResumeLayout(false);
        }

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath shadowPath = GetRoundedRect(new Rectangle(3, 3, panel.Width - 1, panel.Height - 1), 12))
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(20, 0, 0, 0)))
            {
                e.Graphics.FillPath(shadowBrush, shadowPath);
            }

            using (GraphicsPath path = GetRoundedRect(new Rectangle(0, 0, panel.Width - 1, panel.Height - 1), 12))
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                e.Graphics.FillPath(brush, path);
            }
        }

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

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAddReminder.BackColor = Color.FromArgb(39, 174, 96);
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAddReminder.BackColor = Color.FromArgb(46, 204, 113);
        }

        private void btnRefresh_MouseEnter(object sender, EventArgs e)
        {
            btnRefresh.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void btnRefresh_MouseLeave(object sender, EventArgs e)
        {
            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
        }

        private class RoundedButton : Button
        {
            protected override void OnPaint(PaintEventArgs pevent)
            {
                GraphicsPath path = new GraphicsPath();
                Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                int radius = 8;

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