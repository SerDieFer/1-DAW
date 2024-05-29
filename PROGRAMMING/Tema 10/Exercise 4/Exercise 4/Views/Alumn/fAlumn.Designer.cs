namespace Exercise_4
{
    partial class fAlumn
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
            this.btnAlumnOptions = new System.Windows.Forms.Button();
            this.btnCourse = new System.Windows.Forms.Button();
            this.gbAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAdmin
            // 
            this.gbAdmin.Controls.Add(this.btnAlumnOptions);
            this.gbAdmin.Controls.Add(this.btnCourse);
            this.gbAdmin.Location = new System.Drawing.Point(12, 12);
            this.gbAdmin.Name = "gbAdmin";
            this.gbAdmin.Size = new System.Drawing.Size(285, 140);
            this.gbAdmin.TabIndex = 2;
            this.gbAdmin.TabStop = false;
            // 
            // btnAlumnOptions
            // 
            this.btnAlumnOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlumnOptions.Location = new System.Drawing.Point(19, 77);
            this.btnAlumnOptions.Name = "btnAlumnOptions";
            this.btnAlumnOptions.Size = new System.Drawing.Size(252, 41);
            this.btnAlumnOptions.TabIndex = 1;
            this.btnAlumnOptions.Text = "ALUMN DATA OPTIONS";
            this.btnAlumnOptions.UseVisualStyleBackColor = true;
            this.btnAlumnOptions.Click += new System.EventHandler(this.btnAlumnOptions_Click);
            // 
            // btnCourse
            // 
            this.btnCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourse.Location = new System.Drawing.Point(19, 19);
            this.btnCourse.Name = "btnCourse";
            this.btnCourse.Size = new System.Drawing.Size(252, 41);
            this.btnCourse.TabIndex = 0;
            this.btnCourse.Text = "CHECK COURSE";
            this.btnCourse.UseVisualStyleBackColor = true;
            this.btnCourse.Click += new System.EventHandler(this.btnAlumnCourses_Click);
            // 
            // fAlumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 165);
            this.Controls.Add(this.gbAdmin);
            this.Name = "fAlumn";
            this.Text = "Alumn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fAlumn_FormClosing);
            this.Load += new System.EventHandler(this.fAlumn_Load);
            this.gbAdmin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAdmin;
        private System.Windows.Forms.Button btnAlumnOptions;
        private System.Windows.Forms.Button btnCourse;
    }
}