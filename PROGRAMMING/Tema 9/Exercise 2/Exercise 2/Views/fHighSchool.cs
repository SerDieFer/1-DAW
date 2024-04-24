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

namespace Exercise_2
{
    // ERROR AL BORRAR TODOS
    public partial class fHighSchool : Form
    {
        private List<Person> personList;

        public fHighSchool()
        {
            InitializeComponent();
        }

        // CALLING SQLBDHANDLER TO MANAGE DB FUNCTIONS
        TeacherDBHandler handleDB;

        /* ---------------- POSITION HANDLING START --------------------- */

        // CREATION OF GLOBAL POSITION
        private int pos = -1;

        // SETS THE POSITION OF THE ACTUAL RECORD INTO A TEXT LABEL
        private void RecordPositionLabel(int pos)
        {
            if (handleDB.TeachersQuantity > 0)
            {
                lblRecord.Text = "Record Nº" + (pos + 1) + " of " + handleDB.TeachersQuantity;
            }
            else if (handleDB.TeachersQuantity == 0)
            {
                lblRecord.Text = "";
            }
        }

            /* ---------------- POSITION HANDLING END --------------------- */

        // FORM LOADING HANDLING
        private void fHighSchool_Load(object sender, EventArgs e)
        {
            // SETS FIRST POSITION, UPDATES THE VISUALS AND CHECKS THE ACTUAL BUTTONS STATUS WHEN FIRST LOADED
            pos = 0;
            RecordPositionLabel(pos);
            ShowTeacherRecords(pos);
            ButtonsCheck();
        }

        // THESE ARE FOR DETECTING STRING CHANGES IN THE TEXT BOXES SINCE AN ORIGINAL
        // IS REQUIRED TO CHECK BETWEEN THAT ONE AND THE USER CHANGED INPUT
        private bool changeDetected = false;


        // FUNCTION WHICH UPDATES THE VISUAL PART OF THE FORM
        private void ShowTeacherRecords(int pos)
        {
            if (handleDB.TeachersQuantity > 0)
            {
                Teacher selectedTeacherRecords = handleDB.GetTeacherObject(pos);

                // TAKE VALUES FROM EACH RECORD'S COLUMNS TO SET THEM IN THE APPROPIATE TEXTBOX
                txtbID.Text = selectedTeacherRecords.ID;
                txtbName.Text = selectedTeacherRecords.Name;
                txtbSurnames.Text = selectedTeacherRecords.Surnames;
                txtbPhone.Text = selectedTeacherRecords.Phone;
                txtbEmail.Text = selectedTeacherRecords.Email;

                // DETECTED CHANGES RESET AND CHECKS THE ACTUAL BUTTONS STATUS
                changeDetected = false;
                ButtonsCheck();
            }
            else if(handleDB.TeachersQuantity == 0)
            {
                // CLEAR EVERY DATA FROM THE TEXT BOXES AND CHECKS THE ACTUAL BUTTONS STATUS
                btnClear.PerformClick();
                ButtonsCheck();
            }
        }

        public string ShowsTeachersList()
        {
            string result = "";
            if (handleDB.TeachersQuantity != 0)
            {
                string teacherListTxt = "List of teachers: \n\n";

                if (handleDB.TeachersQuantity > 1)
                {
                    DataTable teachersTable = handleDB.ImportTeachersDataTable();

                    foreach (DataRow row in teachersTable.Rows)
                    {
                        string teacherInfo = "ID: " + row["DNI"] + "\n" +
                                                "Name: " + row["Nombre"] + "\n" +
                                                "Surnames: " + row["Apellido"] + "\n" +
                                                "Phone: " + row["Tlf"] + "\n" +
                                                "Email: " + row["Email"] + "\n";

                        teacherListTxt += teacherInfo + "\n";
                    }
                    result = teacherListTxt;
                }
                else if (handleDB.TeachersQuantity == 1)
                {
                    Teacher singleTeacher = handleDB.GetTeacherObject(0);
                    teacherListTxt = "Teacher Data: \n\n" + handleDB.getTeacherDataFromPosition(singleTeacher, 0);
                    result = teacherListTxt;
                }
            }
            else
            {
                result = "No teachers added in the DB.";
            }
            return result;
        }

        public int SimilarTeacherSurnamesCounter(string teacherSurname)
        {
            int counter = 0;
            if (handleDB.TeachersQuantity != 0)
            {
                for (int i = 0; i < handleDB.TeachersQuantity; i++)
                {
                    DataRow teacherRow = handleDB.ImportTeachersDataTable().Rows[i];
                    string stringToCheck = teacherRow[2].ToString().ToLower();
                    if (stringToCheck.Contains(teacherSurname.ToLower()))
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        public void SelectSimilarNameTeachersToShow(string teacherSurname)
        {
            List<string> matchingTeachersSurname = new List<string>();
            List<string> extraTeachersInfo = new List<string>();
            List<int> teachersPositions = new List<int>();

            if (handleDB.TeachersQuantity != 0)
            {
                for (int i = 0; i < handleDB.TeachersQuantity; i++)
                {
                    DataRow teacherRow = handleDB.ImportTeachersDataTable().Rows[i];
                    string stringToCheck = teacherRow[2].ToString().ToLower();
                    if (stringToCheck.Contains(teacherSurname.ToLower()))
                    {
                        string fullName = (teacherRow["Nombre"] + " " + teacherRow["Apellido"]).ToString();
                        matchingTeachersSurname.Add(fullName);

                        string extraTeacherInfo = "ID: " + teacherRow["DNI"] + "\n" +
                                                  "Name: " + teacherRow["Nombre"] + "\n" +
                                                  "Surnames: " + teacherRow["Apellido"] + "\n" +
                                                  "Phone: " + teacherRow["Tlf"] + "\n" +
                                                  "Email: " + teacherRow["Email"] + "\n";

                        extraTeachersInfo.Add(extraTeacherInfo);
                        teachersPositions.Add(i);
                    }
                }
                
            }
            if (matchingTeachersSurname.Count == 1)
            {
                MessageBox.Show("The data from " + matchingTeachersSurname[0] + " is: \n\n" + extraTeachersInfo[0]);
                pos = teachersPositions[0];
                ShowTeacherRecords(pos);
                RecordPositionLabel(pos);
            }
            else if (matchingTeachersSurname.Count > 1)
            {
                bool showed = false;
                int selectedTeacherIndex = 0;

                while (!showed)
                {
                    StringBuilder infoMessage = new StringBuilder("Teachers with the same surname:\n\n");

                    for (int i = 0; i < matchingTeachersSurname.Count; i++)
                    {
                        infoMessage.AppendLine((i + 1) + ") " + matchingTeachersSurname[i] + "\n");
                    }

                    infoMessage.AppendLine("Select the number of the teacher to view more data:");

                    string userInput = Interaction.InputBox(infoMessage.ToString());

                    if (int.TryParse(userInput, out selectedTeacherIndex) && selectedTeacherIndex > 0 && selectedTeacherIndex <= matchingTeachersSurname.Count)
                    {
                        string selectedTeacherInfo = extraTeachersInfo[selectedTeacherIndex - 1];
                        int selectedTeacherPositionInDB = teachersPositions[selectedTeacherIndex - 1];

                        DialogResult result = MessageBox.Show(selectedTeacherInfo + "\n\nIs this the teacher you want to check info?", "Check Teacher Info", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            pos = selectedTeacherPositionInDB;
                            ShowTeacherRecords(pos);
                            RecordPositionLabel(pos);
                            showed = true;
                        }
                        else
                        {
                            MessageBox.Show("Please select a different teacher.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid number corresponding to a teacher.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No teachers found with the selected name.");
            }
        }

        /* ---------------- BUTTONS HANDLING START --------------------- */

        private bool CheckValuesChanged()
        {
            return handleDB.CheckChangesStoredAndActualValues(pos, txtbID.Text, txtbName.Text, txtbSurnames.Text, txtbPhone.Text, txtbEmail.Text);
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
            ShowTeacherRecords(pos);
            RecordPositionLabel(pos);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                pos = 0;
                RecordPositionLabel(pos);
                ShowTeacherRecords(pos);
            }
            else
            {
                bool possiblyChangedValues = CheckValuesChanged();

                if (possiblyChangedValues && (pos == -1))
                {
                    pos = 0;
                    RecordPositionLabel(pos);
                    ShowTeacherRecords(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos = 0;
                    RecordPositionLabel(pos);
                    ShowTeacherRecords(pos);
                }
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                pos = handleDB.TeachersQuantity - 1;
                RecordPositionLabel(pos);
                ShowTeacherRecords(pos);
            }
            else
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (pos == -1))
                {
                    pos = handleDB.TeachersQuantity - 1;
                    RecordPositionLabel(pos);
                    ShowTeacherRecords(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos = handleDB.TeachersQuantity - 1;
                    RecordPositionLabel(pos);
                    ShowTeacherRecords(pos);
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                btnFirst.PerformClick();
            }
            else if (pos < (handleDB.TeachersQuantity - 1))
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (pos == -1))
                {
                    pos++;
                    RecordPositionLabel(pos);
                    ShowTeacherRecords(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos++;
                    RecordPositionLabel(pos);
                    ShowTeacherRecords(pos);
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
                    ShowTeacherRecords(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos--;
                    RecordPositionLabel(pos);
                    ShowTeacherRecords(pos);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtbID.Clear();
            txtbName.Clear();
            txtbSurnames.Clear();
            txtbPhone.Clear();
            txtbEmail.Clear();
            pos = -1;
            lblRecord.Text = "";
            ButtonsCheck();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // CHECKS THAT THE ACTUAL TEXT BOX ID TEXT IS NOT USED ALREADY IN THE DB
            if (!handleDB.DuplicatedIDData(txtbID.Text))
            {
                // CHECKS THAT THE ACTUAL TEXT BOX PHONE TEXT IS NOT USED ALREADY IN THE DB
                if (!handleDB.DuplicatedPhoneData(txtbPhone.Text))
                {
                    // CHECKS THAT THE ACTUAL TEXT BOX EMAIL TEXT IS NOT USED ALREADY IN THE DB
                    if (!handleDB.DuplicatedEmailData(txtbEmail.Text))
                    {
                        // CREATES THE TEACHER TO SAVE
                        Teacher savedTeacher = Teacher.TeacherCreation(txtbID.Text,
                                                                       txtbName.Text,
                                                                       txtbSurnames.Text,
                                                                       txtbPhone.Text,
                                                                       txtbEmail.Text);

                        // IF THIS OBJECT IS VALID IT WILL BE INSERTED INTO THE DB
                        if (savedTeacher != null)
                        {
                            // FUNCTION WHICH CREATES A NEW TEACHER INTO THE DB
                            // AFTER THAT UPDATES THE POSITION AND THE COUNT OF TEACHER'S RECORDS
                            handleDB.AddNewTeacher(savedTeacher);
                            pos = handleDB.TeachersQuantity - 1;
                            RecordPositionLabel(pos);      
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
                if (!handleDB.DuplicatedIDData(txtbID.Text))
                {
                    if (!handleDB.DuplicatedPhoneData(txtbPhone.Text))
                    {
                        if (!handleDB.DuplicatedEmailData(txtbEmail.Text))
                        {
                            handleDB.UpdateTeacher(pos);

                            ShowTeacherRecords(pos);
                            RecordPositionLabel(pos);

                            changeDetected = false;

                            ButtonsCheck();
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
            else if (handleDB.TeachersQuantity == 0)
            {
                MessageBox.Show("Updating without having atleast one teacher in the DB is meaningless, try again after adding a teacher to the DB.");
            }
            else
            {
                MessageBox.Show(returnErrorInput());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        { 
            if (handleDB.TeachersQuantity > 0)
            {
                if (pos != -1)
                {
                    DialogResult delete;
                    delete = MessageBox.Show("Do you want to delete this record (Y/N)?", "Delete Record?", MessageBoxButtons.YesNo);

                    if (delete == DialogResult.Yes)
                    {
                        handleDB.DeleteTeacher(pos);

                        // RESETS POSITION
                        pos = 0;
                        RecordPositionLabel(pos); // RELOADS THE POSITION LABEL
                        ShowTeacherRecords(pos); 
                    }
                }
                else
                {
                    MessageBox.Show("Delete is not possible when no teacher is selected.");
                }
            }
            else if (handleDB.TeachersQuantity == 0)
            {
                MessageBox.Show("Delete is not possible when no elements are in the database.");
            }
        }

        private void btnSearchTeacher_Click(object sender, EventArgs e)
        {
            if (handleDB.TeachersQuantity > 1)
            {
                bool showed = false;
                do
                {
                    string teacherSurname = Interaction.InputBox("Introduce the teacher's surname to show data (ONLY LETTERS): ");

                    if (CustomRegex.RegexName(teacherSurname))
                    {
                        if (SimilarTeacherSurnamesCounter(teacherSurname) > 0)
                        {
                            SelectSimilarNameTeachersToShow(teacherSurname);
                            showed = true;
                        }
                        else
                        {
                            MessageBox.Show("There isn't any teacher with the selected name, try again");
                            showed = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The name format is not correct, try again");
                    }

                } while (!showed);
                
            }
            else if (handleDB.TeachersQuantity == 1)
            {
                MessageBox.Show("There's only one teacher so it's data will be the one showed.");
                MessageBox.Show("The data from " + handleDB.getTeacherFullNameFromPosition(handleDB.GetTeacherObject(0), 0) +
                                " is: \n\n" + handleDB.getTeacherDataFromPosition(handleDB.GetTeacherObject(0), 0));
            }
            else
            {
                MessageBox.Show("Error, the list has no added teachers, add a teacher before checking a teacher data from the teacher list");
            }
        }

        private void btnListTeachers_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ShowsTeachersList());
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
                                  "\nEMAIL: x@iesmarenostrum.com";
            return errorMessage;
        }

            /* ---------------- INPUT ERROR HANDLING END --------------------- */

        /* ---------------- TEXTBOX CHANGE HANDLING FUNCTIONS START --------------------- */

        public void ButtonsCheck()
        {
            bool recordsExist = (handleDB.TeachersQuantity > 0);
            bool noRecordSelected = (pos == -1);

            // ENABLE/DISABLE NAVIGATION BUTTONS
            btnNext.Enabled = (recordsExist && pos < handleDB.TeachersQuantity - 1) && !noRecordSelected;
            btnLast.Enabled = (recordsExist && pos < handleDB.TeachersQuantity - 1) && !noRecordSelected;
            btnPrevious.Enabled = (recordsExist && pos > 0) && !noRecordSelected;
            btnFirst.Enabled = (recordsExist && pos > 0) && !noRecordSelected;

            // ENABLE/DISABLE SAVE BUTTON IF NO RECORD IS SELECTED
            btnSave.Enabled = noRecordSelected;

            // ENABLE/DISABLE CANCEL ADD REGISTRY BUTTON IF NO RECORD IS SELECTED
            btnCancelAddRegistry.Enabled = noRecordSelected;

            // ENABLE/DISABLE DELETE AND UPDATE BUTTONS IF A RECORD IS SELECTED
            btnDelete.Enabled = recordsExist && !noRecordSelected;
            btnUpdate.Enabled = recordsExist && !noRecordSelected && changeDetected;

            // ENABLE/DISABLE OTHER BUTTONS BASED ON RECORD EXISTENCE
            btnClear.Enabled = recordsExist && !noRecordSelected;
            btnListTeachers.Enabled = recordsExist;
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
            UpdateChangeDetected(txtbID.Text, originalID);
        }

        private void txtbName_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected(txtbName.Text, originalName);
        }

        private void txtbSurnames_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected(txtbSurnames.Text, originalSurnames);
        }

        private void txtbPhone_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected(txtbPhone.Text, originalPhone);
        }

        private void txtbEmail_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected(txtbEmail.Text, originalEmail);
        }

            /* ---------------- TEXTBOX CHANGE HANDLING FUNCTIONS END --------------------- */
    }
}
