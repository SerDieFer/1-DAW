﻿namespace Exercise_4
{
    partial class fAlumnOptions
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
            this.gpUpdateData = new System.Windows.Forms.GroupBox();
            this.btnUpdatePhone = new System.Windows.Forms.Button();
            this.btnUpdateAdress = new System.Windows.Forms.Button();
            this.btnUpdatePassword = new System.Windows.Forms.Button();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.txtbPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtbAdress = new System.Windows.Forms.TextBox();
            this.lblAdress = new System.Windows.Forms.Label();
            this.chkbVisible = new System.Windows.Forms.CheckBox();
            this.txtbAlumnPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.gpUpdateData.SuspendLayout();
            this.gbData.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpUpdateData
            // 
            this.gpUpdateData.Controls.Add(this.btnUpdatePhone);
            this.gpUpdateData.Controls.Add(this.btnUpdateAdress);
            this.gpUpdateData.Controls.Add(this.btnUpdatePassword);
            this.gpUpdateData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpUpdateData.Location = new System.Drawing.Point(12, 205);
            this.gpUpdateData.Name = "gpUpdateData";
            this.gpUpdateData.Size = new System.Drawing.Size(473, 163);
            this.gpUpdateData.TabIndex = 20;
            this.gpUpdateData.TabStop = false;
            this.gpUpdateData.Text = "UPDATE PASSWORD, PHONE OR ADRESS";
            // 
            // btnUpdatePhone
            // 
            this.btnUpdatePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePhone.Location = new System.Drawing.Point(250, 37);
            this.btnUpdatePhone.Name = "btnUpdatePhone";
            this.btnUpdatePhone.Size = new System.Drawing.Size(206, 41);
            this.btnUpdatePhone.TabIndex = 3;
            this.btnUpdatePhone.Text = "UPDATE PHONE";
            this.btnUpdatePhone.UseVisualStyleBackColor = true;
            this.btnUpdatePhone.Click += new System.EventHandler(this.btnUpdatePhone_Click);
            // 
            // btnUpdateAdress
            // 
            this.btnUpdateAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateAdress.Location = new System.Drawing.Point(16, 37);
            this.btnUpdateAdress.Name = "btnUpdateAdress";
            this.btnUpdateAdress.Size = new System.Drawing.Size(206, 41);
            this.btnUpdateAdress.TabIndex = 2;
            this.btnUpdateAdress.Text = "UPDATE ADRESS";
            this.btnUpdateAdress.UseVisualStyleBackColor = true;
            this.btnUpdateAdress.Click += new System.EventHandler(this.btnUpdateAdress_Click);
            // 
            // btnUpdatePassword
            // 
            this.btnUpdatePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePassword.Location = new System.Drawing.Point(16, 102);
            this.btnUpdatePassword.Name = "btnUpdatePassword";
            this.btnUpdatePassword.Size = new System.Drawing.Size(440, 41);
            this.btnUpdatePassword.TabIndex = 0;
            this.btnUpdatePassword.Text = "UPDATE PASSWORD";
            this.btnUpdatePassword.UseVisualStyleBackColor = true;
            this.btnUpdatePassword.Click += new System.EventHandler(this.btnUpdatePassword_Click);
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.txtbPhone);
            this.gbData.Controls.Add(this.lblPhone);
            this.gbData.Controls.Add(this.txtbAdress);
            this.gbData.Controls.Add(this.lblAdress);
            this.gbData.Controls.Add(this.chkbVisible);
            this.gbData.Controls.Add(this.txtbAlumnPassword);
            this.gbData.Controls.Add(this.lblPassword);
            this.gbData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbData.Location = new System.Drawing.Point(12, 12);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(473, 171);
            this.gbData.TabIndex = 19;
            this.gbData.TabStop = false;
            this.gbData.Text = "DATA";
            // 
            // txtbPhone
            // 
            this.txtbPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbPhone.Location = new System.Drawing.Point(143, 68);
            this.txtbPhone.Name = "txtbPhone";
            this.txtbPhone.Size = new System.Drawing.Size(313, 22);
            this.txtbPhone.TabIndex = 14;
            this.txtbPhone.TextChanged += new System.EventHandler(this.txtbPhone_TextChanged);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(13, 71);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(58, 16);
            this.lblPhone.TabIndex = 13;
            this.lblPhone.Text = "PHONE:";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtbAdress
            // 
            this.txtbAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbAdress.Location = new System.Drawing.Point(143, 27);
            this.txtbAdress.Name = "txtbAdress";
            this.txtbAdress.Size = new System.Drawing.Size(313, 22);
            this.txtbAdress.TabIndex = 12;
            this.txtbAdress.TextChanged += new System.EventHandler(this.txtbAdress_TextChanged);
            // 
            // lblAdress
            // 
            this.lblAdress.AutoSize = true;
            this.lblAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdress.Location = new System.Drawing.Point(13, 30);
            this.lblAdress.Name = "lblAdress";
            this.lblAdress.Size = new System.Drawing.Size(66, 16);
            this.lblAdress.TabIndex = 11;
            this.lblAdress.Text = "ADRESS:";
            this.lblAdress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkbVisible
            // 
            this.chkbVisible.AutoSize = true;
            this.chkbVisible.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbVisible.Location = new System.Drawing.Point(345, 138);
            this.chkbVisible.Name = "chkbVisible";
            this.chkbVisible.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkbVisible.Size = new System.Drawing.Size(111, 17);
            this.chkbVisible.TabIndex = 10;
            this.chkbVisible.Text = "Password Visibility";
            this.chkbVisible.UseVisualStyleBackColor = true;
            this.chkbVisible.CheckedChanged += new System.EventHandler(this.chkbVisible_CheckedChanged);
            // 
            // txtbAlumnPassword
            // 
            this.txtbAlumnPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbAlumnPassword.Location = new System.Drawing.Point(143, 110);
            this.txtbAlumnPassword.Name = "txtbAlumnPassword";
            this.txtbAlumnPassword.Size = new System.Drawing.Size(313, 22);
            this.txtbAlumnPassword.TabIndex = 6;
            this.txtbAlumnPassword.TextChanged += new System.EventHandler(this.txtbAlumnPassword_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(13, 113);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(89, 16);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "PASSWORD:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fAlumnOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 387);
            this.Controls.Add(this.gpUpdateData);
            this.Controls.Add(this.gbData);
            this.Name = "fAlumnOptions";
            this.Text = "Alumn Options";
            this.Load += new System.EventHandler(this.fAlumnOptions_Load);
            this.gpUpdateData.ResumeLayout(false);
            this.gbData.ResumeLayout(false);
            this.gbData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpUpdateData;
        private System.Windows.Forms.Button btnUpdatePassword;
        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.TextBox txtbAlumnPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.CheckBox chkbVisible;
        private System.Windows.Forms.TextBox txtbAdress;
        private System.Windows.Forms.Label lblAdress;
        private System.Windows.Forms.Button btnUpdateAdress;
        private System.Windows.Forms.TextBox txtbPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Button btnUpdatePhone;
    }
}