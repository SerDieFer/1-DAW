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
    public partial class fTeacher : Form
    {
        public fTeacher()
        {
            InitializeComponent();
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {

        }

        // EVENT HANDLER TO CLOSE THE ACTUAL LOGIN INSTEAD A BUTTON
        // I HAD TO CREATE AN EVENT FOR HANDLING WHEN THIS FORM ITS CLOSED AND ADD ITS ACTIVATION INTO THE DESIGNER OF THIS CLASS
        // this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fAdmin_FormClosing);
        private void fAdmin_FormClosing(object sender, FormClosingEventArgs closeEvent)
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

        // LOADS USER MANAGEMENT MENU
        private void btnAdminUsers_Click(object sender, EventArgs e)
        {
            fAdminUsersManagement adminUsersForm = new fAdminUsersManagement();
            adminUsersForm.ShowDialog();
        }

        // LOADS CHARACTERS MANAGEMENT MENU
        private void btnAdminCharacters_Click(object sender, EventArgs e)
        {
            fAdminCharactersManagement adminCharactersForm = new fAdminCharactersManagement();
            adminCharactersForm.ShowDialog();
        }
    }
}
