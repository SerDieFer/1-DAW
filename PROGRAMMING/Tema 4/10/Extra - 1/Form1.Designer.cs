namespace Extra___1
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
            this.btnmcm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnmcm
            // 
            this.btnmcm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmcm.Location = new System.Drawing.Point(12, 12);
            this.btnmcm.Name = "btnmcm";
            this.btnmcm.Size = new System.Drawing.Size(454, 69);
            this.btnmcm.TabIndex = 0;
            this.btnmcm.Text = "Calcular";
            this.btnmcm.UseVisualStyleBackColor = true;
            this.btnmcm.Click += new System.EventHandler(this.btnmcm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 93);
            this.Controls.Add(this.btnmcm);
            this.Name = "Form1";
            this.Text = "10";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnmcm;
    }
}

