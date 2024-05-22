using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Win32;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Net;
using Exercise_4.Models;


namespace Exercise_4
{
    public partial class fAlumnManagement : Form
    {
        public fAlumnManagement()
        {
            InitializeComponent();
        }

        // CALLING SQLBDHANDLER TO MANAGE DB FUNCTIONS
        SqlDBHandler dbHandler;

        // FORM LOADING HANDLING
        private void fAlumnManagement_Load(object sender, EventArgs e)
        {
            dbHandler = new SqlDBHandler();
            // SETS FIRST POSITION, UPDATES THE VISUALS AND CHECKS THE ACTUAL BUTTONS STATUS WHEN FIRST LOADED
            pos = 0;
            RecordPositionLabel(pos);
            ShowAlumnsRecords(pos);
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
            if (dbHandler.AlumnsQuantity > 0)
            {
                lblRecord.Text = "Record Nº" + (pos + 1) + " of " + dbHandler.AlumnsQuantity;
            }
            else if (dbHandler.AlumnsQuantity == 0)
            {
                lblRecord.Text = "";
            }
        }

        /* ---------------- POSITION HANDLING END --------------------- */


        // FUNCTION WHICH UPDATES THE VISUAL PART OF THE FORM
        private void ShowAlumnsRecords(int pos)
        {
            if (dbHandler.AlumnsQuantity > 0)
            {
                Identity selectedIdentityRecords = dbHandler.GetIdentityType(pos, "Alumnos");
                if (selectedIdentityRecords is Alumn selectedAlumnRecords)
                {
                    // TAKE VALUES FROM EACH RECORD'S COLUMNS TO SET THEM IN THE APPROPIATE TEXTBOX
                    txtbAlumnID.Text = selectedAlumnRecords.ID;
                    txtbAlumnName.Text = selectedAlumnRecords.Name;
                    txtbAlumnSurnames.Text = selectedAlumnRecords.Surnames;
                    txtbAlumnPhone.Text = selectedAlumnRecords.Phone;
                    txtbAlumnAdress.Text = selectedAlumnRecords.Adress;
                    txtbAlumnPassword.Text = selectedAlumnRecords.Password;
                    txtbAlumnCourse.Text = selectedAlumnRecords.CourseCod;

                    // DETECTED CHANGES RESET AND CHECKS THE ACTUAL BUTTONS STATUS
                    changeDetected = false;
                    ButtonsCheck();
                }
            }
            else if (dbHandler.AlumnsQuantity == 0)
            {
                // CLEAR EVERY DATA FROM THE TEXT BOXES AND CHECKS THE ACTUAL BUTTONS STATUS
                btnAlumnClear.PerformClick();
                ButtonsCheck();
            }
        }

        public string ShowsAlumnsList()
        {
            string result = "";
            if (dbHandler.AlumnsQuantity != 0)
            {
                string alumnListTxt = "List of alumns: \n\n";

                if (dbHandler.AlumnsQuantity > 1)
                {
                    DataTable alumnsTable = dbHandler.ImportSelectedDataTable("Alumnos");

                    foreach (DataRow row in alumnsTable.Rows)
                    {
                        string alumnInfo = "ID: " + row["DNI"] + "\n" +
                                           "Name: " + row["Nombre"] + "\n" +
                                           "Surnames: " + row["Apellido"] + "\n" +
                                           "Phone: " + row["Tlf"] + "\n" +
                                           "Adress: " + row["Direccion"] + "\n" +
                                           "Course: " + row["Codigo"] + "\n";

                        alumnListTxt += alumnInfo + "\n";
                    }
                    result = alumnListTxt;
                }
                else if (dbHandler.AlumnsQuantity == 1)
                {
                    Identity singleAlumn = dbHandler.GetIdentityType(0, "Alumnos");
                    alumnListTxt = dbHandler.GetIdentityData(singleAlumn, 0, "Alumnos");
                    result = alumnListTxt;
                }
            }
            else
            {
                result = "No alumns added in the DB.";
            }
            return result;
        }

        public int SimilarAlumnSurnamesCounter(string alumnSurname)
        {
            int counter = 0;
            if (dbHandler.AlumnsQuantity != 0)
            {
                for (int i = 0; i < dbHandler.AlumnsQuantity; i++)
                {
                    DataRow alumnRow = dbHandler.ImportSelectedDataTable("Alumnos").Rows[i];
                    string stringToCheck = alumnRow[2].ToString().ToLower();
                    if (stringToCheck.Contains(alumnSurname.ToLower()))
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        public int SimilarAlumnCourseCounter(string alumnCourse)
        {
            int counter = 0;
            if (dbHandler.AlumnsQuantity != 0)
            {
                for (int i = 0; i < dbHandler.AlumnsQuantity; i++)
                {
                    DataRow alumnRow = dbHandler.ImportSelectedDataTable("Alumnos").Rows[i];
                    string stringToCheck = alumnRow[6].ToString().ToLower();
                    if (stringToCheck.Contains(alumnCourse.ToLower()))
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        public void SelectSimilarNameAlumnsToShow(string alumnSurname)
        {
            List<string> matchingAlumnsSurname = new List<string>();
            List<string> extraAlumnsInfo = new List<string>();
            List<int> alumnsPositions = new List<int>();

            if (dbHandler.AlumnsQuantity != 0)
            {
                for (int i = 0; i < dbHandler.AlumnsQuantity; i++)
                {
                    DataRow alumnRow = dbHandler.ImportSelectedDataTable("Alumnos").Rows[i];
                    string stringToCheck = alumnRow[2].ToString().ToLower();
                    if (stringToCheck.Contains(alumnSurname.ToLower()))
                    {
                        string fullName = (alumnRow["Nombre"] + " " + alumnRow["Apellido"]).ToString();
                        matchingAlumnsSurname.Add(fullName);

                        string extraAlumnInfo = "ID: " + alumnRow["DNI"] + "\n" +
                                                "Name: " + alumnRow["Nombre"] + "\n" +
                                                "Surnames: " + alumnRow["Apellido"] + "\n" +
                                                "Phone: " + alumnRow["Tlf"] + "\n" +
                                                "Adress: " + alumnRow["Direccion"] + "\n" +
                                                "Course: " + alumnRow["Codigo"] + "\n";

                        extraAlumnsInfo.Add(extraAlumnInfo);
                        alumnsPositions.Add(i);
                    }
                }

            }
            if (matchingAlumnsSurname.Count == 1)
            {
                MessageBox.Show("The data from " + matchingAlumnsSurname[0] + " is: \n\n" + extraAlumnsInfo[0]);
                pos = alumnsPositions[0];
                ShowAlumnsRecords(pos);
                RecordPositionLabel(pos);
            }
            else if (matchingAlumnsSurname.Count > 1)
            {
                bool showed = false;
                int selectedAlumnIndex = 0;

                while (!showed)
                {
                    StringBuilder infoMessage = new StringBuilder("Alumns with the same surname:\n\n");

                    for (int i = 0; i < matchingAlumnsSurname.Count; i++)
                    {
                        infoMessage.AppendLine((i + 1) + ") " + matchingAlumnsSurname[i] + "\n");
                    }

                    infoMessage.AppendLine("Select the number of the alumn to view more data:");

                    string userInput = Interaction.InputBox(infoMessage.ToString());

                    if (int.TryParse(userInput, out selectedAlumnIndex) && selectedAlumnIndex > 0 && selectedAlumnIndex <= matchingAlumnsSurname.Count)
                    {
                        string selectedAlumnInfo = extraAlumnsInfo[selectedAlumnIndex - 1];
                        int selectedAlumnPositionInDB = alumnsPositions[selectedAlumnIndex - 1];

                        DialogResult result = MessageBox.Show(selectedAlumnInfo + "\n\nIs this the alumn you want to check info?", "Check Alumn Info", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            pos = selectedAlumnPositionInDB;
                            ShowAlumnsRecords(pos);
                            RecordPositionLabel(pos);
                            showed = true;
                        }
                        else
                        {
                            MessageBox.Show("Please select a different alumn.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid number corresponding to an alumn.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No alumns found with the selected surname.");
            }
        }

        public void SelectSimilarCourseAlumnsToShow(string alumnCourse)
        {
            List<string> matchingAlumnsCourse = new List<string>();
            List<string> extraAlumnsInfo = new List<string>();
            List<int> alumnsPositions = new List<int>();

            if (dbHandler.AlumnsQuantity != 0)
            {
                for (int i = 0; i < dbHandler.AlumnsQuantity; i++)
                {
                    DataRow alumnRow = dbHandler.ImportSelectedDataTable("Alumnos").Rows[i];
                    string stringToCheck = alumnRow[6].ToString().ToLower();
                    if (stringToCheck.Contains(alumnCourse.ToLower()))
                    {
                        string fullName = (alumnRow["Nombre"] + " " + alumnRow["Apellido"] + " course is " + alumnRow["Codigo"]).ToString();
                        matchingAlumnsCourse.Add(fullName);

                        string extraAlumnInfo = "ID: " + alumnRow["DNI"] + "\n" +
                                                "Name: " + alumnRow["Nombre"] + "\n" +
                                                "Surnames: " + alumnRow["Apellido"] + "\n" +
                                                "Phone: " + alumnRow["Tlf"] + "\n" +
                                                "Adress: " + alumnRow["Direccion"] + "\n" +
                                                "Course: " + alumnRow["Codigo"] + "\n";

                        extraAlumnsInfo.Add(extraAlumnInfo);
                        alumnsPositions.Add(i);
                    }
                }

            }
            if (matchingAlumnsCourse.Count == 1)
            {
                MessageBox.Show("The data from " + matchingAlumnsCourse[0] + " is: \n\n" + extraAlumnsInfo[0]);
                pos = alumnsPositions[0];
                ShowAlumnsRecords(pos);
                RecordPositionLabel(pos);
            }
            else if (matchingAlumnsCourse.Count > 1)
            {
                bool showed = false;
                int selectedAlumnIndex = 0;

                while (!showed)
                {
                    StringBuilder infoMessage = new StringBuilder("Alumns with the same course:\n\n");

                    for (int i = 0; i < matchingAlumnsCourse.Count; i++)
                    {
                        infoMessage.AppendLine((i + 1) + ") " + matchingAlumnsCourse[i] + "\n");
                    }

                    infoMessage.AppendLine("Select the number of the alumn to view more data:");

                    string userInput = Interaction.InputBox(infoMessage.ToString());

                    if (int.TryParse(userInput, out selectedAlumnIndex) && selectedAlumnIndex > 0 && selectedAlumnIndex <= matchingAlumnsCourse.Count)
                    {
                        string selectedAlumnInfo = extraAlumnsInfo[selectedAlumnIndex - 1];
                        int selectedAlumnPositionInDB = alumnsPositions[selectedAlumnIndex - 1];

                        DialogResult result = MessageBox.Show(selectedAlumnInfo + "\n\nIs this the alumn you want to check info?", "Check Alumn Info", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            pos = selectedAlumnPositionInDB;
                            ShowAlumnsRecords(pos);
                            RecordPositionLabel(pos);
                            showed = true;
                        }
                        else
                        {
                            MessageBox.Show("Please select a different alumn.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid number corresponding to an alumn.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No alumns found with the selected course.");
            }
        }

        /* ---------------- BUTTONS HANDLING START --------------------- */

        private bool CheckValuesChanged()
        {
            return dbHandler.CheckChangesStoredAndActualValues(pos, txtbAlumnID.Text, txtbAlumnName.Text, txtbAlumnSurnames.Text, 
                                                               txtbAlumnPhone.Text, txtbAlumnAdress.Text, txtbAlumnPassword.Text, 
                                                               txtbAlumnCourse.Text, "Alumnos");
        }

        private void askToUpdateIfChangesWereMade(bool choice)
        {
            if (!choice)
            {
                DialogResult update = MessageBox.Show("Do you want to keep changes of this record (Y/N)?", "Keep Changes?", MessageBoxButtons.YesNo);

                if (update == DialogResult.Yes)
                {
                    btnAlumnUpdate.PerformClick();
                }
            }
        }

        private void btnAlumnCancelAddRegistry_Click(object sender, EventArgs e)
        {
            pos = 0;
            ShowAlumnsRecords(pos);
            RecordPositionLabel(pos);
        }

        private void btnAlumnFirst_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                pos = 0;
                RecordPositionLabel(pos);
                ShowAlumnsRecords(pos);
            }
            else
            {
                bool possiblyChangedValues = CheckValuesChanged();

                if (possiblyChangedValues && (pos == -1))
                {
                    pos = 0;
                    RecordPositionLabel(pos);
                    ShowAlumnsRecords(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos = 0;
                    RecordPositionLabel(pos);
                    ShowAlumnsRecords(pos);
                }
            }
        }

        private void btnAlumnLast_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                pos = dbHandler.AlumnsQuantity - 1;
                RecordPositionLabel(pos);
                ShowAlumnsRecords(pos);
            }
            else
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (pos == -1))
                {
                    pos = dbHandler.AlumnsQuantity - 1;
                    RecordPositionLabel(pos);
                    ShowAlumnsRecords(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos = dbHandler.AlumnsQuantity - 1;
                    RecordPositionLabel(pos);
                    ShowAlumnsRecords(pos);
                }
            }
        }

        private void btnAlumnNext_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                btnAlumnFirst.PerformClick();
            }
            else if (pos <= (dbHandler.AlumnsQuantity - 1))
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (pos == -1))
                {
                    pos++;
                    RecordPositionLabel(pos);
                    ShowAlumnsRecords(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos++;
                    RecordPositionLabel(pos);
                    ShowAlumnsRecords(pos);
                }
            }
        }

        private void btnAlumnPrevious_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                btnAlumnFirst.PerformClick();
            }
            else if (pos > 0)
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (pos == -1))
                {
                    pos--;
                    RecordPositionLabel(pos);
                    ShowAlumnsRecords(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos--;
                    RecordPositionLabel(pos);
                    ShowAlumnsRecords(pos);
                }
            }
        }

        private void btnAlumnClear_Click(object sender, EventArgs e)
        {
            txtbAlumnID.Clear();
            txtbAlumnName.Clear();
            txtbAlumnSurnames.Clear();
            txtbAlumnPhone.Clear();
            txtbAlumnAdress.Clear();
            txtbAlumnPassword.Clear();
            txtbAlumnCourse.Clear();
            pos = -1;
            lblRecord.Text = "";
            ButtonsCheck();
        }

        private void btnAlumnSave_Click(object sender, EventArgs e)
        {
            // CHECKS THAT THE ACTUAL TEXT BOX ID TEXT IS NOT USED ALREADY IN THE DB
            if (!dbHandler.DuplicatedID(txtbAlumnID.Text, "Alumnos"))
            {
                // CHECKS THAT THE ACTUAL TEXT BOX PHONE TEXT IS NOT USED ALREADY IN THE DB
                if (!dbHandler.DuplicatedPhone(txtbAlumnPhone.Text, "Alumnos"))
                {
                    // CHECKS THAT THE ACTUAL TEXT BOX EMAIL TEXT IS NOT USED ALREADY IN THE DB
                    if (!dbHandler.DuplicatedAdress(txtbAlumnAdress.Text, "Alumnos"))
                    {
                        if (dbHandler.CheckCourseExist(txtbAlumnCourse.Text))
                        {
                            // CREATES THE ALUMN TO SAVE
                            Alumn savedAlumn = Alumn.AlumnCreation(txtbAlumnID.Text,
                                                                   txtbAlumnName.Text,
                                                                   txtbAlumnSurnames.Text,
                                                                   txtbAlumnPhone.Text,
                                                                   txtbAlumnAdress.Text,
                                                                   txtbAlumnPassword.Text,
                                                                   txtbAlumnCourse.Text);

                            // IF THIS ALUMN IS VALID IT WILL BE INSERTED INTO THE DB
                            if (savedAlumn != null)
                            {
                                // FUNCTION WHICH CREATES A NEW ALUMN INTO THE DB
                                // AFTER THAT UPDATES THE POSITION AND THE COUNT OF ALUMN'S RECORDS
                                dbHandler.AddNewIdentity(savedAlumn, "Alumnos");
                                pos = dbHandler.AlumnsQuantity - 1;
                                RecordPositionLabel(pos);
                                btnAlumnCancelAddRegistry.PerformClick();
                                ButtonsCheck();
                            }
                            else
                            {
                                MessageBox.Show(returnErrorInput());
                            }
                        }
                        else
                        {
                            MessageBox.Show("This course doesn't exist, try another one");
                        }
                    }
                    else
                    {
                        MessageBox.Show("This adress is already used, try another one");
                    }
                }
                else
                {
                    MessageBox.Show("This phone is already used, try another one");
                }
            }
            else
            {
                MessageBox.Show("This ID is already used, try another one");
            }
        }

        private void btnAlumnUpdate_Click(object sender, EventArgs e)
        {
            if (pos != -1 && changeDetected)
            {
                // SETS VARIABLES DATA TO CREATE A TEMPORAL NEW ALUMN
                string ID = txtbAlumnID.Text;
                string name = txtbAlumnName.Text;
                string surnames = txtbAlumnSurnames.Text;
                string phone = txtbAlumnPhone.Text;
                string adress = txtbAlumnAdress.Text;
                string password = txtbAlumnPassword.Text;
                string course = txtbAlumnCourse.Text;

                // GETS THE SUPOSED DATA FROM AN ALUMN IN THE ACTUAL POSITION 
                Identity oldIdentityData = dbHandler.GetIdentityType(pos, "Alumnos");

                // CHECKS IF THE SELECTED ALUMN IS AN ALUMN AND CONVERTS THAT ALUMN INTO AN ALUMN TYPE TO ACCES TO ITS PROPERTIES
                if (oldIdentityData is Alumn oldAlumnData)
                {
                    // MAKES SURE THAT THE FOLLOWING ID-PHONE-MAIL IS NOT USED OR IF IT'S EXACTLY THE SAME BEFORE ANY CHANGE 
                    if (!dbHandler.DuplicatedID(ID, "Alumnos") || ID == oldAlumnData.ID)
                    {
                        if (!dbHandler.DuplicatedPhone(phone, "Alumnos") || phone == oldAlumnData.Phone)
                        {
                            if (!dbHandler.DuplicatedAdress(adress, "Alumnos") || adress == oldAlumnData.Adress)
                            {
                                if (dbHandler.CheckCourseExist(txtbAlumnCourse.Text))
                                {
                                    // CREATES A NEW ALUMN AS AN ALUMN TYPE ONE
                                    Identity selectedIdentityToUpdate = Alumn.AlumnCreation(ID, name, surnames, phone, adress, password, course);
                                    if (selectedIdentityToUpdate != null)
                                    {
                                        dbHandler.UpdateIdentity(selectedIdentityToUpdate, pos, "Alumnos");
                                        ShowAlumnsRecords(pos);
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
                                    MessageBox.Show("This course doesn't exist, try another one");
                                }
                            }
                            else
                            {
                                MessageBox.Show("This email is already used, try another one");
                            }
                        }
                        else
                        {
                            MessageBox.Show("This phone is already used, try another one");
                        }
                    }
                    else
                    {
                        MessageBox.Show("This ID is already used, try another one");
                    }

                }
                else if (dbHandler.AlumnsQuantity == 0)
                {
                    MessageBox.Show("Updating without having atleast one alumn in the DB is meaningless, try again after adding an alumn to the DB.");
                }
                else
                {
                    MessageBox.Show(returnErrorInput());
                }
            }
        }

        private void btnAlumnDelete_Click(object sender, EventArgs e)
        {
            if (dbHandler.AlumnsQuantity > 0)
            {
                if (pos != -1)
                {
                    DialogResult delete;
                    delete = MessageBox.Show("Do you want to delete this record (Y/N)?", "Delete Record?", MessageBoxButtons.YesNo);

                    if (delete == DialogResult.Yes)
                    {
                        dbHandler.DeleteIdentity(pos, "Alumnos");

                        // RESETS POSITION
                        pos = 0;
                        RecordPositionLabel(pos);
                        ShowAlumnsRecords(pos);
                        ButtonsCheck();
                    }
                }
                else
                {
                    MessageBox.Show("Delete is not possible when no alumn is selected.");
                }
            }
            else if (dbHandler.AlumnsQuantity == 0)
            {
                MessageBox.Show("Delete is not possible when no elements are in the database.");
            }

        }

        private void btnSearchAlumn_Click(object sender, EventArgs e)
        {
            if (dbHandler.AlumnsQuantity > 1)
            {
                bool showed = false;
                do
                {
                    string alumnSurname = Interaction.InputBox("Introduce the alumn's surname to show data (ONLY LETTERS): ");

                    if (CustomRegex.RegexName(alumnSurname))
                    {
                        if (SimilarAlumnSurnamesCounter(alumnSurname) > 0)
                        {
                            SelectSimilarNameAlumnsToShow(alumnSurname);
                            showed = true;
                        }
                        else
                        {
                            MessageBox.Show("There isn't any alumn with the selected name, try again");
                            showed = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The name format is not correct, try again");
                    }

                } while (!showed);

            }
            else if (dbHandler.AlumnsQuantity == 1)
            {
                Identity uniqueAlumn = dbHandler.GetIdentityType(0, "Alumnos");
                MessageBox.Show("There's only one alumn so it's data will be the one showed.");
                MessageBox.Show(dbHandler.GetIdentityData(uniqueAlumn, 0, "Alumnos"));
            }
            else
            {
                MessageBox.Show("Error, the list has no added alumns, add an alumn before checking an alumn data from the alumns list");
            }
        }

        private void btnAlumnSearchCourse_Click(object sender, EventArgs e)
        {
            if (dbHandler.AlumnsQuantity > 1)
            {
                bool showed = false;
                do
                {
                    string alumnCourse = Interaction.InputBox("Introduce the alumn's course to show data (EXAMPLE: 1-DAW-N): ");
                    if (SimilarAlumnCourseCounter(alumnCourse) > 0)
                    {
                        SelectSimilarCourseAlumnsToShow(alumnCourse);
                        showed = true;
                    }
                    else
                    {
                        MessageBox.Show("There isn't any alumn in the selected course, try again");
                        showed = true;
                    }
                } while (!showed);

            }
            else if (dbHandler.AlumnsQuantity == 1)
            {
                Identity uniqueAlumn = dbHandler.GetIdentityType(0, "Alumnos");
                MessageBox.Show("There's only one alumn so it's data will be the one showed.");
                MessageBox.Show(dbHandler.GetIdentityData(uniqueAlumn, 0, "Alumnos"));
            }
            else
            {
                MessageBox.Show("Error, the list has no added alumns, add an alumn before checking an alumn data from the alumns list");
            }
        }

        private void btnListAlumns_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ShowsAlumnsList());
        }

        /* ---------------- BUTTONS HANDLING END --------------------- */

        /* ---------------- INPUT ERROR HANDLING START --------------------- */

        // ERROR STRING IF INPUT IS INVALID
        private string returnErrorInput()
        {
            string errorMessage = "Error, not valid data, try again. " +
                                  "\n\nEXAMPLE:" +
                                  "\nID: 12345678X / X1234567X" +
                                  "\nNAME: Sergio" +
                                  "\nSURNAMES: Diez Fernández" +
                                  "\nPHONE: 600000000 / 799999999" +
                                  "\nADRESS: San Gabriel's Street" +
                                  "\nPASSWORD: Sergio_Diez1" +
                                  "\nCOURSE: 2-DAW-N";
            return errorMessage;
        }

        /* ---------------- INPUT ERROR HANDLING END --------------------- */

        /* ---------------- TEXTBOX CHANGE HANDLING FUNCTIONS START --------------------- */

        public void ButtonsCheck()
        {
            bool recordsExist = (dbHandler.AlumnsQuantity > 0);
            bool noRecordSelected = (pos == -1);

            // ENABLE/DISABLE NAVIGATION BUTTONS
            btnAlumnNext.Enabled = (recordsExist && pos < dbHandler.AlumnsQuantity - 1) && !noRecordSelected;
            btnAlumnPrevious.Enabled = (recordsExist && pos > 0) && !noRecordSelected;
            btnAlumnLast.Enabled = (recordsExist && pos < dbHandler.AlumnsQuantity - 1) && !noRecordSelected;
            btnAlumnFirst.Enabled = (recordsExist && pos > 0) && !noRecordSelected;

            // ENABLE/DISABLE SAVE BUTTON IF NO RECORD IS SELECTED
            btnAlumnSave.Enabled = noRecordSelected;

            // ENABLE/DISABLE CANCEL ADD REGISTRY BUTTON IF NO RECORD IS SELECTED
            btnAlumnCancelAddRegistry.Enabled = noRecordSelected && recordsExist;

            // ENABLE/DISABLE DELETE AND UPDATE BUTTONS IF A RECORD IS SELECTED
            btnAlumnDelete.Enabled = recordsExist && !noRecordSelected;
            btnAlumnUpdate.Enabled = recordsExist && !noRecordSelected && changeDetected;

            // ENABLE/DISABLE OTHER BUTTONS BASED ON RECORD EXISTENCE
            btnAlumnClear.Enabled = recordsExist && !noRecordSelected;
            btnListAlumns.Enabled = recordsExist;
            btnSearchAlumn.Enabled = recordsExist;
            btnAlumnSearchCourse.Enabled = recordsExist;
        }

        // THIS FUNCTION AUTO CHECKS THE CHANGES DETECTED IN THE FOLLOWING TEXT BOXES BETWEEN THE ORIGINAL STRING AND THE NEW CHANGED
        private void UpdateChangeDetected(string currentValue, string originalValue)
        {
            bool anyChangeDetected = (currentValue != originalValue);
            changeDetected = anyChangeDetected;
            ButtonsCheck();
        }


        private void txtbAdress_TextChanged(object sender, EventArgs e)
        {
            Identity actualIdentity = dbHandler.GetIdentityType(pos, "Alumnos");
            if (actualIdentity is Alumn actualAlumn)
            {
                string originalAdress = actualAlumn.Adress;
                UpdateChangeDetected(txtbAlumnAdress.Text, originalAdress);
            }
        }

        private void txtbPassword_TextChanged(object sender, EventArgs e)
        {
            Identity actualIdentity = dbHandler.GetIdentityType(pos, "Alumnos");
            if (actualIdentity is Alumn actualAlumn)
            {
                string originalPassword = actualAlumn.Password;
                UpdateChangeDetected(txtbAlumnPassword.Text, originalPassword);
            }
        }

        private void txtbCourse_TextChanged(object sender, EventArgs e)
        {
            Identity actualIdentity = dbHandler.GetIdentityType(pos, "Alumnos");
            if (actualIdentity is Alumn actualAlumn)
            {
                string originalCourse = actualAlumn.CourseCod;
                UpdateChangeDetected(txtbAlumnCourse.Text, originalCourse);
            }
        }

        private void txtbAlumnID_TextChanged(object sender, EventArgs e)
        {
            Identity actualIdentity = dbHandler.GetIdentityType(pos, "Alumnos");
            if (actualIdentity is Alumn actualAlumn)
            {
                string originalID = actualAlumn.ID;
                UpdateChangeDetected(txtbAlumnID.Text, originalID);
            }
        }

        private void txtbAlumnName_TextChanged(object sender, EventArgs e)
        {
            Identity actualIdentity = dbHandler.GetIdentityType(pos, "Alumnos");
            if (actualIdentity is Alumn actualAlumn)
            {
                string originalName = actualAlumn.Name;
                UpdateChangeDetected(txtbAlumnName.Text, originalName);
            }
        }

        private void txtbAlumnSurnames_TextChanged(object sender, EventArgs e)
        {
            Identity actualIdentity = dbHandler.GetIdentityType(pos, "Alumnos");
            if (actualIdentity is Alumn actualAlumn)
            {
                string originalSurnames = actualAlumn.Surnames;
                UpdateChangeDetected(txtbAlumnSurnames.Text, originalSurnames);
            }
        }

        private void txtbAlumnPhone_TextChanged(object sender, EventArgs e)
        {
            Identity actualIdentity = dbHandler.GetIdentityType(pos, "Alumnos");
            if (actualIdentity is Alumn actualAlumn)
            {
                string originalPhone = actualAlumn.Phone;
                UpdateChangeDetected(txtbAlumnPhone.Text, originalPhone);
            }
        }

        /* ---------------- TEXTBOX CHANGE HANDLING FUNCTIONS END --------------------- */
    }
}