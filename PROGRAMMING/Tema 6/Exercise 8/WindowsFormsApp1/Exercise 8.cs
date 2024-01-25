using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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
        private int ListSize(List<int> list)
        {
            int size = list.Count;
            return size;
        }

        // RANDOM NUMBER GENERATOR
        private int RandomNumberGenerator()
        {
            Random random = new Random();
            int randNum = random.Next(1, 50);
            return randNum;
        }

        // ADD VALUES INTO A LIST
        private void AddValuesToList(List<int> list)
        {
            int counter = 0;
            int value;
            while (counter <= 5)
            {
                try
                {
                    value = int.Parse(Interaction.InputBox("Enter the number you want to add", "Add Value"));
                    bool notContained = list.Contains(value);
                    if (!notContained && (value > 0 && value < 50))
                    {
                        list.Add(value);
                        counter++;
                        MessageBox.Show("The number (" + value + ") has been added to the list", "Numbers Left: " + (6 - counter));
                    }
                    else if (notContained)
                    {
                        MessageBox.Show("Inserted numbers can't be repeated");
                    }
                    else
                    {
                        MessageBox.Show("Only values between 1 to 49 can be used, try again");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("ERROR, the input string is not in the correct format");
                }
            }
            if(counter == 6)
            {
                MessageBox.Show("All the user numbers has been inserted");
            }
        }

        // ADD RANDOM VALUES INTO A LIST
        private void AddRandomValuesToList(List<int> list)
        {
            int i = 0;
            while (i <= 5)
            {
                int randomValue = RandomNumberGenerator();
                if (!list.Contains(randomValue))
                {
                    list.Add(randomValue);
                    i++;
                }
            }
        }

        // ADD VALUES TO WINNER NUMBERS LIST -- BUTTON --
        private void AddWinnersNumbers_Click(object sender, EventArgs e)
        {
            if (userIntroducedNumbers)
            {
                if (ListSize(winnerNumbers) != 0)
                {
                    winnerNumbers.Clear();
                }
                AddRandomValuesToList(winnerNumbers);
            }
            else
            {
                MessageBox.Show("It is not possible to display the result of the list" +
                    " of winning numbers unless you have entered your own list.");
            }
        }

        bool userIntroducedNumbers = false;

        // ADD VALUES TO USER NUMBERS LIST -- BUTTON --
        private void AddUserNumbers_Click(object sender, EventArgs e)
        {
            if (ListSize(userNumbers) != 0)
            {
                userNumbers.Clear();
            }
            AddValuesToList(userNumbers);
            userIntroducedNumbers = true;
        }

        // RETURN LIST VALUE POSITION
        private string ReturnPositionValue(List<int> userList, List<int> winnerList)
        {
            int positionListUser, positionListWinner;
            string txtPositionUser, txtPositionWinner, resultsPositions;
            txtPositionUser = txtPositionWinner = resultsPositions = "";

            for (int i = 0; i < userList.Count; i++)
            {
                for (int j = 0; j < winnerList.Count; j++)
                {
                    if (userList[i] == winnerList[j])
                    {
                        positionListUser = i + 1;
                        positionListWinner = j + 1;
                        txtPositionUser = "Your Nº" + positionListUser;
                        txtPositionWinner = " it's the same as the winning Nº" + positionListWinner + "\n";
                        resultsPositions += txtPositionUser + txtPositionWinner;
                    }
                }
            }
            return resultsPositions;
        }

        // LISTS COMPARATION BETWEEN VALUES AND COMMON NUMBERS COUNTER
        private void CompareListsAndCountSame(List<int> winnerList, List<int> userList)
        {
            int sameValues = 0;
            string txtYouHaveWon, txtSameValues, txtYouHaveLost, counter;
            counter = txtYouHaveWon = txtSameValues = txtYouHaveLost = "";
            for (int i = 0; i < winnerList.Count && i < userList.Count; i++)
            {
                if (userList.Contains(winnerList[i]))
                {
                    sameValues++;
                    txtSameValues = ReturnPositionValue(userList, winnerList);
                }
            }
            counter = "\nYou have matched a total of: " + sameValues + " values";
            if (sameValues == 6)
            {
                txtYouHaveWon = "Congratulations! You have won the lottery";
                MessageBox.Show(ReturnPositionValue(userList, winnerList) + counter + "\n\n" + txtYouHaveWon);
            }
            else if (sameValues == 0)
            {
                txtYouHaveLost = "Unfortunately, you didn't match any numbers";
                MessageBox.Show(counter + "\n\n" + txtYouHaveLost);
            }
            else
            {
                MessageBox.Show(txtSameValues + counter);
            }
        }

        // CHECK RESULTS BETWEEN USER NUMBERS AND WINNER NUMBERS - BUTTON --
        private void btnCheckResults_Click(object sender, EventArgs e)
        {
            CompareListsAndCountSame(winnerNumbers, userNumbers);
        }

        // THROWS LIST'S VALUES INTO A STRING
        private string SingleListString(List<int> list, string listName)
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
        private string ListsStrings(List<int> list1, List<int> list2, List<int> resultsList)
        {
            string txtWinner = SingleListString(winnerNumbers, nameof(winnerNumbers));
            string txtUser = SingleListString(userNumbers, nameof(userNumbers));
            string txtFinal = winnerNumbers + "\n\n" + userNumbers;
            return txtFinal;
        }

        // SHOWS BOTH LISTS AND THE RESULTS -- BUTTON --
        private void btnShowLottery_Click(object sender, EventArgs e)
        {
            bool checkWinnerNotZero, checkUserNotZero;
            checkWinnerNotZero = ListSize(winnerNumbers) != 0;
            checkUserNotZero = ListSize(userNumbers) != 0;
            string singleListWinner, singleListUser, allLists;
            singleListWinner = SingleListString(winnerNumbers, nameof(winnerNumbers));
            singleListUser = SingleListString(userNumbers, nameof(userNumbers));
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