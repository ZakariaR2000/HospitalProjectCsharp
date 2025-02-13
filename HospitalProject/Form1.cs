using HospitalProject.Appointments;
using HospitalProject.Clinic;
using HospitalProject.Doctors;
using HospitalProject.MedicalRecord;
using HospitalProject.Patients;
using HospitalProject.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            ListPeople frm = new ListPeople();
            frm.ShowDialog();
        }

        private void doctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void clinicAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListClinicAddress frm = new frmListClinicAddress();
            frm.ShowDialog();
        }

        private void manageDoctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDoctros frm = new frmListDoctros();
            frm.ShowDialog();
        }

        private void patiantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPatients frm = new frmListPatients();
            frm.ShowDialog();
        }

        private void appointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListAppointments frm = new frmListAppointments();
            frm.ShowDialog();
        }

        private void maToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListMedicalRecords frm = new frmListMedicalRecords();
            frm.ShowDialog();
        }
    }
}
