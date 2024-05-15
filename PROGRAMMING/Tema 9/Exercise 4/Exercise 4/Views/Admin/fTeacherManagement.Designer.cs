namespace Exercise_4
{
    partial class fTeacherManagement
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTeacherID = new System.Windows.Forms.Label();
            this.lblTeacherName = new System.Windows.Forms.Label();
            this.lblTeacherSurnames = new System.Windows.Forms.Label();
            this.lblTeacherPhone = new System.Windows.Forms.Label();
            this.lblTeacherEmail = new System.Windows.Forms.Label();
            this.txtbTeacherSurnames = new System.Windows.Forms.TextBox();
            this.txtbTeacherPhone = new System.Windows.Forms.TextBox();
            this.txtbTeacherEmail = new System.Windows.Forms.TextBox();
            this.txtbTeacherName = new System.Windows.Forms.TextBox();
            this.txtbTeacherID = new System.Windows.Forms.TextBox();
            this.gbTeacherData = new System.Windows.Forms.GroupBox();
            this.txtbTeacherCourse = new System.Windows.Forms.TextBox();
            this.lblTeacherCourse = new System.Windows.Forms.Label();
            this.txtbTeacherPassword = new System.Windows.Forms.TextBox();
            this.lblTeacherPassword = new System.Windows.Forms.Label();
            this.lblRecord = new System.Windows.Forms.Label();
            this.gpTeacherNavigate = new System.Windows.Forms.GroupBox();
            this.btnTeacherPrevious = new System.Windows.Forms.Button();
            this.btnTeacherNext = new System.Windows.Forms.Button();
            this.btnTeacherLast = new System.Windows.Forms.Button();
            this.btnTeacherFirst = new System.Windows.Forms.Button();
            this.gpTeacherNewRegistry = new System.Windows.Forms.GroupBox();
            this.btnTeacherCancelAddRegistry = new System.Windows.Forms.Button();
            this.btnTeacherClear = new System.Windows.Forms.Button();
            this.btnTeacherSave = new System.Windows.Forms.Button();
            this.gpTeacherUpdateDelete = new System.Windows.Forms.GroupBox();
            this.btnTeacherDelete = new System.Windows.Forms.Button();
            this.btnTeacherUpdate = new System.Windows.Forms.Button();
            this.btnListTeachers = new System.Windows.Forms.Button();
            this.btnSearchTeacher = new System.Windows.Forms.Button();
            this.gpTeacherExtraOption = new System.Windows.Forms.GroupBox();
            this.btnSearchTeacherCourse = new System.Windows.Forms.Button();
            this.gbTeacherData.SuspendLayout();
            this.gpTeacherNavigate.SuspendLayout();
            this.gpTeacherNewRegistry.SuspendLayout();
            this.gpTeacherUpdateDelete.SuspendLayout();
            this.gpTeacherExtraOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTeacherID
            // 
            this.lblTeacherID.AutoSize = true;
            this.lblTeacherID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeacherID.Location = new System.Drawing.Point(26, 44);
            this.lblTeacherID.Name = "lblTeacherID";
            this.lblTeacherID.Size = new System.Drawing.Size(23, 16);
            this.lblTeacherID.TabIndex = 0;
            this.lblTeacherID.Text = "ID:";
            this.lblTeacherID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTeacherName
            // 
            this.lblTeacherName.AutoSize = true;
            this.lblTeacherName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeacherName.Location = new System.Drawing.Point(26, 94);
            this.lblTeacherName.Name = "lblTeacherName";
            this.lblTeacherName.Size = new System.Drawing.Size(49, 16);
            this.lblTeacherName.TabIndex = 1;
            this.lblTeacherName.Text = "NAME:";
            this.lblTeacherName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTeacherSurnames
            // 
            this.lblTeacherSurnames.AutoSize = true;
            this.lblTeacherSurnames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeacherSurnames.Location = new System.Drawing.Point(26, 144);
            this.lblTeacherSurnames.Name = "lblTeacherSurnames";
            this.lblTeacherSurnames.Size = new System.Drawing.Size(87, 16);
            this.lblTeacherSurnames.TabIndex = 2;
            this.lblTeacherSurnames.Text = "SURNAMES:";
            this.lblTeacherSurnames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTeacherPhone
            // 
            this.lblTeacherPhone.AutoSize = true;
            this.lblTeacherPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeacherPhone.Location = new System.Drawing.Point(26, 194);
            this.lblTeacherPhone.Name = "lblTeacherPhone";
            this.lblTeacherPhone.Size = new System.Drawing.Size(58, 16);
            this.lblTeacherPhone.TabIndex = 3;
            this.lblTeacherPhone.Text = "PHONE:";
            this.lblTeacherPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTeacherEmail
            // 
            this.lblTeacherEmail.AutoSize = true;
            this.lblTeacherEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeacherEmail.Location = new System.Drawing.Point(26, 244);
            this.lblTeacherEmail.Name = "lblTeacherEmail";
            this.lblTeacherEmail.Size = new System.Drawing.Size(49, 16);
            this.lblTeacherEmail.TabIndex = 4;
            this.lblTeacherEmail.Text = "EMAIL:";
            this.lblTeacherEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtbTeacherSurnames
            // 
            this.txtbTeacherSurnames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbTeacherSurnames.Location = new System.Drawing.Point(130, 142);
            this.txtbTeacherSurnames.Name = "txtbTeacherSurnames";
            this.txtbTeacherSurnames.Size = new System.Drawing.Size(246, 22);
            this.txtbTeacherSurnames.TabIndex = 5;
            this.txtbTeacherSurnames.TextChanged += new System.EventHandler(this.txtbSurnames_TextChanged);
            // 
            // txtbTeacherPhone
            // 
            this.txtbTeacherPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbTeacherPhone.Location = new System.Drawing.Point(130, 192);
            this.txtbTeacherPhone.Name = "txtbTeacherPhone";
            this.txtbTeacherPhone.Size = new System.Drawing.Size(246, 22);
            this.txtbTeacherPhone.TabIndex = 6;
            this.txtbTeacherPhone.TextChanged += new System.EventHandler(this.txtbPhone_TextChanged);
            // 
            // txtbTeacherEmail
            // 
            this.txtbTeacherEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbTeacherEmail.Location = new System.Drawing.Point(130, 242);
            this.txtbTeacherEmail.Name = "txtbTeacherEmail";
            this.txtbTeacherEmail.Size = new System.Drawing.Size(246, 22);
            this.txtbTeacherEmail.TabIndex = 7;
            this.txtbTeacherEmail.TextChanged += new System.EventHandler(this.txtbEmail_TextChanged);
            // 
            // txtbTeacherName
            // 
            this.txtbTeacherName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbTeacherName.Location = new System.Drawing.Point(130, 92);
            this.txtbTeacherName.Name = "txtbTeacherName";
            this.txtbTeacherName.Size = new System.Drawing.Size(246, 22);
            this.txtbTeacherName.TabIndex = 8;
            this.txtbTeacherName.TextChanged += new System.EventHandler(this.txtbName_TextChanged);
            // 
            // txtbTeacherID
            // 
            this.txtbTeacherID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbTeacherID.Location = new System.Drawing.Point(130, 42);
            this.txtbTeacherID.Name = "txtbTeacherID";
            this.txtbTeacherID.Size = new System.Drawing.Size(246, 22);
            this.txtbTeacherID.TabIndex = 9;
            this.txtbTeacherID.TextChanged += new System.EventHandler(this.txtbID_TextChanged);
            // 
            // gbTeacherData
            // 
            this.gbTeacherData.Controls.Add(this.txtbTeacherCourse);
            this.gbTeacherData.Controls.Add(this.lblTeacherCourse);
            this.gbTeacherData.Controls.Add(this.txtbTeacherPassword);
            this.gbTeacherData.Controls.Add(this.lblTeacherPassword);
            this.gbTeacherData.Controls.Add(this.lblRecord);
            this.gbTeacherData.Controls.Add(this.txtbTeacherID);
            this.gbTeacherData.Controls.Add(this.txtbTeacherName);
            this.gbTeacherData.Controls.Add(this.txtbTeacherEmail);
            this.gbTeacherData.Controls.Add(this.txtbTeacherPhone);
            this.gbTeacherData.Controls.Add(this.txtbTeacherSurnames);
            this.gbTeacherData.Controls.Add(this.lblTeacherEmail);
            this.gbTeacherData.Controls.Add(this.lblTeacherPhone);
            this.gbTeacherData.Controls.Add(this.lblTeacherSurnames);
            this.gbTeacherData.Controls.Add(this.lblTeacherName);
            this.gbTeacherData.Controls.Add(this.lblTeacherID);
            this.gbTeacherData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTeacherData.Location = new System.Drawing.Point(12, 12);
            this.gbTeacherData.Name = "gbTeacherData";
            this.gbTeacherData.Size = new System.Drawing.Size(397, 390);
            this.gbTeacherData.TabIndex = 10;
            this.gbTeacherData.TabStop = false;
            this.gbTeacherData.Text = "TEACHER DATA";
            // 
            // txtbTeacherCourse
            // 
            this.txtbTeacherCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbTeacherCourse.Location = new System.Drawing.Point(130, 342);
            this.txtbTeacherCourse.Name = "txtbTeacherCourse";
            this.txtbTeacherCourse.Size = new System.Drawing.Size(246, 22);
            this.txtbTeacherCourse.TabIndex = 14;
            this.txtbTeacherCourse.TextChanged += new System.EventHandler(this.txtbTeacherCourse_TextChanged);
            // 
            // lblTeacherCourse
            // 
            this.lblTeacherCourse.AutoSize = true;
            this.lblTeacherCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeacherCourse.Location = new System.Drawing.Point(26, 344);
            this.lblTeacherCourse.Name = "lblTeacherCourse";
            this.lblTeacherCourse.Size = new System.Drawing.Size(67, 16);
            this.lblTeacherCourse.TabIndex = 13;
            this.lblTeacherCourse.Text = "COURSE:";
            this.lblTeacherCourse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtbTeacherPassword
            // 
            this.txtbTeacherPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbTeacherPassword.Location = new System.Drawing.Point(130, 292);
            this.txtbTeacherPassword.Name = "txtbTeacherPassword";
            this.txtbTeacherPassword.Size = new System.Drawing.Size(246, 22);
            this.txtbTeacherPassword.TabIndex = 12;
            this.txtbTeacherPassword.TextChanged += new System.EventHandler(this.txtbTeacherPassword_TextChanged);
            // 
            // lblTeacherPassword
            // 
            this.lblTeacherPassword.AutoSize = true;
            this.lblTeacherPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeacherPassword.Location = new System.Drawing.Point(26, 294);
            this.lblTeacherPassword.Name = "lblTeacherPassword";
            this.lblTeacherPassword.Size = new System.Drawing.Size(89, 16);
            this.lblTeacherPassword.TabIndex = 11;
            this.lblTeacherPassword.Text = "PASSWORD:";
            this.lblTeacherPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // gpTeacherNavigate
            // 
            this.gpTeacherNavigate.Controls.Add(this.btnTeacherPrevious);
            this.gpTeacherNavigate.Controls.Add(this.btnTeacherNext);
            this.gpTeacherNavigate.Controls.Add(this.btnTeacherLast);
            this.gpTeacherNavigate.Controls.Add(this.btnTeacherFirst);
            this.gpTeacherNavigate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpTeacherNavigate.Location = new System.Drawing.Point(12, 416);
            this.gpTeacherNavigate.Name = "gpTeacherNavigate";
            this.gpTeacherNavigate.Size = new System.Drawing.Size(645, 104);
            this.gpTeacherNavigate.TabIndex = 11;
            this.gpTeacherNavigate.TabStop = false;
            this.gpTeacherNavigate.Text = "NAVIGATE TO";
            // 
            // btnTeacherPrevious
            // 
            this.btnTeacherPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeacherPrevious.Location = new System.Drawing.Point(491, 37);
            this.btnTeacherPrevious.Name = "btnTeacherPrevious";
            this.btnTeacherPrevious.Size = new System.Drawing.Size(134, 41);
            this.btnTeacherPrevious.TabIndex = 3;
            this.btnTeacherPrevious.Text = "PREVIOUS";
            this.btnTeacherPrevious.UseVisualStyleBackColor = true;
            this.btnTeacherPrevious.Click += new System.EventHandler(this.btnTeacherPrevious_Click);
            // 
            // btnTeacherNext
            // 
            this.btnTeacherNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeacherNext.Location = new System.Drawing.Point(331, 37);
            this.btnTeacherNext.Name = "btnTeacherNext";
            this.btnTeacherNext.Size = new System.Drawing.Size(134, 41);
            this.btnTeacherNext.TabIndex = 2;
            this.btnTeacherNext.Text = "NEXT";
            this.btnTeacherNext.UseVisualStyleBackColor = true;
            this.btnTeacherNext.Click += new System.EventHandler(this.btnTeacherNext_Click);
            // 
            // btnTeacherLast
            // 
            this.btnTeacherLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeacherLast.Location = new System.Drawing.Point(173, 37);
            this.btnTeacherLast.Name = "btnTeacherLast";
            this.btnTeacherLast.Size = new System.Drawing.Size(134, 41);
            this.btnTeacherLast.TabIndex = 1;
            this.btnTeacherLast.Text = "LAST";
            this.btnTeacherLast.UseVisualStyleBackColor = true;
            this.btnTeacherLast.Click += new System.EventHandler(this.btnTeacherLast_Click);
            // 
            // btnTeacherFirst
            // 
            this.btnTeacherFirst.Enabled = false;
            this.btnTeacherFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeacherFirst.Location = new System.Drawing.Point(18, 37);
            this.btnTeacherFirst.Name = "btnTeacherFirst";
            this.btnTeacherFirst.Size = new System.Drawing.Size(134, 41);
            this.btnTeacherFirst.TabIndex = 0;
            this.btnTeacherFirst.Text = "FIRST";
            this.btnTeacherFirst.UseVisualStyleBackColor = true;
            this.btnTeacherFirst.Click += new System.EventHandler(this.btnTeacherFirst_Click);
            // 
            // gpTeacherNewRegistry
            // 
            this.gpTeacherNewRegistry.Controls.Add(this.btnTeacherCancelAddRegistry);
            this.gpTeacherNewRegistry.Controls.Add(this.btnTeacherClear);
            this.gpTeacherNewRegistry.Controls.Add(this.btnTeacherSave);
            this.gpTeacherNewRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpTeacherNewRegistry.Location = new System.Drawing.Point(12, 537);
            this.gpTeacherNewRegistry.Name = "gpTeacherNewRegistry";
            this.gpTeacherNewRegistry.Size = new System.Drawing.Size(645, 92);
            this.gpTeacherNewRegistry.TabIndex = 12;
            this.gpTeacherNewRegistry.TabStop = false;
            this.gpTeacherNewRegistry.Text = "NEW REGISTRY";
            // 
            // btnTeacherCancelAddRegistry
            // 
            this.btnTeacherCancelAddRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeacherCancelAddRegistry.Location = new System.Drawing.Point(222, 32);
            this.btnTeacherCancelAddRegistry.Name = "btnTeacherCancelAddRegistry";
            this.btnTeacherCancelAddRegistry.Size = new System.Drawing.Size(194, 41);
            this.btnTeacherCancelAddRegistry.TabIndex = 2;
            this.btnTeacherCancelAddRegistry.Text = "CANCEL REGISTRY ADDITION";
            this.btnTeacherCancelAddRegistry.UseVisualStyleBackColor = true;
            this.btnTeacherCancelAddRegistry.Click += new System.EventHandler(this.btnTeacherCancelAddRegistry_Click);
            // 
            // btnTeacherClear
            // 
            this.btnTeacherClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeacherClear.Location = new System.Drawing.Point(18, 32);
            this.btnTeacherClear.Name = "btnTeacherClear";
            this.btnTeacherClear.Size = new System.Drawing.Size(187, 41);
            this.btnTeacherClear.TabIndex = 0;
            this.btnTeacherClear.Text = "CLEAR DATA";
            this.btnTeacherClear.UseVisualStyleBackColor = true;
            this.btnTeacherClear.Click += new System.EventHandler(this.btnTeacherClear_Click);
            // 
            // btnTeacherSave
            // 
            this.btnTeacherSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeacherSave.Location = new System.Drawing.Point(440, 32);
            this.btnTeacherSave.Name = "btnTeacherSave";
            this.btnTeacherSave.Size = new System.Drawing.Size(186, 41);
            this.btnTeacherSave.TabIndex = 1;
            this.btnTeacherSave.Text = "SAVE AS NEW";
            this.btnTeacherSave.UseVisualStyleBackColor = true;
            this.btnTeacherSave.Click += new System.EventHandler(this.btnTeacherSave_Click);
            // 
            // gpTeacherUpdateDelete
            // 
            this.gpTeacherUpdateDelete.Controls.Add(this.btnTeacherDelete);
            this.gpTeacherUpdateDelete.Controls.Add(this.btnTeacherUpdate);
            this.gpTeacherUpdateDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpTeacherUpdateDelete.Location = new System.Drawing.Point(432, 247);
            this.gpTeacherUpdateDelete.Name = "gpTeacherUpdateDelete";
            this.gpTeacherUpdateDelete.Size = new System.Drawing.Size(225, 155);
            this.gpTeacherUpdateDelete.TabIndex = 13;
            this.gpTeacherUpdateDelete.TabStop = false;
            this.gpTeacherUpdateDelete.Text = "UPDATE AND DELETE";
            // 
            // btnTeacherDelete
            // 
            this.btnTeacherDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeacherDelete.Location = new System.Drawing.Point(20, 90);
            this.btnTeacherDelete.Name = "btnTeacherDelete";
            this.btnTeacherDelete.Size = new System.Drawing.Size(185, 41);
            this.btnTeacherDelete.TabIndex = 1;
            this.btnTeacherDelete.Text = "DELETE";
            this.btnTeacherDelete.UseVisualStyleBackColor = true;
            this.btnTeacherDelete.Click += new System.EventHandler(this.btnTeacherDelete_Click);
            // 
            // btnTeacherUpdate
            // 
            this.btnTeacherUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeacherUpdate.Location = new System.Drawing.Point(21, 32);
            this.btnTeacherUpdate.Name = "btnTeacherUpdate";
            this.btnTeacherUpdate.Size = new System.Drawing.Size(185, 41);
            this.btnTeacherUpdate.TabIndex = 0;
            this.btnTeacherUpdate.Text = "UPDATE";
            this.btnTeacherUpdate.UseVisualStyleBackColor = true;
            this.btnTeacherUpdate.Click += new System.EventHandler(this.btnTeacherUpdate_Click);
            // 
            // btnListTeachers
            // 
            this.btnListTeachers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListTeachers.Location = new System.Drawing.Point(17, 156);
            this.btnListTeachers.Name = "btnListTeachers";
            this.btnListTeachers.Size = new System.Drawing.Size(189, 41);
            this.btnListTeachers.TabIndex = 0;
            this.btnListTeachers.Text = "TEACHERS LIST";
            this.btnListTeachers.UseVisualStyleBackColor = true;
            this.btnListTeachers.Click += new System.EventHandler(this.btnListTeachers_Click);
            // 
            // btnSearchTeacher
            // 
            this.btnSearchTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchTeacher.Location = new System.Drawing.Point(17, 34);
            this.btnSearchTeacher.Name = "btnSearchTeacher";
            this.btnSearchTeacher.Size = new System.Drawing.Size(189, 41);
            this.btnSearchTeacher.TabIndex = 1;
            this.btnSearchTeacher.Text = "SEARCH BY SURNAME";
            this.btnSearchTeacher.UseVisualStyleBackColor = true;
            this.btnSearchTeacher.Click += new System.EventHandler(this.btnSearchTeacher_Click);
            // 
            // gpTeacherExtraOption
            // 
            this.gpTeacherExtraOption.Controls.Add(this.btnSearchTeacherCourse);
            this.gpTeacherExtraOption.Controls.Add(this.btnListTeachers);
            this.gpTeacherExtraOption.Controls.Add(this.btnSearchTeacher);
            this.gpTeacherExtraOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpTeacherExtraOption.Location = new System.Drawing.Point(432, 12);
            this.gpTeacherExtraOption.Name = "gpTeacherExtraOption";
            this.gpTeacherExtraOption.Size = new System.Drawing.Size(225, 217);
            this.gpTeacherExtraOption.TabIndex = 13;
            this.gpTeacherExtraOption.TabStop = false;
            this.gpTeacherExtraOption.Text = "LIST AND SEARCH";
            // 
            // btnSearchTeacherCourse
            // 
            this.btnSearchTeacherCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchTeacherCourse.Location = new System.Drawing.Point(17, 95);
            this.btnSearchTeacherCourse.Name = "btnSearchTeacherCourse";
            this.btnSearchTeacherCourse.Size = new System.Drawing.Size(189, 41);
            this.btnSearchTeacherCourse.TabIndex = 2;
            this.btnSearchTeacherCourse.Text = "SEARCH BY COURSE";
            this.btnSearchTeacherCourse.UseVisualStyleBackColor = true;
            this.btnSearchTeacherCourse.Click += new System.EventHandler(this.btnSearchTeacherCourse_Click);
            // 
            // fTeacherManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 646);
            this.Controls.Add(this.gpTeacherExtraOption);
            this.Controls.Add(this.gpTeacherUpdateDelete);
            this.Controls.Add(this.gpTeacherNewRegistry);
            this.Controls.Add(this.gpTeacherNavigate);
            this.Controls.Add(this.gbTeacherData);
            this.Name = "fTeacherManagement";
            this.Text = "Teachers Management";
            this.Load += new System.EventHandler(this.fTeacherManagement_Load);
            this.gbTeacherData.ResumeLayout(false);
            this.gbTeacherData.PerformLayout();
            this.gpTeacherNavigate.ResumeLayout(false);
            this.gpTeacherNewRegistry.ResumeLayout(false);
            this.gpTeacherUpdateDelete.ResumeLayout(false);
            this.gpTeacherExtraOption.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTeacherID;
        private System.Windows.Forms.Label lblTeacherName;
        private System.Windows.Forms.Label lblTeacherSurnames;
        private System.Windows.Forms.Label lblTeacherPhone;
        private System.Windows.Forms.Label lblTeacherEmail;
        private System.Windows.Forms.TextBox txtbTeacherSurnames;
        private System.Windows.Forms.TextBox txtbTeacherPhone;
        private System.Windows.Forms.TextBox txtbTeacherEmail;
        private System.Windows.Forms.TextBox txtbTeacherName;
        private System.Windows.Forms.TextBox txtbTeacherID;
        private System.Windows.Forms.GroupBox gbTeacherData;
        private System.Windows.Forms.GroupBox gpTeacherNavigate;
        private System.Windows.Forms.Button btnTeacherPrevious;
        private System.Windows.Forms.Button btnTeacherNext;
        private System.Windows.Forms.Button btnTeacherLast;
        private System.Windows.Forms.Button btnTeacherFirst;
        private System.Windows.Forms.GroupBox gpTeacherNewRegistry;
        private System.Windows.Forms.Button btnTeacherClear;
        private System.Windows.Forms.Button btnTeacherSave;
        private System.Windows.Forms.GroupBox gpTeacherUpdateDelete;
        private System.Windows.Forms.Button btnTeacherDelete;
        private System.Windows.Forms.Button btnTeacherUpdate;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Button btnListTeachers;
        private System.Windows.Forms.Button btnSearchTeacher;
        private System.Windows.Forms.GroupBox gpTeacherExtraOption;
        private System.Windows.Forms.Button btnTeacherCancelAddRegistry;
        private System.Windows.Forms.TextBox txtbTeacherPassword;
        private System.Windows.Forms.Label lblTeacherPassword;
        private System.Windows.Forms.TextBox txtbTeacherCourse;
        private System.Windows.Forms.Label lblTeacherCourse;
        private System.Windows.Forms.Button btnSearchTeacherCourse;
    }
}

