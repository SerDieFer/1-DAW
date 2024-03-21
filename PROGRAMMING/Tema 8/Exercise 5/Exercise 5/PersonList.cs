using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5
{
    public class PersonList
    {
        private List<Person> personList;

        public PersonList()
        {
            personList = new List<Person>();
        }

        public bool AlreadyUsedID(string pID)
        {
            bool used = false;
            for (int i = 0; i < personList.Count && !used; i++)
            {
                if (pID == personList[i].ID)
                {
                    used = true;
                }
            }
            return used;
        }

        public bool AlreadyUsedPhone(int pPhone)
        {
            bool used = false;
            for (int i = 0; i < personList.Count && !used; i++)
            {
                if (pPhone == personList[i].Phone)
                {
                    used = true;
                }
            }
            return used;
        }

        public string ReturnsPersonName(string pID)
        {
            string alumnName = "";
            bool found = false;
            for (int i = 0; i < personList.Count && !found; i++)
            {
                if (pID == personList[i].ID)
                {
                    alumnName = personList[i].Name;
                }
            }
            return alumnName;
        }

        public int ReturnPersonPosition(string pID)
        {
            int position = -1;
            bool found = false;

            for (int i = 0; i < personList.Count && !found; i++)
            {
                if (personList[i].ID == pID)
                {
                    position = i;
                    found = true;
                }
            }
            return position;
        }

        public string ReturnsPersonIDFromPosition(int pPosition)
        {
            string alumnID = "";
            bool found = false;
            for (int i = 0; i < personList.Count && !found; i++)
            {
                if (pPosition == i)
                {
                    alumnID = personList[i].ID;
                }
            }
            return alumnID;
        }

        public int CheckTypeOfPerson(string pID)
        {
            int personPosition = ReturnPersonPosition(pID);
            int personType = -1;

            if (personPosition != -1)
            {
                if (personList[personPosition].GetType() == typeof(Alumn))
                {
                    personType = 0;
                }
                else if (personList[personPosition].GetType() == typeof(Teacher))
                {
                    personType = 1;
                }
            }
            return personType;
        }

        public int CountsTotalPersons()
        {
            return personList.Count;
        }
    }
}
