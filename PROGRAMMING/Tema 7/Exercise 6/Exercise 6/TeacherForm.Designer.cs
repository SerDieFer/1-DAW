namespace Exercise_6
{
    partial class TeacherForm
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
            this.gpSubjects = new System.Windows.Forms.GroupBox();
            this.btnRemoveSubjectToSelectedTeacher = new System.Windows.Forms.Button();
            this.btnAddSubjectToSelectedTeacher = new System.Windows.Forms.Button();
            this.gpTeachers = new System.Windows.Forms.GroupBox();
            this.btnShowTeacherData = new System.Windows.Forms.Button();
            this.btnSortAlumnsAlphabetically = new System.Windows.Forms.Button();
            this.btnShowTeacherList = new System.Windows.Forms.Button();
            this.btnRemoveTeacher = new System.Windows.Forms.Button();
            this.btnAddTeacher = new System.Windows.Forms.Button();
            this.btnShowTeachersBySelectedSubject = new System.Windows.Forms.Button();
            this.gpSubjects.SuspendLayout();
            this.gpTeachers.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpSubjects
            // 
            this.gpSubjects.Controls.Add(this.btnRemoveSubjectToSelectedTeacher);
            this.gpSubjects.Controls.Add(this.btnShowTeachersBySelectedSubject);
            this.gpSubjects.Controls.Add(this.btnAddSubjectToSelectedTeacher);
            this.gpSubjects.Location = new System.Drawing.Point(12, 167);
            this.gpSubjects.Name = "gpSubjects";
            this.gpSubjects.Size = new System.Drawing.Size(861, 149);
            this.gpSubjects.TabIndex = 10;
            this.gpSubjects.TabStop = false;
            this.gpSubjects.Text = "Subjects";
            // 
            // btnRemoveSubjectToSelectedTeacher
            // 
            this.btnRemoveSubjectToSelectedTeacher.Location = new System.Drawing.Point(476, 19);
            this.btnRemoveSubjectToSelectedTeacher.Name = "btnRemoveSubjectToSelectedTeacher";
            this.btnRemoveSubjectToSelectedTeacher.Size = new System.Drawing.Size(365, 44);
            this.btnRemoveSubjectToSelectedTeacher.TabIndex = 9;
            this.btnRemoveSubjectToSelectedTeacher.Text = "Remove Subject To Selected Teacher";
            this.btnRemoveSubjectToSelectedTeacher.UseVisualStyleBackColor = true;
            // 
            // btnAddSubjectToSelectedTeacher
            // 
            this.btnAddSubjectToSelectedTeacher.Location = new System.Drawing.Point(25, 19);
            this.btnAddSubjectToSelectedTeacher.Name = "btnAddSubjectToSelectedTeacher";
            this.btnAddSubjectToSelectedTeacher.Size = new System.Drawing.Size(392, 44);
            this.btnAddSubjectToSelectedTeacher.TabIndex = 7;
            this.btnAddSubjectToSelectedTeacher.Text = "Add Subject To Selected Teacher";
            this.btnAddSubjectToSelectedTeacher.UseVisualStyleBackColor = true;
            // 
            // gpTeachers
            // 
            this.gpTeachers.Controls.Add(this.btnShowTeacherData);
            this.gpTeachers.Controls.Add(this.btnSortAlumnsAlphabetically);
            this.gpTeachers.Controls.Add(this.btnShowTeacherList);
            this.gpTeachers.Controls.Add(this.btnRemoveTeacher);
            this.gpTeachers.Controls.Add(this.btnAddTeacher);
            this.gpTeachers.Location = new System.Drawing.Point(12, 12);
            this.gpTeachers.Name = "gpTeachers";
            this.gpTeachers.Size = new System.Drawing.Size(861, 149);
            this.gpTeachers.TabIndex = 9;
            this.gpTeachers.TabStop = false;
            this.gpTeachers.Text = "Teachers";
            // 
            // btnShowTeacherData
            // 
            this.btnShowTeacherData.Location = new System.Drawing.Point(476, 87);
            this.btnShowTeacherData.Name = "btnShowTeacherData";
            this.btnShowTeacherData.Size = new System.Drawing.Size(365, 44);
            this.btnShowTeacherData.TabIndex = 7;
            this.btnShowTeacherData.Text = "Show Selected Teacher Data";
            this.btnShowTeacherData.UseVisualStyleBackColor = true;
            // 
            // btnSortAlumnsAlphabetically
            // 
            this.btnSortAlumnsAlphabetically.Location = new System.Drawing.Point(25, 87);
            this.btnSortAlumnsAlphabetically.Name = "btnSortAlumnsAlphabetically";
            this.btnSortAlumnsAlphabetically.Size = new System.Drawing.Size(392, 44);
            this.btnSortAlumnsAlphabetically.TabIndex = 5;
            this.btnSortAlumnsAlphabetically.Text = "Sort Teachers List Alphabetically ";
            this.btnSortAlumnsAlphabetically.UseVisualStyleBackColor = true;
            // 
            // btnShowTeacherList
            // 
            this.btnShowTeacherList.Location = new System.Drawing.Point(598, 19);
            this.btnShowTeacherList.Name = "btnShowTeacherList";
            this.btnShowTeacherList.Size = new System.Drawing.Size(242, 44);
            this.btnShowTeacherList.TabIndex = 4;
            this.btnShowTeacherList.Text = "Show Teachers List";
            this.btnShowTeacherList.UseVisualStyleBackColor = true;
            // 
            // btnRemoveTeacher
            // 
            this.btnRemoveTeacher.Location = new System.Drawing.Point(325, 19);
            this.btnRemoveTeacher.Name = "btnRemoveTeacher";
            this.btnRemoveTeacher.Size = new System.Drawing.Size(226, 44);
            this.btnRemoveTeacher.TabIndex = 3;
            this.btnRemoveTeacher.Text = "Remove Teacher";
            this.btnRemoveTeacher.UseVisualStyleBackColor = true;
            // 
            // btnAddTeacher
            // 
            this.btnAddTeacher.Location = new System.Drawing.Point(24, 19);
            this.btnAddTeacher.Name = "btnAddTeacher";
            this.btnAddTeacher.Size = new System.Drawing.Size(246, 44);
            this.btnAddTeacher.TabIndex = 2;
            this.btnAddTeacher.Text = "Add Teacher";
            this.btnAddTeacher.UseVisualStyleBackColor = true;
            // 
            // btnShowTeachersBySelectedSubject
            // 
            this.btnShowTeachersBySelectedSubject.Location = new System.Drawing.Point(25, 90);
            this.btnShowTeachersBySelectedSubject.Name = "btnShowTeachersBySelectedSubject";
            this.btnShowTeachersBySelectedSubject.Size = new System.Drawing.Size(815, 44);
            this.btnShowTeachersBySelectedSubject.TabIndex = 8;
            this.btnShowTeachersBySelectedSubject.Text = "Show All Teachers By Subject";
            this.btnShowTeachersBySelectedSubject.UseVisualStyleBackColor = true;
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 338);
            this.Controls.Add(this.gpSubjects);
            this.Controls.Add(this.gpTeachers);
            this.Name = "TeacherForm";
            this.Text = "Teachers Management";
            this.Load += new System.EventHandler(this.TeacherForm_Load);
            this.gpSubjects.ResumeLayout(false);
            this.gpTeachers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpSubjects;
        private System.Windows.Forms.Button btnRemoveSubjectToSelectedTeacher;
        private System.Windows.Forms.Button btnAddSubjectToSelectedTeacher;
        private System.Windows.Forms.GroupBox gpTeachers;
        private System.Windows.Forms.Button btnShowTeacherData;
        private System.Windows.Forms.Button btnSortAlumnsAlphabetically;
        private System.Windows.Forms.Button btnShowTeacherList;
        private System.Windows.Forms.Button btnRemoveTeacher;
        private System.Windows.Forms.Button btnAddTeacher;
        private System.Windows.Forms.Button btnShowTeachersBySelectedSubject;
    }
}