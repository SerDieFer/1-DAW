using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Exercise_2
{
    abstract public class Person
    {
        private string pID;
        private string pName;
        private string pSurnames;
        private string pPhone;

        public string ID
        {
            get => pID;
            set => pID = value;
        }
        public string Name
        {
            get => pName;
            set => pName = value;
        }

        public string Surnames
        {
            get => pSurnames;
            set => pSurnames = value;
        }
        public string Phone
        {
            get => pPhone;
            set => pPhone = value;
        }

        public Person()
        {
            pID = "";
            pName = "";
            pSurnames = "";
            pPhone = "";
        }

        public Person(string pID, string pName, string pSurnames, string pPhone)
        {
            pID = this.pID;
            pName = this.pName;
            pSurnames = this.pSurnames;
            pPhone = this.pPhone;
        }

        public virtual string ShowsPersonData()
        {
            var className = GetType().Name;
            string pInfoTxt = "";
            pInfoTxt = className
                       + " data: \n"
                       + "Name: " + Name + "\n" 
                       + "Surnames: " + Name + "\n"
                       + "ID: " + ID + "\n"
                       + "Phone: " + Phone + "\n";
            return pInfoTxt;
        }

        public string ShowsSimplierPersonData()
        {
            var className = GetType().Name;
            string pInfoTxt = "";
            pInfoTxt = className
                       + " data: \n"
                       + "Name: " + Name + "\n"
                       + "Surnames: " + Name + "\n"
                       + "ID: " + ID + "\n";
            return pInfoTxt;
        }
    }
}
