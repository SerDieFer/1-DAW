﻿namespace Exercise_6
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
            this.btnRemoveAlumnByID = new System.Windows.Forms.Button();
            this.btnShowAlumnData = new System.Windows.Forms.Button();
            this.btnShowAlumnsFromSelectedCourse = new System.Windows.Forms.Button();
            this.btnSortAlumnsAlphabetically = new System.Windows.Forms.Button();
            this.btnShowAlumnList = new System.Windows.Forms.Button();
            this.btnRemoveAlumnByName = new System.Windows.Forms.Button();
            this.btnAddAlumn = new System.Windows.Forms.Button();
            this.gpGrades = new System.Windows.Forms.GroupBox();
            this.btnRemoveGradesToAlumn = new System.Windows.Forms.Button();
            this.btnAvgGradesLessThan5 = new System.Windows.Forms.Button();
            this.btnAddGradesToAlumn = new System.Windows.Forms.Button();
            this.btnAvgGradesEqualMoreThan5 = new System.Windows.Forms.Button();
            this.gpAlumns.SuspendLayout();
            this.gpGrades.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpAlumns
            // 
            this.gpAlumns.Controls.Add(this.btnRemoveAlumnByID);
            this.gpAlumns.Controls.Add(this.btnShowAlumnData);
            this.gpAlumns.Controls.Add(this.btnShowAlumnsFromSelectedCourse);
            this.gpAlumns.Controls.Add(this.btnSortAlumnsAlphabetically);
            this.gpAlumns.Controls.Add(this.btnShowAlumnList);
            this.gpAlumns.Controls.Add(this.btnRemoveAlumnByName);
            this.gpAlumns.Controls.Add(this.btnAddAlumn);
            this.gpAlumns.Location = new System.Drawing.Point(12, 12);
            this.gpAlumns.Name = "gpAlumns";
            this.gpAlumns.Size = new System.Drawing.Size(861, 149);
            this.gpAlumns.TabIndex = 0;
            this.gpAlumns.TabStop = false;
            this.gpAlumns.Text = "Alumns";
            // 
            // btnRemoveAlumnByID
            // 
            this.btnRemoveAlumnByID.Location = new System.Drawing.Point(453, 19);
            this.btnRemoveAlumnByID.Name = "btnRemoveAlumnByID";
            this.btnRemoveAlumnByID.Size = new System.Drawing.Size(176, 44);
            this.btnRemoveAlumnByID.TabIndex = 8;
            this.btnRemoveAlumnByID.Text = "Remove Alumn By ID";
            this.btnRemoveAlumnByID.UseVisualStyleBackColor = true;
            this.btnRemoveAlumnByID.Click += new System.EventHandler(this.btnRemoveAlumnByID_Click);
            // 
            // btnShowAlumnData
            // 
            this.btnShowAlumnData.Location = new System.Drawing.Point(622, 87);
            this.btnShowAlumnData.Name = "btnShowAlumnData";
            this.btnShowAlumnData.Size = new System.Drawing.Size(219, 44);
            this.btnShowAlumnData.TabIndex = 7;
            this.btnShowAlumnData.Text = "Show Selected Alumn Data";
            this.btnShowAlumnData.UseVisualStyleBackColor = true;
            this.btnShowAlumnData.Click += new System.EventHandler(this.btnShowAlumnData_Click);
            // 
            // btnShowAlumnsFromSelectedCourse
            // 
            this.btnShowAlumnsFromSelectedCourse.Location = new System.Drawing.Point(323, 87);
            this.btnShowAlumnsFromSelectedCourse.Name = "btnShowAlumnsFromSelectedCourse";
            this.btnShowAlumnsFromSelectedCourse.Size = new System.Drawing.Size(264, 44);
            this.btnShowAlumnsFromSelectedCourse.TabIndex = 6;
            this.btnShowAlumnsFromSelectedCourse.Text = "Show All Alumns From Selected Course";
            this.btnShowAlumnsFromSelectedCourse.UseVisualStyleBackColor = true;
            // 
            // btnSortAlumnsAlphabetically
            // 
            this.btnSortAlumnsAlphabetically.Location = new System.Drawing.Point(25, 87);
            this.btnSortAlumnsAlphabetically.Name = "btnSortAlumnsAlphabetically";
            this.btnSortAlumnsAlphabetically.Size = new System.Drawing.Size(264, 44);
            this.btnSortAlumnsAlphabetically.TabIndex = 5;
            this.btnSortAlumnsAlphabetically.Text = "Sort Alumns List Alphabetically ";
            this.btnSortAlumnsAlphabetically.UseVisualStyleBackColor = true;
            this.btnSortAlumnsAlphabetically.Click += new System.EventHandler(this.btnSortAlumnsAlphabetically_Click);
            // 
            // btnShowAlumnList
            // 
            this.btnShowAlumnList.Location = new System.Drawing.Point(664, 19);
            this.btnShowAlumnList.Name = "btnShowAlumnList";
            this.btnShowAlumnList.Size = new System.Drawing.Size(176, 44);
            this.btnShowAlumnList.TabIndex = 4;
            this.btnShowAlumnList.Text = "Show Alumns List";
            this.btnShowAlumnList.UseVisualStyleBackColor = true;
            this.btnShowAlumnList.Click += new System.EventHandler(this.btnShowAlumnList_Click);
            // 
            // btnRemoveAlumnByName
            // 
            this.btnRemoveAlumnByName.Location = new System.Drawing.Point(242, 19);
            this.btnRemoveAlumnByName.Name = "btnRemoveAlumnByName";
            this.btnRemoveAlumnByName.Size = new System.Drawing.Size(175, 44);
            this.btnRemoveAlumnByName.TabIndex = 3;
            this.btnRemoveAlumnByName.Text = "Remove Alumn By Name";
            this.btnRemoveAlumnByName.UseVisualStyleBackColor = true;
            this.btnRemoveAlumnByName.Click += new System.EventHandler(this.btnRemoveAlumnByName_Click);
            // 
            // btnAddAlumn
            // 
            this.btnAddAlumn.Location = new System.Drawing.Point(25, 19);
            this.btnAddAlumn.Name = "btnAddAlumn";
            this.btnAddAlumn.Size = new System.Drawing.Size(175, 44);
            this.btnAddAlumn.TabIndex = 2;
            this.btnAddAlumn.Text = "Add Alumn";
            this.btnAddAlumn.UseVisualStyleBackColor = true;
            this.btnAddAlumn.Click += new System.EventHandler(this.btnAddAlumn_Click);
            // 
            // gpGrades
            // 
            this.gpGrades.Controls.Add(this.btnRemoveGradesToAlumn);
            this.gpGrades.Controls.Add(this.btnAvgGradesLessThan5);
            this.gpGrades.Controls.Add(this.btnAddGradesToAlumn);
            this.gpGrades.Controls.Add(this.btnAvgGradesEqualMoreThan5);
            this.gpGrades.Location = new System.Drawing.Point(12, 167);
            this.gpGrades.Name = "gpGrades";
            this.gpGrades.Size = new System.Drawing.Size(861, 149);
            this.gpGrades.TabIndex = 8;
            this.gpGrades.TabStop = false;
            this.gpGrades.Text = "Grades";
            // 
            // btnRemoveGradesToAlumn
            // 
            this.btnRemoveGradesToAlumn.Location = new System.Drawing.Point(25, 90);
            this.btnRemoveGradesToAlumn.Name = "btnRemoveGradesToAlumn";
            this.btnRemoveGradesToAlumn.Size = new System.Drawing.Size(392, 44);
            this.btnRemoveGradesToAlumn.TabIndex = 9;
            this.btnRemoveGradesToAlumn.Text = "Remove Grades To Selected Alumn";
            this.btnRemoveGradesToAlumn.UseVisualStyleBackColor = true;
            // 
            // btnAvgGradesLessThan5
            // 
            this.btnAvgGradesLessThan5.Location = new System.Drawing.Point(476, 90);
            this.btnAvgGradesLessThan5.Name = "btnAvgGradesLessThan5";
            this.btnAvgGradesLessThan5.Size = new System.Drawing.Size(364, 44);
            this.btnAvgGradesLessThan5.TabIndex = 8;
            this.btnAvgGradesLessThan5.Text = "Show Alumns With Average Grades That Are Less Than 5";
            this.btnAvgGradesLessThan5.UseVisualStyleBackColor = true;
            // 
            // btnAddGradesToAlumn
            // 
            this.btnAddGradesToAlumn.Location = new System.Drawing.Point(25, 19);
            this.btnAddGradesToAlumn.Name = "btnAddGradesToAlumn";
            this.btnAddGradesToAlumn.Size = new System.Drawing.Size(392, 44);
            this.btnAddGradesToAlumn.TabIndex = 7;
            this.btnAddGradesToAlumn.Text = "Add Grades To Selected Alumn";
            this.btnAddGradesToAlumn.UseVisualStyleBackColor = true;
            // 
            // btnAvgGradesEqualMoreThan5
            // 
            this.btnAvgGradesEqualMoreThan5.Location = new System.Drawing.Point(475, 19);
            this.btnAvgGradesEqualMoreThan5.Name = "btnAvgGradesEqualMoreThan5";
            this.btnAvgGradesEqualMoreThan5.Size = new System.Drawing.Size(364, 44);
            this.btnAvgGradesEqualMoreThan5.TabIndex = 6;
            this.btnAvgGradesEqualMoreThan5.Text = "Show Alumns With Average Grades That Are Equal Or More Than 5";
            this.btnAvgGradesEqualMoreThan5.UseVisualStyleBackColor = true;
            // 
            // AlumnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 331);
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
        private System.Windows.Forms.Button btnShowAlumnData;
        private System.Windows.Forms.Button btnShowAlumnsFromSelectedCourse;
        private System.Windows.Forms.Button btnSortAlumnsAlphabetically;
        private System.Windows.Forms.Button btnShowAlumnList;
        private System.Windows.Forms.Button btnRemoveAlumnByName;
        private System.Windows.Forms.GroupBox gpGrades;
        private System.Windows.Forms.Button btnRemoveGradesToAlumn;
        private System.Windows.Forms.Button btnAvgGradesLessThan5;
        private System.Windows.Forms.Button btnAddGradesToAlumn;
        private System.Windows.Forms.Button btnAvgGradesEqualMoreThan5;
        private System.Windows.Forms.Button btnRemoveAlumnByID;
    }
}