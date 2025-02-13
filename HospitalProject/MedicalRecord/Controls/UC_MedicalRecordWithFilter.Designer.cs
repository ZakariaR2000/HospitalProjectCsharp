namespace HospitalProject.MedicalRecord.Controls
{
    partial class UC_MedicalRecordWithFilter
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.btnAddNewRecord = new System.Windows.Forms.Button();
            this.btnFindPerson = new System.Windows.Forms.Button();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uC_MedicalRecord1 = new HospitalProject.MedicalRecord.Controls.UC_MedicalRecord();
            this.gbFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.btnAddNewRecord);
            this.gbFilters.Controls.Add(this.btnFindPerson);
            this.gbFilters.Controls.Add(this.txtFilterValue);
            this.gbFilters.Controls.Add(this.cbFilterBy);
            this.gbFilters.Controls.Add(this.label2);
            this.gbFilters.Location = new System.Drawing.Point(3, 3);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(390, 110);
            this.gbFilters.TabIndex = 2;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Filter";
            // 
            // btnAddNewRecord
            // 
            this.btnAddNewRecord.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnAddNewRecord.Image = global::HospitalProject.Properties.Resources.add;
            this.btnAddNewRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewRecord.Location = new System.Drawing.Point(306, 30);
            this.btnAddNewRecord.Name = "btnAddNewRecord";
            this.btnAddNewRecord.Size = new System.Drawing.Size(56, 56);
            this.btnAddNewRecord.TabIndex = 44;
            this.btnAddNewRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNewRecord.UseVisualStyleBackColor = true;
            this.btnAddNewRecord.Click += new System.EventHandler(this.btnAddNewRecord_Click);
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnFindPerson.Image = global::HospitalProject.Properties.Resources.icons8_search_48;
            this.btnFindPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFindPerson.Location = new System.Drawing.Point(227, 31);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.Size = new System.Drawing.Size(57, 55);
            this.btnFindPerson.TabIndex = 43;
            this.btnFindPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFindPerson.UseVisualStyleBackColor = true;
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(98, 74);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(107, 24);
            this.txtFilterValue.TabIndex = 13;
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "RecordID",
            "PatientID",
            "DoctorID"});
            this.cbFilterBy.Location = new System.Drawing.Point(98, 31);
            this.cbFilterBy.Margin = new System.Windows.Forms.Padding(2);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(107, 24);
            this.cbFilterBy.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(9, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Find By :";
            // 
            // uC_MedicalRecord1
            // 
            this.uC_MedicalRecord1.Location = new System.Drawing.Point(0, 109);
            this.uC_MedicalRecord1.Name = "uC_MedicalRecord1";
            this.uC_MedicalRecord1.Size = new System.Drawing.Size(401, 266);
            this.uC_MedicalRecord1.TabIndex = 0;
            // 
            // UC_MedicalRecordWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFilters);
            this.Controls.Add(this.uC_MedicalRecord1);
            this.Name = "UC_MedicalRecordWithFilter";
            this.Size = new System.Drawing.Size(401, 376);
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UC_MedicalRecord uC_MedicalRecord1;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.Button btnFindPerson;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNewRecord;
    }
}
