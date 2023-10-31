namespace Ejercicio_5
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
            this.btnCal = new System.Windows.Forms.Button();
            this.txtBoxN1 = new System.Windows.Forms.TextBox();
            this.txtBoxN2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCal
            // 
            this.btnCal.Location = new System.Drawing.Point(12, 76);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(341, 34);
            this.btnCal.TabIndex = 0;
            this.btnCal.Text = "Calcular";
            this.btnCal.UseVisualStyleBackColor = true;
            this.btnCal.Click += new System.EventHandler(this.btnCal_Click);
            // 
            // txtBoxN1
            // 
            this.txtBoxN1.Location = new System.Drawing.Point(12, 31);
            this.txtBoxN1.Name = "txtBoxN1";
            this.txtBoxN1.Size = new System.Drawing.Size(150, 20);
            this.txtBoxN1.TabIndex = 1;
            // 
            // txtBoxN2
            // 
            this.txtBoxN2.Location = new System.Drawing.Point(205, 31);
            this.txtBoxN2.Name = "txtBoxN2";
            this.txtBoxN2.Size = new System.Drawing.Size(148, 20);
            this.txtBoxN2.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 122);
            this.Controls.Add(this.txtBoxN2);
            this.Controls.Add(this.txtBoxN1);
            this.Controls.Add(this.btnCal);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCal;
        private System.Windows.Forms.TextBox txtBoxN1;
        private System.Windows.Forms.TextBox txtBoxN2;
    }
}

