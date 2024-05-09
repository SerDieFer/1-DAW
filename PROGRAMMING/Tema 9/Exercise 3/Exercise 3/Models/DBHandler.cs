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
using System.Runtime.Remoting.Contexts;
using System.IO;
using Microsoft.VisualBasic.ApplicationServices;

namespace Exercise_3
{
    public class SqlDBHandler
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

        /*----------------------------------- BASIC DB HANDLING FUNCTIONS START ------------------------------------*/

        // METHOD WHICH CREATES A SQL CONNETION TO THE DB
        private SqlConnection CreateSqlConnectionToDB()
        {
            // SETS THE PATH TO THE SELECTED DB
            string path = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\SmashBros.mdf;";
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="
                                       + path + "Integrated Security=True";

            // CREATES THE NEW CONNEXION
            SqlConnection con = new SqlConnection(connectionString);

            return con;
        }

        // SQLDBHANDLER CONSTRUCTOR WHICH HANDLES THE CONNECTION AND CREATION OF DATA SET AND DATA ADAPTER
        public SqlDBHandler(string selectedTable)
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

                if (selectedTable == "Users")
                {
                    // COUNT TOTAL USERS
                    _selectedUsersQuantity = dataSet.Tables[selectedTable].Rows.Count;
                }
                else if(selectedTable == "Characters")
                {
                    // COUNT TOTAL CHARACTERS
                    _selectedCharactersQuantity = dataSet.Tables[selectedTable].Rows.Count;
                }

            // CLOSES CONNECTION
            con.Close();
        }

        // METHOD WHICH RECONNECTS TO THE DATABASE AND UPDATES IT
        private void ReconnectionToDB(string selectedTable)
        {
            // RECONNECTS WITH THE DATA ADAPTER AND UPDATES THE DATABASE    
            SqlCommandBuilder update = new SqlCommandBuilder(dataAdapter);

            if (selectedTable == "Users")
            {
                // UPDATES THE DATABASE WITH CHANGES MADE IN THE USERS TABLE
                dataAdapter.Update(dataSet, "Users");

                // AUTOINCREMENT FIX: CLEARS THE DATASET AND FILLS IT AGAIN
                dataSet.Clear();
                dataAdapter.Fill(dataSet, selectedTable);
            }
            else if (selectedTable == "Characters")
            {
                // UPDATES THE DATABASE WITH CHANGES MADE IN THE CHARACTERS TABLE
                dataAdapter.Update(dataSet, "Characters");

                // AUTOINCREMENT FIX: CLEARS THE DATASET AND FILLS IT AGAIN
                dataSet.Clear();
                dataAdapter.Fill(dataSet, selectedTable);
            }
        }

        // THIS METHOD SELECTS A SPECIFIC TABLE FROM A DATASET AND RETURNS IT AS A DATATABLE
        public DataTable ImportSelectedDataTable(string selectedTable)
        {

            // CREATE AN EMPTY DATATABLE TO STORE THE SELECTED TABLE DATA
            DataTable toImport = new DataTable();

            if (selectedTable == "Users")
            {
                // ASSIGN THE USERS TABLE FROM THE ACTUAL DATASET
                toImport = dataSet.Tables["Users"];
            }
            else if (selectedTable == "Characters")
            {
                // ASSIGN THE CHARACTERS TABLE FROM THE ACTUAL DATASET
                toImport = dataSet.Tables["Characters"];
            }

            // RETURNS THE DATA TABLE WHICH CONTAINS ALL THE SELECTED TABLE DATA
            return toImport;
        }

        /*--------------------------------- BASIC DB HANDLING FUNCTIONS END ------------------------------------*/

        /*---------------------------------- RECURRENT GET FUNCTIONS START -------------------------------------*/

        // METHOD TO GET THE IDENTITY ID FROM A CERTAIN TABLE RECORD BASED IN A CONDITION
        public int GetIdentityID(string selectedTable, string query)
        {
            // DEFAULT ID IF NOT FOUND
            int getId = -1;

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
                    getId = int.Parse(result.ToString());
                }

            // CLOSES THE CONNEXION
            con.Close();

            return getId;
        }

        // METHOD WHICH RETURNS A OBJECT'S DATA FROM A SELECTED POSITION
        public object GetSelectedTypeObject(int pos, string selectedTable)
        {
            object selectedObject = null;

            // OBJECT TO RETRIEVE RECORDS FROM A TABLE
            DataRow dRecord;

            if (selectedTable == "Users")
            {
                if (pos >= 0 && pos < UsersQuantity)
                {
                    // TAKING THE RECORD OF POS POSITION IN USERS TABLE
                    dRecord = ImportSelectedDataTable(selectedTable).Rows[pos];

                    // EXTRACT VALUES FROM EACH RECORD'S COLUMNS TO SET THEM IN THE NEW USER OBJECT
                    selectedObject = User.UserCreation(dRecord[1].ToString(),
                                                       dRecord[2].ToString(),
                                                       dRecord[3].ToString(),
                                                       (bool)dRecord[4]);
                }
            }
            else if (selectedTable == "Characters")
            {
                if (pos >= 0 && pos < CharactersQuantity)
                {
                    // TAKING THE RECORD OF POS POSITION IN CHARACTERS TABLE
                    dRecord = ImportSelectedDataTable(selectedTable).Rows[pos];

                    // EXTRACT VALUES FROM EACH RECORD'S COLUMNS TO SET THEM IN THE NEW CHARACTER OBJECT
                    selectedObject = new Character(dRecord[1].ToString(),
                                                   dRecord[2].ToString(),
                                                   dRecord[3].ToString());
                }
            }
            return selectedObject;
        }

        /*----------------------------------- RECURRENT GET FUNCTIONS END --------------------------------------*/

        /*----------------------------------- CRUD METHOD FUNCTIONS START ------------------------------------*/

        // METHOD TO ADD A NEW OBJECT TO THE DATABASE (CREATE)
        public void AddNewObject(object objectToAdd, string selectedTable)
        {
            ReconnectionToDB(selectedTable);
            // CHECK THE TYPE OF THE OBJECT
            if (objectToAdd is User userToAdd)
            {
                // CREATE A NEW RECORD
                DataRow dNewRecord = ImportSelectedDataTable(selectedTable).NewRow();

                // ADD DATA FROM THE OBJECT INTO THE NEW RECORD
                dNewRecord["ID"] = userToAdd.ID;
                dNewRecord["Name"] = userToAdd.Name;
                dNewRecord["Email"] = userToAdd.Email;
                dNewRecord["Password"] = userToAdd.Password;
                dNewRecord["Banned"] = userToAdd.Banned;

                if (!CheckAllUserDuplicatedData(userToAdd.Name, userToAdd.Email, selectedTable))
                {
                    // ADD THE RECORD TO THE DATASET
                    ImportSelectedDataTable(selectedTable).Rows.Add(dNewRecord);

                    // RECONNECT AND UPDATE THE DATABASE
                    ReconnectionToDB(selectedTable);

                    // UPDATE THE COUNT OF RECORDS
                    _selectedUsersQuantity++;
                }
            }
            else if (objectToAdd is Character characterToAdd)
            {
                // CREATE A NEW RECORD   
                DataRow dNewRecord = ImportSelectedDataTable(selectedTable).NewRow();

                // ADD DATA FROM THE OBJECT INTO THE NEW RECORD
                dNewRecord["Name"] = characterToAdd.Name;
                dNewRecord["ImgRoute"] = characterToAdd.ImgRoute;
                dNewRecord["IconRoute"] = characterToAdd.IconRoute;

                if (!DuplicatedNameData(characterToAdd.Name, selectedTable))
                {
                    // ADD THE RECORD TO THE DATASET
                    ImportSelectedDataTable(selectedTable).Rows.Add(dNewRecord);

                    // RECONNECT AND UPDATE THE DATABASE
                    ReconnectionToDB(selectedTable);

                    // UPDATE THE COUNT OF RECORDS
                    _selectedCharactersQuantity++;
                }
            }
        }

        // METHOD TO GET ALL THE OBJECT DATA (READ)
        public string GetObjectDataFromPosition(object selectedObject, int pos, string selectedTable)
        {
            // RETRIEVE THE SELECTED OBJECT'S DATA
            selectedObject = GetSelectedTypeObject(pos, selectedTable);
            string objectData = "";

            // CHECK THE TYPE OF THE SELECTED OBJECT AND GET ITS DATA
            if (selectedObject is User userToGetData)
            {
                // GETS USER DATA
                objectData = userToGetData.ShowsUserData();
            }
            else if (selectedObject is Character characterToGetData)
            {
                // GETS CHARACTER DATA
                objectData = characterToGetData.ShowCharacterData();
            }
            return objectData;
        }

        // METHOD TO UPDATE A OBJECT INTO THE DATABASE (UPDATE)
        public void UpdateObjectFromPosition(object objectToUpdate, int pos, bool unBanned, string selectedTable)
        {
            // OBJECT TO RETRIEVE RECORDS FROM A TABLE
            DataRow dUpdateRecord;

            // GET THE RECORD AT POSITION POS FROM THE SELECTED TABLE
            dUpdateRecord = ImportSelectedDataTable(selectedTable).Rows[pos];

            if (objectToUpdate is User userToUpdate)
            {
                // UPDATE THE RECORD WITH USER DATA
                dUpdateRecord["ID"] = userToUpdate.ID;
                dUpdateRecord["Name"] = userToUpdate.Name;
                dUpdateRecord["Email"] = userToUpdate.Email;
                dUpdateRecord["Password"] = userToUpdate.Password;

                // UPDATE THE BANNED COLUMN BASED ON THE VALUE OF UNBANNED
                if (unBanned)
                {
                    dUpdateRecord["Banned"] = 1;
                }
                else
                {
                    dUpdateRecord["Banned"] = 0;
                }

                // CHECK FOR DUPLICATED DATA BEFORE UPDATING THE RECORD
                if (!CheckAllUserDuplicatedData(dUpdateRecord[1].ToString(), dUpdateRecord[3].ToString(), selectedTable))
                {
                    // RECONNECT AND UPDATE THE DATABASE
                    ReconnectionToDB(selectedTable);
                }
            }
            else if (objectToUpdate is Character characterToUpdate)
            {
                // UPDATE THE RECORD WITH CHARACTER DATA
                dUpdateRecord["Name"] = characterToUpdate.Name;
                dUpdateRecord["ImgRoute"] = characterToUpdate.ImgRoute;
                dUpdateRecord["IconRoute"] = characterToUpdate.IconRoute;

                // CHECK FOR DUPLICATED NAME DATA BEFORE UPDATING THE RECORD
                if (!DuplicatedNameData(characterToUpdate.Name, selectedTable))
                {
                    // RECONNECT AND UPDATE THE DATABASE
                    ReconnectionToDB(selectedTable);
                }
            }
        }

        // METHOD TO DELETE A SELECTED OBJECT FROM THE DB (DELETE)
        public void DeleteObjectFromPosition(int pos, string selectedTable)
        {
            // DELETE THE RECORD FROM THE SELECTED POSITION
            ImportSelectedDataTable(selectedTable).Rows[pos].Delete();

            // UPDATE THE COUNT OF RECORDS FOR THE SELECTED TABLE
            if (selectedTable == "Users")
            {
                // UPDATES COUNT FROM USERS
                _selectedUsersQuantity--;

            }
            else if (selectedTable == "Characters")
            {
                // UPDATES COUNT FROM CHARACTERS
                _selectedCharactersQuantity--;

            }

            // RECONNECT AND UPDATE THE DATABASE
            ReconnectionToDB(selectedTable);
        }

        /*------------------------------------------- CRUD METHOD FUNCTIONS END ----------------------------------------------*/

        /*------------------------ FUNCTIONS TO CHECK TEXT BOXES FROM SELECTED TABLE DATA START ------------------------------*/

        // FUNCTION WHICH COMPARE THE ACTUAL DATA WITH THE STORED ONE IN THE DB FOR CHARACTERS
        public bool CheckUserChangesStoredAndActualValues(int pos, string name, string email, string password, string banned)
        {
            bool same = true;
            object objectToUpdate = GetSelectedTypeObject(pos, "Users");

            if (objectToUpdate is User userToCompare)
            {
                bool banStatus = false;

                if (banned == "Not Banned")
                {
                    banStatus = true;
                }
                else if (banned == "Banned")
                {
                    banStatus = false;
                }

                if (userToCompare.Name != name ||
                    userToCompare.Password != password ||
                    userToCompare.Email != email ||
                    userToCompare.Banned == banStatus)
                {
                    same = false;
                }
            }
            return same;
        }

        // FUNCTION WHICH COMPARE THE ACTUAL DATA WITH THE STORED ONE IN THE DB FOR USERS
        public bool CheckCharactersChangesStoredAndActualValues(int pos, string name, string imgRoute, string iconRoute)
        {
            bool same = true;
            object objectToUpdate = GetSelectedTypeObject(pos, "Characters");

            if (objectToUpdate is Character characterToCompare)
            {
                if (characterToCompare.Name != name ||
                    characterToCompare.ImgRoute != imgRoute ||
                    characterToCompare.IconRoute != iconRoute)
                {
                    same = false;
                }
            }
            return same;
        }

        /*------------------------ FUNCTIONS TO CHECK TEXT BOXES FROM SELECTED TABLE DATA START -------------------------------*/

        /*--------------------------------- FUNCTIONS TO CHECK USERS DATA INPUT START -----------------------------------------*/

        public bool CheckAllUserDuplicatedData(string userName, string email, string selectedTable)
        {
            bool duplicatedData = false;
            if (selectedTable == "Users")
            {
                if (DuplicatedNameData(userName, selectedTable) ||
                    DuplicatedEmailDataFromUsers(email))
                {
                    duplicatedData = true;
                }
            }
            return duplicatedData;
        }

        public string ReturnStringWhenDuplicatedData(string userName, string email, string selectedTable)
        {
            string result = "";

            if (DuplicatedNameData(userName, selectedTable) && DuplicatedEmailDataFromUsers(email))
            {
                result = "The selected user nickname and the email are already used, try other values";
            }
            else if (DuplicatedNameData(userName, selectedTable))
            {
                result = "This nickname is already used, try another one";
               
            }
            else if(DuplicatedEmailDataFromUsers(email))
            {
                result = "This email is already used, try another one";
            }
            return result;
        }

        public bool DuplicatedNameData(string name, string selectedTable)
        {
            bool usedName = false;

            // GETS THE FULL TABLE DATA
            DataTable tableToCheck = ImportSelectedDataTable(selectedTable);

            // SEARCHS IN THE ROWS FROM THE TABLE
            foreach (DataRow rows in tableToCheck.Rows)
            {
                // CHECK THE SELECTED ROW MATCHES THE INTRODUCED DATA
                if (rows["Name"].ToString() == name)
                {
                    usedName = true;
                }
            }
            return usedName;
        }

        public bool DuplicatedEmailDataFromUsers(string email)
        {
            bool usedMail = false;

            // GETS THE FULL TABLE DATA
            DataTable tableToCheck = ImportSelectedDataTable("Users");

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

        /*----------------------------------- FUNCTIONS TO CHECK USERS DATA INPUT END -----------------------------------------*/

    }
}

