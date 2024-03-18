using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise_5
{
    public class Course
    {
        private int cCourseCod;
        private string cCourseName;

        //FUNCTION WHICH GETS AND SETS THE COURSE NAME
        public string Name
        {
            get { return cCourseName; }
            set { cCourseName = value; }
        }

        //FUNCTION WHICH GETS AND SETS THE COURSE COD
        public int Cod
        {
            get { return cCourseCod; }
            set { cCourseCod = value; }
        }

        public Course()
        {
            cCourseCod = -1;
            cCourseName = "";
        }

        // FUNCTION WHICH SHOW ALL COURSE INFO
        public string ShowsCourseData()
        {
            string cInfoTxt = "\nCourse data: \n" + "Name: " + Name + "\n" + "Code: " + Cod + "\n";
            return cInfoTxt;
        }
    }
}
