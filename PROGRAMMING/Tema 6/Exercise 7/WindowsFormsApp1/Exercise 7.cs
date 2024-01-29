using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Exercise_7 : Form
    {
        public Exercise_7()
        {
            InitializeComponent();
        }

        private void Exercise_7_Load(object sender, EventArgs e)
        {

        }

        // LIST WHICH INCLUDES ALL THE SELECTED STRINGS BY THE USER
        List<string> strings = new List<string>();

        // ADD WORDS INTO A LIST IN ORDER
        private void AddValuesToList(List<string> list)
        {
            string word;
            DialogResult more;
            do
            {
                bool alreadyInserted = false;

                /* EXTRA OPTIONS IF YOU DONT WANT TO GET EMPTY AND NUMERIC STRING VALUES
                do
                {
                    word = Interaction.InputBox("Enter the word you want to add", "Add Word");
                    
                    if (string.IsNullOrWhiteSpace(word)) // THIS CHECKS WHEN THE STRING IS EMPTY
                    {
                        MessageBox.Show("ERROR: Please enter a valid word.");
                    }
                    else if (word.Any(char.IsDigit)) // THIS CHECKS WHEN A NUMERIC VALUE IS IN THE STRING
                    {
                        MessageBox.Show("ERROR: Numbers are not allowed. Please enter a valid word.");
                    }
                } while (string.IsNullOrWhiteSpace(word) || word.Any(char.IsDigit));
                */

                // IN CASE EXTRA OPTIONS ARE LEFT COMMENTED
                word = Interaction.InputBox("Enter the word you want to add", "Add Word");

                for (int i = 0; i < list.Count && !alreadyInserted; i++)
                {
                    if (string.Compare(word, list[i]) <= 0)
                    {
                        list.Insert(i, word);
                        MessageBox.Show("The word (" + word + ") has been added to the list");
                        alreadyInserted = true;
                    }
                }

                if (!alreadyInserted)
                {
                    list.Add(word);
                    MessageBox.Show("The word (" + word + ") has been added to the list");
                }

                more = MessageBox.Show("Do you want to keep adding more words?", "Add Word", MessageBoxButtons.YesNo);
            } while (more == DialogResult.Yes);
        }

        private void btnAddWords_Click(object sender, EventArgs e)
        {
            strings.Clear();
            AddValuesToList(strings);
        }

        // THROWS LIST'S VALUES INTO A STRING
        private string SingleListString(List<string> list, string listName)
        {
            string txtList = "The words in the " + listName + " are: ";
            if (list.Count > 0)
            {
                int elementsCounted = 0;
                foreach (string word in list)
                {
                    txtList += "(" + word + ")";
                    if (elementsCounted < list.Count - 1)
                    {
                        txtList += ", ";
                    }
                    elementsCounted++;
                }
                txtList += ".";
            }
            else
            {
                txtList += "(No words in the list).";
            }
            return txtList;
        }
        

        // SHOWS BOTH LISTS AND THE RESULTS -- BUTTON --
        private void btnShowList_Click(object sender, EventArgs e)
        {
            bool listSizeNotZero;
            listSizeNotZero = strings.Count > 0;

            string listString;
            listString = SingleListString(strings, nameof(strings));

            if (listSizeNotZero)
            {
                    MessageBox.Show(listString);
            }
            else
            {
                MessageBox.Show("ERROR, The list is empty. Add values before displaying values.");
            }
        }
    }
}