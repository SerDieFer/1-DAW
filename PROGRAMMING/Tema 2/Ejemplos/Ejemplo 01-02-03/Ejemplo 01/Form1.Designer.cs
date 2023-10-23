namespace Ejemplo_01
{
    partial class fFormulario2
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
            this.lNum = new System.Windows.Forms.Label();
            this.textBoxNum = new System.Windows.Forms.TextBox();
            this.bMostrarNumString = new System.Windows.Forms.Button();
            this.bMostrarEnteras = new System.Windows.Forms.Button();
            this.bMostrarDouble = new System.Windows.Forms.Button();
            this.bMostrarFloat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lNum
            // 
            this.lNum.AutoSize = true;
            this.lNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lNum.Location = new System.Drawing.Point(279, 91);
            this.lNum.Name = "lNum";
            this.lNum.Size = new System.Drawing.Size(84, 24);
            this.lNum.TabIndex = 0;
            this.lNum.Text = "Número:";
            // 
            // textBoxNum
            // 
            this.textBoxNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxNum.Location = new System.Drawing.Point(369, 91);
            this.textBoxNum.Name = "textBoxNum";
            this.textBoxNum.Size = new System.Drawing.Size(69, 26);
            this.textBoxNum.TabIndex = 2;
            // 
            // bMostrarNumString
            // 
            this.bMostrarNumString.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bMostrarNumString.Location = new System.Drawing.Point(283, 146);
            this.bMostrarNumString.Name = "bMostrarNumString";
            this.bMostrarNumString.Size = new System.Drawing.Size(155, 33);
            this.bMostrarNumString.TabIndex = 4;
            this.bMostrarNumString.Text = "Valor";
            this.bMostrarNumString.UseVisualStyleBackColor = true;
            this.bMostrarNumString.Click += new System.EventHandler(this.bMostrar_Click);
            // 
            // bMostrarEnteras
            // 
            this.bMostrarEnteras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bMostrarEnteras.Location = new System.Drawing.Point(283, 207);
            this.bMostrarEnteras.Name = "bMostrarEnteras";
            this.bMostrarEnteras.Size = new System.Drawing.Size(155, 33);
            this.bMostrarEnteras.TabIndex = 5;
            this.bMostrarEnteras.Text = "Variable Entera";
            this.bMostrarEnteras.UseVisualStyleBackColor = true;
            this.bMostrarEnteras.Click += new System.EventHandler(this.bMostrarEnteras_Click);
            // 
            // bMostrarDouble
            // 
            this.bMostrarDouble.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bMostrarDouble.Location = new System.Drawing.Point(283, 265);
            this.bMostrarDouble.Name = "bMostrarDouble";
            this.bMostrarDouble.Size = new System.Drawing.Size(155, 33);
            this.bMostrarDouble.TabIndex = 6;
            this.bMostrarDouble.Text = "Double";
            this.bMostrarDouble.UseVisualStyleBackColor = true;
            this.bMostrarDouble.Click += new System.EventHandler(this.bMostrarDouble_Click);
            // 
            // bMostrarFloat
            // 
            this.bMostrarFloat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bMostrarFloat.Location = new System.Drawing.Point(283, 324);
            this.bMostrarFloat.Name = "bMostrarFloat";
            this.bMostrarFloat.Size = new System.Drawing.Size(155, 33);
            this.bMostrarFloat.TabIndex = 7;
            this.bMostrarFloat.Text = "Float";
            this.bMostrarFloat.UseVisualStyleBackColor = true;
            this.bMostrarFloat.Click += new System.EventHandler(this.bMostrarFloat_Click);
            // 
            // fFormulario2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 495);
            this.Controls.Add(this.bMostrarFloat);
            this.Controls.Add(this.bMostrarDouble);
            this.Controls.Add(this.bMostrarEnteras);
            this.Controls.Add(this.bMostrarNumString);
            this.Controls.Add(this.textBoxNum);
            this.Controls.Add(this.lNum);
            this.Name = "fFormulario2";
            this.Text = "Ejemplo 02";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lNum;
        private System.Windows.Forms.TextBox textBoxNum;
        private System.Windows.Forms.Button bMostrarNumString;
        private System.Windows.Forms.Button bMostrarEnteras;
        private System.Windows.Forms.Button bMostrarDouble;
        private System.Windows.Forms.Button bMostrarFloat;
    }
}

