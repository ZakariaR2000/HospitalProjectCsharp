namespace HospitalProject
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doctorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clinicAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDoctorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patiantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.medicalRecoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 30F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.peopleToolStripMenuItem,
            this.doctorsToolStripMenuItem,
            this.patiantsToolStripMenuItem,
            this.appointmentsToolStripMenuItem,
            this.medicalRecoreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1041, 48);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(117, 44);
            this.peopleToolStripMenuItem.Text = "People";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // doctorsToolStripMenuItem
            // 
            this.doctorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clinicAddressToolStripMenuItem,
            this.manageDoctorsToolStripMenuItem});
            this.doctorsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.doctorsToolStripMenuItem.Name = "doctorsToolStripMenuItem";
            this.doctorsToolStripMenuItem.Size = new System.Drawing.Size(130, 44);
            this.doctorsToolStripMenuItem.Text = "Doctors";
            this.doctorsToolStripMenuItem.Click += new System.EventHandler(this.doctorsToolStripMenuItem_Click);
            // 
            // clinicAddressToolStripMenuItem
            // 
            this.clinicAddressToolStripMenuItem.Name = "clinicAddressToolStripMenuItem";
            this.clinicAddressToolStripMenuItem.Size = new System.Drawing.Size(319, 44);
            this.clinicAddressToolStripMenuItem.Text = "Clinic Address";
            this.clinicAddressToolStripMenuItem.Click += new System.EventHandler(this.clinicAddressToolStripMenuItem_Click);
            // 
            // manageDoctorsToolStripMenuItem
            // 
            this.manageDoctorsToolStripMenuItem.Name = "manageDoctorsToolStripMenuItem";
            this.manageDoctorsToolStripMenuItem.Size = new System.Drawing.Size(319, 44);
            this.manageDoctorsToolStripMenuItem.Text = "Manage Doctors";
            this.manageDoctorsToolStripMenuItem.Click += new System.EventHandler(this.manageDoctorsToolStripMenuItem_Click);
            // 
            // patiantsToolStripMenuItem
            // 
            this.patiantsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.patiantsToolStripMenuItem.Name = "patiantsToolStripMenuItem";
            this.patiantsToolStripMenuItem.Size = new System.Drawing.Size(131, 44);
            this.patiantsToolStripMenuItem.Text = "Patients";
            this.patiantsToolStripMenuItem.Click += new System.EventHandler(this.patiantsToolStripMenuItem_Click);
            // 
            // appointmentsToolStripMenuItem
            // 
            this.appointmentsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.appointmentsToolStripMenuItem.Name = "appointmentsToolStripMenuItem";
            this.appointmentsToolStripMenuItem.Size = new System.Drawing.Size(212, 44);
            this.appointmentsToolStripMenuItem.Text = "Appointments";
            this.appointmentsToolStripMenuItem.Click += new System.EventHandler(this.appointmentsToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::HospitalProject.Properties.Resources.pexels_pixabay_40568;
            this.pictureBox1.Location = new System.Drawing.Point(0, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1041, 520);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // medicalRecoreToolStripMenuItem
            // 
            this.medicalRecoreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maToolStripMenuItem,
            this.addNewToolStripMenuItem});
            this.medicalRecoreToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.medicalRecoreToolStripMenuItem.Name = "medicalRecoreToolStripMenuItem";
            this.medicalRecoreToolStripMenuItem.Size = new System.Drawing.Size(225, 44);
            this.medicalRecoreToolStripMenuItem.Text = "Medical Recore";
            // 
            // maToolStripMenuItem
            // 
            this.maToolStripMenuItem.Name = "maToolStripMenuItem";
            this.maToolStripMenuItem.Size = new System.Drawing.Size(227, 44);
            this.maToolStripMenuItem.Text = "Manage";
            this.maToolStripMenuItem.Click += new System.EventHandler(this.maToolStripMenuItem_Click);
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(227, 44);
            this.addNewToolStripMenuItem.Text = "Add New";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 568);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doctorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clinicAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDoctorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patiantsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medicalRecoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
    }
}

