using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Exercise_3 : Form
    {
        public Exercise_3()
        {
            InitializeComponent();
        }

        private void Exercise_3_Load(object sender, EventArgs e)
        {

        }

        // ORIGINAL LIST
        List<int> originaList = new List<int>();
        // NEW LIST COPY METHOD
        List<int> primeList = new List<int>();

        // LIST ELEMENTS COUNTER 
        private int listSize(List<int> list)
        {
            int size = list.Count;
            return size;
        }

        // IS PRIME NUMBER?
        private bool primeNumber(int num)
        {
            bool isPrime = true;
            if(num < 2)
            {   
                isPrime = false;
            }
            for (int i = 2; i <= (num) && isPrime; i++)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                }
            }
            return isPrime;
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

        // ADD VALUES TO ORIGINAL LIST -- BUTTON --
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

        // SHOWS VARIOUS LIST VALUES -- BUTTON --
        private void btnShowLists_Click(object sender, EventArgs e)
        {
            if (listSize(originaList) != 0 && listSize(primeList) == 0)
            {
                MessageBox.Show(singleListString(originaList, nameof(originaList)));
            }
            else if(listSize(originaList) != 0 && listSize(primeList) != 0)
            {
                primeList.Sort();
                MessageBox.Show(listsStrings(originaList, primeList));
            }
            else
            {
                MessageBox.Show("ERROR, The list is empty. Add values before displaying values.");
            }
        }

        // REMOVES ALL THE PRIME NUMBERS FROM THE SELECTED LIST AND MOVES THEM TO OTHER LIST
        private void removePrimeFromOriginalList(List<int> oldList, List<int> newList)
        {
            try
            {
                for (int i = oldList.Count - 1; i >= 0; i--)
                {
                    if (primeNumber(oldList[i]))
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

        // PRIME REMOVER FROM ORIGINAL LIST -- BUTTON --
        private void btnRemoveEven_Click(object sender, EventArgs e)
        {
            if (listSize(originaList) != 0)
            {
                removePrimeFromOriginalList(originaList,primeList);
            }
            else
            {
                MessageBox.Show("ERROR, The list is empty. Add values to the list before removing even values.");
            }
        }

        // COPY ALL THE PRIME NUMBERS FROM THE SELECTED LIST TO OTHER LIST
        private void copyPrimeNumbersIntoNewList(List<int> oldList, List<int> newList)
        {
            try
            {
                for (int i = oldList.Count - 1 ; i >= 0; i--)
                {
                    if (primeNumber(oldList[i]))
                    {
                        newList.Add(oldList[i]);
                    }
                    
                }
                MessageBox.Show("All the even values have been moved into a new list");
            }

            catch (FormatException)
            {
                MessageBox.Show("ERROR, the input string is not in the correct format");
            }
        }

        // COPY PRIME NUMBERS FROM ORIGINAL LIST TO EVEN LIST -- BUTTON --
        private void btnCopyPrime_Click(object sender, EventArgs e)
        {
            if (listSize(originaList) != 0)
            {
                copyPrimeNumbersIntoNewList(originaList, primeList);
            }
            else
            {
                MessageBox.Show("ERROR, The list is empty. Add values to the list before copying even values.");
            }
        }
    }
}
