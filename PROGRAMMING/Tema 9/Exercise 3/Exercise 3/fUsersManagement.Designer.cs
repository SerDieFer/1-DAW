﻿namespace Exercise_3
{
    partial class fUsersManagement
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
            this.gExtraOption = new System.Windows.Forms.GroupBox();
            this.btnListUsers = new System.Windows.Forms.Button();
            this.btnSearchUser = new System.Windows.Forms.Button();
            this.gpUpdateDelete = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.gpNewRegistry = new System.Windows.Forms.GroupBox();
            this.btnCancelAddRegistry = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gpNavigate = new System.Windows.Forms.GroupBox();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.lblRecord = new System.Windows.Forms.Label();
            this.txtbID = new System.Windows.Forms.TextBox();
            this.txtbName = new System.Windows.Forms.TextBox();
            this.txtbEmail = new System.Windows.Forms.TextBox();
            this.txtbPassword = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.gExtraOption.SuspendLayout();
            this.gpUpdateDelete.SuspendLayout();
            this.gpNewRegistry.SuspendLayout();
            this.gpNavigate.SuspendLayout();
            this.gbData.SuspendLayout();
            this.SuspendLayout();
            // 
            // gExtraOption
            // 
            this.gExtraOption.Controls.Add(this.btnListUsers);
            this.gExtraOption.Controls.Add(this.btnSearchUser);
            this.gExtraOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gExtraOption.Location = new System.Drawing.Point(441, 27);
            this.gExtraOption.Name = "gExtraOption";
            this.gExtraOption.Size = new System.Drawing.Size(316, 92);
            this.gExtraOption.TabIndex = 17;
            this.gExtraOption.TabStop = false;
            this.gExtraOption.Text = "LIST AND SEARCH";
            // 
            // btnListUsers
            // 
            this.btnListUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListUsers.Location = new System.Drawing.Point(168, 33);
            this.btnListUsers.Name = "btnListUsers";
            this.btnListUsers.Size = new System.Drawing.Size(120, 41);
            this.btnListUsers.TabIndex = 0;
            this.btnListUsers.Text = "LIST OF USERS";
            this.btnListUsers.UseVisualStyleBackColor = true;
            this.btnListUsers.Click += new System.EventHandler(this.btnListUsers_Click);
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchUser.Location = new System.Drawing.Point(29, 33);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(120, 41);
            this.btnSearchUser.TabIndex = 1;
            this.btnSearchUser.Text = "SEARCH BY EMAIL";
            this.btnSearchUser.UseVisualStyleBackColor = true;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // gpUpdateDelete
            // 
            this.gpUpdateDelete.Controls.Add(this.btnDelete);
            this.gpUpdateDelete.Controls.Add(this.btnUpdate);
            this.gpUpdateDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpUpdateDelete.Location = new System.Drawing.Point(441, 148);
            this.gpUpdateDelete.Name = "gpUpdateDelete";
            this.gpUpdateDelete.Size = new System.Drawing.Size(316, 92);
            this.gpUpdateDelete.TabIndex = 18;
            this.gpUpdateDelete.TabStop = false;
            this.gpUpdateDelete.Text = "UPDATE AND DELETE";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(168, 36);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 41);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(29, 36);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 41);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // gpNewRegistry
            // 
            this.gpNewRegistry.Controls.Add(this.btnCancelAddRegistry);
            this.gpNewRegistry.Controls.Add(this.btnClear);
            this.gpNewRegistry.Controls.Add(this.btnSave);
            this.gpNewRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpNewRegistry.Location = new System.Drawing.Point(12, 385);
            this.gpNewRegistry.Name = "gpNewRegistry";
            this.gpNewRegistry.Size = new System.Drawing.Size(745, 92);
            this.gpNewRegistry.TabIndex = 16;
            this.gpNewRegistry.TabStop = false;
            this.gpNewRegistry.Text = "NEW REGISTRY";
            // 
            // btnCancelAddRegistry
            // 
            this.btnCancelAddRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelAddRegistry.Location = new System.Drawing.Point(266, 32);
            this.btnCancelAddRegistry.Name = "btnCancelAddRegistry";
            this.btnCancelAddRegistry.Size = new System.Drawing.Size(210, 41);
            this.btnCancelAddRegistry.TabIndex = 2;
            this.btnCancelAddRegistry.Text = "CANCEL REGISTRY ADDITION";
            this.btnCancelAddRegistry.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(21, 32);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(197, 41);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "CLEAR DATA";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(521, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(196, 41);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "SAVE AS NEW";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // gpNavigate
            // 
            this.gpNavigate.Controls.Add(this.btnPrevious);
            this.gpNavigate.Controls.Add(this.btnNext);
            this.gpNavigate.Controls.Add(this.btnLast);
            this.gpNavigate.Controls.Add(this.btnFirst);
            this.gpNavigate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpNavigate.Location = new System.Drawing.Point(12, 256);
            this.gpNavigate.Name = "gpNavigate";
            this.gpNavigate.Size = new System.Drawing.Size(745, 105);
            this.gpNavigate.TabIndex = 15;
            this.gpNavigate.TabStop = false;
            this.gpNavigate.Text = "NAVIGATE TO";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(565, 37);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(152, 41);
            this.btnPrevious.TabIndex = 3;
            this.btnPrevious.Text = "PREVIOUS";
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(384, 37);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(152, 41);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "NEXT";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnLast
            // 
            this.btnLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast.Location = new System.Drawing.Point(202, 37);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(152, 41);
            this.btnLast.TabIndex = 1;
            this.btnLast.Text = "LAST";
            this.btnLast.UseVisualStyleBackColor = true;
            // 
            // btnFirst
            // 
            this.btnFirst.Enabled = false;
            this.btnFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.Location = new System.Drawing.Point(21, 37);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(152, 41);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.Text = "FIRST";
            this.btnFirst.UseVisualStyleBackColor = true;
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.lblRecord);
            this.gbData.Controls.Add(this.txtbID);
            this.gbData.Controls.Add(this.txtbName);
            this.gbData.Controls.Add(this.txtbEmail);
            this.gbData.Controls.Add(this.txtbPassword);
            this.gbData.Controls.Add(this.lblEmail);
            this.gbData.Controls.Add(this.lblPassword);
            this.gbData.Controls.Add(this.lblName);
            this.gbData.Controls.Add(this.lblID);
            this.gbData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbData.Location = new System.Drawing.Point(12, 12);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(397, 228);
            this.gbData.TabIndex = 14;
            this.gbData.TabStop = false;
            this.gbData.Text = "USERS DATA";
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
            // txtbID
            // 
            this.txtbID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbID.Location = new System.Drawing.Point(153, 48);
            this.txtbID.Name = "txtbID";
            this.txtbID.ReadOnly = true;
            this.txtbID.Size = new System.Drawing.Size(217, 22);
            this.txtbID.TabIndex = 9;
            this.txtbID.TextChanged += new System.EventHandler(this.txtbID_TextChanged);
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
            // txtbEmail
            // 
            this.txtbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbEmail.Location = new System.Drawing.Point(153, 130);
            this.txtbEmail.Name = "txtbEmail";
            this.txtbEmail.Size = new System.Drawing.Size(217, 22);
            this.txtbEmail.TabIndex = 7;
            this.txtbEmail.TextChanged += new System.EventHandler(this.txtbEmail_TextChanged);
            // 
            // txtbPassword
            // 
            this.txtbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbPassword.Location = new System.Drawing.Point(153, 172);
            this.txtbPassword.Name = "txtbPassword";
            this.txtbPassword.Size = new System.Drawing.Size(217, 22);
            this.txtbPassword.TabIndex = 6;
            this.txtbPassword.TextChanged += new System.EventHandler(this.txtbPassword_TextChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(23, 133);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(49, 16);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "EMAIL:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(23, 175);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(89, 16);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "PASSWORD:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // fUsersManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 515);
            this.Controls.Add(this.gExtraOption);
            this.Controls.Add(this.gpUpdateDelete);
            this.Controls.Add(this.gpNewRegistry);
            this.Controls.Add(this.gpNavigate);
            this.Controls.Add(this.gbData);
            this.Name = "fUsersManagement";
            this.Text = "Users Management";
            this.Load += new System.EventHandler(this.fUsersManagement_Load);
            this.gExtraOption.ResumeLayout(false);
            this.gpUpdateDelete.ResumeLayout(false);
            this.gpNewRegistry.ResumeLayout(false);
            this.gpNavigate.ResumeLayout(false);
            this.gbData.ResumeLayout(false);
            this.gbData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gExtraOption;
        private System.Windows.Forms.Button btnListUsers;
        private System.Windows.Forms.Button btnSearchUser;
        private System.Windows.Forms.GroupBox gpUpdateDelete;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox gpNewRegistry;
        private System.Windows.Forms.Button btnCancelAddRegistry;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gpNavigate;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.TextBox txtbID;
        private System.Windows.Forms.TextBox txtbName;
        private System.Windows.Forms.TextBox txtbEmail;
        private System.Windows.Forms.TextBox txtbPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblID;
    }
}

