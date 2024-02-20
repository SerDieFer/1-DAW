﻿using Microsoft.VisualBasic;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Exercise_5
{
    public partial class EmployeesData : Form
    {
        public EmployeesData()
        {
            InitializeComponent();
        }

        // CREATION OF THE LIST OF EMPLOYEES 
        EmployeesList actualListOfEmployees = new EmployeesList();

        /* THIS IS A FORMAT SETTING  FUNCTION WHICH IS GOING TO BE USED TO LIMIT CHARACTERS ALLOWED 
         * (ALLOWS CHARACTERS FROM SPANISH ALPHABET EXCEPT SPECIAL CHARACTERS OR NULLS)
         * ASKED IVENS FOR INFO, AND CHECKED ON INTERNET VIA "https://regex101.com/"
         * TO ARCHIEVE SOMETHING SIMILAR TO THIS .Any(char.IsDigit) / .IsNullOrWhiteSpace()) ARE METHODS TO APPLY FOR EXAMPLE
         * BUT THIS METHOD IS SIMPLIER TO RECALL AND USE */
        public bool RegexFormatCheckerNumbers(string x)
        {
            string regexPattern = "^[0-9]";
            return new Regex(regexPattern).IsMatch(x);
        }
        public bool RegexFormatCheckerLetters(string x)
        {
            string regexPattern = "^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]*$";
            return new Regex(regexPattern).IsMatch(x);
        }

        // ASKS THE DATA FROM THE EMPLOYEE TO ADD AND THEN ADD THIS OBJECT (PROPERTIES) TO THE LIST WITH EMPLOYEESLIST STRUCTURE
        private void IntroduceEmployeeData()
        {
            Employee anEmployee = new Employee();
            bool introduced = false;
            do
            {
                string name = Interaction.InputBox("Introduce the employee's name: ");
                if (RegexFormatCheckerLetters(name))
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
            } while (!introduced) ;
        }

        // BUTTON WHICH ADD A PERSON FROM THE FUNCTION INTRODUCE EMPLOYEE DATA
        private void btnIntroduceEmployee_Click(object sender, EventArgs e)
        {
            IntroduceEmployeeData();
        }

        // BUTTON WHICH REMOVES A SELECTED EMPLOYEE FROM THE LIST OF EMPLOYEES
        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            if (actualListOfEmployees.CountTotalEmployees() > 0)
            {
                bool introduced = false;
                do
                {
                    string searchByName = Interaction.InputBox("Enter the name of the employee whose data is going to be removed");
                    if (RegexFormatCheckerLetters(searchByName))
                    {
                        if (actualListOfEmployees.returnPosition(searchByName) != -1)
                        {
                            actualListOfEmployees.RemoveEmployeeFromList(searchByName);
                            MessageBox.Show(searchByName + " was removed from the list.");
                            introduced = true;
                        }
                        else
                        {
                            MessageBox.Show(searchByName + " is not working here or is not included in the list yet.");
                        }
                    }
                    
                } while (!introduced);
            }
            else
            {
                MessageBox.Show("Error, the list has not employees added, add an employee before removing an employee from the list.");
            }
        }

        // BUTTON WHICH SHOW ALL DATA STORED FROM A SELECTED EMPLOYEE
        private void btnShowEmployeeData_Click(object sender, EventArgs e)
        {
            if (actualListOfEmployees.CountTotalEmployees() > 0)
            {
                bool introduced = false;
                do
                {
                    string searchByName = Interaction.InputBox("Enter the name of the employee whose data is required: ");
                    if (RegexFormatCheckerLetters(searchByName))
                    {
                        if (actualListOfEmployees.returnPosition(searchByName) != -1)
                        {
                            MessageBox.Show(actualListOfEmployees.ShowSelectedEmployeeData(searchByName));
                            introduced = true;
                        }
                        else
                        {
                            MessageBox.Show(searchByName + " is not working here or is not included in the list yet.");
                        }
                    }
                } while (!introduced);
            }
            else
            {
                MessageBox.Show("Error, the list has not employees added, add an employee before checking data from an employee of the list.");
            }
        }

        // BUTTON WHICH SHOW ALL DATA STORED IN THE LIST OF EMPLOYEES
        private void btnShowData_Click(object sender, EventArgs e)
        {
            if (actualListOfEmployees.CountTotalEmployees() > 0)
            {
                MessageBox.Show(actualListOfEmployees.ShowEmployeesList());
            }
            else
            {
                MessageBox.Show("Error, the list has not employees added, add an employee before showing the employees list.");
            }
        }

        // BUTTON WHICH ADDS TO A CERTAIN EMPLOYEE THE SELECTED SALES
        private void btnAddSales_Click (object sender, EventArgs e)
        {
            if (actualListOfEmployees.CountTotalEmployees() > 0)
            {
                bool introduced = false;
                do
                {
                    string searchByName = Interaction.InputBox("Enter the name of the employee who has a sale to add");
                    if (RegexFormatCheckerLetters(searchByName))
                    {
                        if (actualListOfEmployees.returnPosition(searchByName) != -1)
                        {
                            string valueInput = (Interaction.InputBox("Enter the value of the sale from the selected employee"));
                            if (RegexFormatCheckerNumbers(valueInput))
                            {
                                double saleValue = double.Parse(valueInput);
                                if (actualListOfEmployees.SaleAdding(searchByName, saleValue))
                                {
                                    MessageBox.Show(searchByName + " has made a sale of: " + saleValue + "€.");
                                    introduced = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid sale value. Please enter a valid numeric value.");
                            }
                        }
                        else
                        {
                            MessageBox.Show(searchByName + " is not working here or is not included in the list yet.");
                        }
                    }
                } while (!introduced);
            }
            else
            {
                MessageBox.Show("Error, the list has not employees added, add an employee before adding sales to a selected employee.");
            }
        }

        // BUTTON WHICH REMOVES FROM THE SELECTED EMPLOYEE THE SELECTED SALES
        private void btnRemoveSales_Click(object sender, EventArgs e)
        {
            if (actualListOfEmployees.CountTotalEmployees() > 0)
            {
                bool introduced = false;
                do
                {
                    string searchByName = Interaction.InputBox("Enter the name of the employee whose sale is going to be removed");
                    if (RegexFormatCheckerLetters(searchByName))
                    {
                        if (actualListOfEmployees.returnPosition(searchByName) != -1)
                        {
                            if (actualListOfEmployees.EmployeeHasSales(searchByName))
                            { 
                                double saleValue = double.Parse(Interaction.InputBox("Select the value of the sale which is going to be removed from the selected employee"));
                                if (actualListOfEmployees.SaleValueNotFound(searchByName, saleValue))
                                {
                                    if (actualListOfEmployees.SaleRemoval(searchByName, saleValue))
                                    {
                                        MessageBox.Show(searchByName + " has a sale removed with a value of: " + saleValue + "€.");
                                        introduced = true;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(searchByName + " has no sales for this amount (" + saleValue + "€)");
                                }
                            }
                            else
                            {
                                MessageBox.Show(searchByName + " has not made any sale");
                                introduced = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show(searchByName + " does not work here or is not listed yet");
                            introduced = true;
                        }
                    }
                } while (!introduced);
            }
            else
            {
                MessageBox.Show("Error, the list has not employees added, add an employee before removing an employee's sales from the list.");
            }
        }

        // BUTTON WHICH SHOW THE EMPLOYEE WITH GREATER SALES COUNT FROM THE LIST
        private void btnShowEmployeeGreatestSales_Click(object sender, EventArgs e)
        {
            if (actualListOfEmployees.CountTotalEmployees() > 0)
            {
                MessageBox.Show(actualListOfEmployees.BiggestSalesCountValue());
            }
            else
            {
                MessageBox.Show("Error, the list has not employees added, add an employee before showing the employee with greater sales count.");
            }
        }

    }
}
