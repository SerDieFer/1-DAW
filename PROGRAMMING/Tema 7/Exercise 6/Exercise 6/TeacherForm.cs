using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_6
{
    // TODO CANCEL BUTTON?
    // CHECKS EVERYTHING WORKS
    // RENAME MB CONTENT

    public partial class TeacherForm : Form
    {
        public TeacherForm()
        {
            InitializeComponent();
        }

        public TeacherList teacherList;
        public AlumnList alumnList;
        private void TeacherForm_Load(object sender, EventArgs e)
        {
        }
 
        public TeacherForm (TeacherList teacherList, AlumnList alumnList)
        {
            InitializeComponent();
            this.teacherList = teacherList;
            this.alumnList = alumnList;
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            Teacher aTeacher = new Teacher();
            bool introduced = false;
            do
            {
                string teacherName = Interaction.InputBox("Introduce the teacher's teacherName (ONLY LETTERS): ");

                if (CustomFunctions.RegexName(teacherName))
                {
                    string teacherID = Interaction.InputBox("Introduce the teacher's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                    if (CustomFunctions.RegexID(teacherID))
                    {
                        if (!teacherList.AlreadyUsedID(teacherID))
                        {
                            if (!alumnList.AlreadyUsedID(teacherID))
                            {
                                string phoneValue = Interaction.InputBox("Introduce the teacher's phone number (9 DIGITS): \nIt must start with 6 or 7!!\n\nExample 1: 612345678 \nExample 2: 712345678");

                                if (CustomFunctions.RegexPhone(phoneValue))
                                {
                                    int phone = int.Parse(phoneValue);
                                    if (!teacherList.AlreadyUsedPhone(phone))
                                    {
                                        if (!alumnList.AlreadyUsedPhone(phone))
                                        {
                                            DialogResult isTutorResult = MessageBox.Show("Is the teacher a mentor for any course?", "Course Mentor", MessageBoxButtons.YesNo);
                                            if (isTutorResult == DialogResult.Yes)
                                            {
                                                string mentorCourseCod = Interaction.InputBox("Introduce the course code where the teacher is the mentor \n(MUST BE BIGGER THAN 0): ");

                                                if (CustomFunctions.RegexCourseCod(mentorCourseCod) && int.Parse(mentorCourseCod) > 0)
                                                {
                                                    int courseMentorCod = int.Parse(mentorCourseCod);
                                                    teacherList.AddsTeacher(teacherName, teacherID, phone, courseMentorCod);
                                                    introduced = true;
                                                    MessageBox.Show(teacherName + " was registered as the mentor teacher of the course Nº" + courseMentorCod + ".");

                                                }
                                                else
                                                {
                                                    MessageBox.Show("The course code format is not correct, try again.");
                                                }
                                            }
                                            else if (isTutorResult == DialogResult.No)
                                            {
                                                teacherList.AddsTeacher(teacherName, teacherID, phone, -1);
                                                introduced = true;
                                                MessageBox.Show(teacherName + " was registered as a teacher.");
                                            }                       
                                        }
                                        else
                                        {
                                            MessageBox.Show("Not possible, this phone number is already used by an alumn!!");
                                            introduced = true;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Not possible, this phone number is already used by a teacher!!");
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
                                MessageBox.Show("Not possible, this ID is already used by an alumn!!");
                                introduced = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Not possible, this ID is already used by a teacher!!");
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
                    MessageBox.Show("The teacherName format is not correct, try again.");
                }
            } while (!introduced);
        }

        private void btnRemoveTeacherByID_Click(object sender, EventArgs e)
        {
            if (teacherList.CountsTotalTeachers() > 0)
            {
                bool removed = false;
                do
                {
                    string teacherID = Interaction.InputBox("Introduce the teacher's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                    if (CustomFunctions.RegexID(teacherID))
                    {
                        if (teacherList.AlreadyUsedID(teacherID))
                        {
                            if (teacherList.CountsTotalTeachers() >= 1)
                            {
                                int teacherPosition = teacherList.ReturnsTeacherPositionFromID(teacherID);
                                string teacherName = teacherList.ReturnsTeacherName(teacherID);
                                teacherList.RemovesTeacher(teacherPosition);
                                MessageBox.Show("The teacher ( " + teacherName + " ) with the ID ( " + teacherID + " ) was removed.");
                                removed = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is no teacher with the selected ID");
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
                MessageBox.Show("Error, the list has not teachers added, add a teacher before removing a teacher.");
            }
        }

        private void btnRemoveTeacherByName_Click(object sender, EventArgs e)
        {
            if (teacherList.CountsTotalTeachers() > 0)
            {
                bool introduced = false;
                do
                {
                    string teacherName = Interaction.InputBox("Introduce the teacher's teacherName to remove (ONLY LETTERS): ");
                    if (CustomFunctions.RegexName(teacherName))
                    {
                        if (teacherList.SameNameCounter(teacherName) > 1)
                        {
                            teacherList.SelectSameNameTeachersToDelete(teacherName);
                            introduced = true;
                        }
                        else if (teacherList.SameNameCounter(teacherName) == 1)
                        {
                            int teacherPosition = teacherList.GetUniqueNamePosition(teacherName);
                            string teacherID = teacherList.ReturnsTeacherIDFromPosition(teacherPosition);
                            teacherList.RemovesTeacher(teacherPosition);
                            MessageBox.Show("The teacher ( " + teacherName + " ) with the ID ( " + teacherID + " ) was removed.");
                            introduced = true;
                        }
                        else
                        {
                            MessageBox.Show("There aren't any teachers with the selected name, try again");
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
                MessageBox.Show("Error, the list has not teachers added, add a teacher before removing a teacher.");
            }
        }

        private void btnShowTeacherDataByID_Click(object sender, EventArgs e)
        {
            if (teacherList.CountsTotalTeachers() > 0)
            {
                bool introduced = false;
                do
                {
                    string teacherID = Interaction.InputBox("Introduce the teacher's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                    if (CustomFunctions.RegexID(teacherID))
                    {
                        if (teacherList.AlreadyUsedID(teacherID))
                        {
                            MessageBox.Show(teacherList.ShowsSelectedTeacherDataByID(teacherID));
                            introduced = true;
                        }
                        else
                        {
                            MessageBox.Show("There is no teacher with the selected ID, try again");
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
                MessageBox.Show("Error, the list has not teachers added, add a teacher before checking a teacher data from the teacher list");
            }
        }

        private void btnShowTeacherDataByName_Click(object sender, EventArgs e)
        {
            if (teacherList.CountsTotalTeachers() > 0)
            {
                //TODO CHANGE THIS TO ONLY SHOW DATA FROM ALL TEACHERS WITH SAME NAME
                bool showed = false;
                do
                {
                    string teacherName = Interaction.InputBox("Introduce the teacher's name to show data (ONLY LETTERS): ");

                    if (CustomFunctions.RegexName(teacherName))
                    {
                        if (teacherList.SameNameCounter(teacherName) > 1)
                        {
                            teacherList.SelectSameNameTeachersToShow(teacherName);
                            showed = true;
                        }
                        else if (alumnList.SameNameCounter(teacherName) == 1)
                        {
                            int teacherPosition = teacherList.GetUniqueNamePosition(teacherName);
                            string teacherID = teacherList.ReturnsTeacherIDFromPosition(teacherPosition);
                            MessageBox.Show(teacherList.ShowsSelectedTeacherDataByID(teacherID));
                            showed = true;
                        }
                        else
                        {
                            MessageBox.Show("There aren't any teachers with the selected name, try again");
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
                MessageBox.Show("Error, the list has not teachers added, add a teacher before checking a teacher data from the teacher list");
            }
        }

        private void btnShowTeacherList_Click(object sender, EventArgs e)
        {
            if (teacherList.CountsTotalTeachers() != 0)
            {
                MessageBox.Show(teacherList.ShowsTeachersList());
            }
            else
            {
                MessageBox.Show("There aren't any teachers added to the list, add a teacher before trying again");
            }
        }

        private void btnSortAlumnsAlphabetically_Click(object sender, EventArgs e)
        {
            if (teacherList.CountsTotalTeachers() > 0)
            {
                if (teacherList.CountsTotalTeachers() == 1)
                {
                    MessageBox.Show("Error, the list has only one teacher, add atleast 2 teachers to order the list");
                }
                else
                {
                    teacherList.SortTeachersListAlphabetically();
                    MessageBox.Show("The list was correctly sorted by alphabetical order");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has not teachers added, add a teacher before ordering the teacher list");
            }
        }

        private void btnAddSubjectToSelectedTeacherByName_Click(object sender, EventArgs e)
        {
            if (teacherList.CountsTotalTeachers() > 0)
            {
                bool added = false;
                do
                {
                    string teacherName = Interaction.InputBox("Introduce the teacher's name (ONLY LETTERS): ");
                    if (CustomFunctions.RegexName(teacherName))
                    {
                        if (teacherList.SameNameCounter(teacherName) > 1)
                        {
                            teacherList.SelectSameNameTeachersToAddSubjects(teacherName);
                            added = true;
                        }
                        else if (teacherList.SameNameCounter(teacherName) == 1)
                        {
                            int teacherPosition = teacherList.GetUniqueNamePosition(teacherName);
                            string teacherID = teacherList.ReturnsTeacherIDFromPosition(teacherPosition);
                            teacherList.MultipleSubjectsAddingFromSelectedTeacher(teacherID);
                            added = true;
                        }
                        else
                        {
                            MessageBox.Show("There aren't any teachers with the selected name, try again");
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
                MessageBox.Show("Error, the list has not teachers added, add a teacher before ordering the teacher list");
            }
        }

        private void btnRemoveSubjectToSelectedTeacherByName_Click(object sender, EventArgs e)
        {
            if (teacherList.CountsTotalTeachers() > 0)
            {
                if (teacherList.TeachersWithSubjectsCounter() > 0)
                {
                    bool removed = false;
                    do
                    {
                        string teacherName = Interaction.InputBox("Introduce the teacher's name (ONLY LETTERS): ");
                        if (CustomFunctions.RegexName(teacherName))
                        {
                            if (teacherList.SameNameCounter(teacherName) > 1)
                            {
                                teacherList.SelectSameNameTeachersToRemoveSubjects(teacherName);
                                removed = true;
                            }
                            else if (teacherList.SameNameCounter(teacherName) == 1)
                            {
                                int teacherPosition = teacherList.GetUniqueNamePosition(teacherName);
                                string teacherID = teacherList.ReturnsTeacherIDFromPosition(teacherPosition);
                                teacherList.MultipleSubjectsRemovalFromSelectedTeacher(teacherID);
                                removed = true;
                            }
                            else
                            {
                                MessageBox.Show("There aren't any teachers with the selected name, try again");
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
                    MessageBox.Show("There aren't any teachers with subjects added.");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has not teachers added, add a teacher before ordering the teacher list");
            }
        }

        private void btnClearSubjectsToSelectedTeacherByName_Click(object sender, EventArgs e)
        {
            if (teacherList.CountsTotalTeachers() > 0)
            {
                if (teacherList.TeachersWithSubjectsCounter() > 0)
                {
                    bool cleared = false;
                    do
                    {
                        string teacherName = Interaction.InputBox("Introduce the alumn's name (ONLY LETTERS): ");
                        if (CustomFunctions.RegexName(teacherName))
                        {
                            if (teacherList.SameNameCounter(teacherName) > 1)
                            {
                                teacherList.SelectSameNameTeachersToClearSubjects(teacherName);
                                cleared = true;
                            }
                            else if (teacherList.SameNameCounter(teacherName) == 1)
                            {
                                int teacherPosition = teacherList.GetUniqueNamePosition(teacherName);
                                string teacherID = teacherList.ReturnsTeacherIDFromPosition(teacherPosition);
                                if (teacherList.SelectedTeacherHasSubject(teacherID))
                                {
                                    teacherList.SubjectsClearing(teacherID);
                                    MessageBox.Show("All subjects from this teacher has been cleared.");
                                    cleared = true;
                                }
                                else
                                {
                                    MessageBox.Show("This teacher has not any subjects added, clearing them is not needed ");
                                    cleared = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("There aren't any teachers with the selected name, try again");
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
                    MessageBox.Show("There aren't any teachers with subjects added.");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has not teachers added, add a teacher before clearing subjects to a teacher");
            }
        }

        private void btnAddSubjectToSelectedTeacherByID_Click(object sender, EventArgs e)
        {
            if (teacherList.CountsTotalTeachers() > 0)
            {
                bool added = false;
                do
                {
                    string teacherID = Interaction.InputBox("Introduce the teacher's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                    if (CustomFunctions.RegexID(teacherID))
                    {
                        if (teacherList.AlreadyUsedID(teacherID))
                        {
                            if (teacherList.CountsTotalTeachers() >= 1)
                            {
                                teacherList.MultipleSubjectsAddingFromSelectedTeacher(teacherID);
                                added = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is no teacher with the selected ID");
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
                MessageBox.Show("Error, the list has not teachers added, add a teacher before adding subjects to a teacher");
            }
        }

        private void btnRemoveSubjectToSelectedTeacherByID_Click(object sender, EventArgs e)
        {
            if (teacherList.CountsTotalTeachers() > 0)
            {
                if (teacherList.TeachersWithSubjectsCounter() > 0)
                {
                    bool removed = false;
                    do
                    {
                        string teacherID = Interaction.InputBox("Introduce the teacher's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                        if (CustomFunctions.RegexID(teacherID))
                        {
                            if (teacherList.AlreadyUsedID(teacherID))
                            {
                                if (teacherList.CountsTotalTeachers() >= 1)
                                {
                                    teacherList.MultipleSubjectsRemovalFromSelectedTeacher(teacherID);
                                    removed = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("There is no teacher with the selected ID");
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
                    MessageBox.Show("There aren't any teachers with subjects added.");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has not alumns added, add an alumn before removing an alumn.");
            }
        }

        private void btnClearSubjectsToSelectedTeacherByID_Click(object sender, EventArgs e)
        {
            if (teacherList.CountsTotalTeachers() > 0)
            {
                if (teacherList.TeachersWithSubjectsCounter() > 0)
                {
                    bool cleared = false;
                    do
                    {
                        string teacherID = Interaction.InputBox("Introduce the teacher's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                        if (CustomFunctions.RegexID(teacherID))
                        {
                            if (teacherList.AlreadyUsedID(teacherID))
                            {
                                if (teacherList.CountsTotalTeachers() >= 1)
                                {
                                    if (teacherList.SelectedTeacherHasSubject(teacherID))
                                    {
                                        teacherList.SubjectsClearing(teacherID);
                                        MessageBox.Show("All subjects from this teacher has been cleared.");
                                        cleared = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("This teacher has not any subject added, clearing them is not needed ");
                                        cleared = true;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("There is no teacher with the selected ID");
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
                    MessageBox.Show("There aren't any teacher with subjects added.");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has not teachers added, add a teacher before clearing selected teacher's subjects.");
            }
        }

        private void btnShowTeachersBySelectedSubject_Click(object sender, EventArgs e)
        {
            bool introduced = false;
            if (teacherList.CountsTotalTeachers() > 0)
            {
                do
                {
                    string subjectName = Interaction.InputBox("Introduce the subject's name to show the teachers who impart it: ");
                    if (CustomFunctions.RegexName(subjectName))
                    {
                        if (teacherList.SelectedSubjectHasTeachers(subjectName) > 0)
                        {
                            MessageBox.Show(teacherList.ShowTeachersBySubjectName(subjectName));
                            introduced = true;
                        }
                        else
                        {
                            MessageBox.Show("The selected subject doesn't have any teacher imparting it, select another one.");
                            introduced = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The subject name format is not correct, try again");
                    }

                } while (!introduced);
            }
            else
            {
                MessageBox.Show("Error, the list has not teachers added, add a teacher before showing the teachers who imparts the selected subject.");
            }
        }
    }
}
