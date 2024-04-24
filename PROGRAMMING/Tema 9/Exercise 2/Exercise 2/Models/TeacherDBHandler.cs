using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Microsoft.VisualBasic.ApplicationServices;

namespace Exercise_2
{
    internal class TeacherDBHandler
    {
        // DATA SET AND DATA ADAPTER MEMBERS
        DataSet dataSetTeachers;
        SqlDataAdapter dataAdapterTeachers;

        // TEACHERS TOTAL COUNT MEMBER
        private int _teachersQuantity;

        // PROPERTIE OF TEACHERS TOTAL COUNT
        public int TeachersQuantity
        {
            get => _teachersQuantity;
        }

        // SQLDBHANDLER CONSTRUCTOR WHICH HANDLES THE CONNECTION AND CREATION OF DATA SET AND DATA ADAPTER
        public TeacherDBHandler()
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

            // COUNT TOTAL TEACHERS
            _teachersQuantity = dataSetTeachers.Tables["Profesores"].Rows.Count;

            // CLOSES CONNECTION
            con.Close();
        }

        public DataTable ImportTeachersDataTable()
        {
            // RETURNS THE DATA TABLE WHICH CONTAINS TEACHERS DATA
            return dataSetTeachers.Tables["Profesores"];
        }

        // METHOD WHICH RECONNECTS TO THE DATABASE AND UPDATES IT
        private void ReconnectionToDB()
        {
            // RECONNECTS WITH THE DATA ADAPTER AND UPDATES THE DATABASE    
            SqlCommandBuilder update = new SqlCommandBuilder(dataAdapterTeachers);
            dataAdapterTeachers.Update(dataSetTeachers, "Profesores");
        }

        // FUNCTION WHICH STORES ALL THE PERSON DATA FROM THE DB INTO A LIST OF PERSON OBJECTS
        public List<Person> InsertsInitialPersonFromDBIntoList()
        {
            List<Person> listOfPersons = new List<Person>();

            for (int i = 0; i < _teachersQuantity; i++)
            {
                listOfPersons.Add(GetTeacherObject(i));
            }

            return listOfPersons;
        }

        public bool CheckAllPosibleDuplicatedData(string id, string phone, string email)
        {
            bool duplicatedData = false;
            if (DuplicatedIDData(id) || DuplicatedPhoneData(phone) || DuplicatedEmailData(email))
            {
                duplicatedData = true;
            }
            return duplicatedData;
        }

        public bool DuplicatedIDData(string id)
        {
            bool usedID = false;

            // GETS THE FULL TEACHERS TABLE DATA
            DataTable teachersTable = ImportTeachersDataTable();

            // SEARCHS IN THE ROWS FROM THE TEACHERS TABLE
            foreach (DataRow teacherRow in teachersTable.Rows)
            {
                // CHECK THE SELECTED ROW MATCHES THE INTRODUCED DATA
                if (teacherRow["DNI"].ToString() == id)
                {
                    usedID = true;
                }
            }
            return usedID;
        }

        public bool DuplicatedPhoneData(string phone)
        {
            bool usedPhone = false;

            // GETS THE FULL TEACHERS TABLE DATA
            DataTable teachersTable = ImportTeachersDataTable();

            // SEARCHS IN THE ROWS FROM THE TEACHERS TABLE
            foreach (DataRow teacherRow in teachersTable.Rows)
            {
                // CHECK THE SELECTED ROW MATCHES THE INTRODUCED DATA
                if (teacherRow["Tlf"].ToString() == phone)
                {
                    usedPhone = true;
                }
            }
            return usedPhone;
        }

        public bool DuplicatedEmailData(string email)
        {
            bool usedMail = false;

            // GETS THE FULL TEACHERS TABLE DATA
            DataTable teachersTable = ImportTeachersDataTable();

            // SEARCHS IN THE ROWS FROM THE TEACHERS TABLE
            foreach (DataRow teacherRow in teachersTable.Rows)
            {
                // CHECK THE SELECTED ROW MATCHES THE INTRODUCED DATA
                if (teacherRow["Email"].ToString() == email)
                {
                    usedMail = true;
                }
            }
            return usedMail;
        }

        // METHOD WHICH RETURNS A TEACHER'S DATA FROM A SELECTED POSITION
        public Teacher GetTeacherObject(int pos)
        {
            Teacher selectedTeacher = null;

            if (pos >= 0 && pos < TeachersQuantity)
            {
                // OBJECT WHICH ALLOWS US TO COLLECT RECORDS FROM A TABLE
                DataRow dRecord;

                // TAKING THE RECORD OF "pos" POSITION IN TEACHERS TABLE
                dRecord = ImportTeachersDataTable().Rows[pos];

                // TAKE VALUE FROM EACH RECORD'S COLUMNS TO SET THEM IN THE NEW TEACHER OBJECT
                selectedTeacher = Teacher.TeacherCreation(dRecord[0].ToString(), 
                                                          dRecord[1].ToString(), 
                                                          dRecord[2].ToString(), 
                                                          dRecord[3].ToString(), 
                                                          dRecord[4].ToString());
                
            }
            return selectedTeacher;
        }

        public string getTeacherDataFromPosition(Teacher selectedTeacher, int pos)
        {
            selectedTeacher = GetTeacherObject(pos);

            string teacherData = "ID: " + selectedTeacher.ID + "\n" +
                                 "Name: " + selectedTeacher.Name + "\n" +
                                 "Surnames: " + selectedTeacher.Surnames + "\n" +
                                 "Phone: " + selectedTeacher.Phone + "\n" +
                                 "Email: " + selectedTeacher.Email + "\n";
            return teacherData;
        }

        public string getTeacherFullNameFromPosition(Teacher selectedTeacher, int pos)
        {
            selectedTeacher = GetTeacherObject(pos);
            string teacherFullName = (selectedTeacher.Name + " " + selectedTeacher.Surnames);
            return teacherFullName;
        }

        // METHOD TO ADD A NEW TEACHER TO THE DATABASE
        public void AddNewTeacher(Teacher teacherToAdd)
        {
            // CREATE A NEW REGISTRY
            DataRow dNewRecord = ImportTeachersDataTable().NewRow();

            // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
            dNewRecord[0] = teacherToAdd.ID;
            dNewRecord[1] = teacherToAdd.Name;
            dNewRecord[2] = teacherToAdd.Surnames;
            dNewRecord[3] = teacherToAdd.Phone;
            dNewRecord[4] = teacherToAdd.Email;

            if (!CheckAllPosibleDuplicatedData(teacherToAdd.ID, teacherToAdd.Phone, teacherToAdd.Email))
            {
                // ADDS THE REGISTRY TO THE DATA SET
                ImportTeachersDataTable().Rows.Add(dNewRecord);

                // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                ReconnectionToDB();

                // UPDATES THE POSITION AND THE COUNT OF RECORDS
                _teachersQuantity++;
            }

        }

        // METHOD TO UPDATE A TEACHER INTO THE DATABASE
        public void UpdateTeacher(int pos)
        {
            // GETS THE TEACHER OBJECT DATA FROM THE POSITION SELECTED
            Teacher teacherToUpdate = GetTeacherObject(pos);

            // OBJECT WHICH ALLOWS US TO COLLECT RECORDS FROM A TABLE
            DataRow dRecord;

            // TAKING THE RECORD OF "pos" POSITION IN TEACHERS TABLE
            dRecord = ImportTeachersDataTable().Rows[pos];

            // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
            dRecord[0] = teacherToUpdate.ID;
            dRecord[1] = teacherToUpdate.Name;
            dRecord[2] = teacherToUpdate.Surnames;
            dRecord[3] = teacherToUpdate.Phone;
            dRecord[4] = teacherToUpdate.Email;

            if (!CheckAllPosibleDuplicatedData(teacherToUpdate.ID, teacherToUpdate.Phone, teacherToUpdate.Email))
            {
                // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                ReconnectionToDB();
            }
        }

        public void DeleteTeacher(int pos)
        {
            // DELETE THE RECORD FROM THE SELECTED POSITION
            ImportTeachersDataTable().Rows[pos].Delete();

            // UPDATE THE RECORDS COUNT FROM THIS TABLE AND UPDATES THE DB
            _teachersQuantity--;

                        /* TOCHECK
                        pos = 0;
                        RecordPositionLabel(pos); */

            ReconnectionToDB();
        }

        // FUNCTION WHICH COMPARE THE ACTUAL DATA WITH THE STORED ONE
        public bool CheckChangesStoredAndActualValues(int pos, string ID, string name, string surnames, string phone, string email)
        {
            bool same = true;
            Teacher teacherToCompare = GetTeacherObject(pos);

            if (teacherToCompare.ID == ID ||
               teacherToCompare.Name == name ||
               teacherToCompare.Surnames == surnames ||
               teacherToCompare.Phone == phone ||
               teacherToCompare.Email == email)
            {
                same = false;
            }
            return same;
        }
    }
}

