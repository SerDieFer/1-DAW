using Exercise_4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_4.Views.Admin
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {

        }


        // OPENS THE COURSES MANAGEMENT FORM
        private void btnCoursesManagement_Click(object sender, EventArgs e)
        {
            fCourseManagement courseManagement = new fCourseManagement();
            courseManagement.ShowDialog();
        }


        // OPENS THE TEACHERS MANAGEMENT FORM
        private void btnTeacherManagement_Click(object sender, EventArgs e)
        {
            fTeacherManagement teacherManagement = new fTeacherManagement();
            teacherManagement.ShowDialog();
        }

        // OPENS THE ALUMNS MANAGEMENT FORM
        private void btnAlumnManagement_Click(object sender, EventArgs e)
        {
            fAlumnManagement alumnManagement = new fAlumnManagement();
            alumnManagement.ShowDialog();
        }
    }
}
