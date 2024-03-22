using Exercise_5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exercise_5
{
    public partial class fInitial : Form
    {
        public fInitial()  
        {
            InitializeComponent();
        }

        CourseList courseList = new CourseList();
        PersonList personList = new PersonList();

        private void bCursos_Click(object sender, EventArgs e)
        {
            CourseForm courseForm = new CourseForm(courseList, personList);
            courseForm.ShowDialog();
        }

        private void btnAlumn_Click(object sender, EventArgs e)
        {
            AlumnForm alumnForm = new AlumnForm(personList, courseList);
            alumnForm.ShowDialog();
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            TeacherForm teacherForm = new TeacherForm(personList, courseList);
            teacherForm.ShowDialog();
        }

        private void InitialForm_Load(object sender, EventArgs e)
        {

        }
    }
}
