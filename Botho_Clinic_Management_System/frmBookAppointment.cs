using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Botho_Clinic_Management_System
{
    public partial class frmBookAppointment : Form
    {
        private int _studentId;
        private int _userId; 
        private readonly string _connStr = "server=localhost;user=root;password=;database=botho_clinic_management_system;";

        // Constructor accepts user_id and gets the actual student_id
        public frmBookAppointment(int userId)
        {
            InitializeComponent();
            _userId = userId;
            _studentId = GetStudentIdFromUserId(userId);

            if (_studentId <= 0)
            {
                MessageBox.Show($"No student record found for user ID {userId}. Please contact administrator.",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            LoadAvailableProviders();
        }

        // Get the actual student_id from the students table using user_id
        private int GetStudentIdFromUserId(int userId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
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

        // Load providers into ComboBox
        private void LoadAvailableProviders()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    // JOIN providers table to get the correct provider_id
                    string query = @"SELECT p.provider_id, u.username 
                                    FROM providers p 
                                    INNER JOIN users u ON p.user_id = u.user_id 
                                    WHERE u.role = 'Provider'";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbProvider.DisplayMember = "username";
                    cmbProvider.ValueMember = "provider_id"; 
                    cmbProvider.DataSource = dt;
                    cmbProvider.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading providers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            LoadTimeSlots();
        }

        private void cmbProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTimeSlots();
        }

        // Load available time slots (9am–4pm) for the selected provider and date
        private void LoadTimeSlots()
        {
            lstTimeSlots.Items.Clear();
            if (cmbProvider.SelectedIndex == -1) return;

            DateTime selectedDate = monthCalendar1.SelectionStart.Date;
            int providerId = Convert.ToInt32(cmbProvider.SelectedValue);

            for (int hour = 9; hour <= 16; hour++)
            {
                TimeSpan slot = new TimeSpan(hour, 0, 0);
                if (!IsSlotBooked(providerId, selectedDate, slot))
                    lstTimeSlots.Items.Add(slot.ToString(@"hh\:mm"));
            }
        }

        private bool IsSlotBooked(int providerId, DateTime date, TimeSpan time)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = @"
                        SELECT COUNT(*) 
                        FROM appointments 
                        WHERE provider_id = @providerId 
                          AND appointment_date = @date 
                          AND appointment_time = @time";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@providerId", providerId);
                    cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@time", time);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                // Log the error for debugging
                MessageBox.Show("Error checking slot availability: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Treat as booked if error occurs
            }
        }

        // Book appointment
        private void btnBook_Click(object sender, EventArgs e)
        {
            if (_studentId <= 0)
            {
                MessageBox.Show("Invalid student ID. Cannot book appointment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbProvider.SelectedIndex == -1 || lstTimeSlots.SelectedItem == null)
            {
                MessageBox.Show("Please select a provider and a time slot.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime selectedDate = monthCalendar1.SelectionStart.Date;
            TimeSpan selectedTime = TimeSpan.Parse(lstTimeSlots.SelectedItem.ToString());
            int providerId = Convert.ToInt32(cmbProvider.SelectedValue);
            string reason = txtReason.Text.Trim();

            if (string.IsNullOrEmpty(reason))
            {
                MessageBox.Show("Please enter a reason for the appointment.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();

                    string query = @"
                        INSERT INTO appointments(student_id, provider_id, appointment_date, appointment_time, reason)
                        VALUES(@studentId, @providerId, @date, @time, @reason)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@studentId", _studentId);
                    cmd.Parameters.AddWithValue("@providerId", providerId);
                    cmd.Parameters.AddWithValue("@date", selectedDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@time", selectedTime);
                    cmd.Parameters.AddWithValue("@reason", reason);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Appointment booked successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadTimeSlots(); // refresh available slots
                    txtReason.Clear(); // Clear the reason field
                }
            }
            catch (MySqlException ex) when (ex.Number == 1452) // foreign key violation
            {
                MessageBox.Show("Cannot book appointment: student or provider does not exist.\n\n" +
                               $"Student ID: {_studentId}\nProvider ID: {providerId}\nUser ID: {_userId}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error booking appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}