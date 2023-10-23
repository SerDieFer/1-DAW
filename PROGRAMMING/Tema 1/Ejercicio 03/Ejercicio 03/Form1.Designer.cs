namespace Ejercicio_03
{
    partial class fFormulario03
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
            this.bPrimero = new System.Windows.Forms.Button();
            this.bSegundo = new System.Windows.Forms.Button();
            this.bTercero = new System.Windows.Forms.Button();
            this.tTítulo = new System.Windows.Forms.Label();
            this.tCuadrado = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bPrimero
            // 
            this.bPrimero.Location = new System.Drawing.Point(69, 150);
            this.bPrimero.Name = "bPrimero";
            this.bPrimero.Size = new System.Drawing.Size(387, 36);
            this.bPrimero.TabIndex = 0;
            this.bPrimero.Text = "Botón 1";
            this.bPrimero.UseVisualStyleBackColor = true;
            this.bPrimero.Click += new System.EventHandler(this.bPrimero_Click);
            // 
            // bSegundo
            // 
            this.bSegundo.Location = new System.Drawing.Point(69, 208);
            this.bSegundo.Name = "bSegundo";
            this.bSegundo.Size = new System.Drawing.Size(387, 36);
            this.bSegundo.TabIndex = 1;
            this.bSegundo.Text = "Botón 2";
            this.bSegundo.UseVisualStyleBackColor = true;
            this.bSegundo.Click += new System.EventHandler(this.bSegundo_Click);
            // 
            // bTercero
            // 
            this.bTercero.Location = new System.Drawing.Point(69, 267);
            this.bTercero.Name = "bTercero";
            this.bTercero.Size = new System.Drawing.Size(387, 36);
            this.bTercero.TabIndex = 2;
            this.bTercero.Text = "Borrar Texto";
            this.bTercero.UseVisualStyleBackColor = true;
            this.bTercero.Click += new System.EventHandler(this.bTercero_Click);
            // 
            // tTítulo
            // 
            this.tTítulo.AutoSize = true;
            this.tTítulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tTítulo.Location = new System.Drawing.Point(65, 95);
            this.tTítulo.Name = "tTítulo";
            this.tTítulo.Size = new System.Drawing.Size(113, 20);
            this.tTítulo.TabIndex = 3;
            this.tTítulo.Text = "Botón Pulsado";
            // 
            // tCuadrado
            // 
            this.tCuadrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tCuadrado.Location = new System.Drawing.Point(185, 94);
            this.tCuadrado.Name = "tCuadrado";
            this.tCuadrado.Size = new System.Drawing.Size(271, 23);
            this.tCuadrado.TabIndex = 4;
            // 
            // fFormulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(531, 397);
            this.Controls.Add(this.tCuadrado);
            this.Controls.Add(this.tTítulo);
            this.Controls.Add(this.bTercero);
            this.Controls.Add(this.bSegundo);
            this.Controls.Add(this.bPrimero);
            this.Name = "fFormulario";
            this.Text = "Ejercicio 03";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bPrimero;
        private System.Windows.Forms.Button bSegundo;
        private System.Windows.Forms.Button bTercero;
        private System.Windows.Forms.Label tTítulo;
        private System.Windows.Forms.TextBox tCuadrado;
    }
}

