using Exercise_4;
using Exercise_4.Models;
using Exercise_4.Views.Admin;
using Exercise_4.Views.Alumn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Exercise_4
{
    public partial class fAlumn : Form
    {
        public fAlumn(string alumnID)
        {
            InitializeComponent();
            this.Text = alumnID;
            MessageBox.Show("Welcome, " + alumnID + "!");
        }

        // CALLING SQLBDHANDLER TO MANAGE DB FUNCTIONS
        SqlDBHandler dbHandlerAlumns;

        private void fAlumn_Load(object sender, EventArgs e)
        {
            // CONSTRUCTION OF THE DATABASE HANDLER FOR THE ALUMNS AND TEACHERS TABLE
            dbHandlerAlumns = new SqlDBHandler("Alumnos");
        }

        // LOADS COURSE DATA WHERE ALUMN IS INSCRIBED
        private void btnAlumnCourses_Click(object sender, EventArgs e)
        {
            string alumnID = this.Text;

            string courseCod = GetCourse(alumnID);
            if (string.IsNullOrEmpty(courseCod))
            {
                MessageBox.Show("You don't have a course asigned, talk with administrator.");
            }
            else
            {
                fAlumnCheckCourse alumnOptions = new fAlumnCheckCourse(alumnID);
                alumnOptions.ShowDialog();
            }
        }

        // LOADS ALUMNS OPTIONS
        private void btnAlumnOptions_Click(object sender, EventArgs e)
        {
            string alumnID = this.Text;
            fAlumnOptions alumnOptions = new fAlumnOptions(alumnID);
            alumnOptions.ShowDialog();
        }

        private string GetCourse(string ID)
        {
            // QUERY THAT RETURNS THE COURSE COD FROM THAT ALUMN
            string alumnID = this.Text;
            string queryCourseCod = "SELECT Codigo FROM Alumnos WHERE DNI = '" + alumnID + "'";
            string alumnCourseCod = dbHandlerAlumns.GetStringDataFromTable("Alumnos", queryCourseCod);
            return alumnCourseCod;
        }

        // EVENT HANDLER TO CLOSE THE ACTUAL LOGIN INSTEAD A BUTTON
        // I HAD TO CREATE AN EVENT FOR HANDLING WHEN THIS FORM ITS CLOSED AND ADD ITS ACTIVATION INTO THE DESIGNER OF THIS CLASS
        // this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fUser_FormClosing);
        private void fAlumn_FormClosing(object sender, FormClosingEventArgs closeEvent)
        {
            // VERIFY IF THE CLOSURE WAS INITIATED BY THE USER
            if (closeEvent.CloseReason == CloseReason.UserClosing)
            {
                // SHOW A DIALOG BOX TO CONFIRM LOGGING OUT
                DialogResult result = MessageBox.Show("Do you want to log out?", "Log Out", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    // IF THE USER CONFIRMS LOGOUT, SHOW THE LOGIN FORM
                    fLogin loginForm = new fLogin();
                    loginForm.Show();
                }
                else if (result == DialogResult.Cancel)
                {
                    // IF THE USER CANCELS LOGOUT, CANCEL THE FORM CLOSING EVENT
                    closeEvent.Cancel = true;
                }
            }
        }
    }
}
