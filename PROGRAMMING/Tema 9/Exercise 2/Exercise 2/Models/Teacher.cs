using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Data;
using System.Windows.Forms;

namespace Exercise_2
{
    public class Teacher : Person
    {
        private string tID, tName, tSurnames, tPhone, tEmail;

        // PROPERTIES
        public string Email
        {
            get => tEmail;
            set => tEmail = value;
        }

        // CLASS PRE-CONSTRUCTOR
        private Teacher(string tID, string tName, string tSurnames, string tPhone, string tEmail) : base(tID, tName, tSurnames, tPhone)
        {
            tEmail = this.tEmail;
        }

        // CLASS CONSTRUCTOR
        public static Teacher TeacherCreation(string tID, string tName, string tSurnames, string tPhone, string tEmail)
        {
            // RECALL TO CUSTOM REGEX WHICH CHECKS ALL THE INPUTS BEFORE INSERTING THEM INTO
            // THE ORIGINAL CONSTRUCTOR WHICH CREATES THE ACTUAL TEACHER WITHOUT ANY ERROR
            if (!CustomRegex.RegexID(tID) ||
                !CustomRegex.RegexName(tName) ||
                !CustomRegex.RegexName(tSurnames) ||
                !CustomRegex.RegexPhone(tPhone) || 
                !CustomRegex.RegexEmail(tEmail))
            {
                return null;
            }
            else
            {
                return new Teacher(tID, tName, tSurnames, tPhone, tEmail);
            }
        }


        public override string ShowsPersonData()
        {
            string tInfoTxt = "";
            tInfoTxt += base.ShowsPersonData() + "Email: " + Email + "\n";
            return tInfoTxt;
        }

        public string ShowsTeachersList()
        {
            string result = "";
            if ((SqlDBHandler)SqlDBHandler.) > 0)
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
    }
}
