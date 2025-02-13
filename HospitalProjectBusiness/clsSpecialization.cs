using HospitalProjectDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProjectBusiness
{
    public class clsSpecialization
    {
        // Properties for Specialization class

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int SpecializationID { get; set; }
        public string SpecializationName { get; set; }

        public clsDoctor DoctorInfo;

        // Constructor 1: Default constructor (parameterless)
        public clsSpecialization()
        {
            // Initialize default values if needed
            SpecializationID = 0;
            SpecializationName = string.Empty;

            Mode = enMode.AddNew;
        }

        // Constructor 2: Parameterized constructor
        public clsSpecialization(int SpecializationID, string SpecializationName)
        {
            this.SpecializationID = SpecializationID;
            this.SpecializationName = SpecializationName;

            Mode = enMode.Update;
        }

        public static clsSpecialization Find(int SpecializationID )
        {
            string SpecializationName = "";

            return clsSpecializationData.GetSpecializationByID(SpecializationID, ref SpecializationName) ?
                new clsSpecialization(SpecializationID, SpecializationName) : null;

        }

        public static clsSpecialization Find(string SpecializationName)
        {
            int SpecializationID = -1;
            Console.WriteLine("Finding specialization for: " + SpecializationName); // طباعة الاسم الذي يتم البحث عنه

            return clsSpecializationData.GetSpecializationByName(SpecializationName, ref SpecializationID) ?
                new clsSpecialization(SpecializationID, SpecializationName) : null;
        }


        // Optionally, you can add methods to the class
        public override string ToString()
        {
            return $"Specialization ID: {SpecializationID}, Name: {SpecializationName}";
        }


        public static DataTable GetAllSpecialization()
        {
            return clsSpecializationData.GetAllSpecializations();
        }

    }

}
