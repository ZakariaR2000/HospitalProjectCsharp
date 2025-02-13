using HospitalProject.Clinic;
using HospitalProject.People.Controls;
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
    public partial class frmCompleteRegistration : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        private int _DoctorID = -1;
        clsDoctor _Doctor;
        public int PersonID { get; set; }

        private clsClinicAddress _ClinicAddress;

        public frmCompleteRegistration()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmCompleteRegistration(int DoctorID)
        {
            InitializeComponent();
            _DoctorID = DoctorID;
            _Mode = enMode.Update;
        }

        private void _FillSpecializationInComboBox()
        {
            DataTable dtSpecialization = clsSpecialization.GetAllSpecialization();

            foreach (DataRow dr in dtSpecialization.Rows)
            {
                cbSpecialization.Items.Add(dr["SpecializationName"]);
            }
        }

        private void _ResetDefaultValues()
        {
            _FillSpecializationInComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "New Doctor";
                this.Text = "New Doctor";
                lblHireDate.Text = DateTime.Now.ToString();

                _Doctor = new clsDoctor();
                _ClinicAddress = new clsClinicAddress();

                txtAddressLine1.Text = "";
                txtAddressLine2.Text = "";
                txtCity.Text = "";
                txtPostalCode.Text = "";

                btnAddClinicAddress.Visible = true;
                btnEditClinicAddress.Visible = false;
                btnDeleteClinicAddress.Visible = false;
            }
            else
            {
                lblTitle.Text = "Update Doctor";
                this.Text = "Update Doctor";

                btnSave.Enabled = true;
            }
        }

        private void _LoadData()
        {
            _Doctor = clsDoctor.GetDoctorInfoByID(_DoctorID);

            if (_Doctor == null)
            {
                MessageBox.Show("No Doctor with ID = " + _DoctorID, "Doctor Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lblDoctorID.Text = _Doctor.DoctorID.ToString();
            lblHireDate.Text = _Doctor.HireDate.ToString();
            cbSpecialization.SelectedIndex = cbSpecialization.FindString(clsSpecialization.Find(_Doctor.SpecializationID).SpecializationName);
            txtSalary.Text = _Doctor.Salary.ToString();
            lblCreatedByUser.Text = "1";

            if (_Doctor.ClinicAddressID.HasValue)
            {
                _ClinicAddress = clsClinicAddress.GetClinicAddressByID(_Doctor.ClinicAddressID.Value);
                if (_ClinicAddress != null)
                {
                    txtAddressLine1.Text = _ClinicAddress.AddressLine1;
                    txtAddressLine2.Text = _ClinicAddress.AddressLine2;
                    txtCity.Text = _ClinicAddress.City;
                    txtPostalCode.Text = _ClinicAddress.PostalCode;
                    lblClinicAddressID.Text = _ClinicAddress.ClinicAddresseID.ToString();

                    btnAddClinicAddress.Visible = false;
                    btnEditClinicAddress.Visible = true;
                    btnDeleteClinicAddress.Visible = true;
                }
            }
            else
            {
                _ClinicAddress = new clsClinicAddress();
                btnAddClinicAddress.Visible = true;
                btnEditClinicAddress.Visible = false;
                btnDeleteClinicAddress.Visible = false;
            }
        }

        private void frmCompleteRegistration_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            // حفظ بيانات الطبيب
            DateTime hireDate;
            if (DateTime.TryParse(lblHireDate.Text, out hireDate))
            {
                _Doctor.HireDate = hireDate;
            }

            if (cbSpecialization.SelectedItem != null)
            {
                string specializationName = cbSpecialization.SelectedItem.ToString();
                Console.WriteLine("Selected Specialization: " + specializationName); // طباعة الاسم المحدد
                clsSpecialization specialization = clsSpecialization.Find(specializationName);

                if (specialization != null)
                {
                    _Doctor.SpecializationID = specialization.SpecializationID;
                }
                else
                {
                    MessageBox.Show("Specialization not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a specialization.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            decimal salary;
            if (decimal.TryParse(txtSalary.Text, out salary))
            {
                _Doctor.Salary = salary;
            }

            _Doctor.CreatedByUserID = 1;
            _Doctor.PersonID = PersonID;
            _Doctor.IsActive = true;
            _Doctor.ClinicAddressID = _Doctor.ClinicAddressID;

            // إذا لم يكن هناك ClinicAddressID، لا تحاول حفظ العنوان
            if (_Doctor.ClinicAddressID.HasValue)
            {
                _ClinicAddress.AddressLine1 = txtAddressLine1.Text;
                _ClinicAddress.AddressLine2 = txtAddressLine2.Text;
                _ClinicAddress.City = txtCity.Text;
                _ClinicAddress.PostalCode = txtPostalCode.Text;

                bool isSaved = _ClinicAddress.Save();
                if (!isSaved)
                {
                    MessageBox.Show("Error: Clinic address could not be saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                _Doctor.ClinicAddressID = null; // تأكيد أن الطبيب ليس له عنوان عيادة
            }

            bool isDoctorSaved = _Doctor.Save();
            if (isDoctorSaved)
            {
                MessageBox.Show("Doctor Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = enMode.Update;
                lblTitle.Text = "Update Doctor";
            }
            else
            {
                MessageBox.Show("Error: Data is not saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControlDoctor.SelectedTab = tpClinicInfo;
        }

        private void btnAddClinicAddress_Click(object sender, EventArgs e)
        {
            if (_Doctor.Save())
            {
                frmAddEditClinic frm = new frmAddEditClinic();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _Doctor.ClinicAddressID = frm.NewClinicAddressID;
                    _Doctor.Save(); // حفظ تحديث الطبيب مع ClinicAddressID الجديد
                    MessageBox.Show("Clinic Address added and linked to Doctor.");
                    _LoadData();  // إعادة تحميل البيانات لتحديث الشاشة
                }
            }
            else
            {
                MessageBox.Show("Error: Doctor could not be saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        

        private void btnEditClinicAddress_Click_1(object sender, EventArgs e)
        {
            if (_Doctor.ClinicAddressID.HasValue)
            {
                frmAddEditClinic frm = new frmAddEditClinic(_Doctor.ClinicAddressID.Value); // فتح النموذج في وضع التعديل
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _LoadData();  // إعادة تحميل البيانات لتحديث الشاشة بعد التعديل
                }
            }
        }

        private void btnDeleteClinicAddress_Click(object sender, EventArgs e)
        {
            if (_Doctor.ClinicAddressID.HasValue)
            {
                var result = MessageBox.Show("Are you sure you want to delete this clinic address?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    clsClinicAddress.DeleteClinicAddress(_Doctor.ClinicAddressID.Value);
                    _Doctor.ClinicAddressID = null; // إزالة الربط بين الطبيب والعيادة
                    _Doctor.Save(); // حفظ التحديث
                    MessageBox.Show("Clinic Address deleted successfully.");
                    _LoadData();  // إعادة تحميل البيانات لتحديث الشاشة
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabControlDoctor.SelectedTab = tpDoctorInfo;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblClinicAddressStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
