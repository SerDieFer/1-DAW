namespace Ejercicio_07
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
            this.lAltura = new System.Windows.Forms.Label();
            this.textBoxCms = new System.Windows.Forms.TextBox();
            this.lCms = new System.Windows.Forms.Label();
            this.bResultado = new System.Windows.Forms.Button();
            this.lResultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lAltura
            // 
            this.lAltura.AutoSize = true;
            this.lAltura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lAltura.Location = new System.Drawing.Point(76, 42);
            this.lAltura.Name = "lAltura";
            this.lAltura.Size = new System.Drawing.Size(59, 20);
            this.lAltura.TabIndex = 0;
            this.lAltura.Text = "Altura: ";
            // 
            // textBoxCms
            // 
            this.textBoxCms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxCms.Location = new System.Drawing.Point(131, 39);
            this.textBoxCms.Name = "textBoxCms";
            this.textBoxCms.Size = new System.Drawing.Size(55, 26);
            this.textBoxCms.TabIndex = 1;
            // 
            // lCms
            // 
            this.lCms.AutoSize = true;
            this.lCms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lCms.Location = new System.Drawing.Point(192, 42);
            this.lCms.Name = "lCms";
            this.lCms.Size = new System.Drawing.Size(38, 20);
            this.lCms.TabIndex = 2;
            this.lCms.Text = "cms";
            // 
            // bResultado
            // 
            this.bResultado.Location = new System.Drawing.Point(80, 89);
            this.bResultado.Name = "bResultado";
            this.bResultado.Size = new System.Drawing.Size(149, 29);
            this.bResultado.TabIndex = 3;
            this.bResultado.Text = "Resultado";
            this.bResultado.UseVisualStyleBackColor = true;
            this.bResultado.Click += new System.EventHandler(this.bResultado_Click);
            // 
            // lResultado
            // 
            this.lResultado.AutoSize = true;
            this.lResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lResultado.Location = new System.Drawing.Point(76, 160);
            this.lResultado.Name = "lResultado";
            this.lResultado.Size = new System.Drawing.Size(171, 20);
            this.lResultado.TabIndex = 4;
            this.lResultado.Text = "Mide 1 metro y 85 cms.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 223);
            this.Controls.Add(this.lResultado);
            this.Controls.Add(this.bResultado);
            this.Controls.Add(this.lCms);
            this.Controls.Add(this.textBoxCms);
            this.Controls.Add(this.lAltura);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lAltura;
        private System.Windows.Forms.TextBox textBoxCms;
        private System.Windows.Forms.Label lCms;
        private System.Windows.Forms.Button bResultado;
        private System.Windows.Forms.Label lResultado;
    }
}

