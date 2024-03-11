namespace Exercise_4
{
    partial class EquilateralTriangleForm
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
            this.gpEquilateralTriangleData = new System.Windows.Forms.GroupBox();
            this.btnCreateEquilateralTriangle = new System.Windows.Forms.Button();
            this.txtbEquilateralTriangleSide = new System.Windows.Forms.TextBox();
            this.txtbColor = new System.Windows.Forms.TextBox();
            this.txtbPositionY = new System.Windows.Forms.TextBox();
            this.txtbPositionX = new System.Windows.Forms.TextBox();
            this.lblEquilateralTriangleSide = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblPositionY = new System.Windows.Forms.Label();
            this.lblPositionX = new System.Windows.Forms.Label();
            this.gpEquilateralTriangleData.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpEquilateralTriangleData
            // 
            this.gpEquilateralTriangleData.Controls.Add(this.btnCreateEquilateralTriangle);
            this.gpEquilateralTriangleData.Controls.Add(this.txtbEquilateralTriangleSide);
            this.gpEquilateralTriangleData.Controls.Add(this.txtbColor);
            this.gpEquilateralTriangleData.Controls.Add(this.txtbPositionY);
            this.gpEquilateralTriangleData.Controls.Add(this.txtbPositionX);
            this.gpEquilateralTriangleData.Controls.Add(this.lblEquilateralTriangleSide);
            this.gpEquilateralTriangleData.Controls.Add(this.lblColor);
            this.gpEquilateralTriangleData.Controls.Add(this.lblPositionY);
            this.gpEquilateralTriangleData.Controls.Add(this.lblPositionX);
            this.gpEquilateralTriangleData.Location = new System.Drawing.Point(12, 12);
            this.gpEquilateralTriangleData.Name = "gpEquilateralTriangleData";
            this.gpEquilateralTriangleData.Size = new System.Drawing.Size(210, 227);
            this.gpEquilateralTriangleData.TabIndex = 2;
            this.gpEquilateralTriangleData.TabStop = false;
            this.gpEquilateralTriangleData.Text = "Introduce Equilateral Triangle Data";
            // 
            // btnCreateEquilateralTriangle
            // 
            this.btnCreateEquilateralTriangle.Location = new System.Drawing.Point(26, 171);
            this.btnCreateEquilateralTriangle.Name = "btnCreateEquilateralTriangle";
            this.btnCreateEquilateralTriangle.Size = new System.Drawing.Size(158, 36);
            this.btnCreateEquilateralTriangle.TabIndex = 8;
            this.btnCreateEquilateralTriangle.Text = "Create Equilateral Triangle";
            this.btnCreateEquilateralTriangle.UseVisualStyleBackColor = true;
            this.btnCreateEquilateralTriangle.Click += new System.EventHandler(this.btnCreateEquilateralTriangle_Click);
            // 
            // txtbEquilateralTriangleSide
            // 
            this.txtbEquilateralTriangleSide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbEquilateralTriangleSide.Location = new System.Drawing.Point(116, 129);
            this.txtbEquilateralTriangleSide.Name = "txtbEquilateralTriangleSide";
            this.txtbEquilateralTriangleSide.Size = new System.Drawing.Size(68, 26);
            this.txtbEquilateralTriangleSide.TabIndex = 7;
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
            // lblEquilateralTriangleSide
            // 
            this.lblEquilateralTriangleSide.AutoSize = true;
            this.lblEquilateralTriangleSide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquilateralTriangleSide.Location = new System.Drawing.Point(60, 132);
            this.lblEquilateralTriangleSide.Name = "lblEquilateralTriangleSide";
            this.lblEquilateralTriangleSide.Size = new System.Drawing.Size(45, 20);
            this.lblEquilateralTriangleSide.TabIndex = 3;
            this.lblEquilateralTriangleSide.Text = "Side:";
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
            // EquilateralTriangleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 253);
            this.Controls.Add(this.gpEquilateralTriangleData);
            this.Name = "EquilateralTriangleForm";
            this.Text = "EquilateralTriangleForm";
            this.Load += new System.EventHandler(this.EquilateralTriangleForm_Load);
            this.gpEquilateralTriangleData.ResumeLayout(false);
            this.gpEquilateralTriangleData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpEquilateralTriangleData;
        private System.Windows.Forms.Button btnCreateEquilateralTriangle;
        private System.Windows.Forms.TextBox txtbEquilateralTriangleSide;
        private System.Windows.Forms.TextBox txtbColor;
        private System.Windows.Forms.TextBox txtbPositionY;
        private System.Windows.Forms.TextBox txtbPositionX;
        private System.Windows.Forms.Label lblEquilateralTriangleSide;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblPositionY;
        private System.Windows.Forms.Label lblPositionX;
    }
}