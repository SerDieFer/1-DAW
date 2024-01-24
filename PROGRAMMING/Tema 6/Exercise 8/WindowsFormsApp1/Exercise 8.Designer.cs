namespace WindowsFormsApp1
{
    partial class Exercise_8
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gPanel = new System.Windows.Forms.GroupBox();
            this.AddUserNumbers = new System.Windows.Forms.Button();
            this.btnShowLottery = new System.Windows.Forms.Button();
            this.AddWinnerNumbers = new System.Windows.Forms.Button();
            this.gPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gPanel
            // 
            this.gPanel.Controls.Add(this.AddUserNumbers);
            this.gPanel.Controls.Add(this.btnShowLottery);
            this.gPanel.Controls.Add(this.AddWinnerNumbers);
            this.gPanel.Location = new System.Drawing.Point(12, 12);
            this.gPanel.Name = "gPanel";
            this.gPanel.Size = new System.Drawing.Size(264, 242);
            this.gPanel.TabIndex = 0;
            this.gPanel.TabStop = false;
            this.gPanel.Text = "Elements";
            // 
            // AddUserNumbers
            // 
            this.AddUserNumbers.Location = new System.Drawing.Point(21, 98);
            this.AddUserNumbers.Name = "AddUserNumbers";
            this.AddUserNumbers.Size = new System.Drawing.Size(224, 58);
            this.AddUserNumbers.TabIndex = 4;
            this.AddUserNumbers.Text = "Add User Numbers";
            this.AddUserNumbers.UseVisualStyleBackColor = true;
            this.AddUserNumbers.Click += new System.EventHandler(this.AddWinnerNumbers_Click);
            // 
            // btnShowLottery
            // 
            this.btnShowLottery.Location = new System.Drawing.Point(21, 162);
            this.btnShowLottery.Name = "btnShowLottery";
            this.btnShowLottery.Size = new System.Drawing.Size(224, 58);
            this.btnShowLottery.TabIndex = 2;
            this.btnShowLottery.Text = "Show Lottery";
            this.btnShowLottery.UseVisualStyleBackColor = true;
            this.btnShowLottery.Click += new System.EventHandler(this.btnShowLottery_Click);
            // 
            // AddWinnerNumbers
            // 
            this.AddWinnerNumbers.Location = new System.Drawing.Point(21, 34);
            this.AddWinnerNumbers.Name = "AddWinnerNumbers";
            this.AddWinnerNumbers.Size = new System.Drawing.Size(224, 58);
            this.AddWinnerNumbers.TabIndex = 0;
            this.AddWinnerNumbers.Text = "Add Winner Numbers";
            this.AddWinnerNumbers.UseVisualStyleBackColor = true;
            this.AddWinnerNumbers.Click += new System.EventHandler(this.AddUserNumbers_Click);
            // 
            // Exercise_8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 284);
            this.Controls.Add(this.gPanel);
            this.Name = "Exercise_8";
            this.Text = "Exercise 8";
            this.Load += new System.EventHandler(this.Exercise_8_Load);
            this.gPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gPanel;
        private System.Windows.Forms.Button AddWinnerNumbers;
        private System.Windows.Forms.Button btnShowLottery;
        private System.Windows.Forms.Button AddUserNumbers;
    }
}

