using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
