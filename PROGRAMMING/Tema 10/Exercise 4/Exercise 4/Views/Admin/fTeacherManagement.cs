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

        // arreglar botones clear y al buscar curso/apellido no sale el correcto
        // CREACION Y BORRADO VAN MAL

        // FORM LOADING HANDLING
        private void fTeacherManagement_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'highschoolDataSet.Profesores' Puede moverla o quitarla según sea necesario.
            this.profesoresAdminTableAdapter.Fill(this.highschoolDataSet.Profesores);

            profesoresAdminBindingSource.DataSource = this.highschoolDataSet.Profesores;

            profesoresAdminBindingSource.Position = 0;

            RecordPositionLabel();
            ShowTeacherRecords();
            ButtonsCheck();
        }

        // THESE ARE FOR DETECTING STRING CHANGES IN THE TEXT BOXES SINCE AN ORIGINAL
        // IS REQUIRED TO CHECK BETWEEN THAT ONE AND THE USER CHANGED INPUT
        private bool changeDetected = false;

        /* ---------------- POSITION HANDLING START --------------------- */

        // SETS THE POSITION OF THE ACTUAL RECORD INTO A TEXT LABEL
        private void RecordPositionLabel()
        {
            int actualPos = profesoresAdminBindingSource.Position;
            int teacherCount = profesoresAdminBindingSource.Count;

            if (teacherCount > 0)
            {
                lblRecord.Text = "Record Nº" + (actualPos + 1) + " of " + teacherCount;
            }
            else if (teacherCount == 0)
            {
                lblRecord.Text = "";
            }
        }

        /* ---------------- POSITION HANDLING END --------------------- */


        // FUNCTION WHICH UPDATES THE VISUAL PART OF THE FORM
        private void ShowTeacherRecords()
        {
            int alumnCount = profesoresAdminBindingSource.Count;

            if (alumnCount > 0)
            {
                // DETECTED CHANGES RESET AND CHECKS THE ACTUAL BUTTONS STATUS
                changeDetected = false;
            }
            else if (alumnCount == 0)
            {
                // CLEAR EVERY DATA FROM THE TEXT BOXES AND CHECKS THE ACTUAL BUTTONS STATUS
                btnTeacherClear.PerformClick();
            }

            ButtonsCheck();
        }

        public string ShowsTeachersList()
        {
            int teacherCount = profesoresAdminBindingSource.Count;
            string result = "";

            if (teacherCount == 0)
            {
                result = "No teachers added in the DB.";
            }

            StringBuilder teacherListTxt = new StringBuilder("List of teachers: \n\n");

            for (int i = 0; i < teacherCount; i++)
            {
                profesoresAdminBindingSource.Position = i;
                DataRowView currentRowView = (DataRowView)profesoresAdminBindingSource.Current;
                DataRow row = currentRowView.Row;

                string teacherInfo = "ID: " + row["DNI"] + "\n" +
                                     "Name: " + row["Nombre"] + "\n" +
                                     "Surnames: " + row["Apellido"] + "\n" +
                                     "Phone: " + row["Tlf"] + "\n" +
                                     "Email: " + row["Email"] + "\n" +
                                     "Course: " + row["Codigo"] + "\n\n";

                teacherListTxt.Append(teacherInfo);
                result = teacherListTxt.ToString();
            }

            // RESET ORIGINAL POSITION
            profesoresAdminBindingSource.Position = 0;

            return result;
        }

        public int SimilarTeacherSurnamesCounter(string teacherSurname)
        {
            int counter = 0;
            foreach (DataRowView teacherRowView in profesoresAdminBindingSource)
            {
                DataRow teacherRow = teacherRowView.Row;
                string stringToCheck = teacherRow["Apellido"].ToString().ToLower();
                if (stringToCheck.Contains(teacherSurname.ToLower()))
                {
                    counter++;
                }
            }
            return counter;
        }

        public int SimilarTeacherCourseCounter(string teacherCourse)
        {
            int counter = 0;
            foreach (DataRowView teacherRowView in profesoresAdminBindingSource)
            {
                DataRow teacherRow = teacherRowView.Row;
                string stringToCheck = teacherRow["Codigo"].ToString().ToLower();
                if (stringToCheck.Contains(teacherCourse.ToLower()))
                {
                    counter++;
                }
            }
            return counter;
        }

        public void SelectSimilarNameTeachersToShow(string teacherSurname)
        {
            List<string> matchingTeachersSurname = new List<string>();
            List<string> extraTeachersInfo = new List<string>();
            List<int> teachersPositions = new List<int>();

            foreach (DataRowView teacherRowView in profesoresAdminBindingSource)
            {
                DataRow teacherRow = teacherRowView.Row;
                string stringToCheck = teacherRow["Apellido"].ToString().ToLower();
                if (stringToCheck.Contains(teacherSurname.ToLower()))
                {
                    string fullName = (teacherRow["Nombre"] + " " + teacherRow["Apellido"] + " course is " + teacherRow["Codigo"]).ToString();
                    matchingTeachersSurname.Add(fullName);

                    string extraTeacherInfo = "ID: " + teacherRow["DNI"] + "\n" +
                                              "Name: " + teacherRow["Nombre"] + "\n" +
                                              "Surnames: " + teacherRow["Apellido"] + "\n" +
                                              "Phone: " + teacherRow["Tlf"] + "\n" +
                                              "Email: " + teacherRow["Email"] + "\n" +
                                              "Course: " + teacherRow["Codigo"] + "\n";

                    extraTeachersInfo.Add(extraTeacherInfo);
                    teachersPositions.Add(profesoresAdminBindingSource.IndexOf(teacherRowView));
                }
            }

            if (matchingTeachersSurname.Count == 1)
            {
                MessageBox.Show("The data from " + matchingTeachersSurname[0] + " is: \n\n" + extraTeachersInfo[0]);
                profesoresAdminBindingSource.Position = teachersPositions[0];
                ShowTeacherRecords();
                RecordPositionLabel();
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
                            profesoresAdminBindingSource.Position = teachersPositions[0];
                            ShowTeacherRecords();
                            RecordPositionLabel();
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

        public void SelectSimilarCourseTeachersToShow(string teacherCourse)
        {
            List<string> matchingTeachersCourse = new List<string>();
            List<string> extraTeachersInfo = new List<string>();
            List<int> teachersPositions = new List<int>();

            foreach (DataRowView teacherRowView in profesoresAdminBindingSource)
            {
                DataRow teacherRow = teacherRowView.Row;
                string stringToCheck = teacherRow["Codigo"].ToString().ToLower();
                if (stringToCheck.Contains(teacherCourse.ToLower()))
                {
                    string fullName = (teacherRow["Nombre"] + " " + teacherRow["Apellido"] + " course is " + teacherRow["Codigo"]).ToString();
                    matchingTeachersCourse.Add(fullName);

                    string extraTeacherInfo = "ID: " + teacherRow["DNI"] + "\n" +
                                              "Name: " + teacherRow["Nombre"] + "\n" +
                                              "Surnames: " + teacherRow["Apellido"] + "\n" +
                                              "Phone: " + teacherRow["Tlf"] + "\n" +
                                              "Email: " + teacherRow["Email"] + "\n" +
                                              "Course: " + teacherRow["Codigo"] + "\n";

                    extraTeachersInfo.Add(extraTeacherInfo);
                    teachersPositions.Add(profesoresAdminBindingSource.IndexOf(teacherRowView));
                }
            }
            if (matchingTeachersCourse.Count == 1)
            {
                MessageBox.Show("The data from " + matchingTeachersCourse[0] + " is: \n\n" + extraTeachersInfo[0]);
                profesoresAdminBindingSource.Position = teachersPositions[0];
                ShowTeacherRecords();
                RecordPositionLabel();
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
                            profesoresAdminBindingSource.Position = teachersPositions[0];
                            ShowTeacherRecords();
                            RecordPositionLabel();
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
            bool changesDetected = false;

            DataRowView currentRowView = (DataRowView)profesoresAdminBindingSource.Current;

            if (currentRowView != null)
            {
                DataRow currentRow = currentRowView.Row;

                // CHECK THE ACTUAL DATA IN THE TEXT BOXES
                string id = txtbTeacherID.Text;
                string name = txtbTeacherName.Text;
                string surnames = txtbTeacherSurnames.Text;
                string phone = txtbTeacherPhone.Text;
                string email = txtbTeacherEmail.Text;
                string password = txtbTeacherPassword.Text;
                string course = txtbTeacherCourse.Text;

                // CHECK THIS DATA WITH THE ONE STORED IN THE DATASET IN THAT POSITION
                if (id != currentRow["DNI"].ToString() ||
                    name != currentRow["Nombre"].ToString() ||
                    surnames != currentRow["Apellido"].ToString() ||
                    phone != currentRow["Tlf"].ToString() ||
                    email != currentRow["Email"].ToString() ||
                    password != currentRow["Contraseña"].ToString() ||
                    course != currentRow["Codigo"].ToString())
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
                    btnTeacherUpdate.PerformClick();
                }
            }
        }

        private void btnTeacherCancelAddRegistry_Click(object sender, EventArgs e)
        {
            // RESET ORIGINAL POSITION
            profesoresAdminBindingSource.Position = 0;

            ShowTeacherRecords();
            RecordPositionLabel();
        }

        private void btnTeacherFirst_Click(object sender, EventArgs e)
        {
            int actualPos = profesoresAdminBindingSource.Position;

            if (actualPos < 0)
            {
                // RESET ORIGINAL POSITION
                profesoresAdminBindingSource.Position = 0;

                RecordPositionLabel();
                ShowTeacherRecords();
            }
            else
            {
                bool possiblyChangedValues = CheckValuesChanged();

                if (possiblyChangedValues && (actualPos < 0))
                {
                    // RESET ORIGINAL POSITION
                    profesoresAdminBindingSource.Position = 0;

                    RecordPositionLabel();
                    ShowTeacherRecords();
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);

                    // RESET ORIGINAL POSITION
                    profesoresAdminBindingSource.Position = 0;

                    RecordPositionLabel();
                    ShowTeacherRecords();
                }
            }
        }

        private void btnTeacherLast_Click(object sender, EventArgs e)
        {
            int actualPos = profesoresAdminBindingSource.Position;
            int teacherCount = profesoresAdminBindingSource.Count;

            if (actualPos < 0)
            {
                profesoresAdminBindingSource.Position = teacherCount - 1;
                RecordPositionLabel();
                ShowTeacherRecords();
            }
            else
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (actualPos < 0))
                {
                    profesoresAdminBindingSource.Position = teacherCount - 1;
                    RecordPositionLabel();
                    ShowTeacherRecords();
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);

                    profesoresAdminBindingSource.Position = teacherCount - 1;

                    RecordPositionLabel();
                    ShowTeacherRecords();
                }
            }
        }

        private void btnTeacherNext_Click(object sender, EventArgs e)
        {
            int actualPos = profesoresAdminBindingSource.Position;
            int teacherCount = profesoresAdminBindingSource.Count;

            if (actualPos < 0)
            {
                profesoresAdminBindingSource.MoveFirst();
            }
            else if (actualPos <= (teacherCount - 1))
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (actualPos < 0))
                {

                    profesoresAdminBindingSource.MoveNext();

                    RecordPositionLabel();
                    ShowTeacherRecords();
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);

                    profesoresAdminBindingSource.MoveNext();

                    RecordPositionLabel();
                    ShowTeacherRecords();
                }
            }
        }

        private void btnTeacherPrevious_Click(object sender, EventArgs e)
        {
            int actualPos = profesoresAdminBindingSource.Position;
            int teacherCount = profesoresAdminBindingSource.Count;

            if (actualPos < 0)
            {
                profesoresAdminBindingSource.MoveFirst();
            }
            else if (actualPos <= (teacherCount - 1))
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (possiblyChangedValues && (actualPos < 0))
                {

                    profesoresAdminBindingSource.MovePrevious();

                    RecordPositionLabel();
                    ShowTeacherRecords();
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);

                    profesoresAdminBindingSource.MovePrevious();

                    RecordPositionLabel();
                    ShowTeacherRecords();
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
            profesoresAdminBindingSource.Position = -1;
            lblRecord.Text = "";
            ButtonsCheck();
        }

        private void btnTeacherSave_Click(object sender, EventArgs e)
        {
            profesoresAdminBindingSource.AddNew();

            // CHECKS THAT THE ACTUAL TEXT BOX ID TEXT IS NOT USED ALREADY IN THE DB
            if (!BindingResources.DuplicatedID(txtbTeacherID.Text, profesoresAdminBindingSource))
            {
                // CHECKS THAT THE ACTUAL TEXT BOX PHONE TEXT IS NOT USED ALREADY IN THE DB
                if (!BindingResources.DuplicatedPhone(txtbTeacherPhone.Text, profesoresAdminBindingSource))
                {
                    // CHECKS THAT THE ACTUAL TEXT BOX EMAIL TEXT IS NOT USED ALREADY IN THE DB
                    if (!BindingResources.DuplicatedEmail(txtbTeacherEmail.Text, profesoresAdminBindingSource))
                    {
                        if (BindingResources.CheckCourseExist(txtbTeacherCourse.Text, profesoresAdminBindingSource))
                        {
                            // CREATES THE ALUMN TO SAVE
                            Teacher savedTeacher = Teacher.TeacherCreation(txtbTeacherID.Text,
                                                                           txtbTeacherName.Text,
                                                                           txtbTeacherSurnames.Text,
                                                                           txtbTeacherPhone.Text,
                                                                           txtbTeacherEmail.Text,
                                                                           txtbTeacherPassword.Text,
                                                                           txtbTeacherCourse.Text);

                            // IF THIS ALUMN IS VALID IT WILL BE INSERTED INTO THE DB
                            if (savedTeacher != null)
                            {
                                // FUNCTION WHICH CREATES A NEW ALUMN INTO THE DB
                                // AFTER THAT UPDATES THE POSITION AND THE COUNT OF ALUMN'S RECORDS

                                profesoresAdminBindingSource.Add(savedTeacher);

                                RecordPositionLabel();

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

        private void btnTeacherUpdate_Click(object sender, EventArgs e)
        {
            int teacherCount = profesoresAdminBindingSource.Count;

            if (profesoresAdminBindingSource.Current != null && changeDetected)
            {
                DataRowView currentRow = profesoresAdminBindingSource.Current as DataRowView;

                string ID = txtbTeacherID.Text;
                string name = txtbTeacherName.Text;
                string surnames = txtbTeacherSurnames.Text;
                string phone = txtbTeacherPhone.Text;
                string email = txtbTeacherEmail.Text;
                string password = txtbTeacherPassword.Text;
                string course = txtbTeacherCourse.Text;

                if (!BindingResources.DuplicatedID(ID, profesoresAdminBindingSource) || ID == currentRow["DNI"].ToString())
                {
                    if (!BindingResources.DuplicatedPhone(phone, profesoresAdminBindingSource) || phone == currentRow["Tlf"].ToString())
                    {
                        if (!BindingResources.DuplicatedEmail(email, profesoresAdminBindingSource) || email == currentRow["Email"].ToString())
                        {
                            if (BindingResources.CheckCourseExist(course, profesoresAdminBindingSource))
                            {
                                // UPDATE RECORDS IN THE BINDING SOURCE
                                currentRow["DNI"] = ID;
                                currentRow["Nombre"] = name;
                                currentRow["Apellidos"] = surnames;
                                currentRow["Tlf"] = phone;
                                currentRow["Email"] = email;
                                currentRow["Contraseña"] = password;
                                currentRow["Codigo"] = course;

                                // SAVE CHANGES
                                profesoresAdminBindingSource.EndEdit();
                                changeDetected = false;
                                MessageBox.Show("Teacher updated successfully!");
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
            else if (teacherCount == 0)
            {
                MessageBox.Show("Updating without having atleast one teacher in the DB is meaningless, try again after adding a teacher to the DB.");
            }
            else
            {
                MessageBox.Show(returnErrorInput());
            }
        }

        private void btnTeacherDelete_Click(object sender, EventArgs e)
        {
            int teacherCount = profesoresAdminBindingSource.Count;

            if (teacherCount >= 0)
            {
                DialogResult deleteConfirmation = MessageBox.Show("Do you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo);

                if (deleteConfirmation == DialogResult.Yes)
                {
                    profesoresAdminBindingSource.RemoveCurrent();

                    MessageBox.Show("Record deleted successfully!");
                }
            }
            else
            {
                MessageBox.Show("There are no records to delete.");
            }
        }


        private void btnSearchTeacher_Click(object sender, EventArgs e)
        {
            int teacherCount = profesoresAdminBindingSource.Count;
            if (teacherCount > 1)
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
            else if (teacherCount == 1)
            {
                BindingResources.ShowIdentityData(profesoresAdminBindingSource);
            }
            else
            {
                MessageBox.Show("Error, the list has no added teachers, add a teacher before checking a teacher data from the teacher list");
            }
        }

        private void btnSearchTeacherCourse_Click(object sender, EventArgs e)
        {
            int teacherCount = profesoresAdminBindingSource.Count;
            if (teacherCount > 1)
            {
                bool showed = false;
                do
                {
                    string teacherCourse = Interaction.InputBox("Introduce the teacher's course to show data (EXAMPLE: 1-DAW-N): ");
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
                } while (!showed);
            }
            else if (teacherCount == 1)
            {
                BindingResources.ShowIdentityData(profesoresAdminBindingSource);
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
            int teacherCount = profesoresAdminBindingSource.Count;
            int teacherPosition = profesoresAdminBindingSource.Position;

            bool recordsExist = (teacherCount > 0);
            bool noRecordSelected = (teacherPosition == -1);

            // ENABLE/DISABLE NAVIGATION BUTTONS
            btnTeacherNext.Enabled = (recordsExist && teacherPosition < teacherCount - 1) && !noRecordSelected;
            btnTeacherPrevious.Enabled = (recordsExist && teacherPosition > 0) && !noRecordSelected;
            btnTeacherLast.Enabled = (recordsExist && teacherPosition < teacherCount - 1) && !noRecordSelected;
            btnTeacherFirst.Enabled = (recordsExist && teacherPosition > 0) && !noRecordSelected;

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
            btnSearchTeacherCourse.Enabled = recordsExist;
        }

        // THIS FUNCTION AUTO CHECKS THE CHANGES DETECTED IN THE FOLLOWING TEXT BOXES BETWEEN THE ORIGINAL STRING AND THE NEW CHANGED
        private bool UpdateChangeDetected()
        {
            bool changeDetected = false;
            Teacher actualTeacher = profesoresAdminBindingSource.Current as Teacher;
            if (actualTeacher != null)
            {
                changeDetected = (txtbTeacherPhone.Text != actualTeacher.Phone ||
                                  txtbTeacherPassword.Text != actualTeacher.Password ||
                                  txtbTeacherCourse.Text != actualTeacher.CourseCod ||
                                  txtbTeacherID.Text != actualTeacher.ID ||
                                  txtbTeacherName.Text != actualTeacher.Name ||
                                  txtbTeacherSurnames.Text != actualTeacher.Surnames ||
                                  txtbTeacherEmail.Text != actualTeacher.Email);
                ButtonsCheck();
            }
            return changeDetected;
        }

        private void txtbID_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected();
        }

        private void txtbName_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected();
        }

        private void txtbSurnames_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected();
        }

        private void txtbPhone_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected();
        }

        private void txtbEmail_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected();
        }

        private void txtbTeacherPassword_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected();
        }

        private void txtbTeacherCourse_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected();
        }


        /* ---------------- TEXTBOX CHANGE HANDLING FUNCTIONS END --------------------- */
    }
}
