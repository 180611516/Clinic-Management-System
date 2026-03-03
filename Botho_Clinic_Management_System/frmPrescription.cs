using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Botho_Clinic_Management_System
{
    public partial class frmPrescription : Form
    {
        private int _providerId;
        private string _connStr = "server=localhost;user=root;database=Botho_Clinic_Management_System;password=;";

        public frmPrescription(int providerId)
        {
            InitializeComponent();
            _providerId = providerId;

            LoadPrescriptions();
        }

        private void LoadPrescriptions()
        {
            dgvPrescriptions.Columns.Clear();
            dgvPrescriptions.Rows.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();

                    // Adjusted query based on your table
                    string query = @"
                        SELECT pr.prescription_id,
                               u.full_name AS patient_name,
                               pr.medication_name,
                               pr.dosage,
                               pr.instructions
                        FROM prescriptions pr
                        INNER JOIN consultations c ON pr.consultation_id = c.consultation_id
                        INNER JOIN appointments a ON c.appointment_id = a.appointment_id
                        INNER JOIN users u ON a.student_id = u.user_id
                        WHERE a.provider_id = @providerId
                        ORDER BY c.recorded_at DESC"; 

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@providerId", _providerId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            dgvPrescriptions.Columns.Add("prescription_id", "ID");
                            dgvPrescriptions.Columns.Add("patient_name", "Patient");
                            dgvPrescriptions.Columns.Add("medication_name", "Medication");
                            dgvPrescriptions.Columns.Add("dosage", "Dosage");
                            dgvPrescriptions.Columns.Add("instructions", "Instructions");

                            while (reader.Read())
                            {
                                dgvPrescriptions.Rows.Add(
                                    reader.GetInt32("prescription_id"),
                                    reader.GetString("patient_name"),
                                    reader.GetString("medication_name"),
                                    reader.GetString("dosage"),
                                    reader.GetString("instructions")
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading prescriptions: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPrescriptions();
        }
    }
}
