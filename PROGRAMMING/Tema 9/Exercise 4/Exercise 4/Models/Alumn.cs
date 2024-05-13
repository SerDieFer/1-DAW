using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4.Models
{
    public class Alumn : Person
    {
        private string aAdress;

        // PROPERTIES
        public string Adress
        {
            get => aAdress;
            set => aAdress = value;
        }

        // CLASS PRE-CONSTRUCTOR
        private Alumn(string aID, string aName, string aSurnames, string aPhone, string aAdress) : base(aID, aName, aSurnames, aPhone)
        {
            Adress = aAdress;
        }

        // CLASS CONSTRUCTOR
        public static Alumn AlumnCreation(string aID, string aName, string aSurnames, string aPhone, string aAdress)
        {
            // RECALL TO CUSTOM REGEX WHICH CHECKS ALL THE INPUTS BEFORE INSERTING THEM INTO
            // THE ORIGINAL CONSTRUCTOR WHICH CREATES THE ACTUAL TEACHER WITHOUT ANY ERROR
            if (!CustomRegex.RegexID(aID) ||
                !CustomRegex.RegexName(aName) ||
                !CustomRegex.RegexName(aSurnames) ||
                !CustomRegex.RegexPhone(aPhone))
            {
                return null;
            }
            else
            {
                return new Alumn(aID, aName, aSurnames, aPhone, aAdress);
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
