
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Exercise_4
{
    class Employee
    {
        private string eName;
        private int eAge;
        private List<double> eSalesList;
        private int eID; // TODO

        // CONSTRUCTOR OF A EMPLOYEE
        public Employee()
        {
            this.eName = "";
            this.eAge = 0;
            this.eID = -1;
            this.eSalesList = new List<double>();
        }

        // FUNCTION WHICH ADDS A YEAR TO AN EMPLOYEE ACTUAL AGE (HAPPY BIRTHDAY!)
        public void EmployeeBirthday ()
        {
            eAge += 1;
        }

        // FUNCTION WHICH ADDS A SALE TO AN EMPLOYEE (NICE JOB!)
        public void AddSales(double saleValue)
        {
            if(saleValue > 0)
            {
                eSalesList.Add(saleValue);
            }
        }

        // FUNCTION WHICH STORES A STRING WITH ALL THE INFO ABOUT THE SALESLIST FROM A POSITION WHICH WILL COINCIDE WITH SELECTED EMPLOYEE
        private string StoreSalesInfo ()
        {
            string salesTxt = "The sales are: ";
            int counter = 0;
            if(SalesList.Count != 0)
            {
                for(int i = 0; i < SalesList.Count; i++)
                {
                    if (counter < SalesList.Count - 1)
                    {
                        salesTxt += eSalesList[i] + ", ";
                    }
                    else
                    {
                        salesTxt += eSalesList[i] + ".";
                    }
                    counter++;
                }
                salesTxt += "\n";
            }
            else
            {
                salesTxt = "This employee has not made any sale";
            }
            return salesTxt;
        }

        // FUNCTION WHICH SHOWS ALL EMPLOYEE INFO RECIEVED
        public string ShowAllEmployeeData()
        {
            string eInfoTxt = "\nEmployee data: \n" + "Name: " + eName + "\n" + "Age: " + eAge + "\n";
            eInfoTxt += StoreSalesInfo() + "\n"; // THIS WILL ADD THE SELECTED EMPLOYEE INFO ABOUT THE SALES MADE.
            return eInfoTxt;
        }

        // SETTER & GETTER FOR EMPLOYEE NAME
        public string Name
        {
            get { return eName; }
            set { eName = value; }
        }

        // SETTER & GETTER FOR EMPLOYEE AGE
        public int Age
        {
            get { return eAge; }
            set { eAge = value; }
        }

        // SETTER & GETTER FOR EMPLOYEE SALESLIST
        public List<double> SalesList
        {
            get { return eSalesList; }
            set { eSalesList = value; }
        }

        // SETTER & GETTER FOR EMPLOYEE ID // TODO
        public int ID
        {
            get { return eID; }
            set { eID = value; }
        }
    }
}


