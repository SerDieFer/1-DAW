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
                fTeacher adminLogin = new fTeacher();
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
                            fAlumn userLogin = new fAlumn(txtbUserName.Text);
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

        // FORCES APP CLOSING
        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // CLOSES THE APP
            Application.Exit();
        }
    }
}
