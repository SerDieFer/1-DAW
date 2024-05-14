using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4.Models
{
    public class Alumn : Person
    {
        private string aAdress, aCourseCod;

        // PROPERTIES
        public string Adress
        {
            get => aAdress;
            set => aAdress = value;
        }
        public string CourseCod
        {
            get => aCourseCod;
            set => aCourseCod = value;
        }


        // CLASS PRE-CONSTRUCTOR
        private Alumn(string aID, string aName, string aSurnames, string aPhone, string aAdress, string aPassword, string aCourseCod) : base(aID, aName, aSurnames, aPhone, aPassword)
        {
            Adress = aAdress;
            CourseCod = aCourseCod;
        }

        // CLASS CONSTRUCTOR
        public static Alumn AlumnCreation(string aID, string aName, string aSurnames, string aPhone, string aAdress, string aPassword, string aCourseCod)
        {
            // RECALL TO CUSTOM REGEX WHICH CHECKS ALL THE INPUTS BEFORE INSERTING THEM INTO
            // THE ORIGINAL CONSTRUCTOR WHICH CREATES THE ACTUAL TEACHER WITHOUT ANY ERROR
            if (!CustomRegex.RegexID(aID) ||
                !CustomRegex.RegexName(aName) ||
                !CustomRegex.RegexName(aSurnames) ||
                !CustomRegex.RegexPhone(aPhone) ||
                !CustomRegex.RegexPassword(aPassword) ||
                !CustomRegex.RegexCourseCod(aCourseCod))
            {
                return null;
            }
            else
            {
                return new Alumn(aID, aName, aSurnames, aPhone, aAdress, aPassword, aCourseCod);
            }
        }

        public override string ShowsPersonData()
        {
            string tInfoTxt = "";
            tInfoTxt += base.ShowsPersonData() + "Adress: " + Adress + "\n";
            return tInfoTxt;
        }

    }
}
