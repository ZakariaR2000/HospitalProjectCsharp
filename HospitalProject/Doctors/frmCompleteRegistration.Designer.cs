namespace HospitalProject.Doctors
{
    partial class frmCompleteRegistration
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControlDoctor = new System.Windows.Forms.TabControl();
            this.tpDoctorInfo = new System.Windows.Forms.TabPage();
            this.btnDeleteClinicAddress = new System.Windows.Forms.Button();
            this.btnEditClinicAddress = new System.Windows.Forms.Button();
            this.lblClinicAddressStatus = new System.Windows.Forms.Label();
            this.btnAddClinicAddress = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblUserMessage = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.cbSpecialization = new System.Windows.Forms.ComboBox();
            this.lblCreatedByUser = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblHireDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDoctorID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tpClinicInfo = new System.Windows.Forms.TabPage();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtAddressLine2 = new System.Windows.Forms.TextBox();
            this.txtAddressLine1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblClinicAddressID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControlDoctor.SuspendLayout();
            this.tpDoctorInfo.SuspendLayout();
            this.tpClinicInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(230, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(83, 41);
            this.lblTitle.TabIndex = 23;
            this.lblTitle.Text = "Title";
            // 
            // tabControlDoctor
            // 
            this.tabControlDoctor.Controls.Add(this.tpDoctorInfo);
            this.tabControlDoctor.Controls.Add(this.tpClinicInfo);
            this.tabControlDoctor.Location = new System.Drawing.Point(13, 53);
            this.tabControlDoctor.Name = "tabControlDoctor";
            this.tabControlDoctor.SelectedIndex = 0;
            this.tabControlDoctor.Size = new System.Drawing.Size(514, 558);
            this.tabControlDoctor.TabIndex = 41;
            // 
            // tpDoctorInfo
            // 
            this.tpDoctorInfo.Controls.Add(this.btnDeleteClinicAddress);
            this.tpDoctorInfo.Controls.Add(this.btnEditClinicAddress);
            this.tpDoctorInfo.Controls.Add(this.lblClinicAddressStatus);
            this.tpDoctorInfo.Controls.Add(this.btnAddClinicAddress);
            this.tpDoctorInfo.Controls.Add(this.btnNext);
            this.tpDoctorInfo.Controls.Add(this.lblUserMessage);
            this.tpDoctorInfo.Controls.Add(this.txtSalary);
            this.tpDoctorInfo.Controls.Add(this.cbSpecialization);
            this.tpDoctorInfo.Controls.Add(this.lblCreatedByUser);
            this.tpDoctorInfo.Controls.Add(this.label8);
            this.tpDoctorInfo.Controls.Add(this.label7);
            this.tpDoctorInfo.Controls.Add(this.label6);
            this.tpDoctorInfo.Controls.Add(this.lblHireDate);
            this.tpDoctorInfo.Controls.Add(this.label5);
            this.tpDoctorInfo.Controls.Add(this.lblDoctorID);
            this.tpDoctorInfo.Controls.Add(this.label2);
            this.tpDoctorInfo.Location = new System.Drawing.Point(4, 25);
            this.tpDoctorInfo.Name = "tpDoctorInfo";
            this.tpDoctorInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpDoctorInfo.Size = new System.Drawing.Size(506, 529);
            this.tpDoctorInfo.TabIndex = 0;
            this.tpDoctorInfo.Text = "Doctor Info";
            this.tpDoctorInfo.UseVisualStyleBackColor = true;
            // 
            // btnDeleteClinicAddress
            // 
            this.btnDeleteClinicAddress.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnDeleteClinicAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteClinicAddress.Location = new System.Drawing.Point(26, 473);
            this.btnDeleteClinicAddress.Name = "btnDeleteClinicAddress";
            this.btnDeleteClinicAddress.Size = new System.Drawing.Size(131, 53);
            this.btnDeleteClinicAddress.TabIndex = 61;
            this.btnDeleteClinicAddress.Text = "DeleteClinic";
            this.btnDeleteClinicAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteClinicAddress.UseVisualStyleBackColor = true;
            this.btnDeleteClinicAddress.Click += new System.EventHandler(this.btnDeleteClinicAddress_Click);
            // 
            // btnEditClinicAddress
            // 
            this.btnEditClinicAddress.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnEditClinicAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditClinicAddress.Location = new System.Drawing.Point(167, 470);
            this.btnEditClinicAddress.Name = "btnEditClinicAddress";
            this.btnEditClinicAddress.Size = new System.Drawing.Size(99, 53);
            this.btnEditClinicAddress.TabIndex = 60;
            this.btnEditClinicAddress.Text = "EditClinic";
            this.btnEditClinicAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditClinicAddress.UseVisualStyleBackColor = true;
            this.btnEditClinicAddress.Click += new System.EventHandler(this.btnEditClinicAddress_Click_1);
            // 
            // lblClinicAddressStatus
            // 
            this.lblClinicAddressStatus.AutoSize = true;
            this.lblClinicAddressStatus.Font = new System.Drawing.Font("Tahoma", 15F);
            this.lblClinicAddressStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblClinicAddressStatus.Location = new System.Drawing.Point(21, 423);
            this.lblClinicAddressStatus.Name = "lblClinicAddressStatus";
            this.lblClinicAddressStatus.Size = new System.Drawing.Size(72, 30);
            this.lblClinicAddressStatus.TabIndex = 59;
            this.lblClinicAddressStatus.Text = "Clinic";
            this.lblClinicAddressStatus.Click += new System.EventHandler(this.lblClinicAddressStatus_Click);
            // 
            // btnAddClinicAddress
            // 
            this.btnAddClinicAddress.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnAddClinicAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddClinicAddress.Location = new System.Drawing.Point(285, 470);
            this.btnAddClinicAddress.Name = "btnAddClinicAddress";
            this.btnAddClinicAddress.Size = new System.Drawing.Size(99, 53);
            this.btnAddClinicAddress.TabIndex = 58;
            this.btnAddClinicAddress.Text = "AddClinic";
            this.btnAddClinicAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddClinicAddress.UseVisualStyleBackColor = true;
            this.btnAddClinicAddress.Click += new System.EventHandler(this.btnAddClinicAddress_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnNext.Image = global::HospitalProject.Properties.Resources.next_189253;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(401, 470);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(99, 53);
            this.btnNext.TabIndex = 57;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.AutoSize = true;
            this.lblUserMessage.ForeColor = System.Drawing.Color.Red;
            this.lblUserMessage.Location = new System.Drawing.Point(299, 34);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.Size = new System.Drawing.Size(90, 17);
            this.lblUserMessage.TabIndex = 56;
            this.lblUserMessage.Text = "User Message";
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(245, 267);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(144, 24);
            this.txtSalary.TabIndex = 55;
            // 
            // cbSpecialization
            // 
            this.cbSpecialization.Font = new System.Drawing.Font("Tahoma", 15F);
            this.cbSpecialization.FormattingEnabled = true;
            this.cbSpecialization.Location = new System.Drawing.Point(245, 192);
            this.cbSpecialization.Name = "cbSpecialization";
            this.cbSpecialization.Size = new System.Drawing.Size(217, 38);
            this.cbSpecialization.TabIndex = 54;
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.AutoSize = true;
            this.lblCreatedByUser.Font = new System.Drawing.Font("Tahoma", 15F);
            this.lblCreatedByUser.Location = new System.Drawing.Point(240, 343);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(81, 30);
            this.lblCreatedByUser.TabIndex = 53;
            this.lblCreatedByUser.Text = "[????]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label8.Location = new System.Drawing.Point(21, 329);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 60);
            this.label8.TabIndex = 52;
            this.label8.Text = "Registration By\r\nUser :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label7.Location = new System.Drawing.Point(21, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 30);
            this.label7.TabIndex = 51;
            this.label7.Text = "Salary :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label6.Location = new System.Drawing.Point(19, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 30);
            this.label6.TabIndex = 50;
            this.label6.Text = "Specialization :";
            // 
            // lblHireDate
            // 
            this.lblHireDate.AutoSize = true;
            this.lblHireDate.Font = new System.Drawing.Font("Tahoma", 15F);
            this.lblHireDate.Location = new System.Drawing.Point(240, 117);
            this.lblHireDate.Name = "lblHireDate";
            this.lblHireDate.Size = new System.Drawing.Size(149, 30);
            this.lblHireDate.TabIndex = 49;
            this.lblHireDate.Text = "[??/??/????]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label5.Location = new System.Drawing.Point(21, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 30);
            this.label5.TabIndex = 48;
            this.label5.Text = "HireDate :";
            // 
            // lblDoctorID
            // 
            this.lblDoctorID.AutoSize = true;
            this.lblDoctorID.Font = new System.Drawing.Font("Tahoma", 15F);
            this.lblDoctorID.ForeColor = System.Drawing.Color.Red;
            this.lblDoctorID.Location = new System.Drawing.Point(177, 34);
            this.lblDoctorID.Name = "lblDoctorID";
            this.lblDoctorID.Size = new System.Drawing.Size(69, 30);
            this.lblDoctorID.TabIndex = 47;
            this.lblDoctorID.Text = "[???]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label2.Location = new System.Drawing.Point(19, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 30);
            this.label2.TabIndex = 46;
            this.label2.Text = "Doctor ID :";
            // 
            // tpClinicInfo
            // 
            this.tpClinicInfo.Controls.Add(this.btnBack);
            this.tpClinicInfo.Controls.Add(this.txtPostalCode);
            this.tpClinicInfo.Controls.Add(this.txtCity);
            this.tpClinicInfo.Controls.Add(this.txtAddressLine2);
            this.tpClinicInfo.Controls.Add(this.txtAddressLine1);
            this.tpClinicInfo.Controls.Add(this.label1);
            this.tpClinicInfo.Controls.Add(this.lblClinicAddressID);
            this.tpClinicInfo.Controls.Add(this.label9);
            this.tpClinicInfo.Controls.Add(this.label10);
            this.tpClinicInfo.Controls.Add(this.label3);
            this.tpClinicInfo.Controls.Add(this.label4);
            this.tpClinicInfo.Location = new System.Drawing.Point(4, 25);
            this.tpClinicInfo.Name = "tpClinicInfo";
            this.tpClinicInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpClinicInfo.Size = new System.Drawing.Size(506, 529);
            this.tpClinicInfo.TabIndex = 1;
            this.tpClinicInfo.Text = "Clinic Info";
            this.tpClinicInfo.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnBack.Image = global::HospitalProject.Properties.Resources.icons8_back_44;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(6, 470);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(99, 53);
            this.btnBack.TabIndex = 65;
            this.btnBack.Text = "Back";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Enabled = false;
            this.txtPostalCode.Location = new System.Drawing.Point(245, 355);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(136, 24);
            this.txtPostalCode.TabIndex = 64;
            // 
            // txtCity
            // 
            this.txtCity.Enabled = false;
            this.txtCity.Location = new System.Drawing.Point(245, 286);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(136, 24);
            this.txtCity.TabIndex = 63;
            // 
            // txtAddressLine2
            // 
            this.txtAddressLine2.Enabled = false;
            this.txtAddressLine2.Location = new System.Drawing.Point(245, 214);
            this.txtAddressLine2.Name = "txtAddressLine2";
            this.txtAddressLine2.Size = new System.Drawing.Size(136, 24);
            this.txtAddressLine2.TabIndex = 62;
            // 
            // txtAddressLine1
            // 
            this.txtAddressLine1.Enabled = false;
            this.txtAddressLine1.Location = new System.Drawing.Point(245, 133);
            this.txtAddressLine1.Name = "txtAddressLine1";
            this.txtAddressLine1.Size = new System.Drawing.Size(136, 24);
            this.txtAddressLine1.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label1.Location = new System.Drawing.Point(31, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 30);
            this.label1.TabIndex = 60;
            this.label1.Text = "AddressLine2 :";
            // 
            // lblClinicAddressID
            // 
            this.lblClinicAddressID.AutoSize = true;
            this.lblClinicAddressID.Font = new System.Drawing.Font("Tahoma", 15F);
            this.lblClinicAddressID.ForeColor = System.Drawing.Color.Red;
            this.lblClinicAddressID.Location = new System.Drawing.Point(240, 61);
            this.lblClinicAddressID.Name = "lblClinicAddressID";
            this.lblClinicAddressID.Size = new System.Drawing.Size(69, 30);
            this.lblClinicAddressID.TabIndex = 56;
            this.lblClinicAddressID.Text = "[???]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label9.Location = new System.Drawing.Point(27, 349);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 30);
            this.label9.TabIndex = 55;
            this.label9.Text = "Postal Code :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label10.Location = new System.Drawing.Point(29, 277);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 30);
            this.label10.TabIndex = 54;
            this.label10.Text = "City :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label3.Location = new System.Drawing.Point(29, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 30);
            this.label3.TabIndex = 52;
            this.label3.Text = "AddressLine1 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label4.Location = new System.Drawing.Point(27, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 30);
            this.label4.TabIndex = 51;
            this.label4.Text = "Clinic AddressID :";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnClose.Image = global::HospitalProject.Properties.Resources.icons8_close_50__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(302, 630);
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
            this.btnSave.Location = new System.Drawing.Point(425, 630);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 53);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmCompleteRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 684);
            this.Controls.Add(this.tabControlDoctor);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmCompleteRegistration";
            this.Text = "frmCompleteRegistration";
            this.Load += new System.EventHandler(this.frmCompleteRegistration_Load);
            this.tabControlDoctor.ResumeLayout(false);
            this.tpDoctorInfo.ResumeLayout(false);
            this.tpDoctorInfo.PerformLayout();
            this.tpClinicInfo.ResumeLayout(false);
            this.tpClinicInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControlDoctor;
        private System.Windows.Forms.TabPage tpDoctorInfo;
        private System.Windows.Forms.Label lblUserMessage;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.ComboBox cbSpecialization;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblHireDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDoctorID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tpClinicInfo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblClinicAddressID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtAddressLine2;
        private System.Windows.Forms.TextBox txtAddressLine1;
        private System.Windows.Forms.Label lblClinicAddressStatus;
        private System.Windows.Forms.Button btnAddClinicAddress;
        private System.Windows.Forms.Button btnEditClinicAddress;
        private System.Windows.Forms.Button btnDeleteClinicAddress;
        private System.Windows.Forms.Button btnBack;
    }
}