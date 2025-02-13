namespace HospitalProject.Appointments
{
    partial class frmListAppointments
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAllAppointments = new System.Windows.Forms.DataGridView();
            this.cmsAppointment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.completeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllAppointments)).BeginInit();
            this.cmsAppointment.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 30F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(285, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(518, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Appointments";
            // 
            // dgvAllAppointments
            // 
            this.dgvAllAppointments.AllowUserToAddRows = false;
            this.dgvAllAppointments.AllowUserToDeleteRows = false;
            this.dgvAllAppointments.AllowUserToOrderColumns = true;
            this.dgvAllAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllAppointments.ContextMenuStrip = this.cmsAppointment;
            this.dgvAllAppointments.Location = new System.Drawing.Point(13, 204);
            this.dgvAllAppointments.Name = "dgvAllAppointments";
            this.dgvAllAppointments.ReadOnly = true;
            this.dgvAllAppointments.RowHeadersWidth = 51;
            this.dgvAllAppointments.RowTemplate.Height = 26;
            this.dgvAllAppointments.Size = new System.Drawing.Size(870, 357);
            this.dgvAllAppointments.TabIndex = 1;
            this.dgvAllAppointments.SelectionChanged += new System.EventHandler(this.dgvAllAppointments_SelectionChanged);
            // 
            // cmsAppointment
            // 
            this.cmsAppointment.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsAppointment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.completeToolStripMenuItem,
            this.onTimeToolStripMenuItem,
            this.cancledToolStripMenuItem});
            this.cmsAppointment.Name = "cmsAppointment";
            this.cmsAppointment.Size = new System.Drawing.Size(144, 124);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(332, 168);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(239, 24);
            this.txtFilterValue.TabIndex = 38;
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
            this.cbFilterBy.Location = new System.Drawing.Point(114, 168);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(212, 24);
            this.cbFilterBy.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.Location = new System.Drawing.Point(12, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 24);
            this.label3.TabIndex = 36;
            this.label3.Text = "Filter By :";
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblNumberOfRecords.Location = new System.Drawing.Point(132, 564);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(37, 24);
            this.lblNumberOfRecords.TabIndex = 42;
            this.lblNumberOfRecords.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(12, 564);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 24);
            this.label2.TabIndex = 41;
            this.label2.Text = "# Records :";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnClose.Image = global::HospitalProject.Properties.Resources.icons8_close_50__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(889, 508);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(190, 53);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnAddAppointment.Image = global::HospitalProject.Properties.Resources.add;
            this.btnAddAppointment.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddAppointment.Location = new System.Drawing.Point(898, 204);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(181, 78);
            this.btnAddAppointment.TabIndex = 33;
            this.btnAddAppointment.Text = "Add Appointment";
            this.btnAddAppointment.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // completeToolStripMenuItem
            // 
            this.completeToolStripMenuItem.Name = "completeToolStripMenuItem";
            this.completeToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.completeToolStripMenuItem.Text = "Complete";
            this.completeToolStripMenuItem.Click += new System.EventHandler(this.completeToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // onTimeToolStripMenuItem
            // 
            this.onTimeToolStripMenuItem.Name = "onTimeToolStripMenuItem";
            this.onTimeToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.onTimeToolStripMenuItem.Text = "OnTime";
            this.onTimeToolStripMenuItem.Click += new System.EventHandler(this.onTimeToolStripMenuItem_Click);
            // 
            // cancledToolStripMenuItem
            // 
            this.cancledToolStripMenuItem.Name = "cancledToolStripMenuItem";
            this.cancledToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.cancledToolStripMenuItem.Text = "Canceled";
            this.cancledToolStripMenuItem.Click += new System.EventHandler(this.cancledToolStripMenuItem_Click);
            // 
            // frmListAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 599);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.dgvAllAppointments);
            this.Controls.Add(this.label1);
            this.Name = "frmListAppointments";
            this.Text = "frmListAppointments";
            this.Load += new System.EventHandler(this.frmListAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllAppointments)).EndInit();
            this.cmsAppointment.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAllAppointments;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip cmsAppointment;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancledToolStripMenuItem;
    }
}