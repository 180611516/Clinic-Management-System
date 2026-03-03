using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Botho_Clinic_Management_System
{
    public partial class frmUserProfile : Form
    {
        private int userId;
        private string userRole;

        public frmUserProfile(int userId, string userRole)
        {
            this.userId = userId;
            this.userRole = userRole;
            InitializeComponent();

            // Show role-specific panels
            pnlStudentInfo.Visible = (userRole == "Student");
            pnlProviderInfo.Visible = (userRole == "Provider");

            if (userRole == "Student")
            {
                this.Height += 180;
            }
            else if (userRole == "Provider")
            {
                this.Height += 140;
            }

            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            try
            {
                string connStr = "server=localhost;user=root;database=botho_clinic_management_system;password=;";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // Load basic user information
                    string userQuery = @"SELECT u.username, u.full_name, u.email, u.phone_number, 
                                        u.date_of_birth, u.address, u.emergency_contact_name, 
                                        u.emergency_contact_phone
                                        FROM users u 
                                        WHERE u.user_id = @userId";

                    using (MySqlCommand cmd = new MySqlCommand(userQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Basic information
                                txtUsername.Text = reader["username"].ToString();
                                txtFullName.Text = reader["full_name"].ToString();
                                txtEmail.Text = reader["email"] != DBNull.Value ? reader["email"].ToString() : "";
                                txtPhone.Text = reader["phone_number"] != DBNull.Value ? reader["phone_number"].ToString() : "";

                                if (reader["date_of_birth"] != DBNull.Value)
                                {
                                    dtpDateOfBirth.Value = Convert.ToDateTime(reader["date_of_birth"]);
                                }

                                txtAddress.Text = reader["address"] != DBNull.Value ? reader["address"].ToString() : "";
                                txtEmergencyContact.Text = reader["emergency_contact_name"] != DBNull.Value ? reader["emergency_contact_name"].ToString() : "";
                                txtEmergencyPhone.Text = reader["emergency_contact_phone"] != DBNull.Value ? reader["emergency_contact_phone"].ToString() : "";
                            }
                        }
                    }

                    // Load role-specific information
                    if (userRole == "Student")
                    {
                        LoadStudentInfo(conn);
                    }
                    else if (userRole == "Provider")
                    {
                        LoadProviderInfo(conn);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStudentInfo(MySqlConnection conn)
        {
            string studentQuery = @"SELECT student_number, faculty, program, year_of_study, gender
                                  FROM student_details 
                                  WHERE user_id = @userId";

            using (MySqlCommand cmd = new MySqlCommand(studentQuery, conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtStudentID.Text = reader["student_number"] != DBNull.Value ? reader["student_number"].ToString() : "";
                        txtFaculty.Text = reader["faculty"] != DBNull.Value ? reader["faculty"].ToString() : "";
                        txtProgram.Text = reader["program"] != DBNull.Value ? reader["program"].ToString() : "";

                        if (reader["year_of_study"] != DBNull.Value)
                        {
                            numYearOfStudy.Value = Convert.ToInt32(reader["year_of_study"]);
                        }

                        if (reader["gender"] != DBNull.Value)
                        {
                            cmbGender.Text = reader["gender"].ToString();
                        }
                    }
                }
            }
        }

        private void LoadProviderInfo(MySqlConnection conn)
        {
            string providerQuery = @"SELECT staff_number, department, position, specialization, office_location
                                   FROM provider_details 
                                   WHERE user_id = @userId";

            using (MySqlCommand cmd = new MySqlCommand(providerQuery, conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtStaffNumber.Text = reader["staff_number"] != DBNull.Value ? reader["staff_number"].ToString() : "";
                        txtDepartment.Text = reader["department"] != DBNull.Value ? reader["department"].ToString() : "";
                        txtPosition.Text = reader["position"] != DBNull.Value ? reader["position"].ToString() : "";
                        txtSpecialization.Text = reader["specialization"] != DBNull.Value ? reader["specialization"].ToString() : "";
                        txtOfficeLocation.Text = reader["office_location"] != DBNull.Value ? reader["office_location"].ToString() : "";
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                string connStr = "server=localhost;user=root;database=botho_clinic_management_system;password=;";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // Update Users table
                    string userQuery = @"UPDATE users 
                                       SET full_name = @fullName, email = @email, 
                                           phone_number = @phone, date_of_birth = @dob,
                                           address = @address, emergency_contact_name = @emergencyName,
                                           emergency_contact_phone = @emergencyPhone,
                                           last_updated = CURRENT_TIMESTAMP
                                       WHERE user_id = @userId";

                    using (MySqlCommand cmd = new MySqlCommand(userQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@fullName", txtFullName.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@dob", dtpDateOfBirth.Value);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@emergencyName", txtEmergencyContact.Text.Trim());
                        cmd.Parameters.AddWithValue("@emergencyPhone", txtEmergencyPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@userId", userId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Update role-specific information
                            if (userRole == "Student")
                            {
                                UpdateStudentInfo(conn);
                            }
                            else if (userRole == "Provider")
                            {
                                UpdateProviderInfo(conn);
                            }

                            MessageBox.Show("Profile updated successfully!", "Success",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile: " + ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStudentInfo(MySqlConnection conn)
        {
            string studentQuery = @"INSERT INTO student_details (user_id, student_number, faculty, program, year_of_study, gender)
                                  VALUES (@userId, @studentNumber, @faculty, @program, @yearOfStudy, @gender)
                                  ON DUPLICATE KEY UPDATE
                                  student_number = @studentNumber, faculty = @faculty, 
                                  program = @program, year_of_study = @yearOfStudy, gender = @gender";

            using (MySqlCommand cmd = new MySqlCommand(studentQuery, conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@studentNumber", txtStudentID.Text.Trim());
                cmd.Parameters.AddWithValue("@faculty", txtFaculty.Text.Trim());
                cmd.Parameters.AddWithValue("@program", txtProgram.Text.Trim());
                cmd.Parameters.AddWithValue("@yearOfStudy", numYearOfStudy.Value);
                cmd.Parameters.AddWithValue("@gender", cmbGender.Text);

                cmd.ExecuteNonQuery();
            }
        }

        private void UpdateProviderInfo(MySqlConnection conn)
        {
            string providerQuery = @"INSERT INTO provider_details (user_id, staff_number, department, position, specialization, office_location)
                                   VALUES (@userId, @staffNumber, @department, @position, @specialization, @officeLocation)
                                   ON DUPLICATE KEY UPDATE
                                   staff_number = @staffNumber, department = @department, 
                                   position = @position, specialization = @specialization, 
                                   office_location = @officeLocation";

            using (MySqlCommand cmd = new MySqlCommand(providerQuery, conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@staffNumber", txtStaffNumber.Text.Trim());
                cmd.Parameters.AddWithValue("@department", txtDepartment.Text.Trim());
                cmd.Parameters.AddWithValue("@position", txtPosition.Text.Trim());
                cmd.Parameters.AddWithValue("@specialization", txtSpecialization.Text.Trim());
                cmd.Parameters.AddWithValue("@officeLocation", txtOfficeLocation.Text.Trim());

                cmd.ExecuteNonQuery();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please enter your full name.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter your email address.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}