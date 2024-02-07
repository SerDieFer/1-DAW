using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // BUTTON WHICH ADD A PERSON
        private void btnIntroduceDate_Click(object sender, EventArgs e)
        {
            IntroduceDate();
        }

        // ASKS THE DATA FROM DATE AND THEN ADD THIS OBJECT (DATE) TO THE LIST
        private void IntroduceDate()
        {
            bool checker = false;
            Date da = new Date();
            do
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
                        MessageBox.Show("Error, the data input is not possible, retry again");
                    }
                }
            } while (!checker);
        }

        // ADDS ALL THE DATA FROM EVERY DATE CREATED IN THE LIST
        private string AddAllToList()
        {
            Date da;
            string txtAll = "";
            if (dateList.Count != 0)
            {
                for (int i = 0; i < dateList.Count; i++)
                {
                    da = dateList[i];
                    txtAll += da.ShowData();
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

            MessageBox.Show(AddAllToList());
        }
    }
}
