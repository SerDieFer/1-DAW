namespace Ejercicio_11
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
            this.textBoxDinero = new System.Windows.Forms.TextBox();
            this.textBoxTasa = new System.Windows.Forms.TextBox();
            this.lDinero = new System.Windows.Forms.Label();
            this.lTasa = new System.Windows.Forms.Label();
            this.bCalculo = new System.Windows.Forms.Button();
            this.lResultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxDinero
            // 
            this.textBoxDinero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDinero.Location = new System.Drawing.Point(252, 60);
            this.textBoxDinero.Name = "textBoxDinero";
            this.textBoxDinero.Size = new System.Drawing.Size(100, 26);
            this.textBoxDinero.TabIndex = 0;
            // 
            // textBoxTasa
            // 
            this.textBoxTasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTasa.Location = new System.Drawing.Point(252, 107);
            this.textBoxTasa.Name = "textBoxTasa";
            this.textBoxTasa.Size = new System.Drawing.Size(100, 26);
            this.textBoxTasa.TabIndex = 1;
            // 
            // lDinero
            // 
            this.lDinero.AutoSize = true;
            this.lDinero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDinero.Location = new System.Drawing.Point(110, 63);
            this.lDinero.Name = "lDinero";
            this.lDinero.Size = new System.Drawing.Size(136, 20);
            this.lDinero.TabIndex = 2;
            this.lDinero.Text = "Dinero Ingresado:";
            // 
            // lTasa
            // 
            this.lTasa.AutoSize = true;
            this.lTasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTasa.Location = new System.Drawing.Point(99, 110);
            this.lTasa.Name = "lTasa";
            this.lTasa.Size = new System.Drawing.Size(147, 20);
            this.lTasa.TabIndex = 3;
            this.lTasa.Text = "Tasa Interés Anual:";
            // 
            // bCalculo
            // 
            this.bCalculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCalculo.Location = new System.Drawing.Point(103, 161);
            this.bCalculo.Name = "bCalculo";
            this.bCalculo.Size = new System.Drawing.Size(249, 39);
            this.bCalculo.TabIndex = 4;
            this.bCalculo.Text = "Calcular Ingresos Anuales";
            this.bCalculo.UseVisualStyleBackColor = true;
            this.bCalculo.Click += new System.EventHandler(this.bCalculo_Click);
            // 
            // lResultado
            // 
            this.lResultado.AutoSize = true;
            this.lResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lResultado.Location = new System.Drawing.Point(99, 231);
            this.lResultado.Name = "lResultado";
            this.lResultado.Size = new System.Drawing.Size(0, 20);
            this.lResultado.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 302);
            this.Controls.Add(this.lResultado);
            this.Controls.Add(this.bCalculo);
            this.Controls.Add(this.lTasa);
            this.Controls.Add(this.lDinero);
            this.Controls.Add(this.textBoxTasa);
            this.Controls.Add(this.textBoxDinero);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDinero;
        private System.Windows.Forms.TextBox textBoxTasa;
        private System.Windows.Forms.Label lDinero;
        private System.Windows.Forms.Label lTasa;
        private System.Windows.Forms.Button bCalculo;
        private System.Windows.Forms.Label lResultado;
    }
}

