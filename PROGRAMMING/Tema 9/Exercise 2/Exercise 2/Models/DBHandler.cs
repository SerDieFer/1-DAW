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
using Microsoft.VisualBasic.Devices;

namespace Exercise_2
{
    abstract public class SqlDBHandler
    {
        // DATA SET AND DATA ADAPTER MEMBERS
        DataSet dataSet;
        SqlDataAdapter dataAdapter;

        // TEACHERS TOTAL COUNT MEMBER
        private int _selectedTeachersQuantity;
        private int _selectedCoursesQuantity;
        private int _selectedAlumnsQuantity;

        // PROPERTIE OF TEACHERS TOTAL COUNT
        public int TeachersQuantity
        {
            get => _selectedTeachersQuantity;
        }

        // PROPERTIE OF COURSES TOTAL COUNT
        public int CoursesQuantity
        {
            get => _selectedCoursesQuantity;
        }

        // PROPERTIE OF ALUMNS TOTAL COUNT
        public int AlumnsQuantity
        {
            get => _selectedAlumnsQuantity;
        }

        // SQLDBHANDLER CONSTRUCTOR WHICH HANDLES THE CONNECTION AND CREATION OF DATA SET AND DATA ADAPTER
        public SqlDBHandler(string selectedTable)
        {
            // DB CONNECTION
            string path = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\Highschool.mdf;";

            SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; " +
            "AttachDbFilename=" + path + "Integrated Security=True");

            // OPENS CONNECTION
            con.Open();

            dataSet = new DataSet();            
            string stringSQL = "SELECT * FROM " + selectedTable;

            dataAdapter = new SqlDataAdapter(stringSQL, con);

            dataAdapter.Fill(dataSet, selectedTable);

            if (selectedTable == "Profesores")
            {
                // COUNT TOTAL TEACHERS
                _selectedTeachersQuantity = dataSet.Tables[selectedTable].Rows.Count;
            }
            else if(selectedTable == "Alumnos")
            {
                // COUNT TOTAL ALUMNS
                _selectedAlumnsQuantity = dataSet.Tables[selectedTable].Rows.Count;
            }
            else if(selectedTable == "Courses")
            {
                // COUNT TOTAL COURSES
                _selectedCoursesQuantity = dataSet.Tables[selectedTable].Rows.Count;
            }
            // CLOSES CONNECTION
            con.Close();
        }

        public DataTable ImportSelectedDataTable(string selectedTable)
        {
            DataTable toImport = new DataTable();

            if (selectedTable == "Profesores")
            {
                toImport = dataSet.Tables[selectedTable];
            }
            else if (selectedTable == "Alumnos")
            {
                toImport = dataSet.Tables[selectedTable];
            }
            else if (selectedTable == "Courses")
            {
                toImport = dataSet.Tables[selectedTable];
            }

            // RETURNS THE DATA TABLE WHICH CONTAINS SELECTED TABLE DATA
            return toImport;
        }

        // METHOD WHICH RECONNECTS TO THE DATABASE AND UPDATES IT
        private void ReconnectionToDB(string selectedTable)
        {
            // RECONNECTS WITH THE DATA ADAPTER AND UPDATES THE DATABASE    
            SqlCommandBuilder update = new SqlCommandBuilder(dataAdapter);

            if (selectedTable == "Profesores")
            {
                dataAdapter.Update(dataSet, "Profesores");
            }
            else if (selectedTable == "Alumnos")
            {
                dataAdapter.Update(dataSet, "Alumnos");
            }
            else if (selectedTable == "Courses")
            {
                dataAdapter.Update(dataSet, "Courses");
            }
        }

        public bool CheckAllPosibleDuplicatedData(string id, string phone, string email, string selectedTable)
        {
            bool duplicatedData = false;
            if (selectedTable == "Profesores" || selectedTable == "Alumnos")
            {
                if (DuplicatedIDDataFromSelectedTable(id, selectedTable) || 
                    DuplicatedPhoneDataFromSelectedTable(phone, selectedTable) || 
                    DuplicatedEmailDataFromSelectedTable(email, selectedTable))
                {
                    duplicatedData = true;
                }
            }
            else if (selectedTable == "Cursos")
            {
                if (DuplicatedIDDataFromSelectedTable(id, selectedTable))
                {
                    duplicatedData = true;
                }
            }
            return duplicatedData;
        }

        public bool DuplicatedIDDataFromSelectedTable(string id, string selectedTable)
        {
            bool usedID = false;

            // GETS THE FULL TABLE DATA
            DataTable tableToCheck = ImportSelectedDataTable(selectedTable);

            // SEARCHS IN THE ROWS FROM THE TABLE
            foreach (DataRow row in tableToCheck.Rows)
            {
                // CHECK THE SELECTED ROW MATCHES THE INTRODUCED DATA
                if (row["DNI"].ToString() == id)
                {
                    usedID = true;
                }
            }
            return usedID;
        }

        public bool DuplicatedPhoneDataFromSelectedTable(string phone, string selectedTable)
        {
            bool usedPhone = false;

            // GETS THE FULL TABLE DATA
            DataTable tableToCheck = ImportSelectedDataTable(selectedTable);

            // SEARCHS IN THE ROWS FROM THE TABLE
            foreach (DataRow rows in tableToCheck.Rows)
            {
                // CHECK THE SELECTED ROW MATCHES THE INTRODUCED DATA
                if (rows["Tlf"].ToString() == phone)
                {
                    usedPhone = true;
                }
            }
            return usedPhone;
        }

        public bool DuplicatedEmailDataFromSelectedTable(string email, string selectedTable)
        {
            bool usedMail = false;

            // GETS THE FULL TABLE DATA
            DataTable tableToCheck = ImportSelectedDataTable(selectedTable);

            // SEARCHS IN THE ROWS FROM THE TABLE
            foreach (DataRow row in tableToCheck.Rows)
            {
                // CHECK THE SELECTED ROW MATCHES THE INTRODUCED DATA
                if (row["Email"].ToString() == email)
                {
                    usedMail = true;
                }
            }
            return usedMail;
        }

        // METHOD WHICH RETURNS A OBJECT'S DATA FROM A SELECTED POSITION
        public object GetSelectedTypeObject(int pos, string selectedTable)
        {
            object selectedObject = null;

            // OBJECT WHICH ALLOWS US TO COLLECT RECORDS FROM A TABLE
            DataRow dRecord;

            if (selectedTable == "Profesores")
            {
                if (pos >= 0 && pos < TeachersQuantity)
                {
                    // TAKING THE RECORD OF "pos" POSITION IN TEACHERS TABLE
                    dRecord = ImportSelectedDataTable(selectedTable).Rows[pos];

                    // TAKE VALUE FROM EACH RECORD'S COLUMNS TO SET THEM IN THE NEW TEACHER OBJECT
                    selectedObject = Teacher.TeacherCreation(dRecord[0].ToString(),
                                                             dRecord[1].ToString(),
                                                             dRecord[2].ToString(),
                                                             dRecord[3].ToString(),
                                                             dRecord[4].ToString());
                }
            }

            /* TODO DO THE SAME AS TEACHER UNTIL I CREATE ALUMNS CLASS
            else if (selectedTable == "Alumnos")
            {

                if (pos >= 0 && pos < AlumnsQuantity)
                {
                    dRecord = ImportSelectedDataTable(selectedTable).Rows[pos];

                    // TAKE VALUE FROM EACH RECORD'S COLUMNS TO SET THEM IN THE NEW ALUMNS OBJECT
                    selectedObject = Alumn.AlumnCreation(dRecord[0].ToString(),
                                                         dRecord[1].ToString(),
                                                         dRecord[2].ToString(),
                                                         dRecord[3].ToString(),
                                                         dRecord[4].ToString());
                }
            } */

            /* TODO DO THE SAME AS TEACHER UNTIL I CREATE ALUMNS CLASS
            else if (selectedTable == "Courses")
            {
                if (pos >= 0 && pos < CoursesQuantity)
                {
                    dRecord = ImportSelectedDataTable(selectedTable).Rows[pos];

                    // TAKE VALUE FROM EACH RECORD'S COLUMNS TO SET THEM IN THE NEW COURSES OBJECT
                    selectedObject = Course.CourseCreation(dRecord[0].ToString(),
                                                           dRecord[1].ToString());
                }
            } */

            return selectedObject;
        }

        // METHOD TO GET ALL THE OBJECT DATA
        public string GetObjectDataFromPosition(object selectedObject, int pos, string selectedTable)
        {
            selectedObject = GetSelectedTypeObject(pos, selectedTable);
            string objectData = "";

            // THE IS COMPARATOR IS TO COMPARE THE TYPE OF THE OBJECT
            if (selectedObject is Person personToGetData)
            {
                if (personToGetData.GetPersonType() == "Teacher")
                {
                    Teacher teacherToGetData = (Teacher)personToGetData;
                    objectData = teacherToGetData.ShowsPersonData();
                }

                /*TODO CREATE ALUMN CLASS BEFORE CHECKING HERE
                else if (personToGetData.GetPersonType() == "Alumn")
                {
                    Alumn alumnToGetData = (Alumn)personToGetData; ;
                    objectData = alumnToGetData.ShowsPersonData();
                } */
            }

            /* TODO CREATE COURSE CLASS BEFORE CHECKING HERE
            else if (selectedObject is Course courseToAdd)
            {
                objectData = courseToAdd.ShowsCourseData();
            } */

            return objectData;
        }

        // FUNCTION WHICH RETURNS THE FULL NAME OF A PERSON
        public string GetPersonFullNameFromPosition(object selectedObject, int pos, string selectedTable)
        {
            if (selectedObject is Person selectedPerson)
            {
                // FIX THIS TO DEPENDACY OF TEACHER OR ALUMN
                object selectedObject = (Person)selectedPerson;
                selectedPerson = GetSelectedTypeObject(pos, selectedTable);
                string selectedPersonFullName = (selectedObject.Name + " " + selectedObject.Surnames);
            }
            return selectedPersonFullName;
        }

        // METHOD TO ADD A NEW OBJECT TO THE DATABASE
        public void AddNewObject(object objectToAdd, string selectedTable)
        {
            // THE IS COMPARATOR IS TO COMPARE THE TYPE OF THE OBJECT
            if (objectToAdd is Person personToAdd)
            {
                // CREATE A NEW REGISTRY
                DataRow dNewRecord = ImportSelectedDataTable(selectedTable).NewRow();

                if (personToAdd.GetPersonType() == "Teacher")
                {
                    Teacher teacherToAdd = (Teacher)personToAdd;
                    // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                    dNewRecord[0] = teacherToAdd.ID;
                    dNewRecord[1] = teacherToAdd.Name;
                    dNewRecord[2] = teacherToAdd.Surnames;
                    dNewRecord[3] = teacherToAdd.Phone;
                    dNewRecord[4] = teacherToAdd.Email;

                    if (!CheckAllPosibleDuplicatedData(teacherToAdd.ID, teacherToAdd.Phone, teacherToAdd.Email, selectedTable))
                    {
                        // ADDS THE REGISTRY TO THE DATA SET
                        ImportSelectedDataTable(selectedTable).Rows.Add(dNewRecord);

                        // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                        ReconnectionToDB(selectedTable);

                        // UPDATES THE POSITION AND THE COUNT OF RECORDS
                        _selectedTeachersQuantity++;
                    }
                }

                /* TODO CREATE ALUMN CLASS BEFORE CHECKING HERE
                else if (personToAdd.GetPersonType() == "Alumn")
                {
                    Alumn alumnToAdd = (Alumn)personToAdd;
                    // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                    dNewRecord[0] = alumnToAdd.ID;
                    dNewRecord[1] = alumnToAdd.Name;
                    dNewRecord[2] = alumnToAdd.Surnames;
                    dNewRecord[3] = alumnToAdd.Phone;
                    dNewRecord[4] = alumnToAdd.Email;

                    if (!CheckAllPosibleDuplicatedData(alumnToAdd.ID, alumnToAdd.Phone, alumnToAdd.Email, selectedTable))
                    {
                        // ADDS THE REGISTRY TO THE DATA SET
                        ImportSelectedDataTable(selectedTable).Rows.Add(dNewRecord);

                        // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                        ReconnectionToDB(selectedTable);

                        // UPDATES THE POSITION AND THE COUNT OF RECORDS
                        _selectedAlumnsQuantity++;
                    }
                }*/
        }

        /* TODO CREATE COURSE CLASS BEFORE CHECKING HERE
        else if (objectToAdd is Course courseToAdd)
        {
            // CREATE A NEW REGISTRY
            DataRow dNewRecord = ImportSelectedDataTable(selectedTable).NewRow();

            // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
            dNewRecord[0] = courseToAdd.ID;
            dNewRecord[1] = courseToAdd.Name;

            if (!DuplicatedIDDataFromSelectedTable(courseToAdd.ID, , selectedTable))
            {
                // ADDS THE REGISTRY TO THE DATA SET
                ImportSelectedDataTable(selectedTable).Rows.Add(dNewRecord);

                // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                ReconnectionToDB(selectedTable);

                // UPDATES THE POSITION AND THE COUNT OF RECORDS
                _selectedCoursesQuantity++;
            }
        }*/

    }

        // METHOD TO UPDATE A OBJECT INTO THE DATABASE
        public void UpdateSelectedObjectFromPosition(int pos, string selectedTable)
        {
            if (selectedTable != "Courses")
            {
                // GETS THE PERSON OBJECT DATA FROM THE POSITION SELECTED
                Person personToUpdate = GetSelectedTypeObject(pos, selectedTable);

                // OBJECT WHICH ALLOWS US TO COLLECT RECORDS FROM A TABLE
                DataRow dRecord;

                if (personToUpdate.GetPersonType() == "Teacher")
                {
                    // TAKING THE RECORD OF "pos" POSITION IN SELECTED TABLE
                    dRecord = ImportSelectedDataTable(selectedTable).Rows[pos];

                    Teacher teacherToUpdate = (Teacher)personToUpdate;
                    // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                    dRecord[0] = teacherToUpdate.ID;
                    dRecord[1] = teacherToUpdate.Name;
                    dRecord[2] = teacherToUpdate.Surnames;
                    dRecord[3] = teacherToUpdate.Phone;
                    dRecord[4] = teacherToUpdate.Email;

                    if (!CheckAllPosibleDuplicatedData(teacherToUpdate.ID, teacherToUpdate.Phone, teacherToUpdate.Email, selectedTable))
                    {
                        // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                        ReconnectionToDB(selectedTable);
                    }
                }

                /* TODO CREATE ALUMN CLASS BEFORE CHECKING HERE
                else if (personToAdd.GetPersonType() == "Alumn")
                {
                    Alumn alumnToUpdate = (Alumn)personToUpdate;
                    // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                    dNewRecord[0] = alumnToUpdate.ID;
                    dNewRecord[1] = alumnToUpdate.Name;
                    dNewRecord[2] = alumnToUpdate.Surnames;
                    dNewRecord[3] = alumnToUpdate.Phone;
                    dNewRecord[4] = alumnToUpdate.Email;

                    if (!CheckAllPosibleDuplicatedData(alumnToUpdate.ID, alumnToUpdate.Phone, alumnToUpdate.Email, selectedTable))
                    {

                        // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                        ReconnectionToDB(selectedTable);
                    }
                }*/
        }

        /* TODO COURSE CLASS BEFORE CHECKING HERE
        else
        {
            // GETS THE COURSE OBJECT DATA FROM THE POSITION SELECTED
            Course courseToUpdate = GetSelectedTypeObject(pos, selectedTable);

            // OBJECT WHICH ALLOWS US TO COLLECT RECORDS FROM A TABLE
            DataRow dRecord;

            // TAKING THE RECORD OF "pos" POSITION IN SELECTED TABLE
            dRecord = ImportSelectedDataTable(selectedTable).Rows[pos];

            // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
            dRecord[0] = courseToUpdate.ID;
            dRecord[1] = courseToUpdate.Name;

            if (!DuplicatedIDDataFromSelectedTable(courseToUpdate.ID, selectedTable))
            {
                // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                ReconnectionToDB(selectedTable);
            }
        }
        */
    }

        // METHOD TO DELETE A SELECTED OBJECT FROM THE DB
        public void DeleteSelectedObjectFromPosition(int pos, string selectedTable)
        {
            // DELETE THE RECORD FROM THE SELECTED POSITION
            ImportSelectedDataTable(selectedTable).Rows[pos].Delete();

            if (selectedTable == "Profesores")
            {
                // UPDATES COUNT FROM TEACHERS
                _selectedTeachersQuantity--;

            }
            else if (selectedTable == "Alumnos")
            {
                // UPDATES COUNT FROM ALUMNS
                _selectedAlumnsQuantity--;

            }
            else if (selectedTable == "Courses")
            {
                // UPDATES COUNT FROM COURSES
                _selectedCoursesQuantity--;

            }

            // UPDATES THE DB FROM SELECTED TABLE
            ReconnectionToDB(selectedTable);
        }

        // FUNCTION WHICH COMPARE THE ACTUAL DATA WITH THE STORED ONE IN THE DB
        public bool CheckChangesStoredAndActualValues(int pos, string ID, string name, string surnames, string phone, string email, string selectedTable)
        {
            bool same = true;

            if (selectedTable != "Courses")
            {
                Person personToCompare = GetSelectedTypeObject(pos, selectedTable);

                if (personToCompare.GetPersonType() == "Teacher")
                {
                    Teacher teacherToCompare = (Teacher)personToCompare;
                    if (teacherToCompare.ID != ID ||
                        teacherToCompare.Name != name ||
                        teacherToCompare.Surnames != surnames ||
                        teacherToCompare.Phone != phone ||
                        teacherToCompare.Email != email)
                    {
                        same = false;
                    }
                }

                /* TODO CREATE ALUMN CLASS BEFORE CHECKING HERE
                else if (personToCompare.GetPersonType() == "Alumn")
                {
                    Alumn alumnToCompare = (Alumn)personToCompare;
                    if (alumnToCompare.ID != ID ||
                        alumnToCompare.Name != name ||
                        alumnToCompare.Surnames != surnames ||
                        alumnToCompare.Phone != phone ||
                        alumnToCompare.Email != email)
                    {
                        same = false;
                    }
                }
                */
            }

            /* TODO CREATE COURSE CLASS BEFORE CHECKING HERE
            else
            {
                Course courseToCompare = GetSelectedTypeObject(pos, selectedTable);
                if (courseToCompare.ID != ID ||
                    courseToCompare.Name != name)
                {
                    same = false;
                }
            }
            */

            return same;
        }
    }
}

