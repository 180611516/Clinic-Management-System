using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Botho_Clinic_Management_System
{
    public partial class frmStudentReminders : Form
    {
        private readonly int _userId; 
        private readonly string _connStr = "server=localhost;user=root;database=botho_clinic_management_system;password=;";

        public frmStudentReminders(int userId)
        {
            InitializeComponent();
            _userId = userId;

            // Setup DataGridView
            dgvReminders.AllowUserToAddRows = false;
            dgvReminders.ReadOnly = true;
            dgvReminders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReminders.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvReminders_CellDoubleClick);

            LoadStudentReminders();
            UpdateStats();
        }

        private void LoadStudentReminders()
        {
            dgvReminders.Rows.Clear();
            dgvReminders.Columns.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();

                    // First check if user exists and show debug info
                    string debugQuery = "SELECT full_name FROM students WHERE user_id = @userId";
                    using (MySqlCommand debugCmd = new MySqlCommand(debugQuery, conn))
                    {
                        debugCmd.Parameters.AddWithValue("@userId", _userId);
                        object studentName = debugCmd.ExecuteScalar();
                        MessageBox.Show($"DEBUG: Loading reminders for User ID: {_userId}, Name: {studentName ?? "Unknown"}", "Debug Info");
                    }

                    // Check reminder count
                    string countQuery = "SELECT COUNT(*) FROM reminders WHERE user_id = @userId";
                    using (MySqlCommand countCmd = new MySqlCommand(countQuery, conn))
                    {
                        countCmd.Parameters.AddWithValue("@userId", _userId);
                        int count = Convert.ToInt32(countCmd.ExecuteScalar());
                        MessageBox.Show($"DEBUG: Found {count} reminders for user ID {_userId}", "Debug Info");

                        if (count == 0)
                        {
                            MessageBox.Show("You have no reminders at this time.", "No Reminders",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // Main query to load reminders - changed student_id to user_id
                    string query = @"SELECT 
                                        r.reminder_id,
                                        r.message,
                                        r.reminder_date,
                                        r.date_sent,
                                        COALESCE(p.full_name, 'Unknown Provider') as provider_name,
                                        r.status,
                                        r.is_read,
                                        CASE 
                                            WHEN DATE(r.reminder_date) < CURDATE() THEN 'Overdue'
                                            WHEN DATE(r.reminder_date) = CURDATE() THEN 'Today'
                                            ELSE 'Upcoming'
                                        END as due_status
                                     FROM reminders r
                                     LEFT JOIN providers p ON r.provider_id = p.provider_id
                                     WHERE r.user_id = @userId
                                     ORDER BY r.reminder_date DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", _userId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Add columns
                            dgvReminders.Columns.Add("due_status", "Status");
                            dgvReminders.Columns.Add("message", "Message");
                            dgvReminders.Columns.Add("reminder_date", "Due Date");
                            dgvReminders.Columns.Add("date_sent", "Sent On");
                            dgvReminders.Columns.Add("provider_name", "From Provider");
                            dgvReminders.Columns.Add("status", "Completion");
                            dgvReminders.Columns.Add("is_read", "Read");
                            dgvReminders.Columns.Add("reminder_id", "Reminder ID");

                            // Hide technical columns
                            dgvReminders.Columns["reminder_id"].Visible = false;
                            dgvReminders.Columns["is_read"].Visible = false;

                            int loadedCount = 0;
                            while (reader.Read())
                            {
                                loadedCount++;

                                // Safe conversion for is_read
                                bool isRead = false;
                                object isReadValue = reader["is_read"];
                                if (isReadValue != DBNull.Value)
                                {
                                    isRead = Convert.ToInt32(isReadValue) == 1;
                                }

                                int rowIndex = dgvReminders.Rows.Add(
                                    reader["due_status"].ToString(),
                                    reader["message"].ToString(),
                                    Convert.ToDateTime(reader["reminder_date"]).ToString("yyyy-MM-dd HH:mm"),
                                    Convert.ToDateTime(reader["date_sent"]).ToString("yyyy-MM-dd HH:mm"),
                                    reader["provider_name"].ToString(),
                                    reader["status"].ToString(),
                                    isRead.ToString(),
                                    reader["reminder_id"].ToString()
                                );

                                // Color code based on due status and read state
                                Color rowColor = GetRowColor(reader["due_status"].ToString(), isRead);
                                dgvReminders.Rows[rowIndex].DefaultCellStyle.BackColor = rowColor;
                            }

                            MessageBox.Show($"Successfully loaded {loadedCount} reminders", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                UpdateStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reminders: {ex.Message}\n\nUser ID: {_userId}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStats()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();

                    string query = @"SELECT 
                                        COUNT(*) as total_reminders,
                                        COALESCE(SUM(CASE WHEN is_read = 0 THEN 1 ELSE 0 END), 0) as unread_reminders,
                                        COALESCE(SUM(CASE WHEN DATE(reminder_date) < CURDATE() THEN 1 ELSE 0 END), 0) as overdue_reminders,
                                        COALESCE(SUM(CASE WHEN DATE(reminder_date) = CURDATE() THEN 1 ELSE 0 END), 0) as today_reminders
                                     FROM reminders 
                                     WHERE user_id = @userId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", _userId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int total = SafeConvertToInt(reader["total_reminders"]);
                                int unread = SafeConvertToInt(reader["unread_reminders"]);
                                int overdue = SafeConvertToInt(reader["overdue_reminders"]);
                                int today = SafeConvertToInt(reader["today_reminders"]);

                                // Update labels
                                lblTotalReminders.Text = $"📋 Total: {total}";
                                lblUnreadReminders.Text = $"📬 Unread: {unread}";

                                if (lblOverdueReminders != null)
                                    lblOverdueReminders.Text = $"⚠️ Overdue: {overdue}";

                                if (lblTodayReminders != null)
                                    lblTodayReminders.Text = $"📅 Today: {today}";

                                // Visual indicators
                                if (unread > 0)
                                {
                                    lblUnreadReminders.ForeColor = Color.FromArgb(220, 53, 69);
                                    lblUnreadReminders.Font = new Font(lblUnreadReminders.Font, FontStyle.Bold);
                                }
                                else
                                {
                                    lblUnreadReminders.ForeColor = Color.White;
                                    lblUnreadReminders.Font = new Font(lblUnreadReminders.Font, FontStyle.Regular);
                                }
                            }
                            else
                            {
                                SetDefaultStats();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading statistics: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetDefaultStats();
            }
        }

        private int SafeConvertToInt(object dbValue)
        {
            if (dbValue == null || dbValue == DBNull.Value)
                return 0;

            try
            {
                return Convert.ToInt32(dbValue);
            }
            catch
            {
                return 0;
            }
        }

        private void SetDefaultStats()
        {
            lblTotalReminders.Text = "📋 Total: 0";
            lblUnreadReminders.Text = "📬 Unread: 0";

            if (lblOverdueReminders != null)
                lblOverdueReminders.Text = "⚠️ Overdue: 0";

            if (lblTodayReminders != null)
                lblTodayReminders.Text = "📅 Today: 0";

            // Reset colors
            lblUnreadReminders.ForeColor = Color.White;
            lblUnreadReminders.Font = new Font(lblUnreadReminders.Font, FontStyle.Regular);
        }

        private Color GetRowColor(string dueStatus, bool isRead)
        {
            if (isRead)
            {
                // Read reminders - lighter colors
                switch (dueStatus)
                {
                    case "Overdue":
                        return Color.FromArgb(255, 230, 230);
                    case "Today":
                        return Color.FromArgb(230, 255, 230);
                    case "Upcoming":
                        return Color.FromArgb(230, 240, 255);
                    default:
                        return Color.White;
                }
            }
            else
            {
                // Unread reminders - brighter colors
                switch (dueStatus)
                {
                    case "Overdue":
                        return Color.FromArgb(255, 200, 200);
                    case "Today":
                        return Color.FromArgb(200, 255, 200);
                    case "Upcoming":
                        return Color.FromArgb(200, 220, 255);
                    default:
                        return Color.White;
                }
            }
        }

        private void dgvReminders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvReminders.Rows.Count)
            {
                string reminderId = dgvReminders.Rows[e.RowIndex].Cells["reminder_id"].Value.ToString();
                string isRead = dgvReminders.Rows[e.RowIndex].Cells["is_read"].Value.ToString();

                if (isRead == "False")
                {
                    MarkAsRead(Convert.ToInt32(reminderId));

                    string status = dgvReminders.Rows[e.RowIndex].Cells["due_status"].Value.ToString();
                    dgvReminders.Rows[e.RowIndex].DefaultCellStyle.BackColor = GetRowColor(status, true);
                    dgvReminders.Rows[e.RowIndex].Cells["is_read"].Value = "True";

                    UpdateStats();

                    MessageBox.Show("Reminder marked as read.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("This reminder has already been read.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void MarkAsRead(int reminderId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    // Changed student_id to user_id
                    string query = "UPDATE reminders SET is_read = 1 WHERE reminder_id = @reminderId AND user_id = @userId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@reminderId", reminderId);
                        cmd.Parameters.AddWithValue("@userId", _userId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error marking as read: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MarkAllAsRead()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    // Changed student_id to user_id
                    string query = "UPDATE reminders SET is_read = 1 WHERE user_id = @userId AND is_read = 0";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", _userId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"{rowsAffected} reminders marked as read.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadStudentReminders();
                        }
                        else
                        {
                            MessageBox.Show("No unread reminders to mark as read.", "Info",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error marking all as read: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStudentReminders();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMarkAllRead_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Mark all unread reminders as read?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MarkAllAsRead();
            }
        }
    }
}