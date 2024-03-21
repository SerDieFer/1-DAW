using Exercise_5;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exercise_6
{
    public partial class CourseForm : Form
    {
        public CourseForm()
        {
            InitializeComponent();
        }

        public CourseList courseList;
        public PersonList personList;

        private void CourseForm_Load(object sender, EventArgs e)
        {

        }

        public CourseForm(CourseList courseList, PersonList personList)
        {
            InitializeComponent();
            this.courseList = courseList;
            this.personList = personList;
        }

        // ADD COURSE
        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            Course aCourse = new Course();
            bool introduced = false;
            do
            {
                string courseCodValue = Interaction.InputBox("Introduce the desired course code \n(MUST BE BIGGER THAN 0): ");
                int courseCod = int.Parse(courseCodValue);
                if (CustomRegex.RegexCourseCod(courseCodValue) && courseCod > 0)
                {
                    if (!courseList.AlreadyUsedCourseCod(courseCod))
                    {
                        string courseName = Interaction.InputBox("Introduce the course's name (ONLY LETTERS): ");
                        if (CustomRegex.RegexName(courseName))
                        {
                            courseList.AddsCourse(courseCod, courseName);
                            introduced = true;
                            MessageBox.Show("The course Nº" + courseCod + " and designed as " + courseName + " was registered.");
                        }
                        else
                        {
                            MessageBox.Show("The course name format is not correct, try again.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The selected course cod already exist, try again.");
                        introduced = true;
                    }
                }
                else
                {
                    MessageBox.Show("The course format is not correct, try again.");
                }
            } while (!introduced);
        }

        // REMOVE COURSE
        private void btnRemoveCourse_Click(object sender, EventArgs e)
        {
            if (courseList.CountsTotalCourses() > 0)
            {
                bool introduced = false;
                do
                {
                    string courseCodValue = Interaction.InputBox("Introduce the course's cod to remove (ONLY NUMS, MUST BE BIGGER THAN 0): ");
                    if (CustomRegex.RegexCourseCod(courseCodValue))
                    {
                        int courseCod = int.Parse(courseCodValue);
                        string courseName = courseList.ReturnsCourseName(courseCod);
                        int coursePosition = courseList.ReturnsCoursePosition(courseCod);
                        if (coursePosition != -1)
                        {
                            courseList.RemovesCourse(courseCod);
                            MessageBox.Show("The course ( " + courseName + " ) with the Cod ( " + courseCod + " ) was removed.");
                            introduced = true;
                        }
                        else
                        {
                            MessageBox.Show("The course cod selected doesn't exist, try again");
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
                MessageBox.Show("Error, the list has no added courses, add a course before removing a course.");
            }
        }

        // SHOW COURSE
        private void btnShowCourses_Click(object sender, EventArgs e)
        {
            if (courseList.CountsTotalCourses() != 0)
            {
                MessageBox.Show(courseList.ShowsAllCoursesData());
            }
            else
            {
                MessageBox.Show("There isn't any added course to the list, add a course before trying again");
            }
        }

        // SHOW SELECTED COURSE BY COURSE COD
        private void btnShowSelectedCourse_Click(object sender, EventArgs e)
        {
            if (courseList.CountsTotalCourses() != 0)
            {
                bool introduced = false;
                do
                {
                    string courseCodValue = Interaction.InputBox("Introduce the course's cod to show data (ONLY NUMS, MUST BE BIGGER THAN 0): ");
                    if (CustomRegex.RegexCourseCod(courseCodValue))
                    {
                        int courseCod = int.Parse(courseCodValue);
                        int coursePosition = courseList.ReturnsCoursePosition(courseCod);
                        if (coursePosition != -1)
                        {
                            MessageBox.Show(courseList.ShowsSelectedCourseData(courseCod));
                            introduced = true;
                        }
                        else
                        {
                            MessageBox.Show("The course cod selected doesn't exist, try again");
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
                MessageBox.Show("There isn't any added course to the list, add a course before trying again");
            }
        }

        // SHOW ALUMNS IN SELECTED COURSE
        private void btnShowAlumnsSelectedCourse_Click(object sender, EventArgs e)
        {
            bool introduced = false;
            if (courseList.CountsTotalCourses() > 0)
            {
                if (personList.CountsTotalPersons() > 0)
                {
                    do
                    {
                        string courseCodValue = Interaction.InputBox("Introduce the course's cod to show alumns data (ONLY NUMS, MUST BE BIGGER THAN 0): ");
                        if (CustomRegex.RegexCourseCod(courseCodValue))
                        {
                            int courseCod = int.Parse(courseCodValue);
                            if (personList.AlumnsInCourse(courseCod))
                            {
                                MessageBox.Show(personList.ShowAlumnsBySelectedCourseCod(courseCod));
                                introduced = true;
                            }
                            else
                            {
                                MessageBox.Show("The selected course hasn't any alumn registered yet, select another one.");
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
                    MessageBox.Show("Error, the list has no added alumns, add a alumn before showing the alumns who are doing the selected course.");
                }
            }
            else
            {
                MessageBox.Show("Error, the list has no added courses, add a course before showing the alumns who are doing the selected course.");
            }
        }
    }
}
