namespace Exercise_3
{
    partial class fAdmin
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
            this.btnAdminUsers = new System.Windows.Forms.Button();
            this.gbAdmin = new System.Windows.Forms.GroupBox();
            this.btnAdminCharacters = new System.Windows.Forms.Button();
            this.gbAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdminUsers
            // 
            this.btnAdminUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminUsers.Location = new System.Drawing.Point(19, 19);
            this.btnAdminUsers.Name = "btnAdminUsers";
            this.btnAdminUsers.Size = new System.Drawing.Size(252, 41);
            this.btnAdminUsers.TabIndex = 0;
            this.btnAdminUsers.Text = "MANAGE USERS";
            this.btnAdminUsers.UseVisualStyleBackColor = true;
            this.btnAdminUsers.Click += new System.EventHandler(this.btnAdminUsers_Click);
            // 
            // gbAdmin
            // 
            this.gbAdmin.Controls.Add(this.btnAdminCharacters);
            this.gbAdmin.Controls.Add(this.btnAdminUsers);
            this.gbAdmin.Location = new System.Drawing.Point(12, 12);
            this.gbAdmin.Name = "gbAdmin";
            this.gbAdmin.Size = new System.Drawing.Size(285, 140);
            this.gbAdmin.TabIndex = 1;
            this.gbAdmin.TabStop = false;
            // 
            // btnAdminCharacters
            // 
            this.btnAdminCharacters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminCharacters.Location = new System.Drawing.Point(19, 77);
            this.btnAdminCharacters.Name = "btnAdminCharacters";
            this.btnAdminCharacters.Size = new System.Drawing.Size(252, 41);
            this.btnAdminCharacters.TabIndex = 1;
            this.btnAdminCharacters.Text = "MANAGE CHARACTERS";
            this.btnAdminCharacters.UseVisualStyleBackColor = true;
            this.btnAdminCharacters.Click += new System.EventHandler(this.btnAdminCharacters_Click);
            // 
            // fAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 165);
            this.Controls.Add(this.gbAdmin);
            this.Name = "fAdmin";
            this.Text = "Administrator";
            this.Load += new System.EventHandler(this.fAdmin_Load);
            this.gbAdmin.ResumeLayout(false);
                // THIS IS AN EVENT WHEN ITS CLOSED
                this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fAdmin_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdminUsers;
        private System.Windows.Forms.GroupBox gbAdmin;
        private System.Windows.Forms.Button btnAdminCharacters;
    }
}