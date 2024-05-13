using Exercise_4.Models;
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

namespace Exercise_4.Views
{
    public partial class fAlumnData : Form
    {
        public fAlumnData()
        {
            InitializeComponent();
        }

        // CALLING SQLBDHANDLER TO MANAGE DB FUNCTIONS
        SqlDBHandler dbHandler;

        // FORM LOADING HANDLING
        private void fAlumnData_Load(object sender, EventArgs e)
        {
            dbHandler = new SqlDBHandler("Alumnos");
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
                object selectedObjectRecords = dbHandler.GetSelectedTypeObject(pos, "Alumnos");
                if (selectedObjectRecords is Alumn selectedAlumnRecords)
                {

                    // TAKE VALUES FROM EACH RECORD'S COLUMNS TO SET THEM IN THE APPROPIATE TEXTBOX
                    txtbID.Text = selectedAlumnRecords.ID;
                    txtbName.Text = selectedAlumnRecords.Name;
                    txtbSurnames.Text = selectedAlumnRecords.Surnames;
                    txtbPhone.Text = selectedAlumnRecords.Phone;
                    txtbAdress.Text = selectedAlumnRecords.Adress;

                    // DETECTED CHANGES RESET AND CHECKS THE ACTUAL BUTTONS STATUS
                    changeDetected = false;
                    ButtonsCheck();
                }
            }
            else if (dbHandler.AlumnsQuantity == 0)
            {
                // CLEAR EVERY DATA FROM THE TEXT BOXES AND CHECKS THE ACTUAL BUTTONS STATUS
                btnClear.PerformClick();
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
                                           "Adress: " + row["Direccion"] + "\n";

                        alumnListTxt += alumnInfo + "\n";
                    }
                    result = alumnListTxt;
                }
                else if (dbHandler.AlumnsQuantity == 1)
                {
                    object singleAlumn = dbHandler.GetSelectedTypeObject(0, "Alumnos");
                    alumnListTxt = dbHandler.GetObjectDataFromPosition(singleAlumn, 0, "Alumnos");
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
                                                  "Adress: " + alumnRow["Direccion"] + "\n";

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
                MessageBox.Show("No alumns found with the selected name.");
            }
        }

        /* ---------------- BUTTONS HANDLING START --------------------- */

        private bool CheckValuesChanged()
        {
            return dbHandler.CheckChangesStoredAndActualValues(pos, txtbID.Text, txtbName.Text, txtbSurnames.Text, txtbPhone.Text, txtbAdress.Text, "Alumnos");
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
            ShowAlumnsRecords(pos);
            RecordPositionLabel(pos);
        }

        private void btnFirst_Click(object sender, EventArgs e)
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

        private void btnLast_Click(object sender, EventArgs e)
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                btnFirst.PerformClick();
            }
            else if (pos < (dbHandler.AlumnsQuantity - 1))
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtbID.Clear();
            txtbName.Clear();
            txtbSurnames.Clear();
            txtbPhone.Clear();
            txtbAdress.Clear();
            pos = -1;
            lblRecord.Text = "";
            ButtonsCheck();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // CHECKS THAT THE ACTUAL TEXT BOX ID TEXT IS NOT USED ALREADY IN THE DB
            if (!dbHandler.DuplicatedIDDataFromSelectedTable(txtbID.Text, "Alumnos"))
            {
                // CHECKS THAT THE ACTUAL TEXT BOX PHONE TEXT IS NOT USED ALREADY IN THE DB
                if (!dbHandler.DuplicatedPhoneDataFromSelectedTable(txtbPhone.Text, "Alumnos"))
                {
                    // CHECKS THAT THE ACTUAL TEXT BOX EMAIL TEXT IS NOT USED ALREADY IN THE DB
                    if (!dbHandler.DuplicatedAdressDataFromSelectedTable(txtbAdress.Text, "Alumnos"))
                    {
                        // CREATES THE TEACHER TO SAVE
                        Alumn savedAlumn = Alumn.AlumnCreation(txtbID.Text,
                                                               txtbName.Text,
                                                               txtbSurnames.Text,
                                                               txtbPhone.Text,
                                                               txtbAdress.Text);

                        // IF THIS OBJECT IS VALID IT WILL BE INSERTED INTO THE DB
                        if (savedAlumn != null)
                        {
                            // FUNCTION WHICH CREATES A NEW ALUMN INTO THE DB
                            // AFTER THAT UPDATES THE POSITION AND THE COUNT OF ALUMN'S RECORDS
                            dbHandler.AddNewObject(savedAlumn, "Alumnos");
                            pos = dbHandler.AlumnsQuantity - 1;
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
                    MessageBox.Show("This phone is already used, try another one");
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
                // SETS VARIABLES DATA TO CREATE A TEMPORAL NEW ALUMN
                string ID = txtbID.Text;
                string name = txtbName.Text;
                string surnames = txtbSurnames.Text;
                string phone = txtbPhone.Text;
                string adress = txtbAdress.Text;

                // GETS THE SUPOSED DATA FROM AN OBJECT IN THE ACTUAL POSITION 
                object oldObjectData = dbHandler.GetSelectedTypeObject(pos, "Alumnos");

                // CHECKS IF THE SELECTED OBJECT IS AN ALUMN AND CONVERTS THAT OBJECT INTO AN ALUMN TYPE TO ACCES TO ITS PROPERTIES
                if (oldObjectData is Alumn oldAlumnData)
                {
                    // MAKES SURE THAT THE FOLLOWING ID-PHONE-MAIL IS NOT USED OR IF IT'S EXACTLY THE SAME BEFORE ANY CHANGE 
                    if (!dbHandler.DuplicatedIDDataFromSelectedTable(ID, "Alumnos") || ID == oldAlumnData.ID)
                    {
                        if (!dbHandler.DuplicatedPhoneDataFromSelectedTable(phone, "Alumnos") || phone == oldAlumnData.Phone)
                        {
                            if (!dbHandler.DuplicatedAdressDataFromSelectedTable(adress, "Alumnos") || adress == oldAlumnData.Adress)
                            {
                                // CREATES A NEW OBJECT AS AN ALUMN TYPE ONE
                                object selectedObjectToUpdate = Alumn.AlumnCreation(ID, name, surnames, phone, adress);
                                if (selectedObjectToUpdate != null)
                                {
                                    dbHandler.UpdateSelectedObjectFromPosition(selectedObjectToUpdate, pos, "Alumnos");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dbHandler.AlumnsQuantity > 0)
            {
                if (pos != -1)
                {
                    DialogResult delete;
                    delete = MessageBox.Show("Do you want to delete this record (Y/N)?", "Delete Record?", MessageBoxButtons.YesNo);

                    if (delete == DialogResult.Yes)
                    {
                        dbHandler.DeleteSelectedObjectFromPosition(pos, "Alumnos");

                        // RESETS POSITION
                        pos = 0;
                        RecordPositionLabel(pos); // RELOADS THE POSITION LABEL
                        ShowAlumnsRecords(pos);
                        ButtonsCheck();
                    }
                }
                else
                {
                    MessageBox.Show("Delete is not possible when no alumn is selected.");
                }
            }
            else if (dbHandler.TeachersQuantity == 0)
            {
                MessageBox.Show("Delete is not possible when no elements are in the database.");
            }
        }

        private void btnSearchTeacher_Click(object sender, EventArgs e)
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
                object uniqueAlumn = dbHandler.GetSelectedTypeObject(0, "Alumnos");
                MessageBox.Show("There's only one alumn so it's data will be the one showed.");
                MessageBox.Show(dbHandler.GetObjectDataFromPosition(uniqueAlumn, 0, "Alumnos"));
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
                                  "\nADRESS: San Gabriel's Street";
            return errorMessage;
        }

        /* ---------------- INPUT ERROR HANDLING END --------------------- */

        /* ---------------- TEXTBOX CHANGE HANDLING FUNCTIONS START --------------------- */

        public void ButtonsCheck()
        {
            bool recordsExist = (dbHandler.TeachersQuantity > 0);
            bool noRecordSelected = (pos == -1);

            // ENABLE/DISABLE NAVIGATION BUTTONS
            btnNext.Enabled = (recordsExist && pos < dbHandler.TeachersQuantity - 1) && !noRecordSelected;
            btnLast.Enabled = (recordsExist && pos < dbHandler.TeachersQuantity - 1) && !noRecordSelected;
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
            btnListAlumns.Enabled = recordsExist;
            btnSearchTeacher.Enabled = recordsExist;
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
            object actualObject = dbHandler.GetSelectedTypeObject(pos, "Alumnos");
            if (actualObject is Alumn actualAlumn)
            {
                string originalID = actualAlumn.ID;
                UpdateChangeDetected(txtbID.Text, actualAlumn.ID);
            }
        }

        private void txtbName_TextChanged(object sender, EventArgs e)
        {
            object actualObject = dbHandler.GetSelectedTypeObject(pos, "Alumnos");
            if (actualObject is Alumn actualAlumn)
            {
                string originalName = actualAlumn.Name;
                UpdateChangeDetected(txtbName.Text, originalName);
            }
        }

        private void txtbSurnames_TextChanged(object sender, EventArgs e)
        {
            object actualObject = dbHandler.GetSelectedTypeObject(pos, "Alumnos");
            if (actualObject is Alumn actualAlumn)
            {
                string originalSurnames = actualAlumn.Surnames;
                UpdateChangeDetected(txtbSurnames.Text, originalSurnames);
            }
        }

        private void txtbPhone_TextChanged(object sender, EventArgs e)
        {
            object actualObject = dbHandler.GetSelectedTypeObject(pos, "Alumnos");
            if (actualObject is Alumn actualAlumn)
            {
                string originalPhone = actualAlumn.Phone;
                UpdateChangeDetected(txtbPhone.Text, originalPhone);
            }
        }

        private void txtbAdress_TextChanged(object sender, EventArgs e)
        {
            object actualObject = dbHandler.GetSelectedTypeObject(pos, "Alumnos");
            if (actualObject is Alumn actualAlumn)
            {
                string originalAdress = actualAlumn.Adress;
                UpdateChangeDetected(txtbAdress.Text, originalAdress);
            }
        }


        /* ---------------- TEXTBOX CHANGE HANDLING FUNCTIONS END --------------------- */
    }
}