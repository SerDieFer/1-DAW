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
            this.btnIntroducirVector = new System.Windows.Forms.Button();
            this.btnMostrarVector = new System.Windows.Forms.Button();
            this.btnBuscarVector = new System.Windows.Forms.Button();
            this.btnOrdenarVector = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIntroducirVector
            // 
            this.btnIntroducirVector.Location = new System.Drawing.Point(12, 12);
            this.btnIntroducirVector.Name = "btnIntroducirVector";
            this.btnIntroducirVector.Size = new System.Drawing.Size(218, 41);
            this.btnIntroducirVector.TabIndex = 0;
            this.btnIntroducirVector.Text = "Leer Vector";
            this.btnIntroducirVector.UseVisualStyleBackColor = true;
            this.btnIntroducirVector.Click += new System.EventHandler(this.btnIntroducirVector_Click);
            // 
            // btnMostrarVector
            // 
            this.btnMostrarVector.Location = new System.Drawing.Point(12, 153);
            this.btnMostrarVector.Name = "btnMostrarVector";
            this.btnMostrarVector.Size = new System.Drawing.Size(218, 46);
            this.btnMostrarVector.TabIndex = 1;
            this.btnMostrarVector.Text = "Mostrar Vector";
            this.btnMostrarVector.UseVisualStyleBackColor = true;
            this.btnMostrarVector.Click += new System.EventHandler(this.btnMostrarVector_Click);
            // 
            // btnBuscarVector
            // 
            this.btnBuscarVector.Location = new System.Drawing.Point(12, 59);
            this.btnBuscarVector.Name = "btnBuscarVector";
            this.btnBuscarVector.Size = new System.Drawing.Size(218, 41);
            this.btnBuscarVector.TabIndex = 2;
            this.btnBuscarVector.Text = "Buscar Elemento";
            this.btnBuscarVector.UseVisualStyleBackColor = true;
            this.btnBuscarVector.Click += new System.EventHandler(this.btnBuscarVector_Click);
            // 
            // btnOrdenarVector
            // 
            this.btnOrdenarVector.Location = new System.Drawing.Point(12, 106);
            this.btnOrdenarVector.Name = "btnOrdenarVector";
            this.btnOrdenarVector.Size = new System.Drawing.Size(218, 41);
            this.btnOrdenarVector.TabIndex = 3;
            this.btnOrdenarVector.Text = "Ordenar Vector";
            this.btnOrdenarVector.UseVisualStyleBackColor = true;
            this.btnOrdenarVector.Click += new System.EventHandler(this.btnOrdenarVector_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 209);
            this.Controls.Add(this.btnOrdenarVector);
            this.Controls.Add(this.btnBuscarVector);
            this.Controls.Add(this.btnMostrarVector);
            this.Controls.Add(this.btnIntroducirVector);
            this.Name = "Form1";
            this.Text = "Ejercicio 17";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIntroducirVector;
        private System.Windows.Forms.Button btnMostrarVector;
        private System.Windows.Forms.Button btnBuscarVector;
        private System.Windows.Forms.Button btnOrdenarVector;
    }
}

