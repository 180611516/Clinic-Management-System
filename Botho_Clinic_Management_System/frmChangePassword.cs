using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Botho_Clinic_Management_System
{
    public partial class frmChangePassword : Form
    {
        private int _userId; // Logged-in user's ID

        public frmChangePassword(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                lblError.Text = "All fields are required.";
                return;
            }

            if (newPassword != confirmPassword)
            {
                lblError.Text = "New password and confirmation do not match.";
                return;
            }

            try
            {
                string connStr = "server=localhost;user=root;database=Botho_Clinic_Management_System;password=;";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // 1️⃣ Verify current password
                    string getPasswordQuery = "SELECT password_hash FROM Users WHERE user_id = @userId";
                    using (MySqlCommand cmd = new MySqlCommand(getPasswordQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", _userId);
                        string storedHash = cmd.ExecuteScalar().ToString();

                        if (!VerifyPassword(currentPassword, storedHash))
                        {
                            lblError.Text = "Current password is incorrect.";
                            return;
                        }
                    }

                    // 2️⃣ Update with new hashed password
                    string newHash = ComputeSha256Hash(newPassword);
                    string updateQuery = "UPDATE Users SET password_hash = @newHash, must_change_password = 0 WHERE user_id = @userId";
                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@newHash", newHash);
                        cmd.Parameters.AddWithValue("@userId", _userId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            lblError.Text = "Error updating password.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Database error: " + ex.Message;
            }
        }

        // SHA-256 verification
        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            string hash = ComputeSha256Hash(inputPassword);
            return hash == storedHash.Trim().ToLower();
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(rawData);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
