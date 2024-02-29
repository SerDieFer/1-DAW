using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace Exercise_6
{
    //TODO CANCELAR BOTON
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

        // IS DONE
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

        //CHECK THIS DOESNT WORK
        private void btnRemoveAlumnByName_Click(object sender, EventArgs e)
        {
            if (alumnList.CountsTotalAlumns() > 0)
            {
                bool introduced = false;
                do
                {
                    string alumnName = Interaction.InputBox("Introduce the alumn's name to remove (ONLY LETTERS): ");
                    if (CustomFunctions.RegexName(alumnName))
                    {
                        if (alumnList.SameNameCounter(alumnName) > 1)
                        {
                            alumnList.SelectSameNameAlumnsToDelete(alumnName);
                            introduced = true;
                        }
                        else if (alumnList.SameNameCounter(alumnName) == 1)
                        {
                            int uniqueNamePosition = alumnList.GetUniqueNamePosition(alumnName);
                            alumnList.RemovesAlumn(uniqueNamePosition);
                            introduced = true;
                            MessageBox.Show(alumnName + " was removed.");
                        }
                        else
                        {
                            MessageBox.Show("There is no alumns with the selected name, try again");
                            introduced = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The name format is not correct, try again");
                    }

                } while (!introduced);
            }
            else
            {
                MessageBox.Show("Error, the list has not alumns added, add an alumn before removing an alumn.");
            }
        }

        // IS DONE
        private void btnRemoveAlumnByID_Click(object sender, EventArgs e)
        {
            if (alumnList.CountsTotalAlumns() > 0)
            {
                bool introduced = false;
                do
                {
                    string alumnID = Interaction.InputBox("Introduce the alumn's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                    if (CustomFunctions.RegexID(alumnID))
                    {
                        if (alumnList.AlreadyUsedID(alumnID))
                        {
                            if (alumnList.CountsTotalAlumns() >= 1)
                            {
                                int alumnPosition = alumnList.ReturnsAlumnPositionFromID(alumnID);
                                string alumnName = alumnList.ReturnsAlumnName(alumnID);
                                alumnList.RemovesAlumn(alumnPosition);
                                MessageBox.Show("The alumn (" + alumnName + ") with the ID (" + alumnID + ") was removed.");
                                introduced = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is no alumns with the selected ID");
                            introduced = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The ID format is not correct, try again");
                    }

                } while (!introduced);
            }
            else
            {
                MessageBox.Show("Error, the list has not alumns added, add an alumn before removing an alumn.");
            }
        }

        //CHECK THIS DOESNT WORK
        private void btnShowAlumnDataByID_Click(object sender, EventArgs e)
        {
            if (alumnList.CountsTotalAlumns() > 0)
            {
                bool introduced = false;
                do
                {
                    string alumnID = Interaction.InputBox("Introduce the alumn's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                    if (CustomFunctions.RegexID(alumnID))
                    {
                        if (alumnList.CountsTotalAlumns() > 0)
                        {
                            MessageBox.Show(alumnList.ShowsSelectedAlumnsData(alumnID));
                            introduced = true;
                        }
                        else
                        {
                            MessageBox.Show("There is no alumns with the selected ID, try again");
                            introduced = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The ID format is not correct, try again");
                    }

                } while (!introduced);
            }
            else
            {
                MessageBox.Show("Error, the list has not alumns added, add an alumn before checking an alumn data from the alumns list");
            }
        }

        // IS DONE
        private void btnShowAlumnDataByName_Click(object sender, EventArgs e)
        {
            if (alumnList.CountsTotalAlumns() > 0)
            {
                //TODO CHANGE THIS TO ONLY SHOW DATA FROM ALL ALUMNS WITH SAME NAME
                bool introduced = false;
                do
                {
                    string name = Interaction.InputBox("Introduce the alumn's name to show data (ONLY LETTERS): ");

                    if (CustomFunctions.RegexName(name))
                    {
                        if (alumnList.SameNameCounter(name) > 1)
                        {
                            alumnList.SelectSameNameAlumnsToShow(name);
                            introduced = true;
                        }
                        else if (alumnList.SameNameCounter(name) == 1)
                        {
                            alumnList.SelectSameNameAlumnsToShow(name);
                            introduced = true;
                        }
                        else
                        {
                            MessageBox.Show("There is no alumns with the selected name, try again");
                            introduced = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The name format is not correct, try again");
                    }

                } while (!introduced);
            }
            else
            {
                MessageBox.Show("Error, the list has not alumns added, add an alumn before checking an alumn data from the alumns list");
            }
        }

        //CHECK THIS DOESNT WORK
        private void btnShowAlumnsFromSelectedCourse_Click(object sender, EventArgs e)
        {
            bool introduced = false;
            if (alumnList.CountsTotalAlumns() > 0)
            {
                do
                {
                    string courseCodValue = Interaction.InputBox("Introduce the course code to show the alumns who are registered in it (FROM 1 TO ∞): ");
                    if (CustomFunctions.RegexCourseCod(courseCodValue))
                    {
                        int courseCod = int.Parse(courseCodValue);
                        MessageBox.Show(alumnList.ShowAlumnsByCourseCod(courseCod));
                        introduced = true;
                    }
                    else
                    {
                        MessageBox.Show("The course cod format is not correct, try again");
                    }

                } while (!introduced);
            }
            else
            {
                MessageBox.Show("Error, the list has not alumns added, add an alumn before showing the alumns from the selected course.");
            }
        }
        
        // IS DONE
        private void btnShowAlumnList_Click(object sender, EventArgs e)
        {
            if (alumnList.CountsTotalAlumns() != 0)
            {
                MessageBox.Show(alumnList.ShowsAlumnsList());
            }
            else
            {
                MessageBox.Show("There is no alumns added to the list, add an alumn before trying again");
            }
        }

        // IS DONE
        private void btnSortAlumnsAlphabetically_Click(object sender, EventArgs e)
        {
            if (alumnList.CountsTotalAlumns() > 0)
            {
                if (alumnList.CountsTotalAlumns() == 1)
                {
                    MessageBox.Show("Error, the list has only one alumn, add atleast 2 alumns to order the list");
                }
                else
                {
                    alumnList.SortAlumnListAlphabetically();
                    MessageBox.Show("The list was correctly sorted by alphabetical order");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has not alumns added, add an alumn before ordering the alumns list");
            }
        }
    }
}

