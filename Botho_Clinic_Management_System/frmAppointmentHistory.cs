using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Botho_Clinic_Management_System
{
    public partial class frmAppointmentHistory : Form
    {
        private int _studentId;
        private int _userId;
        private string _connectionString = "server=localhost;database=botho_clinic_management_system;uid=root;pwd=;";

        // Constructor accepts user_id and converts it to student_id
        public frmAppointmentHistory(int userId)
        {
            InitializeComponent();
            _userId = userId;
            _studentId = GetStudentIdFromUserId(userId);

            if (_studentId <= 0)
            {
                MessageBox.Show($"No student record found for user ID {userId}. Please contact administrator.",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // Get the actual student_id from the students table using user_id
        private int GetStudentIdFromUserId(int userId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT student_id FROM students WHERE user_id = @userId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting student information: " + ex.Message,
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void frmAppointmentHistory_Load(object sender, EventArgs e)
        {
            if (_studentId > 0)
            {
                LoadAppointments();
            }
        }

        private void LoadAppointments()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            a.appointment_id AS 'Appointment ID',
                            a.appointment_date AS 'Date',
                            a.appointment_time AS 'Time',
                            u.username AS 'Provider',
                            a.reason AS 'Reason',
                            a.status AS 'Status',
                            a.created_at AS 'Created At'
                        FROM appointments a
                        INNER JOIN providers p ON a.provider_id = p.provider_id
                        INNER JOIN users u ON p.user_id = u.user_id
                        WHERE a.student_id = @studentId
                        ORDER BY a.appointment_date DESC, a.appointment_time DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", _studentId);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("You have no appointment history yet.",
                                          "No Appointments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        dgvAppointments.DataSource = dt;

                        // Set column widths
                        dgvAppointments.Columns["Appointment ID"].Width = 120;
                        dgvAppointments.Columns["Date"].Width = 100;
                        dgvAppointments.Columns["Time"].Width = 80;
                        dgvAppointments.Columns["Provider"].Width = 150;
                        dgvAppointments.Columns["Reason"].Width = 200;
                        dgvAppointments.Columns["Status"].Width = 100;
                        dgvAppointments.Columns["Created At"].Width = 130;

                        // Optional: Format the date and time columns
                        dgvAppointments.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd";
                        dgvAppointments.Columns["Time"].DefaultCellStyle.Format = "hh\\:mm";
                        dgvAppointments.Columns["Created At"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}