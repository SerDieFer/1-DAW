namespace Exercise_4.Views.Admin
{
    partial class fCourseManagement
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
            this.gpCourseExtraOption = new System.Windows.Forms.GroupBox();
            this.btnListCourses = new System.Windows.Forms.Button();
            this.btnSearchCourse = new System.Windows.Forms.Button();
            this.gpCourseUpdateDelete = new System.Windows.Forms.GroupBox();
            this.btnCourseDelete = new System.Windows.Forms.Button();
            this.btnCourseUpdate = new System.Windows.Forms.Button();
            this.gpCourseNewRegistry = new System.Windows.Forms.GroupBox();
            this.btnCourseCancelAddRegistry = new System.Windows.Forms.Button();
            this.btnCourseClear = new System.Windows.Forms.Button();
            this.btnCourseSave = new System.Windows.Forms.Button();
            this.gpCourseNavigate = new System.Windows.Forms.GroupBox();
            this.btnCoursePrevious = new System.Windows.Forms.Button();
            this.btnCourseNext = new System.Windows.Forms.Button();
            this.btnCourseLast = new System.Windows.Forms.Button();
            this.btnCourseFirst = new System.Windows.Forms.Button();
            this.gbCourseData = new System.Windows.Forms.GroupBox();
            this.lblRecord = new System.Windows.Forms.Label();
            this.txtbCourseID = new System.Windows.Forms.TextBox();
            this.txtbCourseName = new System.Windows.Forms.TextBox();
            this.lblCourseName = new System.Windows.Forms.Label();
            this.lblCourseID = new System.Windows.Forms.Label();
            this.gpCourseExtraOption.SuspendLayout();
            this.gpCourseUpdateDelete.SuspendLayout();
            this.gpCourseNewRegistry.SuspendLayout();
            this.gpCourseNavigate.SuspendLayout();
            this.gbCourseData.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpCourseExtraOption
            // 
            this.gpCourseExtraOption.Controls.Add(this.btnListCourses);
            this.gpCourseExtraOption.Controls.Add(this.btnSearchCourse);
            this.gpCourseExtraOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpCourseExtraOption.Location = new System.Drawing.Point(12, 309);
            this.gpCourseExtraOption.Name = "gpCourseExtraOption";
            this.gpCourseExtraOption.Size = new System.Drawing.Size(699, 99);
            this.gpCourseExtraOption.TabIndex = 22;
            this.gpCourseExtraOption.TabStop = false;
            this.gpCourseExtraOption.Text = "LIST AND SEARCH";
            // 
            // btnListCourses
            // 
            this.btnListCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListCourses.Location = new System.Drawing.Point(373, 34);
            this.btnListCourses.Name = "btnListCourses";
            this.btnListCourses.Size = new System.Drawing.Size(302, 41);
            this.btnListCourses.TabIndex = 0;
            this.btnListCourses.Text = "LIST OF COURSES";
            this.btnListCourses.UseVisualStyleBackColor = true;
            this.btnListCourses.Click += new System.EventHandler(this.btnListCourses_Click);
            // 
            // btnSearchCourse
            // 
            this.btnSearchCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCourse.Location = new System.Drawing.Point(21, 34);
            this.btnSearchCourse.Name = "btnSearchCourse";
            this.btnSearchCourse.Size = new System.Drawing.Size(301, 41);
            this.btnSearchCourse.TabIndex = 1;
            this.btnSearchCourse.Text = "SEARCH BY ID";
            this.btnSearchCourse.UseVisualStyleBackColor = true;
            this.btnSearchCourse.Click += new System.EventHandler(this.btnSearchCourse_Click);
            // 
            // gpCourseUpdateDelete
            // 
            this.gpCourseUpdateDelete.Controls.Add(this.btnCourseDelete);
            this.gpCourseUpdateDelete.Controls.Add(this.btnCourseUpdate);
            this.gpCourseUpdateDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpCourseUpdateDelete.Location = new System.Drawing.Point(469, 12);
            this.gpCourseUpdateDelete.Name = "gpCourseUpdateDelete";
            this.gpCourseUpdateDelete.Size = new System.Drawing.Size(242, 159);
            this.gpCourseUpdateDelete.TabIndex = 23;
            this.gpCourseUpdateDelete.TabStop = false;
            this.gpCourseUpdateDelete.Text = "UPDATE AND DELETE";
            // 
            // btnCourseDelete
            // 
            this.btnCourseDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourseDelete.Location = new System.Drawing.Point(21, 101);
            this.btnCourseDelete.Name = "btnCourseDelete";
            this.btnCourseDelete.Size = new System.Drawing.Size(197, 41);
            this.btnCourseDelete.TabIndex = 1;
            this.btnCourseDelete.Text = "DELETE";
            this.btnCourseDelete.UseVisualStyleBackColor = true;
            this.btnCourseDelete.Click += new System.EventHandler(this.btnCourseDelete_Click);
            // 
            // btnCourseUpdate
            // 
            this.btnCourseUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourseUpdate.Location = new System.Drawing.Point(21, 37);
            this.btnCourseUpdate.Name = "btnCourseUpdate";
            this.btnCourseUpdate.Size = new System.Drawing.Size(197, 41);
            this.btnCourseUpdate.TabIndex = 0;
            this.btnCourseUpdate.Text = "UPDATE";
            this.btnCourseUpdate.UseVisualStyleBackColor = true;
            this.btnCourseUpdate.Click += new System.EventHandler(this.btnCourseUpdate_Click);
            // 
            // gpCourseNewRegistry
            // 
            this.gpCourseNewRegistry.Controls.Add(this.btnCourseCancelAddRegistry);
            this.gpCourseNewRegistry.Controls.Add(this.btnCourseClear);
            this.gpCourseNewRegistry.Controls.Add(this.btnCourseSave);
            this.gpCourseNewRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpCourseNewRegistry.Location = new System.Drawing.Point(12, 424);
            this.gpCourseNewRegistry.Name = "gpCourseNewRegistry";
            this.gpCourseNewRegistry.Size = new System.Drawing.Size(699, 92);
            this.gpCourseNewRegistry.TabIndex = 21;
            this.gpCourseNewRegistry.TabStop = false;
            this.gpCourseNewRegistry.Text = "NEW REGISTRY";
            // 
            // btnCourseCancelAddRegistry
            // 
            this.btnCourseCancelAddRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourseCancelAddRegistry.Location = new System.Drawing.Point(248, 32);
            this.btnCourseCancelAddRegistry.Name = "btnCourseCancelAddRegistry";
            this.btnCourseCancelAddRegistry.Size = new System.Drawing.Size(200, 41);
            this.btnCourseCancelAddRegistry.TabIndex = 2;
            this.btnCourseCancelAddRegistry.Text = "CANCEL REGISTRY ADDITION";
            this.btnCourseCancelAddRegistry.UseVisualStyleBackColor = true;
            this.btnCourseCancelAddRegistry.Click += new System.EventHandler(this.btnCourseCancelAddRegistry_Click);
            // 
            // btnCourseClear
            // 
            this.btnCourseClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourseClear.Location = new System.Drawing.Point(18, 32);
            this.btnCourseClear.Name = "btnCourseClear";
            this.btnCourseClear.Size = new System.Drawing.Size(187, 41);
            this.btnCourseClear.TabIndex = 0;
            this.btnCourseClear.Text = "CLEAR DATA";
            this.btnCourseClear.UseVisualStyleBackColor = true;
            this.btnCourseClear.Click += new System.EventHandler(this.btnCourseClear_Click);
            // 
            // btnCourseSave
            // 
            this.btnCourseSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourseSave.Location = new System.Drawing.Point(489, 32);
            this.btnCourseSave.Name = "btnCourseSave";
            this.btnCourseSave.Size = new System.Drawing.Size(186, 41);
            this.btnCourseSave.TabIndex = 1;
            this.btnCourseSave.Text = "SAVE AS NEW";
            this.btnCourseSave.UseVisualStyleBackColor = true;
            this.btnCourseSave.Click += new System.EventHandler(this.btnCourseSave_Click);
            // 
            // gpCourseNavigate
            // 
            this.gpCourseNavigate.Controls.Add(this.btnCoursePrevious);
            this.gpCourseNavigate.Controls.Add(this.btnCourseNext);
            this.gpCourseNavigate.Controls.Add(this.btnCourseLast);
            this.gpCourseNavigate.Controls.Add(this.btnCourseFirst);
            this.gpCourseNavigate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpCourseNavigate.Location = new System.Drawing.Point(12, 190);
            this.gpCourseNavigate.Name = "gpCourseNavigate";
            this.gpCourseNavigate.Size = new System.Drawing.Size(699, 104);
            this.gpCourseNavigate.TabIndex = 20;
            this.gpCourseNavigate.TabStop = false;
            this.gpCourseNavigate.Text = "NAVIGATE TO";
            // 
            // btnCoursePrevious
            // 
            this.btnCoursePrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCoursePrevious.Location = new System.Drawing.Point(524, 43);
            this.btnCoursePrevious.Name = "btnCoursePrevious";
            this.btnCoursePrevious.Size = new System.Drawing.Size(151, 41);
            this.btnCoursePrevious.TabIndex = 3;
            this.btnCoursePrevious.Text = "PREVIOUS";
            this.btnCoursePrevious.UseVisualStyleBackColor = true;
            this.btnCoursePrevious.Click += new System.EventHandler(this.btnCoursePrevious_Click);
            // 
            // btnCourseNext
            // 
            this.btnCourseNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourseNext.Location = new System.Drawing.Point(354, 43);
            this.btnCourseNext.Name = "btnCourseNext";
            this.btnCourseNext.Size = new System.Drawing.Size(151, 41);
            this.btnCourseNext.TabIndex = 2;
            this.btnCourseNext.Text = "NEXT";
            this.btnCourseNext.UseVisualStyleBackColor = true;
            this.btnCourseNext.Click += new System.EventHandler(this.btnCourseNext_Click);
            // 
            // btnCourseLast
            // 
            this.btnCourseLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourseLast.Location = new System.Drawing.Point(188, 43);
            this.btnCourseLast.Name = "btnCourseLast";
            this.btnCourseLast.Size = new System.Drawing.Size(151, 41);
            this.btnCourseLast.TabIndex = 1;
            this.btnCourseLast.Text = "LAST";
            this.btnCourseLast.UseVisualStyleBackColor = true;
            this.btnCourseLast.Click += new System.EventHandler(this.btnCourseLast_Click);
            // 
            // btnCourseFirst
            // 
            this.btnCourseFirst.Enabled = false;
            this.btnCourseFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourseFirst.Location = new System.Drawing.Point(21, 43);
            this.btnCourseFirst.Name = "btnCourseFirst";
            this.btnCourseFirst.Size = new System.Drawing.Size(151, 41);
            this.btnCourseFirst.TabIndex = 0;
            this.btnCourseFirst.Text = "FIRST";
            this.btnCourseFirst.UseVisualStyleBackColor = true;
            this.btnCourseFirst.Click += new System.EventHandler(this.btnCourseFirst_Click);
            // 
            // gbCourseData
            // 
            this.gbCourseData.Controls.Add(this.lblRecord);
            this.gbCourseData.Controls.Add(this.txtbCourseID);
            this.gbCourseData.Controls.Add(this.txtbCourseName);
            this.gbCourseData.Controls.Add(this.lblCourseName);
            this.gbCourseData.Controls.Add(this.lblCourseID);
            this.gbCourseData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCourseData.Location = new System.Drawing.Point(12, 12);
            this.gbCourseData.Name = "gbCourseData";
            this.gbCourseData.Size = new System.Drawing.Size(442, 159);
            this.gbCourseData.TabIndex = 19;
            this.gbCourseData.TabStop = false;
            this.gbCourseData.Text = "COURSE DATA";
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(169, 0);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(0, 20);
            this.lblRecord.TabIndex = 10;
            // 
            // txtbCourseID
            // 
            this.txtbCourseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCourseID.Location = new System.Drawing.Point(86, 48);
            this.txtbCourseID.Name = "txtbCourseID";
            this.txtbCourseID.Size = new System.Drawing.Size(337, 22);
            this.txtbCourseID.TabIndex = 9;
            this.txtbCourseID.TextChanged += new System.EventHandler(this.txtbCourseID_TextChanged);
            // 
            // txtbCourseName
            // 
            this.txtbCourseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCourseName.Location = new System.Drawing.Point(86, 88);
            this.txtbCourseName.Name = "txtbCourseName";
            this.txtbCourseName.Size = new System.Drawing.Size(337, 22);
            this.txtbCourseName.TabIndex = 8;
            this.txtbCourseName.TextChanged += new System.EventHandler(this.txtbCourseName_TextChanged);
            // 
            // lblCourseName
            // 
            this.lblCourseName.AutoSize = true;
            this.lblCourseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseName.Location = new System.Drawing.Point(23, 91);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(49, 16);
            this.lblCourseName.TabIndex = 1;
            this.lblCourseName.Text = "NAME:";
            this.lblCourseName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCourseID
            // 
            this.lblCourseID.AutoSize = true;
            this.lblCourseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseID.Location = new System.Drawing.Point(23, 51);
            this.lblCourseID.Name = "lblCourseID";
            this.lblCourseID.Size = new System.Drawing.Size(23, 16);
            this.lblCourseID.TabIndex = 0;
            this.lblCourseID.Text = "ID:";
            this.lblCourseID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fCourseManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 532);
            this.Controls.Add(this.gpCourseExtraOption);
            this.Controls.Add(this.gpCourseUpdateDelete);
            this.Controls.Add(this.gpCourseNewRegistry);
            this.Controls.Add(this.gpCourseNavigate);
            this.Controls.Add(this.gbCourseData);
            this.Name = "fCourseManagement";
            this.Text = "Courses";
            this.Load += new System.EventHandler(this.fCourseManagement_Load);
            this.gpCourseExtraOption.ResumeLayout(false);
            this.gpCourseUpdateDelete.ResumeLayout(false);
            this.gpCourseNewRegistry.ResumeLayout(false);
            this.gpCourseNavigate.ResumeLayout(false);
            this.gbCourseData.ResumeLayout(false);
            this.gbCourseData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpCourseExtraOption;
        private System.Windows.Forms.Button btnListCourses;
        private System.Windows.Forms.Button btnSearchCourse;
        private System.Windows.Forms.GroupBox gpCourseUpdateDelete;
        private System.Windows.Forms.Button btnCourseDelete;
        private System.Windows.Forms.Button btnCourseUpdate;
        private System.Windows.Forms.GroupBox gpCourseNewRegistry;
        private System.Windows.Forms.Button btnCourseCancelAddRegistry;
        private System.Windows.Forms.Button btnCourseClear;
        private System.Windows.Forms.Button btnCourseSave;
        private System.Windows.Forms.GroupBox gpCourseNavigate;
        private System.Windows.Forms.Button btnCoursePrevious;
        private System.Windows.Forms.Button btnCourseNext;
        private System.Windows.Forms.Button btnCourseLast;
        private System.Windows.Forms.Button btnCourseFirst;
        private System.Windows.Forms.GroupBox gbCourseData;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.TextBox txtbCourseID;
        private System.Windows.Forms.TextBox txtbCourseName;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.Label lblCourseID;
    }
}