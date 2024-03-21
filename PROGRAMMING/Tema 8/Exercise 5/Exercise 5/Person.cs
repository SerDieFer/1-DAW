using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise_5
{
    abstract public class Person
    {
        private string pName;
        private string pID;
        private int pPhone;

        public string Name
        {
            get { return pName; }
            set { pName = value; }
        }
        public string ID
        {
            get { return pID; }
            set { pID = value; }
        }

        public int Phone
        {
            get { return pPhone; }
            set { pPhone = value; }
        }

        public Person()
        {
            pName = "";
            pID = "";
            pPhone = -1;
        }

        public Person(string pName, string pID, int pPhone)
        {
            pName = this.pName;
            pID = this.pID;
            pPhone = this.pPhone;
        }

        public virtual string ShowsPersonData()
        {
            var className = GetType().Name;
            string pInfoTxt = "";
            pInfoTxt = className + " data: \n" + "Name: " + Name + "\n" + "ID: " + ID + "\n" + "Phone: " + Phone + "\n";
            return pInfoTxt;
        }
    }
}
