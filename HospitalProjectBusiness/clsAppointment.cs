using HospitalProjectDataAccess;
using System;
using System.Data;

namespace HospitalProjectBusiness
{
    public class clsAppointment
    {
        // Enums for mode and status
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode { get; set; } = enMode.AddNew;

        public enum enStatus { OnTime = 1, Cancelled = 2, Completed = 3 }
        public enStatus Status { get; set; }

        public string StatusText
        {
            get
            {
                switch (Status)
                {
                    case enStatus.OnTime:
                        return "New";
                    case enStatus.Cancelled:
                        return "Cancelled";
                    case enStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }
        }


        // Properties
        public int AppointmentID { get; set; } = -1;
        public int PatientID { get; set; } = -1;
        public int? DoctorID { get; set; } = null;
        public DateTime AppointmentDate { get; set; } = DateTime.Now;
        public string Notes { get; set; } = string.Empty;
        public int CreatedByUserID { get; set; } = -1;

        public clsDoctor DoctorInfo {  get; set; }


        // Constructor for creating a new object
        public clsAppointment()
        {
            // تعيين قيم افتراضية للخصائص
            this.AppointmentID = 0; // القيمة الافتراضية للمعرّف
            this.PatientID = 0; // القيمة الافتراضية لمعرف المريض
            this.DoctorID = null; // القيمة الافتراضية للطبيب (null)
            this.AppointmentDate = DateTime.Now; // تاريخ الموعد الافتراضي
            this.Status = enStatus.OnTime; // الحالة الافتراضية
            this.Notes = string.Empty; // ملاحظات فارغة
            this.CreatedByUserID = 0; // القيمة الافتراضية لمعرف المستخدم
            this.Mode = enMode.AddNew; // وضع الإضافة الافتراضي
        }


        // Constructor for initializing an existing object
        private clsAppointment(int appointmentID, int patientID, int? doctorID, DateTime appointmentDate, enStatus status, string notes, int createdByUserID)
        {
            this.AppointmentID = appointmentID;
            this.PatientID = patientID;
            this.DoctorID = doctorID;
            this.AppointmentDate = appointmentDate;
            this.Status = status;
            this.Notes = notes;
            this.CreatedByUserID = createdByUserID;

            Mode = enMode.Update;
        }

        // Retrieve appointment info by ID
        public static clsAppointment GetAppointmentInfoByID(int appointmentID)
        {
            // التحقق المبكر من صلاحية appointmentID
            if (appointmentID <= 0)
            {
                Console.WriteLine("Invalid AppointmentID.");
                return null;
            }

            // القيم الافتراضية في حالة عدم العثور على بيانات
            int patientID = -1, createdByUserID = -1;
            int? doctorID = null;
            DateTime appointmentDate = DateTime.Now;
            byte statusInt = 1; // الحالة الافتراضية كعدد صحيح
            string notes = string.Empty;

            try
            {
                // استرجاع البيانات من قاعدة البيانات
                bool isFound = clsAppointmentData.GetAppointmentByID(
                    appointmentID,
                    ref patientID,
                    ref doctorID,
                    ref appointmentDate,
                    ref statusInt, // استخدام int هنا
                    ref notes,
                    ref createdByUserID
                );

                // إذا تم العثور على الموعد
                if (isFound)
                {
                    // تحويل القيمة العددية إلى enStatus

                    return new clsAppointment(
                        appointmentID,
                        patientID,
                        doctorID,
                        appointmentDate,
                       (enStatus)statusInt,
                        notes,
                        createdByUserID
                    );
                }
                else
                {
                    // في حال عدم العثور على الموعد
                    Console.WriteLine($"Appointment with ID {appointmentID} not found.");
                    return null; // إعادة null بدلاً من رمي استثناء
                }
            }
            catch (Exception ex)
            {
                // طباعة التفاصيل في حال حدوث استثناء
                Console.WriteLine($"Error retrieving appointment with ID {appointmentID}: {ex.Message}");

                // رمي الاستثناء مجددًا مع معلومات إضافية حول مكان المشكلة
                throw new ApplicationException($"An error occurred while retrieving appointment with ID: {appointmentID}", ex);
            }
        }

        // Add a new appointment
        private bool _AddNewAppointment()
        {
            AppointmentID = clsAppointmentData.AddAppointment(this.PatientID, this.DoctorID, this.AppointmentDate,
                (byte)this.Status, this.Notes, this.CreatedByUserID);

            if (AppointmentID != -1)
            {
                Mode = enMode.Update;
                return true;
            }

            return false;
        }

        // Update an existing appointment
        private bool _UpdateAppointment()
        {
            return clsAppointmentData.UpdateAppointment(this.AppointmentID, this.PatientID, this.DoctorID,
                this.AppointmentDate, (byte)this.Status, this.Notes, this.CreatedByUserID);
        }

        // Save the current appointment
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAppointment())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateAppointment();

            }

            return false;
        }


        // Delete an appointment
        public static bool DeleteAppointment(int appointmentID)
        {
            return clsAppointmentData.DeleteAppointment(appointmentID);
        }

        // Retrieve all appointments
        public static DataTable GetAllAppointments()
        {
            return clsAppointmentData.GetAllAppointments();
        }

        // Retrieve appointments by patient ID
        public static DataTable GetAppointmentsByPatientID(int patientID)
        {
            return clsAppointmentData.GetAppointmentsByPatientID(patientID);
        }

        // Retrieve appointments by doctor ID
        public static DataTable GetAppointmentsByDoctorID(int? doctorID)
        {
            return clsAppointmentData.GetAppointmentsByDoctorID(doctorID);
        }

        // Check if an appointment exists
        public static bool IsAppointmentExist(int appointmentID)
        {
            return clsAppointmentData.IsAppointmentExist(appointmentID);
        }


        public static bool UpdateAppointmentStatus(int appointmentID, clsAppointment.enStatus newStatus)
        {
            try
            {
                // تحويل الحالة إلى النوع المناسب لقاعدة البيانات (byte)
                byte statusValue = (byte)newStatus;

                // استدعاء ميثود طبقة البيانات لتحديث الحالة
                bool isUpdated = clsAppointmentData.UpdateAppointmentStatus(appointmentID, statusValue);

                return isUpdated;
            }
            catch (Exception ex)
            {
                // يمكنك تسجيل الخطأ أو معالجته هنا إذا لزم الأمر
                Console.WriteLine($"Error in UpdateAppointmentStatus: {ex.Message}");
                return false;
            }
        }


        public static int? GetAppointmentIDByPatientID(int patientID)
        {
            // استدعاء الدالة من طبقة البيانات
            return clsAppointmentData.GetAppointmentIDByPatientID(patientID);
        }

        // Method to get DoctorID by AppointmentID
        public static int? GetDoctorIDByAppointmentID(int appointmentID)
        {
            // استدعاء الدالة من طبقة البيانات
            return clsAppointmentData.GetDoctorIDByAppointmentID(appointmentID);
        }

        public static clsAppointment GetAppointmentInfoByPatientID(int patientID)
        {
            // تعريف المتغيرات المطلوبة مع تعيين قيم ابتدائية
            int appointmentID = -1;
            int? doctorID = null;
            DateTime appointmentDate = DateTime.MinValue;
            byte statusInt = 1;
            string notes = string.Empty;
            int createdByUserID = -1;

            try
            {
                // استدعاء الدالة لجلب معلومات الموعد
                bool isFound = clsAppointmentData.GetAppointmentByPatientID(
                    patientID,
                    ref appointmentID,
                    ref doctorID,
                    ref appointmentDate,
                    ref statusInt,
                    ref notes,
                    ref createdByUserID);

                // إذا تم العثور على الموعد، ارجع كائن clsAppointment جديد
                if (isFound)
                {
                    return new clsAppointment(
                        appointmentID,
                        patientID,
                        doctorID,
                        appointmentDate,
                       (enStatus)statusInt,
                        notes,
                        createdByUserID
                    );
                }
                else
                {
                    // يمكنك رفع استثناء هنا أو تسجيل رسالة
                    return null; // أو throw new KeyNotFoundException($"Appointment with PatientID {patientID} not found.");
                }
            }
            catch (Exception ex)
            {
                // يمكن تسجيل الاستثناء أو رفعه مرة أخرى لمزيد من المعالجة
                Console.WriteLine($"Error retrieving appointment info: {ex.Message}");
                throw; // إعادة رفع الاستثناء بعد تسجيله
            }
        }


    }
}
