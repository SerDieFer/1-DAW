using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_6
{
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
                string name = Interaction.InputBox("Introduce the teacher's name (ONLY LETTERS): ");

                if (CustomFunctions.RegexName(name))
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
                                        string mentorCourseCod = Interaction.InputBox("Introduce the course code where the teacher is the mentor \n(MUST BE BIGGER THAN 0): ");

                                        if (CustomFunctions.RegexCourseCod(mentorCourseCod) && int.Parse(mentorCourseCod) > 0)
                                        {
                                            int courseMentorCod = int.Parse(mentorCourseCod);
                                            teacherList.AddsTeacher(name, teacherID, phone, courseMentorCod);
                                            introduced = true;
                                            MessageBox.Show(name + " was registered.");

                                        }
                                        else
                                        {
                                            MessageBox.Show("The course code format is not correct, try again.");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("The phone is already used, so this teacher was registered before!!");
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
                                MessageBox.Show("The ID is already used, an alumn already uses this ID!!");
                                introduced = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("The ID is already used, so this teacher was registered before!!");
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
    }
}
