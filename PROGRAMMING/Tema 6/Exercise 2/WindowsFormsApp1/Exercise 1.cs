using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Exercise_1 : Form
    {
        public Exercise_1()
        {
            InitializeComponent();
        }

        private void Exercise_1_Load(object sender, EventArgs e)
        {

        }

        // CREATION OF THE LIST AND VARIABLES OF IT

        List<int> numbers = new List<int>();

            // NUMBERS WHICH ARE GOING TO BE IN THE LIST, AND THEIR RESPECTIVE POSITION
            int num, pos;

        // BUTTONS

            // ADD NUMBER
            private void btnAdd_Click(object sender, EventArgs e)   // DONE AND TESTED
            {
                try
                {
                    int value = int.Parse(Interaction.InputBox("Enter the number you want to add", "Add Number"));
                    numbers.Add(value);
                    MessageBox.Show("The number (" + value + ") has been added to the list");
                }
                catch (FormatException)
                {
                    MessageBox.Show("ERROR, the input string is not in the correct format");
                }
            }

            // INSERT NUMBER IN A CERTAIN POSITION
            private void btnInsert_Click(object sender, EventArgs e)    // DONE AND TESTED
            {
                try
                {
                    num = int.Parse(Interaction.InputBox("Enter the number you want to insert", "Insert Number"));
                    pos = int.Parse(Interaction.InputBox("Enter the position you want to insert the (" + num + ").", "Insert Number Position"));
                    numbers.Insert(pos, num);
                    MessageBox.Show("The number (" + num + ") has been inserted in position (" + pos + ")");
                }
                catch (FormatException)
                {
                    MessageBox.Show("ERROR, the input string is not in the correct format");
                }
                catch (ArgumentOutOfRangeException)
                {
                    if (numbers.Count != 0)
                    {
                        MessageBox.Show("ERROR, the index must be within the limits of the list, the last value position is [" + (numbers.Count - 1) + "]");
                    }
                    else
                    {
                        MessageBox.Show("ERROR, the index must be within the limits of the list, the last value position is [" + (numbers.Count) + "]");
                    }
                }
            }

            // SHOW ALL VALUES IN THE LIST
            private void btnShowList_Click(object sender, EventArgs e)  // DONE AND TESTED
            {
                if (numbers.Count != 0)
                {
                    string txtList = "The items in the list are:\n\n";
                    int count = 0;
                    foreach (int num in numbers)
                    {
                        if (count == numbers.Count - 1)
                        {
                            txtList += "(" + num + ").";
                        }
                        else
                        {
                            txtList += "(" + num + "), ";
                        }
                        count++;
                    }
                    MessageBox.Show(txtList);
                }
                else
                {
                    MessageBox.Show("ERROR, The list is empty. Add values before displaying values.");
                }
            }

            // SHOWS THE FIRST POSITION FROM THE SELECTED VALUE
            private void btnShowFirstValuePosition_Click(object sender, EventArgs e)    // DONE AND TESTED
            {
                try
                {
                    if (numbers.Count != 0)
                    {
                        int value = int.Parse(Interaction.InputBox("Enter the number you want to check it's first position", "Show Number First Position"));
                        if (numbers.Contains(value))
                        {
                            MessageBox.Show("The first position of (" + value + ") would be the (" + numbers.IndexOf(value) + ")");
                        }
                        else
                        {
                            MessageBox.Show("ERROR, that value is not in the list");
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR, The list is empty. Add values before checking values.");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("ERROR, the input string is not in the correct format");
                }

            }

            // SHOWS ALL THE POSITIONS FROM THE SELECTED VALUE
            private void btnShowPositionsFromValue_Click(object sender, EventArgs e)    // DONE AND TESTED
            {
                try
                {
                    if (numbers.Count != 0)
                    {
                        int value = int.Parse(Interaction.InputBox("Enter the number you want to check all it's positions", "Show All Number Positions"));
                        if (numbers.Contains(value))
                        {
                            string text;
                            text = "The positions of the selected value in the list are:\n\n";
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (numbers[i] == value) 
                                {
                                    text += "(" + i + "), ";
                                }
                            }
                            text = text.Remove(text.Length - 2); // This removes that last coma added in text.
                            text = text.Insert(text.Length, "."); // This adds a dot in the last part of the text.
                            MessageBox.Show(text);
                        }
                        else
                        {
                            MessageBox.Show("ERROR, that value is not in the list");
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR, The list is empty. Add values before checking values.");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("ERROR, the input string is not in the correct format");
                }
            }

            // REMOVES THE FIRST VALUE POSITION FROM SELECTED VALUE
            private void btnRemoveFirstValue_Click(object sender, EventArgs e)  // DONE AND TESTED
            {
                try
                {
                    if (numbers.Count != 0)
                    {
                        int value = int.Parse(Interaction.InputBox("Enter the number to remove it's first position from the list.", "Remove Number First Position"));
                        int deletedPos = -1; // -1 means that the position is NULL
                        bool firstFound = false;
                        if (numbers.Contains(value))
                        {
                            for (int i = 0; i <= numbers.Count - 1 && !firstFound; i++)
                            {
                                if (numbers[i] == value)
                                {
                                    numbers.RemoveAt(i);
                                    deletedPos = i;
                                    firstFound = true;
                                }
                            }
                            MessageBox.Show("The value: (" + value + ") at position: (" + deletedPos + ") has been removed");
                        }
                        else
                        {
                            MessageBox.Show("ERROR, that value is not in the list");
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR, The list is empty. Add values before removing values.");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("ERROR, the input string is not in the correct format");
                }
            }

            // REMOVES ALL THE POSITIONS FROM THE SELECTED VALUE
            private void btnRemoveValues_Click(object sender, EventArgs e)  // DONE AND TESTED
            {
                try
                {
                    if (numbers.Count != 0)
                    {
                        int value = int.Parse(Interaction.InputBox("Enter the number you want to remove all it's positions", "Remove All Number Positions"));
                        if (numbers.Contains(value))
                        {
                            // /* WAY #1
                            for (int i = numbers.Count - 1; i >= 0; i--)
                            {
                                if (numbers[i] == value)
                                {
                                    numbers.RemoveAt(i);
                                }
                            }
                            /* WAY #2              
                               int i = 0;
                               while(i < numbers.Count)
                               {
                                   if (numbers[i] == value)
                                   {
                                       numbers.RemoveAt(i);
                                   }
                                   else
                                   {
                                       i++;
                                   }
                               }
                              */
                            MessageBox.Show("All the values which are (" + value + ") have been removed");
                        }
                        else
                        {
                            MessageBox.Show("ERROR, that value is not in the list");
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR, The list is empty. Add values before removing values.");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("ERROR, the input string is not in the correct format");
                }
            }

            // REMOVES A NUMBER IN A CERTAIN POSITION
            private void btnRemovePosition_Click(object sender, EventArgs e)    // DONE AND TESTED
            {
                try
                {
                    if (numbers.Count != 0)
                    {
                        int value = int.Parse(Interaction.InputBox("Enter the position to remove.", "Remove Number At Certain Position"));
                        numbers.RemoveAt(value);
                        MessageBox.Show("The position (" + value + ") has been removed");
                    }
                    else
                    {
                        MessageBox.Show("ERROR, The list is empty. Add values before removing values.");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("ERROR, the input string is not in the correct format");
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("ERROR, the index must be within the limits of the list, the last value position is [" + (numbers.Count - 1) + "]");
                }
            }

            // ORDERS THE LIST BY ASCENDENT ORDER
            private void btnSortList_Click(object sender, EventArgs e)  // DONE AND TESTED
            {
                if (numbers.Count < 1)
                {
                    MessageBox.Show("ERROR, The list is empty. Add values before sorting values.");
                
                }
                else if( numbers.Count < 2)
                {
                    MessageBox.Show("ERROR, There's only element in the list. In this case is not necessary to order the list");
                }
                else
                {
                    numbers.Sort();
                    MessageBox.Show("The list has been ordered");
                }
            }

            // CLEAR THE LIST
            private void btnClearAll_Click(object sender, EventArgs e)  // DONE AND TESTED
            {
                if (numbers.Count != 0)
                {
                    numbers.Clear();
                    MessageBox.Show("All list values has been cleared");
                }
                else
                {
                    MessageBox.Show("ERROR, The list is empty. Add values before clearing.");
                }
            }
    }
}
