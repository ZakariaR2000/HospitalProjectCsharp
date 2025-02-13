using HospitalProject.Doctors;
using HospitalProject.Patients;
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

namespace HospitalProject.Appointments
{
    public partial class frmAddEditAppointment : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;


        private int _AppointmentID;
        clsAppointment _Appointment;

        clsDoctor _Doctor;
        clsPatient clsPatient;

        public frmAddEditAppointment()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddEditAppointment(int AppointmentID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _AppointmentID = AppointmentID;
        }

        private void _ResetDefualtValues()
        {
            // _FillClassesInComboBox();

            if (_Mode == enMode.AddNew)
            {

                lblTitle.Text = "New Appointment";
                this.Text = "New Appointment";

                _Appointment = new clsAppointment();

                /// ctrlPatientsInfo1.FilterFocus();

            }
            else
            {
                lblTitle.Text = "Update Appointment";
                this.Text = "Update Appointment";

                tpPatient.Enabled = true;
                tpDoctor.Enabled = true;

                btnSave.Enabled = true;
            }


        }


        private void frmAddEditAppointment_Load(object sender, EventArgs e)
        {
            // إعادة تعيين القيم الافتراضية
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();

        }

        private void _LoadData()
        {
            _Appointment = clsAppointment.GetAppointmentInfoByID(_AppointmentID);

            if (_Appointment != null)
            {
                // تعبئة الحقول في tpAppointment
                dtpAppointmentDate.Value = _Appointment.AppointmentDate;
               // txtNotes.Text = _Appointment.Notes;

                // تعيين الحالة حسب قيمة Status
                switch (_Appointment.Status)
                {
                    case clsAppointment.enStatus.OnTime:
                        rbOnTime.Checked = true;
                        break;
                    case clsAppointment.enStatus.Completed:
                        rbComplete.Checked = true;
                        break;
                    case clsAppointment.enStatus.Cancelled:
                        rbCanceled.Checked = true;
                        break;
                    default:
                        rbOnTime.Checked = true;
                        break;
                }

                // تعبئة PatientID و DoctorID
                txtPatientID.Text = _Appointment.PatientID.ToString();
                txtDoctorID.Text = _Appointment.DoctorID.HasValue ? _Appointment.DoctorID.Value.ToString() : string.Empty;
                txtNotes.Text = _Appointment.Notes;



                ctrlPatientsInfo1.LoadInfo(_Appointment.PatientID);

                ctrlDoctroInfo1.LoadInfo(_Appointment.DoctorID.Value);
                
                
            }
            else
            {
                MessageBox.Show($"Appointment with ID {_AppointmentID} not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void _LoadPatientData()
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtDoctorID.Text, out int doctorID))
                {
                    MessageBox.Show("Invalid Doctor ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDoctorID.Text))
                {
                    MessageBox.Show("Doctor ID cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // التحقق من وجود PatientID
                if (string.IsNullOrWhiteSpace(txtPatientID.Text))
                {
                    MessageBox.Show("Patient ID cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // تعبئة الكائن _Appointment
                _Appointment.AppointmentDate = dtpAppointmentDate.Value;
                _Appointment.Notes = txtNotes.Text;
                _Appointment.PatientID = int.Parse(txtPatientID.Text);  // لا حاجة للتحقق مرة أخرى هنا
                _Appointment.DoctorID = int.Parse(txtDoctorID.Text);    // لا حاجة للتحقق مرة أخرى هنا
                _Appointment.AppointmentID = _AppointmentID;
                _Appointment.CreatedByUserID = 1;

                // تعيين الحالة حسب الاختيار
                if (rbOnTime.Checked)
                    _Appointment.Status = clsAppointment.enStatus.OnTime;
                else if (rbComplete.Checked)
                    _Appointment.Status = clsAppointment.enStatus.Completed;
                else if (rbCanceled.Checked)
                    _Appointment.Status = clsAppointment.enStatus.Cancelled;



                // حفظ الموعد
                if (_Appointment.Save())
                {
                    MessageBox.Show("Appointment saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to save appointment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            // فتح نافذة اختيار المرضى
            frmListPatients frm = new frmListPatients();
            frm.IsCalledByAppointment = true; // تحديد أن الاستدعاء من clsAppointment

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // تعبئة معلومات المريض المختار
                if (frm.SelectedPatient != null)
                {
                    // تحديث txtPatientID مباشرةً مع PatientID
                    txtPatientID.Text = frm.SelectedPatient.PatientID.ToString();

                    // ملء معلومات المريض في ctrlPatientsInfo1
                    ctrlPatientsInfo1.LoadInfo(frm.SelectedPatient.PatientID);
                }
            }
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            // فتح نافذة اختيار الأطباء
            frmListDoctros frm = new frmListDoctros();
            frm.IsCalledByAppointment = true; // تحديد أن الاستدعاء من clsAppointment

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // تعبئة معلومات الطبيب المختار
                if (frm.SelectedDoctor != null)
                {
                    // تحديث txtDoctorID مباشرةً مع DoctorID
                    txtDoctorID.Text = frm.SelectedDoctor.DoctorID.ToString();

                    // ملء معلومات الطبيب في ctrlDoctorInfo1
                    ctrlDoctroInfo1.LoadInfo(frm.SelectedDoctor.DoctorID);
                }
            }
        }
    }
}
