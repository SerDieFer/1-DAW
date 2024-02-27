using System;
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

        // FUNCTION WHICH ADDS A GRADE IN A CERTAIN COURSE TO A SELECTED ALUMN
        public void AddsSelectedAlumnGrade(int alumnName, int courseCod, double courseGrade)
        {
            if (courseGrade >= 0 && courseGrade <= 10)
            {
                aGradesList.Add(courseGrade);
            }
        }

        // FUNCTION WHICH REMOVES A GRADE IN A CERTAIN COURSE TO A SELECTED ALUMN
        public void RemovesSelectedAlumnGrade(int alumnName, int courseCod, double courseGrade)
        {
            if (courseGrade >= 0 && courseGrade <= 10)
            {
                aGradesList.Remove(courseGrade);
            }
        }

        // FUNCTION WHICH REMOVES ALL GRADES FROM AN ALUMN
        public void ClearGradesFromAlumn()
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
            string AllgradesTxt = "";
            string gradesTxt = "The grades from " + aName + " are: ";
            if (aGradesList.Count != 0)
            {
                for (int i = 0; i < aGradesList.Count; i++)
                {
                    gradesTxt += aGradesList[i] + "\n";
                }
                AllgradesTxt = "And the grades from " + aName + " are: " + gradesTxt;
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
            string aInfoTxt = "\nAlumn data: \n" + "Name: " + aName + "\n" + "ID: " + aID + "\n" + "Phone: " + aPhone + "\n\n";
            aInfoTxt += StoresAlumnGradesInfo() + "\n"; // THIS WILL ADD THE SELECTED ALUMN INFO ABOUT THE GRADES IT HAS MADE.
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
