using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Exercise_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Date> dateList = new List<Date>();

        // ASKS THE DATA FROM DATE AND THEN ADD THIS OBJECT (DATE) TO THE LIST
        private void IntroduceDate(List<Date> list)
        {
            bool checker = false;
            Date da = new Date();
            do
            {
                try
                {
                    da.Day = int.Parse(Interaction.InputBox("Introduce the day: "));
                    da.Month = int.Parse(Interaction.InputBox("Introduce the month: "));
                    da.Year = int.Parse(Interaction.InputBox("Introduce the year: ")); ;
                    if (!checker)
                    {
                        if (da.ValidateData())
                        {
                            dateList.Add(da);
                            checker = true;
                        }
                        else
                        {
                            MessageBox.Show("Error, the data input is not possible you must " +
                                "stay within the range of a date-type data format , retry again");
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("You must enter numbers to set the data values");
                }
              
            } while (!checker);
        }

        // BUTTON WHICH ADD A PERSON
        private void btnIntroduceDate_Click(object sender, EventArgs e)
        {
            IntroduceDate(dateList);
        }

        // ADDS ALL THE DATA FROM EVERY DATE CREATED IN THE LIST
        private string AddAllToList(List<Date> list)
        {
            Date da;
            string txtAll = "";
            if (dateList.Count != 0)
            {
                for (int i = 0; i < dateList.Count; i++)
                {
                    da = dateList[i];
                    txtAll += da.ShowData() + "\n";
                }
            }
            else
            {
                MessageBox.Show("ERROR");
            }
            return txtAll;
        }

        // BUTTON WHICH SHOW ALL DATA STORED
        private void brnShowData_Click(object sender, EventArgs e)
        {

            MessageBox.Show(AddAllToList(dateList));
        }

        // CHECK IF DATA IS PREVIOUS AND RETURNS A TRUE OR FALSE
        private bool IsDatePrevious(Date actualDate, Date nextDate)
        {
            bool isPrevious = true;

            if (actualDate.Year > nextDate.Year)
            {
                isPrevious = false;
            }
            else if (actualDate.Year == nextDate.Year)
            {
                if (actualDate.Month > nextDate.Month)
                {
                    isPrevious = false;
                }
                else if (actualDate.Month == nextDate.Month)
                {
                    if (actualDate.Day > nextDate.Day)
                    {
                        isPrevious = false;
                    }
                }
            }
            return isPrevious;
        }

        // CHECKS THE DATA FROM DATELIST AND THEN ORDER THIS DATES IN THE LIST BY YEAR, MONTH, DAY
        private void OrdersDateList(List<Date> list)
        {
            Date temporalDate;

            for (int i = 0; i < dateList.Count - 1; i++)
            {
                for (int j = i + 1; j < dateList.Count; j++)
                {
                    if (IsDatePrevious(dateList[i], dateList[j]))
                    {
                        temporalDate = dateList[i];
                        dateList[i] = dateList[j];
                        dateList[j] = temporalDate;
                    }
                }
            }
        }

        // BUTTON WHICH ORDERS ALL DATA STORED
        private void btnOrderDate_Click(object sender, EventArgs e)
        {
            OrdersDateList(dateList);
        }
    }
}
