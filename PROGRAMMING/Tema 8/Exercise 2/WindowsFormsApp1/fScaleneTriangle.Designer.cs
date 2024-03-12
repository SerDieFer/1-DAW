namespace WindowsFormsApp1
{
    partial class fScaleneTriangle
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
            this.gpScaleneTriangleData = new System.Windows.Forms.GroupBox();
            this.txtbScaleneTriangleSideA = new System.Windows.Forms.TextBox();
            this.lblScaleneTriangleSideA = new System.Windows.Forms.Label();
            this.btnCreateScaleneTriangle = new System.Windows.Forms.Button();
            this.txtbColor = new System.Windows.Forms.TextBox();
            this.txtbPositionY = new System.Windows.Forms.TextBox();
            this.txtbPositionX = new System.Windows.Forms.TextBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblPositionY = new System.Windows.Forms.Label();
            this.lblPositionX = new System.Windows.Forms.Label();
            this.txtbScaleneTriangleSideB = new System.Windows.Forms.TextBox();
            this.lblScaleneTriangleSideB = new System.Windows.Forms.Label();
            this.txtbScaleneTriangleSideC = new System.Windows.Forms.TextBox();
            this.lblScaleneTriangleSideC = new System.Windows.Forms.Label();
            this.gpScaleneTriangleData.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpScaleneTriangleData
            // 
            this.gpScaleneTriangleData.Controls.Add(this.txtbScaleneTriangleSideC);
            this.gpScaleneTriangleData.Controls.Add(this.lblScaleneTriangleSideC);
            this.gpScaleneTriangleData.Controls.Add(this.txtbScaleneTriangleSideB);
            this.gpScaleneTriangleData.Controls.Add(this.lblScaleneTriangleSideB);
            this.gpScaleneTriangleData.Controls.Add(this.txtbScaleneTriangleSideA);
            this.gpScaleneTriangleData.Controls.Add(this.lblScaleneTriangleSideA);
            this.gpScaleneTriangleData.Controls.Add(this.btnCreateScaleneTriangle);
            this.gpScaleneTriangleData.Controls.Add(this.txtbColor);
            this.gpScaleneTriangleData.Controls.Add(this.txtbPositionY);
            this.gpScaleneTriangleData.Controls.Add(this.txtbPositionX);
            this.gpScaleneTriangleData.Controls.Add(this.lblColor);
            this.gpScaleneTriangleData.Controls.Add(this.lblPositionY);
            this.gpScaleneTriangleData.Controls.Add(this.lblPositionX);
            this.gpScaleneTriangleData.Location = new System.Drawing.Point(12, 12);
            this.gpScaleneTriangleData.Name = "gpScaleneTriangleData";
            this.gpScaleneTriangleData.Size = new System.Drawing.Size(267, 310);
            this.gpScaleneTriangleData.TabIndex = 4;
            this.gpScaleneTriangleData.TabStop = false;
            this.gpScaleneTriangleData.Text = "Introduce Scalene Triangle Data";
            // 
            // txtbScaleneTriangleSideA
            // 
            this.txtbScaleneTriangleSideA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbScaleneTriangleSideA.Location = new System.Drawing.Point(117, 130);
            this.txtbScaleneTriangleSideA.Name = "txtbScaleneTriangleSideA";
            this.txtbScaleneTriangleSideA.Size = new System.Drawing.Size(125, 26);
            this.txtbScaleneTriangleSideA.TabIndex = 10;
            // 
            // lblScaleneTriangleSideA
            // 
            this.lblScaleneTriangleSideA.AutoSize = true;
            this.lblScaleneTriangleSideA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScaleneTriangleSideA.Location = new System.Drawing.Point(46, 132);
            this.lblScaleneTriangleSideA.Name = "lblScaleneTriangleSideA";
            this.lblScaleneTriangleSideA.Size = new System.Drawing.Size(60, 20);
            this.lblScaleneTriangleSideA.TabIndex = 9;
            this.lblScaleneTriangleSideA.Text = "Side A:";
            // 
            // btnCreateScaleneTriangle
            // 
            this.btnCreateScaleneTriangle.Location = new System.Drawing.Point(26, 246);
            this.btnCreateScaleneTriangle.Name = "btnCreateScaleneTriangle";
            this.btnCreateScaleneTriangle.Size = new System.Drawing.Size(215, 36);
            this.btnCreateScaleneTriangle.TabIndex = 8;
            this.btnCreateScaleneTriangle.Text = "Create Scalene Triangle";
            this.btnCreateScaleneTriangle.UseVisualStyleBackColor = true;
            this.btnCreateScaleneTriangle.Click += new System.EventHandler(this.btnCreateScaleneTriangle_Click);
            // 
            // txtbColor
            // 
            this.txtbColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbColor.Location = new System.Drawing.Point(116, 95);
            this.txtbColor.Name = "txtbColor";
            this.txtbColor.Size = new System.Drawing.Size(125, 26);
            this.txtbColor.TabIndex = 6;
            // 
            // txtbPositionY
            // 
            this.txtbPositionY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbPositionY.Location = new System.Drawing.Point(116, 60);
            this.txtbPositionY.Name = "txtbPositionY";
            this.txtbPositionY.Size = new System.Drawing.Size(125, 26);
            this.txtbPositionY.TabIndex = 5;
            // 
            // txtbPositionX
            // 
            this.txtbPositionX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbPositionX.Location = new System.Drawing.Point(116, 27);
            this.txtbPositionX.Name = "txtbPositionX";
            this.txtbPositionX.Size = new System.Drawing.Size(125, 26);
            this.txtbPositionX.TabIndex = 4;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(56, 98);
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
            // txtbScaleneTriangleSideB
            // 
            this.txtbScaleneTriangleSideB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbScaleneTriangleSideB.Location = new System.Drawing.Point(116, 164);
            this.txtbScaleneTriangleSideB.Name = "txtbScaleneTriangleSideB";
            this.txtbScaleneTriangleSideB.Size = new System.Drawing.Size(125, 26);
            this.txtbScaleneTriangleSideB.TabIndex = 12;
            // 
            // lblScaleneTriangleSideB
            // 
            this.lblScaleneTriangleSideB.AutoSize = true;
            this.lblScaleneTriangleSideB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScaleneTriangleSideB.Location = new System.Drawing.Point(45, 166);
            this.lblScaleneTriangleSideB.Name = "lblScaleneTriangleSideB";
            this.lblScaleneTriangleSideB.Size = new System.Drawing.Size(60, 20);
            this.lblScaleneTriangleSideB.TabIndex = 11;
            this.lblScaleneTriangleSideB.Text = "Side B:";
            // 
            // txtbScaleneTriangleSideC
            // 
            this.txtbScaleneTriangleSideC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbScaleneTriangleSideC.Location = new System.Drawing.Point(117, 197);
            this.txtbScaleneTriangleSideC.Name = "txtbScaleneTriangleSideC";
            this.txtbScaleneTriangleSideC.Size = new System.Drawing.Size(125, 26);
            this.txtbScaleneTriangleSideC.TabIndex = 14;
            // 
            // lblScaleneTriangleSideC
            // 
            this.lblScaleneTriangleSideC.AutoSize = true;
            this.lblScaleneTriangleSideC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScaleneTriangleSideC.Location = new System.Drawing.Point(46, 199);
            this.lblScaleneTriangleSideC.Name = "lblScaleneTriangleSideC";
            this.lblScaleneTriangleSideC.Size = new System.Drawing.Size(60, 20);
            this.lblScaleneTriangleSideC.TabIndex = 13;
            this.lblScaleneTriangleSideC.Text = "Side C:";
            // 
            // fScaleneTriangle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 344);
            this.Controls.Add(this.gpScaleneTriangleData);
            this.Name = "fScaleneTriangle";
            this.Text = "Scalene Triangles";
            this.Load += new System.EventHandler(this.fScaleneTriangle_Load);
            this.gpScaleneTriangleData.ResumeLayout(false);
            this.gpScaleneTriangleData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpScaleneTriangleData;
        private System.Windows.Forms.TextBox txtbScaleneTriangleSideC;
        private System.Windows.Forms.Label lblScaleneTriangleSideC;
        private System.Windows.Forms.TextBox txtbScaleneTriangleSideB;
        private System.Windows.Forms.Label lblScaleneTriangleSideB;
        private System.Windows.Forms.TextBox txtbScaleneTriangleSideA;
        private System.Windows.Forms.Label lblScaleneTriangleSideA;
        private System.Windows.Forms.Button btnCreateScaleneTriangle;
        private System.Windows.Forms.TextBox txtbColor;
        private System.Windows.Forms.TextBox txtbPositionY;
        private System.Windows.Forms.TextBox txtbPositionX;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblPositionY;
        private System.Windows.Forms.Label lblPositionX;
    }
}