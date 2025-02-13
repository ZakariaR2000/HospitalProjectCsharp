using HospitalProjectDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProjectBusiness
{
    public class clsPatient
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int PatientID { get; set; }
        public int PersonID { get; set; }
        public string PatientNumber { get; set; }
        public string BloodType { get; set; }
        public string Allergies { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? DoctorID { get; set; }

        public clsAppointment AppointmentInfo {  get; set; }

        //public clsDoctor GetDoctorInfo()
        //{
        //    // تحقق إذا كانت DoctorID غير موجودة أو فارغة
        //    if (!DoctorID.HasValue)
        //    {
        //        return null; // إذا لم يكن هناك طبيب محدد
        //    }

        //    // استرجاع بيانات الطبيب باستخدام DoctorID
        //    var doctorInfo = clsDoctor.GetDoctorInfoByID(DoctorID.Value);

        //    return doctorInfo;
        //}

        public clsDoctor GetDoctorInfoByAppointment()
        {
            // الحصول على AppointmentID بناءً على PatientID
            int? appointmentID = clsAppointment.GetAppointmentIDByPatientID(this.PatientID);

            if (!appointmentID.HasValue)
            {
                return null; // إذا لم يكن هناك موعد مرتبط بالمريض
            }

            // استرجاع DoctorID من الميعاد
            int? doctorID = clsAppointment.GetDoctorIDByAppointmentID(appointmentID.Value);

            if (!doctorID.HasValue)
            {
                return null; // إذا لم يكن هناك طبيب مرتبط بالميعاد
            }

            // استرجاع معلومات الطبيب باستخدام DoctorID
            var doctorInfo = clsDoctor.GetDoctorInfoByID(doctorID.Value);

            return doctorInfo;
        }


        public int CreatedByUserID { get; set; }

        public clsPerson PersonInfo;
      //  public clsDoctor DoctorInfo;

        // Constructor
        public clsPatient()
        {
            this.PatientID = -1;
            this.PersonID = -1;
            this.PatientNumber = string.Empty;
            this.BloodType = string.Empty;
            this.Allergies = string.Empty;
            this.CreatedDate = DateTime.Now;
            //this.DoctorID = -1;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsPatient(int patientID, int personID, string patientNumber, string bloodType, string allergies,
            DateTime createdDate, int createdByUserID)
        {
            this.PatientID = patientID;
            this.PersonID = personID;
            this.PatientNumber = patientNumber;
            this.BloodType = bloodType;
            this.Allergies = allergies;
            this.CreatedDate = createdDate;
            // this.DoctorID = doctorID;
            this.AppointmentInfo = clsAppointment.GetAppointmentInfoByPatientID(patientID);
            this.CreatedByUserID = createdByUserID;

            this.PersonInfo = clsPerson.Find(personID);
           // this.DoctorInfo = clsDoctor.GetDoctorInfoByID(doctorID);

            Mode = enMode.Update;
        }

        // Method to fetch Patient info by ID

        //public static clsPatient GetPatientInfoByID(int patientID)
        //{
        //    int personID = -1, doctorID = -1, createdByUserID = -1;
        //    string patientNumber = string.Empty, bloodType = string.Empty, allergies = string.Empty;
        //    DateTime createdDate = DateTime.Now;

        //    if (clsPatientsData.GetPatientByID(patientID, ref personID, ref patientNumber, ref bloodType, ref allergies,
        //        ref createdDate, ref doctorID, ref createdByUserID))
        //    {
        //        return new clsPatient(patientID, personID, patientNumber, bloodType, allergies, createdDate, doctorID, createdByUserID);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public static clsPatient GetPatientInfoByID(int patientID)
        {
            
            // تعريف المتغيرات المطلوبة مع تعيين قيم ابتدائية
            int personID = -1;
            //int? doctorID = -1;
            int createdByUserID = -1;
            string patientNumber = string.Empty;
            string bloodType = string.Empty;
            string allergies = string.Empty;
            DateTime createdDate = DateTime.MinValue; // تعيين قيمة ابتدائية لتاريخ الخلق

            try
            {
                // استدعاء الدالة لجلب معلومات المريض
                bool isFound = clsPatientsData.GetPatientByID(
                    patientID,
                    ref personID,
                    ref patientNumber,
                    ref bloodType,
                    ref allergies,
                    ref createdDate,
                    ref createdByUserID);

                // إذا تم العثور على المريض، ارجع كائن clsPatient جديد
                if (isFound)
                {
                    return new clsPatient(patientID, personID, patientNumber, bloodType, allergies, createdDate, createdByUserID);
                }
                else
                {
                    // يمكنك رفع استثناء هنا أو تسجيل رسالة
                    return null; // أو throw new KeyNotFoundException($"Patient with ID {patientID} not found.");
                }
            }
            catch (Exception ex)
            {
                // يمكن تسجيل الاستثناء أو رفعه مرة أخرى لمزيد من المعالجة
                Console.WriteLine($"Error retrieving patient info: {ex.Message}");
                throw; // إعادة رفع الاستثناء بعد تسجيله
            }
        }







        // Method to add a new patient
        private bool _AddNewPatient()
        {
            // التأكد من أن DoctorID يأخذ القيمة null إذا لم يتم تحديد طبيب
          //  int? doctorID = this.DoctorID > 0 ? this.DoctorID : (int?)null;

            // استدعاء دالة AddPatient مع القيم المعدلة
            this.PatientID = clsPatientsData.AddPatient(
                this.PersonID,
                this.PatientNumber,
                this.BloodType,
                this.Allergies,
                this.CreatedDate,
                this.CreatedByUserID
            );

            if (this.PatientID != -1)
            {
                Mode = enMode.Update;
                return true;
            }
            else
            {
                return false;
            }
        }


        // Method to update existing patient details
        private bool _UpdatePatient()
        {
            try
            {
                return clsPatientsData.UpdatePatient(this.PatientID, this.PersonID, this.PatientNumber, this.BloodType,
                    this.Allergies, this.CreatedDate, this.CreatedByUserID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Method to delete a patient by ID
        public static bool DeletePatient(int patientID)
        {
            try
            {
                return clsPatientsData.DeletePatient(patientID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Method to fetch all patients
        public static DataTable GetAllPatients()
        {
            return clsPatientsData.GetAllPatients();
        }

        public static clsPatient GetPatientInfoByPersonID(int PersonID)
        {
            int patientID = 0;
            string bloodType = "";
            string allergies = "";
            DateTime createdDate = DateTime.MinValue;
          //  int doctorID = 0;
            int createdByUserID = 0;
            string patientNumber = "";

            // استدعاء ميثود الوصول إلى البيانات
            if (clsPatientsData.GetPatientInfoByPersonID(PersonID, ref patientID, ref bloodType, ref allergies,
                ref createdDate, ref createdByUserID, ref patientNumber))
            {
                return new clsPatient(patientID, PersonID, patientNumber, bloodType, allergies, createdDate, createdByUserID);
            }
            return null;
        }




        // Method to check if patient exists by PatientID
        //public static bool IsPatientExist(int patientID)
        //{
        //    return clsPatientsData.IsPatientExistByID(patientID);
        //}

        // Method to save the patient details
        public bool Save()
        {
            if (Mode == enMode.AddNew)
            {
                return _AddNewPatient();
            }
            else if (Mode == enMode.Update)
            {
                return _UpdatePatient();
            }

            return false;
        }

        // Method to fetch patients by doctor
        //public static DataTable GetPatientsByDoctorID(int doctorID)
        //{
        //    return clsPatientsData.GetPatientsByDoctorID(doctorID);
        //}
    }

}



