using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5
{
    abstract public class Person
    {
        private string pName;
        private string pID;
        private int pPhone;

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







    }
}
