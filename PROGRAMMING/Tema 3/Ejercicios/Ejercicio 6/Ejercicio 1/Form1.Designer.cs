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
            this.lblNota = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.btnNota = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNota
            // 
            this.lblNota.AutoSize = true;
            this.lblNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNota.Location = new System.Drawing.Point(91, 76);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(51, 20);
            this.lblNota.TabIndex = 0;
            this.lblNota.Text = "Nota :";
            // 
            // txtNota
            // 
            this.txtNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNota.Location = new System.Drawing.Point(148, 73);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(146, 26);
            this.txtNota.TabIndex = 1;
            // 
            // btnNota
            // 
            this.btnNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnNota.Location = new System.Drawing.Point(95, 129);
            this.btnNota.Name = "btnNota";
            this.btnNota.Size = new System.Drawing.Size(199, 29);
            this.btnNota.TabIndex = 2;
            this.btnNota.Text = "Resultado";
            this.btnNota.UseVisualStyleBackColor = true;
            this.btnNota.Click += new System.EventHandler(this.btnNota_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 218);
            this.Controls.Add(this.btnNota);
            this.Controls.Add(this.txtNota);
            this.Controls.Add(this.lblNota);
            this.Name = "Form1";
            this.Text = "Ejercicio 6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Button btnNota;
    }
}

