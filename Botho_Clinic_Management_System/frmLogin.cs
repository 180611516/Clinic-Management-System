using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Botho_Clinic_Management_System
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validate username
            if (string.IsNullOrEmpty(username))
            {
                lblError.Text = "Please enter your username.";
                txtUsername.Focus();
                return;
            }

            // Validate password
            if (string.IsNullOrEmpty(password))
            {
                lblError.Text = "Please enter your password.";
                txtPassword.Focus();
                return;
            }

            try
            {
                UserSync.SyncUserIds();

                string connStr = "server=localhost;user=root;database=botho_clinic_management_system;password=;";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = "SELECT user_id, password_hash, role, must_change_password " +
                                   "FROM Users WHERE username = @username AND is_active = 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHash = reader.GetString("password_hash").Trim();
                                string role = reader.GetString("role").Trim();
                                int userId = reader.GetInt32("user_id");
                                bool mustChangePassword = reader.GetBoolean("must_change_password");

                                if (VerifyPassword(password, storedHash))
                                {
                                    this.Hide();

                                    if (mustChangePassword)
                                    {
                                        new frmChangePassword(userId).Show();
                                        return;
                                    }

                                    switch (role)
                                    {
                                        case "Admin":
                                            new frmAdminDashboard(userId).Show();
                                            break;
                                        case "Provider":
                                            new frmProviderDashboard(userId).Show();
                                            break;
                                        case "Student":
                                            new frmStudentDashboard(userId).Show();
                                            break;
                                        default:
                                            lblError.Text = "Unknown role assigned.";
                                            this.Show();
                                            break;
                                    }
                                }
                                else
                                {
                                    lblError.Text = "Incorrect password.";
                                    txtPassword.Focus();
                                    txtPassword.SelectAll();
                                }
                            }
                            else
                            {
                                lblError.Text = "User not found or inactive.";
                                txtUsername.Focus();
                                txtUsername.SelectAll();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Database error: " + ex.Message;
            }
        }

        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(inputPassword);
                byte[] hash = sha256.ComputeHash(bytes);
                string hashString = BitConverter.ToString(hash).Replace("-", "").ToLower();
                return hashString == storedHash.ToLower();
            }
        }

        // Add this handler to frmLogin.cs (place it near other event handlers)
        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var forgot = new frmForgotPassword())
            {
                forgot.StartPosition = FormStartPosition.CenterParent;
                forgot.ShowDialog(this);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                lblError.Text = "";
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            // Clear error when user starts typing in password
            if (!string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                lblError.Text = "";
            }
        }

        // Optional: Handle Enter key press to trigger login
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}