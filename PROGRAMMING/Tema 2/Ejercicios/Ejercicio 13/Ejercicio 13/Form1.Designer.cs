namespace Ejercicio_13
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
            this.lHoras = new System.Windows.Forms.Label();
            this.lExtras = new System.Windows.Forms.Label();
            this.lPagaHoraria = new System.Windows.Forms.Label();
            this.textBoxHoras = new System.Windows.Forms.TextBox();
            this.textBoxExtras = new System.Windows.Forms.TextBox();
            this.textBoxPagaHoraria = new System.Windows.Forms.TextBox();
            this.bNomina = new System.Windows.Forms.Button();
            this.lNomina = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lHoras
            // 
            this.lHoras.AutoSize = true;
            this.lHoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHoras.Location = new System.Drawing.Point(137, 93);
            this.lHoras.Name = "lHoras";
            this.lHoras.Size = new System.Drawing.Size(139, 20);
            this.lHoras.TabIndex = 0;
            this.lHoras.Text = "Horas Trabajadas:";
            // 
            // lExtras
            // 
            this.lExtras.AutoSize = true;
            this.lExtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lExtras.Location = new System.Drawing.Point(137, 133);
            this.lExtras.Name = "lExtras";
            this.lExtras.Size = new System.Drawing.Size(188, 20);
            this.lExtras.TabIndex = 1;
            this.lExtras.Text = "Horas Extras Trabajadas:";
            // 
            // lPagaHoraria
            // 
            this.lPagaHoraria.AutoSize = true;
            this.lPagaHoraria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPagaHoraria.Location = new System.Drawing.Point(137, 174);
            this.lPagaHoraria.Name = "lPagaHoraria";
            this.lPagaHoraria.Size = new System.Drawing.Size(116, 20);
            this.lPagaHoraria.TabIndex = 2;
            this.lPagaHoraria.Text = "Paga por Hora:";
            // 
            // textBoxHoras
            // 
            this.textBoxHoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHoras.Location = new System.Drawing.Point(331, 87);
            this.textBoxHoras.Name = "textBoxHoras";
            this.textBoxHoras.Size = new System.Drawing.Size(84, 26);
            this.textBoxHoras.TabIndex = 3;
            // 
            // textBoxExtras
            // 
            this.textBoxExtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxExtras.Location = new System.Drawing.Point(331, 130);
            this.textBoxExtras.Name = "textBoxExtras";
            this.textBoxExtras.Size = new System.Drawing.Size(84, 26);
            this.textBoxExtras.TabIndex = 4;
            // 
            // textBoxPagaHoraria
            // 
            this.textBoxPagaHoraria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPagaHoraria.Location = new System.Drawing.Point(331, 171);
            this.textBoxPagaHoraria.Name = "textBoxPagaHoraria";
            this.textBoxPagaHoraria.Size = new System.Drawing.Size(84, 26);
            this.textBoxPagaHoraria.TabIndex = 5;
            // 
            // bNomina
            // 
            this.bNomina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bNomina.Location = new System.Drawing.Point(141, 218);
            this.bNomina.Name = "bNomina";
            this.bNomina.Size = new System.Drawing.Size(274, 40);
            this.bNomina.TabIndex = 6;
            this.bNomina.Text = "Calcula la Nómina Mensual";
            this.bNomina.UseVisualStyleBackColor = true;
            this.bNomina.Click += new System.EventHandler(this.bNomina_Click);
            // 
            // lNomina
            // 
            this.lNomina.AutoSize = true;
            this.lNomina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNomina.Location = new System.Drawing.Point(109, 293);
            this.lNomina.Name = "lNomina";
            this.lNomina.Size = new System.Drawing.Size(0, 20);
            this.lNomina.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 394);
            this.Controls.Add(this.lNomina);
            this.Controls.Add(this.bNomina);
            this.Controls.Add(this.textBoxPagaHoraria);
            this.Controls.Add(this.textBoxExtras);
            this.Controls.Add(this.textBoxHoras);
            this.Controls.Add(this.lPagaHoraria);
            this.Controls.Add(this.lExtras);
            this.Controls.Add(this.lHoras);
            this.Name = "Form1";
            this.Text = "Ejercicio 13";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lHoras;
        private System.Windows.Forms.Label lExtras;
        private System.Windows.Forms.Label lPagaHoraria;
        private System.Windows.Forms.TextBox textBoxHoras;
        private System.Windows.Forms.TextBox textBoxExtras;
        private System.Windows.Forms.TextBox textBoxPagaHoraria;
        private System.Windows.Forms.Button bNomina;
        private System.Windows.Forms.Label lNomina;
    }
}

