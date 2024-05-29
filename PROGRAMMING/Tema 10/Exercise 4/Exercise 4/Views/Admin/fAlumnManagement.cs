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
using Exercise_4;
using Exercise_4.Models;

namespace Exercise_4
{
    // arreglar botones clear y al buscar curso/apellido no sale el correcto
    // CREACION Y BORRADO VAN MAL
    public partial class fAlumnManagement : Form
    {
        public fAlumnManagement()
        {
            InitializeComponent();
        }

        // FORM LOADING HANDLING
        private void fAlumnManagement_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'highschoolDataSet.Alumnos' Puede moverla o quitarla según sea necesario.
            this.alumnosAdminTableAdapter.Fill(this.highschoolDataSet.Alumnos);

            alumnosAdminBindingSource.DataSource = this.highschoolDataSet.Alumnos;

            alumnosAdminBindingSource.Position = 0;

            RecordPositionLabel();
            ShowAlumnsRecords();
            ButtonsCheck();
        }

        // THESE ARE FOR DETECTING STRING CHANGES IN THE TEXT BOXES SINCE AN ORIGINAL
        // IS REQUIRED TO CHECK BETWEEN THAT ONE AND THE USER CHANGED INPUT
        private bool changeDetected = false;
        private bool clearedRows = false;


        /* ---------------- POSITION HANDLING START --------------------- */


        // SETS THE POSITION OF THE ACTUAL RECORD INTO A TEXT LABEL
        private void RecordPositionLabel()
        {
            int actualPos = alumnosAdminBindingSource.Position;
            int alumnCount = alumnosAdminBindingSource.Count;

            if (alumnCount > 0)
            {
                lblRecord.Text = "Record Nº" + (actualPos + 1) + " of " + alumnCount;
            }
            else if (alumnCount == 0)
            {
                lblRecord.Text = "";
            }
        }

        /* ---------------- POSITION HANDLING END --------------------- */


        // FUNCTION WHICH UPDATES THE VISUAL PART OF THE FORM
        private void ShowAlumnsRecords()
        {
            int alumnCount = alumnosAdminBindingSource.Count;

            if (alumnCount > 0)
            {
                // DETECTED CHANGES RESET AND CHECKS THE ACTUAL BUTTONS STATUS
                changeDetected = false;      
            }
            else if (alumnCount == 0)
            {
                // CLEAR EVERY DATA FROM THE TEXT BOXES AND CHECKS THE ACTUAL BUTTONS STATUS
                btnAlumnClear.PerformClick();
            }

            ButtonsCheck();
        }

        public string ShowsAlumnsList()
        {
            int alumnCount = alumnosAdminBindingSource.Count;
            string result = "";

            if (alumnCount == 0)
            {
                result = "No alumns added in the DB.";
            }

            StringBuilder alumnListTxt = new StringBuilder("List of alumns: \n\n");

            for (int i = 0; i < alumnCount; i++)
            {
                alumnosAdminBindingSource.Position = i;
                DataRowView currentRowView = (DataRowView)alumnosAdminBindingSource.Current;
                DataRow row = currentRowView.Row;

                string alumnInfo = "ID: " + row["DNI"] + "\n" +
                                   "Name: " + row["Nombre"] + "\n" +
                                   "Surnames: " + row["Apellido"] + "\n" +
                                   "Phone: " + row["Tlf"] + "\n" +
                                   "Address: " + row["Direccion"] + "\n" +
                                   "Course: " + row["Codigo"] + "\n\n";

                alumnListTxt.Append(alumnInfo);
                result = alumnListTxt.ToString();
            }

            // RESET ORIGINAL POSITION
            alumnosAdminBindingSource.Position = 0;

            return result;
        }

        public int SimilarAlumnSurnamesCounter(string alumnSurname)
        {
            int counter = 0;
            foreach (DataRowView alumnRowView in alumnosAdminBindingSource)
            {
                DataRow alumnRow = alumnRowView.Row;
                string stringToCheck = alumnRow["Apellido"].ToString().ToLower();
                if (stringToCheck.Contains(alumnSurname.ToLower()))
                {
                    counter++;
                }
            }
            return counter;
        }

        public int SimilarAlumnCourseCounter(string alumnCourse)
        {
            int counter = 0;
            foreach (DataRowView alumnRowView in alumnosAdminBindingSource)
            {
                DataRow alumnRow = alumnRowView.Row;
                string stringToCheck = alumnRow["Codigo"].ToString().ToLower();
                if (stringToCheck.Contains(alumnCourse.ToLower()))
                {
                    counter++;
                }
            }
            return counter;
        }

        public void SelectSimilarNameAlumnsToShow(string alumnSurname)
        {
            List<string> matchingAlumnsName = new List<string>();
            List<string> extraAlumnsInfo = new List<string>();
            List<int> alumnsPositions = new List<int>();

            foreach (DataRowView alumnRowView in alumnosAdminBindingSource)
            {
                DataRow alumnRow = alumnRowView.Row;
                string stringToCheck = alumnRow["Apellido"].ToString().ToLower();
                if (stringToCheck.Contains(alumnSurname.ToLower()))
                {
                    string fullName = (alumnRow["Nombre"] + " " + alumnRow["Apellido"]).ToString();
                    matchingAlumnsName.Add(fullName);

                    string extraAlumnInfo = "ID: " + alumnRow["DNI"] + "\n" +
                                            "Name: " + alumnRow["Nombre"] + "\n" +
                                            "Surnames: " + alumnRow["Apellido"] + "\n" +
                                            "Phone: " + alumnRow["Tlf"] + "\n" +
                                            "Address: " + alumnRow["Direccion"] + "\n" +
                                            "Course: " + alumnRow["Codigo"] + "\n";

                    extraAlumnsInfo.Add(extraAlumnInfo);
                    alumnsPositions.Add(alumnosAdminBindingSource.IndexOf(alumnRowView));
                }
            }

            if (matchingAlumnsName.Count == 1)
            {
                MessageBox.Show("The data from " + matchingAlumnsName[0] + " is: \n\n" + extraAlumnsInfo[0]);
                alumnosAdminBindingSource.Position = alumnsPositions[0];
                ShowAlumnsRecords();
                RecordPositionLabel();
            }
            else if (matchingAlumnsName.Count > 1)
            {
                bool showed = false;
                int selectedAlumnIndex = 0;

                while (!showed)
                {
                    StringBuilder infoMessage = new StringBuilder("Alumns with the same surname:\n\n");

                    for (int i = 0; i < matchingAlumnsName.Count; i++)
                    {
                        infoMessage.AppendLine((i + 1) + ") " + matchingAlumnsName[i] + "\n");
                    }

                    infoMessage.AppendLine("Select the number of the alumn to view more data:");

                    string userInput = Interaction.InputBox(infoMessage.ToString());

                    if (int.TryParse(userInput, out selectedAlumnIndex) && selectedAlumnIndex > 0 && selectedAlumnIndex <= matchingAlumnsName.Count)
                    {
                        string selectedAlumnInfo = extraAlumnsInfo[selectedAlumnIndex - 1];
                        int selectedAlumnPositionInDB = alumnsPositions[selectedAlumnIndex - 1];

                        DialogResult result = MessageBox.Show(selectedAlumnInfo + "\n\nIs this the alumn you want to check info?", "Check Alumn Info", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            alumnosAdminBindingSource.Position = selectedAlumnPositionInDB;
                            ShowAlumnsRecords();
                            RecordPositionLabel();
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

            foreach (DataRowView alumnRowView in alumnosAdminBindingSource)
            {
                DataRow alumnRow = alumnRowView.Row;
                string stringToCheck = alumnRow["Codigo"].ToString().ToLower();
                if (stringToCheck.Contains(alumnCourse.ToLower()))
                {
                    string fullName = (alumnRow["Nombre"] + " " + alumnRow["Apellido"] + " course is " + alumnRow["Codigo"]).ToString();
                    matchingAlumnsCourse.Add(fullName);

                    string extraAlumnInfo = "ID: " + alumnRow["DNI"] + "\n" +
                                            "Name: " + alumnRow["Nombre"] + "\n" +
                                            "Surnames: " + alumnRow["Apellido"] + "\n" +
                                            "Phone: " + alumnRow["Tlf"] + "\n" +
                                            "Address: " + alumnRow["Direccion"] + "\n" +
                                            "Course: " + alumnRow["Codigo"] + "\n";

                    extraAlumnsInfo.Add(extraAlumnInfo);
                    alumnsPositions.Add(alumnosAdminBindingSource.IndexOf(alumnRowView));
                }
            }

            if (matchingAlumnsCourse.Count == 1)
            {
                MessageBox.Show("The data from " + matchingAlumnsCourse[0] + " is: \n\n" + extraAlumnsInfo[0]);
                alumnosAdminBindingSource.Position = alumnsPositions[0];
                ShowAlumnsRecords();
                RecordPositionLabel();
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
                        int selectedAlumnPositionInBS = alumnsPositions[selectedAlumnIndex - 1];

                        DialogResult result = MessageBox.Show(selectedAlumnInfo + "\n\nIs this the alumn you want to check info?", "Check Alumn Info", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            alumnosAdminBindingSource.Position = selectedAlumnPositionInBS;
                            ShowAlumnsRecords(); 
                            RecordPositionLabel(); 
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
            bool changesDetected = false;

            DataRowView currentRowView = (DataRowView)alumnosAdminBindingSource.Current;

            if (currentRowView != null)
            {
                DataRow currentRow = currentRowView.Row;

                // CHECK THE ACTUAL DATA IN THE TEXT BOXES
                string id = txtbAlumnID.Text;
                string name = txtbAlumnName.Text;
                string surnames = txtbAlumnSurnames.Text;
                string phone = txtbAlumnPhone.Text;
                string address = txtbAlumnAdress.Text;
                string password = txtbAlumnPassword.Text;
                string course = txtbAlumnCourse.Text;

                // CHECK THIS DATA WITH THE ONE STORED IN THE DATASET IN THAT POSITION
                if (id != currentRow["DNI"].ToString() ||
                    name != currentRow["Nombre"].ToString() ||
                    surnames != currentRow["Apellido"].ToString() ||
                    phone != currentRow["Tlf"].ToString() ||
                    address != currentRow["Direccion"].ToString() ||
                    password != currentRow["Contraseña"].ToString() ||
                    course != currentRow["Codigo"].ToString())
                {
                    changesDetected = true;
                }
            }
            else
            {
                changesDetected = false;
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
                    btnAlumnUpdate.PerformClick();
                }
            }
        }

        private void btnAlumnCancelAddRegistry_Click(object sender, EventArgs e)
        {
            alumnosAdminBindingSource.CancelEdit();
            alumnosAdminBindingSource.Position = 0;
            // RESET ORIGINAL POSITION
            btnAlumnFirst.PerformClick();
            clearedRows = false;
            ShowAlumnsRecords();
            RecordPositionLabel();
        }

        private void btnAlumnFirst_Click(object sender, EventArgs e)
        {
            int actualPos = alumnosAdminBindingSource.Position;
            clearedRows = false;
                bool possiblyChangedValues = CheckValuesChanged();

                if (!possiblyChangedValues)
                {
                    // RESET ORIGINAL POSITION
                    alumnosAdminBindingSource.Position = 0;

                    RecordPositionLabel();
                    ShowAlumnsRecords();
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);

                    // RESET ORIGINAL POSITION
                    alumnosAdminBindingSource.Position = 0;

                    RecordPositionLabel();
                    ShowAlumnsRecords();
                }
            
        }

        private void btnAlumnLast_Click(object sender, EventArgs e)
        {
            int actualPos = alumnosAdminBindingSource.Position;
            int alumnCount = alumnosAdminBindingSource.Count;
            clearedRows = false;
            bool possiblyChangedValues = CheckValuesChanged();
            if (!possiblyChangedValues)
            {
                alumnosAdminBindingSource.Position = alumnCount - 1;
                RecordPositionLabel();
                ShowAlumnsRecords();
            }
            else
            {
                askToUpdateIfChangesWereMade(possiblyChangedValues);

                alumnosAdminBindingSource.Position = alumnCount - 1;

                RecordPositionLabel();
                ShowAlumnsRecords();
            }
            
        }

        private void btnAlumnNext_Click(object sender, EventArgs e)
        {
            int actualPos = alumnosAdminBindingSource.Position;
            int alumnCount = alumnosAdminBindingSource.Count;
            clearedRows = false;

            if (actualPos <= (alumnCount - 1))
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (!possiblyChangedValues)
                {

                    alumnosAdminBindingSource.MoveNext();

                    RecordPositionLabel();
                    ShowAlumnsRecords();
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);

                    alumnosAdminBindingSource.MoveNext();

                    RecordPositionLabel();
                    ShowAlumnsRecords();
                }
            }
        }

        private void btnAlumnPrevious_Click(object sender, EventArgs e)
        {
            int actualPos = alumnosAdminBindingSource.Position;
            int alumnCount = alumnosAdminBindingSource.Count;
            clearedRows = false;
            if (actualPos <= (alumnCount - 1))
            {
                bool possiblyChangedValues = CheckValuesChanged();
                if (!possiblyChangedValues)
                {

                    alumnosAdminBindingSource.MovePrevious();

                    RecordPositionLabel();
                    ShowAlumnsRecords();
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);

                    alumnosAdminBindingSource.MovePrevious();

                    RecordPositionLabel();
                    ShowAlumnsRecords();
                }
            }
        }

        private void btnAlumnClear_Click(object sender, EventArgs e)
        {
            alumnosAdminBindingSource.AddNew();
            clearedRows = true;
            lblRecord.Text = "";
            ButtonsCheck();
        }

        private void btnAlumnSave_Click(object sender, EventArgs e)
        {
            alumnosAdminBindingSource.AddNew();

            // CHECKS THAT THE ACTUAL TEXT BOX ID TEXT IS NOT USED ALREADY IN THE DB
            if (!BindingResources.DuplicatedID(txtbAlumnID.Text, alumnosAdminBindingSource))
            {
                // CHECKS THAT THE ACTUAL TEXT BOX PHONE TEXT IS NOT USED ALREADY IN THE DB
                if (!BindingResources.DuplicatedPhone(txtbAlumnPhone.Text, alumnosAdminBindingSource))
                {
                    // CHECKS THAT THE ACTUAL TEXT BOX ADRESS TEXT IS NOT USED ALREADY IN THE DB
                    if (!BindingResources.DuplicatedAdress(txtbAlumnAdress.Text, alumnosAdminBindingSource))
                    {
                        if (BindingResources.CheckCourseExist(txtbAlumnCourse.Text, alumnosAdminBindingSource))
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

                                alumnosAdminBindingSource.Add(savedAlumn);

                                RecordPositionLabel();

                                btnAlumnCancelAddRegistry.PerformClick();
                                clearedRows = false;
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
            int alumnCount = alumnosAdminBindingSource.Count;

            if (alumnosAdminBindingSource.Current != null && changeDetected)
            {
                DataRowView currentRow = alumnosAdminBindingSource.Current as DataRowView;

                string ID = txtbAlumnID.Text;
                string name = txtbAlumnName.Text;
                string surnames = txtbAlumnSurnames.Text;
                string phone = txtbAlumnPhone.Text;
                string adress = txtbAlumnAdress.Text;
                string password = txtbAlumnPassword.Text;
                string course = txtbAlumnCourse.Text;

                if (!BindingResources.DuplicatedID(ID, alumnosAdminBindingSource) || ID == currentRow["DNI"].ToString())
                {
                    if (!BindingResources.DuplicatedPhone(phone, alumnosAdminBindingSource) || phone == currentRow["Tlf"].ToString())
                    {
                        if (!BindingResources.DuplicatedAdress(adress, alumnosAdminBindingSource) || adress == currentRow["Direccion"].ToString())
                        {
                            if (BindingResources.CheckCourseExist(course, alumnosAdminBindingSource))
                            {
                                // UPDATE RECORDS IN THE BINDING SOURCE
                                currentRow["DNI"] = ID;
                                currentRow["Nombre"] = name;
                                currentRow["Apellidos"] = surnames;
                                currentRow["Tlf"] = phone;
                                currentRow["Direccion"] = adress;
                                currentRow["Contraseña"] = password;
                                currentRow["Codigo"] = course;

                                // SAVE CHANGES
                                alumnosAdminBindingSource.EndEdit();
                                changeDetected = false;
                                clearedRows = false;
                                MessageBox.Show("Alumn updated successfully!");
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
            else if (alumnCount == 0)
            {
                MessageBox.Show("Updating without having atleast one alumn in the DB is meaningless, try again after adding an alumn to the DB.");
            }
            else
            {
                MessageBox.Show(returnErrorInput());
            }
        }

        private void btnAlumnDelete_Click(object sender, EventArgs e)
        {
            int alumnCount = alumnosAdminBindingSource.Count;

            if (alumnCount >= 0)
            {
                DialogResult deleteConfirmation = MessageBox.Show("Do you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo);

                if (deleteConfirmation == DialogResult.Yes)
                {
                    alumnosAdminBindingSource.RemoveCurrent();
                    RecordPositionLabel();
                    ShowAlumnsRecords();

                    MessageBox.Show("Record deleted successfully!");
                }
            }
            else
            {
                MessageBox.Show("There are no records to delete.");
            }
        }

        private void btnSearchAlumn_Click(object sender, EventArgs e)
        {
            int alumnCount = alumnosAdminBindingSource.Count;

            if (alumnCount > 1)
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
            else if (alumnCount == 1)
            {
                BindingResources.ShowIdentityData(alumnosAdminBindingSource);
            }
            else
            {
                MessageBox.Show("Error, the list has no added alumns, add an alumn before checking an alumn data from the alumns list");
            }
        }

        private void btnAlumnSearchCourse_Click(object sender, EventArgs e)
        {
            int alumnCount = alumnosAdminBindingSource.Count;

            if (alumnCount > 1)
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
            else if (alumnCount == 1)
            {
                BindingResources.ShowIdentityData(alumnosAdminBindingSource);
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
            int alumnCount = alumnosAdminBindingSource.Count;
            int alumnPosition = alumnosAdminBindingSource.Position;

            bool recordsExist = (alumnCount > 0);
            bool noRecordSelected = clearedRows;

            // ENABLE/DISABLE NAVIGATION BUTTONS
            btnAlumnNext.Enabled = (recordsExist && alumnPosition < (alumnCount - 1)) && !noRecordSelected;
            btnAlumnPrevious.Enabled = (recordsExist && alumnPosition > 0) && !noRecordSelected;
            btnAlumnLast.Enabled = (recordsExist && alumnPosition < (alumnCount - 1)) && !noRecordSelected;
            btnAlumnFirst.Enabled = (recordsExist && alumnPosition > 0) && !noRecordSelected;

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
        private bool UpdateChangeDetected()
        {
            bool changeDetected = false;
            Alumn actualAlumn = alumnosAdminBindingSource.Current as Alumn;
            if (actualAlumn != null)
            {          
                changeDetected = (txtbAlumnAdress.Text != actualAlumn.Adress ||
                                  txtbAlumnPassword.Text != actualAlumn.Password ||
                                  txtbAlumnCourse.Text != actualAlumn.CourseCod ||
                                  txtbAlumnID.Text != actualAlumn.ID ||
                                  txtbAlumnName.Text != actualAlumn.Name ||
                                  txtbAlumnSurnames.Text != actualAlumn.Surnames ||
                                  txtbAlumnPhone.Text != actualAlumn.Phone);

            }
            ButtonsCheck();
            return changeDetected;
        }


        private void txtbAdress_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected();
        }

        private void txtbPassword_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected();
        }

        private void txtbCourse_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected();
        }

        private void txtbAlumnID_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected();
        }

        private void txtbAlumnName_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected();
        }

        private void txtbAlumnSurnames_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected();
        }

        private void txtbAlumnPhone_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeDetected();
        }

        /* ---------------- TEXTBOX CHANGE HANDLING FUNCTIONS END --------------------- */
    }
}