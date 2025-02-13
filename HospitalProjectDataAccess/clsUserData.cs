using System;
using System.Data;
using System.Data.SqlClient;

namespace HospitalProjectDataAccess
{
    public class clsUserData
    {
        private static string ConnectionString => clsDataAccessSettings.ConnectionString;

        // Method to map data from SqlDataReader to user properties
        private static bool MapUserData(SqlDataReader reader, ref int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            if (reader.Read())
            {
                UserID = (int)reader["UserID"];
                PersonID = (int)reader["PersonID"];
                UserName = (string)reader["UserName"];
                Password = (string)reader["Password"];
                IsActive = (bool)reader["IsActive"];
                return true;
            }
            return false;
        }

        public static bool GetUserInfoByUserID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", UserID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return MapUserData(reader, ref UserID, ref PersonID, ref UserName, ref Password, ref IsActive);
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool GetUserInfoByPersonID(int PersonID, ref int UserID, ref string UserName, ref string Password, ref bool IsActive)
        {
            string query = "SELECT * FROM Users WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return MapUserData(reader, ref UserID, ref PersonID, ref UserName, ref Password, ref IsActive);
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool GetUserInfoByUsernameAndPassword(string UserName, string Password, ref int UserID, ref int PersonID, ref bool IsActive)
        {
            string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", UserName);
                command.Parameters.AddWithValue("@Password", Password);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return MapUserData(reader, ref UserID, ref PersonID, ref UserName, ref Password, ref IsActive);
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            string query = @"INSERT INTO Users (PersonID, UserName, Password, IsActive)
                             VALUES (@PersonID, @UserName, @Password, @IsActive);
                             SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@IsActive", IsActive);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null && int.TryParse(result.ToString(), out int insertedID) ? insertedID : -1;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            string query = @"UPDATE Users SET PersonID = @PersonID, UserName = @UserName, Password = @Password, IsActive = @IsActive 
                             WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@IsActive", IsActive);
                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static DataTable GetAllUsers()
        {
            string query = @"SELECT Users.UserID, Users.PersonID,
                            People.FirstName + ' ' + People.SecondName + ' ' + ISNULL(People.ThirdName,'') + ' ' + People.LastName AS FullName,
                            Users.UserName, Users.IsActive
                            FROM Users
                            INNER JOIN People ON Users.PersonID = People.PersonID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                DataTable dt = new DataTable();
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
                    // Handle exceptions here
                }
                return dt;
            }
        }

        public static bool DeleteUser(int UserID)
        {
            string query = "DELETE FROM Users WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool IsUserExist(int UserID)
        {
            string query = "SELECT 1 FROM Users WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", UserID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool IsUserExist(string UserName)
        {
            string query = "SELECT 1 FROM Users WHERE UserName = @UserName";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserName", UserName);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool IsUserExistForPersonID(int PersonID)
        {
            string query = "SELECT 1 FROM Users WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool ChangePassword(int UserID, string NewPassword)
        {
            string query = "UPDATE Users SET Password = @Password WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Password", NewPassword);
                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
