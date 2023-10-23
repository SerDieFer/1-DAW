namespace Ejercicio_14
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
            this.textBoxNum1 = new System.Windows.Forms.TextBox();
            this.textBoxNum2 = new System.Windows.Forms.TextBox();
            this.lNum2 = new System.Windows.Forms.Label();
            this.bMenor = new System.Windows.Forms.Button();
            this.bMayor = new System.Windows.Forms.Button();
            this.bIgual = new System.Windows.Forms.Button();
            this.bNoIgual = new System.Windows.Forms.Button();
            this.lResultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lNum1
            // 
            this.lNum1.AutoSize = true;
            this.lNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNum1.Location = new System.Drawing.Point(177, 118);
            this.lNum1.Name = "lNum1";
            this.lNum1.Size = new System.Drawing.Size(86, 20);
            this.lNum1.TabIndex = 0;
            this.lNum1.Text = "Número 1: ";
            // 
            // textBoxNum1
            // 
            this.textBoxNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNum1.Location = new System.Drawing.Point(269, 115);
            this.textBoxNum1.Name = "textBoxNum1";
            this.textBoxNum1.Size = new System.Drawing.Size(310, 26);
            this.textBoxNum1.TabIndex = 1;
            // 
            // textBoxNum2
            // 
            this.textBoxNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNum2.Location = new System.Drawing.Point(269, 275);
            this.textBoxNum2.Name = "textBoxNum2";
            this.textBoxNum2.Size = new System.Drawing.Size(310, 26);
            this.textBoxNum2.TabIndex = 3;
            // 
            // lNum2
            // 
            this.lNum2.AutoSize = true;
            this.lNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNum2.Location = new System.Drawing.Point(177, 278);
            this.lNum2.Name = "lNum2";
            this.lNum2.Size = new System.Drawing.Size(86, 20);
            this.lNum2.TabIndex = 2;
            this.lNum2.Text = "Número 2: ";
            // 
            // bMenor
            // 
            this.bMenor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMenor.Location = new System.Drawing.Point(181, 185);
            this.bMenor.Name = "bMenor";
            this.bMenor.Size = new System.Drawing.Size(47, 47);
            this.bMenor.TabIndex = 4;
            this.bMenor.Text = "<";
            this.bMenor.UseVisualStyleBackColor = true;
            this.bMenor.Click += new System.EventHandler(this.bMenor_Click);
            // 
            // bMayor
            // 
            this.bMayor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMayor.Location = new System.Drawing.Point(303, 185);
            this.bMayor.Name = "bMayor";
            this.bMayor.Size = new System.Drawing.Size(47, 47);
            this.bMayor.TabIndex = 5;
            this.bMayor.Text = ">";
            this.bMayor.UseVisualStyleBackColor = true;
            this.bMayor.Click += new System.EventHandler(this.bMayor_Click);
            // 
            // bIgual
            // 
            this.bIgual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bIgual.Location = new System.Drawing.Point(426, 185);
            this.bIgual.Name = "bIgual";
            this.bIgual.Size = new System.Drawing.Size(47, 47);
            this.bIgual.TabIndex = 6;
            this.bIgual.Text = "==";
            this.bIgual.UseVisualStyleBackColor = true;
            this.bIgual.Click += new System.EventHandler(this.bIgual_Click);
            // 
            // bNoIgual
            // 
            this.bNoIgual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNoIgual.Location = new System.Drawing.Point(532, 185);
            this.bNoIgual.Name = "bNoIgual";
            this.bNoIgual.Size = new System.Drawing.Size(47, 47);
            this.bNoIgual.TabIndex = 7;
            this.bNoIgual.Text = "!=";
            this.bNoIgual.UseVisualStyleBackColor = true;
            this.bNoIgual.Click += new System.EventHandler(this.bNoIgual_Click);
            // 
            // lResultado
            // 
            this.lResultado.AutoSize = true;
            this.lResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lResultado.Location = new System.Drawing.Point(376, 362);
            this.lResultado.Name = "lResultado";
            this.lResultado.Size = new System.Drawing.Size(0, 20);
            this.lResultado.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lResultado);
            this.Controls.Add(this.bNoIgual);
            this.Controls.Add(this.bIgual);
            this.Controls.Add(this.bMayor);
            this.Controls.Add(this.bMenor);
            this.Controls.Add(this.textBoxNum2);
            this.Controls.Add(this.lNum2);
            this.Controls.Add(this.textBoxNum1);
            this.Controls.Add(this.lNum1);
            this.Name = "Form1";
            this.Text = "Ejercicio 14";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lNum1;
        private System.Windows.Forms.TextBox textBoxNum1;
        private System.Windows.Forms.TextBox textBoxNum2;
        private System.Windows.Forms.Label lNum2;
        private System.Windows.Forms.Button bMenor;
        private System.Windows.Forms.Button bMayor;
        private System.Windows.Forms.Button bIgual;
        private System.Windows.Forms.Button bNoIgual;
        private System.Windows.Forms.Label lResultado;
    }
}

