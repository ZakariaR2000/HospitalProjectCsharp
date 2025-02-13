namespace HospitalProject.Doctors
{
    partial class frmListDoctros
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListDoctros));
            this.dgvDoctors = new System.Windows.Forms.DataGridView();
            this.cmsDoctor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDoctorInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showClinicInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).BeginInit();
            this.cmsDoctor.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDoctors
            // 
            this.dgvDoctors.AllowUserToAddRows = false;
            this.dgvDoctors.AllowUserToDeleteRows = false;
            this.dgvDoctors.AllowUserToOrderColumns = true;
            this.dgvDoctors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoctors.ContextMenuStrip = this.cmsDoctor;
            this.dgvDoctors.Location = new System.Drawing.Point(12, 210);
            this.dgvDoctors.Name = "dgvDoctors";
            this.dgvDoctors.ReadOnly = true;
            this.dgvDoctors.RowHeadersWidth = 51;
            this.dgvDoctors.RowTemplate.Height = 26;
            this.dgvDoctors.Size = new System.Drawing.Size(1237, 416);
            this.dgvDoctors.TabIndex = 0;
            this.dgvDoctors.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDoctors_CellDoubleClick);
            // 
            // cmsDoctor
            // 
            this.cmsDoctor.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsDoctor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDoctorInfoToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.showClinicInfoToolStripMenuItem});
            this.cmsDoctor.Name = "cmsDoctor";
            this.cmsDoctor.Size = new System.Drawing.Size(211, 128);
            // 
            // showDoctorInfoToolStripMenuItem
            // 
            this.showDoctorInfoToolStripMenuItem.Name = "showDoctorInfoToolStripMenuItem";
            this.showDoctorInfoToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.showDoctorInfoToolStripMenuItem.Text = "Show Doctor Info";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // showClinicInfoToolStripMenuItem
            // 
            this.showClinicInfoToolStripMenuItem.Name = "showClinicInfoToolStripMenuItem";
            this.showClinicInfoToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.showClinicInfoToolStripMenuItem.Text = "Show Clinic Info";
            this.showClinicInfoToolStripMenuItem.Click += new System.EventHandler(this.showClinicInfoToolStripMenuItem_Click);
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblNumberOfRecords.Location = new System.Drawing.Point(131, 640);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(37, 24);
            this.lblNumberOfRecords.TabIndex = 42;
            this.lblNumberOfRecords.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(11, 640);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 24);
            this.label2.TabIndex = 41;
            this.label2.Text = "# Records :";
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(335, 169);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(239, 24);
            this.txtFilterValue.TabIndex = 45;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Doctor ID",
            "Person ID",
            "Clinic Address ID",
            "Specialization ID",
            "Hire Date",
            "Is Active"});
            this.cbFilterBy.Location = new System.Drawing.Point(117, 169);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(212, 24);
            this.cbFilterBy.TabIndex = 44;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.Location = new System.Drawing.Point(15, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 24);
            this.label3.TabIndex = 43;
            this.label3.Text = "Filter By :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 30F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(438, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 60);
            this.label1.TabIndex = 46;
            this.label1.Text = "Manage Doctros";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1132, 632);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 53);
            this.btnClose.TabIndex = 48;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnAddNew.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.Image")));
            this.btnAddNew.Location = new System.Drawing.Point(1198, 152);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(51, 51);
            this.btnAddNew.TabIndex = 47;
            this.btnAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // frmListDoctros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 692);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDoctors);
            this.Name = "frmListDoctros";
            this.Text = "frmListDoctro";
            this.Load += new System.EventHandler(this.frmListDoctro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).EndInit();
            this.cmsDoctor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDoctors;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmsDoctor;
        private System.Windows.Forms.ToolStripMenuItem showDoctorInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showClinicInfoToolStripMenuItem;
    }
}