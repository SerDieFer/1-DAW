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

        // arreglar botones clear y al buscar curso/apellido no sale el correcto
        // CREACION Y BORRADO VAN MAL

        // FORM LOADING HANDLING
        private void fCourseManagement_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'highschoolDataSet.Cursos' Puede moverla o quitarla según sea necesario.
            this.cursosAdminTableAdapter.Fill(this.highschoolDataSet.Cursos);

            cursosAdminBindingSource.DataSource = this.highschoolDataSet.Cursos;

            cursosAdminBindingSource.Position = 0;

            RecordPositionLabel();
            ShowCoursesRecords();
            ButtonsCheck();
        }

        // THESE ARE FOR DETECTING STRING CHANGES IN THE TEXT BOXES SINCE AN ORIGINAL
        // IS REQUIRED TO CHECK BETWEEN THAT ONE AND THE USER CHANGED INPUT
        private bool changeDetected = false;

        /* ---------------- POSITION HANDLING START --------------------- */

        // SETS THE POSITION OF THE ACTUAL RECORD INTO A TEXT LABEL
        private void RecordPositionLabel()
        {
            int actualPos = cursosAdminBindingSource.Position;
            int courseCount = cursosAdminBindingSource.Count;

            if (courseCount > 0)
            {
                lblRecord.Text = "Record Nº" + (actualPos + 1) + " of " + courseCount;
            }
            else if (courseCount == 0)
            {
                lblRecord.Text = "";
            }
        }

        /* ---------------- POSITION HANDLING END --------------------- */


        // FUNCTION WHICH UPDATES THE VISUAL PART OF THE FORM
        private void ShowCoursesRecords()
        {
            int courseCount = cursosAdminBindingSource.Count;

            if (courseCount > 0)
            {
                // DETECTED CHANGES RESET AND CHECKS THE ACTUAL BUTTONS STATUS
                changeDetected = false;
            }
            else if (courseCount == 0)
            {
                // CLEAR EVERY DATA FROM THE TEXT BOXES AND CHECKS THE ACTUAL BUTTONS STATUS
                btnCourseClear.PerformClick();
            }

            ButtonsCheck();
        }

        public string ShowsCoursesList()
        {
            int courseCount = cursosAdminBindingSource.Count;
            string result = "";

            if (courseCount == 0)
            {
                result = "No courses added in the DB.";
            }

            StringBuilder courseListTxt = new StringBuilder("List of courses: \n\n");

            for (int i = 0; i < courseCount; i++)
            {
                cursosAdminBindingSource.Position = i;
                DataRowView currentRowView = (DataRowView)cursosAdminBindingSource.Current;
                DataRow row = currentRowView.Row;

                string courseInfo = "Course: " + row["Codigo"] + "\n" +
                                    "Name: " + row["Nombre"] + "\n";

                courseListTxt.Append(courseInfo);
                result = courseListTxt.ToString();
            }

            // RESET ORIGINAL POSITION
            cursosAdminBindingSource.Position = 0;

            return result;
        }

        public int SimilarCourseIDCounter(string courseID)
        {
            int counter = 0;
            foreach (DataRowView courseRowView in cursosAdminBindingSource)
            {
                DataRow courseRow = courseRowView.Row;
                string stringToCheck = courseRow["Codigo"].ToString().ToLower();
                if (stringToCheck.Contains(courseID.ToLower()))
                {
                    counter++;
                }
            }
            return counter;
        }

        public void SelectSimilarIDCourseToShow(string courseID)
        {
            List<string> matchingCoursesID = new List<string>();
            List<string> extraCoursesInfo = new List<string>();
            List<int> coursesPositions = new List<int>();

            foreach (DataRowView courseRowView in cursosAdminBindingSource)
            {
                DataRow courseRow = courseRowView.Row;
                string stringToCheck = courseRow["Codigo"].ToString().ToLower();
                if (stringToCheck.Contains(courseID.ToLower()))
                {
                    string fullCourse = (courseRow["Nombre"] + " course is " + courseRow["Codigo"]).ToString();
                    matchingCoursesID.Add(fullCourse);

                    string extraCourseInfo = "Course: " + courseRow["Codigo"] + "\n" +
                                             "Name: " + courseRow["Nombre"] + "\n";

                    extraCoursesInfo.Add(extraCourseInfo);
                    coursesPositions.Add(cursosAdminBindingSource.IndexOf(courseRowView));
                }
            }
            if (matchingCoursesID.Count == 1)
            {
                MessageBox.Show("The only course data is: " + extraCoursesInfo[0] + "\n\n");
                cursosAdminBindingSource.Position = coursesPositions[0];
                ShowCoursesRecords();
                RecordPositionLabel();
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
                            cursosAdminBindingSource.Position = coursesPositions[0];
                            ShowCoursesRecords();
                            RecordPositionLabel();
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
            bool changesDetected = false;

            DataRowView currentRowView = (DataRowView)cursosAdminBindingSource.Current;

            if (currentRowView != null)
            {
                DataRow currentRow = currentRowView.Row;

                // CHECK THE ACTUAL DATA IN THE TEXT BOXES
                string id = txtbCourseID.Text;
                string name = txtbCourseName.Text;


                // CHECK THIS DATA WITH THE ONE STORED IN THE DATASET IN THAT POSITION
                if (id != currentRow["Codigo"].ToString() ||
                    name != currentRow["Nombre"].ToString())
                {
                    changesDetected = true;
                }
            }
            return changesDetected;
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
            cursosAdminBindingSource.Position = 0;
            ShowCoursesRecords();
            RecordPositionLabel();
        }

        private void btnCourseFirst_Click(object sender, EventArgs e)
        {
            int actualPos = cursosAdminBindingSource.Position;

            if (actualPos < 0)
            {
                // RESET ORIGINAL POSITION
                cursosAdminBindingSource.Position = 0;

                RecordPositionLabel();
                ShowCoursesRecords();
            }
            else
            {
                bool possiblyChangedValues = CheckValuesChanged();

                if (possiblyChangedValues && (actualPos < 0))
                {
                    // RESET ORIGINAL POSITION
                    cursosAdminBindingSource.Position = 0;

                    RecordPositionLabel();
                    ShowCoursesRecords();
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);

                    // RESET ORIGINAL POSITION
                    cursosAdminBindingSource.Position = 0;

                    RecordPositionLabel();
                    ShowCoursesRecords();
                }
            }
        }

        private void btnCourseLast_Click(object sender, EventArgs e)
        {
            int actualPos = cursosAdminBindingSource.Position;
            int courseCount = cursosAdminBindingSource.Count;

            if (actualPos < 0)
            {
                cursosAdminBindingSource.Position = courseCount - 1;
                RecordPositionLabel();
                ShowCoursesRecords();
            }
            else
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (actualPos < 0))
                {
                    cursosAdminBindingSource.Position = courseCount - 1;
                    RecordPositionLabel();
                    ShowCoursesRecords();
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);

                    cursosAdminBindingSource.Position = courseCount - 1;

                    RecordPositionLabel();
                    ShowCoursesRecords();
                }
            }
        }

        private void btnCourseNext_Click(object sender, EventArgs e)
        {
            int actualPos = cursosAdminBindingSource.Position;
            int coursesCount = cursosAdminBindingSource.Count;

            if (actualPos < 0)
            {
                cursosAdminBindingSource.MoveFirst();
            }
            else if (actualPos <= (coursesCount - 1))
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (actualPos < 0))
                {

                    cursosAdminBindingSource.MoveNext();

                    RecordPositionLabel();
                    ShowCoursesRecords();
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);

                    cursosAdminBindingSource.MoveNext();

                    RecordPositionLabel();
                    ShowCoursesRecords();
                }
            }
        }

        private void btnCoursePrevious_Click(object sender, EventArgs e)
        {
            int actualPos = cursosAdminBindingSource.Position;
            int courseCount = cursosAdminBindingSource.Count;

            if (actualPos < 0)
            {
                cursosAdminBindingSource.MoveFirst();
            }
            else if (actualPos <= (courseCount - 1))
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (actualPos < 0))
                {

                    cursosAdminBindingSource.MovePrevious();

                    RecordPositionLabel();
                    ShowCoursesRecords();
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);

                    cursosAdminBindingSource.MovePrevious();

                    RecordPositionLabel();
                    ShowCoursesRecords();
                }
            }
        }

        private void btnCourseClear_Click(object sender, EventArgs e)
        {
            txtbCourseID.Clear();
            txtbCourseName.Clear();
            cursosAdminBindingSource.Position = -1;
            lblRecord.Text = "";
            ButtonsCheck();
        }

        private void btnCourseSave_Click(object sender, EventArgs e)
        {
            cursosAdminBindingSource.AddNew();

            // CHECKS THAT THE ACTUAL TEXT BOX ID TEXT IS NOT USED ALREADY IN THE DB
            if (!BindingResources.DuplicatedID(txtbCourseID.Text, cursosAdminBindingSource))
            {
                // CREATES THE ALUMN TO SAVE
                Course savedCourse = Course.CourseCreation(txtbCourseID.Text,
                                                           txtbCourseName.Text);

                // IF THIS ALUMN IS VALID IT WILL BE INSERTED INTO THE DB
                if (savedCourse != null)
                {
                    // FUNCTION WHICH CREATES A NEW ALUMN INTO THE DB
                    // AFTER THAT UPDATES THE POSITION AND THE COUNT OF ALUMN'S RECORDS

                    cursosAdminBindingSource.Add(savedCourse);

                    RecordPositionLabel();

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
            int courseCount = cursosAdminBindingSource.Count;

            if (cursosAdminBindingSource.Current != null && changeDetected)
            {
                DataRowView currentRow = cursosAdminBindingSource.Current as DataRowView;

                string ID = txtbCourseID.Text;
                string name = txtbCourseName.Text;

                if (!BindingResources.DuplicatedID(ID, cursosAdminBindingSource) || ID == currentRow["Codigo"].ToString())
                {
                        // UPDATE RECORDS IN THE BINDING SOURCE
                        currentRow["Codigo"] = ID;
                        currentRow["Nombre"] = name;

                        // SAVE CHANGES
                        cursosAdminBindingSource.EndEdit();
                        changeDetected = false;
                        MessageBox.Show("Teacher updated successfully!");
                }
                else
                {
                    MessageBox.Show("This ID is already used, try another one");
                }
            }
            else if (courseCount == 0)
            {
                MessageBox.Show("Updating without having atleast one course in the DB is meaningless, try again after adding a course to the DB.");
            }
            else
            {
                MessageBox.Show(returnErrorInput());
            }
        }
    

        private void btnCourseDelete_Click(object sender, EventArgs e)
        {
            int courseCount = cursosAdminBindingSource.Count;

            if (courseCount >= 0)
            {
                DialogResult deleteConfirmation = MessageBox.Show("Do you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo);

                if (deleteConfirmation == DialogResult.Yes)
                {
                    cursosAdminBindingSource.RemoveCurrent();

                    MessageBox.Show("Record deleted successfully!");
                }
            }
            else
            {
                MessageBox.Show("There are no records to delete.");
            }
        }

        private void btnSearchCourse_Click(object sender, EventArgs e)
        {
            int courseCount = cursosAdminBindingSource.Count;
            if (courseCount > 1)
            {
                bool showed = false;
                do
                {
                    string courseID = Interaction.InputBox("Introduce the course's ID to show data (ONLY LETTERS): ");

                    if (CustomRegex.RegexCourseCod(courseID))
                    {
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
                    }
                    else
                    {
                        MessageBox.Show("The ID format is not correct, try again");
                    }

                } while (!showed);

            }
            else if (courseCount == 1)
            {
                BindingResources.ShowIdentityData(cursosAdminBindingSource);
            }
            else
            {
                MessageBox.Show("Error, the list has no added courses, add a course before checking a course data from the courses list");
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
            int courseCount = cursosAdminBindingSource.Count;
            int coursePosition = cursosAdminBindingSource.Position;

            bool recordsExist = (courseCount > 0);
            bool noRecordSelected = (coursePosition == -1);

            // ENABLE/DISABLE NAVIGATION BUTTONS
            btnCourseNext.Enabled = (recordsExist && coursePosition < courseCount - 1) && !noRecordSelected;
            btnCoursePrevious.Enabled = (recordsExist && coursePosition > 0) && !noRecordSelected;
            btnCourseLast.Enabled = (recordsExist && coursePosition < courseCount - 1) && !noRecordSelected;
            btnCourseFirst.Enabled = (recordsExist && coursePosition > 0) && !noRecordSelected;

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
        private bool UpdateChangeDetected()
        {
            bool changeDetected = false;
            Course actualCourse = cursosAdminBindingSource.Current as Course;
            if (actualCourse != null)
            {
                changeDetected = (txtbCourseID.Text != actualCourse.ID ||
                                  txtbCourseName.Text != actualCourse.Name);
                ButtonsCheck();
            }
            return changeDetected;
        }

        private void txtbCourseID_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected();
        }

        private void txtbCourseName_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected();
        }
    }
}