using HospitalProjectDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProjectBusiness
{
    public class clsDoctor
    {

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int DoctorID { get; set; }
        public int PersonID { get; set; }
        public int? ClinicAddressID { get; set; } // Nullable
        public int SpecializationID { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
        public decimal Salary {  get; set; }
        public int CreatedByUserID {  get; set; }

      //  public clsPerson PersonInfo {  get; set; }
        public clsSpecialization SpecializationInfo { get; set; }
         public clsClinicAddress clinicAddressInfo {  get; set; }

        //private Lazy<clsClinicAddress> _clinicAddressInfo = new Lazy<clsClinicAddress>(() => new clsClinicAddress());

        //public clsClinicAddress clinicAddressInfo
        //{
        //    get { return _clinicAddressInfo.Value; }
        //    set { _clinicAddressInfo = new Lazy<clsClinicAddress>(() => value); }
        //}


        // Constructor
        public clsDoctor() 
        {
            this.DoctorID = -1;
            this.PersonID = -1;
            this.ClinicAddressID = null;
            this.SpecializationID = -1;
            this.HireDate = DateTime.Now;
            this.IsActive = false;
            this.CreatedByUserID = -1;
            this.Salary = 0;

            Mode = enMode.AddNew;
        }

        private clsDoctor(int DoctroID , int PersonID , int? ClinicAddressID ,
            int Specialization , DateTime HireDate , bool IsActive, int CreatedByUserID, decimal Salary)
        {
            this.DoctorID = DoctroID;
            this.PersonID = PersonID;
            this.ClinicAddressID = ClinicAddressID;
            this.SpecializationID = Specialization;
            this.HireDate = HireDate;
            this.IsActive = IsActive;
           // this.PersonInfo = clsPerson.Find(PersonID);
            this.SpecializationInfo = clsSpecialization.Find(SpecializationID);
            this.clinicAddressInfo =
                clsClinicAddress.GetClinicAddressByID(ClinicAddressID.GetValueOrDefault());
            this.Salary = Salary;
            this.CreatedByUserID = CreatedByUserID;
            Mode = enMode.Update;
        }

        // Method to fetch Doctor info by ID
        public static clsDoctor GetDoctorInfoByID(int? DoctorID)
        {
            if (DoctorID == null || DoctorID <= 0)
            {
                return null; // إذا كانت القيمة null أو غير صالحة
            }

            int PersonID = -1, CreatedByUserID = -1, Specialization = -1;
            int? ClinicAddressID = null;
            DateTime HireDate = DateTime.Now;
            bool IsActive = false;
            decimal Salary = 0;

            if (clsDoctorData.GetDoctorInfoByID(DoctorID.Value, ref PersonID, ref ClinicAddressID,
                ref Specialization, ref HireDate, ref IsActive, ref CreatedByUserID, ref Salary))
            {
                return new clsDoctor(DoctorID.Value, PersonID, ClinicAddressID, Specialization, HireDate, IsActive, CreatedByUserID, Salary);
            }
            else
            {
                return null;
            }
        }

        //public static clsDoctor GetDoctorInfoByID(int doctorID)
        //{
        //    int personID = -1, createdByUserID = -1, specializationID = -1;
        //    int? clinicAddressID = null;
        //    DateTime hireDate = DateTime.Now;
        //    bool isActive = false;
        //    decimal salary = 0;

        //    if (clsDoctorData.GetDoctorInfoByID(doctorID, ref personID, ref clinicAddressID,
        //        ref specializationID, ref hireDate, ref isActive, ref createdByUserID, ref salary))
        //    {
        //        clsDoctor doctor = new clsDoctor(doctorID, personID, clinicAddressID, specializationID, hireDate, isActive, createdByUserID, salary);

        //        // فقط عندما تحتاج إلى اسم الشخص أو بياناته الأخرى، قم بتحميل PersonInfo
        //        doctor.PersonInfo = clsPerson.Find(personID);  // هذا استدعاء خارجي ولن يؤدي إلى استدعاء متبادل

        //        return doctor;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}



        // Method to fetch Doctor info by National Number

        // Method to add a new doctor
        private bool _AddNewDoctor()
        {


            this.DoctorID = clsDoctorData.AddDoctor(this.PersonID, this.ClinicAddressID, this.SpecializationID, this.HireDate,
                this.IsActive, this.CreatedByUserID, this.Salary);

            if (this.DoctorID != -1)
            {
                Mode = enMode.Update;
                return true;
            }
            else
            {
                return false; // هنا يجب التأكد من معالجة الخطأ إذا لم يتم إرجاع DoctorID
            }

        }

        // Method to update existing doctor details
        private  bool _UpdateDoctor()
        {
            try
            {

                return clsDoctorData.UpdateDoctor(this.DoctorID, this.PersonID, this.ClinicAddressID,
                    this.SpecializationID, this.HireDate, this.IsActive ,this.CreatedByUserID, this.Salary);
            }
            catch (Exception ex)
            {
                // Handle exceptions

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Method to delete a doctor by ID
        public static bool DeleteDoctor(int doctorID)
        {
            try
            {
                return clsDoctorData.DeleteDoctor(doctorID);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Method to fetch all doctors
        public static DataTable GetAllDoctors()
        {
             return clsDoctorData.GetAllDoctors();
            
            
        }

        public bool Save()
        {
            if (Mode == enMode.AddNew)
            {

                return _AddNewDoctor();
            }
            else if (Mode == enMode.Update)
            {
                return _UpdateDoctor();
            }

            return false;
        }

        public static bool IsDoctorExist(int DoctorID)
        {
            return clsDoctorData.IsDoctorExistByID(DoctorID);
        }

        public static bool IsDoctorExist(string NationalNo)
        {
            return clsDoctorData.IsDoctorExistByNationalNo(NationalNo);
        }
        public static DataTable GetDoctorsByClinicAddress(int clinicAddressID)
        {
            // استرجاع بيانات الأطباء من DataAccess
            return clsDoctorData.GetDoctorInfoByClinicAddresseID(clinicAddressID);
        }


        public static int? GetDoctorIDByClinicAddress(int clinicAddressID)
        {
            return clsDoctorData.GetDoctorIDByClinicAddress(clinicAddressID);
        }

        

    }


}
