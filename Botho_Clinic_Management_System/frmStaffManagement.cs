using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Botho_Clinic_Management_System
{
    public partial class frmStaffManagement : Form
    {
        private readonly string _connStr = "server=localhost;user=root;password=;database=botho_clinic_management_system;";

        public frmStaffManagement()
        {
            InitializeComponent();
            LoadUsers();
        }

        // Helper function to hash passwords (SHA256)
        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        //  Load users into DataGridView
        private void LoadUsers()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "SELECT user_id, username, full_name, contact_info, role, is_active, must_change_password FROM users";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUsers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add new user (with hashed password)
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string fullname = txtFullName.Text.Trim();
            string contact = txtContactInfo.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill in all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string defaultPassword = "ChangeMe123!";
            string hashedPassword = HashPassword(defaultPassword);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    MySqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        //  Insert into users table
                        string insertUser = @"INSERT INTO users (username, full_name, contact_info, role, password_hash, is_active, must_change_password)
                                              VALUES (@username, @fullname, @contact, @role, @password_hash, 1, 1)";
                        long userId;

                        using (MySqlCommand cmd = new MySqlCommand(insertUser, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@fullname", fullname);
                            cmd.Parameters.AddWithValue("@contact", contact);
                            cmd.Parameters.AddWithValue("@role", role);
                            cmd.Parameters.AddWithValue("@password_hash", hashedPassword);
                            cmd.ExecuteNonQuery();
                            userId = cmd.LastInsertedId;
                        }

                        //  Insert into role-specific table
                        switch (role.ToLower())
                        {
                            case "admin":
                                InsertIntoRoleTable(conn, transaction, "administrators", userId, username, fullname);
                                break;
                            case "provider":
                                InsertIntoRoleTable(conn, transaction, "providers", userId, username, fullname);
                                break;
                            case "student":
                                InsertIntoRoleTable(conn, transaction, "students", userId, username, fullname);
                                break;
                        }

                        transaction.Commit();
                        MessageBox.Show($"User added successfully!\nDefault password: {defaultPassword}\nUser must change it on first login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error adding user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Insert into role-specific table
        private void InsertIntoRoleTable(MySqlConnection conn, MySqlTransaction transaction, string tableName, long userId, string username, string fullName)
        {
            string query = $"INSERT INTO {tableName} (user_id, username, full_name) VALUES (@user_id, @username, @full_name)";
            using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@full_name", fullName);
                cmd.ExecuteNonQuery();
            }
        }

        //  Edit selected user
        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["user_id"].Value);
            string fullname = txtFullName.Text.Trim();
            string contact = txtContactInfo.Text.Trim();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    MySqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string roleQuery = "SELECT role FROM users WHERE user_id=@id";
                        string role;
                        using (MySqlCommand cmdRole = new MySqlCommand(roleQuery, conn, transaction))
                        {
                            cmdRole.Parameters.AddWithValue("@id", userId);
                            role = cmdRole.ExecuteScalar()?.ToString();
                        }

                        //  Update user table
                        string updateUser = "UPDATE users SET full_name=@fullname, contact_info=@contact WHERE user_id=@id";
                        using (MySqlCommand cmd = new MySqlCommand(updateUser, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@fullname", fullname);
                            cmd.Parameters.AddWithValue("@contact", contact);
                            cmd.Parameters.AddWithValue("@id", userId);
                            cmd.ExecuteNonQuery();
                        }

                        // Update matching role table
                        if (!string.IsNullOrEmpty(role))
                        {
                            string tableName = role.ToLower() == "provider" ? "providers"
                                : role.ToLower() == "student" ? "students"
                                : role.ToLower() == "admin" ? "administrators" : null;

                            if (tableName != null)
                                UpdateRoleTable(conn, transaction, tableName, userId, fullname);
                        }

                        transaction.Commit();
                        MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error updating user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateRoleTable(MySqlConnection conn, MySqlTransaction transaction, string tableName, int userId, string fullName)
        {
            string query = $"UPDATE {tableName} SET full_name=@full_name WHERE user_id=@user_id";
            using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@full_name", fullName);
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.ExecuteNonQuery();
            }
        }

        //  Delete user
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["user_id"].Value);

            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(_connStr))
                    {
                        conn.Open();
                        MySqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            string roleQuery = "SELECT role FROM users WHERE user_id=@id";
                            string role;
                            using (MySqlCommand cmdRole = new MySqlCommand(roleQuery, conn, transaction))
                            {
                                cmdRole.Parameters.AddWithValue("@id", userId);
                                role = cmdRole.ExecuteScalar()?.ToString();
                            }

                            // Delete from role-specific table
                            if (!string.IsNullOrEmpty(role))
                            {
                                string tableName = role.ToLower() == "provider" ? "providers"
                                    : role.ToLower() == "student" ? "students"
                                    : role.ToLower() == "admin" ? "administrators" : null;

                                if (tableName != null)
                                {
                                    string deleteRole = $"DELETE FROM {tableName} WHERE user_id=@id";
                                    using (MySqlCommand cmd = new MySqlCommand(deleteRole, conn, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@id", userId);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            // Delete from users table
                            string deleteUser = "DELETE FROM users WHERE user_id=@id";
                            using (MySqlCommand cmd = new MySqlCommand(deleteUser, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", userId);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUsers();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error deleting user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //  Reset password securely (hashed)
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["user_id"].Value);
            string defaultPassword = "ChangeMe123!";
            string hashedPassword = HashPassword(defaultPassword);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string resetQuery = "UPDATE users SET password_hash=@pass, must_change_password=1 WHERE user_id=@id";
                    using (MySqlCommand cmd = new MySqlCommand(resetQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@pass", hashedPassword);
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show($"Password reset to default: {defaultPassword}\nUser must change on next login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error resetting password: " + ex.Message);
            }
        }
    }
}
