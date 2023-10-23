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
            this.bCalculo = new System.Windows.Forms.Button();
            this.lProducto1 = new System.Windows.Forms.Label();
            this.lProducto2 = new System.Windows.Forms.Label();
            this.lProducto3 = new System.Windows.Forms.Label();
            this.textBoxProducto1 = new System.Windows.Forms.TextBox();
            this.textBoxProducto2 = new System.Windows.Forms.TextBox();
            this.textBoxProducto3 = new System.Windows.Forms.TextBox();
            this.lCalculo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bCalculo
            // 
            this.bCalculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCalculo.Location = new System.Drawing.Point(113, 166);
            this.bCalculo.Name = "bCalculo";
            this.bCalculo.Size = new System.Drawing.Size(217, 35);
            this.bCalculo.TabIndex = 0;
            this.bCalculo.Text = "Calcular los costos totales";
            this.bCalculo.UseVisualStyleBackColor = true;
            this.bCalculo.Click += new System.EventHandler(this.bCalculo_Click);
            // 
            // lProducto1
            // 
            this.lProducto1.AutoSize = true;
            this.lProducto1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProducto1.Location = new System.Drawing.Point(109, 56);
            this.lProducto1.Name = "lProducto1";
            this.lProducto1.Size = new System.Drawing.Size(90, 20);
            this.lProducto1.TabIndex = 1;
            this.lProducto1.Text = "Producto 1:";
            // 
            // lProducto2
            // 
            this.lProducto2.AutoSize = true;
            this.lProducto2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProducto2.Location = new System.Drawing.Point(109, 90);
            this.lProducto2.Name = "lProducto2";
            this.lProducto2.Size = new System.Drawing.Size(90, 20);
            this.lProducto2.TabIndex = 2;
            this.lProducto2.Text = "Producto 2:";
            this.lProducto2.UseMnemonic = false;
            // 
            // lProducto3
            // 
            this.lProducto3.AutoSize = true;
            this.lProducto3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProducto3.Location = new System.Drawing.Point(109, 124);
            this.lProducto3.Name = "lProducto3";
            this.lProducto3.Size = new System.Drawing.Size(90, 20);
            this.lProducto3.TabIndex = 3;
            this.lProducto3.Text = "Producto 3:";
            this.lProducto3.UseMnemonic = false;
            // 
            // textBoxProducto1
            // 
            this.textBoxProducto1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProducto1.Location = new System.Drawing.Point(205, 53);
            this.textBoxProducto1.Name = "textBoxProducto1";
            this.textBoxProducto1.Size = new System.Drawing.Size(125, 26);
            this.textBoxProducto1.TabIndex = 4;
            // 
            // textBoxProducto2
            // 
            this.textBoxProducto2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProducto2.Location = new System.Drawing.Point(205, 87);
            this.textBoxProducto2.Name = "textBoxProducto2";
            this.textBoxProducto2.Size = new System.Drawing.Size(125, 26);
            this.textBoxProducto2.TabIndex = 5;
            // 
            // textBoxProducto3
            // 
            this.textBoxProducto3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProducto3.Location = new System.Drawing.Point(205, 121);
            this.textBoxProducto3.Name = "textBoxProducto3";
            this.textBoxProducto3.Size = new System.Drawing.Size(125, 26);
            this.textBoxProducto3.TabIndex = 6;
            // 
            // lCalculo
            // 
            this.lCalculo.AutoSize = true;
            this.lCalculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCalculo.Location = new System.Drawing.Point(87, 233);
            this.lCalculo.Name = "lCalculo";
            this.lCalculo.Size = new System.Drawing.Size(0, 20);
            this.lCalculo.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 314);
            this.Controls.Add(this.lCalculo);
            this.Controls.Add(this.textBoxProducto3);
            this.Controls.Add(this.textBoxProducto2);
            this.Controls.Add(this.textBoxProducto1);
            this.Controls.Add(this.lProducto3);
            this.Controls.Add(this.lProducto2);
            this.Controls.Add(this.lProducto1);
            this.Controls.Add(this.bCalculo);
            this.Name = "Form1";
            this.Text = "Ejercicio 12";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCalculo;
        private System.Windows.Forms.Label lProducto1;
        private System.Windows.Forms.Label lProducto2;
        private System.Windows.Forms.Label lProducto3;
        private System.Windows.Forms.TextBox textBoxProducto1;
        private System.Windows.Forms.TextBox textBoxProducto2;
        private System.Windows.Forms.TextBox textBoxProducto3;
        private System.Windows.Forms.Label lCalculo;
    }
}

