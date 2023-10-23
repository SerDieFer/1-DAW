namespace Ejercicio_12
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
            this.txtNum = new System.Windows.Forms.TextBox();
            this.btnWhile = new System.Windows.Forms.Button();
            this.btnFor = new System.Windows.Forms.Button();
            this.lblNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNum
            // 
            this.txtNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNum.Location = new System.Drawing.Point(56, 86);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(348, 26);
            this.txtNum.TabIndex = 3;
            // 
            // btnWhile
            // 
            this.btnWhile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWhile.Location = new System.Drawing.Point(56, 127);
            this.btnWhile.Name = "btnWhile";
            this.btnWhile.Size = new System.Drawing.Size(170, 33);
            this.btnWhile.TabIndex = 4;
            this.btnWhile.Text = "While";
            this.btnWhile.UseVisualStyleBackColor = true;
            this.btnWhile.Click += new System.EventHandler(this.btnWhile_Click);
            // 
            // btnFor
            // 
            this.btnFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFor.Location = new System.Drawing.Point(234, 127);
            this.btnFor.Name = "btnFor";
            this.btnFor.Size = new System.Drawing.Size(170, 33);
            this.btnFor.TabIndex = 6;
            this.btnFor.Text = "For";
            this.btnFor.UseVisualStyleBackColor = true;
            this.btnFor.Click += new System.EventHandler(this.btnFor_Click);
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum.Location = new System.Drawing.Point(76, 54);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(308, 20);
            this.lblNum.TabIndex = 7;
            this.lblNum.Text = "Introduzca un número para saber la suma:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 209);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.btnFor);
            this.Controls.Add(this.btnWhile);
            this.Controls.Add(this.txtNum);
            this.Name = "Form1";
            this.Text = "Ejercicio 14";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Button btnWhile;
        private System.Windows.Forms.Button btnFor;
        private System.Windows.Forms.Label lblNum;
    }
}

