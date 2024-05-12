namespace Exercise_3
{
    partial class fAdminCharactersManagement
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
            this.gbCharacterData = new System.Windows.Forms.GroupBox();
            this.lblCharacterImage = new System.Windows.Forms.Label();
            this.pbCharacter = new System.Windows.Forms.PictureBox();
            this.lblRecord = new System.Windows.Forms.Label();
            this.txtbCharacterID = new System.Windows.Forms.TextBox();
            this.txtbCharacterName = new System.Windows.Forms.TextBox();
            this.lblCharacterName = new System.Windows.Forms.Label();
            this.lblCharacterID = new System.Windows.Forms.Label();
            this.gpUpdateDeleteSetImage = new System.Windows.Forms.GroupBox();
            this.btnCharacterSetImage = new System.Windows.Forms.Button();
            this.btnCharacterUpdate = new System.Windows.Forms.Button();
            this.btnCharacterDelete = new System.Windows.Forms.Button();
            this.gpCharacterNavigate = new System.Windows.Forms.GroupBox();
            this.btnCharacterFirst = new System.Windows.Forms.Button();
            this.btnCharacterLast = new System.Windows.Forms.Button();
            this.btnCharacterPrevious = new System.Windows.Forms.Button();
            this.btnCharacterNext = new System.Windows.Forms.Button();
            this.gpCharacterExtraOption = new System.Windows.Forms.GroupBox();
            this.btnSearchCharacter = new System.Windows.Forms.Button();
            this.btnListCharacters = new System.Windows.Forms.Button();
            this.gpCharacterNewRegistry = new System.Windows.Forms.GroupBox();
            this.btnCharacterCancelAddRegistry = new System.Windows.Forms.Button();
            this.btnCharacterClear = new System.Windows.Forms.Button();
            this.btnCharacterSave = new System.Windows.Forms.Button();
            this.gbCharacterData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacter)).BeginInit();
            this.gpUpdateDeleteSetImage.SuspendLayout();
            this.gpCharacterNavigate.SuspendLayout();
            this.gpCharacterExtraOption.SuspendLayout();
            this.gpCharacterNewRegistry.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCharacterData
            // 
            this.gbCharacterData.Controls.Add(this.lblCharacterImage);
            this.gbCharacterData.Controls.Add(this.pbCharacter);
            this.gbCharacterData.Controls.Add(this.lblRecord);
            this.gbCharacterData.Controls.Add(this.txtbCharacterID);
            this.gbCharacterData.Controls.Add(this.txtbCharacterName);
            this.gbCharacterData.Controls.Add(this.lblCharacterName);
            this.gbCharacterData.Controls.Add(this.lblCharacterID);
            this.gbCharacterData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCharacterData.Location = new System.Drawing.Point(12, 12);
            this.gbCharacterData.Name = "gbCharacterData";
            this.gbCharacterData.Size = new System.Drawing.Size(397, 514);
            this.gbCharacterData.TabIndex = 19;
            this.gbCharacterData.TabStop = false;
            this.gbCharacterData.Text = "CHARACTER DATA";
            // 
            // lblCharacterImage
            // 
            this.lblCharacterImage.AutoSize = true;
            this.lblCharacterImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharacterImage.Location = new System.Drawing.Point(23, 132);
            this.lblCharacterImage.Name = "lblCharacterImage";
            this.lblCharacterImage.Size = new System.Drawing.Size(52, 16);
            this.lblCharacterImage.TabIndex = 12;
            this.lblCharacterImage.Text = "IMAGE:";
            this.lblCharacterImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbCharacter
            // 
            this.pbCharacter.Location = new System.Drawing.Point(26, 163);
            this.pbCharacter.Name = "pbCharacter";
            this.pbCharacter.Size = new System.Drawing.Size(344, 316);
            this.pbCharacter.TabIndex = 11;
            this.pbCharacter.TabStop = false;
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
            // txtbCharacterID
            // 
            this.txtbCharacterID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCharacterID.Location = new System.Drawing.Point(153, 48);
            this.txtbCharacterID.Name = "txtbCharacterID";
            this.txtbCharacterID.ReadOnly = true;
            this.txtbCharacterID.ShortcutsEnabled = false;
            this.txtbCharacterID.Size = new System.Drawing.Size(217, 22);
            this.txtbCharacterID.TabIndex = 9;
            this.txtbCharacterID.TabStop = false;
            // 
            // txtbCharacterName
            // 
            this.txtbCharacterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCharacterName.Location = new System.Drawing.Point(153, 88);
            this.txtbCharacterName.Name = "txtbCharacterName";
            this.txtbCharacterName.Size = new System.Drawing.Size(217, 22);
            this.txtbCharacterName.TabIndex = 8;
            this.txtbCharacterName.TextChanged += new System.EventHandler(this.txtbCharacterName_TextChanged);
            // 
            // lblCharacterName
            // 
            this.lblCharacterName.AutoSize = true;
            this.lblCharacterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharacterName.Location = new System.Drawing.Point(23, 91);
            this.lblCharacterName.Name = "lblCharacterName";
            this.lblCharacterName.Size = new System.Drawing.Size(49, 16);
            this.lblCharacterName.TabIndex = 1;
            this.lblCharacterName.Text = "NAME:";
            this.lblCharacterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCharacterID
            // 
            this.lblCharacterID.AutoSize = true;
            this.lblCharacterID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharacterID.Location = new System.Drawing.Point(23, 51);
            this.lblCharacterID.Name = "lblCharacterID";
            this.lblCharacterID.Size = new System.Drawing.Size(23, 16);
            this.lblCharacterID.TabIndex = 0;
            this.lblCharacterID.Text = "ID:";
            this.lblCharacterID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gpUpdateDeleteSetImage
            // 
            this.gpUpdateDeleteSetImage.Controls.Add(this.btnCharacterSetImage);
            this.gpUpdateDeleteSetImage.Controls.Add(this.btnCharacterUpdate);
            this.gpUpdateDeleteSetImage.Controls.Add(this.btnCharacterDelete);
            this.gpUpdateDeleteSetImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpUpdateDeleteSetImage.Location = new System.Drawing.Point(431, 12);
            this.gpUpdateDeleteSetImage.Name = "gpUpdateDeleteSetImage";
            this.gpUpdateDeleteSetImage.Size = new System.Drawing.Size(510, 107);
            this.gpUpdateDeleteSetImage.TabIndex = 20;
            this.gpUpdateDeleteSetImage.TabStop = false;
            this.gpUpdateDeleteSetImage.Text = "UPDATE, DELETE AND SET IMAGE";
            // 
            // btnCharacterSetImage
            // 
            this.btnCharacterSetImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCharacterSetImage.Location = new System.Drawing.Point(264, 39);
            this.btnCharacterSetImage.Name = "btnCharacterSetImage";
            this.btnCharacterSetImage.Size = new System.Drawing.Size(222, 41);
            this.btnCharacterSetImage.TabIndex = 2;
            this.btnCharacterSetImage.Text = "SET IMAGE";
            this.btnCharacterSetImage.UseVisualStyleBackColor = true;
            this.btnCharacterSetImage.Click += new System.EventHandler(this.btnSetImage_Click);
            // 
            // btnCharacterUpdate
            // 
            this.btnCharacterUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCharacterUpdate.Location = new System.Drawing.Point(26, 39);
            this.btnCharacterUpdate.Name = "btnCharacterUpdate";
            this.btnCharacterUpdate.Size = new System.Drawing.Size(103, 41);
            this.btnCharacterUpdate.TabIndex = 0;
            this.btnCharacterUpdate.Text = "UPDATE";
            this.btnCharacterUpdate.UseVisualStyleBackColor = true;
            this.btnCharacterUpdate.Click += new System.EventHandler(this.btnCharacterUpdate_Click);
            // 
            // btnCharacterDelete
            // 
            this.btnCharacterDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCharacterDelete.Location = new System.Drawing.Point(144, 39);
            this.btnCharacterDelete.Name = "btnCharacterDelete";
            this.btnCharacterDelete.Size = new System.Drawing.Size(103, 41);
            this.btnCharacterDelete.TabIndex = 1;
            this.btnCharacterDelete.Text = "DELETE";
            this.btnCharacterDelete.UseVisualStyleBackColor = true;
            this.btnCharacterDelete.Click += new System.EventHandler(this.btnCharacterDelete_Click);
            // 
            // gpCharacterNavigate
            // 
            this.gpCharacterNavigate.Controls.Add(this.btnCharacterFirst);
            this.gpCharacterNavigate.Controls.Add(this.btnCharacterLast);
            this.gpCharacterNavigate.Controls.Add(this.btnCharacterPrevious);
            this.gpCharacterNavigate.Controls.Add(this.btnCharacterNext);
            this.gpCharacterNavigate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpCharacterNavigate.Location = new System.Drawing.Point(431, 428);
            this.gpCharacterNavigate.Name = "gpCharacterNavigate";
            this.gpCharacterNavigate.Size = new System.Drawing.Size(510, 98);
            this.gpCharacterNavigate.TabIndex = 21;
            this.gpCharacterNavigate.TabStop = false;
            this.gpCharacterNavigate.Text = "NAVIGATE TO";
            // 
            // btnCharacterFirst
            // 
            this.btnCharacterFirst.Enabled = false;
            this.btnCharacterFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCharacterFirst.Location = new System.Drawing.Point(264, 38);
            this.btnCharacterFirst.Name = "btnCharacterFirst";
            this.btnCharacterFirst.Size = new System.Drawing.Size(103, 41);
            this.btnCharacterFirst.TabIndex = 0;
            this.btnCharacterFirst.Text = "FIRST";
            this.btnCharacterFirst.UseVisualStyleBackColor = true;
            this.btnCharacterFirst.Click += new System.EventHandler(this.btnCharacterFirst_Click);
            // 
            // btnCharacterLast
            // 
            this.btnCharacterLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCharacterLast.Location = new System.Drawing.Point(383, 38);
            this.btnCharacterLast.Name = "btnCharacterLast";
            this.btnCharacterLast.Size = new System.Drawing.Size(103, 41);
            this.btnCharacterLast.TabIndex = 1;
            this.btnCharacterLast.Text = "LAST";
            this.btnCharacterLast.UseVisualStyleBackColor = true;
            this.btnCharacterLast.Click += new System.EventHandler(this.btnCharacterLast_Click);
            // 
            // btnCharacterPrevious
            // 
            this.btnCharacterPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCharacterPrevious.Location = new System.Drawing.Point(26, 38);
            this.btnCharacterPrevious.Name = "btnCharacterPrevious";
            this.btnCharacterPrevious.Size = new System.Drawing.Size(103, 41);
            this.btnCharacterPrevious.TabIndex = 3;
            this.btnCharacterPrevious.Text = "PREVIOUS";
            this.btnCharacterPrevious.UseVisualStyleBackColor = true;
            this.btnCharacterPrevious.Click += new System.EventHandler(this.btnCharacterPrevious_Click);
            // 
            // btnCharacterNext
            // 
            this.btnCharacterNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCharacterNext.Location = new System.Drawing.Point(144, 38);
            this.btnCharacterNext.Name = "btnCharacterNext";
            this.btnCharacterNext.Size = new System.Drawing.Size(103, 41);
            this.btnCharacterNext.TabIndex = 2;
            this.btnCharacterNext.Text = "NEXT";
            this.btnCharacterNext.UseVisualStyleBackColor = true;
            this.btnCharacterNext.Click += new System.EventHandler(this.btnCharacterNext_Click);
            // 
            // gpCharacterExtraOption
            // 
            this.gpCharacterExtraOption.Controls.Add(this.btnSearchCharacter);
            this.gpCharacterExtraOption.Controls.Add(this.btnListCharacters);
            this.gpCharacterExtraOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpCharacterExtraOption.Location = new System.Drawing.Point(431, 313);
            this.gpCharacterExtraOption.Name = "gpCharacterExtraOption";
            this.gpCharacterExtraOption.Size = new System.Drawing.Size(510, 98);
            this.gpCharacterExtraOption.TabIndex = 22;
            this.gpCharacterExtraOption.TabStop = false;
            this.gpCharacterExtraOption.Text = "LIST AND SEARCH";
            // 
            // btnSearchCharacter
            // 
            this.btnSearchCharacter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCharacter.Location = new System.Drawing.Point(265, 34);
            this.btnSearchCharacter.Name = "btnSearchCharacter";
            this.btnSearchCharacter.Size = new System.Drawing.Size(221, 46);
            this.btnSearchCharacter.TabIndex = 1;
            this.btnSearchCharacter.Text = "SEARCH BY NAME";
            this.btnSearchCharacter.UseVisualStyleBackColor = true;
            this.btnSearchCharacter.Click += new System.EventHandler(this.btnSearchCharacter_Click);
            // 
            // btnListCharacters
            // 
            this.btnListCharacters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListCharacters.Location = new System.Drawing.Point(26, 34);
            this.btnListCharacters.Name = "btnListCharacters";
            this.btnListCharacters.Size = new System.Drawing.Size(221, 46);
            this.btnListCharacters.TabIndex = 0;
            this.btnListCharacters.Text = "LIST OF CHARACTERS";
            this.btnListCharacters.UseVisualStyleBackColor = true;
            this.btnListCharacters.Click += new System.EventHandler(this.btnListCharacters_Click);
            // 
            // gpCharacterNewRegistry
            // 
            this.gpCharacterNewRegistry.Controls.Add(this.btnCharacterCancelAddRegistry);
            this.gpCharacterNewRegistry.Controls.Add(this.btnCharacterClear);
            this.gpCharacterNewRegistry.Controls.Add(this.btnCharacterSave);
            this.gpCharacterNewRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpCharacterNewRegistry.Location = new System.Drawing.Point(431, 135);
            this.gpCharacterNewRegistry.Name = "gpCharacterNewRegistry";
            this.gpCharacterNewRegistry.Size = new System.Drawing.Size(510, 163);
            this.gpCharacterNewRegistry.TabIndex = 23;
            this.gpCharacterNewRegistry.TabStop = false;
            this.gpCharacterNewRegistry.Text = "NEW REGISTRY";
            // 
            // btnCharacterCancelAddRegistry
            // 
            this.btnCharacterCancelAddRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCharacterCancelAddRegistry.Location = new System.Drawing.Point(265, 32);
            this.btnCharacterCancelAddRegistry.Name = "btnCharacterCancelAddRegistry";
            this.btnCharacterCancelAddRegistry.Size = new System.Drawing.Size(221, 41);
            this.btnCharacterCancelAddRegistry.TabIndex = 2;
            this.btnCharacterCancelAddRegistry.Text = "CANCEL REGISTRY ADDITION";
            this.btnCharacterCancelAddRegistry.UseVisualStyleBackColor = true;
            this.btnCharacterCancelAddRegistry.Click += new System.EventHandler(this.btnCharacterCancelAddRegistry_Click);
            // 
            // btnCharacterClear
            // 
            this.btnCharacterClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCharacterClear.Location = new System.Drawing.Point(26, 32);
            this.btnCharacterClear.Name = "btnCharacterClear";
            this.btnCharacterClear.Size = new System.Drawing.Size(221, 41);
            this.btnCharacterClear.TabIndex = 0;
            this.btnCharacterClear.Text = "CLEAR DATA";
            this.btnCharacterClear.UseVisualStyleBackColor = true;
            this.btnCharacterClear.Click += new System.EventHandler(this.btnCharacterClear_Click);
            // 
            // btnCharacterSave
            // 
            this.btnCharacterSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCharacterSave.Location = new System.Drawing.Point(26, 100);
            this.btnCharacterSave.Name = "btnCharacterSave";
            this.btnCharacterSave.Size = new System.Drawing.Size(460, 41);
            this.btnCharacterSave.TabIndex = 1;
            this.btnCharacterSave.Text = "SAVE AS NEW";
            this.btnCharacterSave.UseVisualStyleBackColor = true;
            this.btnCharacterSave.Click += new System.EventHandler(this.btnCharacterSave_Click);
            // 
            // fAdminCharactersManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 538);
            this.Controls.Add(this.gpCharacterNewRegistry);
            this.Controls.Add(this.gpCharacterExtraOption);
            this.Controls.Add(this.gpCharacterNavigate);
            this.Controls.Add(this.gpUpdateDeleteSetImage);
            this.Controls.Add(this.gbCharacterData);
            this.Name = "fAdminCharactersManagement";
            this.Text = "Characters Management";
            this.Load += new System.EventHandler(this.fAdminCharactersManagement_Load);
            this.gbCharacterData.ResumeLayout(false);
            this.gbCharacterData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacter)).EndInit();
            this.gpUpdateDeleteSetImage.ResumeLayout(false);
            this.gpCharacterNavigate.ResumeLayout(false);
            this.gpCharacterExtraOption.ResumeLayout(false);
            this.gpCharacterNewRegistry.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbCharacterData;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.TextBox txtbCharacterID;
        private System.Windows.Forms.TextBox txtbCharacterName;
        private System.Windows.Forms.Label lblCharacterName;
        private System.Windows.Forms.Label lblCharacterID;
        private System.Windows.Forms.Label lblCharacterImage;
        private System.Windows.Forms.PictureBox pbCharacter;
        private System.Windows.Forms.GroupBox gpUpdateDeleteSetImage;
        private System.Windows.Forms.Button btnCharacterSetImage;
        private System.Windows.Forms.Button btnCharacterUpdate;
        private System.Windows.Forms.Button btnCharacterDelete;
        private System.Windows.Forms.GroupBox gpCharacterNavigate;
        private System.Windows.Forms.Button btnCharacterPrevious;
        private System.Windows.Forms.Button btnCharacterNext;
        private System.Windows.Forms.Button btnCharacterLast;
        private System.Windows.Forms.Button btnCharacterFirst;
        private System.Windows.Forms.GroupBox gpCharacterExtraOption;
        private System.Windows.Forms.Button btnListCharacters;
        private System.Windows.Forms.Button btnSearchCharacter;
        private System.Windows.Forms.GroupBox gpCharacterNewRegistry;
        private System.Windows.Forms.Button btnCharacterCancelAddRegistry;
        private System.Windows.Forms.Button btnCharacterClear;
        private System.Windows.Forms.Button btnCharacterSave;
    }
}