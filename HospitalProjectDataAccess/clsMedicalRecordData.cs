using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProjectDataAccess
{
    public class clsMedicalRecordData
    {
        public static bool GetMedicalRecordByID(int recordID, ref int patientID, ref int? doctorID, ref DateTime recordDate, ref string diagnosis, ref string treatment, ref int createdByUserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM MedicalRecords WHERE RecordID = @RecordID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@RecordID", SqlDbType.Int)).Value = recordID;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                patientID = reader.GetInt32(reader.GetOrdinal("PatientID"));
                                doctorID = reader.IsDBNull(reader.GetOrdinal("DoctorID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("DoctorID"));
                                recordDate = reader.GetDateTime(reader.GetOrdinal("RecordDate"));
                                diagnosis = reader.IsDBNull(reader.GetOrdinal("Diagnosis")) ? string.Empty : reader.GetString(reader.GetOrdinal("Diagnosis"));
                                treatment = reader.IsDBNull(reader.GetOrdinal("Treatment")) ? string.Empty : reader.GetString(reader.GetOrdinal("Treatment"));
                                createdByUserID = reader.GetInt32(reader.GetOrdinal("CreatedByUserID"));

                                isFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        public static int AddMedicalRecord(int patientID, int? doctorID, DateTime recordDate, string diagnosis, string treatment, int createdByUserID)
        {
            int newRecordID = -1;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO MedicalRecords (PatientID, DoctorID, RecordDate, Diagnosis, Treatment, CreatedByUserID) 
                                 OUTPUT INSERTED.RecordID 
                                 VALUES (@PatientID, @DoctorID, @RecordDate, @Diagnosis, @Treatment, @CreatedByUserID)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientID);
                    cmd.Parameters.AddWithValue("@DoctorID", doctorID.HasValue ? (object)doctorID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@RecordDate", recordDate);
                    cmd.Parameters.AddWithValue("@Diagnosis", string.IsNullOrEmpty(diagnosis) ? DBNull.Value : (object)diagnosis);
                    cmd.Parameters.AddWithValue("@Treatment", string.IsNullOrEmpty(treatment) ? DBNull.Value : (object)treatment);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    try
                    {
                        conn.Open();
                        newRecordID = (int)cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        newRecordID = -1;
                    }
                }
            }

            return newRecordID;
        }

        public static DataTable GetAllMedicalRecords()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM MedicalRecords", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    conn.Open();
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return dataTable;
        }

        public static bool UpdateMedicalRecord(int recordID, int patientID, int? doctorID, DateTime recordDate, string diagnosis, string treatment, int createdByUserID)
        {
            bool isUpdated = false;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE MedicalRecords
                                 SET PatientID = @PatientID, DoctorID = @DoctorID, RecordDate = @RecordDate,
                                     Diagnosis = @Diagnosis, Treatment = @Treatment, 
                                     CreatedByUserID = @CreatedByUserID
                                 WHERE RecordID = @RecordID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RecordID", recordID);
                    cmd.Parameters.AddWithValue("@PatientID", patientID);
                    cmd.Parameters.AddWithValue("@DoctorID", doctorID.HasValue ? (object)doctorID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@RecordDate", recordDate);
                    cmd.Parameters.AddWithValue("@Diagnosis", string.IsNullOrEmpty(diagnosis) ? DBNull.Value : (object)diagnosis);
                    cmd.Parameters.AddWithValue("@Treatment", string.IsNullOrEmpty(treatment) ? DBNull.Value : (object)treatment);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    try
                    {
                        conn.Open();
                        isUpdated = cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        isUpdated = false;
                    }
                }
            }

            return isUpdated;
        }

        public static bool DeleteMedicalRecord(int recordID)
        {
            bool isDeleted = false;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM MedicalRecords WHERE RecordID = @RecordID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RecordID", recordID);

                    try
                    {
                        conn.Open();
                        isDeleted = cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        isDeleted = false;
                    }
                }
            }

            return isDeleted;
        }

        public static DataTable GetMedicalRecordsByPatientID(int patientID)
        {
            // إنشاء DataTable لاسترجاع البيانات
            DataTable dt = new DataTable();

            try
            {
                // كتابة استعلام SQL
                string sqlQuery = "SELECT * FROM MedicalRecords WHERE PatientID = @PatientID";

                // تنفيذ الاستعلام باستخدام قاعدة البيانات
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@PatientID", patientID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetMedicalRecordsByPatientID: {ex.Message}");
                throw;
            }

            return dt;
        }

        public static bool IsMedicalRecordExist(int medicalRecordID)
        {
            bool isExist = false;

            try
            {
                // كتابة استعلام SQL
                string sqlQuery = "SELECT COUNT(1) FROM MedicalRecords WHERE MedicalRecordID = @MedicalRecordID";

                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MedicalRecordID", medicalRecordID);
                        conn.Open();
                        isExist = Convert.ToBoolean(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in IsMedicalRecordExist: {ex.Message}");
                throw;
            }

            return isExist;
        }



    }
}
