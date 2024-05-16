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

namespace Exercise_4.Views.Admin
{
    public partial class fCourseManagement : Form
    {
        public fCourseManagement()
        {
            InitializeComponent();
        }

        // CALLING SQLBDHANDLER TO MANAGE DB FUNCTIONS
        SqlDBHandler dbHandler;

        // FORM LOADING HANDLING
        private void fCourseManagement_Load(object sender, EventArgs e)
        {
            dbHandler = new SqlDBHandler();
            // SETS FIRST POSITION, UPDATES THE VISUALS AND CHECKS THE ACTUAL BUTTONS STATUS WHEN FIRST LOADED
            pos = 0;
            RecordPositionLabel(pos);
            ShowCoursesRecords(pos);
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
            if (dbHandler.CoursesQuantity > 0)
            {
                lblRecord.Text = "Record Nº" + (pos + 1) + " of " + dbHandler.CoursesQuantity;
            }
            else if (dbHandler.CoursesQuantity == 0)
            {
                lblRecord.Text = "";
            }
        }

        /* ---------------- POSITION HANDLING END --------------------- */


        // FUNCTION WHICH UPDATES THE VISUAL PART OF THE FORM
        private void ShowCoursesRecords(int pos)
        {
            if (dbHandler.CoursesQuantity > 0)
            {
                Identity selectedIdentityRecords = dbHandler.GetIdentityType(pos, "Cursos");
                if (selectedIdentityRecords is Course selectedCourseRecords)
                {
                    // TAKE VALUES FROM EACH RECORD'S COLUMNS TO SET THEM IN THE APPROPIATE TEXTBOX
                    txtbCourseID.Text = selectedCourseRecords.ID;
                    txtbCourseName.Text = selectedCourseRecords.Name;

                    // DETECTED CHANGES RESET AND CHECKS THE ACTUAL BUTTONS STATUS
                    changeDetected = false;
                    ButtonsCheck();
                }
            }
            else if (dbHandler.CoursesQuantity == 0)
            {
                // CLEAR EVERY DATA FROM THE TEXT BOXES AND CHECKS THE ACTUAL BUTTONS STATUS
                btnCourseClear.PerformClick();
                ButtonsCheck();
            }
        }

        public string ShowsCoursesList()
        {
            string result = "";
            if (dbHandler.CoursesQuantity != 0)
            {
                string courseListTxt = "List of courses: \n\n";

                if (dbHandler.CoursesQuantity > 1)
                {
                    DataTable coursesTable = dbHandler.ImportSelectedDataTable("Cursos");

                    foreach (DataRow row in coursesTable.Rows)
                    {
                        string courseInfo = "ID: " + row["Codigo"] + "\n" +
                                            "Name: " + row["Nombre"] + "\n";

                        courseListTxt += courseInfo + "\n";
                    }
                    result = courseListTxt;
                }
                else if (dbHandler.CoursesQuantity == 1)
                {
                    Identity singleCourse = dbHandler.GetIdentityType(0, "Cursos");
                    courseListTxt = dbHandler.GetIdentityData(singleCourse, 0, "Cursos");
                    result = courseListTxt;
                }
            }
            else
            {
                result = "No courses added in the DB.";
            }
            return result;
        }

        public int SimilarCourseIDCounter(string courseID)
        {
            int counter = 0;
            if (dbHandler.CoursesQuantity != 0)
            {
                for (int i = 0; i < dbHandler.CoursesQuantity; i++)
                {
                    DataRow courseRow = dbHandler.ImportSelectedDataTable("Cursos").Rows[i];
                    string stringToCheck = courseRow[0].ToString().ToLower();
                    if (stringToCheck.Contains(courseID.ToLower()))
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        public void SelectSimilarIDCourseToShow(string courseID)
        {
            List<string> matchingCoursesID = new List<string>();
            List<string> extraCoursesInfo = new List<string>();
            List<int> coursesPositions = new List<int>();

            if (dbHandler.CoursesQuantity != 0)
            {
                for (int i = 0; i < dbHandler.CoursesQuantity; i++)
                {
                    DataRow courseRow = dbHandler.ImportSelectedDataTable("Cursos").Rows[i];
                    string stringToCheck = courseRow[0].ToString().ToLower();
                    if (stringToCheck.Contains(courseID.ToLower()))
                    {
                        string fullName = (courseRow["Nombre"]).ToString();
                        matchingCoursesID.Add(fullName);

                        string extraCourseInfo = "ID: " + courseRow["Codigo"] + "\n" +
                                                 "Name: " + courseRow["Nombre"] + "\n";

                        extraCoursesInfo.Add(extraCourseInfo);
                        coursesPositions.Add(i);
                    }
                }

            }
            if (matchingCoursesID.Count == 1)
            {
                MessageBox.Show("The only course data is: " + extraCoursesInfo[0] + "\n\n");
                pos = coursesPositions[0];
                ShowCoursesRecords(pos);
                RecordPositionLabel(pos);
            }
            else if (matchingCoursesID.Count > 1)
            {
                bool showed = false;
                int selectedCourseIndex = 0;

                while (!showed)
                {
                    StringBuilder infoMessage = new StringBuilder("Courses with similar ID:\n\n");

                    for (int i = 0; i < matchingCoursesID.Count; i++)
                    {
                        infoMessage.AppendLine((i + 1) + ") " + matchingCoursesID[i] + "\n");
                    }

                    infoMessage.AppendLine("Select the number of the course to view more data:");

                    string userInput = Interaction.InputBox(infoMessage.ToString());

                    if (int.TryParse(userInput, out selectedCourseIndex) && selectedCourseIndex > 0 && selectedCourseIndex <= matchingCoursesID.Count)
                    {
                        string selectedCourseInfo = extraCoursesInfo[selectedCourseIndex - 1];
                        int selectedCoursePositionInDB = coursesPositions[selectedCourseIndex - 1];

                        DialogResult result = MessageBox.Show(selectedCourseInfo + "\n\nIs this the course you want to check info?", "Check Course Info", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            pos = selectedCoursePositionInDB;
                            ShowCoursesRecords(pos);
                            RecordPositionLabel(pos);
                            showed = true;
                        }
                        else
                        {
                            MessageBox.Show("Please select a different course.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid number corresponding to a course.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No courses found with the selected id.");
            }
        }


        /* ---------------- BUTTONS HANDLING START --------------------- */

        private bool CheckValuesChanged()
        {
            return dbHandler.CheckChangesStoredAndActualValues(pos, txtbCourseID.Text, txtbCourseName.Text, "Cursos");
        }

        private void askToUpdateIfChangesWereMade(bool choice)
        {
            if (!choice)
            {
                DialogResult update = MessageBox.Show("Do you want to keep changes of this record (Y/N)?", "Keep Changes?", MessageBoxButtons.YesNo);

                if (update == DialogResult.Yes)
                {
                    btnCourseUpdate.PerformClick();
                }
            }
        }

        private void btnCourseCancelAddRegistry_Click(object sender, EventArgs e)
        {
            pos = 0;
            ShowCoursesRecords(pos);
            RecordPositionLabel(pos);
        }

        private void btnCourseFirst_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                pos = 0;
                RecordPositionLabel(pos);
                ShowCoursesRecords(pos);
            }
            else
            {
                bool possiblyChangedValues = CheckValuesChanged();

                if (possiblyChangedValues && (pos == -1))
                {
                    pos = 0;
                    RecordPositionLabel(pos);
                    ShowCoursesRecords(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos = 0;
                    RecordPositionLabel(pos);
                    ShowCoursesRecords(pos);
                }
            }
        }

        private void btnCourseLast_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                pos = dbHandler.CoursesQuantity - 1;
                RecordPositionLabel(pos);
                ShowCoursesRecords(pos);
            }
            else
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (pos == -1))
                {
                    pos = dbHandler.CoursesQuantity - 1;
                    RecordPositionLabel(pos);
                    ShowCoursesRecords(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos = dbHandler.CoursesQuantity - 1;
                    RecordPositionLabel(pos);
                    ShowCoursesRecords(pos);
                }
            }
        }

        private void btnCourseNext_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                btnCourseFirst.PerformClick();
            }
            else if (pos <= (dbHandler.CoursesQuantity - 1))
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (pos == -1))
                {
                    pos++;
                    RecordPositionLabel(pos);
                    ShowCoursesRecords(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos++;
                    RecordPositionLabel(pos);
                    ShowCoursesRecords(pos);
                }
            }
        }

        private void btnCoursePrevious_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                btnCourseFirst.PerformClick();
            }
            else if (pos > 0)
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (pos == -1))
                {
                    pos--;
                    RecordPositionLabel(pos);
                    ShowCoursesRecords(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos--;
                    RecordPositionLabel(pos);
                    ShowCoursesRecords(pos);
                }
            }
        }

        private void btnCourseClear_Click(object sender, EventArgs e)
        {
            txtbCourseID.Clear();
            txtbCourseName.Clear();
            pos = -1;
            lblRecord.Text = "";
            ButtonsCheck();
        }

        private void btnCourseSave_Click(object sender, EventArgs e)
        {
            // CHECKS THAT THE ACTUAL TEXT BOX ID TEXT IS NOT USED ALREADY IN THE DB
            if (!dbHandler.DuplicatedID(txtbCourseID.Text, "Cursos"))
            {
                // CREATES THE COURSE TO SAVE
                Course savedCourse = Course.CourseCreation(txtbCourseID.Text,
                                                           txtbCourseName.Text);

                // IF THIS ALUMN IS VALID IT WILL BE INSERTED INTO THE DB
                if (savedCourse != null)
                {
                    // FUNCTION WHICH CREATES A NEW ALUMN INTO THE DB
                    // AFTER THAT UPDATES THE POSITION AND THE COUNT OF COURSE'S RECORDS
                    dbHandler.AddNewIdentity(savedCourse, "Cursos");
                    pos = dbHandler.CoursesQuantity - 1;
                    RecordPositionLabel(pos);
                    btnCourseCancelAddRegistry.PerformClick();
                    ButtonsCheck();
                }
                else
                {
                    MessageBox.Show(returnErrorInput());
                }
            }
            else
            {
                MessageBox.Show("This ID is already used, try another one");
            }
        }

        private void btnCourseUpdate_Click(object sender, EventArgs e)
        {
            if (pos != -1 && changeDetected)
            {
                // SETS VARIABLES DATA TO CREATE A TEMPORAL NEW COURSE
                string ID = txtbCourseID.Text;
                string name = txtbCourseName.Text;

                // GETS THE SUPOSED DATA FROM A COURSE IN THE ACTUAL POSITION 
                Identity oldIdentityData = dbHandler.GetIdentityType(pos, "Cursos");

                // CHECKS IF THE SELECTED IDENTITY IS A COURSE AND CONVERTS THAT IDENTITY INTO AN COURSE TYPE TO ACCES TO ITS PROPERTIES
                if (oldIdentityData is Course oldCourseData)
                {
                    // MAKES SURE THAT THE FOLLOWING ID IS NOT USED OR IF IT'S EXACTLY THE SAME BEFORE ANY CHANGE 
                    if (!dbHandler.DuplicatedID(ID, "Cursos") || ID == oldCourseData.ID)
                    {
                        // CREATES A NEW COURSE AS AN COURSE TYPE ONE
                        Identity selectedIdentityToUpdate = Course.CourseCreation(ID, name);
                        if (selectedIdentityToUpdate != null)
                        {
                            dbHandler.UpdateIdentity(selectedIdentityToUpdate, pos, "Cursos");
                            ShowCoursesRecords(pos);
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
                        MessageBox.Show("This ID is already used, try another one");
                    }

                }
                else if (dbHandler.CoursesQuantity == 0)
                {
                    MessageBox.Show("Updating without having atleast one alumn in the DB is meaningless, try again after adding an alumn to the DB.");
                }
                else
                {
                    MessageBox.Show(returnErrorInput());
                }
            }
        }

        private void btnCourseDelete_Click(object sender, EventArgs e)
        {
            if (dbHandler.CoursesQuantity > 0)
            {
                if (pos != -1)
                {
                    DialogResult delete;
                    delete = MessageBox.Show("Do you want to delete this record (Y/N)?", "Delete Record?", MessageBoxButtons.YesNo);

                    if (delete == DialogResult.Yes)
                    {
                        dbHandler.DeleteIdentity(pos, "Cursos");

                        // RESETS POSITION
                        pos = 0;
                        RecordPositionLabel(pos);
                        ShowCoursesRecords(pos);
                        ButtonsCheck();
                    }
                }
                else
                {
                    MessageBox.Show("Delete is not possible when no course is selected.");
                }
            }
            else if (dbHandler.CoursesQuantity == 0)
            {
                MessageBox.Show("Delete is not possible when no elements are in the database.");
            }
        }

        private void btnSearchCourse_Click(object sender, EventArgs e)
        {
            if (dbHandler.CoursesQuantity > 1)
            {
                bool showed = false;
                do
                {
                string courseID = Interaction.InputBox("Introduce the course's ID to show data (EXAMPLE: 1-DAW-N): ");

                    if (SimilarCourseIDCounter(courseID) > 0)
                    {
                        SelectSimilarIDCourseToShow(courseID);
                        showed = true;
                    }
                    else
                    {
                        MessageBox.Show("There isn't any course with the selected ID, try again");
                        showed = true;
                    }
                } while (!showed);

            }
            else if (dbHandler.CoursesQuantity == 1)
            {
                Identity uniqueCourse = dbHandler.GetIdentityType(0, "Cursos");
                MessageBox.Show("There's only one course so it's data will be the one showed.");
                MessageBox.Show(dbHandler.GetIdentityData(uniqueCourse, 0, "Cursos"));
            }
            else
            {
                MessageBox.Show("Error, the list has no added alumns, add an alumn before checking an alumn data from the alumns list");
            }
        }

        private void btnListCourses_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ShowsCoursesList());
        }

        /* ---------------- BUTTONS HANDLING END --------------------- */

        /* ---------------- INPUT ERROR HANDLING START --------------------- */

        // ERROR STRING IF INPUT IS INVALID
        private string returnErrorInput()
        {
            string errorMessage = "Error, not valid data, try again. " +
                                  "\n\nEXAMPLE:" +
                                  "\nID: 1-DAW-N / 2-DAM-N" +
                                  "\nNAME: Desarrollo de Aplicaciones Web\n";
            return errorMessage;
        }

        /* ---------------- INPUT ERROR HANDLING END --------------------- */

        /* ---------------- TEXTBOX CHANGE HANDLING FUNCTIONS START --------------------- */

        public void ButtonsCheck()
        {
            bool recordsExist = (dbHandler.CoursesQuantity > 0);
            bool noRecordSelected = (pos == -1);

            // ENABLE/DISABLE NAVIGATION BUTTONS
            btnCourseNext.Enabled = (recordsExist && pos < dbHandler.CoursesQuantity - 1) && !noRecordSelected;
            btnCoursePrevious.Enabled = (recordsExist && pos > 0) && !noRecordSelected;
            btnCourseLast.Enabled = (recordsExist && pos < dbHandler.CoursesQuantity - 1) && !noRecordSelected;
            btnCourseFirst.Enabled = (recordsExist && pos > 0) && !noRecordSelected;

            // ENABLE/DISABLE SAVE BUTTON IF NO RECORD IS SELECTED
            btnCourseSave.Enabled = noRecordSelected;

            // ENABLE/DISABLE CANCEL ADD REGISTRY BUTTON IF NO RECORD IS SELECTED
            btnCourseCancelAddRegistry.Enabled = noRecordSelected && recordsExist;

            // ENABLE/DISABLE DELETE AND UPDATE BUTTONS IF A RECORD IS SELECTED
            btnCourseDelete.Enabled = recordsExist && !noRecordSelected;
            btnCourseUpdate.Enabled = recordsExist && !noRecordSelected && changeDetected;

            // ENABLE/DISABLE OTHER BUTTONS BASED ON RECORD EXISTENCE
            btnCourseClear.Enabled = recordsExist && !noRecordSelected;
            btnListCourses.Enabled = recordsExist;
            btnSearchCourse.Enabled = recordsExist;
            btnSearchCourse.Enabled = recordsExist;
        }

        // THIS FUNCTION AUTO CHECKS THE CHANGES DETECTED IN THE FOLLOWING TEXT BOXES BETWEEN THE ORIGINAL STRING AND THE NEW CHANGED
        private void UpdateChangeDetected(string currentValue, string originalValue)
        {
            bool anyChangeDetected = (currentValue != originalValue);
            changeDetected = anyChangeDetected;
            ButtonsCheck();
        }

        private void txtbCourseID_TextChanged(object sender, EventArgs e)
        {
            Identity actualIdentity = dbHandler.GetIdentityType(pos, "Cursos");
            if (actualIdentity is Course actualCourse)
            {
                string originalID = actualCourse.ID;
                UpdateChangeDetected(txtbCourseID.Text, originalID);
            }
        }

        private void txtbCourseName_TextChanged(object sender, EventArgs e)
        {
            Identity actualIdentity = dbHandler.GetIdentityType(pos, "Cursos");
            if (actualIdentity is Course actualCourse)
            {
                string originalName = actualCourse.Name;
                UpdateChangeDetected(txtbCourseName.Text, originalName);
            }
        }
    }
}