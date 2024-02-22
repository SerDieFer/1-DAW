using System;

namespace Exercise_5
{
    partial class EmployeesData
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
            this.btnShowEmployeeData = new System.Windows.Forms.Button();
            this.btnAddSales = new System.Windows.Forms.Button();
            this.gBEmployees = new System.Windows.Forms.GroupBox();
            this.btnOrderEmployeesAlphabetically = new System.Windows.Forms.Button();
            this.btnRemoveEmployee = new System.Windows.Forms.Button();
            this.gbSales = new System.Windows.Forms.GroupBox();
            this.btnOrderEmployeesBySales = new System.Windows.Forms.Button();
            this.btnShowEmployeeGreatestSales = new System.Windows.Forms.Button();
            this.btnRemoveSales = new System.Windows.Forms.Button();
            this.btnRemoveAllSales = new System.Windows.Forms.Button();
            this.gBEmployees.SuspendLayout();
            this.gbSales.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIntroduceEmployee
            // 
            this.btnIntroduceEmployee.Location = new System.Drawing.Point(23, 34);
            this.btnIntroduceEmployee.Name = "btnIntroduceEmployee";
            this.btnIntroduceEmployee.Size = new System.Drawing.Size(235, 46);
            this.btnIntroduceEmployee.TabIndex = 0;
            this.btnIntroduceEmployee.Text = "Add New Employee";
            this.btnIntroduceEmployee.UseVisualStyleBackColor = true;
            this.btnIntroduceEmployee.Click += new System.EventHandler(this.btnIntroduceEmployee_Click);
            // 
            // btnShowList
            // 
            this.btnShowList.Location = new System.Drawing.Point(553, 105);
            this.btnShowList.Name = "btnShowList";
            this.btnShowList.Size = new System.Drawing.Size(235, 46);
            this.btnShowList.TabIndex = 1;
            this.btnShowList.Text = "Show Employees List";
            this.btnShowList.UseVisualStyleBackColor = true;
            this.btnShowList.Click += new System.EventHandler(this.btnShowData_Click);
            // 
            // btnShowEmployeeData
            // 
            this.btnShowEmployeeData.Location = new System.Drawing.Point(553, 34);
            this.btnShowEmployeeData.Name = "btnShowEmployeeData";
            this.btnShowEmployeeData.Size = new System.Drawing.Size(235, 46);
            this.btnShowEmployeeData.TabIndex = 2;
            this.btnShowEmployeeData.Text = "Show Employee Data";
            this.btnShowEmployeeData.UseVisualStyleBackColor = true;
            this.btnShowEmployeeData.Click += new System.EventHandler(this.btnShowEmployeeData_Click);
            // 
            // btnAddSales
            // 
            this.btnAddSales.Location = new System.Drawing.Point(23, 29);
            this.btnAddSales.Name = "btnAddSales";
            this.btnAddSales.Size = new System.Drawing.Size(364, 46);
            this.btnAddSales.TabIndex = 3;
            this.btnAddSales.Text = "Add Sales To Employee";
            this.btnAddSales.UseVisualStyleBackColor = true;
            this.btnAddSales.Click += new System.EventHandler(this.btnAddSales_Click);
            // 
            // gBEmployees
            // 
            this.gBEmployees.Controls.Add(this.btnOrderEmployeesAlphabetically);
            this.gBEmployees.Controls.Add(this.btnRemoveEmployee);
            this.gBEmployees.Controls.Add(this.btnIntroduceEmployee);
            this.gBEmployees.Controls.Add(this.btnShowList);
            this.gBEmployees.Controls.Add(this.btnShowEmployeeData);
            this.gBEmployees.Location = new System.Drawing.Point(12, 12);
            this.gBEmployees.Name = "gBEmployees";
            this.gBEmployees.Size = new System.Drawing.Size(812, 183);
            this.gBEmployees.TabIndex = 4;
            this.gBEmployees.TabStop = false;
            this.gBEmployees.Text = "Employees";
            // 
            // btnOrderEmployeesAlphabetically
            // 
            this.btnOrderEmployeesAlphabetically.Location = new System.Drawing.Point(23, 105);
            this.btnOrderEmployeesAlphabetically.Name = "btnOrderEmployeesAlphabetically";
            this.btnOrderEmployeesAlphabetically.Size = new System.Drawing.Size(495, 46);
            this.btnOrderEmployeesAlphabetically.TabIndex = 3;
            this.btnOrderEmployeesAlphabetically.Text = "Sort Employees List Alphabetically ";
            this.btnOrderEmployeesAlphabetically.UseVisualStyleBackColor = true;
            this.btnOrderEmployeesAlphabetically.Click += new System.EventHandler(this.btnOrderEmployeesAlphabetically_Click);
            // 
            // btnRemoveEmployee
            // 
            this.btnRemoveEmployee.Location = new System.Drawing.Point(283, 34);
            this.btnRemoveEmployee.Name = "btnRemoveEmployee";
            this.btnRemoveEmployee.Size = new System.Drawing.Size(235, 46);
            this.btnRemoveEmployee.TabIndex = 0;
            this.btnRemoveEmployee.Text = "Remove Employee";
            this.btnRemoveEmployee.UseVisualStyleBackColor = true;
            this.btnRemoveEmployee.Click += new System.EventHandler(this.btnRemoveEmployee_Click);
            // 
            // gbSales
            // 
            this.gbSales.Controls.Add(this.btnRemoveAllSales);
            this.gbSales.Controls.Add(this.btnOrderEmployeesBySales);
            this.gbSales.Controls.Add(this.btnShowEmployeeGreatestSales);
            this.gbSales.Controls.Add(this.btnRemoveSales);
            this.gbSales.Controls.Add(this.btnAddSales);
            this.gbSales.Location = new System.Drawing.Point(12, 216);
            this.gbSales.Name = "gbSales";
            this.gbSales.Size = new System.Drawing.Size(812, 183);
            this.gbSales.TabIndex = 5;
            this.gbSales.TabStop = false;
            this.gbSales.Text = "Sales";
            // 
            // btnOrderEmployeesBySales
            // 
            this.btnOrderEmployeesBySales.Location = new System.Drawing.Point(553, 104);
            this.btnOrderEmployeesBySales.Name = "btnOrderEmployeesBySales";
            this.btnOrderEmployeesBySales.Size = new System.Drawing.Size(235, 46);
            this.btnOrderEmployeesBySales.TabIndex = 4;
            this.btnOrderEmployeesBySales.Text = "Sort Employees List By Sales";
            this.btnOrderEmployeesBySales.UseVisualStyleBackColor = true;
            this.btnOrderEmployeesBySales.Click += new System.EventHandler(this.btnOrderEmployeesBySales_Click);
            // 
            // btnShowEmployeeGreatestSales
            // 
            this.btnShowEmployeeGreatestSales.Location = new System.Drawing.Point(419, 29);
            this.btnShowEmployeeGreatestSales.Name = "btnShowEmployeeGreatestSales";
            this.btnShowEmployeeGreatestSales.Size = new System.Drawing.Size(369, 46);
            this.btnShowEmployeeGreatestSales.TabIndex = 1;
            this.btnShowEmployeeGreatestSales.Text = "Show Employee With Greater Sales";
            this.btnShowEmployeeGreatestSales.UseVisualStyleBackColor = true;
            this.btnShowEmployeeGreatestSales.Click += new System.EventHandler(this.btnShowEmployeeGreatestSales_Click);
            // 
            // btnRemoveSales
            // 
            this.btnRemoveSales.Location = new System.Drawing.Point(23, 104);
            this.btnRemoveSales.Name = "btnRemoveSales";
            this.btnRemoveSales.Size = new System.Drawing.Size(235, 46);
            this.btnRemoveSales.TabIndex = 2;
            this.btnRemoveSales.Text = "Remove Selected Sale From Employee";
            this.btnRemoveSales.UseVisualStyleBackColor = true;
            this.btnRemoveSales.Click += new System.EventHandler(this.btnRemoveSales_Click);
            // 
            // btnRemoveAllSales
            // 
            this.btnRemoveAllSales.Location = new System.Drawing.Point(283, 104);
            this.btnRemoveAllSales.Name = "btnRemoveAllSales";
            this.btnRemoveAllSales.Size = new System.Drawing.Size(235, 46);
            this.btnRemoveAllSales.TabIndex = 5;
            this.btnRemoveAllSales.Text = "Remove All Sales From Employee";
            this.btnRemoveAllSales.UseVisualStyleBackColor = true;
            this.btnRemoveAllSales.Click += new System.EventHandler(this.btnRemoveAllSales_Click);
            // 
            // EmployeesData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 420);
            this.Controls.Add(this.gbSales);
            this.Controls.Add(this.gBEmployees);
            this.Name = "EmployeesData";
            this.Text = "Exercise 5";
            this.gBEmployees.ResumeLayout(false);
            this.gbSales.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIntroduceEmployee;
        private System.Windows.Forms.Button btnShowList;
        private System.Windows.Forms.Button btnShowEmployeeData;
        private System.Windows.Forms.Button btnAddSales;
        private System.Windows.Forms.GroupBox gBEmployees;
        private System.Windows.Forms.Button btnRemoveEmployee;
        private System.Windows.Forms.GroupBox gbSales;
        private System.Windows.Forms.Button btnOrderEmployeesAlphabetically;
        private System.Windows.Forms.Button btnShowEmployeeGreatestSales;
        private System.Windows.Forms.Button btnRemoveSales;
        private System.Windows.Forms.Button btnOrderEmployeesBySales;
        private System.Windows.Forms.Button btnRemoveAllSales;
    }
}

