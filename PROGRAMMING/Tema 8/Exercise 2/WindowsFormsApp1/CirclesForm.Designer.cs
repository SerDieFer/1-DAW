namespace Exercise_2
{
    partial class CirclesForm
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
            this.gpCircleData = new System.Windows.Forms.GroupBox();
            this.btnCreateCircle = new System.Windows.Forms.Button();
            this.txtbCircleRadius = new System.Windows.Forms.TextBox();
            this.txtbColor = new System.Windows.Forms.TextBox();
            this.txtbPositionY = new System.Windows.Forms.TextBox();
            this.txtbPositionX = new System.Windows.Forms.TextBox();
            this.lblCircleRadius = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblPositionY = new System.Windows.Forms.Label();
            this.lblPositionX = new System.Windows.Forms.Label();
            this.gpCircleData.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpCircleData
            // 
            this.gpCircleData.Controls.Add(this.btnCreateCircle);
            this.gpCircleData.Controls.Add(this.txtbCircleRadius);
            this.gpCircleData.Controls.Add(this.txtbColor);
            this.gpCircleData.Controls.Add(this.txtbPositionY);
            this.gpCircleData.Controls.Add(this.txtbPositionX);
            this.gpCircleData.Controls.Add(this.lblCircleRadius);
            this.gpCircleData.Controls.Add(this.lblColor);
            this.gpCircleData.Controls.Add(this.lblPositionY);
            this.gpCircleData.Controls.Add(this.lblPositionX);
            this.gpCircleData.Location = new System.Drawing.Point(12, 12);
            this.gpCircleData.Name = "gpCircleData";
            this.gpCircleData.Size = new System.Drawing.Size(210, 227);
            this.gpCircleData.TabIndex = 1;
            this.gpCircleData.TabStop = false;
            this.gpCircleData.Text = "Introduce Circle Data";
            // 
            // btnCreateCircle
            // 
            this.btnCreateCircle.Location = new System.Drawing.Point(26, 171);
            this.btnCreateCircle.Name = "btnCreateCircle";
            this.btnCreateCircle.Size = new System.Drawing.Size(158, 36);
            this.btnCreateCircle.TabIndex = 8;
            this.btnCreateCircle.Text = "Create Circle";
            this.btnCreateCircle.UseVisualStyleBackColor = true;
            this.btnCreateCircle.Click += new System.EventHandler(this.btnCreateCircle_Click);
            // 
            // txtbCircleRadius
            // 
            this.txtbCircleRadius.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCircleRadius.Location = new System.Drawing.Point(116, 129);
            this.txtbCircleRadius.Name = "txtbCircleRadius";
            this.txtbCircleRadius.Size = new System.Drawing.Size(68, 26);
            this.txtbCircleRadius.TabIndex = 7;
            // 
            // txtbColor
            // 
            this.txtbColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbColor.Location = new System.Drawing.Point(116, 94);
            this.txtbColor.Name = "txtbColor";
            this.txtbColor.Size = new System.Drawing.Size(68, 26);
            this.txtbColor.TabIndex = 6;
            // 
            // txtbPositionY
            // 
            this.txtbPositionY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbPositionY.Location = new System.Drawing.Point(116, 60);
            this.txtbPositionY.Name = "txtbPositionY";
            this.txtbPositionY.Size = new System.Drawing.Size(68, 26);
            this.txtbPositionY.TabIndex = 5;
            // 
            // txtbPositionX
            // 
            this.txtbPositionX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbPositionX.Location = new System.Drawing.Point(116, 27);
            this.txtbPositionX.Name = "txtbPositionX";
            this.txtbPositionX.Size = new System.Drawing.Size(68, 26);
            this.txtbPositionX.TabIndex = 4;
            // 
            // lblCircleRadius
            // 
            this.lblCircleRadius.AutoSize = true;
            this.lblCircleRadius.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCircleRadius.Location = new System.Drawing.Point(45, 132);
            this.lblCircleRadius.Name = "lblCircleRadius";
            this.lblCircleRadius.Size = new System.Drawing.Size(63, 20);
            this.lblCircleRadius.TabIndex = 3;
            this.lblCircleRadius.Text = "Radius:";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(56, 97);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(54, 20);
            this.lblColor.TabIndex = 2;
            this.lblColor.Text = "Color: ";
            // 
            // lblPositionY
            // 
            this.lblPositionY.AutoSize = true;
            this.lblPositionY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPositionY.Location = new System.Drawing.Point(22, 63);
            this.lblPositionY.Name = "lblPositionY";
            this.lblPositionY.Size = new System.Drawing.Size(88, 20);
            this.lblPositionY.TabIndex = 1;
            this.lblPositionY.Text = "Position Y: ";
            // 
            // lblPositionX
            // 
            this.lblPositionX.AutoSize = true;
            this.lblPositionX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPositionX.Location = new System.Drawing.Point(22, 30);
            this.lblPositionX.Name = "lblPositionX";
            this.lblPositionX.Size = new System.Drawing.Size(88, 20);
            this.lblPositionX.TabIndex = 0;
            this.lblPositionX.Text = "Position X: ";
            // 
            // CirclesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 254);
            this.Controls.Add(this.gpCircleData);
            this.Name = "CirclesForm";
            this.Text = "CirclesForm";
            this.Load += new System.EventHandler(this.Circles_Load);
            this.gpCircleData.ResumeLayout(false);
            this.gpCircleData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpCircleData;
        private System.Windows.Forms.Button btnCreateCircle;
        private System.Windows.Forms.TextBox txtbCircleRadius;
        private System.Windows.Forms.TextBox txtbColor;
        private System.Windows.Forms.TextBox txtbPositionY;
        private System.Windows.Forms.TextBox txtbPositionX;
        private System.Windows.Forms.Label lblCircleRadius;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblPositionY;
        private System.Windows.Forms.Label lblPositionX;
    }
}