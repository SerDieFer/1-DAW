namespace Exercise_3
{
    partial class fTeacher
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
            this.btnAdminUsers = new System.Windows.Forms.Button();
            this.gbAdmin = new System.Windows.Forms.GroupBox();
            this.btnTeacherOptions = new System.Windows.Forms.Button();
            this.gbAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdminUsers
            // 
            this.btnAdminUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminUsers.Location = new System.Drawing.Point(19, 19);
            this.btnAdminUsers.Name = "btnAdminUsers";
            this.btnAdminUsers.Size = new System.Drawing.Size(252, 41);
            this.btnAdminUsers.TabIndex = 0;
            this.btnAdminUsers.Text = "MANAGE COURSE";
            this.btnAdminUsers.UseVisualStyleBackColor = true;
            this.btnAdminUsers.Click += new System.EventHandler(this.btnAdminUsers_Click);
            // 
            // gbAdmin
            // 
            this.gbAdmin.Controls.Add(this.btnTeacherOptions);
            this.gbAdmin.Controls.Add(this.btnAdminUsers);
            this.gbAdmin.Location = new System.Drawing.Point(12, 12);
            this.gbAdmin.Name = "gbAdmin";
            this.gbAdmin.Size = new System.Drawing.Size(285, 140);
            this.gbAdmin.TabIndex = 1;
            this.gbAdmin.TabStop = false;
            // 
            // btnTeacherOptions
            // 
            this.btnTeacherOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeacherOptions.Location = new System.Drawing.Point(19, 77);
            this.btnTeacherOptions.Name = "btnTeacherOptions";
            this.btnTeacherOptions.Size = new System.Drawing.Size(252, 41);
            this.btnTeacherOptions.TabIndex = 1;
            this.btnTeacherOptions.Text = "TEACHER DATA OPTIONS";
            this.btnTeacherOptions.UseVisualStyleBackColor = true;
            this.btnTeacherOptions.Click += new System.EventHandler(this.btnAdminCharacters_Click);
            // 
            // fTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 162);
            this.Controls.Add(this.gbAdmin);
            this.Name = "fTeacher";
            this.Text = "Teacher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fAdmin_FormClosing);
            this.Load += new System.EventHandler(this.fAdmin_Load);
            this.gbAdmin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdminUsers;
        private System.Windows.Forms.GroupBox gbAdmin;
        private System.Windows.Forms.Button btnTeacherOptions;
    }
}