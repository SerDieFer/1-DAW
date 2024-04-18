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
    public partial class fHighSchool : Form
    {
        public fHighSchool()
        {
            InitializeComponent();
        }

        DataSet dataSetTeachers;
        SqlDataAdapter dataAdapterTeachers;
        private int pos;
        private int maxRecords;

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
            }
            else if(maxRecords == 0)
            {
                btnClear.PerformClick();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectLink = "Data Source =(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=C:\\Users\\serdiefer\\Desktop\\1-DAW\\PROGRAMMING\\Tema 9\\Exercise 1\\Exercise 1\\App_Data\\Highschool.mdf;" +
            "Integrated Security=True";

            SqlConnection con = new SqlConnection(connectLink);

            // OPENS CONNECTION
            con.Open();

            dataSetTeachers = new DataSet();
            string stringSQL = "SELECT * FROM Profesores";

            dataAdapterTeachers = new SqlDataAdapter(stringSQL, con);

            dataAdapterTeachers.Fill(dataSetTeachers, "Profesores");

            // SETS FIRST POSITION
            pos = 0;
            showRecord(pos);

            // GETS TOTAL RECORDS
            maxRecords = dataSetTeachers.Tables["Profesores"].Rows.Count;
            recordPositionLabel(pos);

            // CLOSES CONNECTION
            con.Close();

        }

        // FUNCTION TO CHECK THE INPUTS FROM THE LABELS
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

        private void btnFirst_Click(object sender, EventArgs e)
        {
            pos = 0;
            recordPositionLabel(pos);
            showRecord(pos);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            pos = maxRecords - 1;
            recordPositionLabel(pos);
            showRecord(pos);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pos < (maxRecords - 1))
            {
                pos++;
                recordPositionLabel(pos);
                showRecord(pos);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pos > 0)
            {
                pos--;
                recordPositionLabel(pos);
                showRecord(pos);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtbID.Clear();
            txtbName.Clear();
            txtbSurnames.Clear();
            txtbPhone.Clear();
            txtbEmail.Clear();
            lblRecord.Text = "";
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
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (maxRecords > 0)
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
            else if(maxRecords == 0)
            {
                MessageBox.Show("Delete is not possible when no elements are in the database.");
            }
        }
    }
}
