namespace Extra___1
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
            this.btnPrimo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPrimo
            // 
            this.btnPrimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrimo.Location = new System.Drawing.Point(12, 12);
            this.btnPrimo.Name = "btnPrimo";
            this.btnPrimo.Size = new System.Drawing.Size(454, 69);
            this.btnPrimo.TabIndex = 0;
            this.btnPrimo.Text = "Calcular Número Primo";
            this.btnPrimo.UseVisualStyleBackColor = true;
            this.btnPrimo.Click += new System.EventHandler(this.btnPrimo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 93);
            this.Controls.Add(this.btnPrimo);
            this.Name = "Form1";
            this.Text = "Extra 1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrimo;
    }
}

