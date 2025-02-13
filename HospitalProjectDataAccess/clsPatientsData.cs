using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProjectDataAccess
{
    public class clsPatientsData
    {

        public static bool GetPatientByID(int patientID, ref int personID, ref string patientNumber,
                                  ref string bloodType, ref string allergies, ref DateTime createdDate,
                                  ref int createdByUserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Patients WHERE PatientID = @PatientID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientID", patientID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                personID = (int)reader["PersonID"];
                                patientNumber = reader["PatientNumber"].ToString();
                                bloodType = reader["BloodType"] != DBNull.Value ? reader["BloodType"].ToString() : null;
                                allergies = reader["Allergies"] != DBNull.Value ? reader["Allergies"].ToString() : null;
                                createdDate = (DateTime)reader["CreatedDate"];
                                createdByUserID = (int)reader["CreatedByUserID"];
                            }
                        }
                    }
                    catch (Exception)
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        // دالة للتحقق مما إذا كان PatientNumber موجودًا
        private static bool IsPatientNumberExists(string patientNumber)
        {
            bool exists = false;
            string query = "SELECT COUNT(*) FROM Patients WHERE PatientNumber = @PatientNumber";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PatientNumber", patientNumber);

                try
                {
                    connection.Open();
                    exists = (int)command.ExecuteScalar() > 0; // تحقق مما إذا كان الرقم موجودًا
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return exists;
        }

        // Method to add a new patient
        public static int AddPatient(int personID, string patientNumber, string bloodType, string allergies,
            DateTime createdDate, int createdByUserID)
        {

            if (IsPatientNumberExists(patientNumber))
            {
                throw new Exception("PatientNumber must be unique.");
            }

            int patientID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Patients (PersonID, PatientNumber, BloodType, Allergies, CreatedDate, 
                                CreatedByUserID) 
                                VALUES (@PersonID, @PatientNumber, @BloodType, @Allergies, @CreatedDate, 
                                @CreatedByUserID);
                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@PatientNumber", patientNumber);
                    command.Parameters.AddWithValue("@BloodType", bloodType);
                    command.Parameters.AddWithValue("@Allergies", allergies ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedDate", createdDate);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            patientID = insertedID;
                        }
                    }
                    catch (Exception)
                    {
                        // Handle the exception if needed
                    }
                }
            }

            return patientID;
        }

        // Method to update patient information
        public static bool UpdatePatient(int patientID, int personID, string patientNumber, string bloodType,
            string allergies, DateTime createdDate, int createdByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Patients 
                                 SET PersonID = @PersonID, 
                                     PatientNumber = @PatientNumber, 
                                     BloodType = @BloodType, 
                                     Allergies = @Allergies, 
                                     CreatedDate = @CreatedDate, 
                                     CreatedByUserID = @CreatedByUserID 
                                 WHERE PatientID = @PatientID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientID", patientID);
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@PatientNumber", patientNumber);
                    command.Parameters.AddWithValue("@BloodType", bloodType);
                    command.Parameters.AddWithValue("@Allergies", allergies ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedDate", createdDate);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Method to delete a patient
        public static bool DeletePatient(int patientID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"DELETE FROM Patients WHERE PatientID = @PatientID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientID", patientID);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }


        // Method to get all patients
        public static DataTable GetAllPatients()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT PatientID, PersonID,PatientNumber,BloodType,Allergies,CreatedDate, 
                                        CreatedByUserID
                                    FROM Patients;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // Handle exceptions if needed
                    }
                }
            }

            return dt;
        }

        public static bool GetPatientInfoByPersonID(int PersonID, ref int PatientID, ref string BloodType, ref string Allergies,
      ref DateTime CreatedDate, ref int CreatedByUserID, ref string PatientNumber)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "select * from Patients WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                PatientID = reader.GetInt32(reader.GetOrdinal("PatientID"));
                                PatientNumber = reader.GetString(reader.GetOrdinal("PatientNumber"));
                                BloodType = reader.GetString(reader.GetOrdinal("BloodType"));
                                Allergies = reader["Allergies"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Allergies")) : "";
                                CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
                                CreatedByUserID = reader["CreatedByUserID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CreatedByUserID")) : default;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

    }
}
