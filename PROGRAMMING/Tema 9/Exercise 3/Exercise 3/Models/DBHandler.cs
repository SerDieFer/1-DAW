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

namespace Exercise_3
{
    public class SqlDBHandler : TableRegistry
    {
        // DATA SET AND DATA ADAPTER MEMBERS
        DataSet dataSet;
        SqlDataAdapter dataAdapter;

        // TEACHERS TOTAL COUNT MEMBER
        private int _selectedUsersQuantity;
        private int _selectedCharactersQuantity;

        // PROPERTIE OF USERS TOTAL COUNT
        public int UsersQuantity
        {
            get => _selectedUsersQuantity;
        }

        // PROPERTIE OF CHARACTERS TOTAL COUNT
        public int CharactersQuantity
        {
            get => _selectedCharactersQuantity;
        }

        // SQLDBHANDLER CONSTRUCTOR WHICH HANDLES THE CONNECTION AND CREATION OF DATA SET AND DATA ADAPTER
        public SqlDBHandler(string selectedTable)
        {
            // DB CONNECTION
            string path = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\SmashBros.mdf;";

            SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; " +
            "AttachDbFilename=" + path + "Integrated Security=True");

            // OPENS CONNECTION
            con.Open();

            dataSet = new DataSet();            
            string stringSQL = "SELECT * FROM " + selectedTable;

            dataAdapter = new SqlDataAdapter(stringSQL, con);

            dataAdapter.Fill(dataSet, selectedTable);

            if (selectedTable == ((TablesEnum)0).ToString())
            {
                // COUNT TOTAL TEACHERS
                _selectedUsersQuantity = dataSet.Tables[selectedTable].Rows.Count;
            }
            else if(selectedTable == TablesEnum.Characters)
            {
                // COUNT TOTAL ALUMNS
                _selectedCharactersQuantity = dataSet.Tables[selectedTable].Rows.Count;
            }

            // CLOSES CONNECTION
            con.Close();
        }

        public void TableSelection()
        {
            if (selectedTable = Tables.Characters)
            {
                // COUNT TOTAL TEACHERS
                _selectedTeachersQuantity = dataSet.Tables[selectedTable].Rows.Count;
            }
            else if (selectedTable == "Characters")
            {
                // COUNT TOTAL ALUMNS
                _selectedAlumnsQuantity = dataSet.Tables[selectedTable].Rows.Count;
            }
        }


        public DataTable ImportSelectedDataTable(string selectedTable)
        {
            DataTable toImport = new DataTable();

            if (selectedTable == "Profesores")
            {
                toImport = dataSet.Tables["Profesores"];
            }
            else if (selectedTable == "Alumnos")
            {
                toImport = dataSet.Tables["Alumnos"];
            }
            else if (selectedTable == "Cursos")
            {
                toImport = dataSet.Tables["Cursos"];
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
                    selectedObject = (Alumn)selectedObject;
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
            string selectedObjectDenomination = "";
            if (selectedObject is Teacher selectedTeacher)
            {
                // FIX THIS TO DEPENDACY OF TEACHER OR ALUMN
                selectedObject = GetSelectedTypeObject(pos, selectedTable);
                selectedObject = selectedTeacher;
                selectedObjectDenomination = (selectedTeacher.Name.ToString() + " " + selectedTeacher.Surnames.ToString());
            }

            /* TODO CREATE COURSE CLASS BEFORE CHECKING HERE
            else if (selectedObject is Course selectedCourse)
            {
                selectedObject = GetSelectedTypeObject(pos, selectedTable);
                selectedObject = (Course)selectedCourse;
                selectedObjectDenomination = (selectedCourse.Name + "-" + selectedCourse.ID);
            } */

            return selectedObjectDenomination;
        }

        // METHOD TO ADD A NEW OBJECT TO THE DATABASE
        public void AddNewObject(object objectToAdd, string selectedTable)
        {
            // THE IS COMPARATOR IS TO COMPARE THE TYPE OF THE OBJECT
            if (objectToAdd is Teacher teacherToAdd)
            {
                // CREATE A NEW REGISTRY
                DataRow dNewRecord = ImportSelectedDataTable(selectedTable).NewRow();

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
            
            /*TODO CREATE ALUMN CLASS BEFORE CHECKING HERE
            else if (objectToAdd is Alumn alumnToAdd)
            {
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

            /* TODO CREATE COURSE CLASS BEFORE CHECKING HERE
            else if (objectToAdd is Course courseToAdd)
            {
                // CREATE A NEW REGISTRY
                DataRow dNewRecord = ImportSelectedDataTable(selectedTable).NewRow();

                // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                dNewRecord[0] = courseToAdd.ID;
                dNewRecord[1] = courseToAdd.Name;

                if (!DuplicatedIDDataFromSelectedTable(courseToAdd.ID, selectedTable))
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
        public void UpdateSelectedObjectFromPosition(object objectToUpdate, int pos, string selectedTable)
        {
            // OBJECT WHICH ALLOWS US TO COLLECT RECORDS FROM A TABLE
            DataRow dUpdateRecord;

            // TAKING THE RECORD OF "pos" POSITION IN SELECTED TABLE
            dUpdateRecord = ImportSelectedDataTable(selectedTable).Rows[pos];

            if (objectToUpdate is Teacher teacherToUpdate)
            {
                // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                dUpdateRecord[0] = teacherToUpdate.ID;
                dUpdateRecord[1] = teacherToUpdate.Name;
                dUpdateRecord[2] = teacherToUpdate.Surnames;
                dUpdateRecord[3] = teacherToUpdate.Phone;
                dUpdateRecord[4] = teacherToUpdate.Email;

                if (!CheckAllPosibleDuplicatedData(dUpdateRecord[0].ToString(), dUpdateRecord[3].ToString(), dUpdateRecord[4].ToString(), selectedTable))
                {

                    // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                    ReconnectionToDB(selectedTable);
                }
            }

            /* TODO CREATE ALUMN CLASS BEFORE CHECKING HERE
            else if (objectToUpdate is Alumn alumnToUpdate)
            {
                // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                dUpdateRecord[0] = alumnToUpdate.ID;
                dUpdateRecord[1] = alumnToUpdate.Name;
                dUpdateRecord[2] = alumnToUpdate.Surnames;
                dUpdateRecord[3] = alumnToUpdate.Phone;
                dUpdateRecord[4] = alumnToUpdate.Email;

                if (!CheckAllPosibleDuplicatedData(alumnToUpdate.ID, alumnToUpdate.Phone, alumnToUpdate.Email, selectedTable))
                {
                    // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                    ReconnectionToDB(selectedTable);
                }
            }*/

            /* TODO COURSE CLASS BEFORE CHECKING HERE
            else if (objectToUpdate is Course courseToUpdate)
            {
                // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                dUpdateRecord[0] = courseToUpdate.ID;
                dUpdateRecord[1] = courseToUpdate.Name;

                if (!DuplicatedIDDataFromSelectedTable(courseToUpdate.ID, selectedTable))
                {
                    // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                    ReconnectionToDB(selectedTable);
                }
            }*/

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
            object objectToUpdate = GetSelectedTypeObject(pos, selectedTable);

            if (objectToUpdate is Teacher teacherToCompare)
            {
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
            else if (objectToUpdate is Alumn alumnToCompare)
            {
                if (alumnToCompare.ID != ID ||
                    alumnToCompare.Name != name ||
                    alumnToCompare.Surnames != surnames ||
                    alumnToCompare.Phone != phone ||
                    alumnToCompare.Email != email)
                {
                    same = false;
                }
            } */

            /* TODO CREATE COURSE CLASS BEFORE CHECKING HERE
            else if (objectToUpdate is Course courseToCompare)
                {
                if (courseToCompare.ID != ID ||
                    courseToCompare.Name != name)
                {
                    same = false;
                }
            }*/
            
            return same;
        }
    }
}

