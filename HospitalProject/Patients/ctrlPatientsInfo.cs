using HospitalProject.Doctors;
using HospitalProject.Properties;
using HospitalProjectBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalProject.Patients
{
    public partial class ctrlPatientsInfo : UserControl
    {
        private int _PatientID;
        private clsPatient _Patient;
        public ctrlPatientsInfo()
        {
            InitializeComponent();
        }


        public int PatientID
        {
            get
            {
                return _PatientID;
            }
        }
        public clsPatient SelectedPatient
        {
            get
            {
                return _Patient;
            }
        }

        private void _LoadPersonImage()
        {
            if (_Patient.PersonInfo.Gender == 0)
                pbPersonImage.Image = Resources.icons8_male_64;
            else
                pbPersonImage.Image = Resources.icons8_female_64;

            string ImagePath = _Patient.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }


        public void LoadInfo(int PatientID)
        {
            _PatientID = PatientID;


            _Patient = clsPatient.GetPatientInfoByID(PatientID);

            if (_Patient == null)
            {
                MessageBox.Show("Could not find Patient ID = " + _PatientID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _PatientID = -1;
                return;
            }

            lblPatientID.Text = _PatientID.ToString();
            lblPatientName.Text = _Patient.PersonInfo.FullName;
            lblPatientNumber.Text = _Patient.PatientNumber;
            lblBloodType.Text = _Patient.BloodType;
            lblAllergies.Text = _Patient.Allergies;
            lblCreatedDate.Text = _Patient.CreatedDate.ToString();

            _LoadPersonImage();
        }

        

        private void llDoctorInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (_Patient.DoctorInfo != null && _Patient.DoctorInfo.DoctorID>0)
            //{
            //    // إذا كان DoctorID يحتوي على قيمة صالحة
            //    frmDoctorInfo frm = new frmDoctorInfo(_Patient.DoctorInfo.DoctorID);
            //    frm.ShowDialog();
            //}
            //else
            //{
            //    // عرض رسالة إذا لم يتم تعيين طبيب للمريض
            //    MessageBox.Show("No doctor assigned to this patient.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            if (_Patient.AppointmentInfo != null && _Patient.AppointmentInfo.DoctorInfo.DoctorID > 0)
            {
                // إذا كان DoctorID يحتوي على قيمة صالحة
                frmDoctorInfo frm = new frmDoctorInfo(_Patient.AppointmentInfo.DoctorInfo.DoctorID);
                frm.ShowDialog();
            }
            else
            {
                // عرض رسالة إذا لم يتم تعيين طبيب للمريض
                MessageBox.Show("No doctor assigned to this patient.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
