using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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











    }
}
