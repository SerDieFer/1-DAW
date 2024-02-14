using Ejercicio_1;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

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
                    string name = Interaction.InputBox("Introduce the day: ");
                    int age = int.Parse(Interaction.InputBox("Introduce the month: "));
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
            if (actualListOfEmployees.CountEmployeesList() != 0)
            {
                MessageBox.Show(actualListOfEmployees.ShowEmployeesList());
            }
            else
            { 
                MessageBox.Show("NULL");
            }
        }

        // 
        private void btnBirthday_Click(object sender, EventArgs e)
        {

        }

        // 
        private void btnAddSales_Click (object sender, EventArgs e)
        {

        }
    }
}
