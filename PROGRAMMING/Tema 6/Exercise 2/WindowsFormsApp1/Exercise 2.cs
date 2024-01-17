using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Exercise_2 : Form
    {
        public Exercise_2()
        {
            InitializeComponent();
        }

        private void Exercise_1_Load(object sender, EventArgs e)
        {

        }

        // ORIGINAL LIST
        List<int> originaList = new List<int>();
        // NEW LIST COPY METHOD
        List<int> evenList = new List<int>();

        // LIST ELEMENTS COUNTER 
        private int listSize (List<int> list)
        {
            int size = list.Count;
            return size;
        }

        // ADD NUMBERS TO ORIGINAL LIST
        private void addValuesToList(List<int> list) 
        {
            try
            {
                DialogResult more;
                int value;
                do
                {
                    value = int.Parse(Interaction.InputBox("Enter the value you want to add", "Add Value"));
                    originaList.Add(value);
                    MessageBox.Show("The number (" + value + ") has been added to the list");
                    more = MessageBox.Show("Do you want to enter another value?", "Value", MessageBoxButtons.YesNo);
                } while (more == DialogResult.Yes);
            }
            catch (FormatException)
            {
                MessageBox.Show("ERROR, the input string is not in the correct format");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addValuesToList(originaList);
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

        // ADD BOTH LIST'S VALUES INTO A SINGLE STRING
        private string listsStrings(List<int> originaList, List<int> evenList)
        {
            string txtOriginal = singleListString(originaList, nameof(originaList));
            string txtNew = singleListString(evenList, nameof(evenList));
            string txtFinal = txtOriginal + "\n\n" + txtNew;
            return txtFinal;
        }

        // SHOW ALL LIST VALUES
        private void btnShowLists_Click(object sender, EventArgs e)
        {
            if (listSize(originaList) != 0 && listSize(evenList) == 0)
            {
                MessageBox.Show(singleListString(originaList, nameof(originaList)));
            }
            else if(listSize(originaList) != 0 && listSize(evenList) != 0)
            {
                MessageBox.Show(listsStrings(originaList, evenList));
            }
            else
            {
                MessageBox.Show("ERROR, The list is empty. Add values before displaying values.");
            }
        }

        // REMOVES ALL THE EVEN NUMBERS FROM THE SELECTED LIST
        private void removeNotEvenNumbersFromOriginalList (List<int> oldList, List<int> newList)
        {
            try
            {
                for (int i = oldList.Count - 1; i >= 0; i--)
                {
                    if ((oldList[i] % 2) == 0)
                    {
                    newList.Add(oldList[i]);
                    oldList.RemoveAt(i);
                    }
                }
                MessageBox.Show("All the even values have been removed");
            }

            catch (FormatException)
            {
                MessageBox.Show("ERROR, the input string is not in the correct format");
            }
        }

        private void btnRemoveEven_Click(object sender, EventArgs e)
        {
            if (listSize(originaList) != 0)
            {
                removeNotEvenNumbersFromOriginalList(originaList,evenList);
            }
            else
            {
                MessageBox.Show("ERROR, The list is empty. Add values to the list before removing even values.");
            }
        }
    }
}
