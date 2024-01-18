namespace WindowsFormsApp1
{
    partial class Exercise_2
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
            this.btnShowLists = new System.Windows.Forms.Button();
            this.btnCopyPrime = new System.Windows.Forms.Button();
            this.btnRemovePrime = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gPanel
            // 
            this.gPanel.Controls.Add(this.btnShowLists);
            this.gPanel.Controls.Add(this.btnCopyPrime);
            this.gPanel.Controls.Add(this.btnRemovePrime);
            this.gPanel.Controls.Add(this.btnAdd);
            this.gPanel.Location = new System.Drawing.Point(12, 12);
            this.gPanel.Name = "gPanel";
            this.gPanel.Size = new System.Drawing.Size(264, 317);
            this.gPanel.TabIndex = 0;
            this.gPanel.TabStop = false;
            this.gPanel.Text = "Elements";
            // 
            // btnShowLists
            // 
            this.btnShowLists.Location = new System.Drawing.Point(21, 226);
            this.btnShowLists.Name = "btnShowLists";
            this.btnShowLists.Size = new System.Drawing.Size(224, 58);
            this.btnShowLists.TabIndex = 2;
            this.btnShowLists.Text = "Show Both Lists";
            this.btnShowLists.UseVisualStyleBackColor = true;
            this.btnShowLists.Click += new System.EventHandler(this.btnShowLists_Click);
            // 
            // btnCopyPrime
            // 
            this.btnCopyPrime.Location = new System.Drawing.Point(21, 162);
            this.btnCopyPrime.Name = "btnCopyPrime";
            this.btnCopyPrime.Size = new System.Drawing.Size(224, 58);
            this.btnCopyPrime.TabIndex = 1;
            this.btnCopyPrime.Text = "Copy Prime Numbers Into New List";
            this.btnCopyPrime.UseVisualStyleBackColor = true;
            this.btnCopyPrime.Click += new System.EventHandler(this.btnCopyPrime_Click);
            // 
            // btnRemovePrime
            // 
            this.btnRemovePrime.Location = new System.Drawing.Point(21, 98);
            this.btnRemovePrime.Name = "btnRemovePrime";
            this.btnRemovePrime.Size = new System.Drawing.Size(224, 58);
            this.btnRemovePrime.TabIndex = 0;
            this.btnRemovePrime.Text = "Remove Prime Numbers From Original List\r\n";
            this.btnRemovePrime.UseVisualStyleBackColor = true;
            this.btnRemovePrime.Click += new System.EventHandler(this.btnRemoveEven_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(21, 34);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(224, 58);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add Numbers to Original List";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Exercise_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 347);
            this.Controls.Add(this.gPanel);
            this.Name = "Exercise_2";
            this.Text = "Exercise 2";
            this.Load += new System.EventHandler(this.Exercise_1_Load);
            this.gPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gPanel;
        private System.Windows.Forms.Button btnCopyPrime;
        private System.Windows.Forms.Button btnRemovePrime;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnShowLists;
    }
}

