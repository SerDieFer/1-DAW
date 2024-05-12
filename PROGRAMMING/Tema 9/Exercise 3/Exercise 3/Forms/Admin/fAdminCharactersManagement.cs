using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_3
{
    public partial class fAdminCharactersManagement : Form
    {
        public fAdminCharactersManagement()
        {
            InitializeComponent();
        }

        // CALLING SQLBDHANDLER TO MANAGE DB FUNCTIONS
        SqlDBHandler dbHandler;

        private void fAdminCharactersManagement_Load(object sender, EventArgs e)
        {
            // CONSTRUCTION OF THE DATABASE HANDLER FOR THE CHARACTERS TABLE
            dbHandler = new SqlDBHandler("Characters");

            // SETS FIRST POSITION, UPDATES THE VISUALS AND CHECKS THE ACTUAL BUTTONS STATUS WHEN FIRST LOADED
            pos = 0;
            RecordPositionLabel(pos);
            ShowCharactersRecords(pos);
            ButtonsCheck();

            // THIS SETS THIS BUTTONS UNCHANGEABLE
            txtbCharacterID.ReadOnly = true;
        }

        /*---------------------------------------------- POSITION HANDLING START ------------------------------------------------*/

        // GLOBAL VARIABLE TO STORE THE CURRENT POSITION
        private int pos = -1;

        // FUNCTION TO DISPLAY THE CURRENT RECORD POSITION IN A TEXT LABEL
        private void RecordPositionLabel(int pos)
        {
            if (dbHandler.CharactersQuantity > 0)
            {
                // UPDATE THE LABEL TEXT WITH THE CURRENT RECORD POSITION
                lblRecord.Text = "Record Nº" + (pos + 1) + " of " + dbHandler.CharactersQuantity;
            }
            else if (dbHandler.CharactersQuantity == 0)
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
        private void ShowCharactersRecords(int pos)
        {
            if (dbHandler.CharactersQuantity > 0)
            {
                // GET THE SELECTED CHARACTER OBJECT FROM THE DATABASE
                object selectedObjectRecords = dbHandler.GetSelectedTypeObject(pos, "Characters");

                if (selectedObjectRecords is Character selectedCharacterRecords)
                {
                    // SET VALUES FROM THE SELECTED CHARACTER RECORD INTO THE TEXTBOXES AND PICTURE BOXES
                    txtbCharacterName.Text = selectedCharacterRecords.Name;

                    string imageURL = GetCharacterImg(selectedCharacterRecords.Name);

                    if (!string.IsNullOrEmpty(imageURL) && File.Exists(imageURL))
                    {
                        pbCharacter.ImageLocation = imageURL;
                        pbCharacter.SizeMode = PictureBoxSizeMode.StretchImage;
                    }

                    // GET THE IDENTITY ID OF THE SELECTED CHARACTER AND DISPLAY IT IN THE TEXT BOX BY SELECTION A TABLE AND A CERTAIN CONDITION
                    string query = "SELECT ID FROM Characters WHERE Name = '" + selectedCharacterRecords.Name.ToString() + "'";
                    int selectedCharacterID = dbHandler.GetIdentityID("Characters", query);
                    txtbCharacterID.Text = selectedCharacterID.ToString();

                    // RESET THE CHANGE DETECTED BOOL AND CHECK BUTTONS STATUS
                    changeDetected = false;
                    ButtonsCheck();
                }
            }
            else if (dbHandler.CharactersQuantity == 0)
            {
                // CLEAR ALL TEXT BOXES AND CHECK BUTTONS STATUS IF NO RECORDS ARE AVAILABLE
                btnCharacterClear.PerformClick();
                ButtonsCheck();
            }
        }

        /*----------------------------------------------- VISUAL HANDLING FUNCTIONS END -------------------------------------------------*/

        /*------------------------------------------ GET CHARACTERS INFO RELATED FUNCTIONS START ----------------------------------------------*/

        // FUNCTION THAT RETURNS THE CHARACTERS LIST
        public string ShowsCharactersList()
        {
            string result = "";
            if (dbHandler.CharactersQuantity != 0)
            {
                string charactersListTxt = "List of characters: \n\n";
                if (dbHandler.CharactersQuantity > 1)
                {
                    // GET THE CHARACTERS TABLE FROM THE DATABASE
                    DataTable charactersTable = dbHandler.ImportSelectedDataTable("Characters");

                    // CHECK CHARACTERS FROM TABLE
                    foreach (DataRow row in charactersTable.Rows)
                    {
                        // CONCATENATE USER INFORMATION
                        string characterInfo = "ID: " + row["ID"] + "\n" + 
                                               "Name: " + row["Name"] + "\n";

                        charactersListTxt += characterInfo + "\n";
                    }
                    result = charactersListTxt;
                }
                else if (dbHandler.CharactersQuantity == 1)
                {
                    // GET INFORMATION FOR A SINGLE USER
                    object singleCharacter = dbHandler.GetSelectedTypeObject(0, "Characters");

                    charactersListTxt = dbHandler.GetObjectDataFromPosition(singleCharacter, 0, "Characters");
                    result = charactersListTxt;
                }
            }
            else
            {
                result = "No characters added in the DB.";
            }
            return result;
        }

        // METHOD TO COUNT CHARACTERS WITH SIMILAR NICKNAMES
        public int CountSimilarCharactersName(string characterName)
        {
            int counter = 0;
            if (dbHandler.CharactersQuantity != 0)
            {
                for (int i = 0; i < dbHandler.CharactersQuantity; i++)
                {
                    // GET THE USER ROW FROM THE CHARACTERS TABLE
                    DataRow characterRow = dbHandler.ImportSelectedDataTable("Characters").Rows[i];

                    // GET THE NICKNAME FROM THE CURRENT USER ROW AND CONVERT IT TO LOWERCASE
                    string stringToCheck = characterRow[1].ToString().ToLower();

                    // CHECK IF THE NICKNAME CONTAINS THE INPUT USER NICKNAME
                    if (stringToCheck.Contains(characterName.ToLower()))
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        // METHOD TO SELECT AND SHOW CHARACTERS WITH SIMILAR NAME
        public void ShowSimilarCharacterName(string characterName)
        {
            // LISTS TO STORE MATCHING CHARACTERS' NAMES, EXTRA INFO, AND THEIR POSITIONS
            List<string> matchingCharactersName = new List<string>();
            List<string> extraCharacterInfo = new List<string>();
            List<int> characterPositions = new List<int>();

            if (dbHandler.CharactersQuantity != 0)
            {
                for (int i = 0; i < dbHandler.CharactersQuantity; i++)
                {
                    // GET THE CHARACTER ROW FROM THE CHARACTERS TABLE
                    DataRow characterRow = dbHandler.ImportSelectedDataTable("Characters").Rows[i];

                    // GET THE NAME FROM THE CURRENT CHARACTER ROW AND CONVERT IT TO LOWERCASE
                    string stringToCheck = characterRow[1].ToString().ToLower();

                    // CHECK IF THE NAME CONTAINS THE INPUT USER NAME
                    if (stringToCheck.Contains(characterName.ToLower()))
                    {
                        // ADD THE CHARACTERS'S NAME TO THE MATCHING CHARACTERS LIST
                        string name = characterRow["Name"].ToString();
                        matchingCharactersName.Add(name);

                        // ADD CHARACTER INFO
                        string characterInfo = "ID: " + characterRow["ID"] + "\n" +
                                               "Name: " + characterRow["Name"];


                        // ADD CHARACTER INFO TO THE EXTRA INFO LIST
                        extraCharacterInfo.Add(characterInfo);

                        // ADD CHARACTER POSITION TO THE POSITIONS LIST
                        characterPositions.Add(i);
                    }
                }
            }
            if (matchingCharactersName.Count == 1)
            {
                // SHOW CHARACTER INFO AND RECORD POSITION
                MessageBox.Show("The data from " + matchingCharactersName[0] + " is: \n\n" + extraCharacterInfo[0]);
                pos = characterPositions[0];
                ShowCharactersRecords(pos);
                RecordPositionLabel(pos);
            }
            else if (matchingCharactersName.Count > 1)
            {
                bool showed = false;
                int selectedCharacterIndex = 0;

                while (!showed)
                {
                    StringBuilder infoMessage = new StringBuilder("Characters with similar name:\n\n");

                    // DISPLAY CHARACTERS WITH SIMILAR NICKNAMES
                    for (int i = 0; i < matchingCharactersName.Count; i++)
                    {
                        infoMessage.AppendLine((i + 1) + ") " + matchingCharactersName[i] + "\n");
                    }

                    // MAKES THE USER TO SELECT A USER
                    infoMessage.AppendLine("Select the number of the character to view more data:");

                    string userInput = Interaction.InputBox(infoMessage.ToString());

                    // CHECK USER INPUT
                    if (int.TryParse(userInput, out selectedCharacterIndex) && selectedCharacterIndex > 0 && selectedCharacterIndex <= matchingCharactersName.Count)
                    {
                        // GET SELECTED CHARACTERS INFO AND POSITION
                        string selectedCharacterInfo = extraCharacterInfo[selectedCharacterIndex - 1];
                        int selectedCharacterPositionInDB = characterPositions[selectedCharacterIndex - 1];

                        DialogResult result = MessageBox.Show(selectedCharacterInfo + "\n\nIs this the character you want to check info?", "Check Character Info", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            pos = selectedCharacterPositionInDB;
                            ShowCharactersRecords(pos);
                            RecordPositionLabel(pos);
                            showed = true;
                        }
                        else
                        {
                            MessageBox.Show("Please select a different character.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid number corresponding to a character.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No character found with the selected name.");
            }
        }

        /*----------------------------------- GET CHARACTERS INFO RELATED FUNCTIONS END ----------------------------------------------------------*/

        /* ------------------------------------------- BUTTONS HANDLING START ------------------------------------------------------------------- */

        /* ----------------------- SELECTION OF IMAGES HANDLING START ---------------------------------- */


        //TO THIS PART NEED TO BE FIXED FOR ELEMENTS ALREADY STORED IN THE DB ALSO THE UPDATE BUTTON INTERACTION

        // GENERAL SELECTED IMAGE
        string selectedImg = "";

        // BUTTON WHICH SETS THE IMAGE FOR THE DESIRED CHARACTER
        private void btnSetImage_Click(object sender, EventArgs e)
        {
            if (pos != -1)
            { 
                // SELECTS AND IMG FROM USER COMPUTER
                selectedImg = SelectImageFile();

                //IF IS SELECTED CORRECTLY
                if (!string.IsNullOrEmpty(selectedImg))
                {

                    // LOADS THE URL INTO THE PBCHARACTER AND UPDATES IT
                    pbCharacter.Load(selectedImg);
                    pbCharacter.SizeMode = PictureBoxSizeMode.StretchImage;

                    // WE SET THE CHANGE TO TRUE BECAUSE WE WANT TO UPDATE AFTER SETTING THE IMG
                    changeDetected = true;
                    ButtonsCheck();
                }
            }
            else
            {
                // SELECTS AND IMG FROM USER COMPUTER
                selectedImg = SelectImageFile();

                //IF IS SELECTED CORRECTLY
                if (!string.IsNullOrEmpty(selectedImg))
                {
                    // LOADS THE URL INTO THE PBCHARACTER AND UPDATES IT
                    pbCharacter.Load(selectedImg);
                    pbCharacter.SizeMode = PictureBoxSizeMode.StretchImage;

                    // WE SET THE CHANGE TO FALSE BECAUSE IMG IS ALREADY SETTED TO CREATE THE CHARACTER SO THE UPDATE BUTTON IS DISABLED
                    changeDetected = false;
                    ButtonsCheck();
                }
            }
        }

        // FUNCTION WHICH ALLOWS THE USER TO SELECT THE IMG FROM THEIR COMPUTER
        private string SelectImageFile()
        {
            string imagePath = "";

            // CREATES A DIALOG WINDOW TO SELECT IMAGE 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files|*.jpg;*.jpeg;*.png;*.gif|All files|*.*";
            openFileDialog.Title = "Select an image";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // GET THE SELECTED FILE PATH
                imagePath = openFileDialog.FileName;
            }
            return imagePath;
        }

        private string GetCharacterImg(string characterName)
        {
            // QUERY THAT RETURNS THE IMG URL STATUS FROM THAT CHARACTER
            string imgQuery = "SELECT ImgRoute FROM Characters WHERE Name = '" + characterName + "'";
            string imageURL = dbHandler.GetImgUrl("Characters", imgQuery);

            return imageURL;
        }

        /* ------------------------- SELECTION OF IMAGES HANDLING END ---------------------------------- */

        /*---------------------------- CRUD BUTTONS ACTIONS START ---------------------------------------*/

        // SAVES A CHARACTER (CREATE)
        private void btnCharacterSave_Click(object sender, EventArgs e)
        {
            // CHECK IF THERE ARE NO DUPLICATED DATA FOR THE CHARACTER
            if (!dbHandler.DuplicatedNameData(txtbCharacterName.Text, "Characters"))
            {
                // IF SELECT IMAGE EXIST
                if (!string.IsNullOrEmpty(selectedImg))
                {
                    // CREATES THE CHARACTER TO SAVE
                    Character savedCharacter = Character.CharacterCreation(txtbCharacterName.Text, selectedImg);

                    // IF THE CHARACTER OBJECT IS VALID, INSERT IT INTO THE DATABASE
                    if (savedCharacter != null)
                    {
                        // ADD THE NEW USER TO THE DATABASE
                        dbHandler.AddNewObject(savedCharacter, "Characters");

                        // UPDATE THE POSITION AND THE VISUALS
                        pos = dbHandler.CharactersQuantity - 1;
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
                    MessageBox.Show("You must select an image for this character");
                }
            }
            else
            {
                MessageBox.Show("This character's name is already used, try another");
            }
        }

        // SEARCHS CHARACTER DATA (READ)
        private void btnSearchCharacter_Click(object sender, EventArgs e)
        {
            if (dbHandler.CharactersQuantity > 1)
            {
                bool showed = false;
                do
                {
                    string name = Interaction.InputBox("Introduce the character's name to show data: ");

                    // CHECK IF THE ENTERED NAME HAS A VALID FORMAT
                    if (CustomRegex.RegexName(name))
                    {
                        // CHECK IF THERE ARE CHARACTERS WITH SIMILAR NAMES
                        if (CountSimilarCharactersName(name) > 0)
                        {
                            // SHOW DATA OF SIMILAR CHARACTERS
                            ShowSimilarCharacterName(name);
                            showed = true;
                        }
                        else
                        {
                            MessageBox.Show("There isn't any character with the selected name, try again");
                            showed = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The name format is not correct, try again");
                    }

                } while (!showed);

            }
            else if (dbHandler.CharactersQuantity == 1)
            {
                // IF THERE IS ONLY ONE CHARACTER, DISPLAY ITS DATA
                object uniqueCharacter = dbHandler.GetSelectedTypeObject(0, "Characters");
                MessageBox.Show("There's only one character so it's data will be the one showed.");
                MessageBox.Show(dbHandler.GetObjectDataFromPosition(uniqueCharacter, 0, "Characters"));
            }
            else
            {
                MessageBox.Show("Error, the list has no added characters, add a character before checking a character data from the characters list");
            }
        }

        // UPDATE CHARACTER (UPDATE)
        private void btnCharacterUpdate_Click(object sender, EventArgs e)
        {
            if (pos != -1 && changeDetected)
            {
                // GET THE OLD OBJECT DATA FROM THE DATABASE 
                object oldObjectData = dbHandler.GetSelectedTypeObject(pos, "Characters");

                // SET VARIABLES TO CREATE A NEW CHARACTER
                string name = txtbCharacterName.Text;

                // CHECK IF THE SELECTED OBJECT IS A CHARACTER AND CONVERT IT INTO A CHARACTER TYPE TO ACCESS ITS PROPERTIES
                if (oldObjectData is Character oldCharactersData)
                {
                    // CHECK IF THE NEW NAME IS NOT DUPLICATED OR IF IT'S THE SAME AS THE OLD ONE
                    if (!dbHandler.DuplicatedNameData(name, "Characters") || name == oldCharactersData.Name)
                    {
                        // GETS THIS FROM GENERAL SELECTED IMG
                        string imgRoute = selectedImg;

                        // CREATE A NEW CHARACTER OBJECT
                        object selectedCharacterToUpdate = Character.CharacterCreation(name, imgRoute);

                        // IF THE NEW CHARACTER OBJECT IS VALID, UPDATE THE OBJECT IN THE DATABASE
                        if (selectedCharacterToUpdate != null)
                        {
                            // SETS TRUE IN THE BAN STATUS SINCE IT DOESNT AFFECT THE CHARACTER CREATION
                            dbHandler.UpdateObjectFromPosition(selectedCharacterToUpdate, pos, true, "Characters");
                            ShowCharactersRecords(pos);
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
                        MessageBox.Show("This name is already used, try another one");
                    }
                }
                else if (dbHandler.CharactersQuantity == 0)
                {
                    MessageBox.Show("Updating without having atleast one character in the DB is meaningless, try again after adding a character to the DB.");
                }
                else
                {
                    MessageBox.Show(returnErrorInput());
                }
            }
        }

        // DELETES USER (DELETE)
        private void btnCharacterDelete_Click(object sender, EventArgs e)
        {
            if (dbHandler.CharactersQuantity > 0)
            {
                if (pos != -1)
                {
                    DialogResult delete;
                    delete = MessageBox.Show("Do you want to delete this record (Y/N)?", "Delete Record?", MessageBoxButtons.YesNo);

                    if (delete == DialogResult.Yes)
                    {
                        dbHandler.DeleteObjectFromPosition(pos, "Characters");
                        pos = 0;
                        RecordPositionLabel(pos);
                        ShowCharactersRecords(pos);
                        ButtonsCheck();
                    }
                }
                else
                {
                    MessageBox.Show("Delete is not possible when no character is selected.");
                }
            }
            else if (dbHandler.CharactersQuantity == 0)
            {
                MessageBox.Show("Delete is not possible when no elements are in the database.");
            }
        }


        /*------------------------------- CRUD BUTTONS ACTIONS END -------------------------------*/

        /*------------------------ GENERAL BUTTONS SUPPORT FUNCTIONS START -----------------------*/

        // THE PART THAT CHECKS IF IMG IS CHANGED BETWEEN THE STORED AND THE ACTUAL ONE IN THE PROGRAM DOESNT WORK WELL
        // BETWEEN UPDATE INTERACTION SO I HAD TO CHANGE THAT MANUALLY

        // FUNCTION TO CHECK IF VALUES FROM THE ACTUAL USER POSITION HAVE CHANGED IN THE TEXT BOXES
        private bool CheckValuesChanged()
        {
            bool resultChanged = false;

            // GET THE IMAGE LOCATION STORED IN THE DATABASE FOR THE CURRENT CHARACTER
            string storedImg = GetCharacterImg(txtbCharacterName.Text);

            // GET THE CURRENT IMAGE LOCATION OF THE PICTUREBOX
            string currentImgLocation = pbCharacter.ImageLocation;

            // CHECK IF THE STORED IMAGE LOCATION IS DIFFERENT FROM THE CURRENT IMAGE LOCATION
            if (storedImg != currentImgLocation)
            {
                resultChanged = true; 
            }

            // CHECK IF ANY OTHER VALUES HAVE CHANGED USING THE EXISTING METHOD
            if (dbHandler.CheckCharactersChangesStoredAndActualValues(pos, txtbCharacterName.Text, storedImg))
            {
                resultChanged = true;
            }

            return resultChanged;
        }

        // FUNCTION TO ASK USER TO UPDATE IF CHANGES WERE MADE 
        private void AskToUpdateIfChangesWereMade(bool choice)
        {
            if (!choice)
            {
                DialogResult update = MessageBox.Show("Do you want to keep changes of this record (Y/N)?", "Keep Changes?", MessageBoxButtons.YesNo);

                if (update == DialogResult.Yes)
                {
                    btnCharacterUpdate.PerformClick();
                }
            }
        }

        /*------------------------- GENERAL BUTTONS SUPPORT FUNCTIONS END ------------------------*/

        /*---------------------------- NAVIGATION BUTTONS ACTIONS START --------------------------*/

        // FIRST CHARACTER ADDED
        private void btnCharacterFirst_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                pos = 0;
                RecordPositionLabel(pos);
                ShowCharactersRecords(pos);
            }
            else
            {
                // CHECK IF THERE ARE POSSIBLY CHANGED VALUES AND IF THE POSITION IS NOT -1
                bool possiblyChangedValues = CheckValuesChanged();

                if (possiblyChangedValues && (pos == -1))
                {
                    pos = 0;
                    RecordPositionLabel(pos);
                    ShowCharactersRecords(pos);
                }
                else
                {
                    // ASK TO UPDATE IF CHANGES WERE MADE
                    AskToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos = 0;
                    RecordPositionLabel(pos);
                    ShowCharactersRecords(pos);
                }
            }
        }

        // LAST CHARACTER ADDED
        private void btnCharacterLast_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                pos = dbHandler.CharactersQuantity - 1;
                RecordPositionLabel(pos);
                ShowCharactersRecords(pos);
            }
            else
            {
                // CHECK IF THERE ARE POSSIBLY CHANGED VALUES AND IF THE POSITION IS NOT -1
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (pos == -1))
                {
                    pos = dbHandler.CharactersQuantity - 1;
                    RecordPositionLabel(pos);
                    ShowCharactersRecords(pos);
                }
                else
                {
                    // ASK TO UPDATE IF CHANGES WERE MADE
                    AskToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos = dbHandler.CharactersQuantity - 1;
                    RecordPositionLabel(pos);
                    ShowCharactersRecords(pos);
                }
            }
        }

        // NEXT CHARACTER
        private void btnCharacterNext_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                btnCharacterFirst.PerformClick();
            }
            else if (pos < (dbHandler.CharactersQuantity - 1))
            {
                // CHECK IF THERE ARE POSSIBLY CHANGED VALUES AND IF THE POSITION IS NOT -1
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (pos == -1))
                {
                    pos++;
                    RecordPositionLabel(pos);
                    ShowCharactersRecords(pos);
                }
                else
                {
                    // ASK TO UPDATE IF CHANGES WERE MADE
                    AskToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos++;
                    RecordPositionLabel(pos);
                    ShowCharactersRecords(pos);
                }
            }
        }

        // PREVIOUS CHARACTER
        private void btnCharacterPrevious_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                btnCharacterFirst.PerformClick();
            }
            else if (pos > 0)
            {
                // CHECK IF THERE ARE POSSIBLY CHANGED VALUES AND IF THE POSITION IS NOT -1
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (pos == -1))
                {
                    pos--;
                    RecordPositionLabel(pos);
                    ShowCharactersRecords(pos);
                }
                else
                {
                    // ASK TO UPDATE IF CHANGES WERE MADE
                    AskToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos--;
                    RecordPositionLabel(pos);
                    ShowCharactersRecords(pos);
                }
            }
        }

        /*---------------------------- NAVIGATION BUTTONS ACTIONS END ----------------------------*/

        /*------------------ CLEARING AND RESETING BUTTONS ACTIONS START -------------------------*/

        // CLEARS ALL THE DATA FROM THE TEXT BOXES AND UPDATES THE ID TO THE NEXT ID AVALIABLE
        private void btnCharacterClear_Click(object sender, EventArgs e)
        {
            // QUERY TO GET THE CURRENT IDENTITY ID
            string query = "SELECT IDENT_CURRENT('Characters')";

            // SETS THE ID TEXT BOX TO THE NEXT AVAILABLE ID
            txtbCharacterID.Text = ((dbHandler.GetIdentityID("Characters", query) + 1).ToString());

            // CLEARS THE TEXT BOXES AND RESETS THE SELECTED IMG URL
            txtbCharacterName.Clear();
            pbCharacter.Image = null;
            selectedImg = "";

            // RESETS THE POSITION TO -1 AND CLEARS THE POSITION LABEL
            pos = -1;
            lblRecord.Text = "";

            // UPDATES BUTTON STATUS
            ButtonsCheck();
        }

        // CANCELS THE ACTUAL ACTION AND RESETS THE VISUAL PART
        private void btnCharacterCancelAddRegistry_Click(object sender, EventArgs e)
        {
            pos = 0;
            ShowCharactersRecords(pos);
            RecordPositionLabel(pos);
        }

        /*------------------ CLEARING AND RESETING BUTTONS ACTIONS END ---------------------------*/

        /*-------------------------- LIST BUTTONS ACTIONS START ----------------------------*/

        // SHOWS A LIST OF ALL CHARACTERS ADDED
        private void btnListCharacters_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ShowsCharactersList());
        }

        /*-------------------------- LIST BUTTONS ACTIONS END ----------------------------*/

        /* -------------------------------------------------- BUTTONS HANDLING END ------------------------------------------------------ */

        /* ----------------------------------------------- INPUT ERROR HANDLING START --------------------------------------------------- */

        // ERROR STRING IF INPUT IS INVALID
        private string returnErrorInput()
        {
            string errorMessage = "Error, not valid data, try again. " +
                                  "\n\nEXAMPLE:" +
                                  "\nNAME: GOKU";
            return errorMessage;
        }

        /* --------------------------------------------- INPUT ERROR HANDLING END ------------------------------------------------------ */

        /* ----------------------------- HANDLING FUNCTIONS FOR BUTTONS STATUS AND TEXT BOX CHANGES START ------------------------------ */

        // CHECKS THE ACTUAL STATUS OF EVERY BUTTON
        public void ButtonsCheck()
        {
            bool recordsExist = (dbHandler.CharactersQuantity > 0);
            bool noRecordSelected = (pos == -1);

            // ENABLE/DISABLE NAVIGATION BUTTONS
            btnCharacterNext.Enabled = (recordsExist && pos < dbHandler.CharactersQuantity - 1) && !noRecordSelected;
            btnCharacterLast.Enabled = (recordsExist && pos < dbHandler.CharactersQuantity - 1) && !noRecordSelected;
            btnCharacterPrevious.Enabled = (recordsExist && pos > 0) && !noRecordSelected;
            btnCharacterFirst.Enabled = (recordsExist && pos > 0) && !noRecordSelected;

            // ENABLE/DISABLE SAVE BUTTON IF NO RECORD IS SELECTED
            btnCharacterSave.Enabled = noRecordSelected && (selectedImg != "");

            // ENABLE/DISABLE CANCEL ADD REGISTRY BUTTON IF NO RECORD IS SELECTED
            btnCharacterCancelAddRegistry.Enabled = noRecordSelected && recordsExist;

            // ENABLE/DISABLE DELETE AND UPDATE BUTTONS IF A RECORD IS SELECTED
            btnCharacterDelete.Enabled = recordsExist && !noRecordSelected;
            btnCharacterUpdate.Enabled = (recordsExist && !noRecordSelected && changeDetected);

            // ENABLE/DISABLE OTHER BUTTONS BASED ON RECORD EXISTENCE
            btnCharacterClear.Enabled = recordsExist && !noRecordSelected;
            btnListCharacters.Enabled = recordsExist;
            btnSearchCharacter.Enabled = recordsExist;

        }

        // THIS FUNCTION AUTO CHECKS THE CHANGES DETECTED IN THE FOLLOWING TEXT BOXES BETWEEN THE ORIGINAL STRING AND THE NEW CHANGED
        private void UpdateChangeDetected(string currentValue, string originalValue)
        {
            bool anyChangeDetected = (currentValue != originalValue);
            changeDetected = anyChangeDetected;
            ButtonsCheck();
        }

        // HANDLING FOR CHARACTER NAME CHAGED
        private void txtbCharacterName_TextChanged(object sender, EventArgs e)
        {
            object actualObject = dbHandler.GetSelectedTypeObject(pos, "Characters");
            if (actualObject is Character actualCharacter)
            {
                string originalName = actualCharacter.Name;
                UpdateChangeDetected(txtbCharacterName.Text, originalName);
            }
        }

        /* ------------------------------- HANDLING FUNCTIONS FOR BUTTONS STATUS AND TEXT BOX CHANGES END ------------------------------ */
    }
}
