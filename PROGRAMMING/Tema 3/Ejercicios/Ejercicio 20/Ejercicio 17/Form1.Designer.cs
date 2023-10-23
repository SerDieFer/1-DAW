namespace Ejercicio_17
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
            this.btnCal = new System.Windows.Forms.Button();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.lblElevar = new System.Windows.Forms.Label();
            this.txtElevar = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum.Location = new System.Drawing.Point(43, 33);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(69, 20);
            this.lblNum.TabIndex = 0;
            this.lblNum.Text = "Número:";
            // 
            // btnCal
            // 
            this.btnCal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCal.Location = new System.Drawing.Point(47, 113);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(185, 32);
            this.btnCal.TabIndex = 1;
            this.btnCal.Text = "Calcular";
            this.btnCal.UseVisualStyleBackColor = true;
            this.btnCal.Click += new System.EventHandler(this.btnCal_Click);
            // 
            // txtNum
            // 
            this.txtNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNum.Location = new System.Drawing.Point(118, 30);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(114, 26);
            this.txtNum.TabIndex = 2;
            // 
            // lblElevar
            // 
            this.lblElevar.AutoSize = true;
            this.lblElevar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElevar.Location = new System.Drawing.Point(42, 75);
            this.lblElevar.Name = "lblElevar";
            this.lblElevar.Size = new System.Drawing.Size(70, 20);
            this.lblElevar.TabIndex = 3;
            this.lblElevar.Text = "Elevar a:";
            // 
            // txtElevar
            // 
            this.txtElevar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtElevar.Location = new System.Drawing.Point(118, 72);
            this.txtElevar.Name = "txtElevar";
            this.txtElevar.Size = new System.Drawing.Size(114, 26);
            this.txtElevar.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 184);
            this.Controls.Add(this.txtElevar);
            this.Controls.Add(this.lblElevar);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.btnCal);
            this.Controls.Add(this.lblNum);
            this.Name = "Form1";
            this.Text = "Ejercicio 20";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Button btnCal;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label lblElevar;
        private System.Windows.Forms.TextBox txtElevar;
    }
}

