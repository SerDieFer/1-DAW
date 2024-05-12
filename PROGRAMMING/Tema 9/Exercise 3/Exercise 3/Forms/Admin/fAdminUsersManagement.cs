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
using Microsoft.VisualBasic.ApplicationServices;
using System.Security.Cryptography;

namespace Exercise_3
{
    public partial class fAdminUsersManagement : Form
    {
        public fAdminUsersManagement()
        {
            InitializeComponent();
        }

        // CALLING SQLBDHANDLER TO MANAGE DB FUNCTIONS
        SqlDBHandler dbHandler;

        private void fUsersManagement_Load(object sender, EventArgs e)
        {
            // CONSTRUCTION OF THE DATABASE HANDLER FOR THE USERS TABLE
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

        /*---------------------------------------------- POSITION HANDLING START ------------------------------------------------*/

        // GLOBAL VARIABLE TO STORE THE CURRENT POSITION
        private int pos = -1;

        // FUNCTION TO DISPLAY THE CURRENT RECORD POSITION IN A TEXT LABEL
        private void RecordPositionLabel(int pos)
        {
            if (dbHandler.UsersQuantity > 0)
            {
                // UPDATE THE LABEL TEXT WITH THE CURRENT RECORD POSITION
                lblRecord.Text = "Record Nº" + (pos + 1) + " of " + dbHandler.UsersQuantity;
            }
            else if (dbHandler.UsersQuantity == 0)
            {
                // CLEAR THE LABEL TEXT IF THERE ARE NO RECORDS
                lblRecord.Text = "";
            }
        }

        /*--------------------------------------------- POSITION HANDLING END ---------------------------------------------------*/

        /*---------------------------------------- VISUAL HANDLING FUNCTIONS START ----------------------------------------------*/

        // BOOL TO INDICATE IF CHANGES HAVE BEEN DETECTED IN THE TEXT BOXES
        private bool changeDetected = false;

        // FUNCTION TO UPDATE THE VISUAL PART OF THE FORM WITH USER RECORDS
        private void ShowUsersRecords(int pos)
        {
            if (dbHandler.UsersQuantity > 0)
            {
                // GET THE SELECTED USER OBJECT FROM THE DATABASE
                object selectedObjectRecords = dbHandler.GetSelectedTypeObject(pos, "Users");

                if (selectedObjectRecords is User selectedUserRecords)
                {
                    // SET VALUES FROM THE SELECTED USER RECORD INTO THE TEXTBOXES
                    txtbName.Text = selectedUserRecords.Name;   
                    txtbEmail.Text = selectedUserRecords.Email;
                    txtbPassword.Text = selectedUserRecords.Password;

                    // SET THE BANNED STATUS TEXT BASED ON THE USER RECORD
                    if (!selectedUserRecords.Banned)
                    {
                        txtbBanned.Text = "Not Banned";
                    }
                    else if (selectedUserRecords.Banned)
                    {
                        txtbBanned.Text = "Banned";
                    }

                    // GET THE IDENTITY ID OF THE SELECTED USER AND DISPLAY IT IN THE TEXT BOX BY SELECTION A TABLE AND A CERTAIN CONDITION
                    string query = "SELECT ID FROM Users WHERE Name = '" + selectedUserRecords.Name.ToString() + "'";
                    int selectedUserID = dbHandler.GetIdentityID("Users", query);
                    txtbID.Text = selectedUserID.ToString();

                    // RESET THE CHANGE DETECTED BOOL AND CHECK BUTTONS STATUS
                    changeDetected = false;
                    ButtonsCheck();
                }
            } 
            else if (dbHandler.UsersQuantity == 0)
            {
                // CLEAR ALL TEXT BOXES AND CHECK BUTTONS STATUS IF NO RECORDS ARE AVAILABLE
                btnClear.PerformClick();
                ButtonsCheck();
            }
        }

        /*----------------------------------------------- VISUAL HANDLING FUNCTIONS END -------------------------------------------------*/

        /*------------------------------------------ GET USER INFO RELATED FUNCTIONS START ----------------------------------------------*/

        // FUNCTION THAT RETURNS THE USER LIST
        public string ShowsUsersList()
        {
            string result = "";
            if (dbHandler.UsersQuantity != 0)
            {
                string usersListTxt = "List of users: \n\n";
                if (dbHandler.UsersQuantity > 1)
                {
                    // GET THE USERS TABLE FROM THE DATABASE
                    DataTable usersTable = dbHandler.ImportSelectedDataTable("Users");

                    // CHECK USERS FROM TABLE
                    foreach (DataRow row in usersTable.Rows)
                    {
                        string banInfo = "";

                        // DETERMINE THE BAN STATUS
                        if (!(bool)row["Banned"])
                        {
                            banInfo = "Ban Status: Not Banned\n";
                        }
                        else if ((bool)row["Banned"])
                        {
                            banInfo = "Ban Status: Banned\n";
                        }

                        // CONCATENATE USER INFORMATION
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
                    // GET INFORMATION FOR A SINGLE USER
                    object singleUser = dbHandler.GetSelectedTypeObject(0, "Users");

                    usersListTxt = dbHandler.GetObjectDataFromPosition(singleUser, 0, "Users");
                    result = usersListTxt;
                }
            }
            else
            {
                result = "No users added in the DB.";
            }
            return result;
        }

        // FUNCTION THAT RETURNS THE BANNED USER LIST
        public string ShowsBannedUsersList()
        {
            string result = "";
            if (dbHandler.UsersQuantity == 0)
            {
                result = "No users added in the DB.";
            }

            string bannedUsersListTxt = "";
            int bannedCount = 0;

            // GET THE USERS TABLE FROM THE DATABASE
            DataTable usersTable = dbHandler.ImportSelectedDataTable("Users");

            // CHECK USERS FROM TABLE
            foreach (DataRow row in usersTable.Rows)
            {
                // CHECK IF THE USER IS BANNED
                if ((bool)row["Banned"])
                {
                    bannedCount++;

                    // ADD BANNED USER INFORMATION
                    string bannedUserInfo = "ID: " + row["ID"] + "\n" +
                                            "Name: " + row["Name"] + "\n" +
                                            "Password: " + row["Password"] + "\n" +
                                            "Email: " + row["Email"] + "\n";

                    bannedUsersListTxt += bannedUserInfo + "\n";
                }
            }

            if (bannedCount == 0)
            {
                result = "No banned users added in the DB.";
            }
            else if (bannedCount == 1)
            {
                result = "Banned User: \n\n" + bannedUsersListTxt;
            }
            else if (bannedCount > 1)
            {
                result = "List of banned users: \n\n" + bannedUsersListTxt;
            }
            return result;
        }

        // METHOD TO COUNT USERS WITH SIMILAR NICKNAMES
        public int CountSimilarUsersNickname(string userNickname)
        {
            int counter = 0;
            if (dbHandler.UsersQuantity != 0)
            {
                for (int i = 0; i < dbHandler.UsersQuantity; i++)
                {
                    // GET THE USER ROW FROM THE USERS TABLE
                    DataRow userRow = dbHandler.ImportSelectedDataTable("Users").Rows[i];

                    // GET THE NICKNAME FROM THE CURRENT USER ROW AND CONVERT IT TO LOWERCASE
                    string stringToCheck = userRow[1].ToString().ToLower();

                    // CHECK IF THE NICKNAME CONTAINS THE INPUT USER NICKNAME
                    if (stringToCheck.Contains(userNickname.ToLower()))
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        // METHOD TO SELECT AND SHOW USERS WITH SIMILAR NICKNAMES
        public void ShowSimilarUsersNickname(string userNickname)
        {
            // LISTS TO STORE MATCHING USERS' NICKNAMES, EXTRA INFO, AND THEIR POSITIONS
            List<string> matchingUsersNickname = new List<string>();
            List<string> extraUsersInfo = new List<string>();
            List<int> usersPositions = new List<int>();

            if (dbHandler.UsersQuantity != 0)
            {
                for (int i = 0; i < dbHandler.UsersQuantity; i++)
                {
                    // GET THE USER ROW FROM THE USERS TABLE
                    DataRow userRow = dbHandler.ImportSelectedDataTable("Users").Rows[i];

                    // GET THE NICKNAME FROM THE CURRENT USER ROW AND CONVERT IT TO LOWERCASE
                    string stringToCheck = userRow[1].ToString().ToLower();

                    // CHECK IF THE NICKNAME CONTAINS THE INPUT USER NICKNAME
                    if (stringToCheck.Contains(userNickname.ToLower()))
                    {
                        // ADD THE USER'S NICKNAME TO THE MATCHING USERS LIST
                        string name = userRow["Name"].ToString();
                        matchingUsersNickname.Add(name);

                        // DETERMINE BAN STATUS
                        string banInfo = "";
                        if (!(bool)userRow["Banned"])
                        {
                            banInfo = "Ban Status: Not Banned\n";
                        }
                        else if ((bool)userRow["Banned"])
                        {
                            banInfo = "Ban Status: Banned\n";
                        }

                        // ADD USER INFO
                        string usersInfo = "ID: " + userRow["ID"] + "\n" +
                                           "Name: " + userRow["Name"] + "\n" +
                                           "Password: " + userRow["Password"] + "\n" +
                                           "Email: " + userRow["Email"] + "\n" +
                                           banInfo;

                        // ADD USER INFO TO THE EXTRA INFO LIST
                        extraUsersInfo.Add(usersInfo);

                        // ADD USER POSITION TO THE POSITIONS LIST
                        usersPositions.Add(i);
                    }
                }
            }
            if (matchingUsersNickname.Count == 1)
            {
                // SHOW USER INFO AND RECORD POSITION
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

                    // DISPLAY USERS WITH SIMILAR NICKNAMES
                    for (int i = 0; i < matchingUsersNickname.Count; i++)
                    {
                        infoMessage.AppendLine((i + 1) + ") " + matchingUsersNickname[i] + "\n");
                    }

                    // MAKES THE USER TO SELECT A USER
                    infoMessage.AppendLine("Select the number of the user to view more data:");

                    string userInput = Interaction.InputBox(infoMessage.ToString());

                    // CHECK USER INPUT
                    if (int.TryParse(userInput, out selectedUserIndex) && selectedUserIndex > 0 && selectedUserIndex <= matchingUsersNickname.Count)
                    {
                        // GET SELECTED USER INFO AND POSITION
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

        /*------------------------------------------ GET USER INFO RELATED FUNCTIONS END --------------------------------------------------------*/

        /* ----------------------------------------------- BUTTONS HANDLING START -------------------------------------------------------------- */

        /*--------------------------------- CRUD BUTTONS ACTIONS START -------------------------------*/

        // SAVES AN USER (CREATE)
        private void btnSave_Click(object sender, EventArgs e)
        {
            // CHECK IF THERE ARE NO DUPLICATED DATA FOR THE USER
            if (!dbHandler.CheckAllUserDuplicatedData(txtbName.Text, txtbEmail.Text, "Users"))
            {
                // CREATES THE USER TO SAVE
                User savedUser = User.UserCreation(txtbName.Text, txtbPassword.Text, txtbEmail.Text, false);

                // IF THE USER OBJECT IS VALID, INSERT IT INTO THE DATABASE
                if (savedUser != null)
                {
                    // ADD THE NEW USER TO THE DATABASE
                    dbHandler.AddNewObject(savedUser, "Users");

                    // UPDATE THE POSITION AND THE VISUALS
                    pos = dbHandler.UsersQuantity - 1;
                    RecordPositionLabel(pos);

                    // CHECK BUTTONS STATUS
                    ButtonsCheck();
                }
                else
                {
                    MessageBox.Show(returnErrorInput());
                }
            }
            else
            {
                // CHECKS THAT THE ACTUAL TEXT BOX NAME TEXT AND EMAIL IS NOT USED ALREADY IN THE DB AND SHOWS THE RESULT IN A MESSAGE BOX
                MessageBox.Show(dbHandler.ReturnStringWhenDuplicatedData(txtbName.Text, txtbEmail.Text, "Users"));
            }
        }

        // SEARCHS USER DATA (READ)
        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            if (dbHandler.UsersQuantity > 1)
            {
                bool showed = false;
                do
                {
                    string name = Interaction.InputBox("Introduce the user's nickname to show data: ");

                    // CHECK IF THE ENTERED NICKNAME HAS A VALID FORMAT
                    if (CustomRegex.RegexName(name))
                    {
                        // CHECK IF THERE ARE USERS WITH SIMILAR NICKNAMES
                        if (CountSimilarUsersNickname(name) > 0)
                        {
                            // SHOW DATA OF SIMILAR USERS
                            ShowSimilarUsersNickname(name);
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
                // IF THERE IS ONLY ONE USER, DISPLAY ITS DATA
                object uniqueUser = dbHandler.GetSelectedTypeObject(0, "Users");
                MessageBox.Show("There's only one user so it's data will be the one showed.");
                MessageBox.Show(dbHandler.GetObjectDataFromPosition(uniqueUser, 0, "Users"));
            }
            else
            {
                MessageBox.Show("Error, the list has no added users, add a user before checking a user data from the users list");
            }
        }

        // UPDATE USER (UPDATE)
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (pos != -1 && changeDetected)
            {
                // GET THE OLD OBJECT DATA FROM THE DATABASE 
                object oldObjectData = dbHandler.GetSelectedTypeObject(pos, "Users");

                // SET VARIABLES TO CREATE A NEW USER
                string name = txtbName.Text;
                string email = txtbEmail.Text;
                string password = txtbPassword.Text;        
                bool banStatus = false;

                if (txtbBanned.Text == "Banned")
                {
                    banStatus = true;
                }

                // CHECK IF THE SELECTED OBJECT IS A USER AND CONVERT IT INTO A USER TYPE TO ACCESS ITS PROPERTIES
                if (oldObjectData is User oldUserData)
                {
                    // CHECK IF THE NEW NAME IS NOT DUPLICATED OR IF IT'S THE SAME AS THE OLD ONE
                    if (!dbHandler.DuplicatedNameData(name, "Users") || name == oldUserData.Name)
                    {
                        // CHECK IF THE NEW EMAIL IS NOT DUPLICATED OR IF IT'S THE SAME AS THE OLD ONE
                        if (!dbHandler.DuplicatedEmailDataFromUsers(email) || email == oldUserData.Email)
                        {
                            // CREATE A NEW USER OBJECT
                            object selectedUserToUpdate = User.UserCreation(name, password, email, banStatus);

                            // IF THE NEW USER OBJECT IS VALID, UPDATE THE OBJECT IN THE DATABASE
                            if (selectedUserToUpdate != null)
                            {
                                dbHandler.UpdateObjectFromPosition(selectedUserToUpdate, pos, banStatus, "Users");
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

        // DELETES USER (DELETE)
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
                        dbHandler.DeleteObjectFromPosition(pos, "Users");                 
                        pos = 0;
                        RecordPositionLabel(pos);
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


        /*------------------------------- CRUD BUTTONS ACTIONS END -------------------------------*/

        /*------------------------ GENERAL BUTTONS SUPPORT FUNCTIONS START -----------------------*/

        // FUNCTION TO CHECK IF VALUES FROM THE ACTUAL USER POSITION HAVE CHANGED IN THE TEXT BOXES
        private bool CheckValuesChanged()
        {
            return dbHandler.CheckUserChangesStoredAndActualValues(pos, txtbName.Text, txtbEmail.Text, txtbPassword.Text, txtbBanned.Text);
        }

        // FUNCTION TO ASK USER TO UPDATE IF CHANGES WERE MADE 
        private void AskToUpdateIfChangesWereMade(bool choice)
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

        /*------------------------- GENERAL BUTTONS SUPPORT FUNCTIONS END ------------------------*/

        /*---------------------------- NAVIGATION BUTTONS ACTIONS START --------------------------*/

        // FIRST USER ADDED
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
                // CHECK IF THERE ARE POSSIBLY CHANGED VALUES AND IF THE POSITION IS NOT -1
                bool possiblyChangedValues = CheckValuesChanged();

                if (possiblyChangedValues && (pos == -1))
                {
                    pos = 0;
                    RecordPositionLabel(pos);
                    ShowUsersRecords(pos);
                }
                else
                {
                    // ASK TO UPDATE IF CHANGES WERE MADE
                    AskToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos = 0;
                    RecordPositionLabel(pos);
                    ShowUsersRecords(pos);
                }
            }
        }

        // LAST USER ADDED
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
                // CHECK IF THERE ARE POSSIBLY CHANGED VALUES AND IF THE POSITION IS NOT -1
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (pos == -1))
                {
                    pos = dbHandler.UsersQuantity - 1;
                    RecordPositionLabel(pos);
                    ShowUsersRecords(pos);
                }
                else
                {
                    // ASK TO UPDATE IF CHANGES WERE MADE
                    AskToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos = dbHandler.UsersQuantity - 1;
                    RecordPositionLabel(pos);
                    ShowUsersRecords(pos);
                }
            }
        }

        // NEXT USER
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                btnFirst.PerformClick();
            }
            else if (pos < (dbHandler.UsersQuantity - 1))
            {
                // CHECK IF THERE ARE POSSIBLY CHANGED VALUES AND IF THE POSITION IS NOT -1
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (pos == -1))
                {
                    pos++;
                    RecordPositionLabel(pos);
                    ShowUsersRecords(pos);
                }
                else
                {
                    // ASK TO UPDATE IF CHANGES WERE MADE
                    AskToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos++;
                    RecordPositionLabel(pos);
                    ShowUsersRecords(pos);
                }
            }
        }

        // PREVIOUS USER
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                btnFirst.PerformClick();
            }
            else if (pos > 0)
            {
                // CHECK IF THERE ARE POSSIBLY CHANGED VALUES AND IF THE POSITION IS NOT -1
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (pos == -1))
                {
                    pos--;
                    RecordPositionLabel(pos);
                    ShowUsersRecords(pos);
                }
                else
                {
                    // ASK TO UPDATE IF CHANGES WERE MADE
                    AskToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos--;
                    RecordPositionLabel(pos);
                    ShowUsersRecords(pos);
                }
            }
        }

        /*---------------------------- NAVIGATION BUTTONS ACTIONS END ----------------------------*/

        /*------------------ CLEARING AND RESETING BUTTONS ACTIONS START -------------------------*/

        // CLEARS ALL THE DATA FROM THE TEXT BOXES AND UPDATES THE ID AND THE BAN STATUS TO THE NEXT ID AVALIABLE AND THE BAN STATUS TO DEFAULT
        private void btnClear_Click(object sender, EventArgs e)
        {
            // QUERY TO GET THE CURRENT IDENTITY ID
            string query = "SELECT IDENT_CURRENT('Users')";

            // SETS THE ID TEXT BOX TO THE NEXT AVAILABLE ID
            txtbID.Text = ((dbHandler.GetIdentityID("Users", query) + 1).ToString());

            // CLEARS THE TEXT BOXES
            txtbName.Clear();
            txtbEmail.Clear();
            txtbPassword.Clear();

            // SETS THE BAN STATUS TEXT BOX TO DEFAULT
            txtbBanned.Text = "Not Banned";

            // RESETS THE POSITION TO -1 AND CLEARS THE POSITION LABEL
            pos = -1;
            lblRecord.Text = "";

            // UPDATES BUTTON STATUS
            ButtonsCheck();
        }

            // CANCELS THE ACTUAL ACTION AND RESETS THE VISUAL PART
            private void btnCancelAddRegistry_Click(object sender, EventArgs e)
            {
                pos = 0;
                ShowUsersRecords(pos);
                RecordPositionLabel(pos);
            }

        /*------------------ CLEARING AND RESETING BUTTONS ACTIONS END ---------------------------*/

        /*-------------------------- BANNING BUTTONS ACTIONS AND FUNCTIONS START --------------------------*/

        // METHOD WHICH UPDATES THE BAN STATUS OF THE USER BASES ON THE SELECTED ACTION
        public void UnbannedUser (bool banStatus)
        {
            if (pos != -1)
            {
                // GET THE DATA FROM AN OBJECT AT THE CURRENT POSITION
                object objectToBan = dbHandler.GetSelectedTypeObject(pos, "Users");

                // CHECK IF THE SELECTED OBJECT IS A USER AND CONVERT IT INTO A USER TYPE TO ACCESS ITS PROPERTIES
                if (objectToBan is User userToBan)
                {
                    // GET THE USER'S INFORMATION
                    string name = userToBan.Name;
                    string email = userToBan.Email;
                    string password = userToBan.Password;

                    // CREATE A NEW USER OBJECT WITH THE UPDATED BAN STATUS
                    object selectedUserToUpdate = User.UserCreation(name, password, email, banStatus);
                    if (selectedUserToUpdate != null)
                    {
                        // UPDATE THE USER'S BAN STATUS
                        dbHandler.UpdateObjectFromPosition(selectedUserToUpdate, pos, banStatus, "Users");
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

        // FUNCTION WHICH ASKS THE USER WHICH ACTION IS DESIRED DEPENDING ON THE TEXT BOX BANNED ACTUAL TEXT
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

            // ASK THE USER IF THEY WANT TO BAN OR UNBAN AN USER - CAPITALIZES THE BANSTATUS FIRST LETTER DEPENDING THE ACTION
            DialogResult result = MessageBox.Show("Do you want to " + banStatus + " this user (Y/N)?", 
                                                  char.ToUpper(banStatus.First()) + banStatus.Substring(1).ToLower() + 
                                                  " User ? ", MessageBoxButtons.YesNo);

            // IF THE USER CONFIRMS, CALL THE APPROPRIATE METHOD TO BAN OR UNBAN THE USER
            if (result == DialogResult.Yes)
            {
                if (banStatus == "ban")
                {
                    UnbannedUser(true);
                }
                else if (banStatus == "unban")
                {
                    UnbannedUser(false);
                }
            }
        }

        // BANS THE USER
        private void btnBan_Click(object sender, EventArgs e)
        {
            ConfirmBanOrUnban();
        }

        // UNBANS THE USER
        private void btnUnban_Click(object sender, EventArgs e)
        {
            ConfirmBanOrUnban();
        }

        /*-------------------------- BANNING BUTTONS ACTIONS AND FUNCTIONS END ----------------------------*/

        /*-------------------------- LIST BUTTONS ACTIONS START ----------------------------*/

        // SHOWS A LIST OF ALL USERS ADDED
        private void btnListUsers_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ShowsUsersList());
        }

        // SHOWS A LIST OF ALL BANNED USERS
        private void btnListBannedUsers_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ShowsBannedUsersList());
        }

        /*-------------------------- LIST BUTTONS ACTIONS END ----------------------------*/

        /* -------------------------------------------------- BUTTONS HANDLING END ------------------------------------------------------ */

        /* ----------------------------------------------- INPUT ERROR HANDLING START --------------------------------------------------- */

        // ERROR STRING IF INPUT IS INVALID
        private string returnErrorInput()
        {
            string errorMessage = "Error, not valid data, try again. " +
                                  "\n\nEXAMPLE:" +
                                  "\nNAME: Sergio" +
                                  "\nEMAIL: x@x.com" +
                                  "\nPASSWORD: Contraseña_1 / CONTRASEÑa&2";
            return errorMessage;
        }

        /* --------------------------------------------- INPUT ERROR HANDLING END ------------------------------------------------------ */

        /* ----------------------------- HANDLING FUNCTIONS FOR BUTTONS STATUS AND TEXT BOX CHANGES START ------------------------------ */

        // CHECKS THE ACTUAL STATUS OF EVERY BUTTON
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

        // EVENT HANDLER FOR TEXT BOX NAME TEXT CHANGED
        private void txtbName_TextChanged(object sender, EventArgs e)
        {
            object actualObject = dbHandler.GetSelectedTypeObject(pos, "Users");
            if (actualObject is User actualUser)
            {
                string originalName = actualUser.Name;
                UpdateChangeDetected(txtbName.Text, originalName);
            }
        }

        // EVENT HANDLER FOR TEXT BOX EMAIL TEXT CHANGED
        private void txtbEmail_TextChanged(object sender, EventArgs e)
        {
            object actualObject = dbHandler.GetSelectedTypeObject(pos, "Users");
            if (actualObject is User actualUser)
            {
                string originalEmail = actualUser.Email;
                UpdateChangeDetected(txtbEmail.Text, originalEmail);
            }
        }

        // EVENT HANDLER FOR TEXT BOX PASSWORD TEXT CHANGED
        private void txtbPassword_TextChanged(object sender, EventArgs e)
        {
            object actualObject = dbHandler.GetSelectedTypeObject(pos, "Users");
            if (actualObject is User actualUser)
            {
                string originalPassword = actualUser.Password;
                UpdateChangeDetected(txtbPassword.Text, originalPassword);
            }
        }

        // EVENT HANDLER FOR TEXT BOX BANNED TEXT CHANGED
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

        /* ------------------------------- HANDLING FUNCTIONS FOR BUTTONS STATUS AND TEXT BOX CHANGES END ------------------------------ */
    }
}