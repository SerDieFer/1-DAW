using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_4.Views.Teacher
{
    public partial class fTeacherOptions : Form
    {
        public fTeacherOptions(string teacherID)
        {
            InitializeComponent();
            this.Text = teacherID;
        }

        // CALLING SQLBDHANDLER TO MANAGE DB FUNCTIONS
        SqlDBHandler dbHandlerAlumns;
        SqlDBHandler dbHandlerTeachers;

        private void fTeacherOptions_Load(object sender, EventArgs e)
        {
            // CONSTRUCTION OF THE DATABASE HANDLER FOR THE ALUMNS AND TEACHERS TABLE
            dbHandlerAlumns = new SqlDBHandler("Alumnos");
            dbHandlerTeachers = new SqlDBHandler("Profesores");
            ShowTeacherRecords(this.Text);
        }


        /*---------------------------------------- VISUAL HANDLING FUNCTIONS START ----------------------------------------------*/


        // FUNCTION TO UPDATE THE VISUAL PART OF THE FORM WITH TEACHER RECORDS
        private void ShowTeacherRecords(string ID)
        {
            string teacherPassword = GetPassword(ID);
            string teacherEmail = GetEmail(ID);
            string teacherPhone = GetPhone(ID);

            // SET VALUES FROM THE SELECTED TEACHER RECORD INTO THE TEXTBOXES
            txtbEmail.Text = teacherEmail;
            txtbPhone.Text = teacherPhone;
            txtbTeacherPassword.Text = teacherPassword;
            txtbTeacherPassword.UseSystemPasswordChar = true;

            ButtonsCheck();
        }

        /*----------------------------------------------- VISUAL HANDLING FUNCTIONS END -------------------------------------------------*/

        /*------------------------ GENERAL BUTTONS SUPPORT FUNCTIONS START -----------------------*/

        private string GetPassword(string ID)
        {
            // QUERY THAT RETURNS THE PASSWORD FROM THAT TEACHER
            string queryPassword = "SELECT Contraseña FROM Profesores WHERE DNI = '" + ID + "'";
            string teacherPassword = dbHandlerTeachers.GetStringDataFromTable("Profesores", queryPassword);
            return teacherPassword;
        }

        private string GetEmail(string ID)
        {
            // QUERY THAT RETURNS THE EMAIL FROM THAT TEACHER
            string queryAdress = "SELECT Email FROM Profesores WHERE DNI = '" + ID + "'";
            string teacherAdress = dbHandlerTeachers.GetStringDataFromTable("Profesores", queryAdress);
            return teacherAdress;
        }

        private string GetPhone(string ID)
        {
            // QUERY THAT RETURNS THE PHONE FROM THAT TEACHER
            string queryPhone = "SELECT Tlf FROM Profesores WHERE DNI = '" + ID + "'";
            string teacherPhone = dbHandlerTeachers.GetStringDataFromTable("Profesores", queryPhone);
            return teacherPhone;
        }

        /*------------------------ GENERAL BUTTONS SUPPORT FUNCTIONS END -----------------------*/

        /* ------------------------------------------------ BUTTONS HANDLING START ------------------------------------------------------ */

        // BUTTON WHICH UPDATES PASSWORD AND COMPARES IT BETWEEN THE OLD ONE IN TH DB AND THE NEW, IF THE NEW IS CORRECTLY IT CHANGES THE DB VALUE FOR THIS ALUMN
        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = GetPassword(this.Text);
            string actualPassword = txtbTeacherPassword.Text;
            if (actualPassword != oldPassword)
            {
                if (CustomRegex.RegexPassword(actualPassword))
                {
                    string teacherId = this.Text;

                    SqlConnection con = dbHandlerAlumns.CreateSqlConnectionToDB();

                    con.Open();

                    string queryUpdate = "UPDATE Profesores SET Contraseña = '" + actualPassword + "' WHERE DNI = '" + teacherId + "'";

                    SqlCommand command = new SqlCommand(queryUpdate, con);

                    command.ExecuteNonQuery();

                    con.Close();

                    ButtonsCheck();
                    txtbTeacherPassword.UseSystemPasswordChar = true;
                    chkbVisible.Enabled = false;

                    MessageBox.Show("Password changed!.");
                }
                else
                {
                    txtbTeacherPassword.Text = oldPassword;
                    ButtonsCheck();


                    MessageBox.Show("Please enter a valid password.");
                }
            }
            else
            {
                MessageBox.Show("New password cannot be the same as the old password.");
            }
        }

        // BUTTON WHICH UPDATES THE PHONE AND COMPARES IT BETWEEN THE OLD ONE IN TH DB AND THE NEW, IF THE NEW IS CORRECTLY IT CHANGES THE DB VALUE FOR THIS TEACHER
        private void btnUpdatePhone_Click(object sender, EventArgs e)
        {
            string oldPhone = GetPhone(this.Text);
            string actualPhone = txtbPhone.Text;


            if (!dbHandlerTeachers.DuplicatedPhone(actualPhone, "Profesores"))
            {
                if (!dbHandlerAlumns.DuplicatedPhone(actualPhone, "Alumnos"))
                {
                    if (actualPhone != oldPhone)
                    {
                        if (CustomRegex.RegexPhone(actualPhone))
                        {
                            string teacherId = this.Text;

                            SqlConnection con = dbHandlerAlumns.CreateSqlConnectionToDB();

                            con.Open();

                            string queryUpdate = "UPDATE Profesores SET Tlf = '" + actualPhone + "' WHERE DNI = '" + teacherId + "'";

                            SqlCommand command = new SqlCommand(queryUpdate, con);

                            command.ExecuteNonQuery();

                            con.Close();

                            ButtonsCheck();
                            txtbTeacherPassword.UseSystemPasswordChar = true;
                            chkbVisible.Enabled = false;

                            MessageBox.Show("Phone changed!.");

                        }
                        else
                        {
                            txtbPhone.Text = oldPhone;
                            ButtonsCheck();

                            MessageBox.Show("Please enter a valid phone." +
                                            "EXAMPLE: 600000000 / 799999999");
                        }
                    }
                    else
                    {
                        MessageBox.Show("New phone cannot be the same as the old phone.");
                    }
                }
                else
                {
                    MessageBox.Show("This phone is already used by an alumn.");
                }
            }
            else
            {
                MessageBox.Show("This phone is already used by a teacher.");
            }
        }

        // BUTTON WHICH UPDATES THE EMAIL AND COMPARES IT BETWEEN THE OLD ONE IN TH DB AND THE NEW, IF THE NEW IS CORRECTLY IT CHANGES THE DB VALUE FOR THIS TEACHER
        private void btnUpdateEmail_Click(object sender, EventArgs e)
        {
            string oldEmail = GetPhone(this.Text);
            string actualEmail = txtbEmail.Text;

            if (actualEmail != oldEmail)
            {
                string teacherId = this.Text;

                SqlConnection con = dbHandlerAlumns.CreateSqlConnectionToDB();

                con.Open();

                string queryUpdate = "UPDATE Profesores SET Email = '" + actualEmail + "' WHERE DNI = '" + teacherId + "'";

                SqlCommand command = new SqlCommand(queryUpdate, con);

                command.ExecuteNonQuery();

                con.Close();

                ButtonsCheck();
                txtbTeacherPassword.UseSystemPasswordChar = true;
                chkbVisible.Enabled = false;

                MessageBox.Show("Email changed!.");
            }
            else
            {
                MessageBox.Show("New email cannot be the same as the old email.");
            }
        }

        /* -------------------------------------------------- BUTTONS HANDLING END ------------------------------------------------------ */

        /* ----------------------------- HANDLING FUNCTIONS FOR BUTTONS STATUS AND TEXT BOX CHANGES START ------------------------------ */

        // CHANGED TEXT STATUS
        bool changeDetected = false;

        // CHECKER TO SEE THE PASSWORD CHARACTERS
        private void chkbVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbVisible.Checked)
            {
                txtbTeacherPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtbTeacherPassword.UseSystemPasswordChar = true;
            }
        }

        // CHECKS THE ACTUAL STATUS OF EVERY BUTTON
        public void ButtonsCheck()
        {
            string oldPassword = GetPassword(this.Text);
            string actualPassword = txtbTeacherPassword.Text;

            string oldPhone = GetPhone(this.Text);
            string actualPhone = txtbPhone.Text;

            string oldEmail = GetEmail(this.Text);
            string actualEmail = txtbEmail.Text;

            btnUpdateEmail.Enabled = oldEmail != actualEmail;
            btnUpdatePassword.Enabled = oldPassword != actualPassword;
            btnUpdatePhone.Enabled = oldPhone != actualPhone && (actualPhone.Length == 9);
        }

        // THIS FUNCTION AUTO CHECKS THE CHANGES DETECTED IN THE FOLLOWING TEXT BOXES BETWEEN THE ORIGINAL STRING AND THE NEW CHANGED
        private void UpdateChangeDetected(string currentValue, string originalValue)
        {
            bool anyChangeDetected = (currentValue != originalValue);
            changeDetected = anyChangeDetected;
            ButtonsCheck();
        }

        // EVENT HANDLER FOR DIFFERENT TEACHER PHONE
        private void txtbPhone_TextChanged(object sender, EventArgs e)
        {
            string oldPhone = GetPhone(this.Text);
            string actualPhone = txtbPhone.Text;

            UpdateChangeDetected(actualPhone, oldPhone);
        }

        // EVENT HANDLER FOR DIFFERENT TEACHER EMAIL
        private void txtbEmail_TextChanged(object sender, EventArgs e)
        {
            string oldEmail = GetEmail(this.Text);
            string actualEmail = txtbPhone.Text;

            UpdateChangeDetected(actualEmail, oldEmail);
        }

        // EVENT HANDLER FOR DIFFERENT TEACHER PASSWORD
        private void txtbTeacherPassword_TextChanged(object sender, EventArgs e)
        {
            string oldPassword = GetPassword(this.Text);
            string actualPassword = txtbTeacherPassword.Text;

            if (actualPassword.Length != oldPassword.Length || actualPassword != oldPassword)
            {
                chkbVisible.Enabled = true;

            }
            else
            {
                chkbVisible.Checked = false;
                txtbTeacherPassword.UseSystemPasswordChar = true;
                chkbVisible.Enabled = false;
            }

            // CALL THE FUNCTION TO CHECK FOR CHANGES DETECTED
            UpdateChangeDetected(actualPassword, oldPassword);
        }

        /* ------------------------------- HANDLING FUNCTIONS FOR BUTTONS STATUS AND TEXT BOX CHANGES END ------------------------------ */
    }
}
