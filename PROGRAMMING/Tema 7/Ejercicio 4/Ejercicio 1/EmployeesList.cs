using Exercise_4;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        
        // FUNCTION WHICH ADDS AN EMPLOYEE TO THIS LIST
        public void AddEmployeeToList(string name, int age)
        {
            // THIS CREATE THE OBJECT LISTS FROM EMPLOYEE CLASS
            Employee newEmployee = new Employee(); 

            newEmployee.Name = name;
            newEmployee.Age = age;

            // THIS ADDS THE NEW OBJECT CREATED WITH THE STRUCTURE OF THE SELECTED CLASS INTO THE LIST OF EMPLOYEES CLASS
            eList.Add(newEmployee); 
        }

        // FUNCTION WHICH COLLECTS ALL DATA FROM ALL THE EMPLOYEES ADDED INTO THE EMPLOYEES LIST
        public string ShowEmployeesList()
        {
            string eListTxt = "List of employees: \n";
            if (eList.Count != 0)
            {
                foreach (Employee employee in eList)
                {
                    eListTxt += employee.ShowAllEmployeeData();
                }
            }
            else
            {
                eListTxt = "Error, the list has not employees added, add an employee before showing the list.\n";
            }
            return eListTxt;
        }

        // FUNCTION THAT SELECTS AN EMPLOYEE WHICH BIRTHDAY IS TODAY
        public bool BirthdaySelection (string name)
        {
            bool birthday = false;
            int position = returnIndex(name);
            if (position != -1)
            {
                eList[position].EmployeeBirthday();
                birthday = true;
            }
            return birthday;
        }

        // FUNCTION THAT SELECTS AN EMPLOYEE FROM THE LIST AND ADDS HIM A SALE
        public bool SaleSelection(string name, double value)
        {
            bool saleDone = false;
            int position = returnIndex(name);
            if (position != -1)
            {
                eList[position].AddSales(value);
                saleDone = true;
            }
            return saleDone;
        }

        // FUNCTION WHICH RETURNS THE POSITION OF THE EMPLOYEE IN THE LIST, IF IT'S NEGATIVE THE EMPLOYEE IS NOT IN THE LIST
        public int returnIndex(string name)
        {
            int index = -1;
            for(int i = 0; i < eList.Count;i++)
            {
                if(name == eList[i].Name)
                {
                    index = i;
                }
            }
            return index;
        }
    }
}
