using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProjectDataAccess
{
    public class clsAppointmentData
    {



        public static bool GetAppointmentByID(int appointmentID, ref int patientID, ref int? doctorID, ref DateTime appointmentDate, ref byte status, ref string notes, ref int createdByUserID)
        {
            bool isFound = false;

            // استخدام connection with using statement لضمان الإغلاق التلقائي للاتصال بعد الانتهاء
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Appointments WHERE AppointmentID = @AppointmentID";

                // إعداد الأمر مع المعاملات المناسبة
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // استخدام SqlParameter بدلًا من AddWithValue لتفادي مشاكل تحويل البيانات
                    command.Parameters.Add(new SqlParameter("@AppointmentID", SqlDbType.Int)).Value = appointmentID;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // تعيين القيم مع التحقق من NULL
                                patientID = reader.IsDBNull(reader.GetOrdinal("PatientID")) ? throw new InvalidCastException("PatientID is NULL or invalid.") : reader.GetInt32(reader.GetOrdinal("PatientID"));
                                doctorID = reader.IsDBNull(reader.GetOrdinal("DoctorID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("DoctorID"));
                                appointmentDate = reader.IsDBNull(reader.GetOrdinal("AppointmentDate")) ? throw new InvalidCastException("AppointmentDate is NULL or invalid.") : reader.GetDateTime(reader.GetOrdinal("AppointmentDate"));
                                status = reader.IsDBNull(reader.GetOrdinal("Status")) ? throw new InvalidCastException("Status is NULL or invalid.") : reader.GetByte(reader.GetOrdinal("Status"));
                                if (!reader.IsDBNull(reader.GetOrdinal("Notes")))
                                {
                                    notes = reader["Notes"] as string ?? string.Empty;
                                }
                                else
                                {
                                    notes = string.Empty;
                                }

                                createdByUserID = reader.IsDBNull(reader.GetOrdinal("CreatedByUserID")) ? throw new InvalidCastException("CreatedByUserID is NULL or invalid.") : reader.GetInt32(reader.GetOrdinal("CreatedByUserID"));

                                isFound = true;  // السجل تم العثور عليه
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // طباعة الخطأ بشكل واضح للمساعدة في التشخيص
                        isFound = false; // في حالة حدوث خطأ
                    }
                }
            }

            return isFound;
        }

        public static int AddAppointment(int patientID, int? doctorID, DateTime appointmentDate, byte status, string notes, int createdByUserID)
        {
            int newAppointmentID = -1;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Appointments (PatientID, DoctorID, AppointmentDate, Status, Notes, CreatedByUserID) 
                         OUTPUT INSERTED.AppointmentID 
                         VALUES (@PatientID, @DoctorID, @AppointmentDate, @Status, @Notes, @CreatedByUserID)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // إضافة المعلمات
                    cmd.Parameters.AddWithValue("@PatientID", patientID);
                    cmd.Parameters.AddWithValue("@DoctorID", doctorID.HasValue ? (object)doctorID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? (object)DBNull.Value : notes);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    try
                    {
                        conn.Open();
                        newAppointmentID = (int)cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        newAppointmentID = -1; // إذا حدث خطأ، يُرجع -1
                                               // يمكن تسجيل الخطأ إذا لزم الأمر
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return newAppointmentID;
        }


        public static DataTable GetAllAppointments()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    // تغيير CommandType إلى Text بدلاً من StoredProcedure
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Appointments", conn);
                    cmd.CommandType = CommandType.Text;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    // فتح الاتصال وملء DataTable
                    conn.Open();
                    adapter.Fill(dt);

                    return dt;
                }
            }
            catch (SqlException ex)
            {
                // تسجيل الخطأ بدلاً من الطباعة مباشرة
                LogError(ex); // يمكنك استخدام دالة لتسجيل الأخطاء في سجل
                return null;
            }
            catch (Exception ex)
            {
                // التعامل مع الأخطاء العامة
                LogError(ex);
                return null;
            }
        }

        private static void LogError(Exception ex)
        {
            // يمكن استبدال هذا بمكتبة سجل مهنية (مثل NLog أو Log4Net)
            Console.WriteLine($"Error: {ex.Message}");
            // مثال على سجل الملف:
            // System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now} - {ex.Message}\n");
        }


        public DataTable GetAppointmentById(int appointmentID)
        {
            string query = "SELECT * FROM Appointments WHERE AppointmentID = @AppointmentID";
            DataTable dataTable = new DataTable();

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AppointmentID", appointmentID);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                connection.Open();
                dataAdapter.Fill(dataTable);
            }
            return dataTable;
        }


        public static bool UpdateAppointment(int appointmentID, int patientID, int? doctorID,
            DateTime appointmentDate, int status, string notes, int createdByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Appointments
                         SET PatientID = @PatientID,
                             DoctorID = @DoctorID,
                             AppointmentDate = @AppointmentDate,
                             Status = @Status,
                             Notes = @Notes,
                             CreatedByUserID = @CreatedByUserID
                         WHERE AppointmentID = @AppointmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // ربط القيم بالمعلمات
                    command.Parameters.AddWithValue("@AppointmentID", appointmentID);
                    command.Parameters.AddWithValue("@PatientID", patientID);
                    command.Parameters.AddWithValue("@DoctorID", doctorID.HasValue ? (object)doctorID.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? (object)DBNull.Value : notes);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }


        public static bool DeleteAppointment(int appointmentID)
        {
            string query = "DELETE FROM Appointments WHERE AppointmentID = @AppointmentID";

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AppointmentID", appointmentID);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public DataTable GetAppointmentsByPatientId(int patientID)
        {
            string query = "SELECT * FROM Appointments WHERE PatientID = @PatientID";
            DataTable dataTable = new DataTable();

            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PatientID", patientID);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                connection.Open();
                dataAdapter.Fill(dataTable);
            }
            return dataTable;
        }

        public static DataTable GetAppointmentsByPatientID(int patientID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAppointmentsByPatientID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PatientID", patientID);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    conn.Open();
                    adapter.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static DataTable GetAppointmentsByDoctorID(int? doctorID)
        {
            try
            {
                // إذا كانت DoctorID تساوي null، يمكنك اتخاذ إجراء مناسب أو إرجاع DataTable فارغ
                if (!doctorID.HasValue)
                {
                    return null; // إرجاع جدول فارغ في حالة null
                }

                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAppointmentsByDoctorID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DoctorID", doctorID.Value); // استخدام القيمة الفعلية

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    conn.Open();
                    adapter.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                return null; // إرجاع null في حالة وجود خطأ
            }
        }


        public static bool IsAppointmentExist(int appointmentID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_CheckAppointmentExist", conn);  // تأكد من أنك تستخدم اسم الـ Stored Procedure المناسب
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AppointmentID", appointmentID);

                    conn.Open();
                    object result = cmd.ExecuteScalar(); // استخدام ExecuteScalar للحصول على قيمة واحدة

                    return (result != null && Convert.ToInt32(result) > 0); // إذا كانت القيمة أكبر من 0 فهذا يعني أن الـ Appointment موجود
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false; // في حالة حدوث خطأ، يمكن إرجاع false
            }
        }

        public static bool UpdateAppointmentStatus(int appointmentID, byte newStatus)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Appointments SET Status = @Status WHERE AppointmentID = @AppointmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppointmentID", appointmentID);
                    command.Parameters.AddWithValue("@Status", newStatus);

                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message); // يمكن تسجيل الخطأ إذا لزم الأمر
                        return false;
                    }
                }
            }
        }


        public static int? GetAppointmentIDByPatientID(int patientID)
        {
            int? appointmentID = null;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT TOP 1 AppointmentID FROM Appointments WHERE PatientID = @PatientID ORDER BY AppointmentDate DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientID", patientID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            appointmentID = id;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return appointmentID;
        }


        public static int? GetDoctorIDByAppointmentID(int appointmentID)
        {
            int? doctorID = null;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT DoctorID FROM Appointments WHERE AppointmentID = @AppointmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppointmentID", appointmentID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            doctorID = id;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return doctorID;
        }


        public static bool GetAppointmentByPatientID(int patientID,
            ref int appointmentID,
            ref int? doctorID,
            ref DateTime appointmentDate,
            ref byte status,
            ref string notes,
            ref int createdByUserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT AppointmentID, PatientID, DoctorID, AppointmentDate, Status, Notes, CreatedByUserID 
                         FROM Appointments 
                         WHERE PatientID = @PatientID";

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
                                appointmentID = reader.GetInt32(reader.GetOrdinal("AppointmentID"));
                                doctorID = reader["DoctorID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DoctorID")) : (int?)null;
                                appointmentDate = reader.GetDateTime(reader.GetOrdinal("AppointmentDate"));
                                status = reader.GetByte(reader.GetOrdinal("Status"));
                                notes = reader["Notes"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Notes")) : null;
                                createdByUserID = reader.GetInt32(reader.GetOrdinal("CreatedByUserID"));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error retrieving appointment: {ex.Message}");
                        isFound = false;
                    }
                }
            }

            return isFound;
        }



    }

}
