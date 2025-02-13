using HospitalProjectDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class clsClinicAddresseData
{
    // Method to add a new clinic address
    public static int AddClinicAddress(string AddressLine1, string AddressLine2, string City, string PostalCode)
    {
        int newClinicAddresseID = -1;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = @"INSERT INTO ClinicAddresses (AddressLine1, AddressLine2, City, PostalCode) 
                         OUTPUT INSERTED.ClinicAddresseID 
                         VALUES (@AddressLine1, @AddressLine2, @City, @PostalCode)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AddressLine1", AddressLine1);
                command.Parameters.AddWithValue("@AddressLine2", AddressLine2);
                command.Parameters.AddWithValue("@City", City);
                command.Parameters.AddWithValue("@PostalCode", PostalCode);

                try
                {
                    connection.Open();
                    newClinicAddresseID = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    newClinicAddresseID = -1;
                    // Logging exception if needed
                }
            }
        }

        return newClinicAddresseID;
    }

    // Method to update an existing clinic address
    public static bool UpdateClinicAddress(int ClinicAddresseID, string AddressLine1, string AddressLine2, string City, string PostalCode)
    {
        bool isUpdated = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = @"UPDATE ClinicAddresses SET 
                         AddressLine1 = @AddressLine1, 
                         AddressLine2 = @AddressLine2, 
                         City = @City, 
                         PostalCode = @PostalCode 
                         WHERE ClinicAddresseID = @ClinicAddresseID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClinicAddresseID", ClinicAddresseID);
                command.Parameters.AddWithValue("@AddressLine1", AddressLine1);
                command.Parameters.AddWithValue("@AddressLine2", AddressLine2);
                command.Parameters.AddWithValue("@City", City);
                command.Parameters.AddWithValue("@PostalCode", PostalCode);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    isUpdated = rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    isUpdated = false;
                    // Logging exception if needed
                }
            }
        }

        return isUpdated;
    }

    // Method to delete a clinic address by ID
    public static bool DeleteClinicAddress(int clinicAddressID)
    {
        string query = "DELETE FROM ClinicAddresses WHERE ClinicAddressID = @ClinicAddressID";
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@ClinicAddressID", clinicAddressID);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Handle the exception
                return false;
            }
        }
    }

    // Method to find a clinic address by ID
    public static bool GetClinicAddressByID(int ClinicAddresseID, ref string AddressLine1, ref string AddressLine2, ref string City, ref string PostalCode)
    {
        bool isFound = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = "SELECT AddressLine1, AddressLine2, City, PostalCode FROM ClinicAddresses WHERE ClinicAddresseID = @ClinicAddresseID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClinicAddresseID", ClinicAddresseID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            AddressLine1 = reader["AddressLine1"].ToString();
                            AddressLine2 = reader["AddressLine2"].ToString();
                            City = reader["City"].ToString();
                            PostalCode = reader["PostalCode"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    isFound = false;
                    // Logging exception if needed
                }
            }
        }

        return isFound;
    }

    // Method to get all clinic addresses
    public static DataTable GetAllClinicAddresses()
    {
        DataTable dt = new DataTable();

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = @"SELECT 
                                 dbo.ClinicAddresses.ClinicAddresseID, 
                                 dbo.ClinicAddresses.AddressLine1, 
                                 ISNULL(dbo.ClinicAddresses.AddressLine2,' ') AS AddressLine2, 
                                 dbo.ClinicAddresses.City, 
                                 dbo.ClinicAddresses.PostalCode, 
                                 ISNULL(dbo.People.FirstName + ' ' + ISNULL(dbo.People.SecondName, ' ') + ' ' + dbo.People.ThirdName + ' ' + dbo.People.LastName,' ') AS FullName, 
                                 ISNULL(dbo.Specialization.SpecializationName,' '),
                                 CASE 
                                     WHEN dbo.Doctors.ClinicAddressID IS NOT NULL THEN 'Active'
                                     ELSE 'Inactive'
                                 END AS ClinicStatus
                             FROM 
                                 dbo.ClinicAddresses
                             LEFT JOIN 
                                 dbo.Doctors ON dbo.ClinicAddresses.ClinicAddresseID = dbo.Doctors.ClinicAddressID
                             LEFT JOIN 
                                 dbo.People ON dbo.Doctors.PersonID = dbo.People.PersonID
                             LEFT JOIN 
                                 dbo.Specialization ON dbo.Doctors.SpecializationID = dbo.Specialization.SpecializationID";

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
                    // التعامل مع الاستثناءات
                    throw new Exception("Error fetching clinic addresses: " + ex.Message);
                }
            }
        }

        return dt;
    }

    public static bool IsClinicAddressExistByID(int ClinicAddresseID)
    {
        bool exists = false;

        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            string query = "SELECT COUNT(1) FROM ClinicAddresses WHERE ClinicAddresseID = @ClinicAddresseID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClinicAddresseID", ClinicAddresseID);

                try
                {
                    connection.Open();
                    exists = (int)command.ExecuteScalar() > 0;
                }
                catch (Exception ex)
                {
                    exists = false;
                    // Logging exception if needed
                }
            }
        }

        return exists;
    }

}



