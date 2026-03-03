using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Botho_Clinic_Management_System
{
    public partial class frmForgotPassword : Form
    {
        private readonly string _connStr = "server=localhost;user=root;password=;database=botho_clinic_management_system;";

        public frmForgotPassword()
        {
            InitializeComponent();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Clear previous errors
            lblError.Text = "";

            // Validation
            if (string.IsNullOrEmpty(username))
            {
                ShowError("Please enter your username.");
                return;
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                ShowError("Please enter a new password.");
                return;
            }

            if (newPassword.Length < 6)
            {
                ShowError("Password must be at least 6 characters long.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                ShowError("Passwords do not match.");
                return;
            }

            try
            {
                // Reset the password
                if (ResetUserPassword(username, newPassword))
                {
                    MessageBox.Show("Password reset successfully! You can now login with your new password.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowError("Username not found or password reset failed.");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error resetting password: {ex.Message}");
            }
        }

        private bool ResetUserPassword(string username, string newPassword)
        {
            using (MySqlConnection conn = new MySqlConnection(_connStr))
            {
                conn.Open();

                // First, verify the user exists
                string checkUserQuery = "SELECT user_id FROM users WHERE username = @username AND is_active = 1";
                int userId = 0;

                using (MySqlCommand checkCmd = new MySqlCommand(checkUserQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@username", username);
                    var result = checkCmd.ExecuteScalar();

                    if (result == null)
                    {
                        return false; // User not found
                    }
                    userId = Convert.ToInt32(result);
                }

                // Hash the new password
                string hashedPassword = HashPassword(newPassword);

                // Update the password and reset the must_change_password flag
                string updateQuery = @"UPDATE users 
                                     SET password_hash = @passwordHash, 
                                         must_change_password = 0,
                                         last_updated = CURRENT_TIMESTAMP
                                     WHERE user_id = @userId";

                using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@passwordHash", hashedPassword);
                    updateCmd.Parameters.AddWithValue("@userId", userId);

                    int rowsAffected = updateCmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.ForeColor = Color.FromArgb(220, 53, 69);
        }

        private void ShowSuccess(string message)
        {
            lblError.Text = message;
            lblError.ForeColor = Color.FromArgb(40, 167, 69);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtNewPassword.Focus();
                e.Handled = true;
            }
        }

        private void txtNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtConfirmPassword.Focus();
                e.Handled = true;
            }
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnResetPassword_Click(sender, e);
                e.Handled = true;
            }
        }

        // Paint events for styling
        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.pnlMain.ClientRectangle,
                Color.FromArgb(240, 248, 255),
                Color.FromArgb(255, 255, 255),
                LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, this.pnlMain.ClientRectangle);
            }
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int shadowDepth = 4;
            int borderRadius = 20;

            // Shadow effect
            for (int i = 0; i < shadowDepth; i++)
            {
                Rectangle shadowRect = new Rectangle(i, i, panel.Width - 1, panel.Height - 1);
                using (GraphicsPath path = CreateRoundedRectangle(shadowRect, borderRadius))
                using (Pen shadowPen = new Pen(Color.FromArgb(15, 0, 0, 0)))
                {
                    e.Graphics.DrawPath(shadowPen, path);
                }
            }

            // Main container
            Rectangle mainRect = new Rectangle(0, 0, panel.Width - shadowDepth, panel.Height - shadowDepth);
            using (GraphicsPath path = CreateRoundedRectangle(mainRect, borderRadius))
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                e.Graphics.FillPath(brush, path);
            }

            // Border
            using (GraphicsPath path = CreateRoundedRectangle(mainRect, borderRadius))
            using (Pen borderPen = new Pen(Color.FromArgb(230, 230, 230), 1))
            {
                e.Graphics.DrawPath(borderPen, path);
            }
        }

        private GraphicsPath CreateRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}