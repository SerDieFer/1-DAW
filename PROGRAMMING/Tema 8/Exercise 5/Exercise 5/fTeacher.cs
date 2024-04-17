using Exercise_5;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Exercise_5
{
    public partial class TeacherForm : Form
    {
        public TeacherForm()
        {
            InitializeComponent();
        }

        public PersonList personList;
        public CourseList courseList;

        private void TeacherForm_Load(object sender, EventArgs e)
        {
        }
 
        public TeacherForm (PersonList personList, CourseList courseList)
        {
            InitializeComponent();
            this.personList = personList;
            this.courseList = courseList;
        }

        // ADDS A TEACHER
        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            Teacher aTeacher = new Teacher();
            bool introduced = false;
            do
            {
                string teacherName = Interaction.InputBox("Introduce the teacher's name (ONLY LETTERS): ");

                if (CustomRegex.RegexName(teacherName))
                {
                    string teacherID = Interaction.InputBox("Introduce the teacher's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                    if (CustomRegex.RegexID(teacherID))
                    {
                        if (!personList.AlreadyUsedID(teacherID))
                        {
                            string phoneValue = Interaction.InputBox("Introduce the teacher's phone number (9 DIGITS): \nIt must start with 6 or 7!!\n\nExample 1: 612345678 \nExample 2: 712345678");

                            if (CustomRegex.RegexPhone(phoneValue))
                            {
                                int phone = int.Parse(phoneValue);

                                if (!personList.AlreadyUsedPhone(phone))
                                {
                                    string email = Interaction.InputBox("Introduce the teacher's email: \nIt must end with @edu.gva.es!!\n\nExample 1: soyElProfe2@edu.gva.es");

                                    if (CustomRegex.RegexEmail(email))
                                    {
                                        if (!personList.AlreadyUsedEmail(email))
                                        {
                                            DialogResult isTutorResult = MessageBox.Show("Is the teacher a mentor for any course?", "Course Mentor", MessageBoxButtons.YesNo);
                                            if (isTutorResult == DialogResult.Yes)
                                            {
                                                string mentorCourseCod = Interaction.InputBox("Introduce the course code where the teacher is the mentor \n(MUST BE BIGGER THAN 0): ");

                                                if (CustomRegex.RegexCourseCod(mentorCourseCod) && int.Parse(mentorCourseCod) > 0)
                                                {
                                                    int courseMentorCod = int.Parse(mentorCourseCod);
                                                    int coursePosition = courseList.ReturnsCoursePosition(courseMentorCod);
                                                    if (coursePosition != -1)
                                                    {
                                                        if (!personList.CourseAlreadyHasTutor(courseMentorCod))
                                                        {
                                                            personList.AddsTeacher(teacherName, teacherID, phone, email, courseMentorCod);
                                                            MessageBox.Show(teacherName + " was registered as the mentor teacher of the course Nº" + courseMentorCod + ".");
                                                            introduced = true;
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("The selected course cod already has a tutor asigned.");
                                                            introduced = true;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("The selected course cod doesn't exist, try again");
                                                        introduced = true;
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("The course code format is not correct, try again.");
                                                }
                                            }
                                            else if (isTutorResult == DialogResult.No)
                                            {
                                                personList.AddsTeacher(teacherName, teacherID, phone, email, -1);
                                                introduced = true;
                                                MessageBox.Show(teacherName + " was registered as a teacher.");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Not possible, this email is already used by a person!!");
                                            introduced = true;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("The email format is not correct, try again.");
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
            } while (!introduced);
        }

        // REMOVES SELECTED TEACHER BY ID
        private void btnRemoveTeacherByID_Click(object sender, EventArgs e)
        {
            if (personList.CountsTotalTeachers() > 0)
            {
                bool removed = false;
                do
                {
                    string teacherID = Interaction.InputBox("Introduce the teacher's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                    if (CustomRegex.RegexID(teacherID))
                    {
                        if (personList.AlreadyUsedID(teacherID))
                        {
                            int validation = personList.CheckTypeOfPerson(teacherID);
                            if (validation == 1)
                            {
                                if (personList.CountsTotalTeachers() >= 1)
                                {
                                    int teacherPosition = personList.ReturnPersonPosition(teacherID);
                                    string teacherName = personList.ReturnsPersonName(teacherID);
                                    personList.RemovesTeacher(teacherPosition);
                                    MessageBox.Show("The teacher ( " + teacherName + " ) with the ID ( " + teacherID + " ) was removed.");
                                    removed = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("There isn't any teacher with the selected ID");
                                removed = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("There isn't any person with the selected ID");
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
                MessageBox.Show("Error, the list has no added teachers, add a teacher before removing a teacher.");
            }
        }

        // REMOVES SELECTED TEACHER BY NAME
        private void btnRemoveTeacherByName_Click(object sender, EventArgs e)
        {
            if (personList.CountsTotalTeachers() > 0)
            {
                bool introduced = false;
                do
                {
                    string teacherName = Interaction.InputBox("Introduce the teacher's name to remove (ONLY LETTERS): ");
                    if (CustomRegex.RegexName(teacherName))
                    {
                        if (personList.SameTeacherNameCounter(teacherName) > 1)
                        {
                            personList.SelectSameNameTeachersToDelete(teacherName);
                            introduced = true;
                        }
                        else if (personList.SameTeacherNameCounter(teacherName) == 1)
                        {
                            int teacherPosition = personList.GetPositionFromUniqueName(teacherName);
                            string teacherID = personList.ReturnsPersonIDFromPosition(teacherPosition);
                            personList.RemovesTeacher(teacherPosition);
                            MessageBox.Show("The teacher ( " + teacherName + " ) with the ID ( " + teacherID + " ) was removed.");
                            introduced = true;
                        }
                        else
                        {
                            MessageBox.Show("There isn't any teacher with the selected name, try again");
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
                MessageBox.Show("Error, the list has no added teachers, add a teacher before removing a teacher.");
            }
        }

        // SHOWS SELECTED TEACHER DATA BY ID
        private void btnShowTeacherDataByID_Click(object sender, EventArgs e)
        {
            if (personList.CountsTotalTeachers() > 0)
            {
                bool introduced = false;
                do
                {
                    string teacherID = Interaction.InputBox("Introduce the teacher's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                    if (CustomRegex.RegexID(teacherID))
                    {
                        if (personList.AlreadyUsedID(teacherID))
                        {
                            int validation = personList.CheckTypeOfPerson(teacherID);
                            if (validation == 1)
                            {
                                MessageBox.Show(personList.ShowsSelectedTeacherDataByID(teacherID));
                                introduced = true;
                            }
                            else
                            {
                                MessageBox.Show("The selected ID is not from a teacher, try another ID.");
                                introduced = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("There isn't any teacher with the selected ID, try again");
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
                MessageBox.Show("Error, the list has no added teachers, add a teacher before checking a teacher data from the teacher list");
            }
        }

        // SHOWS SELECTED TEACHER DATA BY NAME
        private void btnShowTeacherDataByName_Click(object sender, EventArgs e)
        {
            if (personList.CountsTotalTeachers() > 0)
            {
                bool showed = false;
                do
                {
                    string teacherName = Interaction.InputBox("Introduce the teacher's name to show data (ONLY LETTERS): ");

                    if (CustomRegex.RegexName(teacherName))
                    {
                        if (personList.SameTeacherNameCounter(teacherName) > 1)
                        {
                            personList.SelectSameNameTeachersToShow(teacherName);
                            showed = true;
                        }
                        else if (personList.SameTeacherNameCounter(teacherName) == 1)
                        {
                            int teacherPosition = personList.GetPositionFromUniqueName(teacherName);
                            string teacherID = personList.ReturnsPersonIDFromPosition(teacherPosition);
                            MessageBox.Show(personList.ShowsSelectedTeacherDataByID(teacherID));
                            showed = true;
                        }
                        else
                        {
                            MessageBox.Show("There isn't any teacher with the selected name, try again");
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
                MessageBox.Show("Error, the list has no added teachers, add a teacher before checking a teacher data from the teacher list");
            }
        }

        // SHOWS TEACHERS LIST
        private void btnShowTeacherList_Click(object sender, EventArgs e)
        {
            if (personList.CountsTotalTeachers() != 0)
            {
                MessageBox.Show(personList.ShowsTeachersList());
            }
            else
            {
                MessageBox.Show("There aren't any teachers added to the list, add a teacher before trying again");
            }
        }

        // SORTS TEACHER LIST BY ALPHABETICAL ORDER
        private void btnSortTeachersAlphabetically_Click(object sender, EventArgs e)
        {
            if (personList.CountsTotalTeachers() > 0)
            {
                if (personList.CountsTotalTeachers() == 1)
                {
                    MessageBox.Show("Error, the list has only one teacher, add atleast 2 teachers to order the list");
                }
                else
                {
                    personList.SortListAlphabeticallyByTeacher();
                    MessageBox.Show("The list was correctly sorted by alphabetical order");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has no added teachers, add a teacher before ordering the teacher list");
            }
        }

        // ADDS MULTIPLE SUBJECTS TO SELECTED TEACHER BY NAME
        private void btnAddSubjectToSelectedTeacherByName_Click(object sender, EventArgs e)
        {
            if (personList.CountsTotalTeachers() > 0)
            {
                bool added = false;
                do
                {
                    string teacherName = Interaction.InputBox("Introduce the teacher's name (ONLY LETTERS): ");
                    if (CustomRegex.RegexName(teacherName))
                    {
                        if (personList.SameTeacherNameCounter(teacherName) > 1)
                        {
                            personList.SelectSameNameTeachersToAddSubjects(teacherName);
                            added = true;
                        }
                        else if (personList.SameTeacherNameCounter(teacherName) == 1)
                        {
                            int teacherPosition = personList.GetPositionFromUniqueName(teacherName);
                            string teacherID = personList.ReturnsPersonIDFromPosition(teacherPosition);
                            personList.MultipleSubjectsAddingFromSelectedTeacher(teacherID);
                            added = true;
                        }
                        else
                        {
                            MessageBox.Show("There isn't any teacher with the selected name, try again");
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
                MessageBox.Show("Error, the list has no added teachers, add a teacher before ordering the teacher list");
            }
        }

        // REMOVES MULTIPLE SUBJECTS TO SELECTED TEACHER BY NAME
        private void btnRemoveSubjectToSelectedTeacherByName_Click(object sender, EventArgs e)
        {
            if (personList.CountsTotalTeachers() > 0)
            {
                if (personList.TeachersWithSubjectsCounter() > 0)
                {
                    bool removed = false;
                    do
                    {
                        string teacherName = Interaction.InputBox("Introduce the teacher's name (ONLY LETTERS): ");
                        if (CustomRegex.RegexName(teacherName))
                        {
                            if (personList.SameTeacherNameCounter(teacherName) > 1)
                            {
                                personList.SelectSameNameTeachersToRemoveSubjects(teacherName);
                                removed = true;
                            }
                            else if (personList.SameTeacherNameCounter(teacherName) == 1)
                            {
                                int teacherPosition = personList.GetPositionFromUniqueName(teacherName);
                                string teacherID = personList.ReturnsPersonIDFromPosition(teacherPosition);
                                personList.MultipleSubjectsRemovalFromSelectedTeacher(teacherID);
                                removed = true;
                            }
                            else
                            {
                                MessageBox.Show("There isn't any teacher with the selected name, try again");
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
                MessageBox.Show("Error, the list has no added teachers, add a teacher before ordering the teacher list");
            }
        }

        // CLEARS ALL SUBJECTS TO SELECTED TEACHER BY NAME
        private void btnClearSubjectsToSelectedTeacherByName_Click(object sender, EventArgs e)
        {
            if (personList.CountsTotalTeachers() > 0)
            {
                if (personList.TeachersWithSubjectsCounter() > 0)
                {
                    bool cleared = false;
                    do
                    {
                        string teacherName = Interaction.InputBox("Introduce the teacher's name (ONLY LETTERS): ");
                        if (CustomRegex.RegexName(teacherName))
                        {
                            if (personList.SameTeacherNameCounter(teacherName) > 1)
                            {
                                personList.SelectSameNameTeachersToClearSubjects(teacherName);
                                cleared = true;
                            }
                            else if (personList.SameTeacherNameCounter(teacherName) == 1)
                            {
                                int teacherPosition = personList.GetPositionFromUniqueName(teacherName);
                                string teacherID = personList.ReturnsPersonIDFromPosition(teacherPosition);
                                if (personList.SelectedTeacherHasSubject(teacherID))
                                {
                                    personList.SubjectsClearing(teacherID);
                                    MessageBox.Show("All subjects from this teacher has been cleared.");
                                    cleared = true;
                                }
                                else
                                {
                                    MessageBox.Show("This teacher has no added subjects, clearing them is not needed ");
                                    cleared = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("There isn't any teacher with the selected name, try again");
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
                MessageBox.Show("Error, the list has no added teachers, add a teacher before clearing subjects to a teacher");
            }
        }
        // ADDS MULTIPLE SUBJECTS TO SELECTED TEACHER BY ID
        private void btnAddSubjectToSelectedTeacherByID_Click(object sender, EventArgs e)
        {
            if (personList.CountsTotalTeachers() > 0)
            {
                bool added = false;
                do
                {
                    string teacherID = Interaction.InputBox("Introduce the teacher's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                    if (CustomRegex.RegexID(teacherID))
                    {
                        if (personList.AlreadyUsedID(teacherID))
                        {
                            int validation = personList.CheckTypeOfPerson(teacherID);
                            if (validation == 1)
                            {
                                if (personList.CountsTotalTeachers() >= 1)
                                {
                                    personList.MultipleSubjectsAddingFromSelectedTeacher(teacherID);
                                    added = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("The selected ID is not from a teacher, try another ID.");
                                added = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("There isn't any teacher with the selected ID");
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
                MessageBox.Show("Error, the list has no added teachers, add a teacher before adding subjects to a teacher");
            }
        }

        // REMOVES MULTIPLE SUBJECTS TO SELECTED TEACHER BY ID
        private void btnRemoveSubjectToSelectedTeacherByID_Click(object sender, EventArgs e)
        {
            if (personList.CountsTotalTeachers() > 0)
            {
                if (personList.TeachersWithSubjectsCounter() > 0)
                {
                    bool removed = false;
                    do
                    {
                        string teacherID = Interaction.InputBox("Introduce the teacher's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                        if (CustomRegex.RegexID(teacherID))
                        {
                            if (personList.AlreadyUsedID(teacherID))
                            {
                                int validation = personList.CheckTypeOfPerson(teacherID);
                                if (validation == 1)
                                {
                                    if (personList.CountsTotalTeachers() >= 1)
                                    {
                                        personList.MultipleSubjectsRemovalFromSelectedTeacher(teacherID);
                                        removed = true;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("The selected ID is not from a teacher, try another ID.");
                                    removed = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("There isn't any teacher with the selected ID");
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
                MessageBox.Show("Error, the list has no added alumns, add an alumn before removing an alumn.");
            }
        }

        // CLEARS ALL SUBJECTS TO SELECTED TEACHER BY ID
        private void btnClearSubjectsToSelectedTeacherByID_Click(object sender, EventArgs e)
        {
            if (personList.CountsTotalTeachers() > 0)
            {
                if (personList.TeachersWithSubjectsCounter() > 0)
                {
                    bool cleared = false;
                    do
                    {
                        string teacherID = Interaction.InputBox("Introduce the teacher's ID (9 CHARACTERS): \n\nNIA example: A1234567B \nDNI example: 12345678A");

                        if (CustomRegex.RegexID(teacherID))
                        {
                            if (personList.AlreadyUsedID(teacherID))
                            {
                                int validation = personList.CheckTypeOfPerson(teacherID);
                                if (validation == 1)
                                {
                                    if (personList.CountsTotalTeachers() >= 1)
                                    {
                                        if (personList.SelectedTeacherHasSubject(teacherID))
                                        {
                                            personList.SubjectsClearing(teacherID);
                                            MessageBox.Show("All subjects from this teacher has been cleared.");
                                            cleared = true;
                                        }
                                        else
                                        {
                                            MessageBox.Show("This teacher has no added subjects, clearing them is not needed ");
                                            cleared = true;
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("The selected ID is not from a teacher, try another ID.");
                                    cleared = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("There isn't any teacher with the selected ID");
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
                MessageBox.Show("Error, the list has no added teachers, add a teacher before clearing selected teacher's subjects.");
            }
        }

        // SHOWS ALL TEACHERS IMPARTING THE SELECTED SUBJECT
        private void btnShowTeachersBySelectedSubject_Click(object sender, EventArgs e)
        {
            bool introduced = false;
            if (personList.CountsTotalTeachers() > 0)
            {
                if (personList.TeachersWithSubjectsCounter() > 0)
                {
                    do
                    {
                        string subjectName = Interaction.InputBox("Introduce the subject's name to show the teachers who impart it: ");
                        if (CustomRegex.RegexName(subjectName))
                        {
                            if (personList.SelectedSubjectHasTeachers(subjectName) > 0)
                            {
                                MessageBox.Show(personList.ShowTeachersBySubjectName(subjectName));
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
                    MessageBox.Show("Error, the list doesn't have any teacher with subjects, add a atleast a subject to a teacher before showing the teachers who are imparting the selected subject.");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has no added teachers, add a teacher before showing the teachers who imparts the selected subject.");
            }
        }
    }
}
