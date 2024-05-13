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

namespace Exercise_3
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        // CALLING SQLBDHANDLER TO MANAGE DB FUNCTIONS
        SqlDBHandler dbHandler;

        private void fLogin_Load(object sender, EventArgs e)
        {
            // CONSTRUCTION OF THE DATABASE HANDLER FOR THE USERS TABLE
            dbHandler = new SqlDBHandler("Users");

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
            if (txtbUserName.Text == "admin" && txtbPassword.Text == "admin")
            {
                fAdmin adminLogin = new fAdmin();
                this.Hide();
                adminLogin.ShowDialog();

                txtbPassword.Clear();
                txtbUserName.Clear();

            }
            else
            {
                // NORMAL LOGIN IF USER EXISTS
                if (dbHandler.DuplicatedNameData(txtbUserName.Text, "Users"))
                {

                    // QUERY THAT RETURNS THE PASSWORD FROM THAT USER
                    string query = "SELECT Password FROM Users WHERE Name = '" + txtbUserName.Text + "'";
                    string correctPasswordForThatUser = dbHandler.GetPasswordFromUserName("Users", query);

                    // QUERY THAT RETURNS THE BAN STATUS FROM THAT USER
                    string banStatusQuery = "SELECT Banned FROM Users WHERE Name = '" + txtbUserName.Text + "'";
                    bool statusBan = dbHandler.GetBanStatusFromUserName("Users", banStatusQuery);

                    if (correctPasswordForThatUser == txtbPassword.Text)
                    {
                        if (statusBan == false)
                        {
                            fUser userLogin = new fUser(txtbUserName.Text);
                            this.Hide();
                            userLogin.ShowDialog();

                            txtbPassword.Clear();
                            txtbUserName.Clear();
                        }
                        else
                        {
                            MessageBox.Show("This user is banned to enter");
                        }
                    }
                    else
                    {
                        txtbPassword.Clear();
                        MessageBox.Show("Incorrect password, try again");
                    }
                }
                else
                {
                    txtbUserName.Clear();
                    txtbPassword.Clear();
                    MessageBox.Show("This user doesn't exist, try another nickname or create an account");
                }
            }

        }

        // REGISTRY OF USERS
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string nameToRegister = txtbUserName.Text;
            string passwordToRegister = txtbPassword.Text;
            string emailToRegister = "";
            bool completeRegister = false;

            if (nameToRegister != "admin" && passwordToRegister != "admin")
            {
                if (CustomRegex.RegexName(nameToRegister))
                {
                    if (CustomRegex.RegexPassword(passwordToRegister))
                    {         
                        if (!dbHandler.CheckAllUserDuplicatedData(nameToRegister, emailToRegister, "Users"))
                        {
                            do
                            {
                                emailToRegister = Interaction.InputBox("Introduce the email for this user: ", "Select Email");

                                if (CustomRegex.RegexEmail(emailToRegister))
                                {
                                    if (!dbHandler.DuplicatedEmailDataFromUsers(emailToRegister))
                                    {
                                        // CREATES THE USER TO SAVE
                                        User newUser = User.UserCreation(nameToRegister, passwordToRegister, emailToRegister, false);

                                        // IF THE USER OBJECT IS VALID, INSERT IT INTO THE DATABASE
                                        if (newUser != null)
                                        {
                                            // ADD THE NEW USER TO THE DATABASE AND LOGS INTO ITS USER MENU
                                            dbHandler.AddNewObject(newUser, "Users");
                                            fUser userLogin = new fUser(nameToRegister);
                                            this.Hide();
                                            userLogin.ShowDialog();

                                            // FINISH THE REGISTRY
                                            completeRegister = true;

                                            txtbPassword.Clear();
                                            txtbUserName.Clear();
                                        }
                                    }
                                    else
                                    {
                                        // CHECKS THAT THE ACTUAL TEXT BOX NAME TEXT AND EMAIL IS NOT USED ALREADY IN THE DB AND SHOWS THE RESULT IN A MESSAGE BOX
                                        MessageBox.Show(dbHandler.ReturnStringWhenDuplicatedData(nameToRegister, emailToRegister, "Users"));
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("The selected email format is incorrect, try again\n\n" +
                                                    "EXAMPLES: example@email.com!\n" +
                                                    "my_email123@example.com\n" +
                                                    "123example@email.com\n");
                                }
                            } while (!completeRegister);
                        }
                        else
                        {
                            // CHECKS THAT THE ACTUAL TEXT BOX NAME TEXT AND EMAIL IS NOT USED ALREADY IN THE DB AND SHOWS THE RESULT IN A MESSAGE BOX
                            MessageBox.Show(dbHandler.ReturnStringWhenDuplicatedData(nameToRegister, emailToRegister, "Users"));
                        }
                    }
                    else
                    {
                        MessageBox.Show("The selected password format is incorrect, try again\n\n" +
                                        "EXAMPLES: Secur3&Pass!\n" +
                                        "P@ssw0rd123\n" +
                                        "MyP@ssw0rd!\n" +
                                        "Secret123!\n");
                    }
                }
                else
                {
                    MessageBox.Show("The selected user name format is incorrect, try again\n\n" +
                                    "EXAMPLES: FuryMaster!\n" +
                                    "Thunder_Striker\n" +
                                    "Ice_Wizard!23\n" +
                                    "Savage-Gladiator!\n");
                }
            }
            else
            {
                // LOGS INTO ADMIN MENU
                fAdmin adminLogin = new fAdmin();
                this.Hide();
                adminLogin.ShowDialog();

                txtbPassword.Clear();
                txtbUserName.Clear();
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
