using Exercise_4.Views.Teacher;
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
    public partial class fTeacher : Form
    {
        public fTeacher(string teacherID)
        {
            InitializeComponent();
            this.Text = teacherID;
            MessageBox.Show("Welcome, " + this.Text + "!");
        }

        private void fTeacher_Load(object sender, EventArgs e)
        {
        }

        // LOADS ALUMNS MENU IN THE TEACHER COURSE
        private void btnCourseManaging_Click(object sender, EventArgs e)
        {

        }

        // LOADS TEACHER OPTIONS MENU
        private void btnTeacherOptions_Click(object sender, EventArgs e)
        {
            string teacherID = this.Text;
            fTeacherOptions teacherOptionsForm = new fTeacherOptions(teacherID);
            teacherOptionsForm.ShowDialog();
        }


        // EVENT HANDLER TO CLOSE THE ACTUAL LOGIN INSTEAD A BUTTON
        // I HAD TO CREATE AN EVENT FOR HANDLING WHEN THIS FORM ITS CLOSED AND ADD ITS ACTIVATION INTO THE DESIGNER OF THIS CLASS
        // this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fTeacher_FormClosing);
        private void fTeacher_FormClosing(object sender, FormClosingEventArgs closeEvent)
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
