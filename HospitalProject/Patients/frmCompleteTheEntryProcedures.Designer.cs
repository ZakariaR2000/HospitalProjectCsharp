namespace HospitalProject.Patients
{
    partial class frmCompleteTheEntryProcedures
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPatientInfo = new System.Windows.Forms.TabPage();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.dtpCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.lblCreatedByUser = new System.Windows.Forms.Label();
            this.txtPatientNum = new System.Windows.Forms.TextBox();
            this.txtAllergies = new System.Windows.Forms.TextBox();
            this.cmBloodType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPatientID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpPatientInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpPatientInfo);
            this.tabControl1.Location = new System.Drawing.Point(12, 68);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(524, 551);
            this.tabControl1.TabIndex = 0;
            // 
            // tpPatientInfo
            // 
            this.tpPatientInfo.Controls.Add(this.lblPatientName);
            this.tpPatientInfo.Controls.Add(this.dtpCreatedDate);
            this.tpPatientInfo.Controls.Add(this.lblCreatedByUser);
            this.tpPatientInfo.Controls.Add(this.txtPatientNum);
            this.tpPatientInfo.Controls.Add(this.txtAllergies);
            this.tpPatientInfo.Controls.Add(this.cmBloodType);
            this.tpPatientInfo.Controls.Add(this.label6);
            this.tpPatientInfo.Controls.Add(this.label11);
            this.tpPatientInfo.Controls.Add(this.label9);
            this.tpPatientInfo.Controls.Add(this.label7);
            this.tpPatientInfo.Controls.Add(this.label5);
            this.tpPatientInfo.Controls.Add(this.label4);
            this.tpPatientInfo.Controls.Add(this.lblPatientID);
            this.tpPatientInfo.Controls.Add(this.label2);
            this.tpPatientInfo.Location = new System.Drawing.Point(4, 25);
            this.tpPatientInfo.Name = "tpPatientInfo";
            this.tpPatientInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPatientInfo.Size = new System.Drawing.Size(516, 522);
            this.tpPatientInfo.TabIndex = 0;
            this.tpPatientInfo.Text = "Patient Info";
            this.tpPatientInfo.UseVisualStyleBackColor = true;
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblPatientName.Location = new System.Drawing.Point(224, 103);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(64, 29);
            this.lblPatientName.TabIndex = 38;
            this.lblPatientName.Text = "[???]";
            // 
            // dtpCreatedDate
            // 
            this.dtpCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreatedDate.Location = new System.Drawing.Point(229, 359);
            this.dtpCreatedDate.Name = "dtpCreatedDate";
            this.dtpCreatedDate.Size = new System.Drawing.Size(121, 24);
            this.dtpCreatedDate.TabIndex = 20;
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.AutoSize = true;
            this.lblCreatedByUser.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblCreatedByUser.Location = new System.Drawing.Point(231, 420);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(64, 29);
            this.lblCreatedByUser.TabIndex = 19;
            this.lblCreatedByUser.Text = "[???]";
            // 
            // txtPatientNum
            // 
            this.txtPatientNum.Location = new System.Drawing.Point(229, 166);
            this.txtPatientNum.Name = "txtPatientNum";
            this.txtPatientNum.Size = new System.Drawing.Size(194, 24);
            this.txtPatientNum.TabIndex = 18;
            // 
            // txtAllergies
            // 
            this.txtAllergies.Location = new System.Drawing.Point(229, 296);
            this.txtAllergies.Name = "txtAllergies";
            this.txtAllergies.Size = new System.Drawing.Size(121, 24);
            this.txtAllergies.TabIndex = 16;
            // 
            // cmBloodType
            // 
            this.cmBloodType.FormattingEnabled = true;
            this.cmBloodType.Items.AddRange(new object[] {
            "A+",
            "O+",
            "B+",
            "AB+",
            "A-",
            "O-",
            "B-",
            "AB-"});
            this.cmBloodType.Location = new System.Drawing.Point(229, 232);
            this.cmBloodType.Name = "cmBloodType";
            this.cmBloodType.Size = new System.Drawing.Size(121, 24);
            this.cmBloodType.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label6.Location = new System.Drawing.Point(38, 420);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 29);
            this.label6.TabIndex = 14;
            this.label6.Text = "CreatedByUser :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label11.Location = new System.Drawing.Point(38, 355);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(162, 29);
            this.label11.TabIndex = 10;
            this.label11.Text = "CreatedDate :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label9.Location = new System.Drawing.Point(38, 292);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 29);
            this.label9.TabIndex = 8;
            this.label9.Text = "Allergies :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label7.Location = new System.Drawing.Point(38, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 29);
            this.label7.TabIndex = 6;
            this.label7.Text = "Blood Type :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label5.Location = new System.Drawing.Point(38, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "PatientNum :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label4.Location = new System.Drawing.Point(38, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "Name :";
            // 
            // lblPatientID
            // 
            this.lblPatientID.AutoSize = true;
            this.lblPatientID.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblPatientID.Location = new System.Drawing.Point(224, 40);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(64, 29);
            this.lblPatientID.TabIndex = 1;
            this.lblPatientID.Text = "[???]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label2.Location = new System.Drawing.Point(38, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "PatientID :";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 24F);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(216, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(95, 48);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnClose.Image = global::HospitalProject.Properties.Resources.icons8_close_50__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(307, 621);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 53);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSave.Image = global::HospitalProject.Properties.Resources.save_file_10057642__1_;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(430, 621);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 53);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmCompleteTheEntryProcedures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 687);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmCompleteTheEntryProcedures";
            this.Text = "frmEditAddPatient";
            this.Load += new System.EventHandler(this.frmCompleteTheEntryProcedures_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpPatientInfo.ResumeLayout(false);
            this.tpPatientInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpPatientInfo;
        private System.Windows.Forms.Label lblPatientID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpCreatedDate;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.TextBox txtAllergies;
        private System.Windows.Forms.ComboBox cmBloodType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.TextBox txtPatientNum;
    }
}