using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Botho_Clinic_Management_System
{
    public partial class frmDailyAppointments : Form
    {
        private int _providerId;
        private string _connStr = "server=localhost;database=botho_clinic_management_system;uid=root;pwd=;";

        public frmDailyAppointments(int providerId)
        {
            InitializeComponent();
            _providerId = providerId;
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            dgvAppointments.Columns.Clear();
            dgvAppointments.Rows.Clear();

            using (var conn = new MySqlConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT a.appointment_id, u.username AS patient_name, a.appointment_date, a.appointment_time, a.status
                        FROM appointments a
                        JOIN users u ON a.student_id = u.user_id
                        WHERE a.provider_id = @providerId
                        ORDER BY a.appointment_date, a.appointment_time";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@providerId", _providerId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            dgvAppointments.Columns.Add("appointment_id", "ID");
                            dgvAppointments.Columns.Add("patient_name", "Patient");
                            dgvAppointments.Columns.Add("appointment_date", "Date");
                            dgvAppointments.Columns.Add("appointment_time", "Time");
                            dgvAppointments.Columns.Add("status", "Status");
                            dgvAppointments.Columns.Add(new DataGridViewButtonColumn()
                            {
                                HeaderText = "Update Status",
                                Text = "Mark Completed",
                                UseColumnTextForButtonValue = true
                            });

                            while (reader.Read())
                            {
                                dgvAppointments.Rows.Add(
                                    reader.GetInt32("appointment_id"),
                                    reader.GetString("patient_name"),
                                    reader.GetDateTime("appointment_date").ToString("yyyy-MM-dd"),
                                    reader.GetTimeSpan("appointment_time").ToString(@"hh\:mm"),
                                    reader.GetString("status")
                                );
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading appointments: " + ex.Message);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void dgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If click is on the "Update Status" button column
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvAppointments.Columns["Update Status"].Index)
            {
                int appointmentId = Convert.ToInt32(dgvAppointments.Rows[e.RowIndex].Cells["appointment_id"].Value);
                UpdateAppointmentStatus(appointmentId);
            }
        }

        private void UpdateAppointmentStatus(int appointmentId)
        {
            using (var conn = new MySqlConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE appointments SET status = 'Completed' WHERE appointment_id = @id";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", appointmentId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Appointment marked as completed.");
                    LoadAppointments();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating status: " + ex.Message);
                }
            }
        }
    }
}
