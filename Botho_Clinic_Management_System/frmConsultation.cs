using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Botho_Clinic_Management_System
{
    public partial class frmConsultation : Form
    {
        private int _appointmentId;
        private int _studentId; // Store student_id for the patient
        private readonly string _connStr = "server=localhost;user=root;password=;database=botho_clinic_management_system;";

        public frmConsultation(int appointmentId)
        {
            InitializeComponent();
            _appointmentId = appointmentId;
            LoadAppointmentDetails();
            LoadMedicalHistory();
            LoadMedications();
        }

        private void LoadAppointmentDetails()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            a.appointment_date,
                            a.appointment_time, 
                            s.full_name AS Patient,
                            s.student_id
                        FROM appointments a
                        INNER JOIN students s ON a.student_id = s.student_id
                        INNER JOIN users u ON s.user_id = u.user_id
                        WHERE a.appointment_id = @appointmentId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@appointmentId", _appointmentId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            _studentId = Convert.ToInt32(reader["student_id"]);
                            lblPatientName.Text = "Patient: " + reader["Patient"].ToString();

                            DateTime appointmentDate = Convert.ToDateTime(reader["appointment_date"]);
                            TimeSpan appointmentTime = (TimeSpan)reader["appointment_time"];

                            lblAppointmentTime.Text = $"Appointment: {appointmentDate:yyyy-MM-dd} at {appointmentTime:hh\\:mm}";
                        }
                        else
                        {
                            MessageBox.Show("Appointment not found!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Load += (s, e) => this.Close();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointment: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMedicalHistory()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            DATE_FORMAT(c.recorded_at, '%Y-%m-%d %H:%i') AS 'Date',
                            c.diagnosis AS 'Diagnosis',
                            c.notes AS 'Notes',
                            c.vitals AS 'Vitals'
                        FROM consultations c
                        INNER JOIN appointments a ON c.appointment_id = a.appointment_id
                        WHERE a.student_id = @studentId
                        ORDER BY c.recorded_at DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@studentId", _studentId);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvMedicalHistory.DataSource = dt;
                    dgvMedicalHistory.ReadOnly = true;
                    dgvMedicalHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // If no history, show message
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No previous medical history found for this patient.",
                            "Medical History", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading medical history: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMedications()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();

                    // Check if medications table exists
                    string checkTable = @"
                        SELECT COUNT(*) 
                        FROM information_schema.tables 
                        WHERE table_schema = 'botho_clinic_management_system' 
                        AND table_name = 'medications'";

                    MySqlCommand checkCmd = new MySqlCommand(checkTable, conn);
                    int tableExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (tableExists > 0)
                    {
                        // Load from database
                        string query = "SELECT medication_id, medication_name FROM medications ORDER BY medication_name";
                        MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cmbMedications.DataSource = dt;
                        cmbMedications.DisplayMember = "medication_name";
                        cmbMedications.ValueMember = "medication_id";
                    }
                    else
                    {
                        // Load hardcoded medications list
                        LoadHardcodedMedications();
                    }
                }
            }
            catch (Exception ex)
            {
                // If error, fall back to hardcoded list
                MessageBox.Show("Medications table not found. Loading default medications.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHardcodedMedications();
            }
        }

        private void LoadHardcodedMedications()
        {
            var medications = new[]
            {
                "Paracetamol (500mg)",
                "Ibuprofen (400mg)",
                "Amoxicillin (250mg)",
                "Omeprazole (20mg)",
                "Cetirizine (10mg)",
                "Aspirin (100mg)",
                "Metformin (500mg)",
                "Atorvastatin (10mg)",
                "Loratadine (10mg)",
                "Vitamin D (1000IU)"
            };

            cmbMedications.Items.Clear();
            cmbMedications.Items.AddRange(medications);
            cmbMedications.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void btnAddPrescription_Click(object sender, EventArgs e)
        {
            string medName = cmbMedications.Text;
            string dosage = txtDosage.Text.Trim();
            string quantity = txtQuantity.Text.Trim();

            if (string.IsNullOrEmpty(medName))
            {
                MessageBox.Show("Please select a medication.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(dosage))
            {
                MessageBox.Show("Please enter dosage (e.g., '1 tablet twice daily').",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(quantity))
            {
                MessageBox.Show("Please enter quantity (e.g., '30 tablets').",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvPrescriptions.Rows.Add(medName, dosage, quantity);
            txtDosage.Clear();
            txtQuantity.Clear();
            cmbMedications.Text = "";
        }

        private void btnSaveConsultation_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtNotes.Text) && string.IsNullOrWhiteSpace(txtDiagnosis.Text))
            {
                MessageBox.Show("Please enter at least notes or diagnosis.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();

                    // Combine vitals into one field (as per your schema)
                    string vitalsData = $"Temp: {txtTemperature.Text}, BP: {txtBloodPressure.Text}, " +
                                       $"Weight: {txtWeight.Text}, Pulse: {txtPulse.Text}";

                    // Save consultation details (matching your actual table structure)
                    string insertConsultation = @"
                        INSERT INTO consultations (appointment_id, vitals, notes, diagnosis, recorded_at)
                        VALUES (@appointmentId, @vitals, @notes, @diagnosis, NOW())";

                    MySqlCommand cmd = new MySqlCommand(insertConsultation, conn);
                    cmd.Parameters.AddWithValue("@appointmentId", _appointmentId);
                    cmd.Parameters.AddWithValue("@vitals", vitalsData);
                    cmd.Parameters.AddWithValue("@notes", txtNotes.Text);
                    cmd.Parameters.AddWithValue("@diagnosis", txtDiagnosis.Text);
                    cmd.ExecuteNonQuery();

                    long consultationId = cmd.LastInsertedId;

                    // Save prescriptions (matching your actual table structure)
                    foreach (DataGridViewRow row in dgvPrescriptions.Rows)
                    {
                        if (!row.IsNewRow && row.Cells[0].Value != null)
                        {
                            string insertPrescription = @"
                                INSERT INTO prescriptions (consultation_id, medication_name, dosage, instructions)
                                VALUES (@consultationId, @medName, @dosage, @instructions)";

                            MySqlCommand presCmd = new MySqlCommand(insertPrescription, conn);
                            presCmd.Parameters.AddWithValue("@consultationId", consultationId);
                            presCmd.Parameters.AddWithValue("@medName", row.Cells[0].Value?.ToString());
                            presCmd.Parameters.AddWithValue("@dosage", row.Cells[1].Value?.ToString());
                            presCmd.Parameters.AddWithValue("@instructions", row.Cells[2].Value?.ToString());
                            presCmd.ExecuteNonQuery();
                        }
                    }

                    // Update appointment status to Completed
                    string updateAppointment = "UPDATE appointments SET status = 'Completed' WHERE appointment_id = @appointmentId";
                    MySqlCommand updateCmd = new MySqlCommand(updateAppointment, conn);
                    updateCmd.Parameters.AddWithValue("@appointmentId", _appointmentId);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Consultation saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving consultation: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}