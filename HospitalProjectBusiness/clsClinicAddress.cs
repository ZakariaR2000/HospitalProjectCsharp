using HospitalProjectDataAccess;
using System;
using System.Data;

namespace HospitalProjectBusiness
{
    public class clsClinicAddress
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int ClinicAddresseID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
       // public clsDoctor DoctorInfo;

        // Constructor
        public clsClinicAddress()
        {
            this.ClinicAddresseID = -1;
            this.AddressLine1 = string.Empty;
            this.AddressLine2 = string.Empty;
            this.City = string.Empty;
            this.PostalCode = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsClinicAddress(int ClinicAddresseID, string AddressLine1, string AddressLine2, string City, string PostalCode)
        {
            this.ClinicAddresseID = ClinicAddresseID;
            this.AddressLine1 = AddressLine1;
            this.AddressLine2 = AddressLine2;
            this.City = City;
            this.PostalCode = PostalCode;

            //DataTable doctorsTable = clsDoctor.GetDoctorsByClinicAddress(ClinicAddresseID);
            //if (doctorsTable != null && doctorsTable.Rows.Count > 0)
            //{
            //    // تعيين المعلومات الخاصة بالطبيب
            //    int doctorID = (int)doctorsTable.Rows[0]["DoctorID"];
            //    this.DoctorInfo = clsDoctor.GetDoctorInfoByID(doctorID);
            //}
            //else
            //{
            //    this.DoctorInfo = null; // لا يوجد أطباء مرتبطين
            //}
            Mode = enMode.Update;
        }

        // Method to fetch Clinic Address info by ID
        public static clsClinicAddress GetClinicAddressByID(int ClinicAddresseID)
        {
            string AddressLine1 = string.Empty, AddressLine2 = string.Empty, City = string.Empty, PostalCode = string.Empty;

            // تعديل استدعاء GetClinicAddressByID ليشمل postalCode
            if (clsClinicAddresseData.GetClinicAddressByID(ClinicAddresseID, ref AddressLine1, ref AddressLine2, ref City, ref PostalCode))
            {
                return new clsClinicAddress(ClinicAddresseID, AddressLine1, AddressLine2, City, PostalCode);
            }
            else
            {
                return null;
            }

        }

        // Method to fetch all clinic addresses
        public static DataTable GetAllClinicAddresses()
        {
            return clsClinicAddresseData.GetAllClinicAddresses();
        }

        // Method to add a new clinic address
        private bool _AddNewClinicAddress()
        {

            // Call to AddClinicAddress - include postalCode parameter
            this.ClinicAddresseID = clsClinicAddresseData.AddClinicAddress(this.AddressLine1, this.AddressLine2, this.City, this.PostalCode);

            if (this.ClinicAddresseID != -1)
            {
                Mode = enMode.Update;
                return true;
            }
            return false;
        }

        // Method to update existing clinic address details
        private bool _UpdateClinicAddress()
        {
           

            
            // Call to UpdateClinicAddress - include postalCode parameter
            return clsClinicAddresseData.UpdateClinicAddress(this.ClinicAddresseID, this.AddressLine1, this.AddressLine2, this.City, this.PostalCode);

        }

        // Method to delete a clinic address by ID
        public static bool DeleteClinicAddress(int ClinicAddresseID)
        {
            try
            {
                return clsClinicAddresseData.DeleteClinicAddress(ClinicAddresseID);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Save method
        public bool Save()
        {
            if (Mode == enMode.AddNew)
            {

                return _AddNewClinicAddress();
            }
            else if (Mode == enMode.Update)
            {

                return _UpdateClinicAddress();
            }

            return false;
        }

        // Method to check if a clinic address exists by ID
        public static bool IsClinicAddressExist(int ClinicAddresseID)
        {
            return clsClinicAddresseData.IsClinicAddressExistByID(ClinicAddresseID);
        }
    }
}
