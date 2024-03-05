using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise_6
{
    class Teacher
    {
        private string tName;
        private string tID;
        private int tPhone;
        private List<string> tSubjectsList;
        private int tCourseMentorCod;

        public Teacher()
        {
            this.tName = "";
            this.tID = "";
            this.tPhone = 0;
            this.tSubjectsList = new List<string>();
            this.tCourseMentorCod = -1;
        }

        // FUNCTION WHICH ADDS A SUBJECT TO A SELECTED TEACHER
        public void AddsSelectedTeacherSubject(string teacherID, string subjectName)
        {
            tSubjectsList.Add(subjectName);
        }

        // FUNCTION WHICH REMOVES A SUBJECT TO A SELECTED TEACHER
        public void RemovesSelectedTeacherSubject(string teacherID, string subjectName)
        {
            tSubjectsList.Remove(subjectName);
        }

        // FUNCTION WHICH RETURNS A BOOLEAN IF A SELECTED TEACHER HAS THE SELECTED SUBJECT
        public bool ChecksTeacherSelectedSubject(string teacherID, string subjectName)
        {
            bool exist = false;

            if (tSubjectsList.Contains(subjectName))
            {
                exist = true;
            }
            return exist;
        }

        // FUNCTION WHICH REMOVES ALL SUBJECTS FROM A TEACHER
        public void ClearSubjectsFromTeacher(string teacherID)
        {
            tSubjectsList.Clear();
        }

        // FUNCTION WHICH STORES A STRING WITH ALL THE INFO ABOUT THE SUBJECTS LIST FROM A POSITION WHICH WILL COINCIDE WITH SELECTED TEACHER
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
                AllSubjectsTxt = "And the subjects from " + tName + " are:\n\n" + subjectsTxt; ;
            }
            else
            {
                AllSubjectsTxt = tName + " has not any subject added.";
            }
            return AllSubjectsTxt;
        }

        // FUNCTION WHICH SHOW ALL TEACHER INFO
        public string ShowsTeacherData()
        {
            string tInfoTxt = "";
            if (tCourseMentorCod == -1)
            {
                tInfoTxt = "Teacher data: \n" + "Name: " + tName + "\n" + "ID: " + tID + "\n" + "Phone: " + tPhone + "\n";
                tInfoTxt += "\n" + StoresTeacherSubjectsInfo() + "\n";
            }
            else
            {
                tInfoTxt = "Teacher data: \n" + "Name: " + tName + "\n" + "ID: " + tID + "\n" + "Phone: " + tPhone + "\n" + "Mentor Course Cod: " + tCourseMentorCod + "\n";
                tInfoTxt += "\n" + StoresTeacherSubjectsInfo() + "\n";
            }
            // THIS WILL ADD THE SELECTED TEACHER INFO ABOUT THE SUBJECTS IT IMPARTS.
            return tInfoTxt;
        }

        // FUNCTION WHICH SHOW SIMPLIER TEACHER INFO
        public string ShowsSimplierTeacherData()
        {
            string tInfoTxt = "Teacher data: \n" + "Name: " + tName + "\n" + "ID: " + tID + "\n";
            return tInfoTxt;
        }

        //FUNCTION WHICH GETS AND SETS THE TEACHER NAME
        public string Name
        {
            get { return tName; }
            set { tName = value; }
        }
        //FUNCTION WHICH GETS AND SETS THE TEACHER ID
        public string ID
        {
            get { return tID; }
            set { tID = value; }
        }

        //FUNCTION WHICH GETS AND SETS THE TEACHER PHONE
        public int Phone
        {
            get { return tPhone; }
            set { tPhone = value; }
        }

        //FUNCTION WHICH GETS AND SETS THE TEACHER SUBJECTS
        public List<string> Subjects
        {
            get { return tSubjectsList; }
            set { tSubjectsList = value; }
        }

        //FUNCTION WHICH GETS AND SETS THE COURSE COD WHERE THE TUTOR IS THE TEACHER
        public int CourseMentorCod
        {
            get { return tCourseMentorCod; }
            set { tCourseMentorCod = value; }
        }
    }
}
