namespace Ejercicio10
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
            this.lEuro = new System.Windows.Forms.Label();
            this.lPeseta = new System.Windows.Forms.Label();
            this.textBoxEuros = new System.Windows.Forms.TextBox();
            this.textBoxPesetas = new System.Windows.Forms.TextBox();
            this.bEuros = new System.Windows.Forms.Button();
            this.bPesetas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lEuro
            // 
            this.lEuro.AutoSize = true;
            this.lEuro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEuro.Location = new System.Drawing.Point(107, 92);
            this.lEuro.Name = "lEuro";
            this.lEuro.Size = new System.Drawing.Size(55, 20);
            this.lEuro.TabIndex = 0;
            this.lEuro.Text = "Euros:";
            // 
            // lPeseta
            // 
            this.lPeseta.AutoSize = true;
            this.lPeseta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPeseta.Location = new System.Drawing.Point(107, 128);
            this.lPeseta.Name = "lPeseta";
            this.lPeseta.Size = new System.Drawing.Size(71, 20);
            this.lPeseta.TabIndex = 1;
            this.lPeseta.Text = "Pesetas:";
            // 
            // textBoxEuros
            // 
            this.textBoxEuros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEuros.Location = new System.Drawing.Point(198, 89);
            this.textBoxEuros.Name = "textBoxEuros";
            this.textBoxEuros.Size = new System.Drawing.Size(158, 26);
            this.textBoxEuros.TabIndex = 2;
            // 
            // textBoxPesetas
            // 
            this.textBoxPesetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesetas.Location = new System.Drawing.Point(198, 125);
            this.textBoxPesetas.Name = "textBoxPesetas";
            this.textBoxPesetas.Size = new System.Drawing.Size(158, 26);
            this.textBoxPesetas.TabIndex = 3;
            // 
            // bEuros
            // 
            this.bEuros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEuros.Location = new System.Drawing.Point(111, 174);
            this.bEuros.Name = "bEuros";
            this.bEuros.Size = new System.Drawing.Size(245, 36);
            this.bEuros.TabIndex = 4;
            this.bEuros.Text = "Pasar a Pesetas";
            this.bEuros.UseVisualStyleBackColor = true;
            this.bEuros.Click += new System.EventHandler(this.bEuros_Click);
            // 
            // bPesetas
            // 
            this.bPesetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPesetas.Location = new System.Drawing.Point(111, 229);
            this.bPesetas.Name = "bPesetas";
            this.bPesetas.Size = new System.Drawing.Size(245, 36);
            this.bPesetas.TabIndex = 5;
            this.bPesetas.Text = "Pasar a Euros";
            this.bPesetas.UseVisualStyleBackColor = true;
            this.bPesetas.Click += new System.EventHandler(this.bPesetas_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 381);
            this.Controls.Add(this.bPesetas);
            this.Controls.Add(this.bEuros);
            this.Controls.Add(this.textBoxPesetas);
            this.Controls.Add(this.textBoxEuros);
            this.Controls.Add(this.lPeseta);
            this.Controls.Add(this.lEuro);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lEuro;
        private System.Windows.Forms.Label lPeseta;
        private System.Windows.Forms.TextBox textBoxEuros;
        private System.Windows.Forms.TextBox textBoxPesetas;
        private System.Windows.Forms.Button bEuros;
        private System.Windows.Forms.Button bPesetas;
    }
}

