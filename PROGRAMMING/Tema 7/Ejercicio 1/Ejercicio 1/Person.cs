
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Exercise_1
{
    class Person
    {
        private string pName;
        private int pAge;
        private string pPhone;
        private char pGender;
        private bool pMarried;

        // CONSTRUCTOR 
        public Person()
        {
            pName = "";
            pAge = 0;
            pPhone = "";
            pMarried = false;
        }

        public string ShowData()
        {
            string txt;
            txt = "Data of this person:\n";
            txt += "Name: " + pName + "\n";
            txt += "Age: " + pAge + "\n";
            txt += "Phone: " + pPhone + "\n";
            txt += "Gender: " + pGender + "\n";

            //txt += "Married " + (pMarried ? "Yes" : "No") + "\n"; -- FAST WAY?
            if (pMarried)
            {
                txt += "Married: Yes\n";
            }
            else
            {
                txt += "Married: No\n";
            }
            return txt;
        }

        public string Name
        {
            get { return pName; }
            set { pName = value; }
        }

        public int Age
        {
            get { return pAge; }
            set {
                if (value >= 0 && value <= 120)
                {
                    pAge = value;
                }
            }   
        }

        public string Phone
        {
            get { return pPhone; }
            set {
                if (value.All(char.IsDigit) && value.Length <= 9)
                {
                    pPhone = value;
                }
                else
                {
                    throw new ArgumentException("The phone number can only have a 9 digits maximum.");
                }
            }
        }

        public char Gender
        {
            get { return pGender; }
            set { 
                if (char.ToUpper(value) == 'M' || char.ToUpper(value) == 'F')
                { 
                    pGender = value; 
                }
                else
                {
                    throw new ArgumentException("You must select 'Male (M)' or 'Female (F)'.");
                }
            }             
        }

        public bool Married
        {
            get { return pMarried; }
            set {  pMarried = value; }
        }
    }
}

