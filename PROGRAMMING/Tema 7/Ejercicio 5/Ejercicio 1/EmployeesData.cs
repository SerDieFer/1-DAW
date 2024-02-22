using Microsoft.VisualBasic;
using System;
using System.Linq;
using System.Reflection;
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

        /* THIS IS A FORMAT SETTING FUNCTION WHICH IS GOING TO BE USED TO LIMIT CHARACTERS ALLOWED 
         * (ALLOWS CHARACTERS FROM SPANISH ALPHABET EXCEPT SPECIAL CHARACTERS OR NULLS)
         * ASKED IVENS FOR INFO, AND CHECKED ON INTERNET VIA "https://regex101.com/"
         * TO ARCHIEVE SOMETHING SIMILAR TO THIS .Any(char.IsDigit) / .IsNullOrWhiteSpace()) ARE METHODS TO APPLY FOR EXAMPLE
         * BUT THIS METHOD IS SIMPLIER TO RECALL AND USE */
        public bool RegexFormatCheckerNumbers(string x)
        {
            /* THIS REGULAR EXPRESSION HAS THIS CONDITIONS:
             * ^: THIS SYMBOL DENOTES THE BEGINNING OF THE STRING.
             * 0-9 MATCHES A SINGLE CHARACTER IN THE RANGE BETWEEN 0 (INDEX 48) AND 9 (INDEX 57) (CASE SENSITIVE)
             * * $: THIS SYMBOL INDICATES THE END OF THE STRING AND ENDS UPPERCASE CONVERSION.
             * SO TO SUM UP, THIS SELECTS ONLY NUMBERS IN THE WHOLE STRING */

            string regexPattern = "^[0-9]+$";
            return new Regex(regexPattern).IsMatch(x);
        }
        public bool RegexFormatCheckerLetters(string x)
        {
            /* THIS REGULAR EXPRESSION HAS THIS CONDITIONS:
             * ^: THIS SYMBOL DENOTES THE BEGINNING OF THE STRING.
             * [A-ZÁ-Ý]+: IN THIS PART, WE USE \U TO BEGIN UPPERCASE CONVERSION, SPECIFYING THAT THE STRING MUST START WITH AT LEAST ONE LETTER OR ACCENTED CHARACTER. 
             * THE [A-ZÁ-Ý] PORTION ALLOWS BOTH UPPERCASE AND ACCENTED CHARACTERS FROM THE SPANISH ALPHABET.
             * ( \U[A-ZÁ-Ý]+)*: THIS SECTION ALLOWS ZERO OR MORE REPETITIONS OF A SPACE FOLLOWED BY ANOTHER WORD. 
             * WITHIN THE PARENTHESES ( ), WE HAVE \U TO CONTINUE UPPERCASE CONVERSION, A SPACE FOLLOWED BY THE SAME EXPRESSION [A-ZÁ-Ý]+
             * INDICATING THAT THERE CAN BE MULTIPLE WORDS SEPARATED BY A SINGLE SPACE.
             * $: THIS SYMBOL INDICATES THE END OF THE STRING AND ENDS UPPERCASE CONVERSION. 
             * SO TO SUM UP, THIS SELECTS ONLY LETTERS AND DIACRITICAL MARKS WHICH CAN BE SEPARATED BY A SINGLE SPACE IN THE WHOLE STRING */

            string regexPattern = "^[a-zA-Zá-ýÁ-Ý]+( [a-zA-Zá-ýÁ-Ý]+)*$";
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
                    string ageValue = Interaction.InputBox("Introduce the employee's age: ");
                    if (RegexFormatCheckerNumbers(ageValue))
                    {
                        int age = int.Parse(ageValue);
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
                    else
                    {
                        MessageBox.Show("The age format is not correct, try again");
                    }
                }
                else
                {
                    MessageBox.Show("The name format is not correct, try again");
                }
            } while (!introduced) ;
        }

        // BUTTON WHICH ADDS AN EMPLOYEE TO THE LIST
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
                        if (actualListOfEmployees.ReturnPosition(searchByName) != -1)
                        {
                            actualListOfEmployees.RemoveEmployeeFromList(searchByName);
                            MessageBox.Show(searchByName + " was removed from the list.");
                            introduced = true;
                        }
                        else
                        {
                            MessageBox.Show(searchByName + " is not working here or is not included in the list yet.");
                            introduced = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The name format is not correct, try again");
                    }

                } while (!introduced);
            }
            else
            {
                MessageBox.Show("Error, the list has not employees added, add an employee before removing an employee from the list.");
            }
        }

        // BUTTON WHICH SHOWS ALL DATA STORED FROM A SELECTED EMPLOYEE
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
                        if (actualListOfEmployees.ReturnPosition(searchByName) != -1)
                        {
                            MessageBox.Show(actualListOfEmployees.ShowSelectedEmployeeData(searchByName));
                            introduced = true;
                        }
                        else
                        {
                            MessageBox.Show(searchByName + " is not working here or is not included in the list yet.");
                            introduced = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The name format is not correct, try again");
                    }
                } while (!introduced);
            }
            else
            {
                MessageBox.Show("Error, the list has not employees added, add an employee before checking data from an employee of the list.");
            }
        }

        // BUTTON WHICH SHOWS ALL DATA STORED IN THE LIST OF EMPLOYEES
        private void btnShowData_Click(object sender, EventArgs e)
        {
            if (actualListOfEmployees.CountTotalEmployees() > 0)
            {
                MessageBox.Show(actualListOfEmployees.ShowsEmployeesList());
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
                        if (actualListOfEmployees.ReturnPosition(searchByName) != -1)
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
                            MessageBox.Show(searchByName + " does not work here or is not listed yet");
                            introduced = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The name format is not correct, try again");
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
                        if (actualListOfEmployees.ReturnPosition(searchByName) != -1)
                        {
                            if (actualListOfEmployees.EmployeeHasSales(searchByName))
                            {
                                string saleInput = Interaction.InputBox("Select the value of the sale which is going to be removed from the selected employee");
                                if (RegexFormatCheckerNumbers(saleInput))
                                {
                                    double saleValue = double.Parse(saleInput);
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
                                    MessageBox.Show("The sale format is not correct, try again");
                                }
                            }
                            else
                            {
                                MessageBox.Show(searchByName + " has not made any sale yet");
                                introduced = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show(searchByName + " does not work here or is not listed yet");
                            introduced = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The name format is not correct, try again");
                    }
                } while (!introduced);
            }
            else
            {
                MessageBox.Show("Error, the list has not employees added, add an employee before removing an employee's sales from the list.");
            }
        }

        // BUTTON WHICH CLEARS ALL SALES FROM A SELECTED EMPLOYEE
        private void btnRemoveAllSales_Click(object sender, EventArgs e)
        {
            if (actualListOfEmployees.CountTotalEmployees() > 0)
            {
                bool introduced = false;
                do
                {
                    string searchByName = Interaction.InputBox("Enter the name of the employee whose sale is going to be removed");
                    if (RegexFormatCheckerLetters(searchByName))
                    {
                        if (actualListOfEmployees.ReturnPosition(searchByName) != -1)
                        {
                            if (actualListOfEmployees.EmployeeHasSales(searchByName))
                            {
                                if (actualListOfEmployees.AllSalesRemoval(searchByName))
                                {
                                    MessageBox.Show("All sales have been removed from " + searchByName);
                                    introduced = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show(searchByName + " has not made any sale yet");
                                introduced = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show(searchByName + " does not work here or is not listed yet");
                            introduced = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The name format is not correct, try again");
                    }
                } while (!introduced);
            }
            else
            {
                MessageBox.Show("Error, the list has not employees added, add an employee before removing an employee's sales from the list.");
            }
        }

        // BUTTON WHICH SHOWS THE EMPLOYEE OR EMPLOYEES WITH GREATER SALES COUNT FROM THE LIST
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

        // BUTTON WHICH SORTS THE EMPLOYEES LIST BY ALPHABETICAL ORDER
        private void btnOrderEmployeesAlphabetically_Click(object sender, EventArgs e)
        {
            if (actualListOfEmployees.CountTotalEmployees() > 0 )
            {
                if (actualListOfEmployees.CountTotalEmployees() == 1)
                {
                    MessageBox.Show("Error, the list has only one employee, add atleast 2 employees to order the list");
                }
                else
                {
                    actualListOfEmployees.SortListAlphabetically();
                    MessageBox.Show("The list was correctly sorted by alphabetical order");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has not employees added, add an employee before ordering the employees list");
            }

        }

        // BUTTON WHICH SORTS THE EMPLOYEES LIST BY SALES TOTAL VALUE ORDER
        private void btnOrderEmployeesBySales_Click(object sender, EventArgs e)
        {
            if (actualListOfEmployees.CountTotalEmployees() > 0)
            {
                if (actualListOfEmployees.CountTotalEmployees() == 1)
                {
                    MessageBox.Show("Error, the list has only one employee, add atleast 2 employees to order the list");
                }
                else
                {
                    actualListOfEmployees.SortListBySales();
                    MessageBox.Show("The list was correctly sorted by total sales value order");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has not employees added, add an employee before ordering the employees list");
            }
        }
    }
}
