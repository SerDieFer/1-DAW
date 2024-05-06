using Exercise_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Exercise_3
{
    public class User
    {
        private string uName, uEmail, uPassword;

        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get => uName;
            set => uName = value;
        }

        public string Email
        {
            get => uEmail;
            set => uEmail = value;
        }

        public string Password
        {
            get => uPassword;
            set => uPassword = value;
        }

        private User(string uName, string uEmail, string uPassword)
        {
            Name = uName;
            Email = uEmail;
            Password = uPassword;
        }

        public static User UserCreation(string uName, string uEmail, string uPassword)
        {
            // RECALL TO CUSTOM REGEX WHICH CHECKS ALL THE INPUTS BEFORE INSERTING THEM INTO
            // THE ORIGINAL CONSTRUCTOR WHICH CREATES THE ACTUAL TEACHER WITHOUT ANY ERROR
            if (!CustomRegex.RegexName(uName) ||
                !CustomRegex.RegexEmail(uEmail) ||
                !CustomRegex.RegexPassword(uPassword))   
            {
                return null;
            }
            else
            {
                return new User(uName, uEmail, uPassword);
            }
        }

        public string ShowsUserData()
        {
            string uInfoTxt = "Name: " + Name + "\nEmail: " + Email;
            return uInfoTxt;
        }
    }
}
