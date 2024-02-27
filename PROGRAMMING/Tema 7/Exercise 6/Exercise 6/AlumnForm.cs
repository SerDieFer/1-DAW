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

namespace Exercise_6
{
    public partial class AlumnForm : Form
    {
        public AlumnForm()
        {
            InitializeComponent();
        }

        public AlumnList alumnList;
        private void AlumnForm_Load(object sender, EventArgs e)
        {
        }

        public AlumnForm(AlumnList alumnList)
        {
            InitializeComponent();
            this.alumnList = alumnList;
        }

        private void btnAddAlumn_Click(object sender, EventArgs e)
        {
            Alumn anAlumn = new Alumn();
            bool introduced = false;
            do
            {
                string name = Interaction.InputBox("Introduce the alumn's name (ONLY LETTERS): ");

                if (CustomFunctions.RegexName(name))
                {
                    string alumnID = Interaction.InputBox("Introduce the alumn's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                    if (CustomFunctions.RegexID(alumnID))
                    {
                        if (!alumnList.AlreadyUsedID(alumnID))
                        {
                            string phoneValue = Interaction.InputBox("Introduce the alumn's phone number (9 DIGITS): \nIt must start with 6 or 7!!\n\nExample 1: 612345678 \nExample 2: 712345678");

                            if (CustomFunctions.RegexPhone(phoneValue))
                            {
                                int phone = int.Parse(phoneValue);
                                if (!alumnList.AlreadyUsedPhone(phone))
                                {
                                    string courseCodValue = Interaction.InputBox("Introduce the alumn's course code \n(MUST BE BIGGER THAN 0): ");

                                    if (CustomFunctions.RegexCourseCod(courseCodValue) && int.Parse(courseCodValue) > 0)
                                    {
                                        int courseCod = int.Parse(courseCodValue);
                                        alumnList.AddsAlumn(name, alumnID, phone, courseCod);
                                        introduced = true;
                                        MessageBox.Show(name + " was registered.");

                                    }
                                    else
                                    {
                                        MessageBox.Show("The course format is not correct, try again.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("The phone is already used, so this alumn was registered in a course before!!");
                                    introduced = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("The phone format is not correct, try again.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("The ID is already used, so this alumn was registered in a course before!!");
                            introduced = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The ID format is not correct, try again.");
                    }
                }
                else
                {
                    MessageBox.Show("The name format is not correct, try again.");
                }
            } while (!introduced);
        }

        private void btnRemoveAlumn_Click(object sender, EventArgs e)
        {
            bool introduced = false;
            do
            {
                string name = Interaction.InputBox("Introduce the alumn's name to remove (ONLY LETTERS): ");

                if (CustomFunctions.RegexName(name))
                {
                    if (alumnList.SameNameCounter(name) > 1)
                    {
                        alumnList.SelectSameNameAlumnsToDelete(name);
                        introduced = true;
                    }
                    else if (alumnList.SameNameCounter(name) == 1)
                    {
                        string uniqueName = alumnList.GetUniqueID(name);
                        alumnList.RemovesAlumn(uniqueName);
                        introduced = true;
                        MessageBox.Show(name + " was removed.");
                    }
                }
                else
                {
                    MessageBox.Show("The name format is not correct, try again");
                }

            } while (!introduced);
        }
    }
}
