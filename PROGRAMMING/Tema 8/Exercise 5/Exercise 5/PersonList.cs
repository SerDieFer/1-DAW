using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5
{
    public class PersonList
    {
        private List<Person> personList;
        private List<Person> teacherList;
        private List<Person> alumnList;

        public PersonList()
        {
            personList = new List<Person>();
            teacherList = new List<Person>();
            alumnList = new List<Person>();
        }
    }
}
