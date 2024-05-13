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

namespace Exercise_3
{
    public partial class fTeacherOptions : Form
    {
        public fTeacherOptions(string username)
        {
            InitializeComponent();
            this.Text = username;
        }

        // CALLING SQLBDHANDLER TO MANAGE DB FUNCTIONS
        SqlDBHandler dbHandler;

        private void fUserOptions_Load(object sender, EventArgs e)
        {
            // CONSTRUCTION OF THE DATABASE HANDLER FOR THE USERS TABLE
            dbHandler = new SqlDBHandler("Users");
            ShowUserRecords(this.Text);
        }

        /*---------------------------------------- VISUAL HANDLING FUNCTIONS START ----------------------------------------------*/


        // FUNCTION TO UPDATE THE VISUAL PART OF THE FORM WITH USER RECORDS
        private void ShowUserRecords(string username)
        {
            string userPassword = GetPassword(username);
            string userEmail = GetEmail(username);

            // SET VALUES FROM THE SELECTED USER RECORD INTO THE TEXTBOXES
            txtbUserEmail.Text = userEmail;
            txtbUserPassword.Text = userPassword;
            txtbUserPassword.UseSystemPasswordChar = true;

            ButtonsCheck();
        }

        /*----------------------------------------------- VISUAL HANDLING FUNCTIONS END -------------------------------------------------*/

        /*------------------------ GENERAL BUTTONS SUPPORT FUNCTIONS START -----------------------*/

        private string GetPassword(string username)
        {
            // QUERY THAT RETURNS THE PASSWORD FROM THAT USER
            string queryPassword = "SELECT Password FROM Users WHERE Name = '" + username + "'";
            string userPassword = dbHandler.GetPasswordFromUserName("Users", queryPassword);
            return userPassword;
        }

        private string GetEmail(string username)
        {
            // QUERY THAT RETURNS THE EMAIL FROM THAT USER
            string queryEmail = "SELECT Email FROM Users WHERE Name = '" + username + "'";
            string userEmail = dbHandler.GetEmail("Users", queryEmail);
            return userEmail;
        }

        /*------------------------ GENERAL BUTTONS SUPPORT FUNCTIONS END -----------------------*/

        /* ------------------------------------------------ BUTTONS HANDLING START ------------------------------------------------------ */

        // BUTTON WHICH UPDATES PASSWORD AND COMPARES IT BETWEEN THE OLD ONE IN TH DB AND THE NEW, IF THE NEW IS CORRECTLY IT CHANGES THE DB VALUE FOR THIS USER
        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = GetPassword(this.Text);
            string actualPassword = txtbUserPassword.Text;
            if (actualPassword != oldPassword)
            {
                if(CustomRegex.RegexPassword(actualPassword))
                {
                    string username = this.Text;

                    SqlConnection con = dbHandler.CreateSqlConnectionToDB();

                    con.Open();

                    string queryUpdate = "UPDATE Users SET Password = '" + actualPassword + "' WHERE Name = '" + username + "'";

                    SqlCommand command = new SqlCommand(queryUpdate, con);

                    command.ExecuteNonQuery();

                    con.Close();

                    ButtonsCheck();
                    txtbUserPassword.UseSystemPasswordChar = true;
                    chkbVisible.Enabled = false;

                    MessageBox.Show("Password changed!.");
                }
                else
                {
                    txtbUserPassword.Text = oldPassword;
                    ButtonsCheck();


                    MessageBox.Show("Please enter a valid password.");
                }
            }
            else
            {
                MessageBox.Show("New password cannot be the same as the old password.");
            }
        }

        // BUTTON WHICH UPDATES EMAIL AND COMPARES IT BETWEEN THE OLD ONE IN TH DB AND THE NEW, IF THE NEW IS CORRECTLY IT CHANGES THE DB VALUE FOR THIS USER
        private void btnUpdateEmail_Click(object sender, EventArgs e)
        {
            string oldEmail = GetEmail(this.Text);
            string actualEmail = txtbUserEmail.Text;

            if (actualEmail != oldEmail)
            {
                if (CustomRegex.RegexEmail(actualEmail))
                {
                    string username = this.Text;

                    SqlConnection con = dbHandler.CreateSqlConnectionToDB();

                    con.Open();

                    string queryUpdate = "UPDATE Users SET Email = '" + actualEmail + "' WHERE Name = '" + username + "'";

                    SqlCommand command = new SqlCommand(queryUpdate, con);

                    command.ExecuteNonQuery();

                    con.Close();

                    ButtonsCheck();
                    txtbUserPassword.UseSystemPasswordChar = true;
                    chkbVisible.Enabled = false;

                    MessageBox.Show("Email changed!.");

                }
                else
                {
                    txtbUserEmail.Text = oldEmail;
                    ButtonsCheck();

                    MessageBox.Show("Please enter a valid email.");
                }
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
                txtbUserPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtbUserPassword.UseSystemPasswordChar = true;
            }
        }

        // CHECKS THE ACTUAL STATUS OF EVERY BUTTON
        public void ButtonsCheck()
        {
            string oldPassword = GetPassword(this.Text);
            string actualPassword = txtbUserPassword.Text;

            string oldEmail = GetEmail(this.Text);
            string actualEmail = txtbUserEmail.Text;

            btnUpdateEmail.Enabled = oldEmail != actualEmail;
            btnUpdatePassword.Enabled = oldPassword != actualPassword;
        }

        // THIS FUNCTION AUTO CHECKS THE CHANGES DETECTED IN THE FOLLOWING TEXT BOXES BETWEEN THE ORIGINAL STRING AND THE NEW CHANGED
        private void UpdateChangeDetected(string currentValue, string originalValue)
        {
            bool anyChangeDetected = (currentValue != originalValue);
            changeDetected = anyChangeDetected;
            ButtonsCheck();
        }

        // EVENT HANDLER FOR DIFFERENT USER PASSWORD
        private void txtbUserPassword_TextChanged(object sender, EventArgs e)
        {
            string oldPassword = GetPassword(this.Text);
            string actualPassword = txtbUserPassword.Text;

            if (actualPassword.Length != oldPassword.Length || actualPassword != oldPassword)
            {
                chkbVisible.Enabled = true;

            }
            else
            {
                chkbVisible.Checked = false;
                txtbUserPassword.UseSystemPasswordChar = true;
                chkbVisible.Enabled = false;
            }

            // CALL THE FUNCTION TO CHECK FOR CHANGES DETECTED
            UpdateChangeDetected(actualPassword, oldPassword);
        }

        // EVENT HANDLER FOR DIFFERENT EMAIL TEXT
        private void txtbUserEmail_TextChanged(object sender, EventArgs e)
        {
            string oldEmail = GetEmail(this.Text);
            string actualEmail = txtbUserEmail.Text;

            UpdateChangeDetected(actualEmail, oldEmail);
        }

        /* ------------------------------- HANDLING FUNCTIONS FOR BUTTONS STATUS AND TEXT BOX CHANGES END ------------------------------ */
    }
}
