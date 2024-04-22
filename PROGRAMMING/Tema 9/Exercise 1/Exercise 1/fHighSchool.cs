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

namespace Exercise_1
{
    // ERROR AL BORRAR TODOS
    public partial class fHighSchool : Form
    {
        public fHighSchool()
        {
            InitializeComponent();
        }

        // CREATION OF DATASET AND ADAPTER
        DataSet dataSetTeachers;
        SqlDataAdapter dataAdapterTeachers;

        // CREATION OF GLOBAL VARIABLES
        private int pos = -1;
        private int maxRecords = 0;

        // FORM LOADING HANDLING
        private void Form1_Load(object sender, EventArgs e)
        {
            // DB CONNECTION
            string path = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\Highschool.mdf;";

            SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; " +
            "AttachDbFilename=" + path + "Integrated Security=True");

            // OPENS CONNECTION
            con.Open();

            dataSetTeachers = new DataSet();
            string stringSQL = "SELECT * FROM Profesores";

            dataAdapterTeachers = new SqlDataAdapter(stringSQL, con);

            dataAdapterTeachers.Fill(dataSetTeachers, "Profesores");

            // GETS TOTAL RECORDS
            maxRecords = dataSetTeachers.Tables["Profesores"].Rows.Count;

            // SETS FIRST POSITION, UPDATES THE VISUALS AND CHECKS THE ACTUAL BUTTONS STATUS WHEN FIRST LOADED
            pos = 0;
            recordPositionLabel(pos);
            showRecord(pos);
            ButtonsCheck();

            // CLOSES CONNECTION
            con.Close();
        }


        // THESE ARE FOR DETECTING STRING CHANGES IN THE TEXT BOXES SINCE AN ORIGINAL
        // IS REQUIRED TO CHECK BETWEEN THAT ONE AND THE USER CHANGED INPUT
        private bool changeDetected = false;
        private string originalID;
        private string originalName;
        private string originalSurnames;
        private string originalPhone;
        private string originalEmail;

        // FUNCTION WHICH UPDATES THE VISUAL PART OF THE FORM AND CREATES A SAVE OF THE TEXT BOXES INPUTS IN THAT POSITION
        private void showRecord(int pos)
        {
            if (maxRecords > 0)
            { 
                // OBJECT WHICH ALLOWS US TO COLLECT RECORDS FROM A TABLE
                DataRow dRecord;

                // TAKING THE RECORD OF "pos" POSITION IN TEACHERS TABLE
                dRecord = dataSetTeachers.Tables["Profesores"].Rows[pos];

                // TAKE VALUE FROM EACH RECORD'S COLUMNS TO SET THEM IN THE APPROPIATE TEXTBOX
                txtbID.Text = dRecord[0].ToString();
                txtbName.Text = dRecord[1].ToString();
                txtbSurnames.Text = dRecord[2].ToString();
                txtbPhone.Text = dRecord[3].ToString();
                txtbEmail.Text = dRecord[4].ToString();

                // SAVES ORIGINAL VALUES FROM THIS POSITION 
                originalID = txtbID.Text;
                originalName = txtbName.Text;
                originalSurnames = txtbSurnames.Text;
                originalPhone = txtbPhone.Text;
                originalEmail = txtbEmail.Text;

                // DETECTED CHANGES RESET AND CHECKS THE ACTUAL BUTTONS STATUS
                changeDetected = false;
                ButtonsCheck();
            }
            else if(maxRecords == 0)
            {
                // CLEAR EVERY DATA FROM THE TEXT BOXES AND CHECKS THE ACTUAL BUTTONS STATUS
                btnClear.PerformClick();
                ButtonsCheck();
            }
        }

        // SET POSITION COUNTER FROM ALL RECORDS
        private void recordPositionLabel(int pos) 
        {
            if(maxRecords > 0)
            {
                lblRecord.Text = "Record Nº" + (pos + 1) + " of " + maxRecords;
            }
            else if (maxRecords == 0)
            {
                lblRecord.Text = "";
            } 
        }

        // FUNCTION WHICH COMPARE THE ACTUAL DATA WITH THE STORED ONE
        private bool compareActualDataWithTheStoredOne(int pos)
        {
            // OBJECT WHICH ALLOWS US TO COLLECT RECORDS FROM A TABLE
            DataRow dCompareRecord;

            // TAKING THE RECORD OF "pos" POSITION IN TEACHERS TABLE
            dCompareRecord = dataSetTeachers.Tables["Profesores"].Rows[pos];

            // CREATE A VECTOR TO STORE THE 5 VALUES TEMPORARILY AND ASSIGN THE ACTUAL VALUES IN THE TEXT BOXES
            string[] actualRecords = new string[5];

            actualRecords[0] = txtbID.Text;
            actualRecords[1] = txtbName.Text;
            actualRecords[2] = txtbSurnames.Text;
            actualRecords[3] = txtbPhone.Text;
            actualRecords[4] = txtbEmail.Text;

            bool same = true;
            for (int i = 0; i < 5 && same; i++)
            {
                if (dCompareRecord[i].ToString() != actualRecords[i])
                {
                    same = false;
                }
            }
            return same;
        }

        private void askToUpdateIfChangesWereMade(bool choice)
        {
            if(!choice) 
            {
                DialogResult update = MessageBox.Show("Do you want to keep changes of this record (Y/N)?", "Keep Changes?", MessageBoxButtons.YesNo);

                if (update == DialogResult.Yes)
                {
                    btnUpdate.PerformClick();
                }
            }
        }

        public int TeachersCounter()
        {
            int counter = 0;
            if (maxRecords != 0)
            {
                for (int i = 0; i < dataSetTeachers.Tables["Profesores"].Rows.Count; i++)
                {
                    counter++;
                }
            }
            return counter;
        }

        public string getTeacherDataFromPosition(int pos)
        {
            DataRow teacherRow = dataSetTeachers.Tables["Profesores"].Rows[pos];
            string teacherData = "ID: " + teacherRow["DNI"] + "\n" +
                                 "Name: " + teacherRow["Nombre"] + "\n" +
                                 "Surnames: " + teacherRow["Apellido"] + "\n" +
                                 "Phone: " + teacherRow["Tlf"] + "\n" +
                                 "Email: " + teacherRow["Email"] + "\n";
            return teacherData;
        }

        public string getTeacherFullNameFromPosition(int pos)
        {
            DataRow teacherRow = dataSetTeachers.Tables["Profesores"].Rows[pos];
            string teacherFullName =(teacherRow["Nombre"] + " " + teacherRow["Apellido"]).ToString();
            return teacherFullName;
        } 

        public int SimilarTeacherSurnamesCounter(string teacherSurname)
        {
            int counter = 0;
            if (maxRecords != 0)
            {
                for (int i = 0; i < dataSetTeachers.Tables["Profesores"].Rows.Count; i++)
                {
                    DataRow teacherRow = dataSetTeachers.Tables["Profesores"].Rows[i];
                    string stringToCheck = teacherRow[2].ToString().ToLower();
                    if (stringToCheck.Contains(teacherSurname.ToLower()))
                    {
                        counter++;                 
                    }
                }
            }
            return counter;
        }

        public string ShowsTeachersList()
        {
            string result = "";
            if (TeachersCounter() > 0)
            {
                string teacherListTxt = "List of teachers: \n\n";

                if (TeachersCounter() > 1)
                {
                    if (maxRecords != 0)
                    {
                        DataTable teachersTable = dataSetTeachers.Tables["Profesores"];

                        foreach (DataRow row in teachersTable.Rows)
                        {
                            string teacherInfo = "ID: " + row["DNI"] + "\n" +
                                                 "Name: " + row["Nombre"] + "\n" +
                                                 "Surnames: " + row["Apellido"] + "\n" +
                                                 "Phone: " + row["Tlf"] + "\n" +
                                                 "Email: " + row["Email"] + "\n";

                            teacherListTxt += teacherInfo + "\n";
                        }
                    }
                    result = teacherListTxt;
                }
                else if (TeachersCounter() == 1)
                {
                    teacherListTxt = "Teacher Data: \n\n" + getTeacherDataFromPosition(0);
                    result = teacherListTxt;
                }
            }
            else
            {
                result = "No teachers added in the DB.";
            }
            return result;
        }

        public void SelectSimilarNameTeachersToShow(string teacherSurname)
        {
            List<string> matchingTeachersSurname = new List<string>();
            List<string> extraTeachersInfo = new List<string>();
            List<int> teachersPositions = new List<int>();

            if (maxRecords != 0)
            {
                DataTable teachersTable = dataSetTeachers.Tables["Profesores"];
                for (int i = 0; i < teachersTable.Rows.Count; i++)
                {
                    DataRow row = dataSetTeachers.Tables["Profesores"].Rows[i];
                    string stringToCheck = row[2].ToString().ToLower();
                    if (stringToCheck.Contains(teacherSurname.ToLower()))
                    {
                        string fullName = (row["Nombre"] + " " + row["Apellido"]).ToString();
                        matchingTeachersSurname.Add(fullName);

                        string extraTeacherInfo = "ID: " + row["DNI"] + "\n" +
                                                  "Name: " + row["Nombre"] + "\n" +
                                                  "Surnames: " + row["Apellido"] + "\n" +
                                                  "Phone: " + row["Tlf"] + "\n" +
                                                  "Email: " + row["Email"] + "\n";

                        extraTeachersInfo.Add(extraTeacherInfo);
                        teachersPositions.Add(i);
                    }
                }
                
            }
            if (matchingTeachersSurname.Count == 1)
            {
                MessageBox.Show("The data from " + matchingTeachersSurname[0] + " is: \n\n" + extraTeachersInfo[0]);
                pos = teachersPositions[0];
                showRecord(pos);
                recordPositionLabel(pos);
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
                            showRecord(pos);
                            recordPositionLabel(pos);
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

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                pos = 0;
                recordPositionLabel(pos);
                showRecord(pos);
            }
            else
            {
                bool possiblyChangedValues = compareActualDataWithTheStoredOne(pos);
                if (possiblyChangedValues && (pos == -1))
                {
                    pos = 0;
                    recordPositionLabel(pos);
                    showRecord(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos = 0;
                    recordPositionLabel(pos);
                    showRecord(pos);
                }
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                pos = maxRecords - 1;
                recordPositionLabel(pos);
                showRecord(pos);
            }
            else
            {
                bool possiblyChangedValues = compareActualDataWithTheStoredOne(pos);
                if (possiblyChangedValues && (pos == -1))
                {
                    pos = maxRecords - 1;
                    recordPositionLabel(pos);
                    showRecord(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos = maxRecords - 1;
                    recordPositionLabel(pos);
                    showRecord(pos);
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pos == -1)
            {
                btnFirst.PerformClick();
            }
            else if (pos < (maxRecords - 1))
            {
                bool possiblyChangedValues = compareActualDataWithTheStoredOne(pos);
                if (possiblyChangedValues && (pos == -1))
                {
                    pos++;
                    recordPositionLabel(pos);
                    showRecord(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos++;
                    recordPositionLabel(pos);
                    showRecord(pos);
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
                bool possiblyChangedValues = compareActualDataWithTheStoredOne(pos);
                if (possiblyChangedValues && (pos == -1))
                {
                    pos--;
                    recordPositionLabel(pos);
                    showRecord(pos);
                }
                else
                {
                    askToUpdateIfChangesWereMade(possiblyChangedValues);
                    pos--;
                    recordPositionLabel(pos);
                    showRecord(pos);
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
            // CREATE A NEW REGISTRY
            DataRow dNewRecord = dataSetTeachers.Tables["Profesores"].NewRow();

            if (checkRecordsInput())
            {
                // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                dNewRecord[0] = txtbID.Text;
                dNewRecord[1] = txtbName.Text;
                dNewRecord[2] = txtbSurnames.Text;
                dNewRecord[3] = txtbPhone.Text;
                dNewRecord[4] = txtbEmail.Text;

                // ADDS THE REGISTRY TO THE DATA SET
                dataSetTeachers.Tables["Profesores"].Rows.Add(dNewRecord);

                // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                SqlCommandBuilder update = new SqlCommandBuilder(dataAdapterTeachers);
                dataAdapterTeachers.Update(dataSetTeachers, "Profesores");

                // UPDATES THE POSITION AND THE COUNT OF RECORDS
                maxRecords++;
                pos = maxRecords - 1;
                recordPositionLabel(pos);
            }
            else
            {
                MessageBox.Show(returnErrorInput());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (pos != -1 && changeDetected)
            {
                // TAKE THE SELECTED RECORD FROM THE ACTUAL POSITION "pos"
                DataRow dUpdateRecord = dataSetTeachers.Tables["Profesores"].Rows[pos];

                if (checkRecordsInput())
                {
                    // UPDATE THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                    dUpdateRecord[0] = txtbID.Text;
                    dUpdateRecord[1] = txtbName.Text;
                    dUpdateRecord[2] = txtbSurnames.Text;
                    dUpdateRecord[3] = txtbPhone.Text;
                    dUpdateRecord[4] = txtbEmail.Text;

                    // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                    SqlCommandBuilder update = new SqlCommandBuilder(dataAdapterTeachers);
                    dataAdapterTeachers.Update(dataSetTeachers, "Profesores");
                }
                else
                {
                    MessageBox.Show(returnErrorInput());
                }

                showRecord(pos);
                recordPositionLabel(pos);
                changeDetected = false;
                ButtonsCheck();
            }
            else
            {
                MessageBox.Show("Updating without having atleast one teacher in the DB is meaningless, try again after adding a teacher to the DB.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (maxRecords > 0)
            {
                if (pos != -1)
                {
                    DialogResult delete;
                    delete = MessageBox.Show("Do you want to delete this record (Y/N)?", "Delete Record?", MessageBoxButtons.YesNo);

                    if (delete == DialogResult.Yes)
                    {
                        // DELETE THE RECORD FROM THE ACTUAL POSITION
                        dataSetTeachers.Tables["Profesores"].Rows[pos].Delete();

                        // UPDATES THE RECORDS' COUNT
                        maxRecords--;

                        // RESET THE POSITION TO DEFAULT AND SHOWS IT
                        pos = 0;
                        recordPositionLabel(pos);

                        // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                        SqlCommandBuilder update = new SqlCommandBuilder(dataAdapterTeachers);
                        dataAdapterTeachers.Update(dataSetTeachers, "Profesores");

                        showRecord(pos);
                    }
                }
                else
                {
                    MessageBox.Show("Delete is not possible when no teacher is selected.");
                }
            }
            else if (maxRecords == 0)
            {
                MessageBox.Show("Delete is not possible when no elements are in the database.");
            }
        }

        private void btnCancelAddRegistry_Click(object sender, EventArgs e)
        {
            pos = 0;
            showRecord(pos);
            recordPositionLabel(pos);
        }

        private void btnSearchTeacher_Click(object sender, EventArgs e)
        {
            if (TeachersCounter() > 1)
            {
                if (maxRecords > 0)
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
            }
            else if (TeachersCounter() == 1)
            {
                MessageBox.Show("There's only one teacher so it's data will be the one showed.");
                MessageBox.Show("The data from " + getTeacherFullNameFromPosition(0) + " is: \n\n" + getTeacherDataFromPosition(0));
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


        /* ---------------- REGEX HANDLING FUNCTIONS START --------------------- */

        // FUNCTION TO CHECK ALL THE INPUTS FROM THE LABELS OF THE TEXT BOXES
        private bool checkRecordsInput()
        {
            bool allValid = true;

            if (!CustomRegex.RegexID(txtbID.Text))
            {
                allValid = false;
            }

            if (!CustomRegex.RegexName(txtbName.Text))
            {
                allValid = false;
            }

            if (!CustomRegex.RegexName(txtbSurnames.Text))
            {
                allValid = false;
            }

            if (!CustomRegex.RegexPhone(txtbPhone.Text))
            {
                allValid = false;
            }

            if (!CustomRegex.RegexEmail(txtbEmail.Text))
            {
                allValid = false;
            }

            return allValid;
        }

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

            /* ---------------- REGEX HANDLING FUNCTIONS END --------------------- */

        /* ---------------- TEXTBOX CHANGE HANDLING FUNCTIONS START --------------------- */

        public void ButtonsCheck()
        {
            bool recordsExist = (maxRecords > 0);
            bool noRecordSelected = (pos == -1);

            // ENABLE/DISABLE NAVIGATION BUTTONS
            btnNext.Enabled = (recordsExist && pos < maxRecords - 1) && !noRecordSelected;
            btnLast.Enabled = (recordsExist && pos < maxRecords - 1) && !noRecordSelected;
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
