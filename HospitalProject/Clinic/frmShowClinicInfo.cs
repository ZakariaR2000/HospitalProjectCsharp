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
    public partial class frmShowClinicInfo : Form
    {
        private clsClinicAddress _clinicInfo;


        //public frmShowClinicInfo(int ClinicAddressID)
        //{
        //    InitializeComponent();

        //    ctrlClinicAddress1.LoadClinicAddress(ClinicAddressID);
        //}

        public frmShowClinicInfo(int ClinicAddressID)
        {
            InitializeComponent();

            // تحميل بيانات العيادة والتحقق من وجودها
            if (!ctrlClinicAddress1.LoadClinicAddress(ClinicAddressID))
            {
                MessageBox.Show("Clinic information could not be loaded. Please ensure the ClinicAddressID is correct.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
