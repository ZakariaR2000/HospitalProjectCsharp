using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProjectDataAccess
{
    public class clsSpecializationData
    {

        private static string ConnectionString => clsDataAccessSettings.ConnectionString;

        // Method to get all specializations
        public static DataTable GetAllSpecializations()
        {
            DataTable dt = new DataTable();
            string query = "SELECT SpecializationName FROM Specialization ORDER BY SpecializationName";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
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
                catch (Exception ex)
                {
                    // يمكنك تسجيل الخطأ أو التعامل معه حسب الحاجة
                }
            }

            return dt;
        }


        // Method to get specialization by ID
        public static bool GetSpecializationByID(int specializationID, ref string specializationName)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT SpecializationName FROM Specialization WHERE SpecializationID = @SpecializationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SpecializationID", specializationID);

                try
                {
                    connection.Open();
                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        specializationName = result.ToString();
                        return true;
                    }
                }
                catch (Exception)
                {
                    // Handle error if needed
                }
            }
            return false;
        }

        public static bool GetSpecializationByName(string specializationName, ref int specializationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT SpecializationID FROM Specialization WHERE SpecializationName = @SpecializationName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SpecializationName", specializationName);

                try
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    Console.WriteLine("Query Result: " + result); // طباعة النتيجة

                    if (result != null)
                    {
                        specializationID = Convert.ToInt32(result);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message); // طباعة أي خطأ يحدث
                }
            }
            return false;
        }



        // Method to add a new specialization
        public static int AddNewSpecialization(string specializationName)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Specializations (SpecializationName) VALUES (@SpecializationName); SELECT SCOPE_IDENTITY();", conn);
                cmd.Parameters.AddWithValue("@SpecializationName", specializationName);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Method to update an existing specialization
        public static bool UpdateSpecialization(int specializationID, string specializationName)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Specializations SET SpecializationName = @SpecializationName WHERE SpecializationID = @SpecializationID", conn);
                cmd.Parameters.AddWithValue("@SpecializationName", specializationName);
                cmd.Parameters.AddWithValue("@SpecializationID", specializationID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Method to delete a specialization
        public static bool DeleteSpecialization(int specializationID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Specializations WHERE SpecializationID = @SpecializationID", conn);
                cmd.Parameters.AddWithValue("@SpecializationID", specializationID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

}
