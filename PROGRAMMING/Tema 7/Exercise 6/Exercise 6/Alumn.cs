using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise_6
{
    class Alumn
    {
        private string aName;
        private string aID;
        private int aPhone;
        private List<double> aGradesList;
        private int aCourseCod;

        public Alumn()
        {
            this.aName = "";
            this.aID = "";
            this.aPhone = 0;
            this.aGradesList = new List<double>();
            this.aCourseCod = -1;
        }

        // FUNCTION WHICH ADDS A GRADE TO A SELECTED ALUMN
        public void AddsSelectedAlumnGrade(string alumnID, double grade)
        {
            if (grade >= 0 && grade <= 10)
            {
                aGradesList.Add(grade);
            }
        }

        // FUNCTION WHICH REMOVES A GRADE TO A SELECTED ALUMN
        public void RemovesSelectedAlumnGrade(string alumnID, double grade)
        {
            if (grade >= 0 && grade <= 10)
            {
                aGradesList.Remove(grade);
            }
        }

        // FUNCTION WHICH RETURNS A BOOLEAN IF A SELECTED ALUMN HAS THE SELECTED GRADE
        public bool ChecksAlumnSelectedGrade(string alumnID, double grade)
        {
            bool exist = false;
            if (grade >= 0 && grade <= 10)
            {
                if(aGradesList.Contains(grade))
                {
                    exist = true;
                }
            }
            return exist;
        }

        // FUNCTION WHICH REMOVES ALL GRADES FROM AN ALUMN
        public void ClearGradesFromAlumn(string alumnID)
        {
            aGradesList.Clear();
        }

        //FUNCTION WHICH RETURNS THE AVERAGE FROM IT'S GRADES
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
            }
            return alumnAVG;
        }

        // FUNCTION WHICH STORES A STRING WITH ALL THE INFO ABOUT THE GRADES LIST FROM A POSITION WHICH WILL COINCIDE WITH SELECTED ALUMN
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
                AllgradesTxt = "And the grades from " + aName + " are:\n\n" + gradesTxt + "\n\nHaving a grade average of: " + averageGrade;
            }
            else
            {
                AllgradesTxt = aName + " has not any grade added.";
            }
            return AllgradesTxt;
        }

        // FUNCTION WHICH SHOW ALL ALUMN INFO
        public string ShowsAlumnData()
        {
            string aInfoTxt = "Alumn data: \n" + "Name: " + aName + "\n" + "ID: " + aID + "\n" + "Phone: " + aPhone+ "\n" + "Course Cod: " + aCourseCod + "\n";
            aInfoTxt += "\n" + StoresAlumnGradesInfo() + "\n"; // THIS WILL ADD THE SELECTED ALUMN INFO ABOUT THE GRADES IT HAS MADE.
            return aInfoTxt;
        }

        // FUNCTION WHICH SHOW SIMPLIER ALUMN INFO
        public string ShowsSimplierAlumnData()
        {
            string aInfoTxt = "Alumn data: \n" + "Name: " + aName + "\n" + "ID: " + aID + "\n";
            return aInfoTxt;
        }

        //FUNCTION WHICH GETS AND SETS THE ALUMN NAME
        public string Name
        {
            get { return aName; }
            set { aName = value; }
        }
        //FUNCTION WHICH GETS AND SETS THE ALUMN ID
        public string ID
        {
            get { return aID; }
            set { aID = value; }
        }

        //FUNCTION WHICH GETS AND SETS THE ALUMN PHONE
        public int Phone
        {
            get { return aPhone; }
            set { aPhone = value; }
        }

        //FUNCTION WHICH GETS AND SETS THE ALUMN GRADES
        public List<double> Grades
        {
            get { return aGradesList; }
            set { aGradesList = value; }
        }

        //FUNCTION WHICH GETS AND SETS THE ALUMN COURSE COD
        public int CourseCod
        {
            get { return aCourseCod; }
            set { aCourseCod = value; }
        }
    }
}
