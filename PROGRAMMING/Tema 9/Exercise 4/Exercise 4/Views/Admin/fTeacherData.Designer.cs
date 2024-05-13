namespace Exercise_4
{
    partial class fTeacherData
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
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSurnames = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtbSurnames = new System.Windows.Forms.TextBox();
            this.txtbPhone = new System.Windows.Forms.TextBox();
            this.txtbEmail = new System.Windows.Forms.TextBox();
            this.txtbName = new System.Windows.Forms.TextBox();
            this.txtbID = new System.Windows.Forms.TextBox();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.lblRecord = new System.Windows.Forms.Label();
            this.gpNavigate = new System.Windows.Forms.GroupBox();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.gpNewRegistry = new System.Windows.Forms.GroupBox();
            this.btnCancelAddRegistry = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gpUpdateDelete = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnListTeachers = new System.Windows.Forms.Button();
            this.btnSearchTeacher = new System.Windows.Forms.Button();
            this.gExtraOption = new System.Windows.Forms.GroupBox();
            this.gbData.SuspendLayout();
            this.gpNavigate.SuspendLayout();
            this.gpNewRegistry.SuspendLayout();
            this.gpUpdateDelete.SuspendLayout();
            this.gExtraOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(23, 51);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(23, 16);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID:";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(23, 91);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 16);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "NAME:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSurnames
            // 
            this.lblSurnames.AutoSize = true;
            this.lblSurnames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurnames.Location = new System.Drawing.Point(23, 133);
            this.lblSurnames.Name = "lblSurnames";
            this.lblSurnames.Size = new System.Drawing.Size(87, 16);
            this.lblSurnames.TabIndex = 2;
            this.lblSurnames.Text = "SURNAMES:";
            this.lblSurnames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(23, 175);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(58, 16);
            this.lblPhone.TabIndex = 3;
            this.lblPhone.Text = "PHONE:";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(23, 217);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(49, 16);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "EMAIL:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtbSurnames
            // 
            this.txtbSurnames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbSurnames.Location = new System.Drawing.Point(153, 130);
            this.txtbSurnames.Name = "txtbSurnames";
            this.txtbSurnames.Size = new System.Drawing.Size(217, 22);
            this.txtbSurnames.TabIndex = 5;
            this.txtbSurnames.TextChanged += new System.EventHandler(this.txtbSurnames_TextChanged);
            // 
            // txtbPhone
            // 
            this.txtbPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbPhone.Location = new System.Drawing.Point(153, 172);
            this.txtbPhone.Name = "txtbPhone";
            this.txtbPhone.Size = new System.Drawing.Size(217, 22);
            this.txtbPhone.TabIndex = 6;
            this.txtbPhone.TextChanged += new System.EventHandler(this.txtbPhone_TextChanged);
            // 
            // txtbEmail
            // 
            this.txtbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbEmail.Location = new System.Drawing.Point(153, 214);
            this.txtbEmail.Name = "txtbEmail";
            this.txtbEmail.Size = new System.Drawing.Size(217, 22);
            this.txtbEmail.TabIndex = 7;
            this.txtbEmail.TextChanged += new System.EventHandler(this.txtbEmail_TextChanged);
            // 
            // txtbName
            // 
            this.txtbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbName.Location = new System.Drawing.Point(153, 88);
            this.txtbName.Name = "txtbName";
            this.txtbName.Size = new System.Drawing.Size(217, 22);
            this.txtbName.TabIndex = 8;
            this.txtbName.TextChanged += new System.EventHandler(this.txtbName_TextChanged);
            // 
            // txtbID
            // 
            this.txtbID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbID.Location = new System.Drawing.Point(153, 48);
            this.txtbID.Name = "txtbID";
            this.txtbID.Size = new System.Drawing.Size(217, 22);
            this.txtbID.TabIndex = 9;
            this.txtbID.TextChanged += new System.EventHandler(this.txtbID_TextChanged);
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.lblRecord);
            this.gbData.Controls.Add(this.txtbID);
            this.gbData.Controls.Add(this.txtbName);
            this.gbData.Controls.Add(this.txtbEmail);
            this.gbData.Controls.Add(this.txtbPhone);
            this.gbData.Controls.Add(this.txtbSurnames);
            this.gbData.Controls.Add(this.lblEmail);
            this.gbData.Controls.Add(this.lblPhone);
            this.gbData.Controls.Add(this.lblSurnames);
            this.gbData.Controls.Add(this.lblName);
            this.gbData.Controls.Add(this.lblID);
            this.gbData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbData.Location = new System.Drawing.Point(12, 12);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(397, 274);
            this.gbData.TabIndex = 10;
            this.gbData.TabStop = false;
            this.gbData.Text = "TEACHER DATA";
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
            // gpNavigate
            // 
            this.gpNavigate.Controls.Add(this.btnPrevious);
            this.gpNavigate.Controls.Add(this.btnNext);
            this.gpNavigate.Controls.Add(this.btnLast);
            this.gpNavigate.Controls.Add(this.btnFirst);
            this.gpNavigate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpNavigate.Location = new System.Drawing.Point(434, 12);
            this.gpNavigate.Name = "gpNavigate";
            this.gpNavigate.Size = new System.Drawing.Size(223, 274);
            this.gpNavigate.TabIndex = 11;
            this.gpNavigate.TabStop = false;
            this.gpNavigate.Text = "NAVIGATE TO";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(21, 208);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(178, 41);
            this.btnPrevious.TabIndex = 3;
            this.btnPrevious.Text = "PREVIOUS";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(21, 150);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(178, 41);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "NEXT";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast.Location = new System.Drawing.Point(21, 94);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(178, 41);
            this.btnLast.TabIndex = 1;
            this.btnLast.Text = "LAST";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Enabled = false;
            this.btnFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.Location = new System.Drawing.Point(21, 37);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(178, 41);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.Text = "FIRST";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // gpNewRegistry
            // 
            this.gpNewRegistry.Controls.Add(this.btnCancelAddRegistry);
            this.gpNewRegistry.Controls.Add(this.btnClear);
            this.gpNewRegistry.Controls.Add(this.btnSave);
            this.gpNewRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpNewRegistry.Location = new System.Drawing.Point(12, 423);
            this.gpNewRegistry.Name = "gpNewRegistry";
            this.gpNewRegistry.Size = new System.Drawing.Size(645, 92);
            this.gpNewRegistry.TabIndex = 12;
            this.gpNewRegistry.TabStop = false;
            this.gpNewRegistry.Text = "NEW REGISTRY";
            // 
            // btnCancelAddRegistry
            // 
            this.btnCancelAddRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelAddRegistry.Location = new System.Drawing.Point(222, 32);
            this.btnCancelAddRegistry.Name = "btnCancelAddRegistry";
            this.btnCancelAddRegistry.Size = new System.Drawing.Size(200, 41);
            this.btnCancelAddRegistry.TabIndex = 2;
            this.btnCancelAddRegistry.Text = "CANCEL REGISTRY ADDITION";
            this.btnCancelAddRegistry.UseVisualStyleBackColor = true;
            this.btnCancelAddRegistry.Click += new System.EventHandler(this.btnCancelAddRegistry_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(18, 32);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(187, 41);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "CLEAR DATA";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(440, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(186, 41);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "SAVE AS NEW";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gpUpdateDelete
            // 
            this.gpUpdateDelete.Controls.Add(this.btnDelete);
            this.gpUpdateDelete.Controls.Add(this.btnUpdate);
            this.gpUpdateDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpUpdateDelete.Location = new System.Drawing.Point(349, 312);
            this.gpUpdateDelete.Name = "gpUpdateDelete";
            this.gpUpdateDelete.Size = new System.Drawing.Size(308, 92);
            this.gpUpdateDelete.TabIndex = 13;
            this.gpUpdateDelete.TabStop = false;
            this.gpUpdateDelete.Text = "UPDATE AND DELETE";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(160, 32);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 41);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(21, 32);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 41);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnListTeachers
            // 
            this.btnListTeachers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListTeachers.Location = new System.Drawing.Point(156, 34);
            this.btnListTeachers.Name = "btnListTeachers";
            this.btnListTeachers.Size = new System.Drawing.Size(120, 41);
            this.btnListTeachers.TabIndex = 0;
            this.btnListTeachers.Text = "LIST OF TEACHERS";
            this.btnListTeachers.UseVisualStyleBackColor = true;
            this.btnListTeachers.Click += new System.EventHandler(this.btnListTeachers_Click);
            // 
            // btnSearchTeacher
            // 
            this.btnSearchTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchTeacher.Location = new System.Drawing.Point(17, 34);
            this.btnSearchTeacher.Name = "btnSearchTeacher";
            this.btnSearchTeacher.Size = new System.Drawing.Size(120, 41);
            this.btnSearchTeacher.TabIndex = 1;
            this.btnSearchTeacher.Text = "SEARCH BY SURNAME";
            this.btnSearchTeacher.UseVisualStyleBackColor = true;
            this.btnSearchTeacher.Click += new System.EventHandler(this.btnSearchTeacher_Click);
            // 
            // gExtraOption
            // 
            this.gExtraOption.Controls.Add(this.btnListTeachers);
            this.gExtraOption.Controls.Add(this.btnSearchTeacher);
            this.gExtraOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gExtraOption.Location = new System.Drawing.Point(12, 312);
            this.gExtraOption.Name = "gExtraOption";
            this.gExtraOption.Size = new System.Drawing.Size(299, 92);
            this.gExtraOption.TabIndex = 13;
            this.gExtraOption.TabStop = false;
            this.gExtraOption.Text = "LIST AND SEARCH";
            // 
            // fTeacherData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 527);
            this.Controls.Add(this.gExtraOption);
            this.Controls.Add(this.gpUpdateDelete);
            this.Controls.Add(this.gpNewRegistry);
            this.Controls.Add(this.gpNavigate);
            this.Controls.Add(this.gbData);
            this.Name = "fTeacherData";
            this.Text = "Teachers";
            this.Load += new System.EventHandler(this.fHighSchool_Load);
            this.gbData.ResumeLayout(false);
            this.gbData.PerformLayout();
            this.gpNavigate.ResumeLayout(false);
            this.gpNewRegistry.ResumeLayout(false);
            this.gpUpdateDelete.ResumeLayout(false);
            this.gExtraOption.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSurnames;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtbSurnames;
        private System.Windows.Forms.TextBox txtbPhone;
        private System.Windows.Forms.TextBox txtbEmail;
        private System.Windows.Forms.TextBox txtbName;
        private System.Windows.Forms.TextBox txtbID;
        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.GroupBox gpNavigate;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.GroupBox gpNewRegistry;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gpUpdateDelete;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Button btnListTeachers;
        private System.Windows.Forms.Button btnSearchTeacher;
        private System.Windows.Forms.GroupBox gExtraOption;
        private System.Windows.Forms.Button btnCancelAddRegistry;
    }
}

