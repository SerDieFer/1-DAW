using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Exercise_4.Views.Alumn
{
    public partial class fAlumnCheckCourse : Form
    {
        public fAlumnCheckCourse(string ID)
        {
            InitializeComponent();
            this.Text = ID;
        }

        // CALLING SQLBDHANDLER TO MANAGE DB FUNCTIONS
        SqlDBHandler dbHandlerAlumns;
        SqlDBHandler dbHandlerTeachers;

        private void fAlumnCheckCourse_Load(object sender, EventArgs e)
        {
            // CONSTRUCTION OF THE DATABASE HANDLER FOR THE ALUMNS AND TEACHERS TABLE
            dbHandlerAlumns = new SqlDBHandler("Alumnos");
            dbHandlerTeachers = new SqlDBHandler("Profesores");
            txtbCourse.ReadOnly = true;
            txtbTeachers.ReadOnly = true;
            txtbTeachers.Multiline = true;
            txtbCourse.Text = GetCourse(this.Text);
            txtbTeachers.Text = GetTeachers(this.Text);
        }

        private string GetCourse(string ID)
        {
            // QUERY THAT RETURNS THE COURSE COD FROM THAT ALUMN
            string queryCourseCod = "SELECT Codigo FROM Alumnos WHERE DNI = '" + ID + "'";
            string alumnCourseCod = dbHandlerAlumns.GetStringDataFromTable("Alumnos", queryCourseCod);
            return alumnCourseCod;
        }

        private string GetTeachers(string ID)
        {
            // QUERY THAT RETURNS THE COURSE COD FROM THAT ALUMN
            string queryTeachers = "SELECT * FROM Profesores WHERE Codigo = '" + GetCourse(ID) + "'";
            string courseTeachers = dbHandlerTeachers.GetStringDataFromRowFromTable("Profesores", queryTeachers);
            return courseTeachers;
        }
    }
}
