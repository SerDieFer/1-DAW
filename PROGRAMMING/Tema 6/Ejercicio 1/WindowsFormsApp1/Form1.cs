using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            num = int.Parse(Interaction.InputBox("Enter the number"));
            pos = int.Parse(Interaction.InputBox("Enter the position you want to insert."));
            numbers.Insert(pos, num);
        }

        private void btnShowList_Click(object sender, EventArgs e)
        {
            string text;
            text = "The items in the list are: ";

            foreach (int num in numbers)
            {
                text += num + ", ";
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
            numbers.RemoveAt(0);
            MessageBox.Show("The first position has been removed");
        }

        private void btnRemoveValues_Click(object sender, EventArgs e)
        {
            int value = int.Parse(Interaction.InputBox("Enter the number to remove all from the list."));

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (numbers[i] == value)
                {
                    numbers.RemoveAt(i);
                }
            }

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
            numbers.Clear();
            MessageBox.Show("All list has been cleared");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int value = int.Parse(Interaction.InputBox("Enter the number"));
            numbers.Add(value);
            MessageBox.Show("The number " + value + " has been added to the list");

        }
    }
}
