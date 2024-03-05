namespace Exercise_6
{
    partial class CourseForm
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
            this.btnAddCourse = new System.Windows.Forms.Button();
            this.btnRemoveCourse = new System.Windows.Forms.Button();
            this.btnShowCourses = new System.Windows.Forms.Button();
            this.btnShowAlumnsSelectedCourse = new System.Windows.Forms.Button();
            this.btnShowSelectedCourse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddCourse
            // 
            this.btnAddCourse.Location = new System.Drawing.Point(12, 18);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(268, 44);
            this.btnAddCourse.TabIndex = 1;
            this.btnAddCourse.Text = "Add Course";
            this.btnAddCourse.UseVisualStyleBackColor = true;
            this.btnAddCourse.Click += new System.EventHandler(this.btnAddCourse_Click);
            // 
            // btnRemoveCourse
            // 
            this.btnRemoveCourse.Location = new System.Drawing.Point(12, 87);
            this.btnRemoveCourse.Name = "btnRemoveCourse";
            this.btnRemoveCourse.Size = new System.Drawing.Size(268, 44);
            this.btnRemoveCourse.TabIndex = 2;
            this.btnRemoveCourse.Text = "Remove Course";
            this.btnRemoveCourse.UseVisualStyleBackColor = true;
            this.btnRemoveCourse.Click += new System.EventHandler(this.btnRemoveCourse_Click);
            // 
            // btnShowCourses
            // 
            this.btnShowCourses.Location = new System.Drawing.Point(12, 158);
            this.btnShowCourses.Name = "btnShowCourses";
            this.btnShowCourses.Size = new System.Drawing.Size(268, 44);
            this.btnShowCourses.TabIndex = 3;
            this.btnShowCourses.Text = "Show All Courses";
            this.btnShowCourses.UseVisualStyleBackColor = true;
            this.btnShowCourses.Click += new System.EventHandler(this.btnShowCourses_Click);
            // 
            // btnShowAlumnsSelectedCourse
            // 
            this.btnShowAlumnsSelectedCourse.Location = new System.Drawing.Point(12, 294);
            this.btnShowAlumnsSelectedCourse.Name = "btnShowAlumnsSelectedCourse";
            this.btnShowAlumnsSelectedCourse.Size = new System.Drawing.Size(268, 44);
            this.btnShowAlumnsSelectedCourse.TabIndex = 4;
            this.btnShowAlumnsSelectedCourse.Text = "Show All Alumns From Selected Course";
            this.btnShowAlumnsSelectedCourse.UseVisualStyleBackColor = true;
            this.btnShowAlumnsSelectedCourse.Click += new System.EventHandler(this.btnShowAlumnsSelectedCourse_Click);
            // 
            // btnShowSelectedCourse
            // 
            this.btnShowSelectedCourse.Location = new System.Drawing.Point(13, 225);
            this.btnShowSelectedCourse.Name = "btnShowSelectedCourse";
            this.btnShowSelectedCourse.Size = new System.Drawing.Size(268, 44);
            this.btnShowSelectedCourse.TabIndex = 5;
            this.btnShowSelectedCourse.Text = "Show Data From Selected Course";
            this.btnShowSelectedCourse.UseVisualStyleBackColor = true;
            this.btnShowSelectedCourse.Click += new System.EventHandler(this.btnShowSelectedCourse_Click);
            // 
            // CourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 350);
            this.Controls.Add(this.btnShowSelectedCourse);
            this.Controls.Add(this.btnShowAlumnsSelectedCourse);
            this.Controls.Add(this.btnShowCourses);
            this.Controls.Add(this.btnRemoveCourse);
            this.Controls.Add(this.btnAddCourse);
            this.Name = "CourseForm";
            this.Text = "Courses Management";
            this.Load += new System.EventHandler(this.CourseForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddCourse;
        private System.Windows.Forms.Button btnRemoveCourse;
        private System.Windows.Forms.Button btnShowCourses;
        private System.Windows.Forms.Button btnShowAlumnsSelectedCourse;
        private System.Windows.Forms.Button btnShowSelectedCourse;
    }
}