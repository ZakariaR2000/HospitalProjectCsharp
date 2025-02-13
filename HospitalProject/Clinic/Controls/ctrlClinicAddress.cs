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

namespace HospitalProject.Clinic.Controls
{
    public partial class ctrlClinicAddress : UserControl
    {

        private clsClinicAddress _ClinicAddresse;

        private int _ClinicAddresseID = -1;

        public int ClinicAddresseID
        {
            get
            {
                return _ClinicAddresseID;
            }
        }

        public clsClinicAddress ClinicAddresse
        {
            get
            {
                return _ClinicAddresse;
            }
        }


        public ctrlClinicAddress()
        {
            InitializeComponent();
        }

        private void _FillClinicAddressInfo()
        {
            llEditClinicAddress.Enabled = true;
            _ClinicAddresseID = _ClinicAddresse.ClinicAddresseID;
            lblClinicAddresseID.Text = _ClinicAddresse.ClinicAddresseID.ToString();
            lblAddressLine1.Text = _ClinicAddresse.AddressLine1;
            lblAddressLine2.Text = _ClinicAddresse.AddressLine2;
            lblCity.Text = _ClinicAddresse.City;
            lblPostalCode.Text  = _ClinicAddresse.PostalCode;
            // التحقق إذا كانت هناك معلومات للطبيب
            

        }

        public bool LoadClinicAddress(int ClinicAddressID)
        {
            _ClinicAddresse = clsClinicAddress.GetClinicAddressByID(ClinicAddressID);

            if (_ClinicAddresse == null)
            {
                // إعادة قيمة تشير إلى فشل تحميل البيانات
                return false;
            }

            _FillClinicAddressInfo();
            return true; // تم تحميل البيانات بنجاح
        }

        public void ResetClinicAddress()
        {
            _ClinicAddresseID = -1;
            lblClinicAddresseID.Text = "[????]";

            lblAddressLine1.Text = "[????]";
            lblAddressLine2.Text = "[????]";
            lblCity.Text = "[????]";
            lblPostalCode.Text = "[????]";
        }

        private void llEditClinicAddress_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
