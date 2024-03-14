namespace WindowsFormsApp1
{
    partial class fIsoscelesTriangle
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
            this.gpIsoscelesTriangleData = new System.Windows.Forms.GroupBox();
            this.btnCreateIsoscelesTriangle = new System.Windows.Forms.Button();
            this.txtbIsoscelesTriangleSide = new System.Windows.Forms.TextBox();
            this.txtbColor = new System.Windows.Forms.TextBox();
            this.txtbPositionY = new System.Windows.Forms.TextBox();
            this.txtbPositionX = new System.Windows.Forms.TextBox();
            this.lblIsoscelesTriangleSide = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblPositionY = new System.Windows.Forms.Label();
            this.lblPositionX = new System.Windows.Forms.Label();
            this.txtbIsoscelesTriangleBase = new System.Windows.Forms.TextBox();
            this.lblIsoscelesTriangleBase = new System.Windows.Forms.Label();
            this.gpIsoscelesTriangleData.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpIsoscelesTriangleData
            // 
            this.gpIsoscelesTriangleData.Controls.Add(this.txtbIsoscelesTriangleBase);
            this.gpIsoscelesTriangleData.Controls.Add(this.lblIsoscelesTriangleBase);
            this.gpIsoscelesTriangleData.Controls.Add(this.btnCreateIsoscelesTriangle);
            this.gpIsoscelesTriangleData.Controls.Add(this.txtbIsoscelesTriangleSide);
            this.gpIsoscelesTriangleData.Controls.Add(this.txtbColor);
            this.gpIsoscelesTriangleData.Controls.Add(this.txtbPositionY);
            this.gpIsoscelesTriangleData.Controls.Add(this.txtbPositionX);
            this.gpIsoscelesTriangleData.Controls.Add(this.lblIsoscelesTriangleSide);
            this.gpIsoscelesTriangleData.Controls.Add(this.lblColor);
            this.gpIsoscelesTriangleData.Controls.Add(this.lblPositionY);
            this.gpIsoscelesTriangleData.Controls.Add(this.lblPositionX);
            this.gpIsoscelesTriangleData.Location = new System.Drawing.Point(12, 12);
            this.gpIsoscelesTriangleData.Name = "gpIsoscelesTriangleData";
            this.gpIsoscelesTriangleData.Size = new System.Drawing.Size(267, 268);
            this.gpIsoscelesTriangleData.TabIndex = 3;
            this.gpIsoscelesTriangleData.TabStop = false;
            this.gpIsoscelesTriangleData.Text = "Introduce Isosceles Triangle Data";
            // 
            // btnCreateIsoscelesTriangle
            // 
            this.btnCreateIsoscelesTriangle.Location = new System.Drawing.Point(26, 210);
            this.btnCreateIsoscelesTriangle.Name = "btnCreateIsoscelesTriangle";
            this.btnCreateIsoscelesTriangle.Size = new System.Drawing.Size(215, 36);
            this.btnCreateIsoscelesTriangle.TabIndex = 8;
            this.btnCreateIsoscelesTriangle.Text = "Create Isosceles Triangle";
            this.btnCreateIsoscelesTriangle.UseVisualStyleBackColor = true;
            this.btnCreateIsoscelesTriangle.Click += new System.EventHandler(this.btnCreateIsoscelesTriangle_Click_1);
            // 
            // txtbIsoscelesTriangleSide
            // 
            this.txtbIsoscelesTriangleSide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbIsoscelesTriangleSide.Location = new System.Drawing.Point(116, 129);
            this.txtbIsoscelesTriangleSide.Name = "txtbIsoscelesTriangleSide";
            this.txtbIsoscelesTriangleSide.Size = new System.Drawing.Size(125, 26);
            this.txtbIsoscelesTriangleSide.TabIndex = 7;
            // 
            // txtbColor
            // 
            this.txtbColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbColor.Location = new System.Drawing.Point(116, 94);
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
            // lblIsoscelesTriangleSide
            // 
            this.lblIsoscelesTriangleSide.AutoSize = true;
            this.lblIsoscelesTriangleSide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsoscelesTriangleSide.Location = new System.Drawing.Point(61, 132);
            this.lblIsoscelesTriangleSide.Name = "lblIsoscelesTriangleSide";
            this.lblIsoscelesTriangleSide.Size = new System.Drawing.Size(45, 20);
            this.lblIsoscelesTriangleSide.TabIndex = 3;
            this.lblIsoscelesTriangleSide.Text = "Side:";
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
            // txtbIsoscelesTriangleBase
            // 
            this.txtbIsoscelesTriangleBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbIsoscelesTriangleBase.Location = new System.Drawing.Point(116, 166);
            this.txtbIsoscelesTriangleBase.Name = "txtbIsoscelesTriangleBase";
            this.txtbIsoscelesTriangleBase.Size = new System.Drawing.Size(125, 26);
            this.txtbIsoscelesTriangleBase.TabIndex = 10;
            // 
            // lblIsoscelesTriangleBase
            // 
            this.lblIsoscelesTriangleBase.AutoSize = true;
            this.lblIsoscelesTriangleBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsoscelesTriangleBase.Location = new System.Drawing.Point(59, 169);
            this.lblIsoscelesTriangleBase.Name = "lblIsoscelesTriangleBase";
            this.lblIsoscelesTriangleBase.Size = new System.Drawing.Size(50, 20);
            this.lblIsoscelesTriangleBase.TabIndex = 9;
            this.lblIsoscelesTriangleBase.Text = "Base:";
            // 
            // fIsoscelesTriangle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 297);
            this.Controls.Add(this.gpIsoscelesTriangleData);
            this.Name = "fIsoscelesTriangle";
            this.Text = "Isosceles Triangles";
            this.Load += new System.EventHandler(this.fIsoscelesTriangle_Load);
            this.gpIsoscelesTriangleData.ResumeLayout(false);
            this.gpIsoscelesTriangleData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpIsoscelesTriangleData;
        private System.Windows.Forms.Button btnCreateIsoscelesTriangle;
        private System.Windows.Forms.TextBox txtbIsoscelesTriangleSide;
        private System.Windows.Forms.TextBox txtbColor;
        private System.Windows.Forms.TextBox txtbPositionY;
        private System.Windows.Forms.TextBox txtbPositionX;
        private System.Windows.Forms.Label lblIsoscelesTriangleSide;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblPositionY;
        private System.Windows.Forms.Label lblPositionX;
        private System.Windows.Forms.TextBox txtbIsoscelesTriangleBase;
        private System.Windows.Forms.Label lblIsoscelesTriangleBase;
    }
}