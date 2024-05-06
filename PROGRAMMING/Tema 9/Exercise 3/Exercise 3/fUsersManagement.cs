using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Exercise_3
{
    public partial class fUsersManagement : Form
    {
        public fUsersManagement()
        {
            InitializeComponent();
        }

        // CALLING SQLBDHANDLER TO MANAGE DB FUNCTIONS
        SqlDBHandler dbHandler;


        private void fUsersManagement_Load(object sender, EventArgs e)
        {
            dbHandler = new SqlDBHandler("Users");
            // SETS FIRST POSITION, UPDATES THE VISUALS AND CHECKS THE ACTUAL BUTTONS STATUS WHEN FIRST LOADED
            pos = 0;
            RecordPositionLabel(pos);
            ShowUsersRecords(pos);
            ButtonsCheck();
        }

        // THESE ARE FOR DETECTING STRING CHANGES IN THE TEXT BOXES SINCE AN ORIGINAL
        // IS REQUIRED TO CHECK BETWEEN THAT ONE AND THE USER CHANGED INPUT
        private bool changeDetected = false;


        /* ---------------- POSITION HANDLING START --------------------- */

        // CREATION OF GLOBAL POSITION
        private int pos = -1;

        // SETS THE POSITION OF THE ACTUAL RECORD INTO A TEXT LABEL
        private void RecordPositionLabel(int pos)
        {
            if (dbHandler.UsersQuantity > 0)
            {
                lblRecord.Text = "Record Nº" + (pos + 1) + " of " + dbHandler.UsersQuantity;
            }
            else if (dbHandler.UsersQuantity == 0)
            {
                lblRecord.Text = "";
            }
        }

        /* ---------------- POSITION HANDLING END --------------------- */


        // FUNCTION WHICH UPDATES THE VISUAL PART OF THE FORM
        private void ShowUsersRecords(int pos)
        {
            if (dbHandler.UsersQuantity > 0)
            {
                object selectedObjectRecords = dbHandler.GetSelectedTypeObject(pos, "Users");
                if (selectedObjectRecords is User selectedUserRecords)
                {

                    // TAKE VALUES FROM EACH RECORD'S COLUMNS TO SET THEM IN THE APPROPIATE TEXTBOX
                    txtbID.Text = selectedUserRecords.ID.ToString();
                    txtbName.Text = selectedUserRecords.Name;
                    txtbEmail.Text = selectedUserRecords.Email;
                    txtbPassword.Text = selectedUserRecords.Password;


                    // DETECTED CHANGES RESET AND CHECKS THE ACTUAL BUTTONS STATUS
                    changeDetected = false;
                    ButtonsCheck();
                }
            }
            else if (dbHandler.UsersQuantity == 0)
            {
                // CLEAR EVERY DATA FROM THE TEXT BOXES AND CHECKS THE ACTUAL BUTTONS STATUS
                btnClear.PerformClick();
                ButtonsCheck();
            }
        }

        public string ShowsUsersList()
        {
            string result = "";
            if (dbHandler.UsersQuantity != 0)
            {
                string usersListTxt = "List of users: \n\n";

                if (dbHandler.UsersQuantity > 1)
                {
                    DataTable usersTable = dbHandler.ImportSelectedDataTable("Users");

                    foreach (DataRow row in usersTable.Rows)
                    {
                        string userInfo = "ID: " + row["ID"] + "\n" +
                                          "Name: " + row["Name"] + "\n" +
                                          "Password: " + row["Password"] + "\n" +
                                          "Email: " + row["Email"] + "\n";

                        usersListTxt += userInfo + "\n";
                    }
                    result = usersListTxt;
                }
                else if (dbHandler.UsersQuantity == 1)
                {
                    object singleUser = dbHandler.GetSelectedTypeObject(0, "Users");
                    usersListTxt = dbHandler.GetObjectDataFromPosition(singleUser, 0, "User");
                    result = usersListTxt;
                }
            }
            else
            {
                result = "No users added in the DB.";
            }
            return result;
        }

        public int SimilarUsersEmailCounter(string userEmail)
        {
            int counter = 0;
            if (dbHandler.UsersQuantity != 0)
            {
                for (int i = 0; i < dbHandler.UsersQuantity; i++)
                {
                    DataRow userRow = dbHandler.ImportSelectedDataTable("Users").Rows[i];
                    string stringToCheck = userRow[4].ToString().ToLower();
                    if (stringToCheck.Contains(userEmail.ToLower()))
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        public void SelectSimilarUsersEmailsToShow(string userEmail)
        {
            List<string> matchingUsersEmail = new List<string>();
            List<string> extraUsersInfo = new List<string>();
            List<int> usersPositions = new List<int>();

            if (dbHandler.UsersQuantity != 0)
            {
                for (int i = 0; i < dbHandler.UsersQuantity; i++)
                {
                    DataRow userRow = dbHandler.ImportSelectedDataTable("Users").Rows[i];
                    string stringToCheck = userRow[4].ToString().ToLower();
                    if (stringToCheck.Contains(userEmail.ToLower()))
                    {
                        string email = userRow["Email"].ToString();
                        matchingUsersEmail.Add(email);

                        string usersInfo = "ID: " + userRow["ID"] + "\n" +
                                           "Name: " + userRow["Name"] + "\n" +
                                           "Email: " + userRow["Email"] + "\n" +
                                           "Password: " + userRow["Password"];
                           
                        extraUsersInfo.Add(usersInfo);
                        usersPositions.Add(i);
                    }
                }

            }
            if (matchingUsersEmail.Count == 1)
            {
                MessageBox.Show("The data from " + matchingUsersEmail[0] + " is: \n\n" + extraUsersInfo[0]);
                pos = usersPositions[0];
                ShowUsersRecords(pos);
                RecordPositionLabel(pos);
            }
            else if (matchingUsersEmail.Count > 1)
            {
                bool showed = false;
                int selectedUserIndex = 0;

                while (!showed)
                {
                    StringBuilder infoMessage = new StringBuilder("Users with similar email:\n\n");

                    for (int i = 0; i < matchingUsersEmail.Count; i++)
                    {
                        infoMessage.AppendLine((i + 1) + ") " + matchingUsersEmail[i] + "\n");
                    }

                    infoMessage.AppendLine("Select the number of the user to view more data:");

                    string userInput = Interaction.InputBox(infoMessage.ToString());

                    if (int.TryParse(userInput, out selectedUserIndex) && selectedUserIndex > 0 && selectedUserIndex <= matchingUsersEmail.Count)
                    {
                        string selectedUserInfo = extraUsersInfo[selectedUserIndex - 1];
                        int selectedUserPositionInDB = usersPositions[selectedUserIndex - 1];

                        DialogResult result = MessageBox.Show(selectedUserInfo + "\n\nIs this the user you want to check info?", "Check User Info", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            pos = selectedUserPositionInDB;
                            ShowUsersRecords(pos);
                            RecordPositionLabel(pos);
                            showed = true;
                        }
                        else
                        {
                            MessageBox.Show("Please select a different user.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid number corresponding to a user.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No user found with the selected name.");
            }
        }

        /* ---------------- BUTTONS HANDLING START --------------------- */

        private bool CheckValuesChanged()
        {
            return dbHandler.CheckUserChangesStoredAndActualValues(pos, txtbName.Text, txtbEmail.Text, txtbPassword.Text);
        }


        private void askToUpdateIfChangesWereMade(bool choice)
        {
            if (!choice)
            {
                DialogResult update = MessageBox.Show("Do you want to keep changes of this record (Y/N)?", "Keep Changes?", MessageBoxButtons.YesNo);

                if (update == DialogResult.Yes)
                {
                    btnUpdate.PerformClick();
                }
            }
        }

        private void btnCancelAddRegistry_Click(object sender, EventArgs e)
        {
            pos = 0;
            ShowUsersRecords(pos);
            RecordPositionLabel(pos);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                pos = 0;
                RecordPositionLabel(pos);
                ShowUsersRecords(pos);
            }
            else
            {
                bool possiblyChangedValues = CheckValuesChanged();

                if (possiblyChangedValues && (pos == -1))
                {
                    pos = 0;
                    RecordPositionLabel(pos);
                    ShowUsersRecords(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos = 0;
                    RecordPositionLabel(pos);
                    ShowUsersRecords(pos);
                }
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                pos = dbHandler.UsersQuantity - 1;
                RecordPositionLabel(pos);
                ShowUsersRecords(pos);
            }
            else
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (pos == -1))
                {
                    pos = dbHandler.UsersQuantity - 1;
                    RecordPositionLabel(pos);
                    ShowUsersRecords(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos = dbHandler.UsersQuantity - 1;
                    RecordPositionLabel(pos);
                    ShowUsersRecords(pos);
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                btnFirst.PerformClick();
            }
            else if (pos < (dbHandler.UsersQuantity - 1))
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (pos == -1))
                {
                    pos++;
                    RecordPositionLabel(pos);
                    ShowUsersRecords(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos++;
                    RecordPositionLabel(pos);
                    ShowUsersRecords(pos);
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                btnFirst.PerformClick();
            }
            else if (pos > 0)
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (pos == -1))
                {
                    pos--;
                    RecordPositionLabel(pos);
                    ShowUsersRecords(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos--;
                    RecordPositionLabel(pos);
                    ShowUsersRecords(pos);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtbID.Clear();
            txtbName.Clear();
            txtbEmail.Clear();
            txtbPassword.Clear();
            pos = -1;
            lblRecord.Text = "";
            ButtonsCheck();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // CHECKS THAT THE ACTUAL TEXT BOX ID TEXT IS NOT USED ALREADY IN THE DB
            if (!dbHandler.DuplicatedIDDataFromSelectedTable(txtbID.Text, "Users"))
            {
                // CHECKS THAT THE ACTUAL TEXT BOX NAME TEXT IS NOT USED ALREADY IN THE DB
                if (!dbHandler.DuplicatedNameDataFromSelectedTable(txtbName.Text, "Users"))
                {
                    // CHECKS THAT THE ACTUAL TEXT BOX EMAIL TEXT IS NOT USED ALREADY IN THE DB
                    if (!dbHandler.DuplicatedEmailDataFromUsers(txtbEmail.Text))
                    {
                        // CREATES THE TEACHER TO SAVE
                        User savedUser = User.UserCreation(txtbName.Text,
                                                           txtbEmail.Text,
                                                           txtbPassword.Text);

                        // IF THIS OBJECT IS VALID IT WILL BE INSERTED INTO THE DB
                        if (savedUser != null)
                        {
                            // FUNCTION WHICH CREATES A NEW USER INTO THE DB
                            // AFTER THAT UPDATES THE POSITION AND THE COUNT OF USERS'S RECORDS
                            dbHandler.AddNewObject(savedUser, "Users");
                            pos = dbHandler.UsersQuantity - 1;
                            RecordPositionLabel(pos);
                            btnCancelAddRegistry.PerformClick();
                            ButtonsCheck();
                        }
                        else
                        {
                            MessageBox.Show(returnErrorInput());
                        }
                    }
                    else
                    {
                        MessageBox.Show("This email is already used, try another one");
                    }
                }
                else
                {
                    MessageBox.Show("This nickname is already used, try another one");
                }
            }
            else
            {
                MessageBox.Show("This ID is already used, try another one");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (pos != -1 && changeDetected)
            {
                // SETS VARIABLES DATA TO CREATE A TEMPORAL NEW TEACHER
                int ID = int.Parse(txtbID.Text);
                string name = txtbName.Text;
                string email = txtbEmail.Text;
                string password = txtbPassword.Text;

                // GETS THE SUPOSED DATA FROM AN OBJECT IN THE ACTUAL POSITION 
                object oldObjectData = dbHandler.GetSelectedTypeObject(pos, "Users");

                // CHECKS IF THE SELECTED OBJECT IS A TEACHER AND CONVERTS THAT OBJECT INTO A TEACHER TYPE TO ACCES TO ITS PROPERTIES
                if (oldObjectData is User oldUserData)
                {
                    // MAKES SURE THAT THE FOLLOWING ID-NICKNAME-MAIL IS NOT USED OR IF IT'S EXACTLY THE SAME BEFORE ANY CHANGE 
                    if (!dbHandler.DuplicatedIDDataFromSelectedTable(ID.ToString(), "Users") || ID == oldUserData.ID)
                    {
                        if (!dbHandler.DuplicatedNameDataFromSelectedTable(name, "Users") || name == oldUserData.Name)
                        {
                            if (!dbHandler.DuplicatedEmailDataFromUsers(email) || email == oldUserData.Email)
                            {
                                // CREATES A NEW OBJECT AS A TEACHER TYPE ONE
                                object selectedObjectToUpdate = User.UserCreation(name, password, email);
                                if (selectedObjectToUpdate != null)
                                {
                                    dbHandler.UpdateSelectedObjectFromPosition(selectedObjectToUpdate, pos, "Users");
                                    ShowUsersRecords(pos);
                                    RecordPositionLabel(pos);
                                    changeDetected = false;
                                    ButtonsCheck();
                                }
                                else
                                {
                                    MessageBox.Show(returnErrorInput());
                                }

                            }
                            else
                            {
                                MessageBox.Show("This email is already used, try another one");
                            }
                        }
                        else
                        {
                            MessageBox.Show("This nickname is already used, try another one");
                        }
                    }
                    else
                    {
                        MessageBox.Show("This ID is already used, try another one");
                    }

                }
                else if (dbHandler.UsersQuantity == 0)
                {
                    MessageBox.Show("Updating without having atleast one user in the DB is meaningless, try again after adding a user to the DB.");
                }
                else
                {
                    MessageBox.Show(returnErrorInput());
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dbHandler.UsersQuantity > 0)
            {
                if (pos != -1)
                {
                    DialogResult delete;
                    delete = MessageBox.Show("Do you want to delete this record (Y/N)?", "Delete Record?", MessageBoxButtons.YesNo);

                    if (delete == DialogResult.Yes)
                    {
                        dbHandler.DeleteSelectedObjectFromPosition(pos, "Users");

                        // RESETS POSITION
                        pos = 0;
                        RecordPositionLabel(pos); // RELOADS THE POSITION LABEL
                        ShowUsersRecords(pos);
                        ButtonsCheck();
                    }
                }
                else
                {
                    MessageBox.Show("Delete is not possible when no teacher is selected.");
                }
            }
            else if (dbHandler.UsersQuantity == 0)
            {
                MessageBox.Show("Delete is not possible when no elements are in the database.");
            }
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            if (dbHandler.UsersQuantity > 1)
            {
                bool showed = false;
                do
                {
                    string userEmail = Interaction.InputBox("Introduce the user's email to show data: ");

                    if (CustomRegex.RegexEmail(userEmail))
                    {
                        if (SimilarUsersEmailCounter(userEmail) > 0)
                        {
                            SelectSimilarUsersEmailsToShow(userEmail);
                            showed = true;
                        }
                        else
                        {
                            MessageBox.Show("There isn't any user with the selected email, try again");
                            showed = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The email format is not correct, try again");
                    }

                } while (!showed);

            }
            else if (dbHandler.UsersQuantity == 1)
            {
                object uniqueUser = dbHandler.GetSelectedTypeObject(0, "Users");
                MessageBox.Show("There's only one user so it's data will be the one showed.");
                MessageBox.Show(dbHandler.GetObjectDataFromPosition(uniqueUser, 0, "Users"));
            }
            else
            {
                MessageBox.Show("Error, the list has no added users, add a user before checking a user data from the teacher list");
            }
        }

        private void btnListUsers_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ShowsUsersList());
        }

        /* ---------------- BUTTONS HANDLING END --------------------- */

        /* ---------------- INPUT ERROR HANDLING START --------------------- */

        // ERROR STRING IF INPUT IS INVALID
        private string returnErrorInput()
        {
            string errorMessage = "Error, not valid data, try again. " +
                                  "\n\nEXAMPLE:" +
                                  "\nID: 1 / 2" +
                                  "\nNAME: Sergio" +
                                  "\nEMAIL: x@x.com" +
                                  "\nPASSWORD: Contraseña_1 / CONTRASEÑa&2";
            return errorMessage;
        }

        /* ---------------- INPUT ERROR HANDLING END --------------------- */

        /* ---------------- TEXTBOX CHANGE HANDLING FUNCTIONS START --------------------- */

        public void ButtonsCheck()
        {
            bool recordsExist = (dbHandler.UsersQuantity > 0);
            bool noRecordSelected = (pos == -1);

            // ENABLE/DISABLE NAVIGATION BUTTONS
            btnNext.Enabled = (recordsExist && pos < dbHandler.UsersQuantity - 1) && !noRecordSelected;
            btnLast.Enabled = (recordsExist && pos < dbHandler.UsersQuantity - 1) && !noRecordSelected;
            btnPrevious.Enabled = (recordsExist && pos > 0) && !noRecordSelected;
            btnFirst.Enabled = (recordsExist && pos > 0) && !noRecordSelected;

            // ENABLE/DISABLE SAVE BUTTON IF NO RECORD IS SELECTED
            btnSave.Enabled = noRecordSelected;

            // ENABLE/DISABLE CANCEL ADD REGISTRY BUTTON IF NO RECORD IS SELECTED
            btnCancelAddRegistry.Enabled = noRecordSelected && recordsExist;

            // ENABLE/DISABLE DELETE AND UPDATE BUTTONS IF A RECORD IS SELECTED
            btnDelete.Enabled = recordsExist && !noRecordSelected;
            btnUpdate.Enabled = recordsExist && !noRecordSelected && changeDetected;

            // ENABLE/DISABLE OTHER BUTTONS BASED ON RECORD EXISTENCE
            btnClear.Enabled = recordsExist && !noRecordSelected;
            btnListUsers.Enabled = recordsExist;
            btnSearchUser.Enabled = recordsExist;
        }

        // THIS FUNCTION AUTO CHECKS THE CHANGES DETECTED IN THE FOLLOWING TEXT BOXES BETWEEN THE ORIGINAL STRING AND THE NEW CHANGED
        private void UpdateChangeDetected(string currentValue, string originalValue)
        {
            bool anyChangeDetected = (currentValue != originalValue);
            changeDetected = anyChangeDetected;
            ButtonsCheck();
        }
        private void txtbID_TextChanged(object sender, EventArgs e)
        {
            object actualObject = dbHandler.GetSelectedTypeObject(pos, "Users");
            if (actualObject is User actualUser)
            {
                int originalID = actualUser.ID;
                UpdateChangeDetected(txtbID.Text, actualUser.ID.ToString());
            }
        }

        private void txtbName_TextChanged(object sender, EventArgs e)
        {
            object actualObject = dbHandler.GetSelectedTypeObject(pos, "Users");
            if (actualObject is User actualUser)
            {
                string originalName = actualUser.Name;
                UpdateChangeDetected(txtbName.Text, originalName);
            }
        }

        private void txtbEmail_TextChanged(object sender, EventArgs e)
        {
            object actualObject = dbHandler.GetSelectedTypeObject(pos, "Users");
            if (actualObject is User actualUser)
            {
                string originalEmail = actualUser.Email;
                UpdateChangeDetected(txtbEmail.Text, originalEmail);
            }
        }

        private void txtbPassword_TextChanged(object sender, EventArgs e)
        {
            object actualObject = dbHandler.GetSelectedTypeObject(pos, "Users");
            if (actualObject is User actualUser)
            {
                string originalPassword = actualUser.Password;
                UpdateChangeDetected(txtbPassword.Text, originalPassword);
            }
        }

        /* ---------------- TEXTBOX CHANGE HANDLING FUNCTIONS END --------------------- */
    }
}