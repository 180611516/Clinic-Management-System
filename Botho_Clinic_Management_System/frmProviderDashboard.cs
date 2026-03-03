using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Botho_Clinic_Management_System
{
    public partial class frmProviderDashboard : Form
    {
        private int _providerId;
        private int _userId;
        private readonly string _connStr = "server=localhost;user=root;password=;database=botho_clinic_management_system;";

        public frmProviderDashboard(int userId)
        {
            InitializeComponent();
            _userId = userId;

            _providerId = GetProviderIdFromUserId(userId);

            if (_providerId <= 0)
            {
                MessageBox.Show($"No provider record found for user ID {userId}. Please contact administrator.",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            LoadTodaysAppointments();
            LoadDashboardStats();

            // Attach click events to stat cards
            pnlCard1.Click += pnlCard1_Click;
            pnlCard2.Click += pnlCard2_Click;
            pnlCard3.Click += pnlCard3_Click;
            pnlCard4.Click += pnlCard4_Click;
        }

        private int GetProviderIdFromUserId(int userId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "SELECT provider_id, full_name FROM providers WHERE user_id = @userId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int providerId = Convert.ToInt32(reader["provider_id"]);
                                string fullName = reader["full_name"]?.ToString() ?? "Provider";

                                // Update welcome label with provider's name
                                lblWelcome.Text = $"👋 Welcome, {fullName}";
                                this.Text = $"Provider Dashboard - {fullName}";
                                return providerId;
                            }
                        }
                    }
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting provider info: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void LoadTodaysAppointments()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            a.appointment_id AS 'ID',
                            COALESCE(s.full_name, 'N/A') AS 'Patient Name',
                            DATE_FORMAT(a.appointment_date, '%Y-%m-%d') AS 'Date',
                            TIME_FORMAT(a.appointment_time, '%H:%i') AS 'Time',
                            COALESCE(a.reason, 'No reason provided') AS 'Reason',
                            COALESCE(a.status, 'Pending') AS 'Status'
                        FROM appointments a
                        LEFT JOIN students s ON a.student_id = s.student_id
                        WHERE a.provider_id = @providerId
                        ORDER BY a.appointment_date DESC, a.appointment_time ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@providerId", _providerId);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvAppointments.DataSource = dt;

                            if (dgvAppointments.Columns["ID"] != null)
                                dgvAppointments.Columns["ID"].Visible = false;

                            dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointments: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDashboardStats()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = @"
                        SELECT
                            COUNT(*) AS totalAppointments,
                            SUM(CASE WHEN DATE(appointment_date) = CURDATE() THEN 1 ELSE 0 END) AS todayAppointments,
                            SUM(CASE WHEN DATE(appointment_date) = CURDATE() AND status = 'Completed' THEN 1 ELSE 0 END) AS completedToday,
                            SUM(CASE WHEN status = 'Pending' THEN 1 ELSE 0 END) AS pendingAppointments
                        FROM appointments
                        WHERE provider_id = @providerId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@providerId", _providerId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblCard1Value.Text = reader["todayAppointments"] != DBNull.Value ? reader["todayAppointments"].ToString() : "0";
                                lblCard2Value.Text = reader["completedToday"] != DBNull.Value ? reader["completedToday"].ToString() : "0";
                                lblCard3Value.Text = reader["pendingAppointments"] != DBNull.Value ? reader["pendingAppointments"].ToString() : "0";
                                lblCard4Value.Text = reader["totalAppointments"] != DBNull.Value ? reader["totalAppointments"].ToString() : "0";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading statistics: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            frmProviderAppointments appointmentsForm = new frmProviderAppointments(_providerId);
            appointmentsForm.ShowDialog();
            LoadTodaysAppointments();
            LoadDashboardStats();
        }

        private void btnConsultations_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an appointment first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int appointmentId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["ID"].Value);
            frmConsultation consultationForm = new frmConsultation(appointmentId);
            consultationForm.ShowDialog();
            LoadTodaysAppointments();
            LoadDashboardStats();
        }

        private void btnPrescriptions_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an appointment first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int appointmentId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["ID"].Value);
            frmPrescription prescriptionForm = new frmPrescription(appointmentId);
            prescriptionForm.ShowDialog();
            LoadTodaysAppointments();
            LoadDashboardStats();
        }

        private void btnReminders_Click(object sender, EventArgs e)
        {
            OpenRemindersForm();
        }

        private void btnUserProfile_Click(object sender, EventArgs e)
        {
            OpenUserProfile();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Log out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                new frmLogin().Show();
            }
        }

        private void dgvAppointments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int appointmentId = Convert.ToInt32(dgvAppointments.Rows[e.RowIndex].Cells["ID"].Value);
                frmConsultation consultationForm = new frmConsultation(appointmentId);
                consultationForm.ShowDialog();
                LoadTodaysAppointments();
                LoadDashboardStats();
            }
        }

        private void OpenRemindersForm()
        {
            try
            {
                // Pass providerId and null for studentId (since provider is managing reminders)
                frmReminders remindersForm = new frmReminders(_providerId, null);
                remindersForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening reminders: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenUserProfile()
        {
            try
            {
                // Create profile form with userId and role
                frmUserProfile profileForm = new frmUserProfile(_userId, "Provider");

                // Show as dialog
                profileForm.ShowDialog();

                // Refresh dashboard data in case profile was updated
                RefreshDashboardData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening profile: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Refresh Dashboard Data
        private void RefreshDashboardData()
        {
            try
            {
                // Refresh provider name in case it was updated
                string providerName = GetProviderName(_userId);
                if (!string.IsNullOrEmpty(providerName))
                {
                    lblWelcome.Text = $"👋 Welcome, {providerName}";
                    this.Text = $"Provider Dashboard - {providerName}";
                }

                // Refresh appointments and stats
                LoadTodaysAppointments();
                LoadDashboardStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing dashboard: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Get Provider Name
        private string GetProviderName(int userId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "SELECT full_name FROM providers WHERE user_id = @userId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        object result = cmd.ExecuteScalar();
                        return result?.ToString() ?? "Provider";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting provider name: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Provider";
            }
        }

        // Event handler for stat card clicks
        private void pnlCard1_Click(object sender, EventArgs e)
        {
            // Show today's appointments when card is clicked
            btnAppointments_Click(sender, e);
        }

        private void pnlCard2_Click(object sender, EventArgs e)
        {
            // Filter to show completed appointments
            MessageBox.Show("Showing completed appointments...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pnlCard3_Click(object sender, EventArgs e)
        {
            // Filter to show pending appointments
            MessageBox.Show("Showing pending appointments...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pnlCard4_Click(object sender, EventArgs e)
        {
            // Show all appointments
            MessageBox.Show("Showing all appointments...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}