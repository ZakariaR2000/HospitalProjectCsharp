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
    public partial class frmDoctorInfo : Form
    {
        private int _DoctorID = -1;


        public frmDoctorInfo(int DoctorID)
        {
            InitializeComponent();

            _DoctorID = DoctorID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDoctorInfo_Load(object sender, EventArgs e)
        {
            ctrlDoctroInfo1.LoadInfo(_DoctorID);
        }
    }
}
