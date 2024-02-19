using Ejercicio_1;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Exercise_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EmployeesList actualListOfEmployees = new EmployeesList();

        // ASKS THE DATA FROM THE EMPLOYEE TO ADD AND THEN ADD THIS OBJECT (PROPERTIES) TO THE LIST WITH EMPLOYEESLIST STRUCTURE
        private void IntroduceEmployeeData()
        {
            Employee anEmployee = new Employee();
            bool introduced = false;
            do
            {
                try
                {
                    string name = Interaction.InputBox("Introduce the employee's name: ");
                    if (!name.Any(char.IsDigit) && !string.IsNullOrWhiteSpace(name))
                    {
                        int age = int.Parse(Interaction.InputBox("Introduce the employee's age: "));
                        if (age > 16 && age <= 75)
                        {
                            actualListOfEmployees.AddEmployeeToList(name, age);
                            introduced = true;
                        }
                        else if (age < 16)
                        {
                            MessageBox.Show("The employee must be legally able to work, so it's age must be over 18");
                        }
                        else if (age > 75)
                        {
                            MessageBox.Show("Do you really think we're going to hire people which should be already retired? So funny!");
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("You must enter valid data to set the employee properties");
                }
            } while (!introduced);    
        }

        // BUTTON WHICH ADD A PERSON FROM THE FUNCTION INTRODUCE EMPLOYEE DATA
        private void btnIntroduceEmployee_Click(object sender, EventArgs e)
        {
            IntroduceEmployeeData();
        }

        // BUTTON WHICH SHOW ALL DATA STORED IN THE LIST, USING A FUNCTION INCLUDED IN EMPLOYEESLIST OBJECT
        private void brnShowData_Click(object sender, EventArgs e)
        {
            MessageBox.Show(actualListOfEmployees.ShowEmployeesList());
        }

        // BUTTON WHICH MAKES THE EMPLOYEE AGE A YEAR WHEN IT'S IT'S BIRTHDAY
        private void btnBirthday_Click(object sender, EventArgs e)
        {
            bool introduced = false;
            do
            {
                try
                {
                    string searchByName = Interaction.InputBox("Enter the name of the employee whose birthday is today");
                    if (!searchByName.Any(char.IsDigit) && !string.IsNullOrWhiteSpace(searchByName))
                    {
                        if (actualListOfEmployees.BirthdaySelection(searchByName))
                        {
                            MessageBox.Show("Happy Birthday " + searchByName + "!!!.");
                            introduced = true;
                        }
                        else
                        {
                            MessageBox.Show(searchByName + " is not working here or is not included in the list yet.");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("You must enter a valid name to set the employee's birthday");
                }
            } while (!introduced);
        }

        // BUTTON WHICH ADDS THE EMPLOYEE SALES
        private void btnAddSales_Click (object sender, EventArgs e)
        {
            bool introduced = false;
            do
            {
                try
                {
                    string searchByName = Interaction.InputBox("Enter the name of the employee who has a sale to add");
                    if (!searchByName.Any(char.IsDigit) && !string.IsNullOrWhiteSpace(searchByName))
                    {
                        double saleValue = double.Parse(Interaction.InputBox("Enter the value of the sale from the selected employee"));
                        if (actualListOfEmployees.SaleSelection(searchByName, saleValue))
                        {
                            MessageBox.Show(searchByName + " has made a sale of: " + saleValue + "€.");
                            introduced = true;
                        }
                        else
                        {
                            MessageBox.Show(searchByName + " is not working here or is not included in the list yet.");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("You must enter a valid name and value to set the employee's sales");
                }
            } while (!introduced);
        }
    }
}
