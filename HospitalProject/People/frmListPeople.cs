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
    public partial class ListPeople : Form
    {
        

        DataTable _dtAllPeople;
        Timer timer;


        private List<string> columnOrder = new List<string>()
        {
            "PersonID", "NationalNo", "FirstName", "SecondName",
            "ThirdName", "LastName", "DateOfBirth", "GenderCaption",
            "Address", "Phone", "Email", "CountryName", "ImagePath"
        };
        public ListPeople()
        {
            InitializeComponent();
        }

        private void clsListPeople_Load(object sender, EventArgs e)
        {


            _dtAllPeople = clsPerson.GetAllPeople();
            dgvPeople.DataSource = _dtAllPeople;

           // lblNumberOfRecords.Text = dgvPeople.

            // إظهار نافذة اختيار الأعمدة
            StartColumnSelectorTimer();


        }
        private void SetDataGridViewColumnOrder()
        {
            // نتحقق من ترتيب الأعمدة وفقاً للترتيب الموجود في columnOrder
            int displayIndex = 0; // المتغير الذي سيخزن الترتيب لكل عمود

            foreach (string columnName in columnOrder)
            {
                // التأكد أن العمود موجود في DataGridView قبل محاولة تغيير ترتيب العرض
                if (dgvPeople.Columns.Contains(columnName))
                {
                    // تأكد من أن DisplayIndex أصغر من عدد الأعمدة
                    dgvPeople.Columns[columnName].DisplayIndex = displayIndex;
                    displayIndex++; // نقوم بزيادة الترتيب لعمود التالي
                }
            }
        }



        private void StartColumnSelectorTimer()
        {
            timer = new Timer();
            timer.Interval = 1000; // تأخير بمقدار 1000 ملي ثانية (1 ثانية)

            timer.Tick += (s, ev) =>
            {
                timer.Stop(); // إيقاف المؤقت

                // فتح نافذة اختيار الأعمدة بعد التأخير
                btnSelectColumns_Click(null, null);
            };

            timer.Start();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();

            // clsListPeople_Load(null, null);

            _dtAllPeople = clsPerson.GetAllPeople();
            dgvPeople.DataSource = _dtAllPeople;
        }

              
        private void btnSelectColumns_Click(object sender, EventArgs e)
        {
            List<string> availableColumns = columnOrder; // قائمة الأعمدة الكاملة

            // إنشاء نافذة frmListOfItems وتمرير الأعمدة المتاحة
            frmListOfItems columnSelector = new frmListOfItems(availableColumns);

            // ضبط حالة الأعمدة كـ "Checked" بناءً على الأعمدة الموجودة في DataGridView
            foreach (string columnName in availableColumns)
            {
                if (dgvPeople.Columns.Contains(columnName))
                {
                    int index = columnSelector.CheckedListBox.Items.IndexOf(columnName);
                    if (index >= 0)
                    {
                        columnSelector.CheckedListBox.SetItemChecked(index, true); // إذا كانت موجودة في DataGridView تعيينها كـ Checked
                    }
                }
            }

            // إظهار نافذة اختيار الأعمدة

            if (columnSelector.ShowDialog() == DialogResult.OK)
            {
                // تحديث DataGridView بالأعمدة المختارة
                UpdateDataGridViewColumns(columnSelector.SelectedColumns);
            }
        }
        

        private void UpdateDataGridViewColumns(List<string> selectedColumns)
        {
            // الاحتفاظ بالبيانات الحالية
            DataTable currentData = _dtAllPeople;

            // إنشاء DataTable جديد فقط بالأعمدة المختارة
            DataTable newTable = new DataTable();

            // إضافة الأعمدة المختارة فقط بالترتيب الصحيح
            foreach (string col in columnOrder)
            {
                if (selectedColumns.Contains(col) && currentData.Columns.Contains(col))
                {
                    newTable.Columns.Add(col, currentData.Columns[col].DataType);
                }
            }

            // إضافة البيانات إلى الجدول الجديد
            foreach (DataRow row in currentData.Rows)
            {
                DataRow newRow = newTable.NewRow();
                foreach (string col in selectedColumns)
                {
                    newRow[col] = row[col];
                }
                newTable.Rows.Add(newRow);
            }

            // تحديث DataGridView
            dgvPeople.DataSource = newTable;
            SetDataGridViewColumnOrder();


        }
        


    }
}
