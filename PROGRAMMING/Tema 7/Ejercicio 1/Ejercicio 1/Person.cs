using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise_1
{
    class Person
    {
        private string pName;
        private int pAge;
        private int pPhone;
        private string pGender;
        private string pMarried;

        // CONSTRUCTOR 
        public Person(string name, int age, int phone, string gender, string married)
        {
            pName = name;
            pAge = age;

            // PHONE VALIDATION
            if (phone >= 0 && phone <= 999999999)
            {
                pPhone = phone;
            }
            else
            {
                throw new ArgumentException("The phone number can only have a 9 digits maximum.");
            }

            // GENDER VALIDATION (MALE OR FEMALE)
            if (gender.ToLower() == "male" || gender.ToLower() == "female")
            {
                pGender = gender.ToLower();
            }
            else
            {
                throw new ArgumentException("You must select 'male' or 'female'.");
            }

            // CIVIL STATUS VALIDATION
            if (married.ToLower() == "yes" || married.ToLower() == "no")
            {
                pMarried = married.ToLower();
            }
            else
            {
                throw new ArgumentException("The civil status must be selected with 'yes' or 'no'.");
            }
        }

        public string ShowData()
        {
            string txt;
            txt = "Data of this person:\n";
            txt += "Name: " + pName + "\n";
            txt += "Age: " + pAge + "\n";
            txt += "Phone: " + pPhone + "\n";
            txt += "Gender: " + pGender + "\n";
            txt += "Married: " + pMarried + "\n";
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
            set { pAge = value; }
        }

        public int Phone
        {
            get { return pPhone; }
            set { pPhone = value; }
        }

        public string Gender
        {
            get { return pGender; }
            set { pGender = value; }
        }

        public string Married
        {
            get { return pMarried; }
            set { pMarried = value; }
        }
    }
}
