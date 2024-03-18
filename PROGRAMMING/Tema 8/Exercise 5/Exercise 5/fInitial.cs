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
    public partial class InitialForm : Form
    {
        public InitialForm()  
        {
            InitializeComponent();
        }

        CourseList courseList = new CourseList();
        AlumnList alumnList = new AlumnList();
        TeacherList teacherList = new TeacherList();

        private void bCursos_Click(object sender, EventArgs e)
        {
            CourseForm courseForm = new CourseForm(courseList, alumnList, teacherList);

            courseForm.ShowDialog();
        }

        private void btnAlumn_Click(object sender, EventArgs e)
        {
            AlumnForm alumnForm = new AlumnForm(alumnList, teacherList, courseList);
            alumnForm.ShowDialog();
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            TeacherForm teacherForm = new TeacherForm(teacherList, alumnList, courseList);
            teacherForm.ShowDialog();
        }
    }
}
