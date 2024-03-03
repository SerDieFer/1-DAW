namespace Exercise_6
{
    partial class AlumnForm
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
            this.gpAlumns = new System.Windows.Forms.GroupBox();
            this.btnShowAlumnDataByName = new System.Windows.Forms.Button();
            this.btnRemoveAlumnByID = new System.Windows.Forms.Button();
            this.btnShowAlumnDataByID = new System.Windows.Forms.Button();
            this.btnShowAlumnsFromSelectedCourse = new System.Windows.Forms.Button();
            this.btnSortAlumnsAlphabetically = new System.Windows.Forms.Button();
            this.btnShowAlumnList = new System.Windows.Forms.Button();
            this.btnRemoveAlumnByName = new System.Windows.Forms.Button();
            this.btnAddAlumn = new System.Windows.Forms.Button();
            this.gpGrades = new System.Windows.Forms.GroupBox();
            this.btnClearAllGradesToAlumnByID = new System.Windows.Forms.Button();
            this.btnRemoveGradesToAlumnByID = new System.Windows.Forms.Button();
            this.btnAddGradesToAlumnByID = new System.Windows.Forms.Button();
            this.btnClearAllGradesToAlumnByName = new System.Windows.Forms.Button();
            this.btnRemoveGradesToAlumnByName = new System.Windows.Forms.Button();
            this.btnAvgGradesLessThan5 = new System.Windows.Forms.Button();
            this.btnAddGradesToAlumnByName = new System.Windows.Forms.Button();
            this.btnAvgGradesEqualMoreThan5 = new System.Windows.Forms.Button();
            this.gpAlumns.SuspendLayout();
            this.gpGrades.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpAlumns
            // 
            this.gpAlumns.Controls.Add(this.btnShowAlumnDataByName);
            this.gpAlumns.Controls.Add(this.btnRemoveAlumnByID);
            this.gpAlumns.Controls.Add(this.btnShowAlumnDataByID);
            this.gpAlumns.Controls.Add(this.btnShowAlumnsFromSelectedCourse);
            this.gpAlumns.Controls.Add(this.btnSortAlumnsAlphabetically);
            this.gpAlumns.Controls.Add(this.btnShowAlumnList);
            this.gpAlumns.Controls.Add(this.btnRemoveAlumnByName);
            this.gpAlumns.Controls.Add(this.btnAddAlumn);
            this.gpAlumns.Location = new System.Drawing.Point(12, 12);
            this.gpAlumns.Name = "gpAlumns";
            this.gpAlumns.Size = new System.Drawing.Size(881, 168);
            this.gpAlumns.TabIndex = 0;
            this.gpAlumns.TabStop = false;
            this.gpAlumns.Text = "Alumns";
            // 
            // btnShowAlumnDataByName
            // 
            this.btnShowAlumnDataByName.Location = new System.Drawing.Point(231, 96);
            this.btnShowAlumnDataByName.Name = "btnShowAlumnDataByName";
            this.btnShowAlumnDataByName.Size = new System.Drawing.Size(197, 44);
            this.btnShowAlumnDataByName.TabIndex = 9;
            this.btnShowAlumnDataByName.Text = "Show Selected Alumn Data By Name";
            this.btnShowAlumnDataByName.UseVisualStyleBackColor = true;
            this.btnShowAlumnDataByName.Click += new System.EventHandler(this.btnShowAlumnDataByName_Click);
            // 
            // btnRemoveAlumnByID
            // 
            this.btnRemoveAlumnByID.Location = new System.Drawing.Point(448, 28);
            this.btnRemoveAlumnByID.Name = "btnRemoveAlumnByID";
            this.btnRemoveAlumnByID.Size = new System.Drawing.Size(197, 44);
            this.btnRemoveAlumnByID.TabIndex = 8;
            this.btnRemoveAlumnByID.Text = "Remove Alumn By ID";
            this.btnRemoveAlumnByID.UseVisualStyleBackColor = true;
            this.btnRemoveAlumnByID.Click += new System.EventHandler(this.btnRemoveAlumnByID_Click);
            // 
            // btnShowAlumnDataByID
            // 
            this.btnShowAlumnDataByID.Location = new System.Drawing.Point(448, 96);
            this.btnShowAlumnDataByID.Name = "btnShowAlumnDataByID";
            this.btnShowAlumnDataByID.Size = new System.Drawing.Size(197, 44);
            this.btnShowAlumnDataByID.TabIndex = 7;
            this.btnShowAlumnDataByID.Text = "Show Selected Alumn Data By ID";
            this.btnShowAlumnDataByID.UseVisualStyleBackColor = true;
            this.btnShowAlumnDataByID.Click += new System.EventHandler(this.btnShowAlumnDataByID_Click);
            // 
            // btnShowAlumnsFromSelectedCourse
            // 
            this.btnShowAlumnsFromSelectedCourse.Location = new System.Drawing.Point(669, 96);
            this.btnShowAlumnsFromSelectedCourse.Name = "btnShowAlumnsFromSelectedCourse";
            this.btnShowAlumnsFromSelectedCourse.Size = new System.Drawing.Size(197, 44);
            this.btnShowAlumnsFromSelectedCourse.TabIndex = 6;
            this.btnShowAlumnsFromSelectedCourse.Text = "Show Alumns From Selected Course";
            this.btnShowAlumnsFromSelectedCourse.UseVisualStyleBackColor = true;
            this.btnShowAlumnsFromSelectedCourse.Click += new System.EventHandler(this.btnShowAlumnsFromSelectedCourse_Click);
            // 
            // btnSortAlumnsAlphabetically
            // 
            this.btnSortAlumnsAlphabetically.Location = new System.Drawing.Point(17, 96);
            this.btnSortAlumnsAlphabetically.Name = "btnSortAlumnsAlphabetically";
            this.btnSortAlumnsAlphabetically.Size = new System.Drawing.Size(197, 44);
            this.btnSortAlumnsAlphabetically.TabIndex = 5;
            this.btnSortAlumnsAlphabetically.Text = "Sort Alumns List Alphabetically ";
            this.btnSortAlumnsAlphabetically.UseVisualStyleBackColor = true;
            this.btnSortAlumnsAlphabetically.Click += new System.EventHandler(this.btnSortAlumnsAlphabetically_Click);
            // 
            // btnShowAlumnList
            // 
            this.btnShowAlumnList.Location = new System.Drawing.Point(669, 28);
            this.btnShowAlumnList.Name = "btnShowAlumnList";
            this.btnShowAlumnList.Size = new System.Drawing.Size(197, 44);
            this.btnShowAlumnList.TabIndex = 4;
            this.btnShowAlumnList.Text = "Show Alumns List";
            this.btnShowAlumnList.UseVisualStyleBackColor = true;
            this.btnShowAlumnList.Click += new System.EventHandler(this.btnShowAlumnList_Click);
            // 
            // btnRemoveAlumnByName
            // 
            this.btnRemoveAlumnByName.Location = new System.Drawing.Point(231, 28);
            this.btnRemoveAlumnByName.Name = "btnRemoveAlumnByName";
            this.btnRemoveAlumnByName.Size = new System.Drawing.Size(197, 44);
            this.btnRemoveAlumnByName.TabIndex = 3;
            this.btnRemoveAlumnByName.Text = "Remove Alumn By Name";
            this.btnRemoveAlumnByName.UseVisualStyleBackColor = true;
            this.btnRemoveAlumnByName.Click += new System.EventHandler(this.btnRemoveAlumnByName_Click);
            // 
            // btnAddAlumn
            // 
            this.btnAddAlumn.Location = new System.Drawing.Point(17, 28);
            this.btnAddAlumn.Name = "btnAddAlumn";
            this.btnAddAlumn.Size = new System.Drawing.Size(197, 44);
            this.btnAddAlumn.TabIndex = 2;
            this.btnAddAlumn.Text = "Add Alumn";
            this.btnAddAlumn.UseVisualStyleBackColor = true;
            this.btnAddAlumn.Click += new System.EventHandler(this.btnAddAlumn_Click);
            // 
            // gpGrades
            // 
            this.gpGrades.Controls.Add(this.btnClearAllGradesToAlumnByID);
            this.gpGrades.Controls.Add(this.btnRemoveGradesToAlumnByID);
            this.gpGrades.Controls.Add(this.btnAddGradesToAlumnByID);
            this.gpGrades.Controls.Add(this.btnClearAllGradesToAlumnByName);
            this.gpGrades.Controls.Add(this.btnRemoveGradesToAlumnByName);
            this.gpGrades.Controls.Add(this.btnAvgGradesLessThan5);
            this.gpGrades.Controls.Add(this.btnAddGradesToAlumnByName);
            this.gpGrades.Controls.Add(this.btnAvgGradesEqualMoreThan5);
            this.gpGrades.Location = new System.Drawing.Point(12, 196);
            this.gpGrades.Name = "gpGrades";
            this.gpGrades.Size = new System.Drawing.Size(881, 231);
            this.gpGrades.TabIndex = 8;
            this.gpGrades.TabStop = false;
            this.gpGrades.Text = "Grades";
            // 
            // btnClearAllGradesToAlumnByID
            // 
            this.btnClearAllGradesToAlumnByID.Location = new System.Drawing.Point(603, 90);
            this.btnClearAllGradesToAlumnByID.Name = "btnClearAllGradesToAlumnByID";
            this.btnClearAllGradesToAlumnByID.Size = new System.Drawing.Size(263, 44);
            this.btnClearAllGradesToAlumnByID.TabIndex = 13;
            this.btnClearAllGradesToAlumnByID.Text = "Clear All Grades From Selected Alumn By ID\r\n";
            this.btnClearAllGradesToAlumnByID.UseVisualStyleBackColor = true;
            this.btnClearAllGradesToAlumnByID.Click += new System.EventHandler(this.btnClearAllGradesToAlumnByID_Click);
            // 
            // btnRemoveGradesToAlumnByID
            // 
            this.btnRemoveGradesToAlumnByID.Location = new System.Drawing.Point(311, 90);
            this.btnRemoveGradesToAlumnByID.Name = "btnRemoveGradesToAlumnByID";
            this.btnRemoveGradesToAlumnByID.Size = new System.Drawing.Size(263, 44);
            this.btnRemoveGradesToAlumnByID.TabIndex = 12;
            this.btnRemoveGradesToAlumnByID.Text = "Remove Selected Grades To Alumn By ID\r\n";
            this.btnRemoveGradesToAlumnByID.UseVisualStyleBackColor = true;
            this.btnRemoveGradesToAlumnByID.Click += new System.EventHandler(this.btnRemoveGradesToAlumnByID_Click);
            // 
            // btnAddGradesToAlumnByID
            // 
            this.btnAddGradesToAlumnByID.Location = new System.Drawing.Point(17, 90);
            this.btnAddGradesToAlumnByID.Name = "btnAddGradesToAlumnByID";
            this.btnAddGradesToAlumnByID.Size = new System.Drawing.Size(263, 44);
            this.btnAddGradesToAlumnByID.TabIndex = 11;
            this.btnAddGradesToAlumnByID.Text = "Add Grades To Selected Alumn By ID";
            this.btnAddGradesToAlumnByID.UseVisualStyleBackColor = true;
            this.btnAddGradesToAlumnByID.Click += new System.EventHandler(this.btnAddGradesToAlumnByID_Click);
            // 
            // btnClearAllGradesToAlumnByName
            // 
            this.btnClearAllGradesToAlumnByName.Location = new System.Drawing.Point(603, 19);
            this.btnClearAllGradesToAlumnByName.Name = "btnClearAllGradesToAlumnByName";
            this.btnClearAllGradesToAlumnByName.Size = new System.Drawing.Size(263, 44);
            this.btnClearAllGradesToAlumnByName.TabIndex = 10;
            this.btnClearAllGradesToAlumnByName.Text = "Clear All Grades From Selected Alumn By Name";
            this.btnClearAllGradesToAlumnByName.UseVisualStyleBackColor = true;
            this.btnClearAllGradesToAlumnByName.Click += new System.EventHandler(this.btnClearAllGradesToAlumnByName_Click);
            // 
            // btnRemoveGradesToAlumnByName
            // 
            this.btnRemoveGradesToAlumnByName.Location = new System.Drawing.Point(311, 19);
            this.btnRemoveGradesToAlumnByName.Name = "btnRemoveGradesToAlumnByName";
            this.btnRemoveGradesToAlumnByName.Size = new System.Drawing.Size(263, 44);
            this.btnRemoveGradesToAlumnByName.TabIndex = 9;
            this.btnRemoveGradesToAlumnByName.Text = "Remove Selected Grades To Alumn By Name";
            this.btnRemoveGradesToAlumnByName.UseVisualStyleBackColor = true;
            this.btnRemoveGradesToAlumnByName.Click += new System.EventHandler(this.btnRemoveGradesToAlumnByName_Click);
            // 
            // btnAvgGradesLessThan5
            // 
            this.btnAvgGradesLessThan5.Location = new System.Drawing.Point(455, 161);
            this.btnAvgGradesLessThan5.Name = "btnAvgGradesLessThan5";
            this.btnAvgGradesLessThan5.Size = new System.Drawing.Size(411, 44);
            this.btnAvgGradesLessThan5.TabIndex = 8;
            this.btnAvgGradesLessThan5.Text = "Show Alumns With Average Grades That Are Less Than 5";
            this.btnAvgGradesLessThan5.UseVisualStyleBackColor = true;
            this.btnAvgGradesLessThan5.Click += new System.EventHandler(this.btnAvgGradesLessThan5_Click);
            // 
            // btnAddGradesToAlumnByName
            // 
            this.btnAddGradesToAlumnByName.Location = new System.Drawing.Point(17, 19);
            this.btnAddGradesToAlumnByName.Name = "btnAddGradesToAlumnByName";
            this.btnAddGradesToAlumnByName.Size = new System.Drawing.Size(263, 44);
            this.btnAddGradesToAlumnByName.TabIndex = 7;
            this.btnAddGradesToAlumnByName.Text = "Add Grades To Selected Alumn By Name";
            this.btnAddGradesToAlumnByName.UseVisualStyleBackColor = true;
            this.btnAddGradesToAlumnByName.Click += new System.EventHandler(this.btnAddGradesToAlumnByName_Click);
            // 
            // btnAvgGradesEqualMoreThan5
            // 
            this.btnAvgGradesEqualMoreThan5.Location = new System.Drawing.Point(17, 161);
            this.btnAvgGradesEqualMoreThan5.Name = "btnAvgGradesEqualMoreThan5";
            this.btnAvgGradesEqualMoreThan5.Size = new System.Drawing.Size(411, 44);
            this.btnAvgGradesEqualMoreThan5.TabIndex = 6;
            this.btnAvgGradesEqualMoreThan5.Text = "Show Alumns With Average Grades That Are Equal Or More Than 5";
            this.btnAvgGradesEqualMoreThan5.UseVisualStyleBackColor = true;
            this.btnAvgGradesEqualMoreThan5.Click += new System.EventHandler(this.btnAvgGradesEqualMoreThan5_Click);
            // 
            // AlumnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 444);
            this.Controls.Add(this.gpGrades);
            this.Controls.Add(this.gpAlumns);
            this.Name = "AlumnForm";
            this.Text = "Alumns Management";
            this.Load += new System.EventHandler(this.AlumnForm_Load);
            this.gpAlumns.ResumeLayout(false);
            this.gpGrades.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpAlumns;
        private System.Windows.Forms.Button btnAddAlumn;
        private System.Windows.Forms.Button btnShowAlumnDataByID;
        private System.Windows.Forms.Button btnShowAlumnsFromSelectedCourse;
        private System.Windows.Forms.Button btnSortAlumnsAlphabetically;
        private System.Windows.Forms.Button btnShowAlumnList;
        private System.Windows.Forms.Button btnRemoveAlumnByName;
        private System.Windows.Forms.GroupBox gpGrades;
        private System.Windows.Forms.Button btnRemoveGradesToAlumnByName;
        private System.Windows.Forms.Button btnAvgGradesLessThan5;
        private System.Windows.Forms.Button btnAddGradesToAlumnByName;
        private System.Windows.Forms.Button btnAvgGradesEqualMoreThan5;
        private System.Windows.Forms.Button btnRemoveAlumnByID;
        private System.Windows.Forms.Button btnShowAlumnDataByName;
        private System.Windows.Forms.Button btnClearAllGradesToAlumnByName;
        private System.Windows.Forms.Button btnClearAllGradesToAlumnByID;
        private System.Windows.Forms.Button btnRemoveGradesToAlumnByID;
        private System.Windows.Forms.Button btnAddGradesToAlumnByID;
    }
}