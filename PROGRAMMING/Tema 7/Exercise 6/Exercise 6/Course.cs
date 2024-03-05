using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace Exercise_6
{
    class Course
    {
        private string cName;
        private int cCod;

        public Course()
        {
            this.cName = "";
            this.cCod = -1;
        }

        // FUNCTION WHICH SHOW ALL COURSE INFO
        public string ShowsCourseData()
        {
            string cInfoTxt = "\nCourse data: \n" + "Name: " + cName + "\n" + "Code: " + cCod + "\n";
            return cInfoTxt;
        }

        //FUNCTION WHICH GETS AND SETS THE COURSE NAME
        public string Name
        {
            get { return cName; }
            set { cName = value; }
        }
        //FUNCTION WHICH GETS AND SETS THE COURSE CODE
        public int Cod
        {
            get { return cCod; }
            set { cCod = value; }
        }
    }
}
