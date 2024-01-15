namespace WindowsFormsApp1
{
    partial class Form1
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
            this.gPanel1 = new System.Windows.Forms.GroupBox();
            this.btnShowPositionsFromValue = new System.Windows.Forms.Button();
            this.btnShowFirstValuePosition = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnShowList = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gPanel2 = new System.Windows.Forms.GroupBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnSortList = new System.Windows.Forms.Button();
            this.btnRemoveValues = new System.Windows.Forms.Button();
            this.btnRemovePosition = new System.Windows.Forms.Button();
            this.btnRemoveFirstValue = new System.Windows.Forms.Button();
            this.gPanel1.SuspendLayout();
            this.gPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gPanel1
            // 
            this.gPanel1.Controls.Add(this.btnShowPositionsFromValue);
            this.gPanel1.Controls.Add(this.btnShowFirstValuePosition);
            this.gPanel1.Controls.Add(this.btnInsert);
            this.gPanel1.Controls.Add(this.btnShowList);
            this.gPanel1.Controls.Add(this.btnAdd);
            this.gPanel1.Location = new System.Drawing.Point(12, 12);
            this.gPanel1.Name = "gPanel1";
            this.gPanel1.Size = new System.Drawing.Size(264, 380);
            this.gPanel1.TabIndex = 0;
            this.gPanel1.TabStop = false;
            this.gPanel1.Text = "Elements";
            // 
            // btnShowPositionsFromValue
            // 
            this.btnShowPositionsFromValue.Location = new System.Drawing.Point(21, 290);
            this.btnShowPositionsFromValue.Name = "btnShowPositionsFromValue";
            this.btnShowPositionsFromValue.Size = new System.Drawing.Size(224, 58);
            this.btnShowPositionsFromValue.TabIndex = 2;
            this.btnShowPositionsFromValue.Text = "Show Positions of Value";
            this.btnShowPositionsFromValue.UseVisualStyleBackColor = true;
            this.btnShowPositionsFromValue.Click += new System.EventHandler(this.btnShowPositionsFromValue_Click);
            // 
            // btnShowFirstValuePosition
            // 
            this.btnShowFirstValuePosition.Location = new System.Drawing.Point(21, 226);
            this.btnShowFirstValuePosition.Name = "btnShowFirstValuePosition";
            this.btnShowFirstValuePosition.Size = new System.Drawing.Size(224, 58);
            this.btnShowFirstValuePosition.TabIndex = 1;
            this.btnShowFirstValuePosition.Text = "Show First Position Of Value";
            this.btnShowFirstValuePosition.UseVisualStyleBackColor = true;
            this.btnShowFirstValuePosition.Click += new System.EventHandler(this.btnShowFirstValuePosition_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(21, 98);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(224, 58);
            this.btnInsert.TabIndex = 1;
            this.btnInsert.Text = "Insert Number";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnShowList
            // 
            this.btnShowList.Location = new System.Drawing.Point(21, 162);
            this.btnShowList.Name = "btnShowList";
            this.btnShowList.Size = new System.Drawing.Size(224, 58);
            this.btnShowList.TabIndex = 0;
            this.btnShowList.Text = "Show List";
            this.btnShowList.UseVisualStyleBackColor = true;
            this.btnShowList.Click += new System.EventHandler(this.btnShowList_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(21, 34);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(224, 58);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add Number";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gPanel2
            // 
            this.gPanel2.Controls.Add(this.btnClearAll);
            this.gPanel2.Controls.Add(this.btnSortList);
            this.gPanel2.Controls.Add(this.btnRemoveValues);
            this.gPanel2.Controls.Add(this.btnRemovePosition);
            this.gPanel2.Controls.Add(this.btnRemoveFirstValue);
            this.gPanel2.Location = new System.Drawing.Point(303, 12);
            this.gPanel2.Name = "gPanel2";
            this.gPanel2.Size = new System.Drawing.Size(264, 380);
            this.gPanel2.TabIndex = 1;
            this.gPanel2.TabStop = false;
            this.gPanel2.Text = "Remove and Sort";
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(20, 289);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(224, 58);
            this.btnClearAll.TabIndex = 7;
            this.btnClearAll.Text = "Remove All Elements";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnSortList
            // 
            this.btnSortList.Location = new System.Drawing.Point(20, 225);
            this.btnSortList.Name = "btnSortList";
            this.btnSortList.Size = new System.Drawing.Size(224, 58);
            this.btnSortList.TabIndex = 5;
            this.btnSortList.Text = "Sort List";
            this.btnSortList.UseVisualStyleBackColor = true;
            this.btnSortList.Click += new System.EventHandler(this.btnSortList_Click);
            // 
            // btnRemoveValues
            // 
            this.btnRemoveValues.Location = new System.Drawing.Point(20, 97);
            this.btnRemoveValues.Name = "btnRemoveValues";
            this.btnRemoveValues.Size = new System.Drawing.Size(224, 58);
            this.btnRemoveValues.TabIndex = 6;
            this.btnRemoveValues.Text = "Remove Values";
            this.btnRemoveValues.UseVisualStyleBackColor = true;
            this.btnRemoveValues.Click += new System.EventHandler(this.btnRemoveValues_Click);
            // 
            // btnRemovePosition
            // 
            this.btnRemovePosition.Location = new System.Drawing.Point(20, 161);
            this.btnRemovePosition.Name = "btnRemovePosition";
            this.btnRemovePosition.Size = new System.Drawing.Size(224, 58);
            this.btnRemovePosition.TabIndex = 3;
            this.btnRemovePosition.Text = "Remove Position";
            this.btnRemovePosition.UseVisualStyleBackColor = true;
            this.btnRemovePosition.Click += new System.EventHandler(this.btnRemovePosition_Click);
            // 
            // btnRemoveFirstValue
            // 
            this.btnRemoveFirstValue.Location = new System.Drawing.Point(20, 33);
            this.btnRemoveFirstValue.Name = "btnRemoveFirstValue";
            this.btnRemoveFirstValue.Size = new System.Drawing.Size(224, 58);
            this.btnRemoveFirstValue.TabIndex = 4;
            this.btnRemoveFirstValue.Text = "Remove First Value";
            this.btnRemoveFirstValue.UseVisualStyleBackColor = true;
            this.btnRemoveFirstValue.Click += new System.EventHandler(this.btnRemoveFirstValue_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 409);
            this.Controls.Add(this.gPanel2);
            this.Controls.Add(this.gPanel1);
            this.Name = "Form1";
            this.Text = "Exercise 1";
            this.Load += new System.EventHandler(this.Exercise_1_Load);
            this.gPanel1.ResumeLayout(false);
            this.gPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gPanel1;
        private System.Windows.Forms.Button btnShowPositionsFromValue;
        private System.Windows.Forms.Button btnShowFirstValuePosition;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnShowList;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox gPanel2;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnSortList;
        private System.Windows.Forms.Button btnRemoveValues;
        private System.Windows.Forms.Button btnRemovePosition;
        private System.Windows.Forms.Button btnRemoveFirstValue;
    }
}

