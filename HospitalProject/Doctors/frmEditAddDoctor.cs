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

namespace HospitalProject.Doctors
{
    public partial class frmEditAddDoctor : Form
    {
        public enum enMode { AddNew = 0 , Update = 1};
        private enMode _Mode;

        clsDoctor _Doctor;
        private int _DoctorID = -1;
        public frmEditAddDoctor()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmEditAddDoctor(int DoctorID)
        {
            InitializeComponent();
            _DoctorID = DoctorID;
            _Mode = enMode.Update;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LoadData()
        {
            _Doctor = clsDoctor.GetDoctorInfoByID(_DoctorID);

            ctrlPersonCardWithFilter1.FilterEnabled = false;

            if (_Doctor == null)
            {
                MessageBox.Show("No Doctor with ID = " + _DoctorID, "Doctor Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            // Retrieve `PersonInfo` based on `PersonID` in `_Doctor`
            int personID = _Doctor.PersonID; // Assuming `_Doctor` has a `PersonID` property
            if (personID > 0)
            {
                ctrlPersonCardWithFilter1.LoadPersonInfo(personID);
            }
            else
            {
                MessageBox.Show("Person information not available for Doctor ID: " + _DoctorID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithFilter1.SelectedPersonInfo == null ||
                   ctrlPersonCardWithFilter1.SelectedPersonInfo.PersonID == -1)
            {
                MessageBox.Show("Please load the person's information before proceeding.",
                                "Information Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrlPersonCardWithFilter1.FilterFocus(); // إرجاع التركيز على اختيار الشخص
                return;
            }

            if(_Mode==enMode.Update)
            {
                frmCompleteRegistration frm = new frmCompleteRegistration(_DoctorID);
                frm.PersonID = _Doctor.PersonID;
                frm.ShowDialog();
                return;
            }

            if(ctrlPersonCardWithFilter1.SelectedPersonInfo.PersonID!=-1)
            {
                frmCompleteRegistration frm = new frmCompleteRegistration();
                frm.PersonID = ctrlPersonCardWithFilter1.SelectedPersonInfo.PersonID; // تمرير PersonID
                frm.ShowDialog();
            }

            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }
        }

        private void frmEditAddDoctor_Load(object sender, EventArgs e)
        {



            if (_Mode == enMode.Update)
                _LoadData();

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
