using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Exercise_5
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

        // FUNCTION WHICH ADDS A SALE TO AN EMPLOYEE
        public void AddSales(double saleValue)
        {
            if(saleValue > 0)
            {
                eSalesList.Add(saleValue);
            }
        }

        // FUNCTION WHICH REMOVES A SALE TO AN EMPLOYEE
        public void RemoveSales(double saleValue)
        {
            if (saleValue > 0)
            {
                eSalesList.Remove(saleValue);
            }
        }

        // FUNCTION WHICH REMOVES ALL SALES TO AN EMPLOYEE
        public void ClearSales()
        {
            eSalesList.Clear();
        }

        // FUNCTION THAT ADDS ALL THE SALES FROM AN EMPLOYEE INTO A TOTAL
        public double SalesTotalValue()
        {
            double value = 0;
            if (SalesList.Count != 0)
            {
                for (int i = 0; i < SalesList.Count; i++)
                {
                    value += eSalesList[i];
                }
            }
            return value;
        }

        // FUNCTION THAT COUNTS ALL THE SALES FROM AN EMPLOYEE
        public int TotalSalesCount()
        {
            int count = 0;
            if (SalesList.Count != 0)
            {
                for(int i = 0; i < SalesList.Count; i++)
                {
                    count++;
                }
            }
            return count;
        }

        // FUNCTION THAT DETECTS IF THE SELECTED VALUE IS IN THE SALES LIST FROM A EMPLOYEE
        public bool SaleValueCheck(double saleValue)
        {
            bool saleCheck = true;
            if(!eSalesList.Contains(saleValue))
            {
                saleCheck = false;
            }
            return saleCheck;
        }

        // FUNCTION WHICH STORES A STRING WITH ALL THE INFO ABOUT THE SALESLIST FROM A POSITION WHICH WILL COINCIDE WITH SELECTED EMPLOYEE
        private string StoreSalesInfo ()
        {
            int counter = 0;
            double totalSales = 0;
            string salesTxt = "The sales from " + eName + " are: ";
            if (SalesList.Count != 0)
            {
                for (int i = 0; i < SalesList.Count; i++)
                {
                    if (counter < SalesList.Count - 1)
                    {
                            salesTxt += eSalesList[i] + " €, ";
                            totalSales += eSalesList[i];
                    }
                    else
                    {
                        salesTxt += eSalesList[i] + " €.\n";
                        totalSales += eSalesList[i];
                    }
                    counter++;
                }
                salesTxt += "And the total value of " + eName + "'s sales is: " + totalSales + " €.";
            }
            else
            {
                salesTxt = eName + " has not made any sale.";
            }
            return salesTxt;
        }
        // FUNCTION WHICH SHOWS ALL DATA FROM A SELECTED EMPLOYEE
        public string ShowSelectedEmployeeData(string name)
        {
            string eInfoTxt = "\nEmployee data: \n" + "Name: " + eName + "\n" + "Age: " + eAge + "\n\n";
            eInfoTxt += StoreSalesInfo() + "\n"; // THIS WILL ADD THE SELECTED EMPLOYEE INFO ABOUT THE SALES MADE.
            return eInfoTxt;
        }

        // FUNCTION WHICH SHOWS ALL EMPLOYEE INFO
        public string ShowAllEmployeeData()
        {
            string eInfoTxt = "\nEmployee data: \n" + "Name: " + eName + "\n" + "Age: " + eAge + "\n\n";
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
