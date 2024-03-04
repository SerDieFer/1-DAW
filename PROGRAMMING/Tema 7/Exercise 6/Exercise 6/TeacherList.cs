using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_6
{
    public class TeacherList
    {
        private List<Teacher> teacherList;

        public TeacherList()
        {
            teacherList = new List<Teacher>();
        }

        // FUNCTION WHICH ADDS AN TEACHER TO THE TEACHER LIST
        public void AddsTeacher(string teacherName, string teacherID, int teacherPhone, int courseMentorCod)
        {
            Teacher newTeacher = new Teacher();
            newTeacher.Name = teacherName;
            newTeacher.ID = teacherID;
            newTeacher.Phone = teacherPhone;
            newTeacher.CourseMentorCod = courseMentorCod;
            teacherList.Add(newTeacher);
        }

        // FUNCTION WHICH REMOVES A TEACHER FROM THIS LIST
        public void RemovesTeacher(int teacherPosition)
        {
            teacherList.RemoveAt(teacherPosition);
        }

        // FUNCTION THAT SELECTS A TEACHER FROM THE LIST AND ADDS A SELECTED SUBJECT
        public bool SubjectAdding(string teacherID, string teacherSubjectName)
        {
            bool subjectAdded = false;
            if (teacherList.Count != 0)
            {
                int position = ReturnsTeacherPositionFromID(teacherID);
                if (position != -1)
                {
                    teacherList[position].AddsSelectedTeacherSubject(teacherID, teacherSubjectName);
                    subjectAdded = true;
                }
            }
            return subjectAdded;
        }

        //FUNCTION WHICH ADDS MULTIPLE SUBJECTS TO A SELECTED TEACHER
        public void MultipleSubjectsAddingFromSelectedTeacher(string teacherID)
        {
            bool added = false;
            do
            {
                string subjectName = Interaction.InputBox("Introduce the subject's name to add to this teacher: ");
                if (CustomFunctions.RegexName(subjectName))
                {
                    SubjectAdding(teacherID, subjectName);
                    MessageBox.Show("A subject named " + subjectName + " has been added to this teacher.");

                    //THIS RE ASKS IF YOU WANT TO ADD MORE GRADES TO THE SAME ALUMN ALREADY SELECTED
                    DialogResult keepAdding = MessageBox.Show("Do you want to keep adding subjects?", "Keep Adding Subjects", MessageBoxButtons.YesNo);
                    if (keepAdding == DialogResult.No)
                    {
                        added = true;
                    }
                }
                else
                {
                    MessageBox.Show("Subject name format invalid.");
                }
            } while (!added);
        }

        // FUNCTION THAT RETURNS IF A SUBJECT EXIST FROM THE SELECTED TEACHER FROM ALL THE TEACHERS LIST
        public bool SubjectExistanceCheck(string teacherID, string teacherSubjectName)
        {
            bool subjectExist = false;
            if (teacherList.Count != 0)
            {
                int position = ReturnsTeacherPositionFromID(teacherID);
                if (position != -1)
                {
                    subjectExist = teacherList[position].ChecksTeacherSelectedSubject(teacherID, teacherSubjectName);
                }
            }
            return subjectExist;
        }

        // FUNCTION THAT SELECTS AN ALUMN FROM THE LIST AND REMOVES IT A SELECTED GRADE
        public void SubjecRemoval(string teacherID, string teacherSubjectName)
        {
            if (teacherList.Count != 0)
            {
                int position = ReturnsTeacherPositionFromID(teacherID);
                if (position != -1)
                {
                    teacherList[position].RemovesSelectedTeacherSubject(teacherID, teacherSubjectName);
                }
            }
        }

        //FUNCTION WHICH REMOVES MULTIPLE GRADES TO A SELECTED ALUMN
        public void MultipleSubjectsRemovingFromSelectedTeacher(string teacherID)
        {
            if (SelectedTeacherHasSubject(teacherID))
            {
                bool removed = false;
                do
                {
                    string subject = Interaction.InputBox("Introduce the subject's name to remove from all the teacher subjects: ");
                    if (CustomFunctions.RegexGradeValue(subject))
                    {
                        if (SubjectExistanceCheck(teacherID, subject))
                        {
                            SubjecRemoval(teacherID, subject);
                            MessageBox.Show("A subject named " + subject + " has been removed from this teacher.");

                            if (SelectedTeacherHasSubject(teacherID))
                            {
                                //THIS RE ASKS IF YOU WANT TO ADD MORE GRADES TO THE SAME TEACHER ALREADY SELECTED
                                DialogResult keepRemoving = MessageBox.Show("Do you want to keep removing subjects?", "Keep Removing Subjects", MessageBoxButtons.YesNo);
                                if (keepRemoving == DialogResult.No)
                                {
                                    removed = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("This teacher doesn't have any subjects left to remove.");
                                removed = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("The teacher has not any subject with that name, try another name.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Subject name format invalid.");
                    }
                } while (!removed);
            }
            else
            {
                MessageBox.Show("The teacher has not any subjects added. ");
            }
        }

        // FUNCTION THAT SELECTS AN ALUMN FROM THE LIST AND CLEARS ALL THE GRADES FROM IT
        public void SubjectsClearing(string teacherID)
        {
            if (teacherList.Count != 0)
            {
                int position = ReturnsTeacherPositionFromID(teacherID);
                if (position != -1)
                {
                    teacherList[position].ClearSubjectsFromTeacher(teacherID);
                }
            }
        }

        // FUNCTION THAT RETURNS IF THE SELECTED TEEACHER IMPARTS A SUBJECT
        public bool SelectedTeacherHasSubject(string teacherID)
        {
            bool hasSubjects = true;
            for (int i = 0; i < teacherList.Count && hasSubjects; i++)
            {
                if (teacherID == teacherList[i].ID)
                {
                    if (teacherList[i].Subjects.Count() == 0)
                    {
                        hasSubjects = false;
                    }
                }
            }
            return hasSubjects;
        }

        // FUNCTION WHICH RETURNS HOW MANY TEACHERS HAVE SUBJECS ADDED
        public int TeachersWithSubjectsCounter()
        {
            int teachersWithSubjects = 0;
            for (int i = 0; i < teacherList.Count; i++)
            {
                if (teacherList[i].Subjects.Count() > 0)
                {
                    teachersWithSubjects++;
                }
            }
            return teachersWithSubjects;
        }

        // FUNCTION WHICH GETS AN UNIQUE ID WHEN THERE'S ONLY AN UNIQUE NAME IN THE LIST
        public int GetUniqueNamePosition(string teacherName)
        {
            int uniqueId = 0;
            for (int i = 0; i < teacherList.Count; i++)
            {
                if (teacherName == teacherList[i].Name)
                {
                    uniqueId = i;
                }
            }
            return uniqueId;
        }

        // FUNCTION WHICH RETURNS IF THE TEACHER ID IS ALREADY USED
        public bool AlreadyUsedID(string teacherID)
        {
            bool used = false;
            for (int i = 0; i < teacherList.Count && !used; i++)
            {
                if (teacherID == teacherList[i].ID)
                {
                    used = true;
                }
            }
            return used;
        }

        // FUNCTION WHICH RETURNS IF THE TEACHER PHONE IS ALREADY USED
        public bool AlreadyUsedPhone(int teacherPhone)
        {
            bool used = false;
            for (int i = 0; i < teacherList.Count && !used; i++)
            {
                if (teacherPhone == teacherList[i].Phone)
                {
                    used = true;
                }
            }
            return used;
        }


        // FUNCTION WHICH RETURNS THE TEACHER NAME FROM THE SELECTED TEACHER ID
        public string ReturnsTeacherName(string teacherID)
        {
            string teacherName = "";
            for (int i = 0; i < teacherList.Count; i++)
            {
                if (teacherID == teacherList[i].ID)
                {
                    teacherName = teacherList[i].Name;
                }
            }
            return teacherName;
        }

        // FUNCTION WHICH RETURNS THE POSITION OF THE TEACHER IN THE LIST, IF IT'S NEGATIVE THE TEACHER IS NOT IN THE LIST
        public int ReturnsTeacherPositionFromID(string teacherID)
        {
            int index = -1;
            for (int i = 0; i < teacherList.Count; i++)
            {
                if (teacherID == teacherList[i].ID)
                {
                    index = i;
                }
            }
            return index;
        }

        // FUNCTION WHICH RETURNS THE ID FROM AN TEACHER IN THE LIST
        public string ReturnsTeacherIDFromPosition(int teacherPosition)
        {
            string teacherID = "";
            for (int i = 0; i < teacherList.Count; i++)
            {
                if (teacherPosition == i)
                {
                    teacherID = teacherList[i].ID;
                }
            }
            return teacherID;
        }

        // FUNCTION WHICH RETURNS THE COUNT OF THE NUMBER OF TEACHERS IN THE LIST
        public int CountsTotalTeachers()
        {
            return teacherList.Count;
        }


    }
}
