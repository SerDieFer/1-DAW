using Microsoft.VisualBasic;
using System;
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

        // LIST ELEMENTS COUNTER 
        private int ListSize(List<string> list)
        {
            int size = list.Count;
            return size;
        }

        // ADD WORDS INTO A LIST IN ORDER
        private void AddValuesToList(List<string> list)
        {
            string word;
            DialogResult more;
            bool alreadyInserted = false;

            word = Interaction.InputBox("Enter the word you want to add", "Add Word");
            list.Add(word);
            MessageBox.Show("The word (" + word + ") has been added to the list");
            more = MessageBox.Show("Do you want to keep adding more words?", "Add Word", MessageBoxButtons.YesNo);

            while (more == DialogResult.Yes)
            {
                try
                {
                    for (int i = 1; i < list.Count && !alreadyInserted; i++)
                    {
                        if (string.Compare(word, list[i]) <= 0)
                        {
                            word = Interaction.InputBox("Enter the word you want to add", "Add Word");
                            list.Insert(i, word);
                            MessageBox.Show("The word (" + word + ") has been added to the list");
                            more = MessageBox.Show("Do you want to keep adding more words?", "Add Word", MessageBoxButtons.YesNo);
                            alreadyInserted = true;
                        }
                    }
                    if(!alreadyInserted)
                    {
                        list.Add(word);
                        MessageBox.Show("The word (" + word + ") has been added to the list");
                        more = MessageBox.Show("Do you want to keep adding more words?", "Add Word", MessageBoxButtons.YesNo);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("ERROR, the input string is not in the correct format");
                }
            }
        }

        private void btnAddWords_Click(object sender, EventArgs e)
        {
            AddValuesToList(strings);
        }

        // THROWS LIST'S VALUES INTO A STRING
        private string SingleListString(List<string> list, string listName)
        {
            string txtList = "The words in the " + listName + " are: ";
            int elementsCounted = 0;
            foreach (string words in list)
            {
                if (elementsCounted == list.Count - 1)
                {
                    txtList += "(" + words + ").";
                }
                else
                {
                    txtList += "(" + words + "), ";
                }
                elementsCounted++;
            }
            return txtList;
        }

        // SHOWS BOTH LISTS AND THE RESULTS -- BUTTON --
        private void btnShowList_Click(object sender, EventArgs e)
        {
            bool listSizeNotZero;
            listSizeNotZero = ListSize(strings) != 0;

            string listString;
            listString = SingleListString(strings, nameof(strings));

            if (!listSizeNotZero)
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