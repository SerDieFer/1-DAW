using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise_5
{
    public class Alumn : Person
    {
        private List<double> aGradesList;
        private int aCourseCod;

        public List<double> GradesList
        {
            get { return aGradesList; }
            set { aGradesList = value; }
        }

        public int CourseCod
        {
            get { return aCourseCod; }
            set { aCourseCod = value; }
        }

        public Alumn()
        {
            aGradesList = new List<double>();
            aCourseCod = -1;
        }

        public Alumn(string aName, string aID, int aPhone, List<double> aGrades,int aCourse) : base(aName, aID, aPhone)
        {
            GradesList = aGrades;
            CourseCod = aCourse;
        }

        public void AddsSelectedAlumnGrade(string alumnID, double grade)
        {
            if (grade >= 0 && grade <= 10)
            {
                aGradesList.Add(grade);
            }
        }

        public void RemovesSelectedAlumnGrade(string alumnID, double grade)
        {
            if (grade >= 0 && grade <= 10)
            {
                aGradesList.Remove(grade);
            }
        }

        public bool ChecksAlumnSelectedGrade(string alumnID, double grade)
        {
            bool exist = false;
            if (grade >= 0 && grade <= 10)
            {
                if (aGradesList.Contains(grade))
                {
                    exist = true;
                }
            }
            return exist;
        }

        public void ClearGradesFromAlumn(string alumnID)
        {
            aGradesList.Clear();
        }

        public double AlumnGradesAverage()
        {
            double alumnAVG = 0;
            if (aGradesList.Count != 0)
            {
                for (int i = 0; i < aGradesList.Count; i++)
                {
                    alumnAVG += aGradesList[i];
                }
                alumnAVG = alumnAVG / aGradesList.Count;
                alumnAVG = Math.Round(alumnAVG, 2);
            }
            return alumnAVG;
        }

        public string StoresAlumnGradesInfo()
        {
            int counter = 0;
            string AllgradesTxt = "";
            string gradesTxt = "";
            if (aGradesList.Count != 0)
            {
                for (int i = 0; i < aGradesList.Count; i++)
                {
                    if (counter < aGradesList.Count - 1)
                    {
                        gradesTxt += aGradesList[i] + " - ";
                    }
                    else
                    {
                        gradesTxt += aGradesList[i];
                    }
                    counter++;

                }
                string averageGrade = AlumnGradesAverage().ToString();
                AllgradesTxt = "And the grades from " + Name + " are:\n\n" + gradesTxt + "\n\nHaving a grade average of: " + averageGrade;
            }
            else
            {
                AllgradesTxt = Name + " has not any grade added.";
            }
            return AllgradesTxt;
        }

        public override string ShowsPersonData()
        {
            string aInfoTxt =  base.ShowsPersonData() + "\n" + "Course Cod: " + CourseCod + "\n";
            aInfoTxt += "\n" + StoresAlumnGradesInfo() + "\n";
            return aInfoTxt;
        }
    }
}
