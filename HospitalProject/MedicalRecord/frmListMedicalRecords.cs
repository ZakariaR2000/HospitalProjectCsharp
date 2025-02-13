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

namespace HospitalProject.MedicalRecord
{
    public partial class frmListMedicalRecords : Form
    {
        DataTable _dtAllMedicalRecords;


        public frmListMedicalRecords()
        {
            InitializeComponent();
        }

        private void frmListMedicalRecords_Load(object sender, EventArgs e)
        {
            _dtAllMedicalRecords = clsMedicalRecord.GetAllMedicalRecords();

            dgvAllMedicalRecords.DataSource = _dtAllMedicalRecords;

            lblNumberOfRecords.Text = _dtAllMedicalRecords.Rows.Count.ToString();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditMedicalRecord frmAddEditMedicalRecord = new frmAddEditMedicalRecord();
            frmAddEditMedicalRecord.ShowDialog();

            frmListMedicalRecords_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RecordID = (int)dgvAllMedicalRecords.CurrentRow.Cells[0].Value;
            frmAddEditMedicalRecord frmAddEditMedicalRecord = new frmAddEditMedicalRecord(RecordID);
            frmAddEditMedicalRecord.ShowDialog();

            frmListMedicalRecords_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // الحصول على PatientID من الصف المحدد
            int selectedPatientID = (int)dgvAllMedicalRecords.CurrentRow.Cells[0].Value;

            // تأكيد الحذف
            var confirmResult = MessageBox.Show("Are you sure you want to delete this Record?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                // تنفيذ الحذف
                bool isDeleted = clsMedicalRecord.DeleteMedicalRecord(selectedPatientID);

                if (isDeleted)
                {
                    MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // تحديث الواجهة (إعادة تحميل البيانات)
                    frmListMedicalRecords_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Error: Record could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
