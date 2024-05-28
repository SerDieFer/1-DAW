using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_4.Views.Teacher
{
    public partial class fTeacherCheckCourse : Form
    {
        public fTeacherCheckCourse(string id)
        {
            InitializeComponent();
            this.Text = id;
        }

        // CALLING SQLBDHANDLER TO MANAGE DB FUNCTIONS
        SqlDBHandler dbHandlerAlumns;
        SqlDBHandler dbHandlerTeachers;

        private void fTeacherCheckCourse_Load(object sender, EventArgs e)
        {
            // CONSTRUCTION OF THE DATABASE HANDLER FOR THE ALUMNS AND TEACHERS TABLE
            dbHandlerAlumns = new SqlDBHandler("Alumnos");
            dbHandlerTeachers = new SqlDBHandler("Profesores");
            txtbCourse.ReadOnly = true;
            txtbAlumns.ReadOnly = true;
            txtbAlumns.Multiline = true;
            txtbCourse.Text = GetCourse(this.Text);
            txtbAlumns.Text = GetAlumns(this.Text);
        }

        private string GetCourse(string ID)
        {
            // QUERY THAT RETURNS THE COURSE COD FROM THAT ALUMN
            string queryCourseCod = "SELECT Codigo FROM Profesores WHERE DNI = '" + ID + "'";
            string teacherCourseCod = dbHandlerTeachers.GetStringDataFromTable("Profesores", queryCourseCod);
            return teacherCourseCod;
        }

        private string GetAlumns(string ID)
        {
            // QUERY THAT RETURNS THE ALUMNS FROM THAT COURSE
            string queryTeachers = "SELECT * FROM Alumnos WHERE Codigo = '" + GetCourse(ID) + "'";
            string courseAlumns = dbHandlerAlumns.GetStringDataFromRowFromTable("Alumnos", queryTeachers);
            return courseAlumns;
        }
    }
}
