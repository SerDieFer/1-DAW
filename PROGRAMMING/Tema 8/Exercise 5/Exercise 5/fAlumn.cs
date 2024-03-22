using Exercise_5;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Exercise_5
{
    public partial class AlumnForm : Form
    {
        public AlumnForm()
        {
            InitializeComponent();
        }
        
        public PersonList personList;
        public CourseList courseList;

        private void AlumnForm_Load(object sender, EventArgs e)
        {

        }

        public AlumnForm(PersonList personList, CourseList courseList)
        {
            InitializeComponent();
            this.personList = personList;
            this.courseList = courseList;
        }

        // ADDS AN ALUMN
        private void btnAddAlumn_Click(object sender, EventArgs e)
        {
            Alumn anAlumn = new Alumn();
            bool introduced = false;
            do
            {
                string name = Interaction.InputBox("Introduce the alumn's name (ONLY LETTERS): ");
                if (CustomRegex.RegexName(name))
                {
                    string alumnID = Interaction.InputBox("Introduce the alumn's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                    if (CustomRegex.RegexID(alumnID))
                    {
                        if (!personList.AlreadyUsedID(alumnID))
                        {
                            string phoneValue = Interaction.InputBox("Introduce the alumn's phone number (9 DIGITS): \nIt must start with 6 or 7!!\n\nExample 1: 612345678 \nExample 2: 712345678");

                            if (CustomRegex.RegexPhone(phoneValue))
                            {
                                int phone = int.Parse(phoneValue);

                                if (!personList.AlreadyUsedPhone(phone))
                                {
                                    string courseCodValue = Interaction.InputBox("Introduce the alumn's course code \n(MUST BE BIGGER THAN 0): ");

                                    if (CustomRegex.RegexCourseCod(courseCodValue) && int.Parse(courseCodValue) > 0)
                                    {
                                        int courseCod = int.Parse(courseCodValue);
                                        int coursePosition = courseList.ReturnsCoursePosition(courseCod);
                                        if (coursePosition != -1)
                                        {
                                            personList.AddsAlumn(name, alumnID, phone, courseCod);
                                            introduced = true;
                                            MessageBox.Show(name + " was registered.");
                                        }
                                        else
                                        {
                                            MessageBox.Show("The selected course cod doesn't exist, try again");
                                            introduced = true;
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("The course format is not correct, try again.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Not possible, this phone number is already used by a person!!");
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
                            MessageBox.Show("Not possible, this ID is already used by a person!!");
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
            } while (!introduced) ;
        }

        // REMOVES AN ALUMN
        private void btnRemoveAlumnByName_Click(object sender, EventArgs e)
        {
            if (personList.CountTotalAlumns() > 0)
            {
                bool introduced = false;
                do
                {
                    string alumnName = Interaction.InputBox("Introduce the alumn's name to remove (ONLY LETTERS): ");
                    if (CustomRegex.RegexName(alumnName))
                    {
                        if (personList.SameAlumnNameCounter(alumnName) > 1)
                        {
                            personList.SelectSameNameAlumnsToDelete(alumnName);
                            introduced = true;
                        }
                        else if (personList.SameAlumnNameCounter(alumnName) == 1)
                        {
                            int alumnPosition = personList.GetPositionFromUniqueName(alumnName);
                            string alumnID = personList.ReturnsPersonIDFromPosition(alumnPosition);
                            personList.RemovesAlumn(alumnPosition);
                            MessageBox.Show("The alumn ( " + alumnName + " ) with the ID ( " + alumnID + " ) was cleared.");
                            introduced = true;
                        }
                        else
                        {
                            MessageBox.Show("There isn't any alumn with the selected name, try again");
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
                MessageBox.Show("Error, the list has no added alumns, add an alumn before removing an alumn.");
            }
        }

        // ADDS MULTIPLE GRADES TO A SELECTED ALUMN BY NAME
        private void btnAddGradesToAlumnByName_Click(object sender, EventArgs e)
        {
            if (personList.CountTotalAlumns() > 0)
            {
                bool added = false;
                do
                {
                    string alumnName = Interaction.InputBox("Introduce the alumn's name (ONLY LETTERS): ");
                    if (CustomRegex.RegexName(alumnName))
                    {
                        if (personList.SameAlumnNameCounter(alumnName) > 1)
                        {
                            personList.SelectSameNameAlumnsToAddGrade(alumnName);
                            added = true;
                        }
                        else if (personList.SameAlumnNameCounter(alumnName) == 1)
                        {
                            int alumnPosition = personList.GetPositionFromUniqueName(alumnName);
                            string alumnID = personList.ReturnsPersonIDFromPosition(alumnPosition);
                            personList.MultipleGradeAddingFromSelectedAlumn(alumnID);
                            added = true;
                        }
                        else
                        {
                            MessageBox.Show("There isn't any alumn with the selected name, try again");
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
                MessageBox.Show("Error, the list has no added alumns, add an alumn before adding grades to an alumn");
            }
        }

        // REMOVES MULTIPLE GRADES TO A SELECTED ALUMN BY NAME
        private void btnRemoveGradesToAlumnByName_Click(object sender, EventArgs e)
        {
            if (personList.CountTotalAlumns() > 0)
            {
                if (personList.AlumnsWithGradesCounter() > 0)
                {
                    bool removed = false;
                    do
                    {
                        string alumnName = Interaction.InputBox("Introduce the alumn's name (ONLY LETTERS): ");
                        if (CustomRegex.RegexName(alumnName))
                        {
                            if (personList.SameAlumnNameCounter(alumnName) > 1)
                            {
                                personList.SelectSameNameAlumnsToRemoveGrade(alumnName);
                                removed = true;
                            }
                            else if (personList.SameAlumnNameCounter(alumnName) == 1)
                            {
                                int alumnPosition = personList.GetPositionFromUniqueName(alumnName);
                                string alumnID = personList.ReturnsPersonIDFromPosition(alumnPosition);
                                personList.MultipleGradeRemovingFromSelectedAlumn(alumnID);
                                removed = true;
                            }
                            else
                            {
                                MessageBox.Show("There isn't any alumn with the selected name, try again");
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
                    MessageBox.Show("There aren't any alumns with grades added.");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has no added alumns, add an alumn before removing grades to an alumn");
            }
        }

        // CLEAR ALL GRADES TO A SELECTED ALUMN BY NAME
        private void btnClearAllGradesToAlumnByName_Click(object sender, EventArgs e)
        {
            if (personList.CountTotalAlumns() > 0)
            {
                if (personList.AlumnsWithGradesCounter() > 0)
                {
                    bool cleared = false;
                    do
                    {
                        string alumnName = Interaction.InputBox("Introduce the alumn's name (ONLY LETTERS): ");
                        if (CustomRegex.RegexName(alumnName))
                        {

                            if (personList.SameAlumnNameCounter(alumnName) > 1)
                            {
                                personList.SelectSameNameAlumnsToClearGrades(alumnName);
                                cleared = true;
                            }
                            else if (personList.SameAlumnNameCounter(alumnName) == 1)
                            {
                                int alumnPosition = personList.GetPositionFromUniqueName(alumnName);
                                string alumnID = personList.ReturnsPersonIDFromPosition(alumnPosition);
                                if (personList.SelectedAlumnHasGrades(alumnID))
                                {
                                    personList.GradesClearing(alumnID);
                                    MessageBox.Show("All grades from this alumn has been cleared.");
                                    cleared = true;
                                }
                                else
                                {
                                    MessageBox.Show("This alumn has no added grades, clearing them is not needed ");
                                    cleared = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("There isn't any alumn with the selected name, try again");
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
                    MessageBox.Show("There aren't any alumns with grades added.");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has no added alumns, add an alumn before clearing grades to an alumn");
            }
        }

        // SHOWS ALL DATA FROM A SELECTED ALUMN BY NAME
        private void btnShowAlumnDataByName_Click(object sender, EventArgs e)
        {
            if (personList.CountTotalAlumns() > 0)
            {
                bool showed = false;
                do
                {
                    string name = Interaction.InputBox("Introduce the alumn's name to show data (ONLY LETTERS): ");

                    if (CustomRegex.RegexName(name))
                    {
                        if (personList.SameAlumnNameCounter(name) > 1)
                        {
                            personList.SelectSameNameAlumnsToShow(name);
                            showed = true;
                        }
                        else if (personList.SameAlumnNameCounter(name) == 1)
                        {
                            int alumnPosition = personList.GetPositionFromUniqueName(name);
                            string alumnID = personList.ReturnsPersonIDFromPosition(alumnPosition);
                            MessageBox.Show(personList.ShowsSelectedAlumnDataByID(alumnID));
                            showed = true;
                        }
                        else
                        {
                            MessageBox.Show("There isn't any alumn with the selected name, try again");
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
                MessageBox.Show("Error, the list has no added alumns, add an alumn before checking an alumn data from the alumns list");
            }
        }

        // REMOVES A SELECTED ALUMN BY ID
        private void btnRemoveAlumnByID_Click(object sender, EventArgs e)
        {
            if (personList.CountTotalAlumns() > 0)
            {
                bool removed = false;
                do
                {
                    string alumnID = Interaction.InputBox("Introduce the alumn's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                    if (CustomRegex.RegexID(alumnID))
                    {
                        if (personList.AlreadyUsedID(alumnID))
                        {
                            if (personList.CountTotalAlumns() >= 1)
                            {
                                int alumnPosition = personList.ReturnPersonPosition(alumnID);
                                string alumnName = personList.ReturnsPersonName(alumnID);
                                personList.RemovesAlumn(alumnPosition);
                                MessageBox.Show("The alumn ( " + alumnName + " ) with the ID ( " + alumnID + " ) was cleared.");
                                removed = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("There isn't any alumn with the selected ID");
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
                MessageBox.Show("Error, the list has no added alumns, add an alumn before removing an alumn.");
            }
        }

        // ADDS MULTIPLE GRADES TO A SELECTED ALUMN BY ID
        private void btnAddGradesToAlumnByID_Click(object sender, EventArgs e)
        {
            if (personList.CountTotalAlumns() > 0)
            {
                bool added = false;
                do
                {
                    string alumnID = Interaction.InputBox("Introduce the alumn's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                    if (CustomRegex.RegexID(alumnID))
                    {
                        if (personList.AlreadyUsedID(alumnID))
                        {
                            if (personList.CountTotalAlumns() >= 1)
                            {
                                personList.MultipleGradeAddingFromSelectedAlumn(alumnID);
                                added = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("There isn't any alumn with the selected ID");
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
                MessageBox.Show("Error, the list has no added alumns, add an alumn before adding grades to an alumn.");
            }
        }

        // REMOVES MULTIPLE GRADES TO A SELECTED ALUMN BY ID
        private void btnRemoveGradesToAlumnByID_Click(object sender, EventArgs e)
        {
            if (personList.CountTotalAlumns() > 0)
            {
                if (personList.AlumnsWithGradesCounter() > 0)
                {
                    bool removed = false;
                    do
                    {
                        string alumnID = Interaction.InputBox("Introduce the alumn's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                        if (CustomRegex.RegexID(alumnID))
                        {
                            if (personList.AlreadyUsedID(alumnID))
                            {
                                if (personList.CountTotalAlumns() >= 1)
                                {
                                    personList.MultipleGradeRemovingFromSelectedAlumn(alumnID);
                                    removed = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("There isn't any alumn with the selected ID");
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
                MessageBox.Show("Error, the list has no added alumns, add an alumn before removing an alumn.");
            }
        }

        // CLEAR ALL GRADES TO A SELECTED ALUMN BY ID
        private void btnClearAllGradesToAlumnByID_Click(object sender, EventArgs e)
        {
            if (personList.CountTotalAlumns() > 0)
            {
                if (personList.AlumnsWithGradesCounter() > 0)
                {
                    bool cleared = false;
                    do
                    {
                        string alumnID = Interaction.InputBox("Introduce the alumn's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                        if (CustomRegex.RegexID(alumnID))
                        {
                            if (personList.AlreadyUsedID(alumnID))
                            {
                                if (personList.CountTotalAlumns() >= 1)
                                {
                                    if (personList.SelectedAlumnHasGrades(alumnID))
                                    {
                                        personList.GradesClearing(alumnID);
                                        MessageBox.Show("All grades from this alumn has been cleared.");
                                        cleared = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("This alumn has no added grades, clearing them is not needed ");
                                        cleared = true;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("There isn't any alumn with the selected ID");
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
                    MessageBox.Show("There aren't any alumns with grades added.");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has no added alumns, add an alumn before clearing selected alumn's grades.");
            }
        }

        // SHOWS ALL DATA FROM A SELECTED ALUMN BY ID
        private void btnShowAlumnDataByID_Click(object sender, EventArgs e)
        {
            if (personList.CountTotalAlumns() > 0)
            {
                bool introduced = false;
                do
                {
                    string alumnID = Interaction.InputBox("Introduce the alumn's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                    if (CustomRegex.RegexID(alumnID))
                    {
                        if (personList.AlreadyUsedID(alumnID))
                        {
                            MessageBox.Show(personList.ShowsSelectedAlumnDataByID(alumnID));
                            introduced = true;
                        }
                        else
                        {
                            MessageBox.Show("There isn`t any alumn with the selected ID, try again");
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
                MessageBox.Show("Error, the list has no added alumns, add an alumn before checking an alumn data from the alumns list");
            }
        }

        // SHOWS ALL ALUMNS FROM A SELECTED COURSE BY COD
        private void btnShowAlumnsFromSelectedCourse_Click(object sender, EventArgs e)
        {
            bool introduced = false;
            if (personList.CountTotalAlumns() > 0)
            {
                do
                {
                    string courseCodValue = Interaction.InputBox("Introduce the course code to show the alumns who are registered in it (FROM 1 TO ∞): ");
                    if (CustomRegex.RegexCourseCod(courseCodValue))
                    {
                        int courseCod = int.Parse(courseCodValue);
                        if (personList.AlumnInCourse(courseCod))
                        {
                            MessageBox.Show(personList.ShowAlumnsBySelectedCourseCod(courseCod));
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
                MessageBox.Show("Error, the list has no added alumns, add an alumn before showing the alumns from the selected course.");
            }
        }

        // SHOWS ALL ALUMNS ADDED
        private void btnShowAlumnList_Click(object sender, EventArgs e)
        {
            if (personList.CountTotalAlumns() > 0)
            {
                MessageBox.Show(personList.ShowsAlumnsList());
            }
            else
            {
                MessageBox.Show("There isn't added any alumn to the list, add an alumn before trying again");
            }
        }

        // SORTS ALUMN LIST IN ALPHABETICAL ORDER
        private void btnSortAlumnsAlphabetically_Click(object sender, EventArgs e)
        {
            if (personList.CountTotalAlumns() > 0)
            {
                if (personList.CountTotalAlumns() == 1)
                {
                    MessageBox.Show("Error, the list has only one alumn, add atleast 2 alumns to order the list");
                }
                else
                {
                    personList.SortListAlphabeticallyByAlumn();
                    MessageBox.Show("The list was correctly sorted by alphabetical order");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has no added alumns, add an alumn before ordering the alumns list");
            }
        }

        // SHOWS ALL ALUMNS WHOSE GRADES AVERAGE IS EQUAL OR BIGGER THAN 5
        private void btnAvgGradesEqualMoreThan5_Click(object sender, EventArgs e)
        {
            if (personList.CountTotalAlumns() > 0)
            {
                if (personList.CountAlumnsWhoseGradeIsEqualOrBiggerThan5() > 0)
                {
                    MessageBox.Show(personList.ShowsAlumnsWhoseGradesAvgIsEqualOrBiggerThan5());
                }
                else
                {
                    MessageBox.Show("There isn't any alumn whose grade is equal or bigger than 5");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has no added alumns, add an alumn before ordering the alumns list");
            }
        }

        // SHOWS ALL ALUMNS WHOSE GRADES AVERAGE IS LOWER THAN 5
        private void btnAvgGradesLessThan5_Click(object sender, EventArgs e)
        {
            if (personList.CountTotalAlumns() > 0)
            {
                if (personList.CountAlumnsWhoseGradeIsLowerThan5() > 0)
                {
                    MessageBox.Show(personList.ShowsAlumnsWhoseGradesAvgIsLowerThan5());
                }
                else
                {
                    MessageBox.Show("There isn't any alumn whose grade is lower than 5");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has no added alumns, add an alumn before ordering the alumns list");
            }
        }
    }
}
