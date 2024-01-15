using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Exercise_1_Load(object sender, EventArgs e)
        {

        }

        List<int> numbers = new List<int>();
        int num, pos;

        private void btnInsert_Click(object sender, EventArgs e) //DONE
        {
            try
            {
                num = int.Parse(Interaction.InputBox("Enter the number"));
                pos = int.Parse(Interaction.InputBox("Enter the position you want to insert."));
                numbers.Insert(pos, num);
            }
            catch (FormatException.OutofRange)
            {

            }
                MessageBox.Show("The number " + num + " has been inserted in position " + pos);
        }

        private void btnShowList_Click(object sender, EventArgs e)
        {
            string text = "The items in the list are: ";
            int count = 0;

            foreach (int num in numbers)
            {
                if (count == numbers.Count-1)
                {
                    text += num + ".";
                }
                else
                {
                text += num + ", ";
                }
            count++;
            }
            MessageBox.Show(text);
        }

        private void btnShowFirstValuePosition_Click(object sender, EventArgs e)
        {
            int value = int.Parse(Interaction.InputBox("Enter the number"));
            MessageBox.Show("The first position of " + value + " would be the " + numbers.IndexOf(value));

        }

        private void btnShowPositionsFromValue_Click(object sender, EventArgs e)
        {
            int value = int.Parse(Interaction.InputBox("Enter the number"));
            string text;
            text = "The positions of the selected value in the list are: ";

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == value)
                {
                    text += i + ", ";
                }
            }
            MessageBox.Show(text);
        }

        private void btnRemoveFirstValue_Click(object sender, EventArgs e)
        {
            //TODO tiene que borrar el primer valor que valga x
            int value = int.Parse(Interaction.InputBox("Enter the number to remove all from the list."));
            int deletedPos = -1; // -1 means that the position is NULL
            bool firstFound = false;

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

        private void btnRemoveValues_Click(object sender, EventArgs e)
        {
            int value = int.Parse(Interaction.InputBox("Enter the number to remove all from the list."));
            // /* WAY #1
            for (int i = numbers.Count - 1; i >= 0; i--)
             {
                 if (numbers[i] == value)
                 {
                     numbers.RemoveAt(i);
                 }
             }
            // */

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

            MessageBox.Show("The values that are " + value + " have been removed");
        }

        private void btnRemovePosition_Click(object sender, EventArgs e)
        {
            int value = int.Parse(Interaction.InputBox("Enter the position to remove."));
            numbers.RemoveAt(value);
            MessageBox.Show("The position " + value + " has been removed");
        }

        private void btnSortList_Click(object sender, EventArgs e)
        {
            numbers.Sort();
            MessageBox.Show("The list has been ordered");
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {

            // Comprobar que no haya nada
            numbers.Clear();
            MessageBox.Show("All list has been cleared");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Comprobar que no haya nada
            int value = int.Parse(Interaction.InputBox("Enter the number"));
            numbers.Add(value);
            MessageBox.Show("The number " + value + " has been added to the list");
        }
    }
}
