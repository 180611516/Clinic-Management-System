using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Botho_Clinic_Management_System
{
    public partial class frmRegistration : Form
    {
        // Connection string 
        private string connectionString = "server=localhost;user=root;database=Botho_Clinic_Management_System;password=;";
        public frmRegistration()
        {
            InitializeComponent();
        }

        // Hash password using SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string contact = txtContact.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString();

            // Input validation
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string defaultPassword = "ChangeMe123"; // default password for new users
            string passwordHash = HashPassword(defaultPassword);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Insert into Users table
                    string insertUserQuery = @"INSERT INTO Users (username, password_hash, full_name, contact_info, role)
                                               VALUES (@username, @password_hash, @full_name, @contact_info, @role);
                                               SELECT LAST_INSERT_ID();";

                    MySqlCommand cmd = new MySqlCommand(insertUserQuery, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password_hash", passwordHash);
                    cmd.Parameters.AddWithValue("@full_name", fullName);
                    cmd.Parameters.AddWithValue("@contact_info", contact);
                    cmd.Parameters.AddWithValue("@role", role);

                    int userId = Convert.ToInt32(cmd.ExecuteScalar());

                    // Insert into Students or Providers table if needed
                    if (role == "Student")
                    {
                        string insertStudent = @"INSERT INTO Students (user_id) VALUES (@user_id)";
                        MySqlCommand cmdStudent = new MySqlCommand(insertStudent, conn);
                        cmdStudent.Parameters.AddWithValue("@user_id", userId);
                        cmdStudent.ExecuteNonQuery();
                    }
                    else if (role == "Provider")
                    {
                        string insertProvider = @"INSERT INTO Providers (user_id) VALUES (@user_id)";
                        MySqlCommand cmdProvider = new MySqlCommand(insertProvider, conn);
                        cmdProvider.Parameters.AddWithValue("@user_id", userId);
                        cmdProvider.ExecuteNonQuery();
                    }

                    MessageBox.Show($"User registered successfully!\nDefault password: {defaultPassword}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear inputs
                    txtFullName.Clear();
                    txtUsername.Clear();
                    txtContact.Clear();
                    cmbRole.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
