namespace Ejercicio_02
{
    partial class fFormulario1
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
            this.tCuadro = new System.Windows.Forms.MaskedTextBox();
            this.lTexto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bPrimero
            // 
            this.bPrimero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.bPrimero.Location = new System.Drawing.Point(219, 202);
            this.bPrimero.Name = "bPrimero";
            this.bPrimero.Size = new System.Drawing.Size(334, 39);
            this.bPrimero.TabIndex = 0;
            this.bPrimero.Text = "Muestra el contenido del Cuadro de Texto";
            this.bPrimero.UseVisualStyleBackColor = true;
            this.bPrimero.Click += new System.EventHandler(this.bPrimero_Click);
            // 
            // bSegundo
            // 
            this.bSegundo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.bSegundo.Location = new System.Drawing.Point(219, 272);
            this.bSegundo.Name = "bSegundo";
            this.bSegundo.Size = new System.Drawing.Size(334, 39);
            this.bSegundo.TabIndex = 1;
            this.bSegundo.Text = "Cambia el color del formulario";
            this.bSegundo.UseVisualStyleBackColor = true;
            this.bSegundo.Click += new System.EventHandler(this.bSegundo_Click);
            // 
            // bTercero
            // 
            this.bTercero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.bTercero.Location = new System.Drawing.Point(219, 344);
            this.bTercero.Name = "bTercero";
            this.bTercero.Size = new System.Drawing.Size(334, 39);
            this.bTercero.TabIndex = 2;
            this.bTercero.Text = "Cambia el color del texto del Cuadro";
            this.bTercero.UseVisualStyleBackColor = true;
            this.bTercero.Click += new System.EventHandler(this.bTercero_Click);
            // 
            // tCuadro
            // 
            this.tCuadro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.tCuadro.Location = new System.Drawing.Point(219, 119);
            this.tCuadro.MaximumSize = new System.Drawing.Size(333, 60);
            this.tCuadro.Name = "tCuadro";
            this.tCuadro.Size = new System.Drawing.Size(333, 26);
            this.tCuadro.TabIndex = 3;
            this.tCuadro.Text = "Escribir aquí";
            // 
            // lTexto
            // 
            this.lTexto.AutoSize = true;
            this.lTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.lTexto.Location = new System.Drawing.Point(219, 60);
            this.lTexto.Name = "lTexto";
            this.lTexto.Size = new System.Drawing.Size(334, 39);
            this.lTexto.TabIndex = 4;
            this.lTexto.Text = "Mi Primer Formulario";
            // 
            // fFormulario1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 573);
            this.Controls.Add(this.lTexto);
            this.Controls.Add(this.tCuadro);
            this.Controls.Add(this.bTercero);
            this.Controls.Add(this.bSegundo);
            this.Controls.Add(this.bPrimero);
            this.Name = "fFormulario1";
            this.Text = "Ejercicio 02";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bPrimero;
        private System.Windows.Forms.Button bSegundo;
        private System.Windows.Forms.Button bTercero;
        private System.Windows.Forms.MaskedTextBox tCuadro;
        private System.Windows.Forms.Label lTexto;
    }
}

