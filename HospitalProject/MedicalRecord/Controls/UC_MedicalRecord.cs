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

namespace HospitalProject.MedicalRecord.Controls
{
    public partial class UC_MedicalRecord : UserControl
    {
        private clsMedicalRecord _MedicalRecord;
        private clsPatient _Patient;
        private clsDoctor _Doctor;

        private int _PatientID;
        private int _DoctorID;





        private int _MedicalRecordID;

        public int MedicalRecordID
        {
            get
            {
                return _MedicalRecordID;
            }
        }

        public clsMedicalRecord SelectedMedicalRecordInfo
        {
            get
            {
                return _MedicalRecord;
            }
        }
        public UC_MedicalRecord()
        {
            InitializeComponent();
        }

        public void ResetMedicalRecord()
        {
            _MedicalRecordID = -1;
            lblTreatment.Text = "[????]";
            lblPatientID.Text = "[????]";
            lblDoctorID.Text = "[????]";
            lblRecordDate.Text = "[????]";
            lblDiagnosis.Text = "[????]";
            lblCreatedByUserID.Text = "[????]";

        }

        private void _FillMedicalRecordInfo()
        {
            if (_MedicalRecord == null)
            {
                MessageBox.Show("No valid MedicalRecord data to display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _MedicalRecordID = _MedicalRecord.MedicalRecordID;

            lblRecordID.Text = _MedicalRecordID.ToString();


           // _PatientID = _Patient.PatientID;
            lblPatientID.Text = clsPatient.GetPatientInfoByID(_MedicalRecord.PatientID).ToString();
           // _DoctorID = _Doctor.DoctorID;
            lblDoctorID.Text = clsDoctor.GetDoctorInfoByID(_MedicalRecord.DoctorID).ToString();
            lblPatientID.Text = _Patient.PatientID.ToString();
            lblDoctorID.Text = _Doctor.DoctorID.ToString();

            lblTreatment.Text = _MedicalRecord.TreatmentPlan;
            lblRecordDate.Text = _MedicalRecord.RecordDate.ToString();
            lblDiagnosis.Text = _MedicalRecord.Diagnosis;
            lblCreatedByUserID.Text = _MedicalRecord.CreatedByUserID.ToString();




           


        }


        public void LoadPersonInfo(int MedicalRecordID)
        {
            _MedicalRecord = clsMedicalRecord.GetMedicalRecordByID(MedicalRecordID);

            if (_MedicalRecord == null)
            {
                ResetMedicalRecord();
                MessageBox.Show("No Person with MedicalRecordID = " + MedicalRecordID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillMedicalRecordInfo();
        }



    }
}
