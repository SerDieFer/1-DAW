namespace WindowsFormsApp1
{
    partial class Exercise_4
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
            this.btnExpAdd = new System.Windows.Forms.Button();
            this.btnShowLists = new System.Windows.Forms.Button();
            this.btnBaseAdd = new System.Windows.Forms.Button();
            this.gPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gPanel
            // 
            this.gPanel.Controls.Add(this.btnExpAdd);
            this.gPanel.Controls.Add(this.btnShowLists);
            this.gPanel.Controls.Add(this.btnBaseAdd);
            this.gPanel.Location = new System.Drawing.Point(12, 12);
            this.gPanel.Name = "gPanel";
            this.gPanel.Size = new System.Drawing.Size(264, 246);
            this.gPanel.TabIndex = 0;
            this.gPanel.TabStop = false;
            this.gPanel.Text = "Elements";
            // 
            // btnExpAdd
            // 
            this.btnExpAdd.Location = new System.Drawing.Point(21, 98);
            this.btnExpAdd.Name = "btnExpAdd";
            this.btnExpAdd.Size = new System.Drawing.Size(224, 58);
            this.btnExpAdd.TabIndex = 3;
            this.btnExpAdd.Text = "Add Exponential Numbers to a List";
            this.btnExpAdd.UseVisualStyleBackColor = true;
            this.btnExpAdd.Click += new System.EventHandler(this.btnExpAdd_Click);
            // 
            // btnShowLists
            // 
            this.btnShowLists.Location = new System.Drawing.Point(21, 162);
            this.btnShowLists.Name = "btnShowLists";
            this.btnShowLists.Size = new System.Drawing.Size(224, 58);
            this.btnShowLists.TabIndex = 2;
            this.btnShowLists.Text = "Show List Result";
            this.btnShowLists.UseVisualStyleBackColor = true;
            this.btnShowLists.Click += new System.EventHandler(this.btnShowLists_Click);
            // 
            // btnBaseAdd
            // 
            this.btnBaseAdd.Location = new System.Drawing.Point(21, 34);
            this.btnBaseAdd.Name = "btnBaseAdd";
            this.btnBaseAdd.Size = new System.Drawing.Size(224, 58);
            this.btnBaseAdd.TabIndex = 0;
            this.btnBaseAdd.Text = "Add Base Numbers to a List";
            this.btnBaseAdd.UseVisualStyleBackColor = true;
            this.btnBaseAdd.Click += new System.EventHandler(this.btnBaseAdd_Click);
            // 
            // Exercise_4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 272);
            this.Controls.Add(this.gPanel);
            this.Name = "Exercise_4";
            this.Text = "Exercise 4";
            this.Load += new System.EventHandler(this.Exercise_4_Load);
            this.gPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gPanel;
        private System.Windows.Forms.Button btnBaseAdd;
        private System.Windows.Forms.Button btnShowLists;
        private System.Windows.Forms.Button btnExpAdd;
    }
}

