using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Botho_Clinic_Management_System
{
    partial class frmUserProfile
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlMain;
        private Panel pnlHeader;
        private Panel pnlContainer;
        private Label lblTitle;
        private Label lblSubtitle;
        private TextBox txtUsername;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private DateTimePicker dtpDateOfBirth;
        private TextBox txtAddress;
        private TextBox txtEmergencyContact;
        private TextBox txtEmergencyPhone;
        private RoundedButton btnSave;
        private RoundedButton btnCancel;
        private Label lblUsername;
        private Label lblFullName;
        private Label lblEmail;
        private Label lblPhone;
        private Label lblDateOfBirth;
        private Label lblAddress;
        private Label lblEmergencyContact;
        private Label lblEmergencyPhone;
        private Panel pnlStudentInfo;
        private TextBox txtStudentID;
        private TextBox txtFaculty;
        private TextBox txtProgram;
        private NumericUpDown numYearOfStudy;
        private Label lblStudentID;
        private Label lblFaculty;
        private Label lblProgram;
        private Label lblYearOfStudy;
        private Panel pnlProviderInfo;
        private TextBox txtStaffNumber;
        private TextBox txtDepartment;
        private TextBox txtPosition;
        private TextBox txtSpecialization;
        private TextBox txtOfficeLocation;
        private Label lblStaffNumber;
        private Label lblDepartment;
        private Label lblPosition;
        private Label lblSpecialization;
        private Label lblOfficeLocation;
        private ComboBox cmbGender;
        private Label lblGender;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new Panel();
            this.pnlContainer = new Panel();
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.pnlProviderInfo = new Panel();
            this.txtOfficeLocation = new TextBox();
            this.lblOfficeLocation = new Label();
            this.txtSpecialization = new TextBox();
            this.lblSpecialization = new Label();
            this.txtPosition = new TextBox();
            this.lblPosition = new Label();
            this.txtDepartment = new TextBox();
            this.lblDepartment = new Label();
            this.txtStaffNumber = new TextBox();
            this.lblStaffNumber = new Label();
            this.pnlStudentInfo = new Panel();
            this.cmbGender = new ComboBox();
            this.lblGender = new Label();
            this.numYearOfStudy = new NumericUpDown();
            this.lblYearOfStudy = new Label();
            this.txtProgram = new TextBox();
            this.lblProgram = new Label();
            this.txtFaculty = new TextBox();
            this.lblFaculty = new Label();
            this.txtStudentID = new TextBox();
            this.lblStudentID = new Label();
            this.btnCancel = new RoundedButton();
            this.btnSave = new RoundedButton();
            this.txtEmergencyPhone = new TextBox();
            this.lblEmergencyPhone = new Label();
            this.txtEmergencyContact = new TextBox();
            this.lblEmergencyContact = new Label();
            this.txtAddress = new TextBox();
            this.lblAddress = new Label();
            this.dtpDateOfBirth = new DateTimePicker();
            this.lblDateOfBirth = new Label();
            this.txtPhone = new TextBox();
            this.lblPhone = new Label();
            this.txtEmail = new TextBox();
            this.lblEmail = new Label();
            this.txtFullName = new TextBox();
            this.lblFullName = new Label();
            this.txtUsername = new TextBox();
            this.lblUsername = new Label();

            this.pnlMain.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlStudentInfo.SuspendLayout();
            this.pnlProviderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYearOfStudy)).BeginInit();
            this.SuspendLayout();

            // Form setup
            this.Text = "User Profile - Botho Clinic";
            this.ClientSize = new Size(550, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(248, 249, 250);

            // Main panel with modern background
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.BackColor = Color.FromArgb(248, 249, 250);
            this.pnlMain.Padding = new Padding(25);

            // Container panel with modern card design
            this.pnlContainer.Size = new Size(500, 700);
            this.pnlContainer.Location = new Point(25, 25);
            this.pnlContainer.BackColor = Color.White;
            this.pnlContainer.Paint += new PaintEventHandler(this.pnlContainer_Paint);

            // Header panel with gradient
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Size = new Size(500, 90);
            this.pnlHeader.BackColor = Color.FromArgb(0, 123, 255);
            this.pnlHeader.Paint += new PaintEventHandler(this.pnlHeader_Paint);

            // Title
            this.lblTitle.Text = "My Profile";
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Size = new Size(500, 40);
            this.lblTitle.Location = new Point(0, 20);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Subtitle
            this.lblSubtitle.Text = "Manage your personal information";
            this.lblSubtitle.Font = new Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = Color.FromArgb(230, 240, 255);
            this.lblSubtitle.Size = new Size(500, 25);
            this.lblSubtitle.Location = new Point(0, 55);
            this.lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;

            // Basic information fields
            int yPos = 110;
            int labelWidth = 140;
            int textBoxWidth = 280;
            int leftMargin = 30;
            int controlLeftMargin = 180;

            // Username (Read-only)
            this.lblUsername.Text = "Username";
            this.lblUsername.Location = new Point(leftMargin, yPos);
            this.lblUsername.Size = new Size(labelWidth, 20);
            this.lblUsername.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblUsername.ForeColor = Color.FromArgb(73, 80, 87);

            this.txtUsername.Location = new Point(controlLeftMargin, yPos);
            this.txtUsername.Size = new Size(textBoxWidth, 25);
            this.txtUsername.Enabled = false;
            this.txtUsername.BackColor = Color.FromArgb(233, 236, 239);
            this.txtUsername.Font = new Font("Segoe UI", 9F);
            this.txtUsername.BorderStyle = BorderStyle.FixedSingle;
            yPos += 35;

            // Full Name
            this.lblFullName.Text = "Full Name";
            this.lblFullName.Location = new Point(leftMargin, yPos);
            this.lblFullName.Size = new Size(labelWidth, 20);
            this.lblFullName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblFullName.ForeColor = Color.FromArgb(73, 80, 87);

            this.txtFullName.Location = new Point(controlLeftMargin, yPos);
            this.txtFullName.Size = new Size(textBoxWidth, 25);
            this.txtFullName.Font = new Font("Segoe UI", 9F);
            this.txtFullName.BorderStyle = BorderStyle.FixedSingle;
            yPos += 35;

            // Email
            this.lblEmail.Text = "Email Address";
            this.lblEmail.Location = new Point(leftMargin, yPos);
            this.lblEmail.Size = new Size(labelWidth, 20);
            this.lblEmail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblEmail.ForeColor = Color.FromArgb(73, 80, 87);

            this.txtEmail.Location = new Point(controlLeftMargin, yPos);
            this.txtEmail.Size = new Size(textBoxWidth, 25);
            this.txtEmail.Font = new Font("Segoe UI", 9F);
            this.txtEmail.BorderStyle = BorderStyle.FixedSingle;
            yPos += 35;

            // Phone
            this.lblPhone.Text = "Phone Number";
            this.lblPhone.Location = new Point(leftMargin, yPos);
            this.lblPhone.Size = new Size(labelWidth, 20);
            this.lblPhone.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblPhone.ForeColor = Color.FromArgb(73, 80, 87);

            this.txtPhone.Location = new Point(controlLeftMargin, yPos);
            this.txtPhone.Size = new Size(textBoxWidth, 25);
            this.txtPhone.Font = new Font("Segoe UI", 9F);
            this.txtPhone.BorderStyle = BorderStyle.FixedSingle;
            yPos += 35;

            // Date of Birth
            this.lblDateOfBirth.Text = "Date of Birth";
            this.lblDateOfBirth.Location = new Point(leftMargin, yPos);
            this.lblDateOfBirth.Size = new Size(labelWidth, 20);
            this.lblDateOfBirth.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblDateOfBirth.ForeColor = Color.FromArgb(73, 80, 87);

            this.dtpDateOfBirth.Location = new Point(controlLeftMargin, yPos);
            this.dtpDateOfBirth.Size = new Size(textBoxWidth, 25);
            this.dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Font = new Font("Segoe UI", 9F);
            yPos += 35;

            // Address
            this.lblAddress.Text = "Address";
            this.lblAddress.Location = new Point(leftMargin, yPos);
            this.lblAddress.Size = new Size(labelWidth, 20);
            this.lblAddress.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblAddress.ForeColor = Color.FromArgb(73, 80, 87);

            this.txtAddress.Location = new Point(controlLeftMargin, yPos);
            this.txtAddress.Size = new Size(textBoxWidth, 50);
            this.txtAddress.Multiline = true;
            this.txtAddress.ScrollBars = ScrollBars.Vertical;
            this.txtAddress.Font = new Font("Segoe UI", 9F);
            this.txtAddress.BorderStyle = BorderStyle.FixedSingle;
            yPos += 60;

            // Emergency Contact
            this.lblEmergencyContact.Text = "Emergency Contact";
            this.lblEmergencyContact.Location = new Point(leftMargin, yPos);
            this.lblEmergencyContact.Size = new Size(labelWidth, 20);
            this.lblEmergencyContact.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblEmergencyContact.ForeColor = Color.FromArgb(73, 80, 87);

            this.txtEmergencyContact.Location = new Point(controlLeftMargin, yPos);
            this.txtEmergencyContact.Size = new Size(textBoxWidth, 25);
            this.txtEmergencyContact.Font = new Font("Segoe UI", 9F);
            this.txtEmergencyContact.BorderStyle = BorderStyle.FixedSingle;
            yPos += 35;

            // Emergency Phone
            this.lblEmergencyPhone.Text = "Emergency Phone";
            this.lblEmergencyPhone.Location = new Point(leftMargin, yPos);
            this.lblEmergencyPhone.Size = new Size(labelWidth, 20);
            this.lblEmergencyPhone.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.lblEmergencyPhone.ForeColor = Color.FromArgb(73, 80, 87);

            this.txtEmergencyPhone.Location = new Point(controlLeftMargin, yPos);
            this.txtEmergencyPhone.Size = new Size(textBoxWidth, 25);
            this.txtEmergencyPhone.Font = new Font("Segoe UI", 9F);
            this.txtEmergencyPhone.BorderStyle = BorderStyle.FixedSingle;
            yPos += 45;

            // Student Information Panel
            this.pnlStudentInfo.Location = new Point(30, yPos);
            this.pnlStudentInfo.Size = new Size(440, 200);
            this.pnlStudentInfo.BackColor = Color.FromArgb(240, 248, 255);
            this.pnlStudentInfo.Visible = false;
            this.pnlStudentInfo.Paint += new PaintEventHandler(this.pnlInfo_Paint);

            int studentY = 15;
            int infoLeftMargin = 15;
            int infoControlLeft = 130;

            // Student ID
            this.lblStudentID.Text = "Student ID";
            this.lblStudentID.Location = new Point(infoLeftMargin, studentY);
            this.lblStudentID.Size = new Size(100, 20);
            this.lblStudentID.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblStudentID.ForeColor = Color.FromArgb(73, 80, 87);

            this.txtStudentID.Location = new Point(infoControlLeft, studentY);
            this.txtStudentID.Size = new Size(290, 25);
            this.txtStudentID.Font = new Font("Segoe UI", 9F);
            this.txtStudentID.BorderStyle = BorderStyle.FixedSingle;
            studentY += 35;

            // Faculty
            this.lblFaculty.Text = "Faculty";
            this.lblFaculty.Location = new Point(infoLeftMargin, studentY);
            this.lblFaculty.Size = new Size(100, 20);
            this.lblFaculty.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblFaculty.ForeColor = Color.FromArgb(73, 80, 87);

            this.txtFaculty.Location = new Point(infoControlLeft, studentY);
            this.txtFaculty.Size = new Size(290, 25);
            this.txtFaculty.Font = new Font("Segoe UI", 9F);
            this.txtFaculty.BorderStyle = BorderStyle.FixedSingle;
            studentY += 35;

            // Program
            this.lblProgram.Text = "Program";
            this.lblProgram.Location = new Point(infoLeftMargin, studentY);
            this.lblProgram.Size = new Size(100, 20);
            this.lblProgram.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblProgram.ForeColor = Color.FromArgb(73, 80, 87);

            this.txtProgram.Location = new Point(infoControlLeft, studentY);
            this.txtProgram.Size = new Size(290, 25);
            this.txtProgram.Font = new Font("Segoe UI", 9F);
            this.txtProgram.BorderStyle = BorderStyle.FixedSingle;
            studentY += 35;

            // Year of Study
            this.lblYearOfStudy.Text = "Year of Study";
            this.lblYearOfStudy.Location = new Point(infoLeftMargin, studentY);
            this.lblYearOfStudy.Size = new Size(100, 20);
            this.lblYearOfStudy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblYearOfStudy.ForeColor = Color.FromArgb(73, 80, 87);

            this.numYearOfStudy.Location = new Point(infoControlLeft, studentY);
            this.numYearOfStudy.Size = new Size(80, 25);
            this.numYearOfStudy.Minimum = 1;
            this.numYearOfStudy.Maximum = 6;
            this.numYearOfStudy.Font = new Font("Segoe UI", 9F);

            // Gender
            this.lblGender.Text = "Gender";
            this.lblGender.Location = new Point(240, studentY);
            this.lblGender.Size = new Size(60, 20);
            this.lblGender.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblGender.ForeColor = Color.FromArgb(73, 80, 87);

            this.cmbGender.Location = new Point(310, studentY);
            this.cmbGender.Size = new Size(110, 25);
            this.cmbGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
            this.cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbGender.Font = new Font("Segoe UI", 9F);

            // Provider Information Panel
            this.pnlProviderInfo.Location = new Point(30, yPos);
            this.pnlProviderInfo.Size = new Size(440, 200);
            this.pnlProviderInfo.BackColor = Color.FromArgb(240, 255, 244);
            this.pnlProviderInfo.Visible = false;
            this.pnlProviderInfo.Paint += new PaintEventHandler(this.pnlInfo_Paint);

            int providerY = 15;

            // Staff Number
            this.lblStaffNumber.Text = "Staff Number";
            this.lblStaffNumber.Location = new Point(infoLeftMargin, providerY);
            this.lblStaffNumber.Size = new Size(100, 20);
            this.lblStaffNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblStaffNumber.ForeColor = Color.FromArgb(73, 80, 87);

            this.txtStaffNumber.Location = new Point(infoControlLeft, providerY);
            this.txtStaffNumber.Size = new Size(290, 25);
            this.txtStaffNumber.Font = new Font("Segoe UI", 9F);
            this.txtStaffNumber.BorderStyle = BorderStyle.FixedSingle;
            providerY += 35;

            // Department
            this.lblDepartment.Text = "Department";
            this.lblDepartment.Location = new Point(infoLeftMargin, providerY);
            this.lblDepartment.Size = new Size(100, 20);
            this.lblDepartment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblDepartment.ForeColor = Color.FromArgb(73, 80, 87);

            this.txtDepartment.Location = new Point(infoControlLeft, providerY);
            this.txtDepartment.Size = new Size(290, 25);
            this.txtDepartment.Font = new Font("Segoe UI", 9F);
            this.txtDepartment.BorderStyle = BorderStyle.FixedSingle;
            providerY += 35;

            // Position
            this.lblPosition.Text = "Position";
            this.lblPosition.Location = new Point(infoLeftMargin, providerY);
            this.lblPosition.Size = new Size(100, 20);
            this.lblPosition.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblPosition.ForeColor = Color.FromArgb(73, 80, 87);

            this.txtPosition.Location = new Point(infoControlLeft, providerY);
            this.txtPosition.Size = new Size(290, 25);
            this.txtPosition.Font = new Font("Segoe UI", 9F);
            this.txtPosition.BorderStyle = BorderStyle.FixedSingle;
            providerY += 35;

            // Specialization
            this.lblSpecialization.Text = "Specialization";
            this.lblSpecialization.Location = new Point(infoLeftMargin, providerY);
            this.lblSpecialization.Size = new Size(100, 20);
            this.lblSpecialization.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblSpecialization.ForeColor = Color.FromArgb(73, 80, 87);

            this.txtSpecialization.Location = new Point(infoControlLeft, providerY);
            this.txtSpecialization.Size = new Size(290, 25);
            this.txtSpecialization.Font = new Font("Segoe UI", 9F);
            this.txtSpecialization.BorderStyle = BorderStyle.FixedSingle;
            providerY += 35;

            // Office Location
            this.lblOfficeLocation.Text = "Office Location";
            this.lblOfficeLocation.Location = new Point(infoLeftMargin, providerY);
            this.lblOfficeLocation.Size = new Size(100, 20);
            this.lblOfficeLocation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblOfficeLocation.ForeColor = Color.FromArgb(73, 80, 87);

            this.txtOfficeLocation.Location = new Point(infoControlLeft, providerY);
            this.txtOfficeLocation.Size = new Size(290, 25);
            this.txtOfficeLocation.Font = new Font("Segoe UI", 9F);
            this.txtOfficeLocation.BorderStyle = BorderStyle.FixedSingle;

            yPos += 210;

            // Buttons
            this.btnSave.Text = "SAVE CHANGES";
            this.btnSave.Size = new Size(180, 45);
            this.btnSave.Location = new Point(90, yPos);
            this.btnSave.BackColor = Color.FromArgb(0, 123, 255);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.btnSave.Cursor = Cursors.Hand;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new EventHandler(this.btnSave_MouseEnter);
            this.btnSave.MouseLeave += new EventHandler(this.btnSave_MouseLeave);

            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Size = new Size(140, 45);
            this.btnCancel.Location = new Point(290, yPos);
            this.btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new EventHandler(this.btnCancel_MouseEnter);
            this.btnCancel.MouseLeave += new EventHandler(this.btnCancel_MouseLeave);

            // Add controls to student panel
            this.pnlStudentInfo.Controls.Add(this.lblStudentID);
            this.pnlStudentInfo.Controls.Add(this.txtStudentID);
            this.pnlStudentInfo.Controls.Add(this.lblFaculty);
            this.pnlStudentInfo.Controls.Add(this.txtFaculty);
            this.pnlStudentInfo.Controls.Add(this.lblProgram);
            this.pnlStudentInfo.Controls.Add(this.txtProgram);
            this.pnlStudentInfo.Controls.Add(this.lblYearOfStudy);
            this.pnlStudentInfo.Controls.Add(this.numYearOfStudy);
            this.pnlStudentInfo.Controls.Add(this.lblGender);
            this.pnlStudentInfo.Controls.Add(this.cmbGender);

            // Add controls to provider panel
            this.pnlProviderInfo.Controls.Add(this.lblStaffNumber);
            this.pnlProviderInfo.Controls.Add(this.txtStaffNumber);
            this.pnlProviderInfo.Controls.Add(this.lblDepartment);
            this.pnlProviderInfo.Controls.Add(this.txtDepartment);
            this.pnlProviderInfo.Controls.Add(this.lblPosition);
            this.pnlProviderInfo.Controls.Add(this.txtPosition);
            this.pnlProviderInfo.Controls.Add(this.lblSpecialization);
            this.pnlProviderInfo.Controls.Add(this.txtSpecialization);
            this.pnlProviderInfo.Controls.Add(this.lblOfficeLocation);
            this.pnlProviderInfo.Controls.Add(this.txtOfficeLocation);

            // Add controls to header
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            // Add controls to container
            this.pnlContainer.Controls.Add(this.pnlHeader);
            this.pnlContainer.Controls.Add(this.lblUsername);
            this.pnlContainer.Controls.Add(this.txtUsername);
            this.pnlContainer.Controls.Add(this.lblFullName);
            this.pnlContainer.Controls.Add(this.txtFullName);
            this.pnlContainer.Controls.Add(this.lblEmail);
            this.pnlContainer.Controls.Add(this.txtEmail);
            this.pnlContainer.Controls.Add(this.lblPhone);
            this.pnlContainer.Controls.Add(this.txtPhone);
            this.pnlContainer.Controls.Add(this.lblDateOfBirth);
            this.pnlContainer.Controls.Add(this.dtpDateOfBirth);
            this.pnlContainer.Controls.Add(this.lblAddress);
            this.pnlContainer.Controls.Add(this.txtAddress);
            this.pnlContainer.Controls.Add(this.lblEmergencyContact);
            this.pnlContainer.Controls.Add(this.txtEmergencyContact);
            this.pnlContainer.Controls.Add(this.lblEmergencyPhone);
            this.pnlContainer.Controls.Add(this.txtEmergencyPhone);
            this.pnlContainer.Controls.Add(this.pnlStudentInfo);
            this.pnlContainer.Controls.Add(this.pnlProviderInfo);
            this.pnlContainer.Controls.Add(this.btnSave);
            this.pnlContainer.Controls.Add(this.btnCancel);

            // Add container to main panel
            this.pnlMain.Controls.Add(this.pnlContainer);

            // Add main panel to form
            this.Controls.Add(this.pnlMain);

            this.pnlMain.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlStudentInfo.ResumeLayout(false);
            this.pnlStudentInfo.PerformLayout();
            this.pnlProviderInfo.ResumeLayout(false);
            this.pnlProviderInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYearOfStudy)).EndInit();
            this.ResumeLayout(false);
        }

        // Header gradient
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

        // Info panel with rounded border
        private void pnlInfo_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundedRectangle(
                new Rectangle(0, 0, panel.Width - 1, panel.Height - 1), 8))
            {
                // Fill background
                using (SolidBrush brush = new SolidBrush(panel.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Draw border
                Color borderColor = panel.BackColor == Color.FromArgb(240, 248, 255)
                    ? Color.FromArgb(0, 123, 255)
                    : Color.FromArgb(40, 167, 69);

                using (Pen pen = new Pen(borderColor, 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
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
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.FromArgb(0, 105, 217);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.FromArgb(0, 123, 255);
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(90, 98, 104);
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(108, 117, 125);
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