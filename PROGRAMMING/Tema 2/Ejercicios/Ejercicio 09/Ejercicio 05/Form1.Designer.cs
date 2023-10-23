namespace Ejercicio_05
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
            this.lResultado = new System.Windows.Forms.Label();
            this.textBoxNum1 = new System.Windows.Forms.TextBox();
            this.textBoxNum2 = new System.Windows.Forms.TextBox();
            this.textBoxResultado = new System.Windows.Forms.TextBox();
            this.bSuma = new System.Windows.Forms.Button();
            this.bResta = new System.Windows.Forms.Button();
            this.bMult = new System.Windows.Forms.Button();
            this.bDiv = new System.Windows.Forms.Button();
            this.bResto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lNum1
            // 
            this.lNum1.AutoSize = true;
            this.lNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lNum1.Location = new System.Drawing.Point(119, 125);
            this.lNum1.Name = "lNum1";
            this.lNum1.Size = new System.Drawing.Size(82, 20);
            this.lNum1.TabIndex = 0;
            this.lNum1.Text = "Número 1:";
            // 
            // lNum2
            // 
            this.lNum2.AutoSize = true;
            this.lNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lNum2.Location = new System.Drawing.Point(119, 173);
            this.lNum2.Name = "lNum2";
            this.lNum2.Size = new System.Drawing.Size(82, 20);
            this.lNum2.TabIndex = 1;
            this.lNum2.Text = "Número 2:";
            // 
            // lResultado
            // 
            this.lResultado.AutoSize = true;
            this.lResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lResultado.Location = new System.Drawing.Point(119, 220);
            this.lResultado.Name = "lResultado";
            this.lResultado.Size = new System.Drawing.Size(86, 20);
            this.lResultado.TabIndex = 2;
            this.lResultado.Text = "Resultado:";
            // 
            // textBoxNum1
            // 
            this.textBoxNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxNum1.Location = new System.Drawing.Point(207, 122);
            this.textBoxNum1.Name = "textBoxNum1";
            this.textBoxNum1.Size = new System.Drawing.Size(50, 26);
            this.textBoxNum1.TabIndex = 3;
            // 
            // textBoxNum2
            // 
            this.textBoxNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxNum2.Location = new System.Drawing.Point(207, 170);
            this.textBoxNum2.Name = "textBoxNum2";
            this.textBoxNum2.Size = new System.Drawing.Size(50, 26);
            this.textBoxNum2.TabIndex = 4;
            // 
            // textBoxResultado
            // 
            this.textBoxResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxResultado.Location = new System.Drawing.Point(207, 217);
            this.textBoxResultado.Name = "textBoxResultado";
            this.textBoxResultado.Size = new System.Drawing.Size(50, 26);
            this.textBoxResultado.TabIndex = 5;
            // 
            // bSuma
            // 
            this.bSuma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bSuma.Location = new System.Drawing.Point(341, 79);
            this.bSuma.Name = "bSuma";
            this.bSuma.Size = new System.Drawing.Size(121, 30);
            this.bSuma.TabIndex = 6;
            this.bSuma.Text = "Suma";
            this.bSuma.UseVisualStyleBackColor = true;
            this.bSuma.Click += new System.EventHandler(this.bSuma_Click);
            // 
            // bResta
            // 
            this.bResta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bResta.Location = new System.Drawing.Point(341, 125);
            this.bResta.Name = "bResta";
            this.bResta.Size = new System.Drawing.Size(121, 30);
            this.bResta.TabIndex = 7;
            this.bResta.Text = "Resta";
            this.bResta.UseVisualStyleBackColor = true;
            this.bResta.Click += new System.EventHandler(this.bResta_Click);
            // 
            // bMult
            // 
            this.bMult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bMult.Location = new System.Drawing.Point(341, 172);
            this.bMult.Name = "bMult";
            this.bMult.Size = new System.Drawing.Size(121, 30);
            this.bMult.TabIndex = 8;
            this.bMult.Text = "Multiplicación";
            this.bMult.UseVisualStyleBackColor = true;
            this.bMult.Click += new System.EventHandler(this.bMult_Click);
            // 
            // bDiv
            // 
            this.bDiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bDiv.Location = new System.Drawing.Point(341, 217);
            this.bDiv.Name = "bDiv";
            this.bDiv.Size = new System.Drawing.Size(121, 30);
            this.bDiv.TabIndex = 9;
            this.bDiv.Text = "División";
            this.bDiv.UseVisualStyleBackColor = true;
            this.bDiv.Click += new System.EventHandler(this.bDiv_Click);
            // 
            // bResto
            // 
            this.bResto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bResto.Location = new System.Drawing.Point(341, 263);
            this.bResto.Name = "bResto";
            this.bResto.Size = new System.Drawing.Size(121, 30);
            this.bResto.TabIndex = 10;
            this.bResto.Text = "Resto";
            this.bResto.UseVisualStyleBackColor = true;
            this.bResto.Click += new System.EventHandler(this.bResto_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 360);
            this.Controls.Add(this.bResto);
            this.Controls.Add(this.bDiv);
            this.Controls.Add(this.bMult);
            this.Controls.Add(this.bResta);
            this.Controls.Add(this.bSuma);
            this.Controls.Add(this.textBoxResultado);
            this.Controls.Add(this.textBoxNum2);
            this.Controls.Add(this.textBoxNum1);
            this.Controls.Add(this.lResultado);
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
        private System.Windows.Forms.Label lResultado;
        private System.Windows.Forms.TextBox textBoxNum1;
        private System.Windows.Forms.TextBox textBoxNum2;
        private System.Windows.Forms.TextBox textBoxResultado;
        private System.Windows.Forms.Button bSuma;
        private System.Windows.Forms.Button bResta;
        private System.Windows.Forms.Button bMult;
        private System.Windows.Forms.Button bDiv;
        private System.Windows.Forms.Button bResto;
    }
}

