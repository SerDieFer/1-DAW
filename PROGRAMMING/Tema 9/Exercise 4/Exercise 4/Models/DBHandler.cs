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
using Exercise_4.Models;

namespace Exercise_4
{
    public class SqlDBHandler
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

        /*----------------------------------- BASIC DB HANDLING FUNCTIONS START ------------------------------------*/

        // METHOD WHICH CREATES A SQL CONNETION TO THE DB
        public SqlConnection CreateSqlConnectionToDB()
        {
            // SETS THE PATH TO THE SELECTED DB
            string path = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\Highschool.mdf;";
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="
                                       + path + "Integrated Security=True";

            // CREATES THE NEW CONNEXION
            SqlConnection con = new SqlConnection(connectionString);

            return con;
        }

        // SQLDBHANDLER CONSTRUCTOR WHICH HANDLES THE CONNECTION AND CREATION OF DATA SET AND DATA ADAPTER
        public SqlDBHandler(string selectedTable)
        {
            try
            {
                // CREATES A CONNEXION WITH THE DB
                SqlConnection con = CreateSqlConnectionToDB();

                // OPENS CONNECTION
                con.Open();

                // CREATES A NEW DATA SET
                dataSet = new DataSet();

                // STRING WHICH CONTAINS A SELECT ORDER FOR A SELECTED TABLE WITH ALL ITS INFO
                string stringSQL = "SELECT * FROM " + selectedTable;

                // CREATES A NEW DATA ADAPTER AND CONNECTS IT TO THE ACTUAL DB TO EXTRACT THE DATA BASED IN THE PREVIOUS ORDER
                dataAdapter = new SqlDataAdapter(stringSQL, con);

                // RETRIEVES DATA FROM THE DATABASE USING A DATA ADAPTER AND FILLS A TABLE IN A DATASET WITH THAT DATA
                dataAdapter.Fill(dataSet, selectedTable);

                if (selectedTable == "Profesores")
                {
                    // COUNT TOTAL TEACHERS
                    _selectedTeachersQuantity = dataSet.Tables[selectedTable].Rows.Count;
                }
                else if (selectedTable == "Alumnos")
                {
                    // COUNT TOTAL ALUMNS
                    _selectedAlumnsQuantity = dataSet.Tables[selectedTable].Rows.Count;
                }
                else if (selectedTable == "Cursos")
                {
                    // COUNT TOTAL COURSES
                    _selectedCoursesQuantity = dataSet.Tables[selectedTable].Rows.Count;
                }
                // CLOSES CONNECTION
                con.Close();
            }
            catch
            {
                Console.WriteLine("Error al conectar a la base de datos: ");
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
            else if (selectedTable == "Cursos")
            {
                dataAdapter.Update(dataSet, "Cursos");
            }
        }

        /*--------------------------------- BASIC DB HANDLING FUNCTIONS END ------------------------------------*/

        /*---------------------------------- RECURRENT GET FUNCTIONS START -------------------------------------*/

        // METHOD TO GET THE SELECTED STRING DATA FROM A CERTAIN TABLE RECORD BASED IN A CONDITION
        public string GetStringDataFromTable(string selectedTable, string query)
        {
            // DEFAULT DATA IF NOT FOUND
            string data = "";

            // CREATES A CONNEXION WITH THE DB
            SqlConnection con = CreateSqlConnectionToDB();

            // OPENS THE CONNEXION
            con.Open();

            // MUST UPDATE THE DB BEFORE DOING A SELECT FROM A CERTAIN QUERY
            ReconnectionToDB(selectedTable);

            // EXECUTES A COMMAND IN THAT CONNEXION WITH THE SELECTED QUERY
            SqlCommand command = new SqlCommand(query, con);

            // GETS AN OBJECT FROM THE COMMAND AND GETS THE FIRST COLUMN VALUE FROM THE FIRST FILE FOUND IN THAT COMMAND (SELECT)
            object result = command.ExecuteScalar();

            if (result != null)
            {
                data = result.ToString();
            }

            // CLOSES THE CONNEXION
            con.Close();

            return data;
        }


        public bool CheckAllDuplicatedData(string id, string phone, string emailOrString, string selectedTable)
        {
            bool duplicatedData = false;
            string differentTable = "";
            if(selectedTable == "Profesores")
            {
                differentTable = "Alumnos";
            }
            else if (selectedTable == "Alumnos")
            {
                differentTable = "Profesores";
            }

            if (selectedTable == "Profesores")
            {
                if (DuplicatedID(id, selectedTable) || DuplicatedID(id, differentTable) ||
                    DuplicatedPhone(phone, selectedTable) || DuplicatedPhone(phone, differentTable) ||
                    DuplicatedEmail(emailOrString, selectedTable))
                {
                    duplicatedData = true;
                }
            }
            else if(selectedTable == "Alumnos")
            {
                if (DuplicatedID(id, selectedTable) || DuplicatedID(id, differentTable) ||
                    DuplicatedPhone(phone, selectedTable) || DuplicatedPhone(phone, differentTable) ||
                    DuplicatedAdress(emailOrString, selectedTable))
                {
                    duplicatedData = true;
                }
            }
            else if (selectedTable == "Cursos")
            {
                if (DuplicatedID(id, selectedTable))
                {
                    duplicatedData = true;
                }
            }
            return duplicatedData;
        }

        public bool DuplicatedID(string id, string selectedTable)
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

        public bool DuplicatedPhone(string phone, string selectedTable)
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

        public bool DuplicatedEmail(string email, string selectedTable)
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

        public bool DuplicatedAdress(string adress, string selectedTable)
        {
            bool usedAdress = false;

            // GETS THE FULL TABLE DATA
            DataTable tableToCheck = ImportSelectedDataTable(selectedTable);

            // SEARCHS IN THE ROWS FROM THE TABLE
            foreach (DataRow row in tableToCheck.Rows)
            {
                // CHECK THE SELECTED ROW MATCHES THE INTRODUCED DATA
                if (row["Direccion"].ToString() == adress)
                {
                    usedAdress = true;
                }
            }
            return usedAdress;
        }

        // METHOD WHICH RETURNS A OBJECT'S DATA FROM A SELECTED POSITION
        public Identity GetIdentityType(int pos, string selectedTable)
        {
            Identity selectedIdentity = null;

            // OBJECT WHICH ALLOWS US TO COLLECT RECORDS FROM A TABLE
            DataRow dRecord;

            if (selectedTable == "Profesores")
            {
                if (pos >= 0 && pos < TeachersQuantity)
                {
                    // TAKING THE RECORD OF "pos" POSITION IN TEACHERS TABLE
                    dRecord = ImportSelectedDataTable(selectedTable).Rows[pos];

                    // TAKE VALUE FROM EACH RECORD'S COLUMNS TO SET THEM IN THE NEW TEACHER OBJECT
                    selectedIdentity = Teacher.TeacherCreation(dRecord[0].ToString(),
                                                               dRecord[1].ToString(),
                                                               dRecord[2].ToString(),
                                                               dRecord[3].ToString(),
                                                               dRecord[4].ToString(),
                                                               dRecord[5].ToString(),
                                                               dRecord[6].ToString());
                }
            }  
            else if (selectedTable == "Alumnos")
            {

                if (pos >= 0 && pos < AlumnsQuantity)
                {
                    dRecord = ImportSelectedDataTable(selectedTable).Rows[pos];

                    // TAKE VALUE FROM EACH RECORD'S COLUMNS TO SET THEM IN THE NEW ALUMNS OBJECT
                    selectedIdentity = Alumn.AlumnCreation(dRecord[0].ToString(),
                                                           dRecord[1].ToString(),
                                                           dRecord[2].ToString(),
                                                           dRecord[4].ToString(),
                                                           dRecord[3].ToString(),
                                                           dRecord[5].ToString(),
                                                           dRecord[6].ToString());
                    // PHONE AND ADDRESES ARE SWAPPED IN THE DB
                }
            } 
            else if (selectedTable == "Courses")
            {
                if (pos >= 0 && pos < CoursesQuantity)
                {
                    dRecord = ImportSelectedDataTable(selectedTable).Rows[pos];

                    // TAKE VALUE FROM EACH RECORD'S COLUMNS TO SET THEM IN THE NEW COURSES OBJECT
                    selectedIdentity = Course.CourseCreation(dRecord[0].ToString(),
                                                             dRecord[1].ToString());
                }
            }

            return selectedIdentity;
        }

        // METHOD TO GET ALL THE OBJECT DATA
        public string GetIdentityData(Identity selectedIdentity, int pos, string selectedTable)
        {
            selectedIdentity = GetIdentityType(pos, selectedTable);
            string identityData = "";

            // THE IS COMPARATOR IS TO COMPARE THE TYPE OF THE OBJECT
            if (selectedIdentity is Person personToGetData)
            {
                if (personToGetData.GetPersonType() == "Teacher")
                {
                    Teacher teacherToGetData = (Teacher)personToGetData;
                    identityData = teacherToGetData.ShowsPersonData();
                }
                else if (personToGetData.GetPersonType() == "Alumn")
                {
                    Alumn alumnToGetData = (Alumn)personToGetData; ;
                    identityData = alumnToGetData.ShowsPersonData();
                } 
            }
            else if (selectedIdentity is Course courseToAdd)
            {
                identityData = courseToAdd.ShowsCourseData();
            } 

            return identityData;
        }

        // FUNCTION WHICH RETURNS THE FULL NAME OF A PERSON
        public string GetIdentityFullName(Identity selectedIdentity, int pos, string selectedTable)
        {
            string selectedIdentityDenomination = "";
            if (selectedIdentity is Teacher selectedTeacher)
            {
                selectedIdentity = GetIdentityType(pos, selectedTable);
                selectedIdentity = selectedTeacher;
                selectedIdentityDenomination = (selectedTeacher.Name.ToString() + " " + selectedTeacher.Surnames.ToString());
            }
            else if (selectedIdentity is Alumn selectedAlumn)
            {
                selectedIdentity = GetIdentityType(pos, selectedTable);
                selectedIdentity = selectedAlumn;
                selectedIdentityDenomination = (selectedAlumn.Name.ToString() + " " + selectedAlumn.Surnames.ToString());
            }
            else if (selectedIdentity is Course selectedCourse)
            {
                selectedIdentity = GetIdentityType(pos, selectedTable);
                selectedIdentity = (Course)selectedCourse;
                selectedIdentityDenomination = (selectedCourse.Name + "-" + selectedCourse.ID);
            } 
            return selectedIdentityDenomination;
        }

        /*---------------------------------- RECURRENT GET FUNCTIONS END ----------------------------------------*/

        // METHOD TO ADD A NEW OBJECT TO THE DATABASE
        public void AddNewIdentity(Identity identityToAdd, string selectedTable)
        {
            // THE IS COMPARATOR IS TO COMPARE THE TYPE OF THE OBJECT
            if (identityToAdd is Teacher teacherToAdd)
            {
                // CREATE A NEW REGISTRY
                DataRow dNewRecord = ImportSelectedDataTable(selectedTable).NewRow();

                // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                dNewRecord[0] = teacherToAdd.ID;
                dNewRecord[1] = teacherToAdd.Name;
                dNewRecord[2] = teacherToAdd.Surnames;
                dNewRecord[3] = teacherToAdd.Phone;
                dNewRecord[4] = teacherToAdd.Email;
                dNewRecord[5] = teacherToAdd.Password;
                dNewRecord[6] = teacherToAdd.CourseCod;

                if (!CheckAllDuplicatedData(teacherToAdd.ID, teacherToAdd.Phone, teacherToAdd.Email, selectedTable))
                {
                    // ADDS THE REGISTRY TO THE DATA SET
                    ImportSelectedDataTable(selectedTable).Rows.Add(dNewRecord);

                    // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                    ReconnectionToDB(selectedTable);

                    // UPDATES THE POSITION AND THE COUNT OF RECORDS
                    _selectedTeachersQuantity++;
                }
            }
            else if (identityToAdd is Alumn alumnToAdd)
            {
                // CREATE A NEW REGISTRY
                DataRow dNewRecord = ImportSelectedDataTable(selectedTable).NewRow();

                // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                dNewRecord[0] = alumnToAdd.ID;
                dNewRecord[1] = alumnToAdd.Name;
                dNewRecord[2] = alumnToAdd.Surnames;
                dNewRecord[4] = alumnToAdd.Phone;
                dNewRecord[3] = alumnToAdd.Adress;
                dNewRecord[5] = alumnToAdd.Password;
                dNewRecord[6] = alumnToAdd.CourseCod;

                if (!CheckAllDuplicatedData(alumnToAdd.ID, alumnToAdd.Phone, alumnToAdd.Adress, selectedTable))
                {
                    // ADDS THE REGISTRY TO THE DATA SET
                    ImportSelectedDataTable(selectedTable).Rows.Add(dNewRecord);

                    // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                    ReconnectionToDB(selectedTable);

                    // UPDATES THE POSITION AND THE COUNT OF RECORDS
                    _selectedAlumnsQuantity++;
                }
            }
            else if (identityToAdd is Course courseToAdd)
            {
                // CREATE A NEW REGISTRY
                DataRow dNewRecord = ImportSelectedDataTable(selectedTable).NewRow();

                // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                dNewRecord[0] = courseToAdd.ID;
                dNewRecord[1] = courseToAdd.Name;

                if (!DuplicatedID(courseToAdd.ID, selectedTable))
                {
                    // ADDS THE REGISTRY TO THE DATA SET
                    ImportSelectedDataTable(selectedTable).Rows.Add(dNewRecord);

                    // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                    ReconnectionToDB(selectedTable);

                    // UPDATES THE POSITION AND THE COUNT OF RECORDS
                    _selectedCoursesQuantity++;
                }
            }
        }

        // METHOD TO UPDATE A OBJECT INTO THE DATABASE
        public void UpdateIdentity(Identity identityToUpdate, int pos, string selectedTable)
        {
            // OBJECT WHICH ALLOWS US TO COLLECT RECORDS FROM A TABLE
            DataRow dUpdateRecord;

            // TAKING THE RECORD OF "pos" POSITION IN SELECTED TABLE
            dUpdateRecord = ImportSelectedDataTable(selectedTable).Rows[pos];

            if (identityToUpdate is Teacher teacherToUpdate)
            {
                // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                dUpdateRecord[0] = teacherToUpdate.ID;
                dUpdateRecord[1] = teacherToUpdate.Name;
                dUpdateRecord[2] = teacherToUpdate.Surnames;
                dUpdateRecord[3] = teacherToUpdate.Phone;
                dUpdateRecord[4] = teacherToUpdate.Email;
                dUpdateRecord[5] = teacherToUpdate.Password;
                dUpdateRecord[6] = teacherToUpdate.CourseCod;

                if (!CheckAllDuplicatedData(teacherToUpdate.ID, dUpdateRecord[3].ToString(), dUpdateRecord[4].ToString(), selectedTable))
                {

                    // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                    ReconnectionToDB(selectedTable);
                }
            }
            else if (identityToUpdate is Alumn alumnToUpdate)
            {
                // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                dUpdateRecord[0] = alumnToUpdate.ID;
                dUpdateRecord[1] = alumnToUpdate.Name;
                dUpdateRecord[2] = alumnToUpdate.Surnames;
                dUpdateRecord[4] = alumnToUpdate.Phone;
                dUpdateRecord[3] = alumnToUpdate.Adress;
                dUpdateRecord[5] = alumnToUpdate.Password;
                dUpdateRecord[6] = alumnToUpdate.CourseCod;

                if (!CheckAllDuplicatedData(alumnToUpdate.ID, alumnToUpdate.Phone, alumnToUpdate.Adress, selectedTable))
                {
                    // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                    ReconnectionToDB(selectedTable);
                }
            }
            else if (identityToUpdate is Course courseToUpdate)
            {
                // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                dUpdateRecord[0] = courseToUpdate.ID;
                dUpdateRecord[1] = courseToUpdate.Name;

                if (!DuplicatedID(courseToUpdate.ID, selectedTable))
                {
                    // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                    ReconnectionToDB(selectedTable);
                }
            }

        }

        // METHOD TO DELETE A SELECTED OBJECT FROM THE DB
        public void DeleteIdentity(int pos, string selectedTable)
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
        public bool CheckChangesStoredAndActualValues(int pos, string ID, string name, string surnames, string phone, string adressOrEmail, string password, string course, string selectedTable)
        {
            bool same = true;
            Identity identityToUpdate = GetIdentityType(pos, selectedTable);

            if (identityToUpdate is Teacher teacherToCompare)
            {
                if (teacherToCompare.ID != ID ||
                    teacherToCompare.Name != name ||
                    teacherToCompare.Surnames != surnames ||
                    teacherToCompare.Phone != phone ||
                    teacherToCompare.Email != adressOrEmail ||
                    teacherToCompare.Password != password ||
                    teacherToCompare.CourseCod != course)
                {
                    same = false;
                }
            }
            else if (identityToUpdate is Alumn alumnToCompare)
            {
                if (alumnToCompare.ID != ID ||
                    alumnToCompare.Name != name ||
                    alumnToCompare.Surnames != surnames ||
                    alumnToCompare.Adress != adressOrEmail ||
                    alumnToCompare.Phone != phone ||
                    alumnToCompare.Password != password ||
                    alumnToCompare.CourseCod != course)
                {
                    same = false;
                }
            }
            else if (identityToUpdate is Course courseToCompare)
            {
                if (courseToCompare.ID != ID ||
                    courseToCompare.Name != name)
                {
                    same = false;
                }
            }
            
            return same;
        }
    }
}

