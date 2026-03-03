using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Botho_Clinic_Management_System
{
    public static class UserSync
    {
        private static readonly string _connStr = "server=localhost;user=root;password=;database=botho_clinic_management_system;";

        // Sync user_ids for students and providers
        public static void SyncUserIds()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();

                    // Sync students.user_id
                    string updateStudents = @"
                        UPDATE students s
                        JOIN Users u ON s.username = u.username OR s.full_name = u.username
                        SET s.user_id = u.user_id;
                    ";
                    using (MySqlCommand cmd = new MySqlCommand(updateStudents, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Sync providers.user_id
                    string updateProviders = @"
                        UPDATE providers p
                        JOIN Users u ON p.username = u.username
                        SET p.user_id = u.user_id;
                    ";
                    using (MySqlCommand cmd = new MySqlCommand(updateProviders, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error synchronizing user IDs: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}