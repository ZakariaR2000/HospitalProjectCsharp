using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalProject.MedicalRecord.Controls
{
    public partial class UC_MedicalRecordWithFilter : UserControl
    {

        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID);
            }
        }
        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }

            set
            {
                _ShowAddPerson = value;
                btnAddNewRecord.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;


        public UC_MedicalRecordWithFilter()
        {
            InitializeComponent();
        }

        private void btnAddNewRecord_Click(object sender, EventArgs e)
        {

        }
    }
}
