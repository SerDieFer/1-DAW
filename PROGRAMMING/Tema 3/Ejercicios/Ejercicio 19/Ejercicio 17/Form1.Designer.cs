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
            this.lblFac = new System.Windows.Forms.Label();
            this.btnFac = new System.Windows.Forms.Button();
            this.txtFac = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblFac
            // 
            this.lblFac.AutoSize = true;
            this.lblFac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFac.Location = new System.Drawing.Point(46, 37);
            this.lblFac.Name = "lblFac";
            this.lblFac.Size = new System.Drawing.Size(135, 20);
            this.lblFac.TabIndex = 0;
            this.lblFac.Text = "Calcular Factorial:";
            // 
            // btnFac
            // 
            this.btnFac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFac.Location = new System.Drawing.Point(50, 69);
            this.btnFac.Name = "btnFac";
            this.btnFac.Size = new System.Drawing.Size(246, 32);
            this.btnFac.TabIndex = 1;
            this.btnFac.Text = "Mostrar Factorial";
            this.btnFac.UseVisualStyleBackColor = true;
            this.btnFac.Click += new System.EventHandler(this.btnFac_Click);
            // 
            // txtFac
            // 
            this.txtFac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFac.Location = new System.Drawing.Point(182, 34);
            this.txtFac.Name = "txtFac";
            this.txtFac.Size = new System.Drawing.Size(114, 26);
            this.txtFac.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 148);
            this.Controls.Add(this.txtFac);
            this.Controls.Add(this.btnFac);
            this.Controls.Add(this.lblFac);
            this.Name = "Form1";
            this.Text = "Ejercicio 19";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFac;
        private System.Windows.Forms.Button btnFac;
        private System.Windows.Forms.TextBox txtFac;
    }
}

