using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Exercise_6
{
    //TODO CANCELAR BOTON?

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

        //IS DONE
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
                            int alumnPosition = alumnList.GetUniqueNamePosition(alumnName);
                            string alumnID = alumnList.ReturnsAlumnIDFromPosition(alumnPosition);
                            alumnList.RemovesAlumn(alumnPosition);
                            MessageBox.Show("The alumn ( " + alumnName + " ) with the ID ( " + alumnID + " ) was cleared.");
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
                MessageBox.Show("Error, the list has not alumns added, add an alumn before removing an alumn.");
            }
        }

        // IS DONE
        private void btnAddGradesToAlumnByName_Click(object sender, EventArgs e)
        {
            if (alumnList.CountsTotalAlumns() > 0)
            {
                bool added = false;
                do
                {
                    string alumnName = Interaction.InputBox("Introduce the alumn's name (ONLY LETTERS): ");
                    if (CustomFunctions.RegexName(alumnName))
                    {
                        if (alumnList.SameNameCounter(alumnName) > 1)
                        {
                            alumnList.SelectSameNameAlumnsToAddGrade(alumnName);
                            added = true;
                        }
                        else if (alumnList.SameNameCounter(alumnName) == 1)
                        {
                            int alumnPosition = alumnList.GetUniqueNamePosition(alumnName);
                            string alumnID = alumnList.ReturnsAlumnIDFromPosition(alumnPosition);
                            alumnList.MultipleGradeAddingFromSelectedAlumn(alumnID);
                            added = true;
                        }
                        else
                        {
                            MessageBox.Show("There is no alumns with the selected name, try again");
                            added = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The name format is not correct, try again.");
                    }

                } while (!added);
            }
            else
            {
                MessageBox.Show("Error, the list has not alumns added, add an alumn before adding grades to an alumn");
            }
        }

        // IS DONE
        private void btnRemoveGradesToAlumnByName_Click(object sender, EventArgs e)
        {
            if (alumnList.CountsTotalAlumns() > 0)
            {
                if (alumnList.AlumnsWithGradesCounter() > 0)
                {
                    bool removed = false;
                    do
                    {
                        string alumnName = Interaction.InputBox("Introduce the alumn's name (ONLY LETTERS): ");
                        if (CustomFunctions.RegexName(alumnName))
                        {
                            if (alumnList.SameNameCounter(alumnName) > 1)
                            {
                                alumnList.SelectSameNameAlumnsToRemoveGrade(alumnName);
                                removed = true;
                            }
                            else if (alumnList.SameNameCounter(alumnName) == 1)
                            {
                                int alumnPosition = alumnList.GetUniqueNamePosition(alumnName);
                                string alumnID = alumnList.ReturnsAlumnIDFromPosition(alumnPosition);
                                alumnList.MultipleGradeRemovingFromSelectedAlumn(alumnID);
                                removed = true;
                            }
                            else
                            {
                                MessageBox.Show("There is no alumns with the selected name, try again");
                                removed = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("The name format is not correct, try again.");
                        }
                    } while (!removed);
                }
                else
                {
                    MessageBox.Show("There is no alumns with grades added.");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has not alumns added, add an alumn before removing grades to an alumn");
            }
        }

        // IS DONE
        private void btnClearAllGradesToAlumnByName_Click(object sender, EventArgs e)
        {
            if (alumnList.CountsTotalAlumns() > 0)
            {
                if (alumnList.AlumnsWithGradesCounter() > 0)
                {
                    bool cleared = false;
                    do
                    {
                        string alumnName = Interaction.InputBox("Introduce the alumn's name (ONLY LETTERS): ");
                        if (CustomFunctions.RegexName(alumnName))
                        {

                            if (alumnList.SameNameCounter(alumnName) > 1)
                            {
                                alumnList.SelectSameNameAlumnsToClearGrades(alumnName);
                                cleared = true;
                            }
                            else if (alumnList.SameNameCounter(alumnName) == 1)
                            {
                                int alumnPosition = alumnList.GetUniqueNamePosition(alumnName);
                                string alumnID = alumnList.ReturnsAlumnIDFromPosition(alumnPosition);
                                if (alumnList.SelectedAlumnHasGrades(alumnID))
                                {
                                    alumnList.GradesClearing(alumnID);
                                    MessageBox.Show("All grades from this alumn has been cleared.");
                                    cleared = true;
                                }
                                else
                                {
                                    MessageBox.Show("This alumn has not any grades added, clearing them is not needed ");
                                    cleared = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("There is no alumns with the selected name, try again");
                                cleared = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("The name format is not correct, try again.");
                        }
                    } while (!cleared);
                }
                else
                {
                    MessageBox.Show("There is no alumns with grades added.");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has not alumns added, add an alumn before clearing grades to an alumn");
            }
        }

        // IS DONE
        private void btnShowAlumnDataByName_Click(object sender, EventArgs e)
        {
            if (alumnList.CountsTotalAlumns() > 0)
            {
                //TODO CHANGE THIS TO ONLY SHOW DATA FROM ALL ALUMNS WITH SAME NAME
                bool showed = false;
                do
                {
                    string name = Interaction.InputBox("Introduce the alumn's name to show data (ONLY LETTERS): ");

                    if (CustomFunctions.RegexName(name))
                    {
                        if (alumnList.SameNameCounter(name) > 1)
                        {
                            alumnList.SelectSameNameAlumnsToShow(name);
                            showed = true;
                        }
                        else if (alumnList.SameNameCounter(name) == 1)
                        {
                            int alumnPosition = alumnList.GetUniqueNamePosition(name);
                            string alumnID = alumnList.ReturnsAlumnIDFromPosition(alumnPosition);
                            MessageBox.Show(alumnList.ShowsSelectedAlumnDataByID(alumnID));
                            showed = true;
                        }
                        else
                        {
                            MessageBox.Show("There is no alumns with the selected name, try again");
                            showed = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The name format is not correct, try again");
                    }

                } while (!showed);

            }
            else
            {
                MessageBox.Show("Error, the list has not alumns added, add an alumn before checking an alumn data from the alumns list");
            }
        }

        // IS DONE
        private void btnRemoveAlumnByID_Click(object sender, EventArgs e)
        {
            if (alumnList.CountsTotalAlumns() > 0)
            {
                bool removed = false;
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
                                MessageBox.Show("The alumn ( " + alumnName + " ) with the ID ( " + alumnID + " ) was cleared.");
                                removed = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is no alumns with the selected ID");
                            removed = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The ID format is not correct, try again");
                    }

                } while (!removed);
            }
            else
            {
                MessageBox.Show("Error, the list has not alumns added, add an alumn before removing an alumn.");
            }
        }

        // IS DONE
        private void btnAddGradesToAlumnByID_Click(object sender, EventArgs e)
        {
            if (alumnList.CountsTotalAlumns() > 0)
            {
                bool added = false;
                do
                {
                    string alumnID = Interaction.InputBox("Introduce the alumn's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                    if (CustomFunctions.RegexID(alumnID))
                    {
                        if (alumnList.AlreadyUsedID(alumnID))
                        {
                            if (alumnList.CountsTotalAlumns() >= 1)
                            {
                                alumnList.MultipleGradeAddingFromSelectedAlumn(alumnID);
                                added = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is no alumns with the selected ID");
                            added = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The ID format is not correct, try again");
                    }

                } while (!added);
            }
            else
            {
                MessageBox.Show("Error, the list has not alumns added, add an alumn before adding grades to an alumn.");
            }
        }

        // IS DONE
        private void btnRemoveGradesToAlumnByID_Click(object sender, EventArgs e)
        {
            if (alumnList.CountsTotalAlumns() > 0)
            {
                if (alumnList.AlumnsWithGradesCounter() > 0)
                {
                    bool removed = false;
                    do
                    {
                        string alumnID = Interaction.InputBox("Introduce the alumn's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                        if (CustomFunctions.RegexID(alumnID))
                        {
                            if (alumnList.AlreadyUsedID(alumnID))
                            {
                                if (alumnList.CountsTotalAlumns() >= 1)
                                {
                                    alumnList.MultipleGradeRemovingFromSelectedAlumn(alumnID);
                                    removed = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("There is no alumns with the selected ID");
                                removed = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("The ID format is not correct, try again");
                        }

                    } while (!removed);
                }
                else
                {
                    MessageBox.Show("There is no alumns with grades added.");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has not alumns added, add an alumn before removing an alumn.");
            }
        }

        // IS DONE
        private void btnClearAllGradesToAlumnByID_Click(object sender, EventArgs e)
        {
            if (alumnList.CountsTotalAlumns() > 0)
            {
                if (alumnList.AlumnsWithGradesCounter() > 0)
                {
                    bool cleared = false;
                    do
                    {
                        string alumnID = Interaction.InputBox("Introduce the alumn's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                        if (CustomFunctions.RegexID(alumnID))
                        {
                            if (alumnList.AlreadyUsedID(alumnID))
                            {
                                if (alumnList.CountsTotalAlumns() >= 1)
                                {
                                    if (alumnList.SelectedAlumnHasGrades(alumnID))
                                    {
                                        alumnList.GradesClearing(alumnID);
                                        MessageBox.Show("All grades from this alumn has been cleared.");
                                        cleared = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("This alumn has not any grades added, clearing them is not needed ");
                                        cleared = true;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("There is no alumns with the selected ID");
                                cleared = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("The ID format is not correct, try again");
                        }

                    } while (!cleared);
                }
                else
                {
                    MessageBox.Show("There is no alumns with grades added.");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has not alumns added, add an alumn before clearing selected alumn's grades.");
            }
        }

        //IS DONE
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
                        if (alumnList.AlreadyUsedID(alumnID))
                        {
                            MessageBox.Show(alumnList.ShowsSelectedAlumnDataByID(alumnID));
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

        //IS DONE
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
                        if (alumnList.AlumnsInCourse(courseCod))
                        {
                            MessageBox.Show(alumnList.ShowAlumnsBySelectedCourseCod(courseCod));
                            introduced = true;
                        }
                        else
                        {
                            MessageBox.Show("The selected course doesn't have any alumn, select another one.");
                            introduced = true;
                        }
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

        // IS DONE
        private void btnAvgGradesEqualMoreThan5_Click(object sender, EventArgs e)
        {
            if (alumnList.CountsTotalAlumns() > 0)
            {
                if (alumnList.CountAlumnsWhoseGradeIsEqualOrBiggerThan5() > 0)
                {
                    MessageBox.Show(alumnList.ShowsAlumnsWhoseGradesAvgIsEqualOrBiggerThan5());
                }
                else
                {
                    MessageBox.Show("There isn't any alumn whose grade is equal or bigger than 5");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has not alumns added, add an alumn before ordering the alumns list");
            }
        }

        // IS DONE
        private void btnAvgGradesLessThan5_Click(object sender, EventArgs e)
        {
            if (alumnList.CountsTotalAlumns() > 0)
            {
                if (alumnList.CountAlumnsWhoseGradeIsLowerThan5() > 0)
                {
                    MessageBox.Show(alumnList.ShowsAlumnsWhoseGradesAvgIsLowerThan5());
                }
                else
                {
                    MessageBox.Show("There isn't any alumn whose grade is lower than 5");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has not alumns added, add an alumn before ordering the alumns list");
            }
        }
    }
}
