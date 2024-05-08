using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using System.Linq;

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

            // THIS SETS THIS BUTTONS UNCHANGEABLE
            txtbBanned.ReadOnly = true;
            txtbID.ReadOnly = true;
        }


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

        // THESE ARE FOR DETECTING STRING CHANGES IN THE TEXT BOXES SINCE AN ORIGINAL
        // IS REQUIRED TO CHECK BETWEEN THAT ONE AND THE USER CHANGED INPUT
        private bool changeDetected = false;

        // FUNCTION WHICH UPDATES THE VISUAL PART OF THE FORM
        private void ShowUsersRecords(int pos)
        {
            if (dbHandler.UsersQuantity > 0)
            {
                object selectedObjectRecords = dbHandler.GetSelectedTypeObject(pos, "Users");
                if (selectedObjectRecords is User selectedUserRecords)
                {
                    // TAKE VALUES FROM EACH RECORD'S COLUMNS TO SET THEM IN THE APPROPIATE TEXTBOX
                    txtbName.Text = selectedUserRecords.Name;   
                    txtbEmail.Text = selectedUserRecords.Email;
                    txtbPassword.Text = selectedUserRecords.Password;

                    if (!selectedUserRecords.Banned)
                    {
                        txtbBanned.Text = "Not Banned";
                    }
                    else if (selectedUserRecords.Banned)
                    {
                        txtbBanned.Text = "Banned";
                    }

                    int selectedUserID = dbHandler.GetIdentityID("Users", "Name = '" + selectedUserRecords.Name.ToString() + "'");
                    txtbID.Text = selectedUserID.ToString();

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
                        string banInfo = "";

                        if (!(bool)row["Banned"])
                        {
                            banInfo = "Ban Status: Not Banned\n";
                        }
                        else if ((bool)row["Banned"])
                        {
                            banInfo = "Ban Status: Banned\n";
                        }

                        string userInfo = "ID: " + row["ID"] + "\n" +
                                          "Name: " + row["Name"] + "\n" +
                                          "Password: " + row["Password"] + "\n" +
                                          "Email: " + row["Email"] + "\n" +
                                          banInfo;

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

        public string ShowsBannedUsersList()
        {
            string result = "";
            if (dbHandler.UsersQuantity != 0)
            {
                string bannedUsersListTxt = "List of users: \n\n";

                if (dbHandler.UsersQuantity > 1)
                {
                    DataTable usersTable = dbHandler.ImportSelectedDataTable("Users");

                    foreach (DataRow row in usersTable.Rows)
                    {
                        if ((bool)row["Banned"])
                        {
                            string bannedUserInfo = "ID: " + row["ID"] + "\n" +
                                                    "Name: " + row["Name"] + "\n" +
                                                    "Password: " + row["Password"] + "\n" +
                                                    "Email: " + row["Email"] + "\n";

                            bannedUsersListTxt += bannedUserInfo + "\n";
                        }
                    }

                    result = bannedUsersListTxt;
                }
                else if (dbHandler.UsersQuantity == 1)
                {
                    object singleUser = dbHandler.GetSelectedTypeObject(0, "Users");
                    if (singleUser is User singleBannedUser)
                    {
                        if (singleBannedUser.Banned)
                        {
                            bannedUsersListTxt = dbHandler.GetObjectDataFromPosition(singleUser, 0, "User");
                            result = bannedUsersListTxt;
                        }
                        else
                        {
                            result = "No banned users added in the DB.";
                        }
                    }
                }
            }
            else
            {
                result = "No users added in the DB.";
            }
            return result;
        }

        public int SimilarUsersNicknameCounter(string userNickname)
        {
            int counter = 0;
            if (dbHandler.UsersQuantity != 0)
            {
                for (int i = 0; i < dbHandler.UsersQuantity; i++)
                {
                    DataRow userRow = dbHandler.ImportSelectedDataTable("Users").Rows[i];
                    string stringToCheck = userRow[1].ToString().ToLower();
                    if (stringToCheck.Contains(userNickname.ToLower()))
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        public void SelectSimilarUsersNicknameToShow(string userEmail)
        {
            List<string> matchingUsersNickname = new List<string>();
            List<string> extraUsersInfo = new List<string>();
            List<int> usersPositions = new List<int>();

            if (dbHandler.UsersQuantity != 0)
            {
                for (int i = 0; i < dbHandler.UsersQuantity; i++)
                {
                    DataRow userRow = dbHandler.ImportSelectedDataTable("Users").Rows[i];
                    string stringToCheck = userRow[1].ToString().ToLower();
                    if (stringToCheck.Contains(userEmail.ToLower()))
                    {
                        string name = userRow["Name"].ToString();
                        matchingUsersNickname.Add(name);

                        string banInfo = "";

                        if (!(bool)userRow["Banned"])
                        {
                            banInfo = "Ban Status: Not Banned\n";
                        }
                        else if ((bool)userRow["Banned"])
                        {
                            banInfo = "Ban Status: Banned\n";
                        }

                        string usersInfo = "ID: " + userRow["ID"] + "\n" +
                                          "Name: " + userRow["Name"] + "\n" +
                                          "Password: " + userRow["Password"] + "\n" +
                                          "Email: " + userRow["Email"] + "\n" +
                                          banInfo;

                        extraUsersInfo.Add(usersInfo);
                        usersPositions.Add(i);
                    }
                }

            }
            if (matchingUsersNickname.Count == 1)
            {
                MessageBox.Show("The data from " + matchingUsersNickname[0] + " is: \n\n" + extraUsersInfo[0]);
                pos = usersPositions[0];
                ShowUsersRecords(pos);
                RecordPositionLabel(pos);
            }
            else if (matchingUsersNickname.Count > 1)
            {
                bool showed = false;
                int selectedUserIndex = 0;

                while (!showed)
                {
                    StringBuilder infoMessage = new StringBuilder("Users with similar nickname:\n\n");

                    for (int i = 0; i < matchingUsersNickname.Count; i++)
                    {
                        infoMessage.AppendLine((i + 1) + ") " + matchingUsersNickname[i] + "\n");
                    }

                    infoMessage.AppendLine("Select the number of the user to view more data:");

                    string userInput = Interaction.InputBox(infoMessage.ToString());

                    if (int.TryParse(userInput, out selectedUserIndex) && selectedUserIndex > 0 && selectedUserIndex <= matchingUsersNickname.Count)
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
                MessageBox.Show("No user found with the selected nickname.");
            }
        }

        /* ---------------- BUTTONS HANDLING START --------------------- */

        private bool CheckValuesChanged()
        {
            return dbHandler.CheckUserChangesStoredAndActualValues(pos, txtbName.Text, txtbEmail.Text, txtbPassword.Text, txtbBanned.Text);
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
            txtbBanned.Clear();
            pos = -1;
            lblRecord.Text = "";
            ButtonsCheck();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // CHECKS THAT THE ACTUAL TEXT BOX NAME TEXT IS NOT USED ALREADY IN THE DB
            if (!dbHandler.DuplicatedNameDataFromSelectedTable(txtbName.Text, "Users"))
            {
                // CHECKS THAT THE ACTUAL TEXT BOX EMAIL TEXT IS NOT USED ALREADY IN THE DB
                if (!dbHandler.DuplicatedEmailDataFromUsers(txtbEmail.Text))
                {
                    bool banStatus = false;

                    if (txtbBanned.Text == "Not Banned")
                    {
                        banStatus = true;
                    }
                    else if (txtbBanned.Text == "Banned")
                    {
                        banStatus = false;
                    }

                    // CREATES THE TEACHER TO SAVE
                    User savedUser = User.UserCreation(txtbName.Text,
                                                       txtbPassword.Text,
                                                       txtbEmail.Text,
                                                       banStatus);

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (pos != -1 && changeDetected)
            {
                // GETS THE SUPOSED DATA FROM AN OBJECT IN THE ACTUAL POSITION 
                object oldObjectData = dbHandler.GetSelectedTypeObject(pos, "Users");
                // SETS VARIABLES DATA TO CREATE A TEMPORAL NEW USER

                string name = txtbName.Text;
                string email = txtbEmail.Text;
                string password = txtbPassword.Text;
                bool banStatus = false;
                if (txtbBanned.Text == "Banned")
                {
                    banStatus = true;
                }

                // CHECKS IF THE SELECTED OBJECT IS A TEACHER AND CONVERTS THAT OBJECT INTO A TEACHER TYPE TO ACCES TO ITS PROPERTIES
                if (oldObjectData is User oldUserData)
                {
                    // MAKES SURE THAT THE FOLLOWING NICKNAME-MAIL IS NOT USED OR IF IT'S EXACTLY THE SAME BEFORE ANY CHANGE 
                    if (!dbHandler.DuplicatedNameDataFromSelectedTable(name, "Users") || name == oldUserData.Name)
                    {
                        if (!dbHandler.DuplicatedEmailDataFromUsers(email) || email == oldUserData.Email)
                        {
                            // CREATES A NEW OBJECT AS A TEACHER TYPE ONE
                            object selectedUserToUpdate = User.UserCreation(name, password, email, banStatus);
                            if (selectedUserToUpdate != null)
                            {
                                dbHandler.UpdateSelectedObjectFromPosition(selectedUserToUpdate, pos, banStatus, "Users");
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
                    MessageBox.Show("Delete is not possible when no user is selected.");
                }
            }
            else if (dbHandler.UsersQuantity == 0)
            {
                MessageBox.Show("Delete is not possible when no elements are in the database.");
            }
        }

        public void UnbannedUser (bool banStatus)
        {
            if (pos != -1)
            {
                // GETS THE DATA FROM AN OBJECT IN THE ACTUAL POSITION 
                object objectToBan = dbHandler.GetSelectedTypeObject(pos, "Users");

                // CHECKS IF THE SELECTED OBJECT IS A USER AND CONVERTS THAT OBJECT INTO A USER TYPE TO ACCES TO ITS PROPERTIES
                if (objectToBan is User userToBan)
                {
                    // SETS VARIABLES DATA TO CREATE A TEMPORAL NEW USER
                    string name = userToBan.Name;
                    string email = userToBan.Email;
                    string password = userToBan.Password;

                    // CREATES A NEW OBJECT AS A TEACHER TYPE ONE
                    object selectedUserToUpdate = User.UserCreation(name, password, email, banStatus);
                    if (selectedUserToUpdate != null)
                    {
                        dbHandler.UpdateSelectedObjectFromPosition(selectedUserToUpdate, pos, banStatus, "Users");
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
            }
        }

        private void ConfirmBanOrUnban()
        {
            string banStatus = "";

            if (txtbBanned.Text == "Not Banned")
            {
                banStatus = "ban";

            }
            else if (txtbBanned.Text == "Banned")
            {
                banStatus = "unban";
            }

            DialogResult result = MessageBox.Show("Do you want to " + banStatus + " this user (Y/N)?", 
                                                  char.ToUpper(banStatus.First()) + banStatus.Substring(1).ToLower() + 
                                                  " User ? ", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (banStatus == "ban")
                {
                    UnbannedUser(true);
                }
                else
                {
                    UnbannedUser(false);
                }
            }
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            ConfirmBanOrUnban();
        }

        private void btnUnban_Click(object sender, EventArgs e)
        {
            ConfirmBanOrUnban();
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            if (dbHandler.UsersQuantity > 1)
            {
                bool showed = false;
                do
                {
                    string name = Interaction.InputBox("Introduce the user's nickname to show data: ");

                    if (CustomRegex.RegexName(name))
                    {
                        if (SimilarUsersNicknameCounter(name) > 0)
                        {
                            SelectSimilarUsersNicknameToShow(name);
                            showed = true;
                        }
                        else
                        {
                            MessageBox.Show("There isn't any user with the selected nickname, try again");
                            showed = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The nickname format is not correct, try again");
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
                MessageBox.Show("Error, the list has no added users, add a user before checking a user data from the users list");
            }
        }

        private void btnListUsers_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ShowsUsersList());
        }

        private void btnListBannedUsers_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ShowsBannedUsersList());
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
                                  "\nPASSWORD: Contraseña_1 / CONTRASEÑa&2" +
                                  "\nBANNED: Not Banned / Banned"; ;
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

            // ENABLE/DISABLE BAN/UNBAN BUTTONS BASED ON ACTUAL STATUS
            btnBan.Enabled = recordsExist && (txtbBanned.Text == "Not Banned");
            btnUnban.Enabled = recordsExist && (txtbBanned.Text == "Banned");
        }

        // THIS FUNCTION AUTO CHECKS THE CHANGES DETECTED IN THE FOLLOWING TEXT BOXES BETWEEN THE ORIGINAL STRING AND THE NEW CHANGED
        private void UpdateChangeDetected(string currentValue, string originalValue)
        {
            bool anyChangeDetected = (currentValue != originalValue);
            changeDetected = anyChangeDetected;
            ButtonsCheck();
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

        private void txtbBanned_TextChanged(object sender, EventArgs e)
        {
            object actualObject = dbHandler.GetSelectedTypeObject(pos, "Users");
            if (actualObject is User actualUser)
            {
                bool banStatus = false;

                if (txtbBanned.Text == "Not Banned")
                {
                    banStatus = true;
                }
                else if (txtbBanned.Text == "Banned")
                {
                    banStatus = false;
                }

                bool originalBan = actualUser.Banned;
                UpdateChangeDetected(banStatus.ToString(), originalBan.ToString());
            }
        }

        private void txtbID_TextChanged(object sender, EventArgs e)
        {

        }

        /* ---------------- TEXTBOX CHANGE HANDLING FUNCTIONS END --------------------- */
    }
}