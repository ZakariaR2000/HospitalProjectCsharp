using HospitalProject.Clinic;
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
    public partial class frmListDoctros : Form
    {
        public bool IsCalledByMedicalRecord { get; set; } = false;

        public int SelectedDoctorID { get; private set; }

        private int _Doctro = -1;

        private DataTable _dtAllDoctorList;
        public clsDoctor SelectedDoctor { get; private set; }

        public bool IsCalledByAppointment { get; set; }


        public frmListDoctros()
        {
            InitializeComponent();
        }

        private void frmListDoctro_Load(object sender, EventArgs e)
        {
            _dtAllDoctorList = clsDoctor.GetAllDoctors();
            dgvDoctors.DataSource = _dtAllDoctorList;

            lblNumberOfRecords.Text = dgvDoctors.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmEditAddDoctor frm = new frmEditAddDoctor();
            frm.ShowDialog();

            frmListDoctro_Load(null, null);

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

            _dtAllDoctorList.DefaultView.RowFilter = "";
            lblNumberOfRecords.Text = dgvDoctors.Rows.Count.ToString();

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            var filterColumns = new Dictionary<string, string>
            {
                { "Doctor ID", "DoctorID" },
                { "Person ID", "PersonID" },
                { "Clinic Address ID", "ClinicAddressID" },
                { "Specialization ID", "SpecializationID" },
                { "Hire Date", "HireDate" },
                { "Is Active", "IsActive" }
            };

            // إذا كانت القيمة فارغة أو الفلتر غير موجود
            if (txtFilterValue.Text.Trim() == "" || !filterColumns.ContainsKey(cbFilterBy.Text))
            {
                _dtAllDoctorList.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvDoctors.Rows.Count.ToString();
                return;
            }

            string filterColumn = filterColumns[cbFilterBy.Text];
            string filterValue = txtFilterValue.Text.Trim();

            // استخدام تعبير ثلاثي لاختيار طريقة الفلترة بناءً على نوع العمود
            _dtAllDoctorList.DefaultView.RowFilter = (filterColumn == "DoctorID" || filterColumn == "PersonID" ||
                filterColumn == "ClinicAddressID" || filterColumn == "SpecializationID")

                ? string.Format("[{0}] = {1}", filterColumn, filterValue)
                : string.Format("[{0}] LIKE '{1}%'", filterColumn, filterValue);

            lblNumberOfRecords.Text = dgvDoctors.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "DoctorID" || cbFilterBy.Text == "PersonID" ||
         cbFilterBy.Text == "ClinicAddressID" || cbFilterBy.Text == "SpecializationID")
            {
                // السماح فقط بإدخال الأرقام أو التحكم (مثل الحذف)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditAddDoctor frm = new frmEditAddDoctor((int)dgvDoctors.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmListDoctro_Load(null, null);
        }

        private void showClinicInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int doctorID = (int)dgvDoctors.CurrentRow.Cells["DoctorID"].Value;

            // استرداد بيانات الطبيب باستخدام كائن clsDoctor
            clsDoctor doctor = clsDoctor.GetDoctorInfoByID(doctorID);

            if (doctor != null && doctor.ClinicAddressID.HasValue)
            {
                // تمرير ClinicAddressID إلى النموذج
                frmShowClinicInfo frm = new frmShowClinicInfo(doctor.ClinicAddressID.Value);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Clinic address not found for this doctor.");
            }
        }

        private void dgvDoctors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                int doctorID = Convert.ToInt32(dgvDoctors.Rows[e.RowIndex].Cells["DoctorID"].Value);
                SelectedDoctor = clsDoctor.GetDoctorInfoByID(doctorID);

                if (SelectedDoctor != null)
                {
                    if (IsCalledByAppointment)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else if (IsCalledByMedicalRecord)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        // إذا لم يكن الاستدعاء من نافذة الحجز أو السجل الطبي، قم بفتح نافذة التعديل
                        frmEditAddDoctor frm = new frmEditAddDoctor(doctorID);
                        frm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Unable to retrieve doctor details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
