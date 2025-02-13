namespace HospitalProject.Clinic
{
    partial class frmListClinicAddress
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
            this.dgvClinicAddress = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmsClinicAddress = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.doctoInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinicAddress)).BeginInit();
            this.cmsClinicAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClinicAddress
            // 
            this.dgvClinicAddress.AllowUserToAddRows = false;
            this.dgvClinicAddress.AllowUserToDeleteRows = false;
            this.dgvClinicAddress.AllowUserToOrderColumns = true;
            this.dgvClinicAddress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClinicAddress.ContextMenuStrip = this.cmsClinicAddress;
            this.dgvClinicAddress.Location = new System.Drawing.Point(12, 165);
            this.dgvClinicAddress.Name = "dgvClinicAddress";
            this.dgvClinicAddress.ReadOnly = true;
            this.dgvClinicAddress.RowHeadersWidth = 51;
            this.dgvClinicAddress.RowTemplate.Height = 26;
            this.dgvClinicAddress.Size = new System.Drawing.Size(950, 303);
            this.dgvClinicAddress.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 30F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(210, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(518, 60);
            this.label1.TabIndex = 34;
            this.label1.Text = "Manage Clinic Address";
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblNumberOfRecords.Location = new System.Drawing.Point(132, 486);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(37, 24);
            this.lblNumberOfRecords.TabIndex = 42;
            this.lblNumberOfRecords.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(12, 486);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 24);
            this.label2.TabIndex = 41;
            this.label2.Text = "# Records :";
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(334, 135);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(239, 24);
            this.txtFilterValue.TabIndex = 45;
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Person ID",
            "National No",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Nationality",
            "Gendor",
            "Phone",
            "Email"});
            this.cbFilterBy.Location = new System.Drawing.Point(116, 135);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(212, 24);
            this.cbFilterBy.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.Location = new System.Drawing.Point(14, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 24);
            this.label3.TabIndex = 43;
            this.label3.Text = "Filter By :";
            // 
            // cmsClinicAddress
            // 
            this.cmsClinicAddress.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsClinicAddress.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doctoInfoToolStripMenuItem});
            this.cmsClinicAddress.Name = "cmsClinicAddress";
            this.cmsClinicAddress.Size = new System.Drawing.Size(211, 56);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnClose.Image = global::HospitalProject.Properties.Resources.icons8_close_50__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(845, 472);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 53);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnAddNew.Image = global::HospitalProject.Properties.Resources.add;
            this.btnAddNew.Location = new System.Drawing.Point(905, 95);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(51, 51);
            this.btnAddNew.TabIndex = 33;
            this.btnAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // doctoInfoToolStripMenuItem
            // 
            this.doctoInfoToolStripMenuItem.Name = "doctoInfoToolStripMenuItem";
            this.doctoInfoToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.doctoInfoToolStripMenuItem.Text = "DoctoInfo";
            this.doctoInfoToolStripMenuItem.Click += new System.EventHandler(this.doctoInfoToolStripMenuItem_Click);
            // 
            // frmListClinicAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 531);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.dgvClinicAddress);
            this.Name = "frmListClinicAddress";
            this.Text = "frmListClinicAddress";
            this.Load += new System.EventHandler(this.frmListClinicAddress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinicAddress)).EndInit();
            this.cmsClinicAddress.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClinicAddress;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmsClinicAddress;
        private System.Windows.Forms.ToolStripMenuItem doctoInfoToolStripMenuItem;
    }
}