﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Exercise_4 : Form
    {
        public Exercise_4()
        {
            InitializeComponent();
        }

        private void Exercise_4_Load(object sender, EventArgs e)
        {

        }

        // BASE LIST
        List<int> baseList = new List<int>();
        // EXPONENTIAL LIST
        List<int> exponentialList = new List<int>();
        // RESULT LIST
        List<int> resultsList = new List<int>();

        // LIST ELEMENTS COUNTER 
        private int listSize(List<int> list)
        {
            int size = list.Count;
            return size;
        }

        // POWER NUMBER
        private int powerNumbers(int baseNum, int exponentialNum)
        {
            int result = 1;

            for (int i = 1; i <= exponentialNum ; i++)
            {
                result *= baseNum; 
            }
            return result;
        }   

        // CALCULATE RESULTS OF POWERED NUMBERS INTO NEW LIST
        private void calculatePoweredList(List<int> baseList, List<int> exponentialList, List<int> resultsList)
        {
            resultsList.Clear();
            for (int i = exponentialList.Count - 1; i >= 0; i--)
            {
                int powered = powerNumbers(baseList[i], exponentialList[i]);
                resultsList.Add(powered);
            }
        }

        // ADD NUMBERS TO LIST
        private void addValuesToList(List<int> list) 
        {
            try
            {
                DialogResult more;
                int value;
                do
                {
                    value = int.Parse(Interaction.InputBox("Enter the value you want to add", "Add Value"));
                    list.Add(value);
                    MessageBox.Show("The number (" + value + ") has been added to the list");
                    more = MessageBox.Show("Do you want to enter another value?", "Value", MessageBoxButtons.YesNo);
                } while (more == DialogResult.Yes);
                check = false;
            }
            catch (FormatException)
            {
                MessageBox.Show("ERROR, the input string is not in the correct format");
            }
        }

        // ADD VALUES TO BASE LIST -- BUTTON --
        private void btnBaseAdd_Click(object sender, EventArgs e)
        {
            addValuesToList(baseList);
        }

        // ADD VALUES TO EXPONENTIAL LIST -- BUTTON --
        private void btnExpAdd_Click(object sender, EventArgs e)
        {
            addValuesToList(exponentialList);
        }

        // THROWS LIST'S VALUES INTO A STRING
        private string singleListString (List<int> list, string listName)
        {
            string txtList = "The items in the " + listName + " are: ";
            int elementsCounted = 0;
            foreach (int num in list)
            {
                if (elementsCounted == list.Count - 1)
                {
                    txtList += "(" + num + ").";
                }
                else
                {
                    txtList += "(" + num + "), ";
                }
                elementsCounted++;
            }
            return txtList;
        }

        // ADD ALL LIST'S VALUES INTO A SINGLE STRING
        private string listsStrings(List<int> baseList, List<int> exponentialList, List<int> resultsList)
        {
            string txtBase = singleListString(baseList, nameof(baseList));
            string txtExponential = singleListString(exponentialList, nameof(exponentialList));
            string txtResult = singleListString(resultsList, nameof(resultsList));
            string txtFinal = txtBase + "\n\n" + txtExponential + "\n\n" + txtResult;
            return txtFinal;
        }

        bool check = false;

        // SHOWS BOTH LISTS AND THE RESULTS -- BUTTON --
        private void btnShowLists_Click(object sender, EventArgs e)
        {
            if (!check)
            {
                calculatePoweredList(baseList, exponentialList, resultsList);
                check = true;
            }
            if (listSize(baseList) != 0 && listSize(exponentialList) == 0)
            {
                baseList.Sort();
                MessageBox.Show(singleListString(baseList, nameof(baseList)));
            }
            else if (listSize(baseList) == 0 && listSize(exponentialList) != 0)
            {
                exponentialList.Sort();
                MessageBox.Show(singleListString(exponentialList, nameof(exponentialList)));
            }
            else if (listSize(baseList) != 0 && listSize(exponentialList) != 0)
            {
                resultsList.Sort();
                MessageBox.Show(listsStrings(baseList, exponentialList, resultsList));
            }
            else
            {
                MessageBox.Show("ERROR, The list is empty. Add values before displaying values.");
            }
        }
    }
}