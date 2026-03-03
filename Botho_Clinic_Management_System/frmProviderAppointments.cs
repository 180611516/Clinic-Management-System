using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Botho_Clinic_Management_System
{
    public partial class frmProviderAppointments : Form
    {
        private int _providerId;
        private int _userId;
        private readonly string _connStr = "server=localhost;user=root;password=;database=botho_clinic_management_system;";

        // Constructor accepts user_id
        public frmProviderAppointments(int userId)
        {
            InitializeComponent();
            _userId = userId;

            // Sync user IDs before loading
            UserSync.SyncUserIds();

            _providerId = GetProviderIdFromUserId(_userId);

            if (_providerId <= 0)
            {
                MessageBox.Show(
                    $"⚠️ No provider record found for user ID {_userId}. Please contact the administrator.",
                    "Provider Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                // Close safely after initialization
                this.Load += (s, e) => this.Close();
                return;
            }

            this.Text = $"Provider Appointments (Provider ID: {_providerId})";
            LoadAppointments();
        }

        // Get provider_id from user_id
        private int GetProviderIdFromUserId(int userId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "SELECT provider_id FROM providers WHERE user_id = @userId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        object result = cmd.ExecuteScalar();
                        return (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting provider information: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        // Load all appointments for this provider
        private void LoadAppointments()
        {
            if (_providerId <= 0) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            a.appointment_id AS 'ID',
                            s.full_name AS 'Student Name',
                            DATE_FORMAT(a.appointment_date, '%Y-%m-%d') AS 'Date',
                            TIME_FORMAT(a.appointment_time, '%H:%i') AS 'Time',
                            a.reason AS 'Reason',
                            COALESCE(a.status, 'Pending') AS 'Status'
                        FROM appointments a
                        INNER JOIN students s ON a.student_id = s.student_id
                        WHERE a.provider_id = @providerId
                        ORDER BY a.appointment_date DESC, a.appointment_time DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@providerId", _providerId);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            dgvProviderAppointments.DataSource = dt;

                            if (dgvProviderAppointments.Columns["ID"] != null)
                                dgvProviderAppointments.Columns["ID"].Visible = false;

                            lblHeader.Text = $"📅 Provider Appointments ({dt.Rows.Count} total)";
                            ColorCodeAppointments();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointments: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Color-code appointments by status
        private void ColorCodeAppointments()
        {
            foreach (DataGridViewRow row in dgvProviderAppointments.Rows)
            {
                if (row.Cells["Status"].Value == null) continue;
                string status = row.Cells["Status"].Value.ToString().ToLower();

                switch (status)
                {
                    case "approved":
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        break;
                    case "rejected":
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        break;
                    case "pending":
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                        break;
                }
            }
        }

        // Approve selected appointment
        private void btnApprove_Click(object sender, EventArgs e)
        {
            UpdateSelectedAppointmentStatus("Approved");
        }

        // Reject selected appointment
        private void btnReject_Click(object sender, EventArgs e)
        {
            UpdateSelectedAppointmentStatus("Rejected");
        }

        // Refresh appointments
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAppointments();
            MessageBox.Show("Appointments refreshed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Update appointment status helper
        private void UpdateSelectedAppointmentStatus(string newStatus)
        {
            if (dgvProviderAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show($"Please select an appointment to {newStatus.ToLower()}.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int appointmentId = Convert.ToInt32(dgvProviderAppointments.SelectedRows[0].Cells["ID"].Value);
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "UPDATE appointments SET status = @status WHERE appointment_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@id", appointmentId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Appointment has been {newStatus.ToLower()} successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAppointments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
