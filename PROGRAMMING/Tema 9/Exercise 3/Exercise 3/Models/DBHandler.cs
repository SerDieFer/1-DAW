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

            if (selectedTable == "Users")
            {
                // COUNT TOTAL TEACHERS
                _selectedUsersQuantity = dataSet.Tables[selectedTable].Rows.Count;
            }
            else if(selectedTable == "Characters")
            {
                // COUNT TOTAL ALUMNS
                _selectedCharactersQuantity = dataSet.Tables[selectedTable].Rows.Count;
            }

            // CLOSES CONNECTION
            con.Close();
        }

        public DataTable ImportSelectedDataTable(string selectedTable)
        {
            DataTable toImport = new DataTable();

            if (selectedTable == "Users")
            {
                toImport = dataSet.Tables["Users"];
            }
            else if (selectedTable == "Characters")
            {
                toImport = dataSet.Tables["Characters"];
            }

            // RETURNS THE DATA TABLE WHICH CONTAINS SELECTED TABLE DATA
            return toImport;
        }

        // METHOD WHICH RECONNECTS TO THE DATABASE AND UPDATES IT
        private void ReconnectionToDB(string selectedTable)
        {
            // RECONNECTS WITH THE DATA ADAPTER AND UPDATES THE DATABASE    
            SqlCommandBuilder update = new SqlCommandBuilder(dataAdapter);

            if (selectedTable == "Users")
            {
                dataAdapter.Update(dataSet, "Users");
            }
            else if (selectedTable == "Characters")
            {
                dataAdapter.Update(dataSet, "Characters");
            }
        }

        public bool CheckAllUserPosibleDuplicatedData(string userName, string email, string selectedTable)
        {
            bool duplicatedData = false;
            if (selectedTable == "Users")
            {
                if (DuplicatedNameDataFromSelectedTable(userName, selectedTable) || 
                    DuplicatedEmailDataFromUsers(email))
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
                if (row["ID"].ToString() == id)
                {
                    usedID = true;
                }
            }
            return usedID;
        }

        public bool DuplicatedNameDataFromSelectedTable(string name, string selectedTable)
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

        // METHOD TO GET THE IDENTITY ID FROM A RECORD BASES IN A CONDITION
        public int GetIdentityID(string selectedTable, string condition)
        {
            int getId;

            string path = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\SmashBros.mdf;";

            SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; " +
            "AttachDbFilename=" + path + "Integrated Security=True");

            con.Open();

            string query = "SELECT ID FROM " + selectedTable + " WHERE " + condition;
            SqlCommand newQuery = new SqlCommand(query, con);
            object lastIdentityIQ = newQuery.ExecuteScalar();

            if (lastIdentityIQ != null)
            {
                getId = Convert.ToInt32(lastIdentityIQ);
            }
            else
            {
                getId = -1;
            }
            return getId;
        }

    // METHOD WHICH RETURNS A OBJECT'S DATA FROM A SELECTED POSITION
    public object GetSelectedTypeObject(int pos, string selectedTable)
        {
            object selectedObject = null;

            // OBJECT WHICH ALLOWS US TO COLLECT RECORDS FROM A TABLE
            DataRow dRecord;

            if (selectedTable == "Users")
            {
                if (pos >= 0 && pos < UsersQuantity)
                {
                    // TAKING THE RECORD OF "pos" POSITION IN TEACHERS TABLE
                    dRecord = ImportSelectedDataTable(selectedTable).Rows[pos];

                    // TAKE VALUE FROM EACH RECORD'S COLUMNS TO SET THEM IN THE NEW USER OBJECT
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
                    dRecord = ImportSelectedDataTable(selectedTable).Rows[pos];

                    // TAKE VALUE FROM EACH RECORD'S COLUMNS TO SET THEM IN THE NEW CHARACTER OBJECT
                    selectedObject = new Character(dRecord[1].ToString(),
                                                   dRecord[2].ToString(),
                                                   dRecord[3].ToString());

                }
            }

            return selectedObject;
        }
        
        // METHOD TO GET ALL THE OBJECT DATA
        public string GetObjectDataFromPosition(object selectedObject, int pos, string selectedTable)
        {
            selectedObject = GetSelectedTypeObject(pos, selectedTable);
            string objectData = "";

            // THE IS COMPARATOR IS TO COMPARE THE TYPE OF THE OBJECT
            if (selectedObject is User userToGetData)
            {
                objectData = userToGetData.ShowsUserData();
            }
            else if (selectedObject is Character characterToGetData)
            {
                objectData = characterToGetData.ShowCharacterData();
            } 
            return objectData;
        }

        // METHOD TO ADD A NEW OBJECT TO THE DATABASE
        public void AddNewObject(object objectToAdd, string selectedTable)
        {
            // THE IS COMPARATOR IS TO COMPARE THE TYPE OF THE OBJECT
            if (objectToAdd is User userToAdd)
            {
                // CREATE A NEW REGISTRY
                DataRow dNewRecord = ImportSelectedDataTable(selectedTable).NewRow();

                // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                dNewRecord["Name"] = userToAdd.Name;
                dNewRecord["Email"] = userToAdd.Email;
                dNewRecord["Password"] = userToAdd.Password;
                dNewRecord["Banned"] = userToAdd.Banned;

                if (!CheckAllUserPosibleDuplicatedData(userToAdd.Name, userToAdd.Email, selectedTable))
                {
                    // ADDS THE REGISTRY TO THE DATA SET
                    ImportSelectedDataTable(selectedTable).Rows.Add(dNewRecord);

                    // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                    ReconnectionToDB(selectedTable);

                    // UPDATES THE POSITION AND THE COUNT OF RECORDS
                    _selectedUsersQuantity++;
                }
            }
            
            else if (objectToAdd is Character characterToAdd)
            {
                // CREATE A NEW REGISTRY    
                DataRow dNewRecord = ImportSelectedDataTable(selectedTable).NewRow();

                // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                dNewRecord["Name"] = characterToAdd.Name;
                dNewRecord["ImgRoute"] = characterToAdd.ImgRoute;
                dNewRecord["IconRoute"] = characterToAdd.IconRoute;

                if (!DuplicatedNameDataFromSelectedTable(characterToAdd.Name, selectedTable))
                {
                    // ADDS THE REGISTRY TO THE DATA SET
                    ImportSelectedDataTable(selectedTable).Rows.Add(dNewRecord);

                    // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                    ReconnectionToDB(selectedTable);

                    // UPDATES THE POSITION AND THE COUNT OF RECORDS
                    _selectedCharactersQuantity++;
                }
            }
        }

        // METHOD TO UPDATE A OBJECT INTO THE DATABASE
        public void UpdateSelectedObjectFromPosition(object objectToUpdate, int pos, string selectedTable)
        {
            // AUTOINCREMENTAL FIX 
            dataSet.Clear();
            dataAdapter.Fill(dataSet, selectedTable);

            // OBJECT WHICH ALLOWS US TO COLLECT RECORDS FROM A TABLE
            DataRow dUpdateRecord;

            // TAKING THE RECORD OF "pos" POSITION IN SELECTED TABLE
            dUpdateRecord = ImportSelectedDataTable(selectedTable).Rows[pos];

            if (objectToUpdate is User userToUpdate)
            {
                // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                dUpdateRecord["Name"] = userToUpdate.Name;
                dUpdateRecord["Email"] = userToUpdate.Email;
                dUpdateRecord["Password"] = userToUpdate.Password;
                dUpdateRecord["Banned"] = userToUpdate.Banned;

                if (!CheckAllUserPosibleDuplicatedData(dUpdateRecord[1].ToString(), dUpdateRecord[3].ToString(), selectedTable))
                {
                    // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                    ReconnectionToDB(selectedTable);
                }
            }
            else if (objectToUpdate is Character characterToUpdate)
            {
                // ADD THE DATA FROM THE SELECTED ELEMENTS INTO THE NEW RECORD
                dUpdateRecord["Name"] = characterToUpdate.Name;
                dUpdateRecord["ImgRoute"] = characterToUpdate.ImgRoute;
                dUpdateRecord["IconRoute"] = characterToUpdate.IconRoute;

                if (!DuplicatedNameDataFromSelectedTable(characterToUpdate.Name, selectedTable))
                {
                    // RECONNECTS WITH THE DATA ADAPTER AND UPDATE THE DATABASE
                    ReconnectionToDB(selectedTable);
                }
            }
        }

        // METHOD TO DELETE A SELECTED OBJECT FROM THE DB
        public void DeleteSelectedObjectFromPosition(int pos, string selectedTable)
        {
            // AUTOINCREMENTAL FIX 
            dataSet.Clear();
            dataAdapter.Fill(dataSet, selectedTable);

            // DELETE THE RECORD FROM THE SELECTED POSITION
            ImportSelectedDataTable(selectedTable).Rows[pos].Delete();

            if (selectedTable == "Users")
            {
                // UPDATES COUNT FROM TEACHERS
                _selectedUsersQuantity--;

            }
            else if (selectedTable == "Characters")
            {
                // UPDATES COUNT FROM ALUMNS
                _selectedCharactersQuantity--;

            }
            // UPDATES THE DB FROM SELECTED TABLE
            ReconnectionToDB(selectedTable);
        }

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
                    banStatus = false;
                }
                else if (banned == "Not Banned")
                {
                    banStatus = true;
                }

                if (userToCompare.Name != name ||
                    userToCompare.Password != password ||
                    userToCompare.Email != email ||
                    userToCompare.Banned != banStatus)
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
    }
}

