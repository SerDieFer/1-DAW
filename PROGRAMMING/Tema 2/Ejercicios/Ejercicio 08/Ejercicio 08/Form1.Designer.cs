namespace Ejercicio_08
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
            this.lNum3 = new System.Windows.Forms.Label();
            this.textBoxNum1 = new System.Windows.Forms.TextBox();
            this.textBoxNum2 = new System.Windows.Forms.TextBox();
            this.textBoxNum3 = new System.Windows.Forms.TextBox();
            this.bResultado = new System.Windows.Forms.Button();
            this.lResultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lNum1
            // 
            this.lNum1.AutoSize = true;
            this.lNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lNum1.Location = new System.Drawing.Point(130, 128);
            this.lNum1.Name = "lNum1";
            this.lNum1.Size = new System.Drawing.Size(82, 20);
            this.lNum1.TabIndex = 0;
            this.lNum1.Text = "Número 1:";
            // 
            // lNum2
            // 
            this.lNum2.AutoSize = true;
            this.lNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lNum2.Location = new System.Drawing.Point(130, 167);
            this.lNum2.Name = "lNum2";
            this.lNum2.Size = new System.Drawing.Size(82, 20);
            this.lNum2.TabIndex = 1;
            this.lNum2.Text = "Número 2:";
            // 
            // lNum3
            // 
            this.lNum3.AutoSize = true;
            this.lNum3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lNum3.Location = new System.Drawing.Point(130, 206);
            this.lNum3.Name = "lNum3";
            this.lNum3.Size = new System.Drawing.Size(82, 20);
            this.lNum3.TabIndex = 2;
            this.lNum3.Text = "Número 3:";
            // 
            // textBoxNum1
            // 
            this.textBoxNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxNum1.Location = new System.Drawing.Point(218, 125);
            this.textBoxNum1.Name = "textBoxNum1";
            this.textBoxNum1.Size = new System.Drawing.Size(70, 26);
            this.textBoxNum1.TabIndex = 3;
            // 
            // textBoxNum2
            // 
            this.textBoxNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxNum2.Location = new System.Drawing.Point(218, 164);
            this.textBoxNum2.Name = "textBoxNum2";
            this.textBoxNum2.Size = new System.Drawing.Size(70, 26);
            this.textBoxNum2.TabIndex = 4;
            // 
            // textBoxNum3
            // 
            this.textBoxNum3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxNum3.Location = new System.Drawing.Point(218, 203);
            this.textBoxNum3.Name = "textBoxNum3";
            this.textBoxNum3.Size = new System.Drawing.Size(70, 26);
            this.textBoxNum3.TabIndex = 5;
            // 
            // bResultado
            // 
            this.bResultado.Location = new System.Drawing.Point(134, 256);
            this.bResultado.Name = "bResultado";
            this.bResultado.Size = new System.Drawing.Size(154, 34);
            this.bResultado.TabIndex = 6;
            this.bResultado.Text = "Resultado";
            this.bResultado.UseVisualStyleBackColor = true;
            this.bResultado.Click += new System.EventHandler(this.bResultado_Click);
            // 
            // lResultado
            // 
            this.lResultado.AutoSize = true;
            this.lResultado.Location = new System.Drawing.Point(159, 331);
            this.lResultado.Name = "lResultado";
            this.lResultado.Size = new System.Drawing.Size(0, 13);
            this.lResultado.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 416);
            this.Controls.Add(this.lResultado);
            this.Controls.Add(this.bResultado);
            this.Controls.Add(this.textBoxNum3);
            this.Controls.Add(this.textBoxNum2);
            this.Controls.Add(this.textBoxNum1);
            this.Controls.Add(this.lNum3);
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
        private System.Windows.Forms.Label lNum3;
        private System.Windows.Forms.TextBox textBoxNum1;
        private System.Windows.Forms.TextBox textBoxNum2;
        private System.Windows.Forms.TextBox textBoxNum3;
        private System.Windows.Forms.Button bResultado;
        private System.Windows.Forms.Label lResultado;
    }
}

