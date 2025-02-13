namespace HospitalProject.Appointments
{
    partial class frmAddEditAppointment
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblAppointmentID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpAppointment = new System.Windows.Forms.TabPage();
            this.btnAddDoctor = new System.Windows.Forms.Button();
            this.btnAddPatient = new System.Windows.Forms.Button();
            this.txtDoctorID = new System.Windows.Forms.TextBox();
            this.txtPatientID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbCanceled = new System.Windows.Forms.RadioButton();
            this.rbComplete = new System.Windows.Forms.RadioButton();
            this.rbOnTime = new System.Windows.Forms.RadioButton();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpAppointmentDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tpPatient = new System.Windows.Forms.TabPage();
            this.ctrlPatientsInfo1 = new HospitalProject.Patients.ctrlPatientsInfo();
            this.tpDoctor = new System.Windows.Forms.TabPage();
            this.ctrlDoctroInfo1 = new HospitalProject.Doctors.Controls.ctrlDoctroInfo();
            this.tabControl1.SuspendLayout();
            this.tpAppointment.SuspendLayout();
            this.tpPatient.SuspendLayout();
            this.tpDoctor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnClose.Image = global::HospitalProject.Properties.Resources.icons8_close_50__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(498, 528);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 53);
            this.btnClose.TabIndex = 60;
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
            this.btnSave.Location = new System.Drawing.Point(621, 528);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 53);
            this.btnSave.TabIndex = 59;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblAppointmentID
            // 
            this.lblAppointmentID.AutoSize = true;
            this.lblAppointmentID.Font = new System.Drawing.Font("Tahoma", 15F);
            this.lblAppointmentID.Location = new System.Drawing.Point(213, 9);
            this.lblAppointmentID.Name = "lblAppointmentID";
            this.lblAppointmentID.Size = new System.Drawing.Size(49, 30);
            this.lblAppointmentID.TabIndex = 42;
            this.lblAppointmentID.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 30);
            this.label1.TabIndex = 41;
            this.label1.Text = "AppointmentID :";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(369, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(83, 41);
            this.lblTitle.TabIndex = 43;
            this.lblTitle.Text = "Title";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpAppointment);
            this.tabControl1.Controls.Add(this.tpPatient);
            this.tabControl1.Controls.Add(this.tpDoctor);
            this.tabControl1.Location = new System.Drawing.Point(17, 61);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(721, 465);
            this.tabControl1.TabIndex = 61;
            // 
            // tpAppointment
            // 
            this.tpAppointment.Controls.Add(this.btnAddDoctor);
            this.tpAppointment.Controls.Add(this.btnAddPatient);
            this.tpAppointment.Controls.Add(this.txtDoctorID);
            this.tpAppointment.Controls.Add(this.txtPatientID);
            this.tpAppointment.Controls.Add(this.label3);
            this.tpAppointment.Controls.Add(this.label2);
            this.tpAppointment.Controls.Add(this.rbCanceled);
            this.tpAppointment.Controls.Add(this.rbComplete);
            this.tpAppointment.Controls.Add(this.rbOnTime);
            this.tpAppointment.Controls.Add(this.txtNotes);
            this.tpAppointment.Controls.Add(this.label6);
            this.tpAppointment.Controls.Add(this.label5);
            this.tpAppointment.Controls.Add(this.dtpAppointmentDate);
            this.tpAppointment.Controls.Add(this.label4);
            this.tpAppointment.Location = new System.Drawing.Point(4, 25);
            this.tpAppointment.Name = "tpAppointment";
            this.tpAppointment.Padding = new System.Windows.Forms.Padding(3);
            this.tpAppointment.Size = new System.Drawing.Size(713, 436);
            this.tpAppointment.TabIndex = 0;
            this.tpAppointment.Text = "Appointment Info";
            this.tpAppointment.UseVisualStyleBackColor = true;
            // 
            // btnAddDoctor
            // 
            this.btnAddDoctor.Location = new System.Drawing.Point(25, 356);
            this.btnAddDoctor.Name = "btnAddDoctor";
            this.btnAddDoctor.Size = new System.Drawing.Size(100, 40);
            this.btnAddDoctor.TabIndex = 73;
            this.btnAddDoctor.Text = "Add Doctor";
            this.btnAddDoctor.UseVisualStyleBackColor = true;
            this.btnAddDoctor.Click += new System.EventHandler(this.btnAddDoctor_Click);
            // 
            // btnAddPatient
            // 
            this.btnAddPatient.Location = new System.Drawing.Point(25, 282);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.Size = new System.Drawing.Size(100, 40);
            this.btnAddPatient.TabIndex = 72;
            this.btnAddPatient.Text = "Add Patient";
            this.btnAddPatient.UseVisualStyleBackColor = true;
            this.btnAddPatient.Click += new System.EventHandler(this.btnAddPatient_Click);
            // 
            // txtDoctorID
            // 
            this.txtDoctorID.Location = new System.Drawing.Point(306, 356);
            this.txtDoctorID.Name = "txtDoctorID";
            this.txtDoctorID.Size = new System.Drawing.Size(122, 24);
            this.txtDoctorID.TabIndex = 71;
            // 
            // txtPatientID
            // 
            this.txtPatientID.Location = new System.Drawing.Point(308, 289);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(122, 24);
            this.txtPatientID.TabIndex = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label3.Location = new System.Drawing.Point(162, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 30);
            this.label3.TabIndex = 69;
            this.label3.Text = "Doctor ID: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label2.Location = new System.Drawing.Point(162, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 30);
            this.label2.TabIndex = 68;
            this.label2.Text = "Patient ID: ";
            // 
            // rbCanceled
            // 
            this.rbCanceled.AutoSize = true;
            this.rbCanceled.Location = new System.Drawing.Point(360, 109);
            this.rbCanceled.Name = "rbCanceled";
            this.rbCanceled.Size = new System.Drawing.Size(84, 21);
            this.rbCanceled.TabIndex = 67;
            this.rbCanceled.TabStop = true;
            this.rbCanceled.Text = "Canceled";
            this.rbCanceled.UseVisualStyleBackColor = true;
            // 
            // rbComplete
            // 
            this.rbComplete.AutoSize = true;
            this.rbComplete.Location = new System.Drawing.Point(252, 109);
            this.rbComplete.Name = "rbComplete";
            this.rbComplete.Size = new System.Drawing.Size(87, 21);
            this.rbComplete.TabIndex = 66;
            this.rbComplete.TabStop = true;
            this.rbComplete.Text = "Complete";
            this.rbComplete.UseVisualStyleBackColor = true;
            // 
            // rbOnTime
            // 
            this.rbOnTime.AutoSize = true;
            this.rbOnTime.Location = new System.Drawing.Point(161, 109);
            this.rbOnTime.Name = "rbOnTime";
            this.rbOnTime.Size = new System.Drawing.Size(76, 21);
            this.rbOnTime.TabIndex = 65;
            this.rbOnTime.TabStop = true;
            this.rbOnTime.Text = "OnTime";
            this.rbOnTime.UseVisualStyleBackColor = true;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(161, 162);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(267, 96);
            this.txtNotes.TabIndex = 64;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label6.Location = new System.Drawing.Point(24, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 30);
            this.label6.TabIndex = 63;
            this.label6.Text = "Notes : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label5.Location = new System.Drawing.Point(24, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 30);
            this.label5.TabIndex = 62;
            this.label5.Text = "Status : ";
            // 
            // dtpAppointmentDate
            // 
            this.dtpAppointmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAppointmentDate.Location = new System.Drawing.Point(270, 43);
            this.dtpAppointmentDate.Name = "dtpAppointmentDate";
            this.dtpAppointmentDate.Size = new System.Drawing.Size(174, 24);
            this.dtpAppointmentDate.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label4.Location = new System.Drawing.Point(24, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 30);
            this.label4.TabIndex = 60;
            this.label4.Text = "Appointment Date :";
            // 
            // tpPatient
            // 
            this.tpPatient.Controls.Add(this.ctrlPatientsInfo1);
            this.tpPatient.Location = new System.Drawing.Point(4, 25);
            this.tpPatient.Name = "tpPatient";
            this.tpPatient.Padding = new System.Windows.Forms.Padding(3);
            this.tpPatient.Size = new System.Drawing.Size(713, 436);
            this.tpPatient.TabIndex = 1;
            this.tpPatient.Text = "PatientInfo";
            this.tpPatient.UseVisualStyleBackColor = true;
            // 
            // ctrlPatientsInfo1
            // 
            this.ctrlPatientsInfo1.Location = new System.Drawing.Point(8, 7);
            this.ctrlPatientsInfo1.Name = "ctrlPatientsInfo1";
            this.ctrlPatientsInfo1.Size = new System.Drawing.Size(697, 422);
            this.ctrlPatientsInfo1.TabIndex = 1;
            // 
            // tpDoctor
            // 
            this.tpDoctor.Controls.Add(this.ctrlDoctroInfo1);
            this.tpDoctor.Location = new System.Drawing.Point(4, 25);
            this.tpDoctor.Name = "tpDoctor";
            this.tpDoctor.Padding = new System.Windows.Forms.Padding(3);
            this.tpDoctor.Size = new System.Drawing.Size(713, 436);
            this.tpDoctor.TabIndex = 2;
            this.tpDoctor.Text = "DoctorInfo";
            this.tpDoctor.UseVisualStyleBackColor = true;
            // 
            // ctrlDoctroInfo1
            // 
            this.ctrlDoctroInfo1.Location = new System.Drawing.Point(7, 4);
            this.ctrlDoctroInfo1.Name = "ctrlDoctroInfo1";
            this.ctrlDoctroInfo1.Size = new System.Drawing.Size(583, 355);
            this.ctrlDoctroInfo1.TabIndex = 0;
            // 
            // frmAddEditAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 589);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAppointmentID);
            this.Name = "frmAddEditAppointment";
            this.Text = "frmAddEditAppointment";
            this.Load += new System.EventHandler(this.frmAddEditAppointment_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpAppointment.ResumeLayout(false);
            this.tpAppointment.PerformLayout();
            this.tpPatient.ResumeLayout(false);
            this.tpDoctor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblAppointmentID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpAppointment;
        private System.Windows.Forms.TabPage tpPatient;
        private System.Windows.Forms.TabPage tpDoctor;
        private System.Windows.Forms.RadioButton rbCanceled;
        private System.Windows.Forms.RadioButton rbComplete;
        private System.Windows.Forms.RadioButton rbOnTime;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpAppointmentDate;
        private System.Windows.Forms.Label label4;
        private Patients.ctrlPatientsInfo ctrlPatientsInfo1;
        private Doctors.Controls.ctrlDoctroInfo ctrlDoctroInfo1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDoctorID;
        private System.Windows.Forms.Button btnAddPatient;
        private System.Windows.Forms.TextBox txtPatientID;
        private System.Windows.Forms.Button btnAddDoctor;
    }
}