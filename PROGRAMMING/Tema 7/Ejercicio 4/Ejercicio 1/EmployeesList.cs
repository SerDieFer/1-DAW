using Exercise_4;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1
{
    class EmployeesList
    {
        private List<Employee> eList;

        // CONSTRUCTOR OF A EMPLOYEES LIST
        public EmployeesList()
        {
            // ALWAYS CREATE A NEW LIST BASED IN THIS OBJECT (EMPLOYEES LIST) WHICH WILL TAKE PROPERTIES FROM EMPLOYEE CLASS
            eList = new List<Employee>();
        }
        
        // FUNCTION WHICH ADD EMPLOYEE TO THIS LIST
        public void AddEmployeeToList(string name, int age)
        {
            // THIS CREATE THE OBJECT LISTS FROM EMPLOYEE CLASS
            Employee newEmployee = new Employee(); 

            newEmployee.Name = name;
            newEmployee.Age = age;

            // THIS ADDS THE NEW OBJECT CREATED WITH THE STRUCTURE OF THE SELECTED CLASS INTO THE LIST OF EMPLOYEES CLASS
            eList.Add(newEmployee); 
        }

        // THIS COLLECTS ALL DATA FROM ALL THE EMPLOYEES ADDED INTO THE EMPLOYEES LIST
        public string ShowEmployeesList ()
        {
            string eListTxt = "List of employees: \n";
            foreach(Employee employee in eList)
            {
                eListTxt += employee.ShowAllEmployeeData();
            }
            return eListTxt;
        }









    }
}
