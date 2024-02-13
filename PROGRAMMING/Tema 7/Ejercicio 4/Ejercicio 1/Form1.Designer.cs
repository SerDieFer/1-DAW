namespace Exercise_4
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
            this.btnIntroduceEmployee = new System.Windows.Forms.Button();
            this.btnShowList = new System.Windows.Forms.Button();
            this.btnBirthday = new System.Windows.Forms.Button();
            this.btnAddSales = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIntroduceEmployee
            // 
            this.btnIntroduceEmployee.Location = new System.Drawing.Point(12, 12);
            this.btnIntroduceEmployee.Name = "btnIntroduceEmployee";
            this.btnIntroduceEmployee.Size = new System.Drawing.Size(235, 46);
            this.btnIntroduceEmployee.TabIndex = 0;
            this.btnIntroduceEmployee.Text = "New Employee";
            this.btnIntroduceEmployee.UseVisualStyleBackColor = true;
            this.btnIntroduceEmployee.Click += new System.EventHandler(this.btnIntroduceDate_Click);
            // 
            // btnShowList
            // 
            this.btnShowList.Location = new System.Drawing.Point(272, 12);
            this.btnShowList.Name = "btnShowList";
            this.btnShowList.Size = new System.Drawing.Size(235, 46);
            this.btnShowList.TabIndex = 1;
            this.btnShowList.Text = "Show Employee List";
            this.btnShowList.UseVisualStyleBackColor = true;
            this.btnShowList.Click += new System.EventHandler(this.brnShowData_Click);
            // 
            // btnBirthday
            // 
            this.btnBirthday.Location = new System.Drawing.Point(12, 73);
            this.btnBirthday.Name = "btnBirthday";
            this.btnBirthday.Size = new System.Drawing.Size(235, 46);
            this.btnBirthday.TabIndex = 2;
            this.btnBirthday.Text = "Birthday Employee";
            this.btnBirthday.UseVisualStyleBackColor = true;
            this.btnBirthday.Click += new System.EventHandler(this.btnOrderDate_Click);
            // 
            // btnAddSales
            // 
            this.btnAddSales.Location = new System.Drawing.Point(272, 73);
            this.btnAddSales.Name = "btnAddSales";
            this.btnAddSales.Size = new System.Drawing.Size(235, 46);
            this.btnAddSales.TabIndex = 3;
            this.btnAddSales.Text = "Add Sales";
            this.btnAddSales.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 132);
            this.Controls.Add(this.btnAddSales);
            this.Controls.Add(this.btnBirthday);
            this.Controls.Add(this.btnShowList);
            this.Controls.Add(this.btnIntroduceEmployee);
            this.Name = "Form1";
            this.Text = "Exercise 4";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIntroduceEmployee;
        private System.Windows.Forms.Button btnShowList;
        private System.Windows.Forms.Button btnBirthday;
        private System.Windows.Forms.Button btnAddSales;
    }
}

