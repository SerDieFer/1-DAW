namespace Ejercicio_17
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
            this.lblNum = new System.Windows.Forms.Label();
            this.btnPrimo = new System.Windows.Forms.Button();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum.Location = new System.Drawing.Point(31, 36);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(69, 20);
            this.lblNum.TabIndex = 0;
            this.lblNum.Text = "Número:";
            // 
            // btnPrimo
            // 
            this.btnPrimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrimo.Location = new System.Drawing.Point(35, 77);
            this.btnPrimo.Name = "btnPrimo";
            this.btnPrimo.Size = new System.Drawing.Size(251, 32);
            this.btnPrimo.TabIndex = 1;
            this.btnPrimo.Text = "Averiguar si es primo";
            this.btnPrimo.UseVisualStyleBackColor = true;
            this.btnPrimo.Click += new System.EventHandler(this.btnPrimo_Click);
            // 
            // txtNum
            // 
            this.txtNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNum.Location = new System.Drawing.Point(106, 33);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(180, 26);
            this.txtNum.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 140);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.btnPrimo);
            this.Controls.Add(this.lblNum);
            this.Name = "Form1";
            this.Text = "Ejercicio 27";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Button btnPrimo;
        private System.Windows.Forms.TextBox txtNum;
    }
}

