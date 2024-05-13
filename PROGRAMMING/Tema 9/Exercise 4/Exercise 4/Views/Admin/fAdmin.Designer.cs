namespace Exercise_4.Views.Admin
{
    partial class fAdmin
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
            this.gbAdmin = new System.Windows.Forms.GroupBox();
            this.btnTeacherData = new System.Windows.Forms.Button();
            this.btnAlumnData = new System.Windows.Forms.Button();
            this.btnCourses = new System.Windows.Forms.Button();
            this.gbAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAdmin
            // 
            this.gbAdmin.Controls.Add(this.btnCourses);
            this.gbAdmin.Controls.Add(this.btnTeacherData);
            this.gbAdmin.Controls.Add(this.btnAlumnData);
            this.gbAdmin.Location = new System.Drawing.Point(12, 12);
            this.gbAdmin.Name = "gbAdmin";
            this.gbAdmin.Size = new System.Drawing.Size(285, 197);
            this.gbAdmin.TabIndex = 3;
            this.gbAdmin.TabStop = false;
            // 
            // btnTeacherData
            // 
            this.btnTeacherData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeacherData.Location = new System.Drawing.Point(19, 77);
            this.btnTeacherData.Name = "btnTeacherData";
            this.btnTeacherData.Size = new System.Drawing.Size(252, 41);
            this.btnTeacherData.TabIndex = 1;
            this.btnTeacherData.Text = "TEACHERS";
            this.btnTeacherData.UseVisualStyleBackColor = true;
            // 
            // btnAlumnData
            // 
            this.btnAlumnData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlumnData.Location = new System.Drawing.Point(19, 133);
            this.btnAlumnData.Name = "btnAlumnData";
            this.btnAlumnData.Size = new System.Drawing.Size(252, 41);
            this.btnAlumnData.TabIndex = 0;
            this.btnAlumnData.Text = "ALUMNS";
            this.btnAlumnData.UseVisualStyleBackColor = true;
            // 
            // btnCourses
            // 
            this.btnCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourses.Location = new System.Drawing.Point(19, 19);
            this.btnCourses.Name = "btnCourses";
            this.btnCourses.Size = new System.Drawing.Size(252, 41);
            this.btnCourses.TabIndex = 2;
            this.btnCourses.Text = "COURSES";
            this.btnCourses.UseVisualStyleBackColor = true;
            // 
            // fAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 221);
            this.Controls.Add(this.gbAdmin);
            this.Name = "fAdmin";
            this.Text = "Admin";
            this.gbAdmin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAdmin;
        private System.Windows.Forms.Button btnCourses;
        private System.Windows.Forms.Button btnTeacherData;
        private System.Windows.Forms.Button btnAlumnData;
    }
}