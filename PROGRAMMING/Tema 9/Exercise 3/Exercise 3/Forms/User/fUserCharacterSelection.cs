using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Exercise_3.Forms.User
{
    public partial class fUserCharacterSelection : Form
    {
        public fUserCharacterSelection()
        {
            InitializeComponent();
        }

        // CALLING SQLBDHANDLER TO MANAGE DB FUNCTIONS
        SqlDBHandler dbHandler;

        private void fUserCharacterSelection_Load(object sender, EventArgs e)
        {
            // CONSTRUCTION OF THE DATABASE HANDLER FOR THE CHARACTERS TABLE
            dbHandler = new SqlDBHandler("Characters");

            // SETS FIRST POSITION, UPDATES THE VISUALS AND CHECKS THE ACTUAL BUTTONS STATUS WHEN FIRST LOADED
            pos = 0;
            CharacterNameLabel(pos);
            ShowCharactersRecords(pos);
            ButtonsCheck();
        }

        /*---------------------------------------------- POSITION HANDLING START ------------------------------------------------*/

        // GLOBAL VARIABLE TO STORE THE CURRENT POSITION
        private int pos = -1;

        // FUNCTION TO DISPLAY THE CURRENT RECORD POSITION IN A TEXT LABEL
        private void CharacterNameLabel(int pos)
        {
            // UPDATE THE LABEL TEXT WITH THE CURRENT RECORD POSITION
            lblCharacterName.Text = "";
        }

        /*--------------------------------------------- POSITION HANDLING END ---------------------------------------------------*/

        /*---------------------------------------- VISUAL HANDLING FUNCTIONS START ----------------------------------------------*/

        // FUNCTION TO UPDATE THE VISUAL PART OF THE FORM WITH USER RECORDS
        private void ShowCharactersRecords(int pos)
        {
            // GET THE SELECTED CHARACTER OBJECT FROM THE DATABASE
            object selectedObjectRecords = dbHandler.GetSelectedTypeObject(pos, "Characters");

            if (selectedObjectRecords is Character selectedCharacterRecords)
            {
                // SET VALUES FROM THE SELECTED CHARACTER RECORD INTO THE TEXTBOXES AND PICTURE BOXES
                lblCharacterName.Text = selectedCharacterRecords.Name;

                string imageURL = GetCharacterImg(selectedCharacterRecords.Name);

                if (!string.IsNullOrEmpty(imageURL) && File.Exists(imageURL))
                {
                    pbCharacterSelected.ImageLocation = imageURL;
                    pbCharacterSelected.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                // RESET THE CHANGE DETECTED BOOL AND CHECK BUTTONS STATUS
                ButtonsCheck();
            }
            
        }

        /*----------------------------------------------- VISUAL HANDLING FUNCTIONS END -------------------------------------------*/

        /* ------------------------------------------- BUTTONS HANDLING START ---------------------------------------------------- */

        /* ----------------------- IMAGES GET FROM DB END START ---------------------------------- */

        private string GetCharacterImg(string characterName)
        {
            // QUERY THAT RETURNS THE IMG URL STATUS FROM THAT CHARACTER
            string imgQuery = "SELECT ImgRoute FROM Characters WHERE Name = '" + characterName + "'";
            string imageURL = dbHandler.GetImgUrl("Characters", imgQuery);

            return imageURL;
        }


        /* ------------------------- IMAGES GET FROM DB END -------------------------------------- */

        /*------------------------ GENERAL BUTTONS SUPPORT FUNCTIONS START -----------------------*/

        // THE PART THAT CHECKS IF IMG IS CHANGED BETWEEN THE STORED AND THE ACTUAL ONE IN THE PROGRAM DOESNT WORK WELL
        // BETWEEN UPDATE INTERACTION SO I HAD TO CHANGE THAT MANUALLY

        // FUNCTION TO CHECK IF VALUES FROM THE ACTUAL USER POSITION HAVE CHANGED IN THE TEXT BOXES
        private bool CheckValuesChanged()
        {
            bool resultChanged = false;

            // GET THE IMAGE LOCATION STORED IN THE DATABASE FOR THE CURRENT CHARACTER
            string storedImg = GetCharacterImg(lblCharacterName.Text);

            // GET THE CURRENT IMAGE LOCATION OF THE PICTUREBOX
            string currentImgLocation = pbCharacterSelected.ImageLocation;

            // CHECK IF THE STORED IMAGE LOCATION IS DIFFERENT FROM THE CURRENT IMAGE LOCATION
            if (storedImg != currentImgLocation)
            {
                resultChanged = true;
            }

            // CHECK IF ANY OTHER VALUES HAVE CHANGED USING THE EXISTING METHOD
            if (dbHandler.CheckCharactersChangesStoredAndActualValues(pos, lblCharacterName.Text, storedImg))
            {
                resultChanged = true;
            }

            return resultChanged;
        }

        /*------------------------- GENERAL BUTTONS SUPPORT FUNCTIONS END ------------------------*/

        /*---------------------------- NAVIGATION BUTTONS ACTIONS START --------------------------*/

        // NEXT CHARACTER
        private void btnSelectNext_Click(object sender, EventArgs e)
        {

            if (pos < (dbHandler.CharactersQuantity - 1))
            {
                pos++;
                CharacterNameLabel(pos);
                ShowCharactersRecords(pos);
            }
        }
        // PREVIOUS CHARACTER
        private void btnSelectPrevious_Click(object sender, EventArgs e)
        {
            pos--;
            CharacterNameLabel(pos);
            ShowCharactersRecords(pos);
        }

        // CREATION OF A TIMER TO EXIT THE APP
        private Timer countdownTimer;

        // SETS THE TOTAL COUNTDOWNSECONDS TO CLOSE THE APP
        private int countdownSeconds = 4;

        private void ShowCountdown()
        {
            MessageBox.Show("Your game will start in " + countdownSeconds + " seconds", "Countdown", MessageBoxButtons.OK);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            btnPlay.Enabled = false;
            btnSelectNext.Enabled = false;
            btnSelectPrevious.Enabled = false;

            // INCIATE THE TIMER
            countdownTimer = new Timer();

            // SELECT 3 SECONDS OF DURATION
            countdownTimer.Interval = 1000;

            // WHEN TIMER REACHS ITS MAX SET INTERVAL ACTIVATES EVENT EXIT TIMER
            countdownTimer.Tick += CountdownTimer_Tick;

            // STARTS THE TIMER
            countdownTimer.Start();
        }

        // EVENT TO COUNT THE SECONDS LEFT AND WHEN ITS REACHER THE TIME LIMIT IT CLOSES THE APP
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            // DECREASE THE SECONDS EVERY TICK OF THE EXIT TIMER
            countdownSeconds--;

            if (countdownSeconds > 0)
            {
                ShowCountdown();
            }
            else
            {
                // STOPS THE TIMER
                countdownTimer.Stop();

                MessageBox.Show("Starting the game now!", "Countdown", MessageBoxButtons.OK);

                // CLOSES THE APP
                Application.Exit();
            }
        }

        /*---------------------------- NAVIGATION BUTTONS ACTIONS END --------------------------------*/

        /* ----------------------------- HANDLING FUNCTIONS FOR BUTTONS STATUS AND TEXT BOX CHANGES START ------------------------------ */

        // CHECKS THE ACTUAL STATUS OF EVERY BUTTON
        public void ButtonsCheck()
        {
            bool recordsExist = (dbHandler.CharactersQuantity > 0);
            bool noRecordSelected = (pos == -1);

            // ENABLE/DISABLE NAVIGATION BUTTONS
            btnSelectNext.Enabled = (recordsExist && pos < dbHandler.CharactersQuantity - 1) && !noRecordSelected;
            btnSelectPrevious.Enabled = (recordsExist && pos > 0) && !noRecordSelected;

        }

        /* ----------------------------- HANDLING FUNCTIONS FOR BUTTONS STATUS AND TEXT BOX CHANGES END ------------------------------- */
    }
}
