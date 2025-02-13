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
    public partial class frmEditAddPatient : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;


        clsPatient _Patient;
        private int _PatientID;

        clsPerson _Person;
        private int _PersonID;

        public frmEditAddPatient()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmEditAddPatient(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _PatientID = PersonID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LoadData()
        {
            //_Person = clsPerson.Find(_PersonID);
            _Patient = clsPatient.GetPatientInfoByID(_PatientID);

            ctrlPersonCardWithFilter1.FilterEnabled = false;

            if (_Patient == null)
            {
                MessageBox.Show("No Patient with ID = " + _PersonID, "Patient Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_Patient.PersonInfo.PersonID);
            btnCompleteTheEntry.Text = "Edit";
            btnCompleteTheEntry.Width = 85;




        }

        private void btnCompleteTheEntry_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithFilter1.SelectedPersonInfo == null ||
       ctrlPersonCardWithFilter1.SelectedPersonInfo.PersonID == -1)
            {
                MessageBox.Show("Please load the person's information before proceeding.",
                                "Information Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrlPersonCardWithFilter1.FilterFocus();
                return;
            }

            int selectedPersonID = ctrlPersonCardWithFilter1.SelectedPersonInfo.PersonID;
            string selectedFullName = ctrlPersonCardWithFilter1.SelectedPersonInfo.FullName;

            if (_Mode == enMode.Update)
            {
                frmCompleteTheEntryProcedures frm = new frmCompleteTheEntryProcedures();
                frm.PatientData = _Patient; // تمرير الكائن _Patient إلى frmCompleteTheEntryProcedures
                frm.PersonID = _Patient.PersonInfo.PersonID;
                frm.FullName = selectedFullName;
                frm.Mode = frmCompleteTheEntryProcedures.enMode.Update; // تحديد وضع التحديث
                frm.ShowDialog();
                return;
            }

            // وضع الإضافة
            frmCompleteTheEntryProcedures newFrm = new frmCompleteTheEntryProcedures();
            newFrm.PersonID = selectedPersonID;
            newFrm.FullName = selectedFullName;
            newFrm.ShowDialog();
        }

        private void frmEditAddPatient_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
                _LoadData();

            
        }
    }
}
