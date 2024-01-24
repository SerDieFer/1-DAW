namespace WindowsFormsApp1
{
    partial class Exercise_5
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
            this.btnList2Add = new System.Windows.Forms.Button();
            this.btnAddBothToNew = new System.Windows.Forms.Button();
            this.btnShowLists = new System.Windows.Forms.Button();
            this.btnList1Add = new System.Windows.Forms.Button();
            this.btnAddBothToNewAndRemoveOriginals = new System.Windows.Forms.Button();
            this.gPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gPanel
            // 
            this.gPanel.Controls.Add(this.btnAddBothToNewAndRemoveOriginals);
            this.gPanel.Controls.Add(this.btnList2Add);
            this.gPanel.Controls.Add(this.btnAddBothToNew);
            this.gPanel.Controls.Add(this.btnShowLists);
            this.gPanel.Controls.Add(this.btnList1Add);
            this.gPanel.Location = new System.Drawing.Point(12, 12);
            this.gPanel.Name = "gPanel";
            this.gPanel.Size = new System.Drawing.Size(264, 363);
            this.gPanel.TabIndex = 0;
            this.gPanel.TabStop = false;
            this.gPanel.Text = "Elements";
            // 
            // btnList2Add
            // 
            this.btnList2Add.Location = new System.Drawing.Point(21, 98);
            this.btnList2Add.Name = "btnList2Add";
            this.btnList2Add.Size = new System.Drawing.Size(224, 58);
            this.btnList2Add.TabIndex = 4;
            this.btnList2Add.Text = "Add Numbers to List2";
            this.btnList2Add.UseVisualStyleBackColor = true;
            this.btnList2Add.Click += new System.EventHandler(this.btnList2Add_Click);
            // 
            // btnAddBothToNew
            // 
            this.btnAddBothToNew.Location = new System.Drawing.Point(21, 162);
            this.btnAddBothToNew.Name = "btnAddBothToNew";
            this.btnAddBothToNew.Size = new System.Drawing.Size(224, 58);
            this.btnAddBothToNew.TabIndex = 3;
            this.btnAddBothToNew.Text = "Add Both Lists Values Into New List";
            this.btnAddBothToNew.UseVisualStyleBackColor = true;
            this.btnAddBothToNew.Click += new System.EventHandler(this.btnAddBothToNew_Click);
            // 
            // btnShowLists
            // 
            this.btnShowLists.Location = new System.Drawing.Point(21, 290);
            this.btnShowLists.Name = "btnShowLists";
            this.btnShowLists.Size = new System.Drawing.Size(224, 58);
            this.btnShowLists.TabIndex = 2;
            this.btnShowLists.Text = "Show List Result";
            this.btnShowLists.UseVisualStyleBackColor = true;
            this.btnShowLists.Click += new System.EventHandler(this.btnShowLists_Click);
            // 
            // btnList1Add
            // 
            this.btnList1Add.Location = new System.Drawing.Point(21, 34);
            this.btnList1Add.Name = "btnList1Add";
            this.btnList1Add.Size = new System.Drawing.Size(224, 58);
            this.btnList1Add.TabIndex = 0;
            this.btnList1Add.Text = "Add Numbers to List1";
            this.btnList1Add.UseVisualStyleBackColor = true;
            this.btnList1Add.Click += new System.EventHandler(this.btnList1Add_Click);
            // 
            // btnAddBothToNewAndRemoveOriginals
            // 
            this.btnAddBothToNewAndRemoveOriginals.Location = new System.Drawing.Point(21, 226);
            this.btnAddBothToNewAndRemoveOriginals.Name = "btnAddBothToNewAndRemoveOriginals";
            this.btnAddBothToNewAndRemoveOriginals.Size = new System.Drawing.Size(224, 58);
            this.btnAddBothToNewAndRemoveOriginals.TabIndex = 5;
            this.btnAddBothToNewAndRemoveOriginals.Text = "Add Both Lists Values Into New List and Remove From Original";
            this.btnAddBothToNewAndRemoveOriginals.UseVisualStyleBackColor = true;
            this.btnAddBothToNewAndRemoveOriginals.Click += new System.EventHandler(this.btnAddBothToNewAndRemoveOriginals_Click);
            // 
            // Exercise_5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 387);
            this.Controls.Add(this.gPanel);
            this.Name = "Exercise_5";
            this.Text = "Exercise 5";
            this.Load += new System.EventHandler(this.Exercise_5_Load);
            this.gPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gPanel;
        private System.Windows.Forms.Button btnList1Add;
        private System.Windows.Forms.Button btnShowLists;
        private System.Windows.Forms.Button btnAddBothToNew;
        private System.Windows.Forms.Button btnList2Add;
        private System.Windows.Forms.Button btnAddBothToNewAndRemoveOriginals;
    }
}

