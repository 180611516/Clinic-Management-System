using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Botho_Clinic_Management_System
{
    public partial class frmAppointments : Form
    {
        private readonly string _connStr = "server=localhost;user=root;database=botho_clinic_management_system;password=;";
        private int _providerId;

        public frmAppointments(int providerId)
        {
            InitializeComponent();
            _providerId = providerId;

            LoadStudents();
            LoadAppointments();
        }

        // Load students into ComboBox
        private void LoadStudents()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "SELECT student_id, student_number FROM students ORDER BY student_number";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    cmbStudents.Items.Clear();
                    while (reader.Read())
                    {
                        // Use anonymous object instead of ComboBoxItem to avoid conflicts
                        cmbStudents.Items.Add(new
                        {
                            Id = reader.GetInt32("student_id"),
                            Name = reader.GetString("student_number")
                        });
                    }

                    if (cmbStudents.Items.Count > 0)
                        cmbStudents.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Get selected student ID from ComboBox
        private int GetSelectedStudentId()
        {
            if (cmbStudents.SelectedItem == null)
                return -1;

            // Use dynamic to extract Id property from anonymous object
            dynamic selected = cmbStudents.SelectedItem;
            return selected.Id;
        }

        // Load appointments for this provider
        private void LoadAppointments()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = @"SELECT appointment_id, student_id, provider_id, appointment_date, appointment_time, reason, status
                                     FROM appointments
                                     WHERE provider_id = @providerId
                                     ORDER BY appointment_date DESC, appointment_time DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@providerId", _providerId);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvAppointments.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add new appointment
        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            int studentId = GetSelectedStudentId();
            if (studentId == -1)
            {
                MessageBox.Show("Please select a student.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string insertQuery = @"INSERT INTO appointments 
                                           (student_id, provider_id, appointment_date, appointment_time, reason, status, created_at)
                                           VALUES (@studentId, @providerId, CURDATE(), CURTIME(), 'General Checkup', 'Scheduled', NOW())";

                    MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    cmd.Parameters.AddWithValue("@providerId", _providerId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("New appointment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAppointments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Open consultation for selected appointment
        private void btnOpenConsultation_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count > 0)
            {
                int appointmentId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["appointment_id"].Value);
                frmConsultation frm = new frmConsultation(appointmentId);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an appointment first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Refresh appointments manually
        private void btnLoadAppointments_Click(object sender, EventArgs e)
        {
            LoadAppointments();
        }
    }
}
