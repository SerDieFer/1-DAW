namespace Exercise_3
{
    partial class fUserOptions
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
            this.gpUpdateEmailPassword = new System.Windows.Forms.GroupBox();
            this.btnUpdateEmail = new System.Windows.Forms.Button();
            this.btnUpdatePassword = new System.Windows.Forms.Button();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.txtbUserEmail = new System.Windows.Forms.TextBox();
            this.txtbUserPassword = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.chkbVisible = new System.Windows.Forms.CheckBox();
            this.gpUpdateEmailPassword.SuspendLayout();
            this.gbData.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpUpdateEmailPassword
            // 
            this.gpUpdateEmailPassword.Controls.Add(this.btnUpdateEmail);
            this.gpUpdateEmailPassword.Controls.Add(this.btnUpdatePassword);
            this.gpUpdateEmailPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpUpdateEmailPassword.Location = new System.Drawing.Point(12, 156);
            this.gpUpdateEmailPassword.Name = "gpUpdateEmailPassword";
            this.gpUpdateEmailPassword.Size = new System.Drawing.Size(397, 98);
            this.gpUpdateEmailPassword.TabIndex = 20;
            this.gpUpdateEmailPassword.TabStop = false;
            this.gpUpdateEmailPassword.Text = "UPDATE PASSWORD OR EMAIL";
            // 
            // btnUpdateEmail
            // 
            this.btnUpdateEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateEmail.Location = new System.Drawing.Point(197, 37);
            this.btnUpdateEmail.Name = "btnUpdateEmail";
            this.btnUpdateEmail.Size = new System.Drawing.Size(163, 41);
            this.btnUpdateEmail.TabIndex = 1;
            this.btnUpdateEmail.Text = "UPDATE EMAIL";
            this.btnUpdateEmail.UseVisualStyleBackColor = true;
            this.btnUpdateEmail.Click += new System.EventHandler(this.btnUpdateEmail_Click);
            // 
            // btnUpdatePassword
            // 
            this.btnUpdatePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePassword.Location = new System.Drawing.Point(21, 37);
            this.btnUpdatePassword.Name = "btnUpdatePassword";
            this.btnUpdatePassword.Size = new System.Drawing.Size(154, 41);
            this.btnUpdatePassword.TabIndex = 0;
            this.btnUpdatePassword.Text = "UPDATE PASSWORD";
            this.btnUpdatePassword.UseVisualStyleBackColor = true;
            this.btnUpdatePassword.Click += new System.EventHandler(this.btnUpdatePassword_Click);
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.chkbVisible);
            this.gbData.Controls.Add(this.txtbUserEmail);
            this.gbData.Controls.Add(this.txtbUserPassword);
            this.gbData.Controls.Add(this.lblEmail);
            this.gbData.Controls.Add(this.lblPassword);
            this.gbData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbData.Location = new System.Drawing.Point(12, 12);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(397, 127);
            this.gbData.TabIndex = 19;
            this.gbData.TabStop = false;
            this.gbData.Text = "DATA";
            // 
            // txtbUserEmail
            // 
            this.txtbUserEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbUserEmail.Location = new System.Drawing.Point(143, 25);
            this.txtbUserEmail.Name = "txtbUserEmail";
            this.txtbUserEmail.Size = new System.Drawing.Size(217, 22);
            this.txtbUserEmail.TabIndex = 7;
            this.txtbUserEmail.TextChanged += new System.EventHandler(this.txtbUserEmail_TextChanged);
            // 
            // txtbUserPassword
            // 
            this.txtbUserPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbUserPassword.Location = new System.Drawing.Point(143, 67);
            this.txtbUserPassword.Name = "txtbUserPassword";
            this.txtbUserPassword.Size = new System.Drawing.Size(217, 22);
            this.txtbUserPassword.TabIndex = 6;
            this.txtbUserPassword.TextChanged += new System.EventHandler(this.txtbUserPassword_TextChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(13, 28);
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
            this.lblPassword.Location = new System.Drawing.Point(13, 70);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(89, 16);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "PASSWORD:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkbVisible
            // 
            this.chkbVisible.AutoSize = true;
            this.chkbVisible.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbVisible.Location = new System.Drawing.Point(249, 95);
            this.chkbVisible.Name = "chkbVisible";
            this.chkbVisible.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkbVisible.Size = new System.Drawing.Size(111, 17);
            this.chkbVisible.TabIndex = 10;
            this.chkbVisible.Text = "Password Visibility";
            this.chkbVisible.UseVisualStyleBackColor = true;
            this.chkbVisible.CheckedChanged += new System.EventHandler(this.chkbVisible_CheckedChanged);
            // 
            // fUserOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 266);
            this.Controls.Add(this.gpUpdateEmailPassword);
            this.Controls.Add(this.gbData);
            this.Name = "fUserOptions";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.fUserOptions_Load);
            this.gpUpdateEmailPassword.ResumeLayout(false);
            this.gbData.ResumeLayout(false);
            this.gbData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpUpdateEmailPassword;
        private System.Windows.Forms.Button btnUpdatePassword;
        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.TextBox txtbUserEmail;
        private System.Windows.Forms.TextBox txtbUserPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnUpdateEmail;
        private System.Windows.Forms.CheckBox chkbVisible;
    }
}