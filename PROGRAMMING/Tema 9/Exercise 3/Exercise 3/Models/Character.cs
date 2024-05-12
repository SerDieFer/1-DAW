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

namespace Exercise_3
{
    public class Character
    {
        private string cName, cImgRoute;

        // PROPERTIES
        public int ID
        {
            get;
            private set;
        }
        public string Name
        {
            get => cName;
            set => cName = value;
        }
        public string ImgRoute
        {
            get => cImgRoute;
            set => cImgRoute = value;
        }

        // CLASS CONSTRUCTOR
        private Character(string cName, string cImgRoute)
        {
            Name = cName;
            ImgRoute = cImgRoute;
        }

        // CLASS CONSTRUCTOR IN A STATIC WAY WHICH FIRST CHECKS THE NAME REGEX IS PERFECT BEFORE CREATING THE CHARACTER
        public static Character CharacterCreation(string cName, string cImgRoute)
        {
            // RECALL TO CUSTOM REGEX WHICH CHECKS ALL THE INPUTS BEFORE INSERTING THEM INTO
            // THE ORIGINAL CONSTRUCTOR WHICH CREATES THE ACTUAL CHARACTER WITHOUT ANY ERROR
            if (!CustomRegex.RegexName(cName))
            {
                return null;
            }
            else
            {
                return new Character(cName, cImgRoute);
            }
        }

        public string ShowCharacterData()
        {
            string cInfoTxt = "Name: " + Name + "\n";
            return cInfoTxt;
        }
    }
}
