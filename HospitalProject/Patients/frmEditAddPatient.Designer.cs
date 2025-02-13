namespace HospitalProject.Patients
{
    partial class frmEditAddPatient
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
            this.ctrlPersonCardWithFilter1 = new HospitalProject.People.Controls.ctrlPersonCardWithFilter();
            this.btnCompleteTheEntry = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(190, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(83, 41);
            this.lblTitle.TabIndex = 41;
            this.lblTitle.Text = "Title";
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(12, 60);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(452, 529);
            this.ctrlPersonCardWithFilter1.TabIndex = 42;
            // 
            // btnCompleteTheEntry
            // 
            this.btnCompleteTheEntry.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnCompleteTheEntry.Image = global::HospitalProject.Properties.Resources.next_189253;
            this.btnCompleteTheEntry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompleteTheEntry.Location = new System.Drawing.Point(197, 527);
            this.btnCompleteTheEntry.Name = "btnCompleteTheEntry";
            this.btnCompleteTheEntry.Size = new System.Drawing.Size(133, 53);
            this.btnCompleteTheEntry.TabIndex = 45;
            this.btnCompleteTheEntry.Text = "Complete";
            this.btnCompleteTheEntry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCompleteTheEntry.UseVisualStyleBackColor = true;
            this.btnCompleteTheEntry.Click += new System.EventHandler(this.btnCompleteTheEntry_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnClose.Image = global::HospitalProject.Properties.Resources.icons8_close_50__1_;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(341, 527);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 53);
            this.btnClose.TabIndex = 44;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmEditAddPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 601);
            this.Controls.Add(this.btnCompleteTheEntry);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmEditAddPatient";
            this.Text = "frmEditAddPatient";
            this.Load += new System.EventHandler(this.frmEditAddPatient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private People.Controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.Button btnCompleteTheEntry;
        private System.Windows.Forms.Button btnClose;
    }
}