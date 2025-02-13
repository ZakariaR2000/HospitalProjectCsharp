using HospitalProject.Doctors;
using HospitalProject.Patients;
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

namespace HospitalProject.MedicalRecord
{
    public partial class frmAddEditMedicalRecord : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;


        private int _RecordID = -1;
        clsMedicalRecord _MedicalRecord;


        public frmAddEditMedicalRecord()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddEditMedicalRecord(int RecordID)
        {
            InitializeComponent();
            _RecordID = RecordID;
            _Mode = enMode.Update;
        }

        private void _ResetDefualtValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Person";
                _MedicalRecord = new clsMedicalRecord();
            }

            else
            {
                lblTitle.Text = "Update Person";
                btnAddDoctor.Visible = false;
                btnAddPatient.Visible = false;
            }

            txtDiagnosis.Text = "";
            txtTreatment.Text = "";
        }


        //In Order To Update
        private void _LoadData()
        {
            _MedicalRecord = clsMedicalRecord.GetMedicalRecordByID(_RecordID);

            if (_MedicalRecord == null) // تحقق مما إذا لم يتم العثور على الشخص
            {
                MessageBox.Show("No Medical Record with ID = " + _RecordID, "Medical Record Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close(); // إغلاق الفورم إذا لم يتم العثور على الشخص
                return;
            }

            lblRecordID.Text = _RecordID.ToString();
            lblPatientID.Text = _MedicalRecord.PatientID.ToString();
            lblDoctorID.Text = _MedicalRecord?.DoctorID.ToString();
            lblCreatedByUserID.Text = _MedicalRecord.CreatedByUserID.ToString();
            txtDiagnosis.Text = _MedicalRecord?.Diagnosis.ToString();
            txtTreatment.Text  = _MedicalRecord?.TreatmentPlan.ToString();


        }
        private void frmAddEditMedicalRecord_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _MedicalRecord.Diagnosis = txtDiagnosis.Text;
            _MedicalRecord.TreatmentPlan = txtTreatment.Text;
            _MedicalRecord.DoctorID = int.Parse(lblDoctorID.Text);
            _MedicalRecord.PatientID = int.Parse(lblPatientID.Text);
            _MedicalRecord.CreatedByUserID = 1;
           // _MedicalRecord.MedicalRecordID = _RecordID;



            if(_MedicalRecord.Save())
            {
                lblRecordID.Text = _MedicalRecord.MedicalRecordID.ToString();

                _Mode = enMode.Update;

                lblTitle.Text = "Update Record";

                MessageBox.Show("Data Saved Successfully.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);


                DataBack?.Invoke(this, _RecordID);
            }

            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            frmListPatients frm = new frmListPatients();

            if (frm.ShowDialog() == DialogResult.OK && frm.SelectedPatient != null)
            {
                lblPatientID.Text = frm.SelectedPatient.PatientID.ToString();
                btnAddPatient.Visible = false; // إخفاء الزر بعد التحديد
            }
            
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            frmListDoctros frm = new frmListDoctros();
            frm.IsCalledByMedicalRecord = true; // ✅ تحديد أن الاستدعاء من السجل الطبي

            if (frm.ShowDialog() == DialogResult.OK && frm.SelectedDoctor != null)
            {
                lblDoctorID.Text = frm.SelectedDoctor.DoctorID.ToString();
                btnAddDoctor.Visible = false; // ✅ إخفاء الزر بعد تحديد طبيب
            }
            else
            {
                MessageBox.Show("يرجى تحديد طبيب من القائمة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
