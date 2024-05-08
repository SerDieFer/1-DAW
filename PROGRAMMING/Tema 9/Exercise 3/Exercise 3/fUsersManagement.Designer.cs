namespace Exercise_3
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
            this.btnListBannedUsers = new System.Windows.Forms.Button();
            this.btnListUsers = new System.Windows.Forms.Button();
            this.btnSearchUser = new System.Windows.Forms.Button();
            this.gpUpdateDeleteBan = new System.Windows.Forms.GroupBox();
            this.btnUnban = new System.Windows.Forms.Button();
            this.btnBan = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.gpNewRegistry = new System.Windows.Forms.GroupBox();
            this.btnCancelAddRegistry = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gpNavigate = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.txtbBanned = new System.Windows.Forms.TextBox();
            this.lblBanned = new System.Windows.Forms.Label();
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
            this.gpUpdateDeleteBan.SuspendLayout();
            this.gpNewRegistry.SuspendLayout();
            this.gpNavigate.SuspendLayout();
            this.gbData.SuspendLayout();
            this.SuspendLayout();
            // 
            // gExtraOption
            // 
            this.gExtraOption.Controls.Add(this.btnListBannedUsers);
            this.gExtraOption.Controls.Add(this.btnListUsers);
            this.gExtraOption.Controls.Add(this.btnSearchUser);
            this.gExtraOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gExtraOption.Location = new System.Drawing.Point(441, 27);
            this.gExtraOption.Name = "gExtraOption";
            this.gExtraOption.Size = new System.Drawing.Size(316, 179);
            this.gExtraOption.TabIndex = 17;
            this.gExtraOption.TabStop = false;
            this.gExtraOption.Text = "LIST AND SEARCH";
            // 
            // btnListBannedUsers
            // 
            this.btnListBannedUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListBannedUsers.Location = new System.Drawing.Point(29, 106);
            this.btnListBannedUsers.Name = "btnListBannedUsers";
            this.btnListBannedUsers.Size = new System.Drawing.Size(259, 41);
            this.btnListBannedUsers.TabIndex = 2;
            this.btnListBannedUsers.Text = "LIST OF BANNED USERS";
            this.btnListBannedUsers.UseVisualStyleBackColor = true;
            this.btnListBannedUsers.Click += new System.EventHandler(this.btnListBannedUsers_Click);
            // 
            // btnListUsers
            // 
            this.btnListUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListUsers.Location = new System.Drawing.Point(168, 36);
            this.btnListUsers.Name = "btnListUsers";
            this.btnListUsers.Size = new System.Drawing.Size(120, 46);
            this.btnListUsers.TabIndex = 0;
            this.btnListUsers.Text = "LIST OF USERS";
            this.btnListUsers.UseVisualStyleBackColor = true;
            this.btnListUsers.Click += new System.EventHandler(this.btnListUsers_Click);
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchUser.Location = new System.Drawing.Point(29, 36);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(120, 46);
            this.btnSearchUser.TabIndex = 1;
            this.btnSearchUser.Text = "SEARCH BY NICKNAME";
            this.btnSearchUser.UseVisualStyleBackColor = true;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // gpUpdateDeleteBan
            // 
            this.gpUpdateDeleteBan.Controls.Add(this.btnUnban);
            this.gpUpdateDeleteBan.Controls.Add(this.btnBan);
            this.gpUpdateDeleteBan.Controls.Add(this.btnDelete);
            this.gpUpdateDeleteBan.Controls.Add(this.btnUpdate);
            this.gpUpdateDeleteBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpUpdateDeleteBan.Location = new System.Drawing.Point(12, 299);
            this.gpUpdateDeleteBan.Name = "gpUpdateDeleteBan";
            this.gpUpdateDeleteBan.Size = new System.Drawing.Size(397, 107);
            this.gpUpdateDeleteBan.TabIndex = 18;
            this.gpUpdateDeleteBan.TabStop = false;
            this.gpUpdateDeleteBan.Text = "UPDATE, DELETE, BAN AND UNBAN";
            // 
            // btnUnban
            // 
            this.btnUnban.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnban.Location = new System.Drawing.Point(294, 37);
            this.btnUnban.Name = "btnUnban";
            this.btnUnban.Size = new System.Drawing.Size(76, 41);
            this.btnUnban.TabIndex = 3;
            this.btnUnban.Text = "UNBAN";
            this.btnUnban.UseVisualStyleBackColor = true;
            this.btnUnban.Click += new System.EventHandler(this.btnUnban_Click);
            // 
            // btnBan
            // 
            this.btnBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBan.Location = new System.Drawing.Point(203, 37);
            this.btnBan.Name = "btnBan";
            this.btnBan.Size = new System.Drawing.Size(76, 41);
            this.btnBan.TabIndex = 2;
            this.btnBan.Text = "BAN";
            this.btnBan.UseVisualStyleBackColor = true;
            this.btnBan.Click += new System.EventHandler(this.btnBan_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(112, 37);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(76, 41);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(21, 37);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(76, 41);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // gpNewRegistry
            // 
            this.gpNewRegistry.Controls.Add(this.btnCancelAddRegistry);
            this.gpNewRegistry.Controls.Add(this.btnClear);
            this.gpNewRegistry.Controls.Add(this.btnSave);
            this.gpNewRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpNewRegistry.Location = new System.Drawing.Point(12, 421);
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
            this.btnCancelAddRegistry.Click += new System.EventHandler(this.btnCancelAddRegistry_Click);
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
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gpNavigate
            // 
            this.gpNavigate.Controls.Add(this.btnNext);
            this.gpNavigate.Controls.Add(this.btnLast);
            this.gpNavigate.Controls.Add(this.btnPrevious);
            this.gpNavigate.Controls.Add(this.btnFirst);
            this.gpNavigate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpNavigate.Location = new System.Drawing.Point(441, 236);
            this.gpNavigate.Name = "gpNavigate";
            this.gpNavigate.Size = new System.Drawing.Size(316, 170);
            this.gpNavigate.TabIndex = 15;
            this.gpNavigate.TabStop = false;
            this.gpNavigate.Text = "NAVIGATE TO";
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(168, 37);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(120, 41);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "NEXT";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast.Location = new System.Drawing.Point(29, 100);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(120, 41);
            this.btnLast.TabIndex = 1;
            this.btnLast.Text = "LAST";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(29, 37);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(120, 41);
            this.btnPrevious.TabIndex = 3;
            this.btnPrevious.Text = "PREVIOUS";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Enabled = false;
            this.btnFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.Location = new System.Drawing.Point(168, 100);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(120, 41);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.Text = "FIRST";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.txtbBanned);
            this.gbData.Controls.Add(this.lblBanned);
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
            this.gbData.Size = new System.Drawing.Size(397, 269);
            this.gbData.TabIndex = 14;
            this.gbData.TabStop = false;
            this.gbData.Text = "USERS DATA";
            // 
            // txtbBanned
            // 
            this.txtbBanned.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbBanned.Location = new System.Drawing.Point(153, 214);
            this.txtbBanned.Name = "txtbBanned";
            this.txtbBanned.ReadOnly = true;
            this.txtbBanned.ShortcutsEnabled = false;
            this.txtbBanned.Size = new System.Drawing.Size(217, 22);
            this.txtbBanned.TabIndex = 12;
            this.txtbBanned.TabStop = false;
            this.txtbBanned.TextChanged += new System.EventHandler(this.txtbBanned_TextChanged);
            // 
            // lblBanned
            // 
            this.lblBanned.AutoSize = true;
            this.lblBanned.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanned.Location = new System.Drawing.Point(23, 217);
            this.lblBanned.Name = "lblBanned";
            this.lblBanned.Size = new System.Drawing.Size(67, 16);
            this.lblBanned.TabIndex = 11;
            this.lblBanned.Text = "BANNED:";
            this.lblBanned.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.txtbID.ShortcutsEnabled = false;
            this.txtbID.Size = new System.Drawing.Size(217, 22);
            this.txtbID.TabIndex = 9;
            this.txtbID.TabStop = false;
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
            this.ClientSize = new System.Drawing.Size(781, 537);
            this.Controls.Add(this.gExtraOption);
            this.Controls.Add(this.gpUpdateDeleteBan);
            this.Controls.Add(this.gpNewRegistry);
            this.Controls.Add(this.gpNavigate);
            this.Controls.Add(this.gbData);
            this.Name = "fUsersManagement";
            this.Text = "Users Management";
            this.Load += new System.EventHandler(this.fUsersManagement_Load);
            this.gExtraOption.ResumeLayout(false);
            this.gpUpdateDeleteBan.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox gpUpdateDeleteBan;
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
        private System.Windows.Forms.Button btnListBannedUsers;
        private System.Windows.Forms.Button btnUnban;
        private System.Windows.Forms.Button btnBan;
        private System.Windows.Forms.TextBox txtbBanned;
        private System.Windows.Forms.Label lblBanned;
    }
}

