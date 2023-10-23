namespace Ejercicio_04
{
    partial class fFormulario
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
            this.tCuadroNum1 = new System.Windows.Forms.TextBox();
            this.bSumar = new System.Windows.Forms.Button();
            this.tCuadroNum2 = new System.Windows.Forms.TextBox();
            this.lNum1 = new System.Windows.Forms.Label();
            this.lNum2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tCuadroNum1
            // 
            this.tCuadroNum1.Location = new System.Drawing.Point(203, 131);
            this.tCuadroNum1.Name = "tCuadroNum1";
            this.tCuadroNum1.Size = new System.Drawing.Size(56, 20);
            this.tCuadroNum1.TabIndex = 0;
            // 
            // bSumar
            // 
            this.bSumar.Location = new System.Drawing.Point(203, 241);
            this.bSumar.Name = "bSumar";
            this.bSumar.Size = new System.Drawing.Size(174, 44);
            this.bSumar.TabIndex = 1;
            this.bSumar.Text = "Calcular la suma";
            this.bSumar.UseVisualStyleBackColor = true;
            this.bSumar.Click += new System.EventHandler(this.bSumar_Click);
            // 
            // tCuadroNum2
            // 
            this.tCuadroNum2.Location = new System.Drawing.Point(203, 170);
            this.tCuadroNum2.Name = "tCuadroNum2";
            this.tCuadroNum2.Size = new System.Drawing.Size(56, 20);
            this.tCuadroNum2.TabIndex = 2;
            // 
            // lNum1
            // 
            this.lNum1.AutoSize = true;
            this.lNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lNum1.Location = new System.Drawing.Point(299, 131);
            this.lNum1.Name = "lNum1";
            this.lNum1.Size = new System.Drawing.Size(78, 20);
            this.lNum1.TabIndex = 3;
            this.lNum1.Text = "Número 1";
            // 
            // lNum2
            // 
            this.lNum2.AutoSize = true;
            this.lNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lNum2.Location = new System.Drawing.Point(299, 170);
            this.lNum2.Name = "lNum2";
            this.lNum2.Size = new System.Drawing.Size(78, 20);
            this.lNum2.TabIndex = 4;
            this.lNum2.Text = "Número 2";
            // 
            // fFormulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 462);
            this.Controls.Add(this.lNum2);
            this.Controls.Add(this.lNum1);
            this.Controls.Add(this.tCuadroNum2);
            this.Controls.Add(this.bSumar);
            this.Controls.Add(this.tCuadroNum1);
            this.Name = "fFormulario";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tCuadroNum1;
        private System.Windows.Forms.Button bSumar;
        private System.Windows.Forms.TextBox tCuadroNum2;
        private System.Windows.Forms.Label lNum1;
        private System.Windows.Forms.Label lNum2;
    }
}

