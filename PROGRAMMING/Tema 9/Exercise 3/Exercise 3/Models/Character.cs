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
    public class Character : TableRegistry
    {
        private string cName, cImgRoute, cImgIconRoute;

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
        public string IconRoute
        {
            get => cImgIconRoute;
            set => cImgIconRoute = value;
        }

        // CLASS CONSTRUCTOR
        public Character(string cName, string cImgRoute, string cImgIconRoute) : base(1)
        {
            Name = cName;
            ImgRoute = cImgRoute;
            IconRoute = cImgIconRoute;
        }

        public string ShowCharacterData()
        {
            string cInfoTxt = "Name: " + Name + "\n";
            return cInfoTxt;
        }
    }
}
