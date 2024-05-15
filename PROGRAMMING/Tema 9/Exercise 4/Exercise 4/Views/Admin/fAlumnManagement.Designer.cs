namespace Exercise_4
{
    partial class fAlumnManagement
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
            this.gpAlumnExtraOption = new System.Windows.Forms.GroupBox();
            this.btnAlumnSearchCourse = new System.Windows.Forms.Button();
            this.btnListAlumns = new System.Windows.Forms.Button();
            this.btnSearchAlumn = new System.Windows.Forms.Button();
            this.gpAlumnUpdateDelete = new System.Windows.Forms.GroupBox();
            this.btnAlumnDelete = new System.Windows.Forms.Button();
            this.btnAlumnUpdate = new System.Windows.Forms.Button();
            this.gpAlumnNewRegistry = new System.Windows.Forms.GroupBox();
            this.btnAlumnCancelAddRegistry = new System.Windows.Forms.Button();
            this.btnAlumnClear = new System.Windows.Forms.Button();
            this.btnAlumnSave = new System.Windows.Forms.Button();
            this.gpAlumnNavigate = new System.Windows.Forms.GroupBox();
            this.btnAlumnPrevious = new System.Windows.Forms.Button();
            this.btnAlumnNext = new System.Windows.Forms.Button();
            this.btnAlumnLast = new System.Windows.Forms.Button();
            this.btnAlumnFirst = new System.Windows.Forms.Button();
            this.gbAlumnData = new System.Windows.Forms.GroupBox();
            this.txtbAlumnCourse = new System.Windows.Forms.TextBox();
            this.lblAlumnCourse = new System.Windows.Forms.Label();
            this.txtbAlumnPassword = new System.Windows.Forms.TextBox();
            this.lblAlumnPassword = new System.Windows.Forms.Label();
            this.lblRecord = new System.Windows.Forms.Label();
            this.txtbAlumnID = new System.Windows.Forms.TextBox();
            this.txtbAlumnName = new System.Windows.Forms.TextBox();
            this.txtbAlumnAdress = new System.Windows.Forms.TextBox();
            this.txtbAlumnPhone = new System.Windows.Forms.TextBox();
            this.txtbAlumnSurnames = new System.Windows.Forms.TextBox();
            this.lblAlumnAdress = new System.Windows.Forms.Label();
            this.lbAlumnlPhone = new System.Windows.Forms.Label();
            this.lblAlumnSurnames = new System.Windows.Forms.Label();
            this.lblAlumnName = new System.Windows.Forms.Label();
            this.lblAlumnID = new System.Windows.Forms.Label();
            this.gpAlumnExtraOption.SuspendLayout();
            this.gpAlumnUpdateDelete.SuspendLayout();
            this.gpAlumnNewRegistry.SuspendLayout();
            this.gpAlumnNavigate.SuspendLayout();
            this.gbAlumnData.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpAlumnExtraOption
            // 
            this.gpAlumnExtraOption.Controls.Add(this.btnAlumnSearchCourse);
            this.gpAlumnExtraOption.Controls.Add(this.btnListAlumns);
            this.gpAlumnExtraOption.Controls.Add(this.btnSearchAlumn);
            this.gpAlumnExtraOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpAlumnExtraOption.Location = new System.Drawing.Point(432, 12);
            this.gpAlumnExtraOption.Name = "gpAlumnExtraOption";
            this.gpAlumnExtraOption.Size = new System.Drawing.Size(225, 217);
            this.gpAlumnExtraOption.TabIndex = 17;
            this.gpAlumnExtraOption.TabStop = false;
            this.gpAlumnExtraOption.Text = "LIST AND SEARCH";
            // 
            // btnAlumnSearchCourse
            // 
            this.btnAlumnSearchCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlumnSearchCourse.Location = new System.Drawing.Point(17, 95);
            this.btnAlumnSearchCourse.Name = "btnAlumnSearchCourse";
            this.btnAlumnSearchCourse.Size = new System.Drawing.Size(189, 41);
            this.btnAlumnSearchCourse.TabIndex = 2;
            this.btnAlumnSearchCourse.Text = "SEARCH BY COURSE";
            this.btnAlumnSearchCourse.UseVisualStyleBackColor = true;
            this.btnAlumnSearchCourse.Click += new System.EventHandler(this.btnAlumnSearchCourse_Click);
            // 
            // btnListAlumns
            // 
            this.btnListAlumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListAlumns.Location = new System.Drawing.Point(17, 156);
            this.btnListAlumns.Name = "btnListAlumns";
            this.btnListAlumns.Size = new System.Drawing.Size(189, 41);
            this.btnListAlumns.TabIndex = 0;
            this.btnListAlumns.Text = "ALUMNS LIST";
            this.btnListAlumns.UseVisualStyleBackColor = true;
            this.btnListAlumns.Click += new System.EventHandler(this.btnListAlumns_Click);
            // 
            // btnSearchAlumn
            // 
            this.btnSearchAlumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchAlumn.Location = new System.Drawing.Point(17, 34);
            this.btnSearchAlumn.Name = "btnSearchAlumn";
            this.btnSearchAlumn.Size = new System.Drawing.Size(189, 41);
            this.btnSearchAlumn.TabIndex = 1;
            this.btnSearchAlumn.Text = "SEARCH BY SURNAME";
            this.btnSearchAlumn.UseVisualStyleBackColor = true;
            this.btnSearchAlumn.Click += new System.EventHandler(this.btnSearchAlumn_Click);
            // 
            // gpAlumnUpdateDelete
            // 
            this.gpAlumnUpdateDelete.Controls.Add(this.btnAlumnDelete);
            this.gpAlumnUpdateDelete.Controls.Add(this.btnAlumnUpdate);
            this.gpAlumnUpdateDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpAlumnUpdateDelete.Location = new System.Drawing.Point(432, 247);
            this.gpAlumnUpdateDelete.Name = "gpAlumnUpdateDelete";
            this.gpAlumnUpdateDelete.Size = new System.Drawing.Size(225, 155);
            this.gpAlumnUpdateDelete.TabIndex = 18;
            this.gpAlumnUpdateDelete.TabStop = false;
            this.gpAlumnUpdateDelete.Text = "UPDATE AND DELETE";
            // 
            // btnAlumnDelete
            // 
            this.btnAlumnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlumnDelete.Location = new System.Drawing.Point(20, 90);
            this.btnAlumnDelete.Name = "btnAlumnDelete";
            this.btnAlumnDelete.Size = new System.Drawing.Size(185, 41);
            this.btnAlumnDelete.TabIndex = 1;
            this.btnAlumnDelete.Text = "DELETE";
            this.btnAlumnDelete.UseVisualStyleBackColor = true;
            this.btnAlumnDelete.Click += new System.EventHandler(this.btnAlumnDelete_Click);
            // 
            // btnAlumnUpdate
            // 
            this.btnAlumnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlumnUpdate.Location = new System.Drawing.Point(21, 32);
            this.btnAlumnUpdate.Name = "btnAlumnUpdate";
            this.btnAlumnUpdate.Size = new System.Drawing.Size(185, 41);
            this.btnAlumnUpdate.TabIndex = 0;
            this.btnAlumnUpdate.Text = "UPDATE";
            this.btnAlumnUpdate.UseVisualStyleBackColor = true;
            this.btnAlumnUpdate.Click += new System.EventHandler(this.btnAlumnUpdate_Click);
            // 
            // gpAlumnNewRegistry
            // 
            this.gpAlumnNewRegistry.Controls.Add(this.btnAlumnCancelAddRegistry);
            this.gpAlumnNewRegistry.Controls.Add(this.btnAlumnClear);
            this.gpAlumnNewRegistry.Controls.Add(this.btnAlumnSave);
            this.gpAlumnNewRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpAlumnNewRegistry.Location = new System.Drawing.Point(12, 537);
            this.gpAlumnNewRegistry.Name = "gpAlumnNewRegistry";
            this.gpAlumnNewRegistry.Size = new System.Drawing.Size(645, 92);
            this.gpAlumnNewRegistry.TabIndex = 16;
            this.gpAlumnNewRegistry.TabStop = false;
            this.gpAlumnNewRegistry.Text = "NEW REGISTRY";
            // 
            // btnAlumnCancelAddRegistry
            // 
            this.btnAlumnCancelAddRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlumnCancelAddRegistry.Location = new System.Drawing.Point(222, 32);
            this.btnAlumnCancelAddRegistry.Name = "btnAlumnCancelAddRegistry";
            this.btnAlumnCancelAddRegistry.Size = new System.Drawing.Size(194, 41);
            this.btnAlumnCancelAddRegistry.TabIndex = 2;
            this.btnAlumnCancelAddRegistry.Text = "CANCEL REGISTRY ADDITION";
            this.btnAlumnCancelAddRegistry.UseVisualStyleBackColor = true;
            this.btnAlumnCancelAddRegistry.Click += new System.EventHandler(this.btnAlumnCancelAddRegistry_Click);
            // 
            // btnAlumnClear
            // 
            this.btnAlumnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlumnClear.Location = new System.Drawing.Point(18, 32);
            this.btnAlumnClear.Name = "btnAlumnClear";
            this.btnAlumnClear.Size = new System.Drawing.Size(187, 41);
            this.btnAlumnClear.TabIndex = 0;
            this.btnAlumnClear.Text = "CLEAR DATA";
            this.btnAlumnClear.UseVisualStyleBackColor = true;
            this.btnAlumnClear.Click += new System.EventHandler(this.btnAlumnClear_Click);
            // 
            // btnAlumnSave
            // 
            this.btnAlumnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlumnSave.Location = new System.Drawing.Point(440, 32);
            this.btnAlumnSave.Name = "btnAlumnSave";
            this.btnAlumnSave.Size = new System.Drawing.Size(186, 41);
            this.btnAlumnSave.TabIndex = 1;
            this.btnAlumnSave.Text = "SAVE AS NEW";
            this.btnAlumnSave.UseVisualStyleBackColor = true;
            this.btnAlumnSave.Click += new System.EventHandler(this.btnAlumnSave_Click);
            // 
            // gpAlumnNavigate
            // 
            this.gpAlumnNavigate.Controls.Add(this.btnAlumnPrevious);
            this.gpAlumnNavigate.Controls.Add(this.btnAlumnNext);
            this.gpAlumnNavigate.Controls.Add(this.btnAlumnLast);
            this.gpAlumnNavigate.Controls.Add(this.btnAlumnFirst);
            this.gpAlumnNavigate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpAlumnNavigate.Location = new System.Drawing.Point(12, 416);
            this.gpAlumnNavigate.Name = "gpAlumnNavigate";
            this.gpAlumnNavigate.Size = new System.Drawing.Size(645, 104);
            this.gpAlumnNavigate.TabIndex = 15;
            this.gpAlumnNavigate.TabStop = false;
            this.gpAlumnNavigate.Text = "NAVIGATE TO";
            // 
            // btnAlumnPrevious
            // 
            this.btnAlumnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlumnPrevious.Location = new System.Drawing.Point(491, 37);
            this.btnAlumnPrevious.Name = "btnAlumnPrevious";
            this.btnAlumnPrevious.Size = new System.Drawing.Size(134, 41);
            this.btnAlumnPrevious.TabIndex = 3;
            this.btnAlumnPrevious.Text = "PREVIOUS";
            this.btnAlumnPrevious.UseVisualStyleBackColor = true;
            this.btnAlumnPrevious.Click += new System.EventHandler(this.btnAlumnPrevious_Click);
            // 
            // btnAlumnNext
            // 
            this.btnAlumnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlumnNext.Location = new System.Drawing.Point(331, 37);
            this.btnAlumnNext.Name = "btnAlumnNext";
            this.btnAlumnNext.Size = new System.Drawing.Size(134, 41);
            this.btnAlumnNext.TabIndex = 2;
            this.btnAlumnNext.Text = "NEXT";
            this.btnAlumnNext.UseVisualStyleBackColor = true;
            this.btnAlumnNext.Click += new System.EventHandler(this.btnAlumnNext_Click);
            // 
            // btnAlumnLast
            // 
            this.btnAlumnLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlumnLast.Location = new System.Drawing.Point(173, 37);
            this.btnAlumnLast.Name = "btnAlumnLast";
            this.btnAlumnLast.Size = new System.Drawing.Size(134, 41);
            this.btnAlumnLast.TabIndex = 1;
            this.btnAlumnLast.Text = "LAST";
            this.btnAlumnLast.UseVisualStyleBackColor = true;
            this.btnAlumnLast.Click += new System.EventHandler(this.btnAlumnLast_Click);
            // 
            // btnAlumnFirst
            // 
            this.btnAlumnFirst.Enabled = false;
            this.btnAlumnFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlumnFirst.Location = new System.Drawing.Point(18, 37);
            this.btnAlumnFirst.Name = "btnAlumnFirst";
            this.btnAlumnFirst.Size = new System.Drawing.Size(134, 41);
            this.btnAlumnFirst.TabIndex = 0;
            this.btnAlumnFirst.Text = "FIRST";
            this.btnAlumnFirst.UseVisualStyleBackColor = true;
            this.btnAlumnFirst.Click += new System.EventHandler(this.btnAlumnFirst_Click);
            // 
            // gbAlumnData
            // 
            this.gbAlumnData.Controls.Add(this.txtbAlumnCourse);
            this.gbAlumnData.Controls.Add(this.lblAlumnCourse);
            this.gbAlumnData.Controls.Add(this.txtbAlumnPassword);
            this.gbAlumnData.Controls.Add(this.lblAlumnPassword);
            this.gbAlumnData.Controls.Add(this.lblRecord);
            this.gbAlumnData.Controls.Add(this.txtbAlumnID);
            this.gbAlumnData.Controls.Add(this.txtbAlumnName);
            this.gbAlumnData.Controls.Add(this.txtbAlumnAdress);
            this.gbAlumnData.Controls.Add(this.txtbAlumnPhone);
            this.gbAlumnData.Controls.Add(this.txtbAlumnSurnames);
            this.gbAlumnData.Controls.Add(this.lblAlumnAdress);
            this.gbAlumnData.Controls.Add(this.lbAlumnlPhone);
            this.gbAlumnData.Controls.Add(this.lblAlumnSurnames);
            this.gbAlumnData.Controls.Add(this.lblAlumnName);
            this.gbAlumnData.Controls.Add(this.lblAlumnID);
            this.gbAlumnData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAlumnData.Location = new System.Drawing.Point(12, 12);
            this.gbAlumnData.Name = "gbAlumnData";
            this.gbAlumnData.Size = new System.Drawing.Size(397, 390);
            this.gbAlumnData.TabIndex = 14;
            this.gbAlumnData.TabStop = false;
            this.gbAlumnData.Text = "ALUMN DATA";
            // 
            // txtbAlumnCourse
            // 
            this.txtbAlumnCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbAlumnCourse.Location = new System.Drawing.Point(130, 342);
            this.txtbAlumnCourse.Name = "txtbAlumnCourse";
            this.txtbAlumnCourse.Size = new System.Drawing.Size(246, 22);
            this.txtbAlumnCourse.TabIndex = 14;
            this.txtbAlumnCourse.TextChanged += new System.EventHandler(this.txtbCourse_TextChanged);
            // 
            // lblAlumnCourse
            // 
            this.lblAlumnCourse.AutoSize = true;
            this.lblAlumnCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlumnCourse.Location = new System.Drawing.Point(26, 344);
            this.lblAlumnCourse.Name = "lblAlumnCourse";
            this.lblAlumnCourse.Size = new System.Drawing.Size(67, 16);
            this.lblAlumnCourse.TabIndex = 13;
            this.lblAlumnCourse.Text = "COURSE:";
            this.lblAlumnCourse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtbAlumnPassword
            // 
            this.txtbAlumnPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbAlumnPassword.Location = new System.Drawing.Point(130, 292);
            this.txtbAlumnPassword.Name = "txtbAlumnPassword";
            this.txtbAlumnPassword.Size = new System.Drawing.Size(246, 22);
            this.txtbAlumnPassword.TabIndex = 12;
            this.txtbAlumnPassword.TextChanged += new System.EventHandler(this.txtbPassword_TextChanged);
            // 
            // lblAlumnPassword
            // 
            this.lblAlumnPassword.AutoSize = true;
            this.lblAlumnPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlumnPassword.Location = new System.Drawing.Point(26, 294);
            this.lblAlumnPassword.Name = "lblAlumnPassword";
            this.lblAlumnPassword.Size = new System.Drawing.Size(89, 16);
            this.lblAlumnPassword.TabIndex = 11;
            this.lblAlumnPassword.Text = "PASSWORD:";
            this.lblAlumnPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // txtbAlumnID
            // 
            this.txtbAlumnID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbAlumnID.Location = new System.Drawing.Point(130, 42);
            this.txtbAlumnID.Name = "txtbAlumnID";
            this.txtbAlumnID.Size = new System.Drawing.Size(246, 22);
            this.txtbAlumnID.TabIndex = 9;
            this.txtbAlumnID.TextChanged += new System.EventHandler(this.txtbAlumnID_TextChanged);
            // 
            // txtbAlumnName
            // 
            this.txtbAlumnName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbAlumnName.Location = new System.Drawing.Point(130, 92);
            this.txtbAlumnName.Name = "txtbAlumnName";
            this.txtbAlumnName.Size = new System.Drawing.Size(246, 22);
            this.txtbAlumnName.TabIndex = 8;
            this.txtbAlumnName.TextChanged += new System.EventHandler(this.txtbAlumnName_TextChanged);
            // 
            // txtbAlumnAdress
            // 
            this.txtbAlumnAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbAlumnAdress.Location = new System.Drawing.Point(130, 242);
            this.txtbAlumnAdress.Name = "txtbAlumnAdress";
            this.txtbAlumnAdress.Size = new System.Drawing.Size(246, 22);
            this.txtbAlumnAdress.TabIndex = 7;
            this.txtbAlumnAdress.TextChanged += new System.EventHandler(this.txtbAdress_TextChanged);
            // 
            // txtbAlumnPhone
            // 
            this.txtbAlumnPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbAlumnPhone.Location = new System.Drawing.Point(130, 192);
            this.txtbAlumnPhone.Name = "txtbAlumnPhone";
            this.txtbAlumnPhone.Size = new System.Drawing.Size(246, 22);
            this.txtbAlumnPhone.TabIndex = 6;
            this.txtbAlumnPhone.TextChanged += new System.EventHandler(this.txtbAlumnPhone_TextChanged);
            // 
            // txtbAlumnSurnames
            // 
            this.txtbAlumnSurnames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbAlumnSurnames.Location = new System.Drawing.Point(130, 142);
            this.txtbAlumnSurnames.Name = "txtbAlumnSurnames";
            this.txtbAlumnSurnames.Size = new System.Drawing.Size(246, 22);
            this.txtbAlumnSurnames.TabIndex = 5;
            this.txtbAlumnSurnames.TextChanged += new System.EventHandler(this.txtbAlumnSurnames_TextChanged);
            // 
            // lblAlumnAdress
            // 
            this.lblAlumnAdress.AutoSize = true;
            this.lblAlumnAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlumnAdress.Location = new System.Drawing.Point(26, 244);
            this.lblAlumnAdress.Name = "lblAlumnAdress";
            this.lblAlumnAdress.Size = new System.Drawing.Size(66, 16);
            this.lblAlumnAdress.TabIndex = 4;
            this.lblAlumnAdress.Text = "ADRESS:";
            this.lblAlumnAdress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbAlumnlPhone
            // 
            this.lbAlumnlPhone.AutoSize = true;
            this.lbAlumnlPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAlumnlPhone.Location = new System.Drawing.Point(26, 194);
            this.lbAlumnlPhone.Name = "lbAlumnlPhone";
            this.lbAlumnlPhone.Size = new System.Drawing.Size(58, 16);
            this.lbAlumnlPhone.TabIndex = 3;
            this.lbAlumnlPhone.Text = "PHONE:";
            this.lbAlumnlPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAlumnSurnames
            // 
            this.lblAlumnSurnames.AutoSize = true;
            this.lblAlumnSurnames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlumnSurnames.Location = new System.Drawing.Point(26, 144);
            this.lblAlumnSurnames.Name = "lblAlumnSurnames";
            this.lblAlumnSurnames.Size = new System.Drawing.Size(87, 16);
            this.lblAlumnSurnames.TabIndex = 2;
            this.lblAlumnSurnames.Text = "SURNAMES:";
            this.lblAlumnSurnames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAlumnName
            // 
            this.lblAlumnName.AutoSize = true;
            this.lblAlumnName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlumnName.Location = new System.Drawing.Point(26, 94);
            this.lblAlumnName.Name = "lblAlumnName";
            this.lblAlumnName.Size = new System.Drawing.Size(49, 16);
            this.lblAlumnName.TabIndex = 1;
            this.lblAlumnName.Text = "NAME:";
            this.lblAlumnName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAlumnID
            // 
            this.lblAlumnID.AutoSize = true;
            this.lblAlumnID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlumnID.Location = new System.Drawing.Point(26, 44);
            this.lblAlumnID.Name = "lblAlumnID";
            this.lblAlumnID.Size = new System.Drawing.Size(23, 16);
            this.lblAlumnID.TabIndex = 0;
            this.lblAlumnID.Text = "ID:";
            this.lblAlumnID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fAlumnManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 646);
            this.Controls.Add(this.gpAlumnExtraOption);
            this.Controls.Add(this.gpAlumnUpdateDelete);
            this.Controls.Add(this.gpAlumnNewRegistry);
            this.Controls.Add(this.gpAlumnNavigate);
            this.Controls.Add(this.gbAlumnData);
            this.Name = "fAlumnManagement";
            this.Text = "Alumns Management";
            this.Load += new System.EventHandler(this.fAlumnManagement_Load);
            this.gpAlumnExtraOption.ResumeLayout(false);
            this.gpAlumnUpdateDelete.ResumeLayout(false);
            this.gpAlumnNewRegistry.ResumeLayout(false);
            this.gpAlumnNavigate.ResumeLayout(false);
            this.gbAlumnData.ResumeLayout(false);
            this.gbAlumnData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpAlumnExtraOption;
        private System.Windows.Forms.Button btnListAlumns;
        private System.Windows.Forms.Button btnSearchAlumn;
        private System.Windows.Forms.GroupBox gpAlumnUpdateDelete;
        private System.Windows.Forms.Button btnAlumnDelete;
        private System.Windows.Forms.Button btnAlumnUpdate;
        private System.Windows.Forms.GroupBox gpAlumnNewRegistry;
        private System.Windows.Forms.Button btnAlumnCancelAddRegistry;
        private System.Windows.Forms.Button btnAlumnClear;
        private System.Windows.Forms.Button btnAlumnSave;
        private System.Windows.Forms.GroupBox gpAlumnNavigate;
        private System.Windows.Forms.Button btnAlumnPrevious;
        private System.Windows.Forms.Button btnAlumnNext;
        private System.Windows.Forms.Button btnAlumnLast;
        private System.Windows.Forms.Button btnAlumnFirst;
        private System.Windows.Forms.GroupBox gbAlumnData;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.TextBox txtbAlumnID;
        private System.Windows.Forms.TextBox txtbAlumnName;
        private System.Windows.Forms.TextBox txtbAlumnAdress;
        private System.Windows.Forms.TextBox txtbAlumnPhone;
        private System.Windows.Forms.TextBox txtbAlumnSurnames;
        private System.Windows.Forms.Label lblAlumnAdress;
        private System.Windows.Forms.Label lbAlumnlPhone;
        private System.Windows.Forms.Label lblAlumnSurnames;
        private System.Windows.Forms.Label lblAlumnName;
        private System.Windows.Forms.Label lblAlumnID;
        private System.Windows.Forms.TextBox txtbAlumnPassword;
        private System.Windows.Forms.Label lblAlumnPassword;
        private System.Windows.Forms.Button btnAlumnSearchCourse;
        private System.Windows.Forms.TextBox txtbAlumnCourse;
        private System.Windows.Forms.Label lblAlumnCourse;
    }
}