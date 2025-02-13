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

namespace HospitalProject.Appointments
{
    public partial class frmListAppointments : Form
    {
        DataTable _dtAllAppointments;


        public frmListAppointments()
        {
            InitializeComponent();
        }

        private void frmListAppointments_Load(object sender, EventArgs e)
        {
            _dtAllAppointments = clsAppointment.GetAllAppointments();

            dgvAllAppointments.DataSource = _dtAllAppointments;

            lblNumberOfRecords.Text = dgvAllAppointments.Rows.Count.ToString();

            if (dgvAllAppointments.CurrentRow != null)
            {
                int appointmentID = Convert.ToInt32(dgvAllAppointments.CurrentRow.Cells["AppointmentID"].Value);
                byte currentStatus = Convert.ToByte(dgvAllAppointments.CurrentRow.Cells["Status"].Value);

                // تحويل الحالة من byte إلى clsAppointment.enStatus
                clsAppointment.enStatus status = (clsAppointment.enStatus)currentStatus;

                // تحديث حالة عناصر القائمة بناءً على الحالة الحالية
                SetMenuItemStatus(status);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                int selectedAppointmentID = (int)(dgvAllAppointments.CurrentRow.Cells[0].Value);

                // افتح النموذج مع تمرير AppointmentID
                frmAddEditAppointment editForm = new frmAddEditAppointment(selectedAppointmentID);
                editForm.ShowDialog();

            frmListAppointments_Load(null, null);



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            frmAddEditAppointment editForm = new frmAddEditAppointment();
            editForm.ShowDialog();

            frmListAppointments_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // الحصول على AppointmentID من العنصر المحدد في القائمة أو DataGridView
                if (dgvAllAppointments.CurrentRow != null)
                {
                    int appointmentID = Convert.ToInt32(dgvAllAppointments.CurrentRow.Cells["AppointmentID"].Value);

                    // تأكيد الحذف
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete the appointment with ID {appointmentID}?",
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // استدعاء ميثود الحذف
                        bool isDeleted = clsAppointment.DeleteAppointment(appointmentID);

                        if (isDeleted)
                        {
                            MessageBox.Show("Appointment deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // إعادة تحميل البيانات بعد الحذف
                            frmListAppointments_Load(null,null);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete the appointment. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No appointment selected to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void completeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateAppointmentStatus((byte)clsAppointment.enStatus.Completed);

        }

        private void onTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateAppointmentStatus((byte)clsAppointment.enStatus.OnTime);

        }

        private void cancledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateAppointmentStatus((byte)clsAppointment.enStatus.Cancelled);

        }

        private void SetMenuItemStatus(clsAppointment.enStatus currentStatus)
        {
            switch (currentStatus)
            {
                case clsAppointment.enStatus.OnTime:
                    onTimeToolStripMenuItem.Enabled = false;
                    completeToolStripMenuItem.Enabled = true;
                    cancledToolStripMenuItem.Enabled = true;
                    break;

                case clsAppointment.enStatus.Completed:
                    onTimeToolStripMenuItem.Enabled = true;
                    completeToolStripMenuItem.Enabled = false;
                    cancledToolStripMenuItem.Enabled = true;
                    break;

                case clsAppointment.enStatus.Cancelled:
                    onTimeToolStripMenuItem.Enabled = true;
                    completeToolStripMenuItem.Enabled = true;
                    cancledToolStripMenuItem.Enabled = false;
                    break;

                default:
                    onTimeToolStripMenuItem.Enabled = true;
                    completeToolStripMenuItem.Enabled = true;
                    cancledToolStripMenuItem.Enabled = true;
                    break;
            }
        }



        private void UpdateAppointmentStatus(byte statusByte)
        {
            try
            {
                if (dgvAllAppointments.CurrentRow != null)
                {
                    int appointmentID = Convert.ToInt32(dgvAllAppointments.CurrentRow.Cells["AppointmentID"].Value);

                    // تحويل byte إلى clsAppointment.enStatus
                    clsAppointment.enStatus newStatus = (clsAppointment.enStatus)statusByte;

                    DialogResult result = MessageBox.Show($"Are you sure you want to update the status to {newStatus}?",
                        "Confirm Status Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bool isUpdated = clsAppointment.UpdateAppointmentStatus(appointmentID, newStatus);

                        if (isUpdated)
                        {
                            MessageBox.Show("Appointment status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SetMenuItemStatus(newStatus);
                            frmListAppointments_Load(null,null);
                        }
                        else
                        {
                            MessageBox.Show("Failed to update appointment status. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No appointment selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAllAppointments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAllAppointments.CurrentRow != null)
            {
                byte currentStatus = Convert.ToByte(dgvAllAppointments.CurrentRow.Cells["Status"].Value);

                // تحويل الحالة من byte إلى clsAppointment.enStatus
                clsAppointment.enStatus status = (clsAppointment.enStatus)currentStatus;

                // تحديث حالة عناصر القائمة بناءً على الحالة الحالية
                SetMenuItemStatus(status);
            }
        }
    }
}
