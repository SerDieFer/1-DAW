namespace Exercise_4
{
    partial class fLogin
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
            this.lblUserID = new System.Windows.Forms.Label();
            this.txtbUserID = new System.Windows.Forms.TextBox();
            this.txtbPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.gpLogin = new System.Windows.Forms.GroupBox();
            this.chkbVisible = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.gpLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(18, 34);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(83, 20);
            this.lblUserID.TabIndex = 0;
            this.lblUserID.Text = "USER ID";
            // 
            // txtbUserID
            // 
            this.txtbUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbUserID.Location = new System.Drawing.Point(22, 57);
            this.txtbUserID.Name = "txtbUserID";
            this.txtbUserID.Size = new System.Drawing.Size(244, 26);
            this.txtbUserID.TabIndex = 8;
            // 
            // txtbPassword
            // 
            this.txtbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbPassword.Location = new System.Drawing.Point(22, 125);
            this.txtbPassword.Name = "txtbPassword";
            this.txtbPassword.Size = new System.Drawing.Size(244, 26);
            this.txtbPassword.TabIndex = 3;
            this.txtbPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(18, 102);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(111, 20);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "PASSWORD";
            // 
            // gpLogin
            // 
            this.gpLogin.Controls.Add(this.chkbVisible);
            this.gpLogin.Controls.Add(this.btnLogin);
            this.gpLogin.Controls.Add(this.lblUserID);
            this.gpLogin.Controls.Add(this.txtbPassword);
            this.gpLogin.Controls.Add(this.txtbUserID);
            this.gpLogin.Controls.Add(this.lblPassword);
            this.gpLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpLogin.Location = new System.Drawing.Point(12, 12);
            this.gpLogin.Name = "gpLogin";
            this.gpLogin.Size = new System.Drawing.Size(295, 252);
            this.gpLogin.TabIndex = 4;
            this.gpLogin.TabStop = false;
            // 
            // chkbVisible
            // 
            this.chkbVisible.AutoSize = true;
            this.chkbVisible.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbVisible.Location = new System.Drawing.Point(155, 157);
            this.chkbVisible.Name = "chkbVisible";
            this.chkbVisible.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkbVisible.Size = new System.Drawing.Size(111, 17);
            this.chkbVisible.TabIndex = 9;
            this.chkbVisible.Text = "Password Visibility";
            this.chkbVisible.UseVisualStyleBackColor = true;
            this.chkbVisible.CheckedChanged += new System.EventHandler(this.chkbVisible_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(22, 195);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(244, 31);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // fLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 282);
            this.Controls.Add(this.gpLogin);
            this.Name = "fLogin";
            this.Text = "HighSchool Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fLogin_FormClosing);
            this.Load += new System.EventHandler(this.fLogin_Load);
            this.gpLogin.ResumeLayout(false);
            this.gpLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.TextBox txtbUserID;
        private System.Windows.Forms.TextBox txtbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.GroupBox gpLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox chkbVisible;
    }
}