namespace Ejercicio_06
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
            this.lNum1 = new System.Windows.Forms.Label();
            this.lNum2 = new System.Windows.Forms.Label();
            this.textBoxNum1 = new System.Windows.Forms.TextBox();
            this.textBoxNum2 = new System.Windows.Forms.TextBox();
            this.bDiv = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lNum1
            // 
            this.lNum1.AutoSize = true;
            this.lNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lNum1.Location = new System.Drawing.Point(102, 138);
            this.lNum1.Name = "lNum1";
            this.lNum1.Size = new System.Drawing.Size(82, 20);
            this.lNum1.TabIndex = 0;
            this.lNum1.Text = "Número 1:";
            // 
            // lNum2
            // 
            this.lNum2.AutoSize = true;
            this.lNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lNum2.Location = new System.Drawing.Point(102, 182);
            this.lNum2.Name = "lNum2";
            this.lNum2.Size = new System.Drawing.Size(82, 20);
            this.lNum2.TabIndex = 1;
            this.lNum2.Text = "Número 2:";
            // 
            // textBoxNum1
            // 
            this.textBoxNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxNum1.Location = new System.Drawing.Point(186, 135);
            this.textBoxNum1.Name = "textBoxNum1";
            this.textBoxNum1.Size = new System.Drawing.Size(109, 26);
            this.textBoxNum1.TabIndex = 2;
            // 
            // textBoxNum2
            // 
            this.textBoxNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxNum2.Location = new System.Drawing.Point(186, 179);
            this.textBoxNum2.Name = "textBoxNum2";
            this.textBoxNum2.Size = new System.Drawing.Size(109, 26);
            this.textBoxNum2.TabIndex = 3;
            // 
            // bDiv
            // 
            this.bDiv.Location = new System.Drawing.Point(107, 229);
            this.bDiv.Name = "bDiv";
            this.bDiv.Size = new System.Drawing.Size(188, 39);
            this.bDiv.TabIndex = 4;
            this.bDiv.Text = "Boton Resultado Division";
            this.bDiv.UseVisualStyleBackColor = true;
            this.bDiv.Click += new System.EventHandler(this.bDiv_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 395);
            this.Controls.Add(this.bDiv);
            this.Controls.Add(this.textBoxNum2);
            this.Controls.Add(this.textBoxNum1);
            this.Controls.Add(this.lNum2);
            this.Controls.Add(this.lNum1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lNum1;
        private System.Windows.Forms.Label lNum2;
        private System.Windows.Forms.TextBox textBoxNum1;
        private System.Windows.Forms.TextBox textBoxNum2;
        private System.Windows.Forms.Button bDiv;
    }
}

