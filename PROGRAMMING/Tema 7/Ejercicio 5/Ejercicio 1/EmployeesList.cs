using Exercise_5;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_5
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

        // FUNCTION WHICH REMOVES AN EMPLOYEE FROM THIS LIST
        public void RemoveEmployeeFromList(string name)
        {
            eList.RemoveAt(returnPosition(name));
        }

        // FUNCTION WHICH COLLECTS ALL DATA FROM THE SELECTED EMPLOYEE
        public string ShowSelectedEmployeeData(string name)
        {
            string eListTxt = "";
            if (eList.Count != 0)
            {
                    eListTxt += eList[returnPosition(name)].ShowAllEmployeeData();
            }
            return eListTxt;
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
            return eListTxt;
        }

        // FUNCTION THAT SELECTS AN EMPLOYEE FROM THE LIST AND ADDS A SALE
        public bool SaleAdding(string name, double value)
        {
            bool saleDone = false;
            if (eList.Count != 0)
            {
                int position = returnPosition(name);
                if (position != -1)
                {
                    if (value > 0)
                    {
                        eList[position].AddSales(value);
                        saleDone = true;
                    }
                }
            }
            return saleDone;
        }

        // FUNCTION THAT SELECTS AN EMPLOYEE FROM THE LIST AND REMOVES A SALE
        public bool SaleRemoval(string name, double value)
        {
            bool saleDone = false;
            if (eList.Count != 0)
            {
                int position = returnPosition(name);
                if (position != -1)
                {
                    if (value > 0)
                    {
                        eList[position].RemoveSales(value);
                        saleDone = true;
                    }
                }
            }
            return saleDone;
        }

        // FUNCTION THAT CHECKS IF THE SELECTED SALE EXIST IN THE EMPLOYEE SALES LIST
        public bool SaleValueNotFound(string name, double value)
        {
            bool saleFound = false;
            if (eList.Count != 0)
            {
                int position = returnPosition(name);
                if (position != -1)
                {
                    if (value > 0)
                    {
                        if (eList[position].SaleValueCheck(value))
                        {
                            saleFound = true;
                        }
                    }
                }
            }
            return saleFound;
        }

        // FUNCTION THAT CHECKS IF THE SELECTED SALE EXIST IN THE EMPLOYEE SALES LIST
        public bool EmployeeHasSales(string name)
        {
            bool hasSales = false;    
            if (eList.Count != 0)
            {
                int position = returnPosition(name);
                if (position != -1)
                {
                    if (eList[position].TotalSalesCount() > 0)
                    {
                        hasSales = true;
                    }
                }
            }
            return hasSales;
        }

        // FUNCTION THAT SELECTS THE EMPLOYEE WITH THE BIGGEST SALE
        public string BiggestSalesCountValue()
        {
            string biggestSale = "The employee with the biggest sales count is: ";
            if (eList.Count != 0)
            {
                double biggest = eList[0].SalesTotalValue();
                for (int i = 1; i < eList.Count; i++)
                {
                    if (biggest < eList[i].SalesTotalValue())
                    {
                        biggest = eList[i].SalesTotalValue();
                        biggestSale += eList[i].Name;
                    }
                }
            }
            return biggestSale;
        }

        // FUNCTION WHICH RETURNS THE POSITION OF THE EMPLOYEE IN THE LIST, IF IT'S NEGATIVE THE EMPLOYEE IS NOT IN THE LIST
        public int returnPosition(string name)
        {
            int index = -1;
            for (int i = 0; i < eList.Count; i++)
            {
                if (name == eList[i].Name)
                {
                    index = i;
                }
            }
            return index;
        }

        // FUNCTION WHICH RETURNS THE COUNT OF THE NUMBER OF EMPLOYEES IN THE LIST
        public int CountTotalEmployees()
        {
            int count = 0;
            for (int i = 0; i < eList.Count; i++)
            {
                count++;
            }
            return count;
        }

    }
}

