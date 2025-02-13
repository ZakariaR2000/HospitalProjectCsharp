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

namespace HospitalProject.People
{
    public partial class frmListOfItems : Form
    {
        public List<string> SelectedColumns { get; private set; }
        public CheckedListBox CheckedListBox { get { return checkedListBoxColumns; } } // إتاحة الوصول إلى CheckedListBox

        public frmListOfItems(List<string> availableColumns)
        {
            InitializeComponent();

            foreach (var column in availableColumns)
            {
                checkedListBoxColumns.Items.Add(column, false);  // افتراضيا كلها مختارة
            }
        }

        

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedColumns = new List<string>();

            // جمع الأعمدة المختارة
            foreach (var item in checkedListBoxColumns.CheckedItems)
            {
                SelectedColumns.Add(item.ToString());
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        
    }
}
