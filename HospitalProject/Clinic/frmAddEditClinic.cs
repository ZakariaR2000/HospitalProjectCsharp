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

namespace HospitalProject.Clinic
{
    public partial class frmAddEditClinic : Form
    {
        public int? NewClinicAddressID { get; private set; } // خاصية لإرجاع ClinicAddressID بعد الحفظ

        private clsClinicAddress _ClinicAddress;
        private bool _IsUpdateMode;

        public frmAddEditClinic()
        {
            InitializeComponent();
            _ClinicAddress = new clsClinicAddress();
            _IsUpdateMode = false; // في حالة الإضافة
        }

        public frmAddEditClinic(int clinicAddressID) // استدعاء النموذج للتعديل
        {
            InitializeComponent();
            _ClinicAddress = clsClinicAddress.GetClinicAddressByID(clinicAddressID);
            _IsUpdateMode = true; // في حالة التعديل
            _LoadClinicAddressData(); // تحميل بيانات العيادة الحالية
        }

        private void _LoadClinicAddressData()
        {
            if (_ClinicAddress != null)
            {
                txtAddressLine1.Text = _ClinicAddress.AddressLine1;
                txtAddressLine2.Text = _ClinicAddress.AddressLine2;
                txtCity.Text = _ClinicAddress.City;
                txtPostalCode.Text = _ClinicAddress.PostalCode;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // التحقق من الإدخالات
            if (string.IsNullOrEmpty(txtAddressLine1.Text) || string.IsNullOrEmpty(txtCity.Text) || string.IsNullOrEmpty(txtPostalCode.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // تعيين القيم للـ ClinicAddress
            _ClinicAddress.AddressLine1 = txtAddressLine1.Text;
            _ClinicAddress.AddressLine2 = txtAddressLine2.Text;
            _ClinicAddress.City = txtCity.Text;
            _ClinicAddress.PostalCode = txtPostalCode.Text;

            // حفظ البيانات
            if (_ClinicAddress.Save())
            {
                NewClinicAddressID = _ClinicAddress.ClinicAddresseID; // حفظ ClinicAddressID الجديد أو المعدل
                MessageBox.Show(_IsUpdateMode ? "Clinic Address updated successfully." : "Clinic Address added successfully.");
                this.DialogResult = DialogResult.OK;
                this.Close(); // إغلاق النموذج بعد الحفظ بنجاح
            }
            else
            {
                MessageBox.Show("Error saving clinic address. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
