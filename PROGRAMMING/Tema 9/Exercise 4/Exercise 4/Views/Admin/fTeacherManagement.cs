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
    public partial class fTeacherManagement : Form
    {
        public fTeacherManagement()
        {
            InitializeComponent();
        }

        // CALLING SQLBDHANDLER TO MANAGE DB FUNCTIONS
        SqlDBHandler dbHandler;

        // FORM LOADING HANDLING
        private void fTeacherManagement_Load(object sender, EventArgs e)
        {
            dbHandler = new SqlDBHandler("Profesores");
            // SETS FIRST POSITION, UPDATES THE VISUALS AND CHECKS THE ACTUAL BUTTONS STATUS WHEN FIRST LOADED
            pos = 0;
            RecordPositionLabel(pos);
            ShowTeacherRecords(pos);
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
            if (dbHandler.TeachersQuantity > 0)
            {
                lblRecord.Text = "Record Nº" + (pos + 1) + " of " + dbHandler.TeachersQuantity;
            }
            else if (dbHandler.TeachersQuantity == 0)
            {
                lblRecord.Text = "";
            }
        }

            /* ---------------- POSITION HANDLING END --------------------- */

   
        // FUNCTION WHICH UPDATES THE VISUAL PART OF THE FORM
        private void ShowTeacherRecords(int pos)
        {
            if (dbHandler.TeachersQuantity > 0)
            {
                Identity selectedIdentityRecords = dbHandler.GetIdentityType(pos, "Profesores");
                if (selectedIdentityRecords is Teacher selectedTeacherRecords)
                {
    
                    // TAKE VALUES FROM EACH RECORD'S COLUMNS TO SET THEM IN THE APPROPIATE TEXTBOX
                    txtbTeacherID.Text = selectedTeacherRecords.ID;
                    txtbTeacherName.Text = selectedTeacherRecords.Name;
                    txtbTeacherSurnames.Text = selectedTeacherRecords.Surnames;
                    txtbTeacherPhone.Text = selectedTeacherRecords.Phone;
                    txtbTeacherEmail.Text = selectedTeacherRecords.Email;
                    txtbTeacherPassword.Text = selectedTeacherRecords.Password;
                    txtbTeacherCourse.Text = selectedTeacherRecords.CourseCod;

                    // DETECTED CHANGES RESET AND CHECKS THE ACTUAL BUTTONS STATUS
                    changeDetected = false;
                    ButtonsCheck();
                }
            }
            else if(dbHandler.TeachersQuantity == 0)
            {
                // CLEAR EVERY DATA FROM THE TEXT BOXES AND CHECKS THE ACTUAL BUTTONS STATUS
                btnTeacherClear.PerformClick();
                ButtonsCheck();
            }
        }

        public string ShowsTeachersList()
        {
            string result = "";
            if (dbHandler.TeachersQuantity != 0)
            {
                string teacherListTxt = "List of teachers: \n\n";

                if (dbHandler.TeachersQuantity > 1)
                {
                    DataTable teachersTable = dbHandler.ImportSelectedDataTable("Profesores");

                    foreach (DataRow row in teachersTable.Rows)
                    {
                        string teacherInfo = "ID: " + row["DNI"] + "\n" +
                                             "Name: " + row["Nombre"] + "\n" +
                                             "Surnames: " + row["Apellido"] + "\n" +
                                             "Phone: " + row["Tlf"] + "\n" +
                                             "Email: " + row["Email"] + "\n" +
                                             "Course: " + row["Cursos"] + "\n";

                        teacherListTxt += teacherInfo + "\n";
                    }
                    result = teacherListTxt;
                }
                else if (dbHandler.TeachersQuantity == 1)
                {
                    Identity singleTeacher = dbHandler.GetIdentityType(0, "Profesores");
                    teacherListTxt = dbHandler.GetIdentityData(singleTeacher, 0, "Profesores");
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
            if (dbHandler.TeachersQuantity != 0)
            {
                for (int i = 0; i < dbHandler.TeachersQuantity; i++)
                {
                    DataRow teacherRow = dbHandler.ImportSelectedDataTable("Profesores").Rows[i];
                    string stringToCheck = teacherRow[2].ToString().ToLower();
                    if (stringToCheck.Contains(teacherSurname.ToLower()))
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        public int SimilarTeacherCourseCounter(string teacherCourse)
        {
            int counter = 0;
            if (dbHandler.TeachersQuantity != 0)
            {
                for (int i = 0; i < dbHandler.TeachersQuantity; i++)
                {
                    DataRow teacherRow = dbHandler.ImportSelectedDataTable("Profesores").Rows[i];
                    string stringToCheck = teacherRow[6].ToString().ToLower();
                    if (stringToCheck.Contains(teacherCourse.ToLower()))
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

            if (dbHandler.TeachersQuantity != 0)
            {
                for (int i = 0; i < dbHandler.TeachersQuantity; i++)
                {
                    DataRow teacherRow = dbHandler.ImportSelectedDataTable("Profesores").Rows[i];
                    string stringToCheck = teacherRow[2].ToString().ToLower();
                    if (stringToCheck.Contains(teacherSurname.ToLower()))
                    {
                        string fullName = (teacherRow["Nombre"] + " " + teacherRow["Apellido"]).ToString();
                        matchingTeachersSurname.Add(fullName);

                        string extraTeacherInfo = "ID: " + teacherRow["DNI"] + "\n" +
                                                  "Name: " + teacherRow["Nombre"] + "\n" +
                                                  "Surnames: " + teacherRow["Apellido"] + "\n" +
                                                  "Phone: " + teacherRow["Tlf"] + "\n" +
                                                  "Email: " + teacherRow["Email"] + "\n" +
                                                  "Course: " + teacherRow["Cursos"] + "\n";

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
                    StringBuilder infoMessage = new StringBuilder("Teachers with similar surname:\n\n");

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

        public void SelectSimilarCourseTeachersToShow(string teacherSurname)
        {
            List<string> matchingTeachersCourse = new List<string>();
            List<string> extraTeachersInfo = new List<string>();
            List<int> teachersPositions = new List<int>();

            if (dbHandler.TeachersQuantity != 0)
            {
                for (int i = 0; i < dbHandler.TeachersQuantity; i++)
                {
                    DataRow teacherRow = dbHandler.ImportSelectedDataTable("Profesores").Rows[i];
                    string stringToCheck = teacherRow[6].ToString().ToLower();
                    if (stringToCheck.Contains(teacherSurname.ToLower()))
                    {
                        string fullName = (teacherRow["Nombre"] + " " + teacherRow["Apellido"]).ToString();
                        matchingTeachersCourse.Add(fullName);

                        string extraTeacherInfo = "ID: " + teacherRow["DNI"] + "\n" +
                                                  "Name: " + teacherRow["Nombre"] + "\n" +
                                                  "Surnames: " + teacherRow["Apellido"] + "\n" +
                                                  "Phone: " + teacherRow["Tlf"] + "\n" +
                                                  "Email: " + teacherRow["Email"] + "\n" +
                                                  "Course: " + teacherRow["Cursos"] + "\n";

                        extraTeachersInfo.Add(extraTeacherInfo);
                        teachersPositions.Add(i);
                    }
                }

            }
            if (matchingTeachersCourse.Count == 1)
            {
                MessageBox.Show("The data from " + matchingTeachersCourse[0] + " is: \n\n" + extraTeachersInfo[0]);
                pos = teachersPositions[0];
                ShowTeacherRecords(pos);
                RecordPositionLabel(pos);
            }
            else if (matchingTeachersCourse.Count > 1)
            {
                bool showed = false;
                int selectedTeacherIndex = 0;

                while (!showed)
                {
                    StringBuilder infoMessage = new StringBuilder("Teachers with the same course:\n\n");

                    for (int i = 0; i < matchingTeachersCourse.Count; i++)
                    {
                        infoMessage.AppendLine((i + 1) + ") " + matchingTeachersCourse[i] + "\n");
                    }

                    infoMessage.AppendLine("Select the number of the teacher to view more data:");

                    string userInput = Interaction.InputBox(infoMessage.ToString());

                    if (int.TryParse(userInput, out selectedTeacherIndex) && selectedTeacherIndex > 0 && selectedTeacherIndex <= matchingTeachersCourse.Count)
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
                MessageBox.Show("No teachers found with the selected course.");
            }
        }

        /* ---------------- BUTTONS HANDLING START --------------------- */

        private bool CheckValuesChanged()
        {
            return dbHandler.CheckChangesStoredAndActualValues(pos, txtbTeacherID.Text, txtbTeacherName.Text, txtbTeacherSurnames.Text,
                                                               txtbTeacherPhone.Text, txtbTeacherEmail.Text, txtbTeacherPassword.Text, txtbTeacherCourse.Text, "Profesores");
        }


        private void askToUpdateIfChangesWereMade(bool choice)
        {
            if (!choice)
            {
                DialogResult update = MessageBox.Show("Do you want to keep changes of this record (Y/N)?", "Keep Changes?", MessageBoxButtons.YesNo);

                if (update == DialogResult.Yes)
                {
                    btnTeacherUpdate.PerformClick();
                }
            }
        }

        private void btnTeacherCancelAddRegistry_Click(object sender, EventArgs e)
        {
            pos = 0;
            ShowTeacherRecords(pos);
            RecordPositionLabel(pos);
        }

        private void btnTeacherFirst_Click(object sender, EventArgs e)
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

        private void btnTeacherLast_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                pos = dbHandler.TeachersQuantity - 1;
                RecordPositionLabel(pos);
                ShowTeacherRecords(pos);
            }
            else
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (pos == -1))
                {
                    pos = dbHandler.TeachersQuantity - 1;
                    RecordPositionLabel(pos);
                    ShowTeacherRecords(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos = dbHandler.TeachersQuantity - 1;
                    RecordPositionLabel(pos);
                    ShowTeacherRecords(pos);
                }
            }
        }

        private void btnTeacherNext_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                btnTeacherFirst.PerformClick();
            }
            else if (pos < (dbHandler.TeachersQuantity - 1))
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

        private void btnTeacherPrevious_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                btnTeacherFirst.PerformClick();
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

        private void btnTeacherClear_Click(object sender, EventArgs e)
        {
            txtbTeacherID.Clear();
            txtbTeacherName.Clear();
            txtbTeacherSurnames.Clear();
            txtbTeacherPhone.Clear();
            txtbTeacherEmail.Clear();
            txtbTeacherPassword.Clear();
            txtbTeacherCourse.Clear();
            pos = -1;
            lblRecord.Text = "";
            ButtonsCheck();
        }

        private void btnTeacherSave_Click(object sender, EventArgs e)
        {
            // CHECKS THAT THE ACTUAL TEXT BOX ID TEXT IS NOT USED ALREADY IN THE DB
            if (!dbHandler.DuplicatedID(txtbTeacherID.Text, "Profesores"))
            {
                // CHECKS THAT THE ACTUAL TEXT BOX PHONE TEXT IS NOT USED ALREADY IN THE DB
                if (!dbHandler.DuplicatedPhone(txtbTeacherPhone.Text, "Profesores"))
                {
                    // CHECKS THAT THE ACTUAL TEXT BOX EMAIL TEXT IS NOT USED ALREADY IN THE DB
                    if (!dbHandler.DuplicatedEmail(txtbTeacherEmail.Text, "Profesores"))
                    {
                        // CREATES THE TEACHER TO SAVE
                        Teacher savedTeacher = Teacher.TeacherCreation(txtbTeacherID.Text,
                                                                       txtbTeacherName.Text,
                                                                       txtbTeacherSurnames.Text,
                                                                       txtbTeacherPhone.Text,
                                                                       txtbTeacherEmail.Text,
                                                                       txtbTeacherPassword.Text,
                                                                       txtbTeacherCourse.Text);

                        // IF THIS IDENTITY IS VALID IT WILL BE INSERTED INTO THE DB
                        if (savedTeacher != null)
                        {
                            // FUNCTION WHICH CREATES A NEW TEACHER INTO THE DB
                            // AFTER THAT UPDATES THE POSITION AND THE COUNT OF TEACHER'S RECORDS
                            dbHandler.AddNewIdentity(savedTeacher, "Profesores");
                            pos = dbHandler.TeachersQuantity - 1;
                            RecordPositionLabel(pos);
                            btnTeacherCancelAddRegistry.PerformClick();
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

        private void btnTeacherUpdate_Click(object sender, EventArgs e)
        {
            if (pos != -1 && changeDetected)
            {
                // SETS VARIABLES DATA TO CREATE A TEMPORAL NEW TEACHER
                string ID = txtbTeacherID.Text;
                string name = txtbTeacherName.Text;
                string surnames = txtbTeacherSurnames.Text;
                string phone = txtbTeacherPhone.Text;
                string email = txtbTeacherEmail.Text;
                string password = txtbTeacherPassword.Text;
                string course = txtbTeacherCourse.Text;

                // GETS THE SUPOSED DATA FROM AN IDENTITY IN THE ACTUAL POSITION 
                Identity oldIdentityData = dbHandler.GetIdentityType(pos, "Profesores");

                // CHECKS IF THE SELECTED IDENTITY IS A TEACHER AND CONVERTS THAT IDENTITY INTO A TEACHER TYPE TO ACCES TO ITS PROPERTIES
                if (oldIdentityData is Teacher oldTeacherData)
                {
                    // MAKES SURE THAT THE FOLLOWING ID-PHONE-MAIL IS NOT USED OR IF IT'S EXACTLY THE SAME BEFORE ANY CHANGE 
                    if (!dbHandler.DuplicatedID(ID, "Profesores") || ID == oldTeacherData.ID)
                    {
                        if (!dbHandler.DuplicatedPhone(phone, "Profesores") || phone == oldTeacherData.Phone)
                        {
                            if (!dbHandler.DuplicatedEmail(email, "Profesores") || email == oldTeacherData.Email)
                            {
                                // CREATES A NEW IDENTITY AS A TEACHER TYPE ONE
                                Identity selectedIdentityToUpdate = Teacher.TeacherCreation(ID, name, surnames, phone, email, password, course);
                                if (selectedIdentityToUpdate != null)
                                {
                                    dbHandler.UpdateIdentity(selectedIdentityToUpdate, pos, "Profesores");
                                    ShowTeacherRecords(pos);
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
                else if (dbHandler.TeachersQuantity == 0)
                {
                    MessageBox.Show("Updating without having atleast one teacher in the DB is meaningless, try again after adding a teacher to the DB.");
                }
                else
                {
                    MessageBox.Show(returnErrorInput());
                }
            }
        }

        private void btnTeacherDelete_Click(object sender, EventArgs e)
        { 
            if (dbHandler.TeachersQuantity > 0)
            {
                if (pos != -1)
                {
                    DialogResult delete;
                    delete = MessageBox.Show("Do you want to delete this record (Y/N)?", "Delete Record?", MessageBoxButtons.YesNo);

                    if (delete == DialogResult.Yes)
                    {
                        dbHandler.DeleteIdentity(pos, "Profesores");

                        // RESETS POSITION
                        pos = 0;
                        RecordPositionLabel(pos); // RELOADS THE POSITION LABEL
                        ShowTeacherRecords(pos);
                        ButtonsCheck();
                    }
                }
                else
                {
                    MessageBox.Show("Delete is not possible when no teacher is selected.");
                }
            }
            else if (dbHandler.TeachersQuantity == 0)
            {
                MessageBox.Show("Delete is not possible when no elements are in the database.");
            }
        }

        private void btnSearchTeacher_Click(object sender, EventArgs e)
        {
            if (dbHandler.TeachersQuantity > 1)
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
            else if (dbHandler.TeachersQuantity == 1)
            {
                Identity uniqueTeacher = dbHandler.GetIdentityType(0, "Profesores");
                MessageBox.Show("There's only one teacher so it's data will be the one showed.");
                MessageBox.Show(dbHandler.GetIdentityData(uniqueTeacher, 0, "Profesores"));
            }
            else
            {
                MessageBox.Show("Error, the list has no added teachers, add a teacher before checking a teacher data from the teacher list");
            }
        }

        private void btnSearchTeacherCourse_Click(object sender, EventArgs e)
        {
            if (dbHandler.TeachersQuantity > 1)
            {
                bool showed = false;
                do
                {
                    string teacherCourse = Interaction.InputBox("Introduce the teacher's course to show data (EXAMPLE: 1-DAW-N): ");

                    if (CustomRegex.RegexCourseCod(teacherCourse))
                    {
                        if (SimilarTeacherCourseCounter(teacherCourse) > 0)
                        {
                            SelectSimilarCourseTeachersToShow(teacherCourse);
                            showed = true;
                        }
                        else
                        {
                            MessageBox.Show("There isn't any teacher with the selected course, try again");
                            showed = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The course format is not correct, try again");
                    }

                } while (!showed);

            }
            else if (dbHandler.TeachersQuantity == 1)
            {
                Identity uniqueTeacher = dbHandler.GetIdentityType(0, "Profesores");
                MessageBox.Show("There's only one teacher so it's data will be the one showed.");
                MessageBox.Show(dbHandler.GetIdentityData(uniqueTeacher, 0, "Profesores"));
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
                                  "\nEMAIL: x@iesmarenostrum.com" +
                                  "\nPASSWORD: Sergio_Diez1" +
                                  "\nCOURSE: 2-DAW-N";
            return errorMessage;
        }

            /* ---------------- INPUT ERROR HANDLING END --------------------- */

        /* ---------------- TEXTBOX CHANGE HANDLING FUNCTIONS START --------------------- */

        public void ButtonsCheck()
        {
            bool recordsExist = (dbHandler.TeachersQuantity > 0);
            bool noRecordSelected = (pos == -1);

            // ENABLE/DISABLE NAVIGATION BUTTONS
            btnTeacherNext.Enabled = (recordsExist && pos < dbHandler.TeachersQuantity - 1) && !noRecordSelected;
            btnTeacherPrevious.Enabled = (recordsExist && pos > 0) && !noRecordSelected;
            btnTeacherLast.Enabled = (recordsExist && pos < dbHandler.TeachersQuantity - 1) && !noRecordSelected;
            btnTeacherFirst.Enabled = (recordsExist && pos > 0) && !noRecordSelected;

            // ENABLE/DISABLE SAVE BUTTON IF NO RECORD IS SELECTED
            btnTeacherSave.Enabled = noRecordSelected;

            // ENABLE/DISABLE CANCEL ADD REGISTRY BUTTON IF NO RECORD IS SELECTED
            btnTeacherCancelAddRegistry.Enabled = noRecordSelected && recordsExist;

            // ENABLE/DISABLE DELETE AND UPDATE BUTTONS IF A RECORD IS SELECTED
            btnTeacherDelete.Enabled = recordsExist && !noRecordSelected;
            btnTeacherUpdate.Enabled = recordsExist && !noRecordSelected && changeDetected;

            // ENABLE/DISABLE OTHER BUTTONS BASED ON RECORD EXISTENCE
            btnTeacherClear.Enabled = recordsExist && !noRecordSelected;
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
            Identity actualIdentity = dbHandler.GetIdentityType(pos, "Profesores");
            if (actualIdentity is Teacher actualTeacher)
            {
                string originalID = actualTeacher.ID;
                UpdateChangeDetected(txtbTeacherID.Text, originalID);
            }
        }

        private void txtbName_TextChanged(object sender, EventArgs e)
        {
            Identity actualIdentity = dbHandler.GetIdentityType(pos, "Profesores");
            if (actualIdentity is Teacher actualTeacher)
            {
                string originalName = actualTeacher.Name;
                UpdateChangeDetected(txtbTeacherName.Text, originalName);
            }
        }

        private void txtbSurnames_TextChanged(object sender, EventArgs e)
        {
            Identity actualIdentity = dbHandler.GetIdentityType(pos, "Profesores");
            if (actualIdentity is Teacher actualTeacher)
            {
                string originalSurnames = actualTeacher.Surnames;
                UpdateChangeDetected(txtbTeacherSurnames.Text, originalSurnames);
            }
        }

        private void txtbPhone_TextChanged(object sender, EventArgs e)
        {
            Identity actualIdentity = dbHandler.GetIdentityType(pos, "Profesores");
            if (actualIdentity is Teacher actualTeacher)
            {
                string originalPhone = actualTeacher.Phone;
                UpdateChangeDetected(txtbTeacherPhone.Text, originalPhone);
            }
        }

        private void txtbEmail_TextChanged(object sender, EventArgs e)
        {
            Identity actualIdentity = dbHandler.GetIdentityType(pos, "Profesores");
            if (actualIdentity is Teacher actualTeacher)
            {
                string originalEmail = actualTeacher.Email;
                UpdateChangeDetected(txtbTeacherEmail.Text, originalEmail);
            }
        }

        private void txtbTeacherPassword_TextChanged(object sender, EventArgs e)
        {
            Identity actualIdentity = dbHandler.GetIdentityType(pos, "Profesores");
            if (actualIdentity is Teacher actualTeacher)
            {
                string originalPassword = actualTeacher.Password;
                UpdateChangeDetected(txtbTeacherPassword.Text, originalPassword);
            }
        }

        private void txtbTeacherCourse_TextChanged(object sender, EventArgs e)
        {
            Identity actualIdentity = dbHandler.GetIdentityType(pos, "Profesores");
            if (actualIdentity is Teacher actualTeacher)
            {
                string originalCourse = actualTeacher.CourseCod;
                UpdateChangeDetected(txtbTeacherCourse.Text, originalCourse);
            }
        }


        /* ---------------- TEXTBOX CHANGE HANDLING FUNCTIONS END --------------------- */
    }
}
