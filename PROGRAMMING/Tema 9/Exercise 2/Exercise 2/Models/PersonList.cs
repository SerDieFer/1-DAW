using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_2
{
    public class PersonList
    {
        private List<Person> personList;

        public PersonList()
        {
            personList = new List<Person>();
        }

        // TEACHERS RELATED METHODS //

        public void AddsTeacher(string tName, string tSurnames, string tID, string tPhone, string tEmail)
        {
            Teacher newTeacher = Teacher.TeacherCreation(tName, tSurnames, tID, tPhone, tEmail);
            personList.Add(newTeacher);
        }

        public int RemovesTeacher(int teacherPosition)
        {
            string personID = ReturnsPersonIDFromPosition(teacherPosition);
            int personType = CheckTypeOfPerson(personID);

            // TYPE 1 IS A TEACHER
            if (personType == 1)
            {
                personList.RemoveAt(teacherPosition);
            }
            else
            {
                personType = 0;
            }
            return personType;
        }

        public string ShowsTeachersList()
        {
            string teacherListTxt = "List of teachers: \n\n";
            if (personList.Count != 0)
            {
                foreach (Person person in personList)
                {
                    int personType = CheckTypeOfPerson(person.ID);

                    // TYPE 1 IS A TEACHER
                    if (personType == 1)
                    {
                        teacherListTxt += ((Teacher)person).ShowsPersonData() + "\n";
                    }
                }
            }
            return teacherListTxt;
        }

        public string ShowsSelectedTeacherDataByID(string teacherID)
        {
            string teacherTxt = "";
            if (personList.Count != 0)
            {
                int personType = CheckTypeOfPerson(teacherID);

                // TYPE 1 IS A TEACHER
                if (personType == 1)
                {
                    int position = ReturnPersonPosition(teacherID);
                    if (position != -1)
                    {
                        teacherTxt = ((Teacher)personList[position]).ShowsPersonData();
                    }
                }
            }
            return teacherTxt;
        }


        public void SortListAlphabeticallyByTeacher()
        {
            Person auxPerson;
            for (int i = 0; i < personList.Count; i++)
            {
                for (int j = i + 1; j < personList.Count; j++)
                {
                    int firstPersonType = CheckTypeOfPerson(personList[i].ID);
                    int secondPersonTypeB = CheckTypeOfPerson(personList[j].ID);

                    // TYPE 1 IS A TEACHER
                    if (firstPersonType == 1 && secondPersonTypeB == 1)
                    {
                        if (string.Compare(personList[i].Name, personList[j].Name) > 0)
                        {
                            auxPerson = personList[i];
                            personList[i] = personList[j];
                            personList[j] = auxPerson;
                        }
                    }
                }
            }
        }

        public int CountsTotalTeachers()
        {
            int totalTeachers = 0;
            if (CountsTotalPersons() > 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);

                    // TYPE 1 IS A TEACHER
                    if (personType == 1)
                    {
                        totalTeachers++;
                    }
                }
            }
            return totalTeachers;
        }

        // END TEACHERS RELATED METHODS //

        public int GetPositionFromUniqueName(string pName)
        {
            int uniquePostion = 0;
            for (int i = 0; i < personList.Count; i++)
            {
                if (pName == personList[i].Name)
                {
                    uniquePostion = i;
                }
            }
            return uniquePostion;
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

        public bool AlreadyUsedPhone(string pPhone)
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


        public bool AlreadyUsedEmail(string pEmail)
        {
            bool used = false;
            for (int i = 0; i < personList.Count && !used; i++)
            {
                int personType = CheckTypeOfPerson(personList[i].ID);

                // TYPE 1 IS A TEACHER
                if (personType == 1)
                {
                    if (pEmail == ((Teacher)personList[i]).Email)
                    {
                        used = true;
                    }
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
            string pID = "";
            bool found = false;
            for (int i = 0; i < personList.Count && !found; i++)
            {
                if (pPosition == i)
                {
                pID = personList[i].ID;
                }
            }
            return pID;
        }

        public int CheckTypeOfPerson(string pID)
        {
            int personPosition = ReturnPersonPosition(pID);
            int personType = -1;

            if (personPosition != -1)
            {
                if (personList[personPosition].GetType() == typeof(Teacher))
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
