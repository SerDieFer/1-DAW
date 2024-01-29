namespace WindowsFormsApp1
{
    partial class Exercise_7
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
            this.btnAddWords = new System.Windows.Forms.Button();
            this.btnShowList = new System.Windows.Forms.Button();
            this.gPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gPanel
            // 
            this.gPanel.Controls.Add(this.btnAddWords);
            this.gPanel.Controls.Add(this.btnShowList);
            this.gPanel.Location = new System.Drawing.Point(12, 12);
            this.gPanel.Name = "gPanel";
            this.gPanel.Size = new System.Drawing.Size(264, 172);
            this.gPanel.TabIndex = 0;
            this.gPanel.TabStop = false;
            this.gPanel.Text = "Elements";
            // 
            // btnAddWords
            // 
            this.btnAddWords.Location = new System.Drawing.Point(21, 19);
            this.btnAddWords.Name = "btnAddWords";
            this.btnAddWords.Size = new System.Drawing.Size(224, 58);
            this.btnAddWords.TabIndex = 4;
            this.btnAddWords.Text = "Add Words";
            this.btnAddWords.UseVisualStyleBackColor = true;
            this.btnAddWords.Click += new System.EventHandler(this.btnAddWords_Click);
            // 
            // btnShowList
            // 
            this.btnShowList.Location = new System.Drawing.Point(21, 83);
            this.btnShowList.Name = "btnShowList";
            this.btnShowList.Size = new System.Drawing.Size(224, 58);
            this.btnShowList.TabIndex = 2;
            this.btnShowList.Text = "Show List";
            this.btnShowList.UseVisualStyleBackColor = true;
            this.btnShowList.Click += new System.EventHandler(this.btnShowList_Click);
            // 
            // Exercise_7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 206);
            this.Controls.Add(this.gPanel);
            this.Name = "Exercise_7";
            this.Text = "Exercise 7";
            this.Load += new System.EventHandler(this.Exercise_7_Load);
            this.gPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gPanel;
        private System.Windows.Forms.Button btnAddWords;
        private System.Windows.Forms.Button btnShowList;
 
    }
}

