using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exercise_6
{
    public partial class CourseForm : Form
    {
        public CourseForm()
        {
            InitializeComponent();
        }

        public CourseList courseList;
        public AlumnList alumnList;
        // public ListaAlumnos listaAlumnos; //necesaria para el botón de mostrar los alumnos por curso.

        private void CourseForm_Load(object sender, EventArgs e)
        {
        }

        public CourseForm(CourseList courseList, AlumnList alumnList)
        {
            InitializeComponent();
            // Ponemos en la lista de cursos del formulario la lista
            // de cursos que se pasa desde el formulario inicial
            this.courseList = courseList;
            this.alumnList = alumnList;
        }

    }
}
