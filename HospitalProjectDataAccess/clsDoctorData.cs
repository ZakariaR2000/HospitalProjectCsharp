using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProjectDataAccess
{
    public class clsDoctorData
    {

        public static bool GetDoctorInfoByID(int DoctorID, ref int PersonID, ref int? ClinicAddressID,
            ref int SpecializationID, ref DateTime HireDate, ref bool IsActive,ref int CreatedByUserID, ref decimal Salary)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Doctors WHERE DoctorID = @DoctorID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DoctorID", DoctorID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                PersonID = (int)reader["PersonID"];
                                ClinicAddressID = reader["ClinicAddressID"] != DBNull.Value ? (int?)reader["ClinicAddressID"] : null;
                                SpecializationID = (int)reader["SpecializationID"];
                                HireDate = (DateTime)reader["HireDate"];
                                IsActive = (bool)reader["IsActive"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                Salary = (decimal)reader["Salary"]; // جلب قيمة الراتب
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



        public static bool GetDoctorInfoByNationalNo(string NationalNo, ref int DoctorID, ref int PersonID,
            ref int? ClinicAddressID, ref int SpecializationID, ref DateTime HireDate, ref bool IsActive,
            ref int CreatedByUser, ref decimal Salary)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT d.DoctorID, d.PersonID, d.ClinicAddressID, d.SpecializationID,
                                d.HireDate, d.IsActive,d.CreatedByUser, d.Salary
                                FROM Doctors d
                                INNER JOIN People p ON d.PersonID = p.PersonID
                                WHERE p.NationalNo = @NationalNo";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                DoctorID = (int)reader["DoctorID"];
                                PersonID = (int)reader["PersonID"];
                                ClinicAddressID = reader["ClinicAddressID"] != DBNull.Value ? (int?)reader["ClinicAddressID"] : null;
                                SpecializationID = (int)reader["SpecializationID"];
                                HireDate = (DateTime)reader["HireDate"];
                                IsActive = (bool)reader["IsActive"];
                                CreatedByUser = (int)reader["CreatedByUser"];
                                Salary = (decimal)reader["Salary"]; // جلب قيمة الراتب
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



        public static int AddDoctor(int personID, int? clinicAddressID, int SpecializationID,
            DateTime hireDate, bool isActive,int CreatedByUserID, decimal salary)
        {
            int doctorID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Doctors (PersonID, ClinicAddressID, SpecializationID, HireDate, IsActive,CreatedByUserID, Salary) 
                         VALUES (@PersonID, @ClinicAddressID, @SpecializationID, @HireDate, @IsActive,@CreatedByUserID, @Salary);
                         SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);
                  //  command.Parameters.AddWithValue("@ClinicAddressID", clinicAddressID.HasValue ? (object)clinicAddressID.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@ClinicAddressID", clinicAddressID ?? (object)DBNull.Value);

                    command.Parameters.AddWithValue("@SpecializationID", SpecializationID);
                    command.Parameters.AddWithValue("@HireDate", hireDate);
                    command.Parameters.AddWithValue("@IsActive", isActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@Salary", salary); // إضافة الراتب

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            doctorID = insertedID;
                        }
                    }
                    catch (Exception)
                    {
                        // Handle the exception if needed
                    }
                }
            }

            return doctorID;
        }




        public static bool UpdateDoctor(int doctorID, int personID, int? clinicAddressID,
            int SpecializationID, DateTime hireDate, bool isActive, int CreatedByUserID, decimal salary)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Doctors 
                         SET PersonID = @PersonID, 
                             ClinicAddressID = @ClinicAddressID, 
                             SpecializationID = @SpecializationID, 
                             HireDate = @HireDate, 
                             IsActive = @IsActive, 
                             Salary = @Salary ,
                             CreatedByUserID = @CreatedByUserID
                         WHERE DoctorID = @DoctorID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DoctorID", doctorID);
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@ClinicAddressID", clinicAddressID.HasValue ? (object)clinicAddressID.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@SpecializationID", SpecializationID);
                    command.Parameters.AddWithValue("@HireDate", hireDate);
                    command.Parameters.AddWithValue("@IsActive", isActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@Salary", salary); // تحديث الراتب

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }



        public static bool DeleteDoctor(int doctorID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"DELETE FROM Doctor WHERE DoctorID = @DoctorID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DoctorID", doctorID);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public static DataTable GetAllDoctors()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT dbo.Doctors.DoctorID, 
                                         dbo.People.NationalNo,
                                         dbo.People.FirstName + ' ' + dbo.People.SecondName + ' ' + ISNULL(dbo.People.ThirdName, '') + ' ' + dbo.People.LastName AS FullName,
                                         CASE 
                                             WHEN dbo.People.Gender = 0 THEN 'Male'
                                             WHEN dbo.People.Gender = 1 THEN 'Female' 
                                         END AS Gender, 
                                         dbo.People.Phone, 
                                         dbo.Specialization.SpecializationName, 
                                         ISNULL(dbo.ClinicAddresses.AddressLine1, 'No Clinic') AS AddressClinic, 
                                         dbo.Users.UserName as CreatedByUser
                                     FROM 
                                         dbo.Doctors 
                                     INNER JOIN
                                         dbo.People ON dbo.Doctors.PersonID = dbo.People.PersonID 
                                     INNER JOIN
                                         dbo.Specialization ON dbo.Doctors.SpecializationID = dbo.Specialization.SpecializationID 
                                     INNER JOIN
                                         dbo.Users ON dbo.Doctors.CreatedByUserID = dbo.Users.UserID 
                                     LEFT JOIN
                                         dbo.ClinicAddresses ON dbo.Doctors.ClinicAddressID = dbo.ClinicAddresses.ClinicAddresseID";


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
                        // التعامل مع الاستثناءات
                    }
                }
            }

            return dt;
        }

        public static DataTable GetDoctorByID(int doctorID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT Doctor.DoctorID, Doctor.PersonID, Doctor.ClinicAddressID, 
                                Doctor.Specialization, Doctor.HireDate, Doctor.IsActive,Doctor.CreatedByUser,
                                Doctor.Salary,
                                People.FirstName, People.LastName, 
                                ClinicAddresses.Address AS ClinicAddress
                                FROM Doctor
                                INNER JOIN People ON Doctor.PersonID = People.PersonID
                                LEFT JOIN ClinicAddresses ON Doctor.ClinicAddressID = ClinicAddresses.ClinicAddressID
                                WHERE Doctor.DoctorID = @DoctorID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DoctorID", doctorID);

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
                        // التعامل مع الاستثناءات
                    }
                }
            }

            return dt;
        }

        public static bool IsDoctorExistByID(int DoctorID)
        {
            bool exists = false;
            string query = "SELECT 1 FROM Doctors WHERE DoctorID = @DoctorID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DoctorID", DoctorID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        exists = reader.HasRows; // يتحقق مما إذا كان هناك صفوف متطابقة
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return exists;
        }

        public static bool IsDoctorExistByNationalNo(string NationalNo)
        {
            bool exists = false;
            string query = "SELECT 1 FROM Doctors WHERE NationalNo = @NationalNo";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@NationalNo", NationalNo);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    exists = count > 0;
                }
                catch (Exception ex)
                {
                    // التعامل مع الأخطاء
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return exists;
        }

        public static DataTable GetDoctorInfoByClinicAddresseID(int clinicAddressID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT d.DoctorID, p.NationalNo,
                   p.FirstName + ' ' + p.SecondName + ' ' + ISNULL(p.ThirdName, '') + ' ' + p.LastName AS FullName,
                   CASE WHEN p.Gender = 0 THEN 'Male'
                        WHEN p.Gender = 1 THEN 'Female' END AS Gender,
                   p.Phone, s.SpecializationName, 
                   ca.AddressLine1 AS AddressClinic, u.UserName
            FROM dbo.Doctors d
            INNER JOIN dbo.People p ON d.PersonID = p.PersonID
            INNER JOIN dbo.Specialization s ON d.SpecializationID = s.SpecializationID
            INNER JOIN dbo.Users u ON d.CreatedByUserID = u.UserID
            LEFT JOIN dbo.ClinicAddresses ca ON d.ClinicAddressID = ca.ClinicAddresseID
            WHERE d.ClinicAddressID = @ClinicAddressID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClinicAddressID", clinicAddressID);

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
                        // يمكنك تسجيل الخطأ أو إظهار رسالة للمستخدم
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return dt;
        }

        public static int? GetDoctorIDByClinicAddress(int clinicAddressID)
        {
            int? doctorID = null;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT DoctorID 
                         FROM dbo.Doctors 
                         WHERE ClinicAddressID = @ClinicAddressID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClinicAddressID", clinicAddressID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            doctorID = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error fetching DoctorID: " + ex.Message);
                    }
                }
            }

            return doctorID;
        }

        public static bool GetDoctorInfoByPersonID(int PersonID, ref int DoctorID, ref int? ClinicAddressID,
    ref int SpecializationID, ref DateTime HireDate, ref bool IsActive, ref int CreatedByUserID, ref decimal Salary)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                // استعلام SQL لجلب البيانات بناءً على PersonID
                string query = "SELECT * FROM Doctors d where d.PersonID  = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                DoctorID = (int)reader["DoctorID"];
                                ClinicAddressID = reader["ClinicAddressID"] != DBNull.Value ? (int?)reader["ClinicAddressID"] : null;
                                SpecializationID = (int)reader["SpecializationID"];
                                HireDate = (DateTime)reader["HireDate"];
                                IsActive = (bool)reader["IsActive"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                Salary = (decimal)reader["Salary"]; // جلب قيمة الراتب
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

        public static bool GetDoctorInfoByPatientPersonID(int patientPersonID, ref int doctorID, ref int personID, ref int? clinicAddressID,
    ref int specializationID, ref DateTime hireDate, ref bool isActive, ref int createdByUserID, ref decimal salary)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT d.DoctorID, d.PersonID, d.ClinicAddressID, d.SpecializationID, d.HireDate, 
                   d.IsActive, d.CreatedByUserID, d.Salary
            FROM Doctors d
            JOIN Patients p ON p.DoctorID = d.DoctorID
            WHERE p.PersonID = @PatientPersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientPersonID", patientPersonID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                doctorID = (int)reader["DoctorID"];
                                personID = (int)reader["PersonID"];
                                clinicAddressID = reader["ClinicAddressID"] != DBNull.Value ? (int?)reader["ClinicAddressID"] : null;
                                specializationID = (int)reader["SpecializationID"];
                                hireDate = (DateTime)reader["HireDate"];
                                isActive = (bool)reader["IsActive"];
                                createdByUserID = (int)reader["CreatedByUserID"];
                                salary = (decimal)reader["Salary"];
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
