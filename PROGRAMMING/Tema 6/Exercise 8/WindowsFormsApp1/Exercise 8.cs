using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Exercise_8 : Form
    {
        public Exercise_8()
        {
            InitializeComponent();
        }

        private void Exercise_8_Load(object sender, EventArgs e)
        {

        }

        // LIST WHICH INCLUDES THE WINNER NUMBER
        List<int> winnerNumbers = new List<int>();
        // LIST WHICH INCLUDES ALL THE SELECTED NUMBERS BY THE USER
        List<int> userNumbers = new List<int>();

        // LIST ELEMENTS COUNTER 
        private int listSize(List<int> list)
        {
            int size = list.Count;
            return size;
        }

        // RANDOM NUMBER GENERATOR
        private int randomNumberGenerator()
        {
            Random random = new Random();
            int randNum = random.Next(1, 50);

            return randNum;
        }

        // ADD NUMBERS TO LIST
        private void addValuesToList(List<int> list)
        {
            try
            {
                int counter = 0;
                int value;

                while (counter < 5)
                {
                    value = int.Parse(Interaction.InputBox("Enter the number you want to add", "Add Value"));
                    if (value > 0 && value < 50)
                    {
                        list.Add(value);
                        counter++;
                    }
                    else
                    {
                        MessageBox.Show("Only values between 1 to 49 can be used, try again");
                    }
                    MessageBox.Show("The number (" + value + ") has been added to the list", "Numbers Left: " + (5 - counter));
                }

                if(counter == 5)
                {
                    MessageBox.Show("All the user numbers has been inserted");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("ERROR, the input string is not in the correct format");
            }
        }

        // ADD VALUES TO BASE LIST -- BUTTON --
        private void AddUserNumbers_Click(object sender, EventArgs e)
        {
            winnerNumbers.Clear();

            for(int i = 0; i < 6; i++)
            {
                winnerNumbers[0] = randomNumberGenerator();

                if (winnerNumbers[i] != randNumber)
                {
                    winnerNumbers.Add(randomNumberGenerator());
                }
            }
        }

        // ADD VALUES TO EXPONENTIAL LIST -- BUTTON --
        private void AddWinnerNumbers_Click(object sender, EventArgs e)
        {
            userNumbers.Clear();
            addValuesToList(userNumbers);
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
            string txtWinner = singleListString(winnerNumbers, nameof(winnerNumbers));
            string txtUser = singleListString(userNumbers, nameof(userNumbers));
            string txtFinal = winnerNumbers + "\n\n" + userNumbers;
            return txtFinal;
        }

        // SHOWS BOTH LISTS AND THE RESULTS -- BUTTON --
        private void btnShowLottery_Click(object sender, EventArgs e)
        {
            bool checkWinnerNotZero, checkUserNotZero;

            checkWinnerNotZero = listSize(winnerNumbers) != 0;
            checkUserNotZero = listSize(userNumbers) != 0;

            string singleListWinner, singleListUser, allLists;

            singleListWinner = singleListString(winnerNumbers, nameof(winnerNumbers));
            singleListUser = singleListString(userNumbers, nameof(userNumbers));
            allLists = singleListWinner + "\n\n" + singleListUser;

            if (checkWinnerNotZero && !checkUserNotZero)
            {
                    MessageBox.Show(singleListWinner);
            }
            else if (!checkWinnerNotZero && checkUserNotZero)
            {
                    MessageBox.Show(singleListUser);
            }
            else if (checkWinnerNotZero && checkUserNotZero)
            {
                    MessageBox.Show(allLists);
            }
            else
            {
                MessageBox.Show("ERROR, The list is empty. Add values before displaying values.");
            }
        }
    }
}