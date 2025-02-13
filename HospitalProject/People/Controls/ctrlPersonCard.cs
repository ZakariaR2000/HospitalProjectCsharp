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
using static HospitalProject.People.frmAddUpdatePerson;

namespace HospitalProject.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        private clsPerson _Person;

        private int _PersonID = -1;
        public int PersonID
        {
            get
            {
                return _PersonID;
            }
        }

        public clsPerson SelectedPersonInfo
        {
            get
            {
                return _Person;
            }
        }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPerosnID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblFullName.Text = "[????]";
            lblGendor.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbPersonImage.Image = Resources.icons8_manager_48;
        }

        private void _LoadPersonImage()
        {
            if (_Person.Gender == 0)
                pbPersonImage.Image = Resources.icons8_male_64;
            else
                pbPersonImage.Image = Resources.icons8_female_64;

            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        //From Object to lable
        //private void _FillPersonInfo()
        //{
        //    llEdetPeronInfo.Enabled = true;
        //    _PersonID = _Person.PersonID;
        //    lblPerosnID.Text = _Person.PersonID.ToString();
        //    lblNationalNo.Text = _Person.NationalNo;
        //    lblFullName.Text = _Person.FullName;
        //    lblGendor.Text = _Person.Gender == 0 ? "Male" : "Female";
        //    lblEmail.Text = _Person.Email;
        //    lblPhone.Text = _Person.Phone;
        //    lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
        //    lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
        //    lblAddress.Text = _Person.Address;
        //    _LoadPersonImage();
        //}

        private void _FillPersonInfo()
        {
            if (_Person == null)
            {
                MessageBox.Show("No valid person data to display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            llEdetPeronInfo.Enabled = true;
            _PersonID = _Person.PersonID;
            lblPerosnID.Text = _Person.PersonID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            lblFullName.Text = _Person.FullName;
            lblGendor.Text = _Person.Gender == 0 ? "Male" : "Female";
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            lblAddress.Text = _Person.Address;
            _LoadPersonImage();
        }



        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with NationalNo = " + NationalNo.ToString(), 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        private void llEdetPeronInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();

            LoadPersonInfo(_PersonID);
        }
    }
}
