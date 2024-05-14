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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Exercise_4
{
    public partial class fAlumnOptions : Form
    {
        public fAlumnOptions(string ID)
        {
            InitializeComponent();
            this.Text = ID;
        }

        // CALLING SQLBDHANDLER TO MANAGE DB FUNCTIONS
        SqlDBHandler dbHandlerAlumns;
        SqlDBHandler dbHandlerTeachers;

        private void fAlumnOptions_Load(object sender, EventArgs e)
        {
            // CONSTRUCTION OF THE DATABASE HANDLER FOR THE ALUMNS AND TEACHERS TABLE
            dbHandlerAlumns = new SqlDBHandler("Alumnos");
            dbHandlerTeachers = new SqlDBHandler("Profesores");
            ShowAlumnRecords(this.Text);
        }

        /*---------------------------------------- VISUAL HANDLING FUNCTIONS START ----------------------------------------------*/


        // FUNCTION TO UPDATE THE VISUAL PART OF THE FORM WITH ALUMN RECORDS
        private void ShowAlumnRecords(string ID)
        {
            string alumnPassword = GetPassword(ID);
            string alumnAdress = GetAdress(ID);
            string alumnPhone = GetPhone(ID);

            // SET VALUES FROM THE SELECTED ALUMN RECORD INTO THE TEXTBOXES
            txtbAdress.Text = alumnAdress;
            txtbPhone.Text = alumnPhone;
            txtbAlumnPassword.Text = alumnPassword;
            txtbAlumnPassword.UseSystemPasswordChar = true;

            ButtonsCheck();
        }

        /*----------------------------------------------- VISUAL HANDLING FUNCTIONS END -------------------------------------------------*/

        /*------------------------ GENERAL BUTTONS SUPPORT FUNCTIONS START -----------------------*/

        private string GetPassword(string ID)
        {
            // QUERY THAT RETURNS THE PASSWORD FROM THAT ALUMN
            string queryPassword = "SELECT Contraseña FROM Alumnos WHERE DNI = '" + ID + "'";
            string alumnPassword = dbHandlerAlumns.GetStringDataFromTable("Alumnos", queryPassword);
            return alumnPassword;
        }

        private string GetAdress(string ID)
        {
            // QUERY THAT RETURNS THE EMAIL FROM THAT ALUMN
            string queryAdress = "SELECT Direccion FROM Alumnos WHERE DNI = '" + ID + "'";
            string alumnAdress = dbHandlerAlumns.GetStringDataFromTable("Alumnos", queryAdress);
            return alumnAdress;
        }

        private string GetPhone(string ID)
        {
            // QUERY THAT RETURNS THE PHONE FROM THAT ALUMN
            string queryPhone = "SELECT Tlf FROM Alumnos WHERE DNI = '" + ID + "'";
            string alumnPhone = dbHandlerAlumns.GetStringDataFromTable("Alumnos", queryPhone);
            return alumnPhone;
        }

        /*------------------------ GENERAL BUTTONS SUPPORT FUNCTIONS END -----------------------*/

        /* ------------------------------------------------ BUTTONS HANDLING START ------------------------------------------------------ */

        // BUTTON WHICH UPDATES PASSWORD AND COMPARES IT BETWEEN THE OLD ONE IN TH DB AND THE NEW, IF THE NEW IS CORRECTLY IT CHANGES THE DB VALUE FOR THIS ALUMN
        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = GetPassword(this.Text);
            string actualPassword = txtbAlumnPassword.Text;
            if (actualPassword != oldPassword)
            {
                if(CustomRegex.RegexPassword(actualPassword))
                {
                    string alumnID = this.Text;

                    SqlConnection con = dbHandlerAlumns.CreateSqlConnectionToDB();

                    con.Open();

                    string queryUpdate = "UPDATE Alumnos SET Contraseña = '" + actualPassword + "' WHERE DNI = '" + alumnID + "'";

                    SqlCommand command = new SqlCommand(queryUpdate, con);

                    command.ExecuteNonQuery();

                    con.Close();

                    ButtonsCheck();
                    txtbAlumnPassword.UseSystemPasswordChar = true;
                    chkbVisible.Enabled = false;

                    MessageBox.Show("Password changed!.");
                }
                else
                {
                    txtbAlumnPassword.Text = oldPassword;
                    ButtonsCheck();


                    MessageBox.Show("Please enter a valid password.");
                }
            }
            else
            {
                MessageBox.Show("New password cannot be the same as the old password.");
            }
        }

        // BUTTON WHICH UPDATES THE PHONE AND COMPARES IT BETWEEN THE OLD ONE IN TH DB AND THE NEW, IF THE NEW IS CORRECTLY IT CHANGES THE DB VALUE FOR THIS ALUMN
        private void btnUpdatePhone_Click(object sender, EventArgs e)
        {
            string oldPhone = GetPhone(this.Text);
            string actualPhone = txtbPhone.Text;


            if(!dbHandlerAlumns.DuplicatedPhone(actualPhone, "Alumnos"))
            {
                if (!dbHandlerTeachers.DuplicatedPhone(actualPhone, "Profesores"))
                {
                    if (actualPhone != oldPhone)
                    {
                        if (CustomRegex.RegexPhone(actualPhone))
                        {
                            string alumnId = this.Text;

                            SqlConnection con = dbHandlerAlumns.CreateSqlConnectionToDB();

                            con.Open();

                            string queryUpdate = "UPDATE Alumnos SET Tlf = '" + actualPhone + "' WHERE DNI = '" + alumnId + "'";

                            SqlCommand command = new SqlCommand(queryUpdate, con);

                            command.ExecuteNonQuery();

                            con.Close();

                            ButtonsCheck();
                            txtbAlumnPassword.UseSystemPasswordChar = true;
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
                    MessageBox.Show("This phone is already used by a teacher.");
                }
            }
            else
            {
                MessageBox.Show("This phone is already used by an alumn.");
            }

        }

        // BUTTON WHICH UPDATES THE ADRESS AND COMPARES IT BETWEEN THE OLD ONE IN TH DB AND THE NEW, IF THE NEW IS CORRECTLY IT CHANGES THE DB VALUE FOR THIS ALUMN
        private void btnUpdateAdress_Click(object sender, EventArgs e)
        {
            string oldAdress = GetPhone(this.Text);
            string actualAdress = txtbAdress.Text;

            if (actualAdress != oldAdress)
            {
                string alumnId = this.Text;

                SqlConnection con = dbHandlerAlumns.CreateSqlConnectionToDB();

                con.Open();

                string queryUpdate = "UPDATE Alumnos SET Direccion = '" + actualAdress + "' WHERE DNI = '" + alumnId + "'";

                SqlCommand command = new SqlCommand(queryUpdate, con);

                command.ExecuteNonQuery();

                con.Close();

                ButtonsCheck();
                txtbAlumnPassword.UseSystemPasswordChar = true;
                chkbVisible.Enabled = false;

                MessageBox.Show("Adress changed!.");
            }
            else
            {
                MessageBox.Show("New adress cannot be the same as the old adress.");
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
                txtbAlumnPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtbAlumnPassword.UseSystemPasswordChar = true;
            }
        }

        // CHECKS THE ACTUAL STATUS OF EVERY BUTTON
        public void ButtonsCheck()
        {
            string oldPassword = GetPassword(this.Text);
            string actualPassword = txtbAlumnPassword.Text;

            string oldPhone = GetPhone(this.Text);
            string actualPhone = txtbPhone.Text;

            string oldAdress = GetAdress(this.Text);
            string actualAdress = txtbAdress.Text;

            btnUpdateAdress.Enabled = oldAdress != actualAdress;
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

        // EVENT HANDLER FOR DIFFERENT USER PASSWORD
        private void txtbAlumnPassword_TextChanged(object sender, EventArgs e)
        {
            string oldPassword = GetPassword(this.Text);
            string actualPassword = txtbAlumnPassword.Text;

            if (actualPassword.Length != oldPassword.Length || actualPassword != oldPassword)
            {
                chkbVisible.Enabled = true;

            }
            else
            {
                chkbVisible.Checked = false;
                txtbAlumnPassword.UseSystemPasswordChar = true;
                chkbVisible.Enabled = false;
            }

            // CALL THE FUNCTION TO CHECK FOR CHANGES DETECTED
            UpdateChangeDetected(actualPassword, oldPassword);
        }

        // EVENT HANDLER FOR DIFFERENT PHONE TEXT
        private void txtbPhone_TextChanged(object sender, EventArgs e)
        {
            string oldPhone = GetPhone(this.Text);
            string actualPhone = txtbPhone.Text;

            UpdateChangeDetected(actualPhone, oldPhone);
        }

        // EVENT HANDLER FOR DIFFERENT ADRESS TEXT
        private void txtbAdress_TextChanged(object sender, EventArgs e)
        {
            string oldAdress = GetAdress(this.Text);
            string actualAdress = txtbAdress.Text;

            UpdateChangeDetected(actualAdress, oldAdress);
        }

        /* ------------------------------- HANDLING FUNCTIONS FOR BUTTONS STATUS AND TEXT BOX CHANGES END ------------------------------ */
    }
}
