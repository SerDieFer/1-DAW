using Exercise_4;
using Exercise_4.Views.Admin;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_4
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        // CALLING SQLBDHANDLER TO MANAGE DB FUNCTIONS
        SqlDBHandler dbHandlerAlumns;
        SqlDBHandler dbHandlerTeachers;

        private void fLogin_Load(object sender, EventArgs e)
        {
            // CONSTRUCTION OF THE DATABASE HANDLER FOR THE ALUMNS TABLE
            dbHandlerAlumns = new SqlDBHandler("Alumnos");

            // CONSTRUCTION OF THE DATABASE HANDLER FOR THE TEACHERS TABLE
            dbHandlerTeachers = new SqlDBHandler("Profesores");

            // SET INITIAL PASSWORD VISIBILITY STATE
            txtbPassword.UseSystemPasswordChar = true;
        }
        
        // PASSWORD VISIBILITY HANDLING
        private void chkbVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbVisible.Checked)
            {
                txtbPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtbPassword.UseSystemPasswordChar = true;
            }
        }

        // LOGIN HANDLER
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // SPECIAL LOGIN FOR ADMIN
            if (txtbUserID.Text == "admin" && txtbPassword.Text == "admin")
            {
                fAdmin adminLogin = new fAdmin();
                this.Hide();
                adminLogin.ShowDialog();

                txtbPassword.Clear();
                txtbUserID.Clear();

            }
            else
            {
                // NORMAL LOGIN IF USER EXISTS
                if (dbHandlerAlumns.DuplicatedID(txtbUserID.Text, "Alumnos"))
                {
                    // QUERY THAT RETURNS THE PASSWORD FROM AN ALUMN
                    string aQuery = "SELECT Contraseña FROM Alumnos WHERE DNI = '" + txtbUserID.Text + "'";
                    string correctPasswordForAlumn = dbHandlerAlumns.GetStringDataFromTable("Alumnos", aQuery);

                    if (correctPasswordForAlumn == txtbPassword.Text)
                    {
                        fAlumn alumnLogin = new fAlumn(txtbUserID.Text);
                        this.Hide();
                        alumnLogin.ShowDialog();
                        txtbPassword.Clear();
                        txtbUserID.Clear();
                    }
                    else
                    {
                        txtbPassword.Clear();
                        MessageBox.Show("Incorrect password, try again");
                    }
                }
                else if (dbHandlerTeachers.DuplicatedID(txtbUserID.Text, "Profesores"))
                {
                    // QUERY THAT RETURNS THE PASSWORD FROM A TEACHER
                    string tQuery = "SELECT Contraseña FROM Profesores WHERE DNI = '" + txtbUserID.Text + "'";
                    string correctPasswordForTeacher = dbHandlerTeachers.GetStringDataFromTable("Profesores", tQuery);

                    if (correctPasswordForTeacher == txtbPassword.Text)
                    {
                        fTeacher teacherLogin = new fTeacher(txtbUserID.Text);
                        this.Hide();
                        teacherLogin.ShowDialog();
                        txtbPassword.Clear();
                        txtbUserID.Clear();
                    }
                    else
                    {
                        txtbPassword.Clear();
                        MessageBox.Show("Incorrect password, try again");
                    }
                }
                else if (!dbHandlerTeachers.DuplicatedID(txtbUserID.Text, "Profesores") && !dbHandlerAlumns.DuplicatedID(txtbUserID.Text, "Alumnos"))
                {
                    MessageBox.Show("This user doesn't exist, try another user ID");
                    txtbUserID.Clear();
                    txtbPassword.Clear();
                }
            }
        }

        // FORCES APP CLOSING
        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // CLOSES THE APP
            Application.Exit();
        }
    }
}
