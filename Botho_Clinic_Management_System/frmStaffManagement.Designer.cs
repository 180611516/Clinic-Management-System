using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Botho_Clinic_Management_System
{
    partial class frmStaffManagement
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtContactInfo;
        private System.Windows.Forms.ComboBox cmbRole;
        private RoundedButton btnAddUser;
        private RoundedButton btnEditUser;
        private RoundedButton btnDeleteUser;
        private RoundedButton btnResetPassword;
        private RoundedButton btnClear;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblContactInfo;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.TextBox txtSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblContactInfo = new System.Windows.Forms.Label();
            this.txtContactInfo = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnAddUser = new RoundedButton();
            this.btnEditUser = new RoundedButton();
            this.btnDeleteUser = new RoundedButton();
            this.btnResetPassword = new RoundedButton();
            this.btnClear = new RoundedButton();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();

            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.BackColor = Color.FromArgb(236, 240, 241);
            this.pnlMain.Controls.Add(this.dgvUsers);
            this.pnlMain.Controls.Add(this.txtSearch);
            this.pnlMain.Controls.Add(this.picSearch);
            this.pnlMain.Controls.Add(this.pnlActions);
            this.pnlMain.Controls.Add(this.pnlForm);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Location = new Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new Padding(30);
            this.pnlMain.Size = new Size(1100, 700);

            // pnlHeader
            this.pnlHeader.BackColor = Color.White;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(30, 30);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(1040, 90);
            this.pnlHeader.Paint += new PaintEventHandler(this.pnlCard_Paint);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(41, 128, 185);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(280, 41);
            this.lblTitle.Text = "👥 Staff Management";

            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = Color.FromArgb(127, 140, 141);
            this.lblSubtitle.Location = new Point(25, 60);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new Size(250, 19);
            this.lblSubtitle.Text = "Manage users, roles, and permissions";

            // pnlForm
            this.pnlForm.BackColor = Color.White;
            this.pnlForm.Controls.Add(this.lblFormTitle);
            this.pnlForm.Controls.Add(this.lblUsername);
            this.pnlForm.Controls.Add(this.txtUsername);
            this.pnlForm.Controls.Add(this.lblFullName);
            this.pnlForm.Controls.Add(this.txtFullName);
            this.pnlForm.Controls.Add(this.lblContactInfo);
            this.pnlForm.Controls.Add(this.txtContactInfo);
            this.pnlForm.Controls.Add(this.lblRole);
            this.pnlForm.Controls.Add(this.cmbRole);
            this.pnlForm.Location = new Point(30, 140);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new Size(680, 180);
            this.pnlForm.Paint += new PaintEventHandler(this.pnlCard_Paint);

            // lblFormTitle
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblFormTitle.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblFormTitle.Location = new Point(20, 15);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new Size(150, 21);
            this.lblFormTitle.Text = "User Information";

            // lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblUsername.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblUsername.Location = new Point(30, 55);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new Size(76, 19);
            this.lblUsername.Text = "Username";

            // txtUsername
            this.txtUsername.BackColor = Color.FromArgb(245, 247, 250);
            this.txtUsername.BorderStyle = BorderStyle.None;
            this.txtUsername.Font = new Font("Segoe UI", 11F);
            this.txtUsername.Location = new Point(30, 80);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new Size(280, 20);
            this.txtUsername.Padding = new Padding(10);

            // lblFullName
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblFullName.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblFullName.Location = new Point(360, 55);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new Size(76, 19);
            this.lblFullName.Text = "Full Name";

            // txtFullName
            this.txtFullName.BackColor = Color.FromArgb(245, 247, 250);
            this.txtFullName.BorderStyle = BorderStyle.None;
            this.txtFullName.Font = new Font("Segoe UI", 11F);
            this.txtFullName.Location = new Point(360, 80);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new Size(280, 20);
            this.txtFullName.Padding = new Padding(10);

            // lblContactInfo
            this.lblContactInfo.AutoSize = true;
            this.lblContactInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblContactInfo.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblContactInfo.Location = new Point(30, 115);
            this.lblContactInfo.Name = "lblContactInfo";
            this.lblContactInfo.Size = new Size(93, 19);
            this.lblContactInfo.Text = "Contact Info";

            // txtContactInfo
            this.txtContactInfo.BackColor = Color.FromArgb(245, 247, 250);
            this.txtContactInfo.BorderStyle = BorderStyle.None;
            this.txtContactInfo.Font = new Font("Segoe UI", 11F);
            this.txtContactInfo.Location = new Point(30, 140);
            this.txtContactInfo.Name = "txtContactInfo";
            this.txtContactInfo.Size = new Size(280, 20);
            this.txtContactInfo.Padding = new Padding(10);

            // lblRole
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblRole.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblRole.Location = new Point(360, 115);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new Size(39, 19);
            this.lblRole.Text = "Role";

            // cmbRole
            this.cmbRole.BackColor = Color.FromArgb(245, 247, 250);
            this.cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRole.FlatStyle = FlatStyle.Flat;
            this.cmbRole.Font = new Font("Segoe UI", 11F);
            this.cmbRole.Items.AddRange(new object[] { "Admin", "Provider", "Student" });
            this.cmbRole.Location = new Point(360, 140);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new Size(280, 28);

            // pnlActions
            this.pnlActions.BackColor = Color.White;
            this.pnlActions.Controls.Add(this.btnAddUser);
            this.pnlActions.Controls.Add(this.btnEditUser);
            this.pnlActions.Controls.Add(this.btnDeleteUser);
            this.pnlActions.Controls.Add(this.btnResetPassword);
            this.pnlActions.Controls.Add(this.btnClear);
            this.pnlActions.Location = new Point(730, 140);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new Size(340, 180);
            this.pnlActions.Paint += new PaintEventHandler(this.pnlCard_Paint);

            // btnAddUser
            this.btnAddUser.BackColor = Color.FromArgb(46, 204, 113);
            this.btnAddUser.FlatAppearance.BorderSize = 0;
            this.btnAddUser.FlatStyle = FlatStyle.Flat;
            this.btnAddUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnAddUser.ForeColor = Color.White;
            this.btnAddUser.Location = new Point(20, 20);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new Size(300, 40);
            this.btnAddUser.Text = "➕ Add User";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new EventHandler(this.btnAddUser_Click);
            this.btnAddUser.MouseEnter += new EventHandler(this.btnAdd_MouseEnter);
            this.btnAddUser.MouseLeave += new EventHandler(this.btnAdd_MouseLeave);

            // btnEditUser
            this.btnEditUser.BackColor = Color.FromArgb(52, 152, 219);
            this.btnEditUser.FlatAppearance.BorderSize = 0;
            this.btnEditUser.FlatStyle = FlatStyle.Flat;
            this.btnEditUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnEditUser.ForeColor = Color.White;
            this.btnEditUser.Location = new Point(20, 70);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new Size(145, 40);
            this.btnEditUser.Text = "✏️ Edit";
            this.btnEditUser.UseVisualStyleBackColor = false;
            this.btnEditUser.Click += new EventHandler(this.btnEditUser_Click);
            this.btnEditUser.MouseEnter += new EventHandler(this.btnEdit_MouseEnter);
            this.btnEditUser.MouseLeave += new EventHandler(this.btnEdit_MouseLeave);

            // btnDeleteUser
            this.btnDeleteUser.BackColor = Color.FromArgb(231, 76, 60);
            this.btnDeleteUser.FlatAppearance.BorderSize = 0;
            this.btnDeleteUser.FlatStyle = FlatStyle.Flat;
            this.btnDeleteUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDeleteUser.ForeColor = Color.White;
            this.btnDeleteUser.Location = new Point(175, 70);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new Size(145, 40);
            this.btnDeleteUser.Text = "🗑️ Delete";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new EventHandler(this.btnDeleteUser_Click);
            this.btnDeleteUser.MouseEnter += new EventHandler(this.btnDelete_MouseEnter);
            this.btnDeleteUser.MouseLeave += new EventHandler(this.btnDelete_MouseLeave);

            // btnResetPassword
            this.btnResetPassword.BackColor = Color.FromArgb(155, 89, 182);
            this.btnResetPassword.FlatAppearance.BorderSize = 0;
            this.btnResetPassword.FlatStyle = FlatStyle.Flat;
            this.btnResetPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnResetPassword.ForeColor = Color.White;
            this.btnResetPassword.Location = new Point(20, 120);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new Size(145, 40);
            this.btnResetPassword.Text = "🔑 Reset Pass";
            this.btnResetPassword.UseVisualStyleBackColor = false;
            this.btnResetPassword.Click += new EventHandler(this.btnResetPassword_Click);
            this.btnResetPassword.MouseEnter += new EventHandler(this.btnReset_MouseEnter);
            this.btnResetPassword.MouseLeave += new EventHandler(this.btnReset_MouseLeave);

            // btnClear
            this.btnClear.BackColor = Color.FromArgb(149, 165, 166);
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClear.ForeColor = Color.White;
            this.btnClear.Location = new Point(175, 120);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(145, 40);
            this.btnClear.Text = "🔄 Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
            this.btnClear.MouseEnter += new EventHandler(this.btnClear_MouseEnter);
            this.btnClear.MouseLeave += new EventHandler(this.btnClear_MouseLeave);

            // picSearch
            this.picSearch.BackColor = Color.White;
            this.picSearch.Location = new Point(50, 345);
            this.picSearch.Name = "picSearch";
            this.picSearch.Size = new Size(20, 20);
            this.picSearch.Paint += new PaintEventHandler(this.picSearch_Paint);

            // txtSearch
            this.txtSearch.BackColor = Color.White;
            this.txtSearch.BorderStyle = BorderStyle.None;
            this.txtSearch.Font = new Font("Segoe UI", 11F);
            this.txtSearch.ForeColor = Color.FromArgb(127, 140, 141);
            this.txtSearch.Location = new Point(80, 343);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new Size(300, 20);
            this.txtSearch.Text = "Search users...";
            this.txtSearch.GotFocus += new EventHandler(this.txtSearch_GotFocus);
            this.txtSearch.LostFocus += new EventHandler(this.txtSearch_LostFocus);
            this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);

            // dgvUsers
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = Color.White;
            this.dgvUsers.BorderStyle = BorderStyle.None;
            this.dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            this.dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.dgvUsers.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            this.dgvUsers.ColumnHeadersHeight = 45;
            this.dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsers.DefaultCellStyle.BackColor = Color.White;
            this.dgvUsers.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            this.dgvUsers.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvUsers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            this.dgvUsers.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvUsers.DefaultCellStyle.Padding = new Padding(8);
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.GridColor = Color.FromArgb(189, 195, 199);
            this.dgvUsers.Location = new Point(30, 380);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowTemplate.Height = 40;
            this.dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new Size(1040, 290);

            // frmStaffManagement
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.ClientSize = new Size(1100, 700);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmStaffManagement";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Staff Management - Botho Clinic";

            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
        }

        // Card shadow and rounded corners
        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundedRectangle(new Rectangle(0, 0, panel.Width - 1, panel.Height - 1), 10))
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                e.Graphics.FillPath(brush, path);
            }
        }

        // Search icon
        private void picSearch_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(Color.FromArgb(149, 165, 166), 2))
            {
                e.Graphics.DrawEllipse(pen, 2, 2, 12, 12);
                e.Graphics.DrawLine(pen, 12, 12, 18, 18);
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

        // Search placeholder behavior
        private void txtSearch_GotFocus(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search users...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.FromArgb(52, 73, 94);
            }
        }

        private void txtSearch_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search users...";
                txtSearch.ForeColor = Color.FromArgb(127, 140, 141);
            }
        }

        // Button hover effects
        private void btnAdd_MouseEnter(object sender, EventArgs e) => btnAddUser.BackColor = Color.FromArgb(39, 174, 96);
        private void btnAdd_MouseLeave(object sender, EventArgs e) => btnAddUser.BackColor = Color.FromArgb(46, 204, 113);

        private void btnEdit_MouseEnter(object sender, EventArgs e) => btnEditUser.BackColor = Color.FromArgb(41, 128, 185);
        private void btnEdit_MouseLeave(object sender, EventArgs e) => btnEditUser.BackColor = Color.FromArgb(52, 152, 219);

        private void btnDelete_MouseEnter(object sender, EventArgs e) => btnDeleteUser.BackColor = Color.FromArgb(192, 57, 43);
        private void btnDelete_MouseLeave(object sender, EventArgs e) => btnDeleteUser.BackColor = Color.FromArgb(231, 76, 60);

        private void btnReset_MouseEnter(object sender, EventArgs e) => btnResetPassword.BackColor = Color.FromArgb(142, 68, 173);
        private void btnReset_MouseLeave(object sender, EventArgs e) => btnResetPassword.BackColor = Color.FromArgb(155, 89, 182);

        private void btnClear_MouseEnter(object sender, EventArgs e) => btnClear.BackColor = Color.FromArgb(127, 140, 141);
        private void btnClear_MouseLeave(object sender, EventArgs e) => btnClear.BackColor = Color.FromArgb(149, 165, 166);

        // Clear button click (add this to your logic file)
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtFullName.Clear();
            txtContactInfo.Clear();
            cmbRole.SelectedIndex = -1;
        }

        // Search text changed (add this to your logic file)
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Implement search filtering here
        }

        // Custom rounded button class
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