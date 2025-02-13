using HospitalProjectDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProjectBusiness
{
    public class clsMedicalRecord
    {
        // Enum for mode (Add or Update)
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode { get; set; } = enMode.AddNew;

        // Enum for record status
        public enum enStatus { Active = 1, Inactive = 2 }

        

        // Properties
        public int MedicalRecordID { get; set; } = -1;
        public int PatientID { get; set; } = -1;
        public int? DoctorID { get; set; } = null;
        public string Diagnosis { get; set; } = string.Empty;
        public string TreatmentPlan { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;

        public DateTime RecordDate { get; set; } = DateTime.Now;
        public int CreatedByUserID { get; set; } = -1;

        // Constructor for new records
        public clsMedicalRecord()
        {
            this.MedicalRecordID = 0;
            this.PatientID = 0;
            this.DoctorID = null;
            this.Diagnosis = string.Empty;
            this.TreatmentPlan = string.Empty;
            this.RecordDate = DateTime.Now;
            this.CreatedByUserID = 0;
            this.Mode = enMode.AddNew;
        }

        // Constructor for existing records
        private clsMedicalRecord(int medicalRecordID, int patientID, int? doctorID, string diagnosis, string treatmentPlan, DateTime recordDate, int createdByUserID)
        {
            this.MedicalRecordID = medicalRecordID;
            this.PatientID = patientID;
            this.DoctorID = doctorID;
            this.Diagnosis = diagnosis;
            this.TreatmentPlan = treatmentPlan;
            this.RecordDate = recordDate;
            this.CreatedByUserID = createdByUserID;
            this.Mode = enMode.Update;
        }

        // Retrieve medical record by ID
        public static clsMedicalRecord GetMedicalRecordByID(int medicalRecordID)
        {
            if (medicalRecordID <= 0)
                return null;

            int patientID = -1, createdByUserID = -1;
            int? doctorID = null;
            string diagnosis = string.Empty, treatmentPlan = string.Empty;
            DateTime recordDate = DateTime.Now;

            bool isFound = clsMedicalRecordData.GetMedicalRecordByID(
                medicalRecordID,
               ref patientID,
               ref doctorID,
               ref recordDate,
               ref diagnosis,
               ref treatmentPlan,
               ref createdByUserID
               
            );

            if (isFound)
            {
                return new clsMedicalRecord(
                    medicalRecordID,
                    patientID,
                    doctorID,
                    diagnosis,
                    treatmentPlan,
                    recordDate,
                    createdByUserID
                );
            }

            return null;
        }

        // Add a new medical record
        private bool _AddNewMedicalRecord()
        {
            MedicalRecordID = clsMedicalRecordData.AddMedicalRecord(
                this.PatientID,
                this.DoctorID,
                this.RecordDate,
                this.Diagnosis,
                this.TreatmentPlan,
                this.CreatedByUserID
            );

            if (MedicalRecordID != -1)
            {
                Mode = enMode.Update;
                return true;
            }

            return false;
        }

        // Update an existing medical record
        private bool _UpdateMedicalRecord()
        {
            return clsMedicalRecordData.UpdateMedicalRecord(
                this.MedicalRecordID,
                this.PatientID,
                this.DoctorID,
                this.RecordDate,
                this.Diagnosis,
                this.TreatmentPlan,
                this.CreatedByUserID
            );
        }

        // Save the medical record
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    return _AddNewMedicalRecord();
                case enMode.Update:
                    return _UpdateMedicalRecord();
                default:
                    return false;
            }
        }


        // Delete a medical record
        public static bool DeleteMedicalRecord(int medicalRecordID)
        {
            return clsMedicalRecordData.DeleteMedicalRecord(medicalRecordID);
        }

        // Retrieve all medical records
        public static DataTable GetAllMedicalRecords()
        {
            return clsMedicalRecordData.GetAllMedicalRecords();
        }

        // Retrieve records by patient ID
        public static DataTable GetMedicalRecordsByPatientID(int patientID)
        {
            return clsMedicalRecordData.GetMedicalRecordsByPatientID(patientID);
        }

        // Check if a medical record exists
        public static bool IsMedicalRecordExist(int medicalRecordID)
        {
            return clsMedicalRecordData.IsMedicalRecordExist(medicalRecordID);
        }
    }
}
