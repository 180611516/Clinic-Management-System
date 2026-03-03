using System;
using System.Drawing;
using System.Windows.Forms;

namespace Botho_Clinic_Management_System
{
    partial class frmChangePassword
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblCurrent;
        private Label lblNew;
        private Label lblConfirm;
        private TextBox txtCurrentPassword;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private Button btnSave;
        private Label lblError;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCurrent = new Label();
            this.lblNew = new Label();
            this.lblConfirm = new Label();
            this.txtCurrentPassword = new TextBox();
            this.txtNewPassword = new TextBox();
            this.txtConfirmPassword = new TextBox();
            this.btnSave = new Button();
            this.lblError = new Label();
            this.SuspendLayout();

            Font labelFont = new Font("Segoe UI", 10F);
            Font inputFont = new Font("Segoe UI", 10F);
            Font buttonFont = new Font("Segoe UI", 10F, FontStyle.Bold);

            // lblCurrent
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Font = labelFont;
            this.lblCurrent.Location = new Point(30, 30);
            this.lblCurrent.Text = "Current Password:";

            // txtCurrentPassword
            this.txtCurrentPassword.Font = inputFont;
            this.txtCurrentPassword.Location = new Point(180, 27);
            this.txtCurrentPassword.Size = new Size(200, 25);
            this.txtCurrentPassword.UseSystemPasswordChar = true;

            // lblNew
            this.lblNew.AutoSize = true;
            this.lblNew.Font = labelFont;
            this.lblNew.Location = new Point(30, 70);
            this.lblNew.Text = "New Password:";

            // txtNewPassword
            this.txtNewPassword.Font = inputFont;
            this.txtNewPassword.Location = new Point(180, 67);
            this.txtNewPassword.Size = new Size(200, 25);
            this.txtNewPassword.UseSystemPasswordChar = true;

            // lblConfirm
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Font = labelFont;
            this.lblConfirm.Location = new Point(30, 110);
            this.lblConfirm.Text = "Confirm Password:";

            // txtConfirmPassword
            this.txtConfirmPassword.Font = inputFont;
            this.txtConfirmPassword.Location = new Point(180, 107);
            this.txtConfirmPassword.Size = new Size(200, 25);
            this.txtConfirmPassword.UseSystemPasswordChar = true;

            // btnSave
            this.btnSave.Font = buttonFont;
            this.btnSave.BackColor = Color.MediumSeaGreen;
            this.btnSave.ForeColor = Color.White;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Location = new Point(180, 150);
            this.btnSave.Size = new Size(200, 35);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // lblError
            this.lblError.AutoSize = true;
            this.lblError.Font = labelFont;
            this.lblError.ForeColor = Color.Red;
            this.lblError.Location = new Point(30, 200);
            this.lblError.Size = new Size(350, 20);
            this.lblError.Text = "";

            // frmChangePassword
            this.ClientSize = new Size(420, 250);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.txtCurrentPassword);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblError);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Name = "frmChangePassword";
            this.Text = "Change Password";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
