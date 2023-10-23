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
            this.lblNum = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.btnCompar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum.Location = new System.Drawing.Point(104, 76);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(73, 20);
            this.lblNum.TabIndex = 0;
            this.lblNum.Text = "Número: ";
            // 
            // txtNum
            // 
            this.txtNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNum.Location = new System.Drawing.Point(183, 73);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(111, 26);
            this.txtNum.TabIndex = 1;
            // 
            // btnCompar
            // 
            this.btnCompar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCompar.Location = new System.Drawing.Point(108, 124);
            this.btnCompar.Name = "btnCompar";
            this.btnCompar.Size = new System.Drawing.Size(186, 29);
            this.btnCompar.TabIndex = 2;
            this.btnCompar.Text = "Comparar";
            this.btnCompar.UseVisualStyleBackColor = true;
            this.btnCompar.Click += new System.EventHandler(this.btnCompar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 201);
            this.Controls.Add(this.btnCompar);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.lblNum);
            this.Name = "Form1";
            this.Text = "Ejercicio 1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Button btnCompar;
    }
}

