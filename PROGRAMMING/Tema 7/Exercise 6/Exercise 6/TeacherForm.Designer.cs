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
            this.btnClearSubjectsToSelectedTeacherByName = new System.Windows.Forms.Button();
            this.btnClearSubjectsToSelectedTeacherByID = new System.Windows.Forms.Button();
            this.btnRemoveSubjectToSelectedTeacherByID = new System.Windows.Forms.Button();
            this.btnAddSubjectToSelectedTeacherByID = new System.Windows.Forms.Button();
            this.btnRemoveSubjectToSelectedTeacherByName = new System.Windows.Forms.Button();
            this.btnShowTeachersBySelectedSubject = new System.Windows.Forms.Button();
            this.btnAddSubjectToSelectedTeacherByName = new System.Windows.Forms.Button();
            this.gpTeachers = new System.Windows.Forms.GroupBox();
            this.btnShowTeacherDataByName = new System.Windows.Forms.Button();
            this.btnRemoveTeacherByName = new System.Windows.Forms.Button();
            this.btnShowTeacherDataByID = new System.Windows.Forms.Button();
            this.btnSortAlumnsAlphabetically = new System.Windows.Forms.Button();
            this.btnShowTeacherList = new System.Windows.Forms.Button();
            this.btnRemoveTeacherByID = new System.Windows.Forms.Button();
            this.btnAddTeacher = new System.Windows.Forms.Button();
            this.gpSubjects.SuspendLayout();
            this.gpTeachers.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpSubjects
            // 
            this.gpSubjects.Controls.Add(this.btnClearSubjectsToSelectedTeacherByName);
            this.gpSubjects.Controls.Add(this.btnClearSubjectsToSelectedTeacherByID);
            this.gpSubjects.Controls.Add(this.btnRemoveSubjectToSelectedTeacherByID);
            this.gpSubjects.Controls.Add(this.btnAddSubjectToSelectedTeacherByID);
            this.gpSubjects.Controls.Add(this.btnRemoveSubjectToSelectedTeacherByName);
            this.gpSubjects.Controls.Add(this.btnShowTeachersBySelectedSubject);
            this.gpSubjects.Controls.Add(this.btnAddSubjectToSelectedTeacherByName);
            this.gpSubjects.Location = new System.Drawing.Point(12, 196);
            this.gpSubjects.Name = "gpSubjects";
            this.gpSubjects.Size = new System.Drawing.Size(920, 291);
            this.gpSubjects.TabIndex = 10;
            this.gpSubjects.TabStop = false;
            this.gpSubjects.Text = "Subjects";
            // 
            // btnClearSubjectsToSelectedTeacherByName
            // 
            this.btnClearSubjectsToSelectedTeacherByName.Location = new System.Drawing.Point(19, 165);
            this.btnClearSubjectsToSelectedTeacherByName.Name = "btnClearSubjectsToSelectedTeacherByName";
            this.btnClearSubjectsToSelectedTeacherByName.Size = new System.Drawing.Size(433, 44);
            this.btnClearSubjectsToSelectedTeacherByName.TabIndex = 13;
            this.btnClearSubjectsToSelectedTeacherByName.Text = "Clear All Subjects To Selected Teacher By Name\r\n";
            this.btnClearSubjectsToSelectedTeacherByName.UseVisualStyleBackColor = true;
            this.btnClearSubjectsToSelectedTeacherByName.Click += new System.EventHandler(this.btnClearSubjectsToSelectedTeacherByName_Click);
            // 
            // btnClearSubjectsToSelectedTeacherByID
            // 
            this.btnClearSubjectsToSelectedTeacherByID.Location = new System.Drawing.Point(470, 165);
            this.btnClearSubjectsToSelectedTeacherByID.Name = "btnClearSubjectsToSelectedTeacherByID";
            this.btnClearSubjectsToSelectedTeacherByID.Size = new System.Drawing.Size(433, 44);
            this.btnClearSubjectsToSelectedTeacherByID.TabIndex = 12;
            this.btnClearSubjectsToSelectedTeacherByID.Text = "Clear All Subjects To Selected Teacher By ID";
            this.btnClearSubjectsToSelectedTeacherByID.UseVisualStyleBackColor = true;
            this.btnClearSubjectsToSelectedTeacherByID.Click += new System.EventHandler(this.btnClearSubjectsToSelectedTeacherByID_Click);
            // 
            // btnRemoveSubjectToSelectedTeacherByID
            // 
            this.btnRemoveSubjectToSelectedTeacherByID.Location = new System.Drawing.Point(470, 97);
            this.btnRemoveSubjectToSelectedTeacherByID.Name = "btnRemoveSubjectToSelectedTeacherByID";
            this.btnRemoveSubjectToSelectedTeacherByID.Size = new System.Drawing.Size(433, 44);
            this.btnRemoveSubjectToSelectedTeacherByID.TabIndex = 11;
            this.btnRemoveSubjectToSelectedTeacherByID.Text = "Remove Subject To Selected Teacher By ID\r\n";
            this.btnRemoveSubjectToSelectedTeacherByID.UseVisualStyleBackColor = true;
            this.btnRemoveSubjectToSelectedTeacherByID.Click += new System.EventHandler(this.btnRemoveSubjectToSelectedTeacherByID_Click);
            // 
            // btnAddSubjectToSelectedTeacherByID
            // 
            this.btnAddSubjectToSelectedTeacherByID.Location = new System.Drawing.Point(470, 29);
            this.btnAddSubjectToSelectedTeacherByID.Name = "btnAddSubjectToSelectedTeacherByID";
            this.btnAddSubjectToSelectedTeacherByID.Size = new System.Drawing.Size(433, 44);
            this.btnAddSubjectToSelectedTeacherByID.TabIndex = 10;
            this.btnAddSubjectToSelectedTeacherByID.Text = "Add Subject To Selected Teacher By ID\r\n";
            this.btnAddSubjectToSelectedTeacherByID.UseVisualStyleBackColor = true;
            this.btnAddSubjectToSelectedTeacherByID.Click += new System.EventHandler(this.btnAddSubjectToSelectedTeacherByID_Click);
            // 
            // btnRemoveSubjectToSelectedTeacherByName
            // 
            this.btnRemoveSubjectToSelectedTeacherByName.Location = new System.Drawing.Point(19, 97);
            this.btnRemoveSubjectToSelectedTeacherByName.Name = "btnRemoveSubjectToSelectedTeacherByName";
            this.btnRemoveSubjectToSelectedTeacherByName.Size = new System.Drawing.Size(433, 44);
            this.btnRemoveSubjectToSelectedTeacherByName.TabIndex = 9;
            this.btnRemoveSubjectToSelectedTeacherByName.Text = "Remove Subject To Selected Teacher By Name";
            this.btnRemoveSubjectToSelectedTeacherByName.UseVisualStyleBackColor = true;
            this.btnRemoveSubjectToSelectedTeacherByName.Click += new System.EventHandler(this.btnRemoveSubjectToSelectedTeacherByName_Click);
            // 
            // btnShowTeachersBySelectedSubject
            // 
            this.btnShowTeachersBySelectedSubject.Location = new System.Drawing.Point(19, 231);
            this.btnShowTeachersBySelectedSubject.Name = "btnShowTeachersBySelectedSubject";
            this.btnShowTeachersBySelectedSubject.Size = new System.Drawing.Size(884, 44);
            this.btnShowTeachersBySelectedSubject.TabIndex = 8;
            this.btnShowTeachersBySelectedSubject.Text = "Show All Teachers By Subject";
            this.btnShowTeachersBySelectedSubject.UseVisualStyleBackColor = true;
            this.btnShowTeachersBySelectedSubject.Click += new System.EventHandler(this.btnShowTeachersBySelectedSubject_Click);
            // 
            // btnAddSubjectToSelectedTeacherByName
            // 
            this.btnAddSubjectToSelectedTeacherByName.Location = new System.Drawing.Point(19, 29);
            this.btnAddSubjectToSelectedTeacherByName.Name = "btnAddSubjectToSelectedTeacherByName";
            this.btnAddSubjectToSelectedTeacherByName.Size = new System.Drawing.Size(433, 44);
            this.btnAddSubjectToSelectedTeacherByName.TabIndex = 7;
            this.btnAddSubjectToSelectedTeacherByName.Text = "Add Subject To Selected Teacher By Name";
            this.btnAddSubjectToSelectedTeacherByName.UseVisualStyleBackColor = true;
            this.btnAddSubjectToSelectedTeacherByName.Click += new System.EventHandler(this.btnAddSubjectToSelectedTeacherByName_Click);
            // 
            // gpTeachers
            // 
            this.gpTeachers.Controls.Add(this.btnShowTeacherDataByName);
            this.gpTeachers.Controls.Add(this.btnRemoveTeacherByName);
            this.gpTeachers.Controls.Add(this.btnShowTeacherDataByID);
            this.gpTeachers.Controls.Add(this.btnSortAlumnsAlphabetically);
            this.gpTeachers.Controls.Add(this.btnShowTeacherList);
            this.gpTeachers.Controls.Add(this.btnRemoveTeacherByID);
            this.gpTeachers.Controls.Add(this.btnAddTeacher);
            this.gpTeachers.Location = new System.Drawing.Point(12, 12);
            this.gpTeachers.Name = "gpTeachers";
            this.gpTeachers.Size = new System.Drawing.Size(920, 178);
            this.gpTeachers.TabIndex = 9;
            this.gpTeachers.TabStop = false;
            this.gpTeachers.Text = "Teachers";
            // 
            // btnShowTeacherDataByName
            // 
            this.btnShowTeacherDataByName.Location = new System.Drawing.Point(472, 104);
            this.btnShowTeacherDataByName.Name = "btnShowTeacherDataByName";
            this.btnShowTeacherDataByName.Size = new System.Drawing.Size(207, 44);
            this.btnShowTeacherDataByName.TabIndex = 9;
            this.btnShowTeacherDataByName.Text = "Show Selected Teacher Data By Name";
            this.btnShowTeacherDataByName.UseVisualStyleBackColor = true;
            this.btnShowTeacherDataByName.Click += new System.EventHandler(this.btnShowTeacherDataByName_Click);
            // 
            // btnRemoveTeacherByName
            // 
            this.btnRemoveTeacherByName.Location = new System.Drawing.Point(472, 36);
            this.btnRemoveTeacherByName.Name = "btnRemoveTeacherByName";
            this.btnRemoveTeacherByName.Size = new System.Drawing.Size(207, 44);
            this.btnRemoveTeacherByName.TabIndex = 8;
            this.btnRemoveTeacherByName.Text = "Remove Teacher By Name";
            this.btnRemoveTeacherByName.UseVisualStyleBackColor = true;
            this.btnRemoveTeacherByName.Click += new System.EventHandler(this.btnRemoveTeacherByName_Click);
            // 
            // btnShowTeacherDataByID
            // 
            this.btnShowTeacherDataByID.Location = new System.Drawing.Point(245, 104);
            this.btnShowTeacherDataByID.Name = "btnShowTeacherDataByID";
            this.btnShowTeacherDataByID.Size = new System.Drawing.Size(207, 44);
            this.btnShowTeacherDataByID.TabIndex = 7;
            this.btnShowTeacherDataByID.Text = "Show Selected Teacher Data By ID";
            this.btnShowTeacherDataByID.UseVisualStyleBackColor = true;
            this.btnShowTeacherDataByID.Click += new System.EventHandler(this.btnShowTeacherDataByID_Click);
            // 
            // btnSortAlumnsAlphabetically
            // 
            this.btnSortAlumnsAlphabetically.Location = new System.Drawing.Point(19, 104);
            this.btnSortAlumnsAlphabetically.Name = "btnSortAlumnsAlphabetically";
            this.btnSortAlumnsAlphabetically.Size = new System.Drawing.Size(207, 44);
            this.btnSortAlumnsAlphabetically.TabIndex = 5;
            this.btnSortAlumnsAlphabetically.Text = "Sort Teachers List Alphabetically ";
            this.btnSortAlumnsAlphabetically.UseVisualStyleBackColor = true;
            this.btnSortAlumnsAlphabetically.Click += new System.EventHandler(this.btnSortAlumnsAlphabetically_Click);
            // 
            // btnShowTeacherList
            // 
            this.btnShowTeacherList.Location = new System.Drawing.Point(696, 36);
            this.btnShowTeacherList.Name = "btnShowTeacherList";
            this.btnShowTeacherList.Size = new System.Drawing.Size(207, 112);
            this.btnShowTeacherList.TabIndex = 4;
            this.btnShowTeacherList.Text = "Show Teachers List";
            this.btnShowTeacherList.UseVisualStyleBackColor = true;
            this.btnShowTeacherList.Click += new System.EventHandler(this.btnShowTeacherList_Click);
            // 
            // btnRemoveTeacherByID
            // 
            this.btnRemoveTeacherByID.Location = new System.Drawing.Point(245, 36);
            this.btnRemoveTeacherByID.Name = "btnRemoveTeacherByID";
            this.btnRemoveTeacherByID.Size = new System.Drawing.Size(207, 44);
            this.btnRemoveTeacherByID.TabIndex = 3;
            this.btnRemoveTeacherByID.Text = "Remove Teacher By ID";
            this.btnRemoveTeacherByID.UseVisualStyleBackColor = true;
            this.btnRemoveTeacherByID.Click += new System.EventHandler(this.btnRemoveTeacherByID_Click);
            // 
            // btnAddTeacher
            // 
            this.btnAddTeacher.Location = new System.Drawing.Point(19, 36);
            this.btnAddTeacher.Name = "btnAddTeacher";
            this.btnAddTeacher.Size = new System.Drawing.Size(207, 44);
            this.btnAddTeacher.TabIndex = 2;
            this.btnAddTeacher.Text = "Add Teacher";
            this.btnAddTeacher.UseVisualStyleBackColor = true;
            this.btnAddTeacher.Click += new System.EventHandler(this.btnAddTeacher_Click);
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 499);
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
        private System.Windows.Forms.Button btnRemoveSubjectToSelectedTeacherByName;
        private System.Windows.Forms.Button btnAddSubjectToSelectedTeacherByName;
        private System.Windows.Forms.GroupBox gpTeachers;
        private System.Windows.Forms.Button btnShowTeacherDataByID;
        private System.Windows.Forms.Button btnSortAlumnsAlphabetically;
        private System.Windows.Forms.Button btnShowTeacherList;
        private System.Windows.Forms.Button btnRemoveTeacherByID;
        private System.Windows.Forms.Button btnAddTeacher;
        private System.Windows.Forms.Button btnShowTeachersBySelectedSubject;
        private System.Windows.Forms.Button btnRemoveTeacherByName;
        private System.Windows.Forms.Button btnShowTeacherDataByName;
        private System.Windows.Forms.Button btnRemoveSubjectToSelectedTeacherByID;
        private System.Windows.Forms.Button btnAddSubjectToSelectedTeacherByID;
        private System.Windows.Forms.Button btnClearSubjectsToSelectedTeacherByName;
        private System.Windows.Forms.Button btnClearSubjectsToSelectedTeacherByID;
    }
}