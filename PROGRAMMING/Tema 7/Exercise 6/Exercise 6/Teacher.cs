using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_6
{
    class Teacher
    {
        private string tName;
        private int tID;
        private int tPhone;
        private List<string> tSubjectsList;
        private int tCourseMentorCod;

        public Teacher()
        {
            this.tName = "";
            this.tID = -1;
            this.tPhone = 0;
            this.tSubjectsList = new List<string>();
            this.tCourseMentorCod = -1;
        }
    }
}
