using HospitalProject.Clinic;
using HospitalProject.Doctors;
using HospitalProjectBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalProject.Patients
{
    public partial class frmCompleteTheEntryProcedures : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        private int _PatientID;
        clsPatient _Patient;

        public clsPatient PatientData { get; set; }


        private int _PersonID;
        clsPerson _Person;

        public int PersonID { get; set; }

        public string FullName { get; set; }
        public int PatientID { get; set; }



        public frmCompleteTheEntryProcedures()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }
        public frmCompleteTheEntryProcedures(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            Mode = enMode.Update;
        }

        
        private void _ResetDefaultValues()
        {

            if (Mode == enMode.AddNew )
            {
                lblTitle.Text = "New Patient";
                this.Text = "New Patient";


                _Patient = new clsPatient();

                _Patient.PersonInfo = new clsPerson(); // إنشاء كائن جديد إذا لم يكن موجودًا

                lblPatientName.Text = !string.IsNullOrEmpty(FullName) ? FullName : "Still.."; // إذا لم يكن هناك اسم
                lblPatientID.Text = PatientID > 0 ? PatientID.ToString() : "Still.."; // إذا لم يكن هناك PatientID


            }
        }


        private void _LoadData()
        {
            if (PatientData == null)
            {
                MessageBox.Show("Patient data not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // تحميل بيانات المريض
            lblPatientID.Text = PatientData.PatientID.ToString();
            lblPatientName.Text = PatientData.PersonInfo?.FullName ?? "Unknown";
            txtPatientNum.Text = PatientData.PatientNumber;
            cmBloodType.Text = PatientData.BloodType;
            dtpCreatedDate.Value = PatientData.CreatedDate;
            lblCreatedByUser.Text = "User1";
            txtAllergies.Text = PatientData.Allergies;

            // تحميل معلومات الطبيب المرتبط بالمريض
            //var doctorInfo = PatientData?.GetDoctorInfo();
            //if (doctorInfo != null)
            //{
            //    lblDoctorID.Text = doctorInfo.DoctorID.ToString();
            //    var personInfo = clsPerson.Find(doctorInfo.PersonID);
            //    lblDoctorName.Text = personInfo?.FullName ?? "Name not available";
            //    lblClinicAddress.Text = doctorInfo.clinicAddressInfo?.AddressLine1 ?? "Clinic Address Not Available";
            //    lblSpecialization.Text = doctorInfo.SpecializationInfo?.SpecializationName ?? "Unknown Specialization";

            //    btnChangeDoctor.Visible = true;
            //    btnAddDoctro.Visible = false;
            //}
            //else
            //{
            //    lblDoctorID.Text = "No Doctor Assigned";
            //    lblDoctorName.Text = "No Doctor Assigned";
            //    lblClinicAddress.Text = "No Clinic Address";

            //    btnAddDoctro.Visible = true;
            //    btnChangeDoctor.Visible = false;
            //}
        }

        private void frmCompleteTheEntryProcedures_Load(object sender, EventArgs e)
        {


            if (PatientData == null)
            {
                PatientData = new clsPatient(); // Create a new instance for a new patient
            }

            if (Mode == enMode.Update && PatientData != null)
            {
                _LoadData();

            }

            else
            {
                _ResetDefaultValues();

               
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PatientData.CreatedDate = DateTime.Now;
            PatientData.CreatedByUserID = 1;
            PatientData.Allergies = txtAllergies.Text;
            PatientData.BloodType = cmBloodType.Text;
            PatientData.PatientNumber = txtPatientNum.Text;
            
                PatientData.PersonID = PersonID;


           

            if (PatientData.Save())
            {
                MessageBox.Show("Patient Data Saved Successfully.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mode = enMode.Update;
                lblTitle.Text = "Update Patient";
            }
            else
            {
                MessageBox.Show("Error: Data is not saved successfully.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        
    }
}
