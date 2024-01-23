using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Exercise_5 : Form
    {
        public Exercise_5()
        {
            InitializeComponent();
        }

        private void Exercise_5_Load(object sender, EventArgs e)
        {

        }

        // LIST1
        List<int> list1 = new List<int>();
        // LIST2
        List<int> list2 = new List<int>();
        // RESULT LIST
        List<int> resultsList = new List<int>();

        bool alreadyRemoved = false;

        // LIST ELEMENTS COUNTER 
        private int listSize(List<int> list)
        {
            int size = list.Count;
            return size;
        }

        // ADD PREVIOUS LISTS NUMBERS TO A NEW LIST
        private void addBothListsToNewList(List<int> list1, List<int> list2, List<int> resultsList)
        {
            int i = 0;
            int j = 0;

            while(i < list1.Count && j < list2.Count)
            {
                if (list1[i] < list2[j])
                {
                    resultsList.Add(list1[i]);
                    i++;
                }
                else if (list1[i] > list2[j])
                {
                    resultsList.Add(list2[j]);
                    j++;
                }
                else
                {
                    resultsList.Add(list1[i]);
                    resultsList.Add(list2[j]);
                    i++;
                    j++;
                }
            }
            while (i < list1.Count)
            {
                resultsList.Add(list1[i]);
                i++;
            }

            while (j < list2.Count)
            {
                resultsList.Add(list2[j]);
                j++;
            }
        }

        // ADD PREVIOUS LISTS NUMBERS TO A NEW LIST AND REMOVE FROM ORIGINAL
        private void CopyBothIntoNewListAndRemoveFromOriginalList(List<int> list1, List<int> list2, List<int> resultsList)
        {
            int i = 0;
            int j = 0;

            while (i < list1.Count && j < list2.Count)
            {
                if (list1[i] < list2[j])
                {
                    resultsList.Add(list1[i]);
                    list1.RemoveAt(i);
                }
                else if (list1[i] > list2[j])
                {
                    resultsList.Add(list2[j]);
                    list2.RemoveAt(j);
                }
                else
                {
                    resultsList.Add(list1[i]);
                    resultsList.Add(list2[j]);
                    list1.RemoveAt(i);
                    list2.RemoveAt(j);
                }
            }

            while (i < list1.Count)
            {
                resultsList.Add(list1[i]);
                list1.RemoveAt(i);
            }

            while (j < list2.Count)
            {
                resultsList.Add(list2[j]);
                list2.RemoveAt(j);
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
            }
            catch (FormatException)
            {
                MessageBox.Show("ERROR, the input string is not in the correct format");
            }
        }

        // ADD VALUES TO BASE LIST -- BUTTON --
        private void btnList1Add_Click(object sender, EventArgs e)
        {
            addValuesToList(list1);
            list1.Sort();
        }

        // ADD VALUES TO EXPONENTIAL LIST -- BUTTON --
        private void btnList2Add_Click(object sender, EventArgs e)
        {
            addValuesToList(list2);
            list2.Sort();
        }

        // ADD BOTH LISTS INTO A NEW -- BUTTON --
        private void btnAddBothToNew_Click(object sender, EventArgs e)
        {
            addBothListsToNewList(list1, list2, resultsList);
        }

        // ADD BOTH LISTS INTO A NEW AND REMOVE FROM ORIGINALS -- BUTTON --
        private void btnAddBothToNewAndRemoveOriginals_Click(object sender, EventArgs e)
        {
            CopyBothIntoNewListAndRemoveFromOriginalList(list1, list2, resultsList);
        }

        // THROWS LIST'S VALUES INTO A STRING
        private string singleListString(List<int> list, string listName)
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
        private string listsStrings(List<int> list1, List<int> list2, List<int> resultsList)
        {
            string txtList1 = singleListString(list1, nameof(list1));
            string txtList2 = singleListString(list2, nameof(list2));
            string txtResult = singleListString(resultsList, nameof(resultsList));
            string txtFinal = txtList1 + "\n\n" + txtList2 + "\n\n" + txtResult;
            return txtFinal;
        }

        // SHOWS BOTH LISTS AND THE RESULTS -- BUTTON --
        private void btnShowLists_Click(object sender, EventArgs e)
        {
            if (listSize(list1) != 0 && listSize(list2) == 0)
            {
                MessageBox.Show(singleListString(list1, nameof(list1)));
            }
            else if (listSize(list1) == 0 && listSize(list2) != 0)
            {
                MessageBox.Show(singleListString(list2, nameof(list2)));
            }
            else if (listSize(list1) != 0 && listSize(list2) != 0)
            {
                MessageBox.Show(listsStrings(list1, list2, resultsList));
                alreadyRemoved = true;
            }
            else if ((listSize(list1) == 0 && listSize(list2) == 0) && alreadyRemoved)
            {
                MessageBox.Show(singleListString(resultsList, nameof(resultsList)));
            }
            else
            {
                MessageBox.Show("ERROR, The list is empty. Add values before displaying values.");
            }
        }
    }
}