namespace Exercise_4.Views.Alumn
{
    partial class fAlumnCheckCourse
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
            this.gbData = new System.Windows.Forms.GroupBox();
            this.txtbTeachers = new System.Windows.Forms.TextBox();
            this.lblTeachers = new System.Windows.Forms.Label();
            this.txtbCourse = new System.Windows.Forms.TextBox();
            this.lblCourse = new System.Windows.Forms.Label();
            this.gbData.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.txtbTeachers);
            this.gbData.Controls.Add(this.lblTeachers);
            this.gbData.Controls.Add(this.txtbCourse);
            this.gbData.Controls.Add(this.lblCourse);
            this.gbData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbData.Location = new System.Drawing.Point(12, 12);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(473, 212);
            this.gbData.TabIndex = 20;
            this.gbData.TabStop = false;
            this.gbData.Text = "DATA";
            // 
            // txtbTeachers
            // 
            this.txtbTeachers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbTeachers.Location = new System.Drawing.Point(143, 68);
            this.txtbTeachers.Multiline = true;
            this.txtbTeachers.Name = "txtbTeachers";
            this.txtbTeachers.Size = new System.Drawing.Size(313, 125);
            this.txtbTeachers.TabIndex = 14;
            // 
            // lblTeachers
            // 
            this.lblTeachers.AutoSize = true;
            this.lblTeachers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeachers.Location = new System.Drawing.Point(13, 71);
            this.lblTeachers.Name = "lblTeachers";
            this.lblTeachers.Size = new System.Drawing.Size(84, 16);
            this.lblTeachers.TabIndex = 13;
            this.lblTeachers.Text = "TEACHERS:";
            this.lblTeachers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtbCourse
            // 
            this.txtbCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCourse.Location = new System.Drawing.Point(143, 27);
            this.txtbCourse.Name = "txtbCourse";
            this.txtbCourse.Size = new System.Drawing.Size(313, 22);
            this.txtbCourse.TabIndex = 12;
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourse.Location = new System.Drawing.Point(13, 30);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(67, 16);
            this.lblCourse.TabIndex = 11;
            this.lblCourse.Text = "COURSE:";
            this.lblCourse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fAlumnCheckCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 236);
            this.Controls.Add(this.gbData);
            this.Name = "fAlumnCheckCourse";
            this.Text = "Alumn Course";
            this.Load += new System.EventHandler(this.fAlumnCheckCourse_Load);
            this.gbData.ResumeLayout(false);
            this.gbData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.TextBox txtbTeachers;
        private System.Windows.Forms.Label lblTeachers;
        private System.Windows.Forms.TextBox txtbCourse;
        private System.Windows.Forms.Label lblCourse;
    }
}