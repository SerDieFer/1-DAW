using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5
{
    public class Teacher : Person
    {
        private List<string> tSubjectsList;
        private int tTutorCod;
        private string tEmail;

        public List<string> SubjectsList
        {
            get { return tSubjectsList; }
            set { tSubjectsList = value; }
        }

        public int TutorCod
        {
            get { return tTutorCod; }
            set { tTutorCod = value; }
        }

        public string Email
        {
            get { return tEmail; }
            set { tEmail = value; }
        }

        public Teacher()
        {
            tSubjectsList = new List<string>();
            tTutorCod = -1;
            tEmail = "";
        }

        public Teacher(string tName, string tID, int tPhone, List<string> tSubjects, int tTutorCod, string tEmail) : base(tName, tID, tPhone)
        {
            SubjectsList = tSubjects;
            TutorCod = tTutorCod;
            Email = tEmail;
        }

        public void AddsSelectedTeacherSubject(string teacherID, string subjectName)
        {
            tSubjectsList.Add(subjectName);
        }

        public void RemovesSelectedTeacherSubject(string teacherID, string subjectName)
        {
            tSubjectsList.Remove(subjectName);
        }

        public bool ChecksTeacherSelectedSubject(string teacherID, string subjectName)
        {
            bool exist = false;

            if (tSubjectsList.Contains(subjectName))
            {
                exist = true;
            }
            return exist;
        }

        public void ClearSubjectsFromTeacher(string teacherID)
        {
            tSubjectsList.Clear();
        }

        public string StoresTeacherSubjectsInfo()
        {
            int counter = 0;
            string AllSubjectsTxt = "";
            string subjectsTxt = "";
            if (tSubjectsList.Count != 0)
            {
                for (int i = 0; i < tSubjectsList.Count; i++)
                {
                    if (counter < tSubjectsList.Count - 1)
                    {
                        subjectsTxt += tSubjectsList[i] + " - ";
                    }
                    else
                    {
                        subjectsTxt += tSubjectsList[i];
                    }
                    counter++;

                }
                AllSubjectsTxt = "And the subjects from " + Name + " are:\n\n" + subjectsTxt; ;
            }
            else
            {
                AllSubjectsTxt = Name + " has not any subject added.";
            }
            return AllSubjectsTxt;
        }

        public override string ShowsPersonData()
        {
            string tInfoTxt = "";
            if (TutorCod == -1)
            {
                tInfoTxt += base.ShowsPersonData() + "Email: " + Email + "\n\n" + StoresTeacherSubjectsInfo() + "\n";
            }
            else
            {
                tInfoTxt = tInfoTxt += base.ShowsPersonData() + "Email: " + Email + "\n" + "Mentor Course Cod: " + TutorCod + "\n\n" + StoresTeacherSubjectsInfo() + "\n";
            }
            return tInfoTxt;
        }

    }
}
