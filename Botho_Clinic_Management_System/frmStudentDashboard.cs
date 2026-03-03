using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;

namespace Botho_Clinic_Management_System
{
    public partial class frmStudentDashboard : Form
    {
        private int _userId; 
        private readonly string _connStr = "server=localhost;user=root;database=botho_clinic_management_system;password=;";

        public frmStudentDashboard(int userId)
        {
            InitializeComponent();
            _userId = userId;

            LoadStudentWelcome();
        }

        private void LoadStudentWelcome()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "SELECT full_name FROM students WHERE student_id = @studentId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", _userId);
                        object result = cmd.ExecuteScalar();
                        string studentName = result?.ToString() ?? "Student";

                        lblWelcome.Text = $"Welcome, {studentName}";
                        this.Text = $"Student Dashboard - {studentName}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading student name: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- BOOK APPOINTMENT ---
        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            try
            {
                pnlMain.Controls.Clear();
                frmBookAppointment bookForm = new frmBookAppointment(_userId) 
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                pnlMain.Controls.Add(bookForm);
                bookForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening appointment booking: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- APPOINTMENT HISTORY ---
        private void btnAppointmentHistory_Click(object sender, EventArgs e)
        {
            try
            {
                pnlMain.Controls.Clear();
                frmAppointmentHistory historyForm = new frmAppointmentHistory(_userId) 
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                pnlMain.Controls.Add(historyForm);
                historyForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening appointment history: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- REMINDERS ---
        private void btnReminders_Click(object sender, EventArgs e)
        {
            try
            {
                // DEBUG: Show what ID we're using
                MessageBox.Show($"Opening reminders for Student ID: {_userId}", "Debug Info");

                frmStudentReminders remindersForm = new frmStudentReminders(_userId);
                remindersForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening reminders: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- PROFILE ---
        private void btnProfile_Click(object sender, EventArgs e)
        {
            try
            {
                frmUserProfile profileForm = new frmUserProfile(_userId, "Student");
                profileForm.ShowDialog();
                LoadStudentWelcome();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening profile: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- LOGOUT ---
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                this.Hide();
                new frmLogin().Show();
                this.Close();
            }
        }

        // --- FORM LOAD ---
        private void frmStudentDashboard_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, MMM dd, yyyy  •  hh:mm tt");
        }

        // --- TIMER TICK ---
        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, MMM dd, yyyy  •  hh:mm tt");
        }

        // --- BUTTON HOVER EFFECTS ---
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is RoundedButton button && button != btnLogout)
            {
                button.BackColor = ControlPaint.Light(button.BackColor, 0.2f);
            }
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is RoundedButton button)
            {
                if (button == btnBookAppointment)
                    button.BackColor = Color.FromArgb(52, 152, 219);
                else if (button == btnAppointmentHistory || button == btnReminders)
                    button.BackColor = Color.FromArgb(52, 73, 94);
                else if (button == btnProfile)
                    button.BackColor = Color.FromArgb(155, 89, 182);
            }
        }

        private void btnLogout_MouseEnter(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(231, 76, 60);
        }

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(192, 57, 43);
        }
    }
}