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
    public class User : TableRegistry
    {
        private string uName, uEmail, uPassword;

        public int ID
        {
            get;
            private set;
        }
        public string Name
        {
            get => uName;
            set => uName = value;
        }

        public string Password
        {
            get => uPassword;
            set => uPassword = value;
        }

        public string Email
        {
            get => uEmail;
            set => uEmail = value;
        }
        private User(string uName, string uPassword, string uEmail) : base(0)
        {
            Name = uName;
            Password = uPassword;
            Email = uEmail;
        }

        public static User UserCreation(string uName, string uPassword, string uEmail)
        {
            // RECALL TO CUSTOM REGEX WHICH CHECKS ALL THE INPUTS BEFORE INSERTING THEM INTO
            // THE ORIGINAL CONSTRUCTOR WHICH CREATES THE ACTUAL TEACHER WITHOUT ANY ERROR
            if (!CustomRegex.RegexName(uName) ||
                !CustomRegex.RegexPassword(uPassword) ||
                !CustomRegex.RegexEmail(uEmail))
            {
                return null;
            }
            else
            {
                return new User(uName,uPassword, uEmail);
            }
        }

        public string ShowsUserData()
        {
            string uInfoTxt = "Name: " + Name + "\nEmail: " + Email;
            return uInfoTxt;
        }
    }
}
