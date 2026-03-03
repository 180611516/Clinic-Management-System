using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Botho_Clinic_Management_System
{
    public partial class frmReminders : Form
    {
        private readonly int _providerId;
        private readonly int? _studentId; 
        private readonly string _connStr = "server=localhost;user=root;database=botho_clinic_management_system;password=;";

        // Constructor
        public frmReminders(int providerId, int? studentId = null)
        {
            InitializeComponent();
            _providerId = providerId;
            _studentId = studentId;

            dgvReminders.AllowUserToAddRows = false;
            dgvReminders.ReadOnly = true;
            dgvReminders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Load students into dropdown and reminders
            LoadStudents();
            LoadReminders();
        }

        // Load students into the dropdown
        private void LoadStudents()
        {
            try
            {
                cmbStudent.Items.Clear();

                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();

                    string query = @"SELECT student_id, student_number, full_name 
                                     FROM students 
                                     ORDER BY full_name";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string studentId = reader["student_id"].ToString();
                                string studentNumber = reader["student_number"].ToString();
                                string fullName = reader["full_name"].ToString();

                                // Add to dropdown with display text and value
                                cmbStudent.Items.Add(new StudentItem(
                                    Convert.ToInt32(studentId),
                                    $"{studentNumber} - {fullName}"
                                ));
                            }
                        }
                    }
                }

                // Select the first item if available
                if (cmbStudent.Items.Count > 0)
                {
                    cmbStudent.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load reminders from database
        private void LoadReminders()
        {
            dgvReminders.Rows.Clear();
            dgvReminders.Columns.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();

                    string query = @"SELECT r.reminder_id, s.student_number, s.full_name, r.message, r.date_sent 
                                     FROM reminders r
                                     JOIN students s ON s.student_id = r.student_id
                                     WHERE r.provider_id = @providerId
                                     " + (_studentId.HasValue ? "AND r.student_id = @studentId" : "") + @"
                                     ORDER BY r.date_sent DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@providerId", _providerId);
                        if (_studentId.HasValue)
                            cmd.Parameters.AddWithValue("@studentId", _studentId.Value);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Add columns if they don't exist
                            if (dgvReminders.Columns.Count == 0)
                            {
                                dgvReminders.Columns.Add("reminder_id", "Reminder ID");
                                dgvReminders.Columns.Add("student_number", "Student Number");
                                dgvReminders.Columns.Add("student_name", "Student Name");
                                dgvReminders.Columns.Add("message", "Message");
                                dgvReminders.Columns.Add("date_sent", "Date Sent");
                            }

                            while (reader.Read())
                            {
                                dgvReminders.Rows.Add(
                                    reader["reminder_id"].ToString(),
                                    reader["student_number"].ToString(),
                                    reader["full_name"].ToString(),
                                    reader["message"].ToString(),
                                    Convert.ToDateTime(reader["date_sent"]).ToString("yyyy-MM-dd HH:mm")
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reminders: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Get selected student ID from dropdown
        private int? GetSelectedStudentId()
        {
            if (cmbStudent.SelectedItem is StudentItem studentItem)
            {
                return studentItem.Id;
            }
            return null;
        }

        // Add new reminder
        private void btnAddReminder_Click(object sender, EventArgs e)
        {
            var selectedStudentId = GetSelectedStudentId();

            if (!selectedStudentId.HasValue)
            {
                MessageBox.Show("Please select a student before adding a reminder.", "Missing Student",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Please enter a reminder message.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpReminderDate.Value < DateTime.Today)
            {
                MessageBox.Show("Reminder date cannot be in the past.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();

                    string query = @"INSERT INTO reminders (provider_id, student_id, message, reminder_date, date_sent)
                                     VALUES (@providerId, @studentId, @message, @reminderDate, NOW())";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@providerId", _providerId);
                        cmd.Parameters.AddWithValue("@studentId", selectedStudentId.Value);
                        cmd.Parameters.AddWithValue("@message", txtMessage.Text.Trim());
                        cmd.Parameters.AddWithValue("@reminderDate", dtpReminderDate.Value);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Reminder added successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMessage.Clear();
                            dtpReminderDate.Value = DateTime.Now; // Reset to current date
                            LoadReminders();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding reminder: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Refresh button
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStudents();
            LoadReminders();
        }

        // Helper class to store student ID and display text
        private class StudentItem
        {
            public int Id { get; set; }
            public string DisplayText { get; set; }

            public StudentItem(int id, string displayText)
            {
                Id = id;
                DisplayText = displayText;
            }

            public override string ToString()
            {
                return DisplayText;
            }
        }
    }
}