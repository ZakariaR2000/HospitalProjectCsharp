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

namespace HospitalProject.Clinic
{
    public partial class frmListClinicAddress : Form
    {
        private DataTable _dtAllClinicAddress;

        public frmListClinicAddress()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListClinicAddress_Load(object sender, EventArgs e)
        {
            _dtAllClinicAddress = clsClinicAddress.GetAllClinicAddresses();

            dgvClinicAddress.DataSource = _dtAllClinicAddress;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditClinic frm = new frmAddEditClinic();
            frm.ShowDialog();

            frmListClinicAddress_Load(null, null);
        }

        private void doctoInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvClinicAddress.CurrentRow != null)
            {
                int clinicAddressID = Convert.ToInt32(dgvClinicAddress.CurrentRow.Cells["ClinicAddresseID"].Value);

                // استدعاء الدالة التي تسترجع DoctorID من العنوان
                int? doctorID = clsDoctor.GetDoctorIDByClinicAddress(clinicAddressID);

                if (doctorID.HasValue)
                {
                    frmDoctorInfo frm = new frmDoctorInfo(doctorID.Value);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No doctor associated with this clinic address.", "No Doctor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a clinic address.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
