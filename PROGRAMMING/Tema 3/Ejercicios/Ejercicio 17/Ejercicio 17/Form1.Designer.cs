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
            this.lblMult = new System.Windows.Forms.Label();
            this.btnMult = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMult
            // 
            this.lblMult.AutoSize = true;
            this.lblMult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMult.Location = new System.Drawing.Point(38, 35);
            this.lblMult.Name = "lblMult";
            this.lblMult.Size = new System.Drawing.Size(324, 20);
            this.lblMult.TabIndex = 0;
            this.lblMult.Text = "Muestra los múltiplos de 3, entre el 1 y el 100";
            // 
            // btnMult
            // 
            this.btnMult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMult.Location = new System.Drawing.Point(42, 72);
            this.btnMult.Name = "btnMult";
            this.btnMult.Size = new System.Drawing.Size(320, 32);
            this.btnMult.TabIndex = 1;
            this.btnMult.Text = "Mostrar Múltiplos de 3";
            this.btnMult.UseVisualStyleBackColor = true;
            this.btnMult.Click += new System.EventHandler(this.btnMult_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 148);
            this.Controls.Add(this.btnMult);
            this.Controls.Add(this.lblMult);
            this.Name = "Form1";
            this.Text = "Ejercicio 17";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMult;
        private System.Windows.Forms.Button btnMult;
    }
}

