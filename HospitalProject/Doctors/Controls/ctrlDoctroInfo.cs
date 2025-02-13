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

namespace HospitalProject.Doctors.Controls
{
    public partial class ctrlDoctroInfo : UserControl
    {
        private int _DoctorID;
        private clsDoctor _Doctor;
        public ctrlDoctroInfo()
        {
            InitializeComponent();
        }


        public int DoctorID
        {
            get
            {
                return _DoctorID;
            }
        }

        public clsDoctor SelectedDoctor
        {
            get
            {
                return _Doctor;
            }
        }


        private void _LoadPersonImage()
        {
            if (_Doctor == null)
            {
                MessageBox.Show("Doctor information not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Retrieve `clsPerson` data based on `_Doctor.PersonID`
            var personInfo = clsPerson.Find(_Doctor.PersonID); // Assume a `Find` method exists in `clsPerson` class

            if (personInfo != null)
            {
                // Set image based on gender
                if (personInfo.Gender == 0)
                    pbPersonImage.Image = Resources.icons8_male_64;
                else
                    pbPersonImage.Image = Resources.icons8_female_64;

                // Load person image if available
                string imagePath = personInfo.ImagePath;
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    pbPersonImage.Load(imagePath);
                else
                    MessageBox.Show("Could not find this image: " + imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Person information not available for Doctor ID: " + _Doctor.DoctorID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void LoadInfo(int DoctorID)
        {
            _DoctorID = DoctorID;
            _Doctor = clsDoctor.GetDoctorInfoByID(DoctorID);

            if (_Doctor == null)
            {
                MessageBox.Show("Could not find Doctor ID = " + _DoctorID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _DoctorID = -1;
                return;
            }

            // Retrieve `clsPerson` data separately using PersonID from `_Doctor`
            var personInfo = clsPerson.Find(_Doctor.PersonID); // Assuming a `Find` method exists

            if (personInfo != null)
            {
                lblFullName.Text = personInfo.FullName;
                lblAddress.Text = personInfo.Address;
                lblPhone.Text = personInfo.Phone;
                lblCountry.Text = personInfo.CountryInfo.CountryName;
                lblEmail.Text = personInfo.Email;

                
            }
            else
            {
                MessageBox.Show("Person information not available for Doctor ID = " + _DoctorID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblSpecialization.Text = _Doctor.SpecializationInfo.SpecializationName;

            _LoadPersonImage();
        }
    }
}
