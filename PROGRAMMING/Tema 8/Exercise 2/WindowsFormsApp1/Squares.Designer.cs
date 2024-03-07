namespace Exercise_2
{
    partial class Squares
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
            this.gpSquareData = new System.Windows.Forms.GroupBox();
            this.lblPositionX = new System.Windows.Forms.Label();
            this.lblPositionY = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblSquareHeight = new System.Windows.Forms.Label();
            this.txtbPositionX = new System.Windows.Forms.TextBox();
            this.txtbPositionY = new System.Windows.Forms.TextBox();
            this.txtbColor = new System.Windows.Forms.TextBox();
            this.txtbSquareHeight = new System.Windows.Forms.TextBox();
            this.btnCreateSquare = new System.Windows.Forms.Button();
            this.gpSquareData.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpSquareData
            // 
            this.gpSquareData.Controls.Add(this.btnCreateSquare);
            this.gpSquareData.Controls.Add(this.txtbSquareHeight);
            this.gpSquareData.Controls.Add(this.txtbColor);
            this.gpSquareData.Controls.Add(this.txtbPositionY);
            this.gpSquareData.Controls.Add(this.txtbPositionX);
            this.gpSquareData.Controls.Add(this.lblSquareHeight);
            this.gpSquareData.Controls.Add(this.lblColor);
            this.gpSquareData.Controls.Add(this.lblPositionY);
            this.gpSquareData.Controls.Add(this.lblPositionX);
            this.gpSquareData.Location = new System.Drawing.Point(12, 12);
            this.gpSquareData.Name = "gpSquareData";
            this.gpSquareData.Size = new System.Drawing.Size(210, 227);
            this.gpSquareData.TabIndex = 0;
            this.gpSquareData.TabStop = false;
            this.gpSquareData.Text = "Introduce Square Data";
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
            // lblSquareHeight
            // 
            this.lblSquareHeight.AutoSize = true;
            this.lblSquareHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSquareHeight.Location = new System.Drawing.Point(45, 132);
            this.lblSquareHeight.Name = "lblSquareHeight";
            this.lblSquareHeight.Size = new System.Drawing.Size(60, 20);
            this.lblSquareHeight.TabIndex = 3;
            this.lblSquareHeight.Text = "Height:";
            // 
            // txtbPositionX
            // 
            this.txtbPositionX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbPositionX.Location = new System.Drawing.Point(116, 27);
            this.txtbPositionX.Name = "txtbPositionX";
            this.txtbPositionX.Size = new System.Drawing.Size(68, 26);
            this.txtbPositionX.TabIndex = 4;
            // 
            // txtbPositionY
            // 
            this.txtbPositionY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbPositionY.Location = new System.Drawing.Point(116, 60);
            this.txtbPositionY.Name = "txtbPositionY";
            this.txtbPositionY.Size = new System.Drawing.Size(68, 26);
            this.txtbPositionY.TabIndex = 5;
            // 
            // txtbColor
            // 
            this.txtbColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbColor.Location = new System.Drawing.Point(116, 94);
            this.txtbColor.Name = "txtbColor";
            this.txtbColor.Size = new System.Drawing.Size(68, 26);
            this.txtbColor.TabIndex = 6;
            // 
            // txtbSquareHeight
            // 
            this.txtbSquareHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbSquareHeight.Location = new System.Drawing.Point(116, 129);
            this.txtbSquareHeight.Name = "txtbSquareHeight";
            this.txtbSquareHeight.Size = new System.Drawing.Size(68, 26);
            this.txtbSquareHeight.TabIndex = 7;
            // 
            // btnCreateSquare
            // 
            this.btnCreateSquare.Location = new System.Drawing.Point(26, 171);
            this.btnCreateSquare.Name = "btnCreateSquare";
            this.btnCreateSquare.Size = new System.Drawing.Size(158, 36);
            this.btnCreateSquare.TabIndex = 8;
            this.btnCreateSquare.Text = "Create Square";
            this.btnCreateSquare.UseVisualStyleBackColor = true;
            // 
            // Squares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 251);
            this.Controls.Add(this.gpSquareData);
            this.Name = "Squares";
            this.Text = "Squares";
            this.Load += new System.EventHandler(this.Squares_Load);
            this.gpSquareData.ResumeLayout(false);
            this.gpSquareData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpSquareData;
        private System.Windows.Forms.Button btnCreateSquare;
        private System.Windows.Forms.TextBox txtbSquareHeight;
        private System.Windows.Forms.TextBox txtbColor;
        private System.Windows.Forms.TextBox txtbPositionY;
        private System.Windows.Forms.TextBox txtbPositionX;
        private System.Windows.Forms.Label lblSquareHeight;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblPositionY;
        private System.Windows.Forms.Label lblPositionX;
    }
}