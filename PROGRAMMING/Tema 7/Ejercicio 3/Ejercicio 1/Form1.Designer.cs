namespace Exercise_3
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
            this.btnIntroduceDate = new System.Windows.Forms.Button();
            this.brnShowData = new System.Windows.Forms.Button();
            this.btnOrderDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIntroduceDate
            // 
            this.btnIntroduceDate.Location = new System.Drawing.Point(12, 12);
            this.btnIntroduceDate.Name = "btnIntroduceDate";
            this.btnIntroduceDate.Size = new System.Drawing.Size(205, 46);
            this.btnIntroduceDate.TabIndex = 0;
            this.btnIntroduceDate.Text = "Introduce Date";
            this.btnIntroduceDate.UseVisualStyleBackColor = true;
            this.btnIntroduceDate.Click += new System.EventHandler(this.btnIntroduceDate_Click);
            // 
            // brnShowData
            // 
            this.brnShowData.Location = new System.Drawing.Point(12, 146);
            this.brnShowData.Name = "brnShowData";
            this.brnShowData.Size = new System.Drawing.Size(205, 46);
            this.brnShowData.TabIndex = 1;
            this.brnShowData.Text = "Show Data";
            this.brnShowData.UseVisualStyleBackColor = true;
            this.brnShowData.Click += new System.EventHandler(this.brnShowData_Click);
            // 
            // btnOrderDate
            // 
            this.btnOrderDate.Location = new System.Drawing.Point(15, 79);
            this.btnOrderDate.Name = "btnOrderDate";
            this.btnOrderDate.Size = new System.Drawing.Size(205, 46);
            this.btnOrderDate.TabIndex = 2;
            this.btnOrderDate.Text = "Order Date";
            this.btnOrderDate.UseVisualStyleBackColor = true;
            this.btnOrderDate.Click += new System.EventHandler(this.btnOrderDate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 204);
            this.Controls.Add(this.btnOrderDate);
            this.Controls.Add(this.brnShowData);
            this.Controls.Add(this.btnIntroduceDate);
            this.Name = "Form1";
            this.Text = "Exercise 3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIntroduceDate;
        private System.Windows.Forms.Button brnShowData;
        private System.Windows.Forms.Button btnOrderDate;
    }
}

