using Exercise_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4
{
    public class Course : Identity
    {
        private string cID, cName;

        public string ID
        {
            get => cID;
            set => cID = value;
        }
        public string Name
        {
            get => cName;
            set => cName = value;
        }

        // CLASS PRE-CONSTRUCTOR
        private Course(string cID, string cName) : base()
        {
            ID = cID;
            Name = cName;
        }

        // CLASS CONSTRUCTOR
        public static Course CourseCreation(string cID, string cName)
        {
            // RECALL TO CUSTOM REGEX WHICH CHECKS ALL THE INPUTS BEFORE INSERTING THEM INTO
            // THE ORIGINAL CONSTRUCTOR WHICH CREATES THE ACTUAL TEACHER WITHOUT ANY ERROR
            if (!CustomRegex.RegexCourseCod(cID) ||
                !CustomRegex.RegexName(cName))
            {
                return null;
            }
            else
            {
                return new Course(cID, cName);
            }
        }

        public string ShowsCourseData()
        {
            var className = GetType().Name;
            string cInfoTxt = "";
            cInfoTxt = className
                       + " data: \n\n"
                       + "ID: " + ID + "\n"
                       + "Name: " + Name + "\n";
            return cInfoTxt;
        }

    }
}
