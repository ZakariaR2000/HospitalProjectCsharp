using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProjectDataAccess
{
    public class clsPersonData
    {
        //    public static bool GetPersonInfoByID(int PersonID, ref string FirstName, ref string SecondName,
        //ref string ThirdName, ref string LastName, ref string NationalNo, ref DateTime DateOfBirth,
        //ref byte Gender, ref string Address, ref string Phone, ref string Email,
        //ref int NationalityCountryID, ref string ImagePath)
        //    {
        //        bool isFound = false;

        //        string query = "SELECT * FROM People WHERE PersonID = @PersonID";

        //        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@PersonID", PersonID);

        //            try
        //            {
        //                connection.Open();
        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        // The record was found
        //                        isFound = true;

        //                        FirstName = (string)reader["FirstName"];
        //                        SecondName = (string)reader["SecondName"];

        //                        //ThirdName: allows null in database so we should handle null
        //                        if (reader["ThirdName"] != DBNull.Value)
        //                        {
        //                            ThirdName = (string)reader["ThirdName"];
        //                        }
        //                        else
        //                        {
        //                            ThirdName = "";
        //                        }

        //                        LastName = (string)reader["LastName"];
        //                        NationalNo = (string)reader["NationalNo"];
        //                        DateOfBirth = (DateTime)reader["DateOfBirth"];
        //                        Gender = (byte)reader["Gender"];
        //                        Address = (string)reader["Address"];
        //                        Phone = (string)reader["Phone"];


        //                        //Email: allows null in database so we should handle null
        //                        if (reader["Email"] != DBNull.Value)
        //                        {
        //                            Email = (string)reader["Email"];
        //                        }
        //                        else
        //                        {
        //                            Email = "";
        //                        }

        //                        NationalityCountryID = (int)reader["NationalityCountryID"];

        //                        //ImagePath: allows null in database so we should handle null
        //                        if (reader["ImagePath"] != DBNull.Value)
        //                        {
        //                            ImagePath = (string)reader["ImagePath"];
        //                        }
        //                        else
        //                        {
        //                            ImagePath = "";
        //                        }

        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                // التعامل مع الأخطاء
        //                isFound = false;
        //            }
        //        }

        //        return isFound;
        //    }

        public static bool GetPersonInfoByID(int PersonID, ref string FirstName, ref string SecondName,
                   ref string ThirdName, ref string LastName, ref string NationalNo, ref DateTime DateOfBirth,
                    ref byte Gendor, ref string Address, ref string Phone, ref string Email,
                    ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    //ThirdName: allows null in database so we should handle null
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }

                    LastName = (string)reader["LastName"];
                    NationalNo = (string)reader["NationalNo"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gender"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];


                    //Email: allows null in database so we should handle null
                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }

                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    //ImagePath: allows null in database so we should handle null
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }




        public static bool GetPersonInfoByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName,
                ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
                 ref byte Gender, ref string Address, ref string Phone, ref string Email,
                 ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    //ThirdName: allows null in database so we should handle null
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = (byte)reader["Gender"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];

                    //Email: allows null in database so we should handle null
                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }

                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    //ImagePath: allows null in database so we should handle null
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static int AddNewPerson(string FirstName, string SecondName,
           string ThirdName, string LastName, string NationalNo, DateTime DateOfBirth,
           short Gender, string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO People (FirstName, SecondName, ThirdName, LastName, NationalNo,
                                               DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath)
                             VALUES (@FirstName, @SecondName, @ThirdName, @LastName, @NationalNo,
                                     @DateOfBirth, @Gender, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
                             SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(ThirdName) ? (object)DBNull.Value : ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? (object)DBNull.Value : Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? (object)DBNull.Value : ImagePath);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            PersonID = insertedID;
                        }
                    }
                    catch (Exception)
                    {
                        // Handle the exception if needed
                    }
                }
            }

            return PersonID;
        }

        public static bool UpdatePerson(int PersonID, string FirstName, string SecondName,
           string ThirdName, string LastName, string NationalNo, DateTime DateOfBirth,
           short Gender, string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE People  
                             SET FirstName = @FirstName,
                                 SecondName = @SecondName,
                                 ThirdName = @ThirdName,
                                 LastName = @LastName, 
                                 NationalNo = @NationalNo,
                                 DateOfBirth = @DateOfBirth,
                                 Gender = @Gender,
                                 Address = @Address,  
                                 Phone = @Phone,
                                 Email = @Email, 
                                 NationalityCountryID = @NationalityCountryID,
                                 ImagePath = @ImagePath
                             WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(ThirdName) ? (object)DBNull.Value : ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? (object)DBNull.Value : Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? (object)DBNull.Value : ImagePath);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT People.PersonID, People.NationalNo,
                            People.FirstName, People.SecondName, People.ThirdName, People.LastName,
                            People.DateOfBirth, 
                            CASE WHEN People.Gender = 0 THEN 'Male' ELSE 'Female' END AS GenderCaption,
                            People.Address, People.Phone, People.Email, 
                            People.NationalityCountryID, Countries.CountryName, People.ImagePath
                            FROM People 
                            INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID
                            ORDER BY People.FirstName";

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
                        // Handle the exception if needed
                    }
                }
            }

            return dt;
        }
        public static DataTable GetPeopleBySelectedColumns(string columns)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                // تحقق من وجود "GenderCaption" واستبدلها بالعبارة المنطقية
                string genderCaseStatement = @"CASE WHEN People.Gender = 0 THEN 'Male' ELSE 'Female' END AS GenderCaption";

                // استبدال GenderCaption بالعبارة المنطقية إذا كانت مختارة
                if (columns.Contains("GenderCaption"))
                {
                    columns = columns.Replace("GenderCaption", genderCaseStatement);
                }

                // بناء الاستعلام بناءً على الأعمدة المختارة
                string query = $@"SELECT {columns}
                          FROM People 
                          INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID
                          ORDER BY People.FirstName";

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
                    catch (SqlException sqlEx)
                    {
                        // استقصاء الخطأ وإضافة نص الاستعلام لمزيد من المعلومات
                        throw new Exception($"SQL Error: {sqlEx.Message}. Query: {query}", sqlEx);
                    }
                    catch (Exception ex)
                    {
                        // استقصاء الخطأ العام
                        throw new Exception($"General Error: {ex.Message}. Query: {query}", ex);
                    }
                }
            }

            return dt;
        }


        public static bool DeletePerson(int PersonID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM People WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found = 1 FROM People WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }
                    }
                    catch (Exception)
                    {
                        // يمكنك هنا تسجيل الخطأ إذا لزم الأمر
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found = 1 FROM People WHERE NationalNo = @NationalNo";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }
                    }
                    catch (Exception)
                    {
                        // يمكنك هنا تسجيل الخطأ إذا لزم الأمر
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

       

    }


}
