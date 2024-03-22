namespace Exercise_5
{
    partial class fInitial
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCourse = new System.Windows.Forms.Button();
            this.btnAlumn = new System.Windows.Forms.Button();
            this.btnTeacher = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCourse
            // 
            this.btnCourse.Location = new System.Drawing.Point(12, 21);
            this.btnCourse.Name = "btnCourse";
            this.btnCourse.Size = new System.Drawing.Size(268, 44);
            this.btnCourse.TabIndex = 0;
            this.btnCourse.Text = "Courses Management";
            this.btnCourse.UseVisualStyleBackColor = true;
            this.btnCourse.Click += new System.EventHandler(this.bCursos_Click);
            // 
            // btnAlumn
            // 
            this.btnAlumn.Location = new System.Drawing.Point(12, 94);
            this.btnAlumn.Name = "btnAlumn";
            this.btnAlumn.Size = new System.Drawing.Size(268, 44);
            this.btnAlumn.TabIndex = 1;
            this.btnAlumn.Text = "Alumns Management";
            this.btnAlumn.UseVisualStyleBackColor = true;
            this.btnAlumn.Click += new System.EventHandler(this.btnAlumn_Click);
            // 
            // btnTeacher
            // 
            this.btnTeacher.Location = new System.Drawing.Point(12, 167);
            this.btnTeacher.Name = "btnTeacher";
            this.btnTeacher.Size = new System.Drawing.Size(268, 44);
            this.btnTeacher.TabIndex = 2;
            this.btnTeacher.Text = "Teachers Management";
            this.btnTeacher.UseVisualStyleBackColor = true;
            this.btnTeacher.Click += new System.EventHandler(this.btnTeacher_Click);
            // 
            // InitialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 229);
            this.Controls.Add(this.btnTeacher);
            this.Controls.Add(this.btnAlumn);
            this.Controls.Add(this.btnCourse);
            this.Name = "InitialForm";
            this.Text = "School Management";
            this.Load += new System.EventHandler(this.InitialForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCourse;
        private System.Windows.Forms.Button btnAlumn;
        private System.Windows.Forms.Button btnTeacher;
    }
}

