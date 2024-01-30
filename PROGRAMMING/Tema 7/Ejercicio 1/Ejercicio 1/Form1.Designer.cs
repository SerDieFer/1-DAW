namespace Exercise_1
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
            this.btnIntroduceData = new System.Windows.Forms.Button();
            this.brnShowData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIntroduceData
            // 
            this.btnIntroduceData.Location = new System.Drawing.Point(12, 12);
            this.btnIntroduceData.Name = "btnIntroduceData";
            this.btnIntroduceData.Size = new System.Drawing.Size(205, 46);
            this.btnIntroduceData.TabIndex = 0;
            this.btnIntroduceData.Text = "Introduce Data";
            this.btnIntroduceData.UseVisualStyleBackColor = true;
            this.btnIntroduceData.Click += new System.EventHandler(this.btnIntroduceData_Click);
            // 
            // brnShowData
            // 
            this.brnShowData.Location = new System.Drawing.Point(12, 78);
            this.brnShowData.Name = "brnShowData";
            this.brnShowData.Size = new System.Drawing.Size(205, 46);
            this.brnShowData.TabIndex = 1;
            this.brnShowData.Text = "Show Data";
            this.brnShowData.UseVisualStyleBackColor = true;
            this.brnShowData.Click += new System.EventHandler(this.brnShowData_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 136);
            this.Controls.Add(this.brnShowData);
            this.Controls.Add(this.btnIntroduceData);
            this.Name = "Form1";
            this.Text = "Exercise 1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIntroduceData;
        private System.Windows.Forms.Button brnShowData;
    }
}

