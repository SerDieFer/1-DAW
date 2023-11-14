namespace Ejercicio_1
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
            this.lblValor = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.lblResultados = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(91, 76);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(54, 20);
            this.lblValor.TabIndex = 0;
            this.lblValor.Text = "Valor :";
            // 
            // txtValor
            // 
            this.txtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(151, 73);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(143, 26);
            this.txtValor.TabIndex = 1;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCalcular.Location = new System.Drawing.Point(95, 129);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(199, 29);
            this.btnCalcular.TabIndex = 2;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // lblResultados
            // 
            this.lblResultados.AutoSize = true;
            this.lblResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultados.Location = new System.Drawing.Point(126, 201);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(0, 20);
            this.lblResultados.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 478);
            this.Controls.Add(this.lblResultados);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.lblValor);
            this.Name = "Form1";
            this.Text = "Ejercicio 10";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label lblResultados;
    }
}

