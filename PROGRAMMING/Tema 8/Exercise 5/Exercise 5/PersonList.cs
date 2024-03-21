using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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

        // ALUMNS RELATED METHODS //


        public string ShowsAlumnsWhoseGradesAvgIsEqualOrBiggerThan5()
        {
            string gradesMoreThan5 = "The alumns with the grade equal or bigger than 5 are: \n\n";
            if (alumnList.Count != 0)
            {
                for (int i = 0; i < alumnList.Count; i++)
                {
                    if (alumnList[i].AlumnGradesAverage() >= 5 && SelectedAlumnHasGrades(alumnList[i].ID))
                    {
                        gradesMoreThan5 += alumnList[i].ShowsAlumnData() + "\n";
                    }
                }
            }
            return gradesMoreThan5;
        }

        // FUNCTION WHICH COUNTS HOW MANY ALUMNS HAS AN AVERAGE EQUAL OR MORE THAN A 5
        public int CountAlumnsWhoseGradeIsEqualOrBiggerThan5()
        {
            int alumnGradesMoreThan5 = 0;
            if (alumnList.Count != 0)
            {
                for (int i = 0; i < alumnList.Count; i++)
                {
                    if (alumnList[i].AlumnGradesAverage() >= 5 && SelectedAlumnHasGrades(alumnList[i].ID))
                    {
                        alumnGradesMoreThan5++;
                    }
                }
            }
            return alumnGradesMoreThan5;
        }

        // FUNCTION WHICH RETURNS ALL ALUMNS WHOSE AVERAGE GRADE IS LOWER THAN 5
        public string ShowsAlumnsWhoseGradesAvgIsLowerThan5()
        {
            string gradesLowerThan5 = "The alumns with the grade lower than 5 are: \n\n";
            if (alumnList.Count != 0)
            {
                for (int i = 0; i < alumnList.Count; i++)
                {
                    if (alumnList[i].AlumnGradesAverage() < 5 && SelectedAlumnHasGrades(alumnList[i].ID))
                    {
                        gradesLowerThan5 += alumnList[i].ShowsAlumnData() + "\n";
                    }
                }
            }
            return gradesLowerThan5;
        }

        // FUNCTION WHICH COUNTS HOW MANY ALUMNS HAS AN AVERAGE LOWER THAN A 5
        public int CountAlumnsWhoseGradeIsLowerThan5()
        {
            int alumnGradesLowerThan5 = 0;
            if (alumnList.Count != 0)
            {
                for (int i = 0; i < alumnList.Count; i++)
                {
                    if (alumnList[i].AlumnGradesAverage() < 5 && SelectedAlumnHasGrades(alumnList[i].ID))
                    {
                        alumnGradesLowerThan5++;
                    }
                }
            }
            return alumnGradesLowerThan5;
        }

        // FUNCTION WHICH RETURNS ALL ALUMNS WHO ARE IN THE SELECTED COURSE
        public string ShowAlumnsBySelectedCourseCod(int courseCod)
        {
            string alumnsInCourse = "The alumns in the course (" + courseCod + ") are: \n\n";
            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    if (((Alumn)personList[i]).CourseCod == courseCod)
                    {
                        alumnsInCourse += personList[i].ShowsPersonData() + "\n";
                    }
                }
            }
            return alumnsInCourse;
        }

        // FUNCTION THAT ORDERS ALUMNS IN ALPHABETICAL ORDER
        public void SortAlumnListAlphabetically()
        {
            Alumn auxAlumnList;
            for (int i = 0; i < alumnList.Count; i++)
            {
                for (int j = i + 1; j < alumnList.Count; j++)
                {
                    if (string.Compare(alumnList[i].Name, alumnList[j].Name) > 0)
                    {
                        auxAlumnList = alumnList[i];
                        alumnList[i] = alumnList[j];
                        alumnList[j] = auxAlumnList;
                    }
                }
            }
        }


        public bool AlumnInCourse(int aCourseCod)
        {
            bool alumnInCourse = false;

            for (int i = 0; i < personList.Count && !alumnInCourse; i++)
            {
                string personID = ReturnsPersonIDFromPosition(i);
                int personType = CheckTypeOfPerson(personID);

                // TYPE 0 IS ALUMN
                if (personType == 0)
                {
                    if (aCourseCod == ((Alumn)personList[i]).CourseCod)
                    {
                        alumnInCourse = true;
                    }
                }
            }
            return alumnInCourse;
        }

        public bool SelectedAlumnHasGrades(string aID)
        {
            bool hasGrades = false;
            int personType = CheckTypeOfPerson(aID);
            int personPosition = ReturnPersonPosition(aID);

            // TYPE 0 IS ALUMN
            if(personType == 0)
            { 
                if (((Alumn)personList[personPosition]).GradesList.Count() != 0)
                {
                    hasGrades = true;
                }
            }
            return hasGrades;
        }

        public int AlumnsWithGradesCounter()
        {
            int alumnsWithGrades = 0;
            for (int i = 0; i < personList.Count; i++)
            {
                string personID = ReturnsPersonIDFromPosition(i);
                int personType = CheckTypeOfPerson(personID);

                // TYPE 0 IS ALUMN
                if (personType == 0)
                {
                    if (((Alumn)personList[i]).GradesList.Count() > 0)
                    {
                        alumnsWithGrades++;
                    }
                }
            }
            return alumnsWithGrades;
        }

        // END ALUMN RELATED METHODS //

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

        public int CountTotalAlumns()
        {
            if (CountsTotalPersons() > 0)
            {
                int totalAlumns = 0;
                for(int i= 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(person.ID);

                    // TYPE 0 IS ALUMN
                    if (personType == 0)
                    {
                        if (((Alumn).GradesList.Count() > 0)
                        {
                            totalAlumns++;
                        }
                    }
                }
            }
        }
    }
}
