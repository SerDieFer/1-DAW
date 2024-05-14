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

namespace Exercise_4
{
    public class Teacher : Person
    {
        private string tEmail, tCourse;

        // PROPERTIES
        public string Email
        {
            get => tEmail;
            set => tEmail = value;
        }

        public string CourseCod
        {
            get => tCourse;
            set => tCourse = value;
        }


        // CLASS PRE-CONSTRUCTOR
        private Teacher(string tID, string tName, string tSurnames, string tPhone, string tEmail, string tPassword, string tCourseCod) : base(tID, tName, tSurnames, tPhone, tPassword)
        {
            Email = tEmail;
            CourseCod = tCourseCod;
        }

        // CLASS CONSTRUCTOR
        public static Teacher TeacherCreation(string tID, string tName, string tSurnames, string tPhone, string tEmail, string tPassword, string tCourseCod)
        {
            // RECALL TO CUSTOM REGEX WHICH CHECKS ALL THE INPUTS BEFORE INSERTING THEM INTO
            // THE ORIGINAL CONSTRUCTOR WHICH CREATES THE ACTUAL TEACHER WITHOUT ANY ERROR
            if (!CustomRegex.RegexID(tID) ||
                !CustomRegex.RegexName(tName) ||
                !CustomRegex.RegexName(tSurnames) ||
                !CustomRegex.RegexPhone(tPhone) || 
                !CustomRegex.RegexEmail(tEmail) ||
                !CustomRegex.RegexPassword(tPassword) ||
                !CustomRegex.RegexCourseCod(tCourseCod))
            {
                return null;
            }
            else
            {
                return new Teacher(tID, tName, tSurnames, tPhone, tEmail, tPassword, tCourseCod);
            }
        }

        public override string ShowsPersonData()
        {
            string tInfoTxt = "";
            tInfoTxt += base.ShowsPersonData() + "Email: " + Email + "\n";
            return tInfoTxt;
        }
    }
}
