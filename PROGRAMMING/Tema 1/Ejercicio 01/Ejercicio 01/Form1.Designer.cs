namespace Ejercicio_01
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fFormulario1));
            this.bPrimero = new System.Windows.Forms.Button();
            this.bSegundo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bPrimero
            // 
            this.bPrimero.BackColor = System.Drawing.Color.White;
            this.bPrimero.Location = new System.Drawing.Point(146, 88);
            this.bPrimero.Name = "bPrimero";
            this.bPrimero.Size = new System.Drawing.Size(243, 104);
            this.bPrimero.TabIndex = 0;
            this.bPrimero.TabStop = false;
            this.bPrimero.Text = "Primer Botón";
            this.bPrimero.UseVisualStyleBackColor = false;
            this.bPrimero.Click += new System.EventHandler(this.bPrimero_Click);
            // 
            // bSegundo
            // 
            this.bSegundo.BackColor = System.Drawing.Color.White;
            this.bSegundo.Location = new System.Drawing.Point(146, 321);
            this.bSegundo.Name = "bSegundo";
            this.bSegundo.Size = new System.Drawing.Size(243, 104);
            this.bSegundo.TabIndex = 1;
            this.bSegundo.TabStop = false;
            this.bSegundo.Text = "Segundo Botón";
            this.bSegundo.UseVisualStyleBackColor = false;
            this.bSegundo.Click += new System.EventHandler(this.bSegundo_Click);
            // 
            // fFormulario1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(539, 516);
            this.Controls.Add(this.bSegundo);
            this.Controls.Add(this.bPrimero);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "fFormulario1";
            this.Text = "Ejercicio 01";
            this.UseWaitCursor = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bPrimero;
        private System.Windows.Forms.Button bSegundo;
    }
}

