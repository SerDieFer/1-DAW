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
    //TODO REFACTORIZAR Y REUSAR EL MULTIPLE ADD/REMOVE EN SAMENAME X
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
        public bool SubjectAdding(string teacherID, string subjectName)
        {
            bool subjectAdded = false;
            if (teacherList.Count != 0)
            {
                int position = ReturnsTeacherPositionFromID(teacherID);
                if (position != -1)
                {
                    teacherList[position].AddsSelectedTeacherSubject(teacherID, subjectName);
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
        public bool SubjectExistanceCheck(string teacherID, string subjectName)
        {
            bool subjectExist = false;
            if (teacherList.Count != 0)
            {
                int position = ReturnsTeacherPositionFromID(teacherID);
                if (position != -1)
                {
                    subjectExist = teacherList[position].ChecksTeacherSelectedSubject(teacherID, subjectName);
                }
            }
            return subjectExist;
        }

        // FUNCTION THAT SELECTS AN ALUMN FROM THE LIST AND REMOVES IT A SELECTED GRADE
        public void SubjecRemoval(string teacherID, string subjectName)
        {
            if (teacherList.Count != 0)
            {
                int position = ReturnsTeacherPositionFromID(teacherID);
                if (position != -1)
                {
                    teacherList[position].RemovesSelectedTeacherSubject(teacherID, subjectName);
                }
            }
        }

        //FUNCTION WHICH REMOVES MULTIPLE GRADES TO A SELECTED ALUMN
        public void MultipleSubjectsRemovalFromSelectedTeacher(string teacherID)
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

        // FUNCTION THAT SELECTS A TEACHER FROM THE LIST AND CLEARS ALL THE SUBJECTS FROM IT
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

        // FUNCTION WHICH COLLECTS ALL DATA FROM ALL THE TEACHERS ADDED INTO THE TEACHER LIST
        public string ShowsTeachersList()
        {
            string teacherListTxt = "List of teachers: \n\n";
            if (teacherList.Count != 0)
            {
                foreach (Teacher teacher in teacherList)
                {
                    teacherListTxt += teacher.ShowsTeacherData() + "\n";
                }
            }
            return teacherListTxt;
        }

        // FUNCTION WHICH COLLECTS ALL THE TEACHERS NAMES AND ID WHO IMPARTS THE SELECTED SUBJECT
        public string ShowTeachersBySubjectName(string subjectName)
        {
            string subjectTeachersTxt = "";
            for (int i = 0; i < teacherList.Count; i++)
            {
                string teacherID = ReturnsTeacherIDFromPosition(i);
                if (teacherList[i].ChecksTeacherSelectedSubject(teacherID, subjectName))
                {
                    subjectTeachersTxt += teacherList[i].ShowsSimplierTeacherData() + "\n";
                }
            }
            return subjectTeachersTxt;
        }

        // FUNCTION WHICH COLLECTS THE SELECTED TEACHER DATA BY ID FROM ALL THE TEACHERS ADDED INTO THE TEACHERS LIST 
        public string ShowsSelectedTeacherDataByID(string teacherID)
        {
            string teacherTxt = "";
            if (teacherList.Count != 0)
            {
                teacherTxt = teacherList[ReturnsTeacherPositionFromID(teacherID)].ShowsTeacherData();
            }
            return teacherTxt;
        }

        // FUNCTION WHICH COUNTS ALL TEACHERS THAT SHARE THE SAME NAME
        public int SameNameCounter(string teacherName)
        {
            int counter = 0;
            if (teacherList.Count != 0)
            {
                for (int i = 0; i < teacherList.Count; i++)
                {
                    if (teacherName == teacherList[i].Name)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        // FUNCTION WHICH COLLECTS ALL DATA FROM ALL THE TEACHERS WITH SAME NAME ADDED INTO THE TEACHERS LIST TO DELETE THE SELECTED ONE
        public void SelectSameNameTeachersToDelete(string teacherName)
        {
            bool found = false;
            List<string> matchingTeachersName = new List<string>();

            if (teacherList.Count != 0)
            {
                for (int i = 0; i < teacherList.Count; i++)
                {
                    if (teacherName == teacherList[i].Name)
                    {
                        found = true;
                        string teacherData = teacherList[i].ShowsSimplierTeacherData();
                        matchingTeachersName.Add(teacherData);
                    }
                }
            }

            if (found)
            {
                // I HAD TO SEARCH THIS PART TO SHOW MULTIPLE INFO AND SELECT ONE FROM ALL OF THEM
                // THIS DISPLAYS ALL INFORMATION FROM ALL MATCHING NAMES FROM DIFFERENT TEACHERS
                StringBuilder infoMessage = new StringBuilder("Teachers with the same name: \n\n");

                for (int i = 0; i < matchingTeachersName.Count; i++)
                {
                    infoMessage.AppendLine((i + 1) + ") " + matchingTeachersName[i]);
                }

                infoMessage.AppendLine("Select the number to delete from list:\n");

                string userInput = Interaction.InputBox(infoMessage.ToString());
                int selectedTeacherIndex;

                // THIS MAKES THE INPUT SELECTED TO ASIGN IT TO A TEACHER INDEX AND NEXT IT WILL ASK IF YOU WANT TO REMOVE THE SELECTED ONE
                if (int.TryParse(userInput, out selectedTeacherIndex) && selectedTeacherIndex > 0 && selectedTeacherIndex <= matchingTeachersName.Count)
                {
                    // GETS THE SELECTED TEACHER INFO
                    string selectedTeacherInfo = matchingTeachersName[selectedTeacherIndex - 1];

                    // ASKS THE USER IF THEY WANT TO REMOVE THE SELECTED TEACHER
                    DialogResult result = MessageBox.Show(selectedTeacherInfo + "Do you want to remove this teacher?", "Remove Teacher", MessageBoxButtons.YesNo);
                    bool deleted = false;
                    do
                    {
                        if (result == DialogResult.Yes)
                        {
                            // FIND THE MATCHING TEACHER IN THE TEACHER LIST AND REMOVE IT
                            for (int i = 0; i < teacherList.Count && !deleted; i++)
                            {
                                if (teacherName == teacherList[i].Name)
                                {
                                    RemovesTeacher(i);
                                    MessageBox.Show("Teacher removed successfully.");
                                    deleted = true;
                                }
                            }
                        }
                        else
                        {
                            userInput = Interaction.InputBox(infoMessage.ToString());
                            result = MessageBox.Show(selectedTeacherInfo + "\nDo you want to remove this teacher?", "Remove Teacher", MessageBoxButtons.YesNo);
                        }
                    } while (!deleted);
                }
                else
                {
                    MessageBox.Show("Invalid number input. Please enter a valid number.");
                }
            }
            else
            {
                MessageBox.Show("No teachers found with the given name.");
            }
        }

        // FUNCTION WHICH COLLECTS ALL DATA FROM ALL THE TEACHERS WITH SAME NAME ADDED INTO THE TEACHER LIST TO SHOW THEIR DATA
        public void SelectSameNameTeachersToShow(string teacherName)
        {
            bool found = false;
            List<string> matchingTeachersName = new List<string>();

            if (teacherList.Count != 0)
            {
                for (int i = 0; i < teacherList.Count; i++)
                {
                    if (teacherName == teacherList[i].Name)
                    {
                        found = true;
                        string teacherData = teacherList[i].ShowsSimplierTeacherData();
                        matchingTeachersName.Add(teacherData);
                    }
                }
            }

            if (found)
            {
                // I HAD TO SEARCH THIS PART TO SHOW MULTIPLE INFO AND SELECT ONE FROM ALL OF THEM
                // THIS DISPLAYS ALL INFORMATION FROM ALL MATCHING NAMES FROM DIFFERENT TEACHERS
                StringBuilder infoMessage = new StringBuilder("Teachers with the same name: \n\n");

                for (int i = 0; i < matchingTeachersName.Count; i++)
                {
                    infoMessage.AppendLine((i + 1) + ") " + matchingTeachersName[i]);
                }

                infoMessage.AppendLine("Select the number of teacher to check more data from it:\n");

                string userInput = Interaction.InputBox(infoMessage.ToString());
                int selectedTeacherIndex;

                // THIS MAKES THE INPUT SELECTED TO ASIGN IT TO A TEACHER INDEX AND NEXT IT WILL ASK IF YOU WANT TO SHOW THE SELECTED ONE
                if (int.TryParse(userInput, out selectedTeacherIndex) && selectedTeacherIndex > 0 && selectedTeacherIndex <= matchingTeachersName.Count)
                {
                    // GETS THE SELECTED TEACHER INFO
                    string selectedTeacherInfo = matchingTeachersName[selectedTeacherIndex - 1];

                    // ASKS THE USER IF THEY WANT TO SHOW THE SELECTED TEACHER
                    DialogResult result = MessageBox.Show(selectedTeacherInfo + "\nIs this teacher the one that you wanted to see info?", "Check Teacher", MessageBoxButtons.YesNo);
                    bool showed = false;
                    do
                    {
                        if (result == DialogResult.Yes)
                        {
                            showed = true;
                        }
                        else
                        {
                            userInput = Interaction.InputBox(infoMessage.ToString());
                            result = MessageBox.Show(selectedTeacherInfo + "\nIs this teacher the one that you wanted to see info?", "Check Teacher", MessageBoxButtons.YesNo);
                        }
                    } while (!showed);
                }
                else
                {
                    MessageBox.Show("Invalid number input. Please enter a valid number.");
                }
            }
            else
            {
                MessageBox.Show("No teachers found with the given name.");
            }
        }

        // FUNCTION WHICH COLLECTS ALL DATA FROM ALL THE TEACHERS WITH SAME NAME ADDED INTO THE TEACHERS LIST TO ADD THEM SUBJECTS
        public void SelectSameNameTeachersToAddSubjects(string teacherName)
        {
            bool found = false;

            // THIS STORES THE TEACHERS WITH THE SAME NAME AS A STRING WITH ALL THEIR DATA FROM TEACHERS LIST
            List<string> matchingTeachersName = new List<string>();

            // THIS STORES THESE TEACHERS ID IN ANOTHER LIST TO REUSE THEIR ID LATER
            List<string> SameNameTeachersID = new List<string>();

            if (teacherList.Count != 0)
            {
                for (int i = 0; i < teacherList.Count; i++)
                {
                    if (teacherName == teacherList[i].Name)
                    {
                        found = true;
                        string teacherData = teacherList[i].ShowsSimplierTeacherData();
                        string teacherID = teacherList[i].ID;
                        matchingTeachersName.Add(teacherData);
                        SameNameTeachersID.Add(teacherID);

                    }
                }
            }

            if (found)
            {
                // I HAD TO SEARCH THIS PART TO SHOW MULTIPLE INFO AND SELECT ONE FROM ALL OF THEM
                // THIS DISPLAYS ALL INFORMATION FROM ALL MATCHING NAMES FROM DIFFERENT TEACHERS
                StringBuilder infoMessage = new StringBuilder("Teachers with the same name: \n\n");

                for (int i = 0; i < matchingTeachersName.Count; i++)
                {
                    infoMessage.AppendLine((i + 1) + ") " + matchingTeachersName[i]);
                }

                infoMessage.AppendLine("Select the number of teacher to add a subject from the list:\n");

                string userInput = Interaction.InputBox(infoMessage.ToString());
                int selectedTeacherIndex;

                if (int.TryParse(userInput, out selectedTeacherIndex) && selectedTeacherIndex > 0 && selectedTeacherIndex <= matchingTeachersName.Count)
                {
                    // GETS THE SELECTED TEACHER INFO AND ID
                    string selectedTeacherInfo = matchingTeachersName[selectedTeacherIndex - 1];
                    string selectedTeacherID = SameNameTeachersID[selectedTeacherIndex - 1];

                    DialogResult result;
                    bool added = false;
                    do
                    {
                        // ASKS THE USER IF THIS IS THE ACTUAL TEACHER WHOSE INFO WAS REQUIRED
                        result = MessageBox.Show(selectedTeacherInfo + "\nIs this teacher the one that you wanted to add a subject?", "Add Subject", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            do
                            {
                                string subjectName = Interaction.InputBox("Introduce the subject's name to add to this teacher: ");
                                if (CustomFunctions.RegexName(subjectName))
                                {
                                    SubjectAdding(selectedTeacherID, subjectName);
                                    MessageBox.Show("A subject named " + subjectName + " has been added to this teacher.");

                                    //THIS RE ASKS IF YOU WANT TO ADD MORE SUBJECTS TO THE SAME TEACHER ALREADY SELECTED
                                    DialogResult keepAdding = MessageBox.Show("Do you want to keep adding subjects?", "Keep Adding Subjects", MessageBoxButtons.YesNo);
                                    if (keepAdding == DialogResult.No)
                                    {
                                        added = true;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Subject name format invalid, try again.");
                                }
                            } while (!added);
                        }
                        else
                        {
                            userInput = Interaction.InputBox(infoMessage.ToString());
                        }
                    } while (!added);
                }
                else
                {
                    MessageBox.Show("Invalid number input. Please enter a valid number.");
                }
            }
            else
            {
                MessageBox.Show("No teachers found with the given name.");
            }
        }

        // FUNCTION WHICH COLLECTS ALL DATA FROM ALL THE TEACHERS WITH SAME NAME ADDED INTO THE TEACHERS LIST TO REMOVE THEIR SELECTED SUBJECTS
        public void SelectSameNameTeachersToRemoveSubjects(string teacherName)
        {
            bool found = false;

            // THIS STORES THE TEACHERS WITH THE SAME NAME AS A STRING WITH ALL THEIR DATA FROM TEACHERS LIST
            List<string> matchingTeachersName = new List<string>();

            // THIS STORES THESE TEACHERS ID IN ANOTHER LIST TO REUSE THEIR ID LATER
            List<string> SameNameTeachersID = new List<string>();

            if (teacherList.Count != 0)
            {
                for (int i = 0; i < teacherList.Count; i++)
                {
                    if (teacherName == teacherList[i].Name)
                    {
                        found = true;
                        string teacherData = teacherList[i].ShowsSimplierTeacherData();
                        string teacherID = teacherList[i].ID;
                        matchingTeachersName.Add(teacherData);
                        SameNameTeachersID.Add(teacherID);

                    }
                }
            }

            if (found)
            {
                // I HAD TO SEARCH THIS PART TO SHOW MULTIPLE INFO AND SELECT ONE FROM ALL OF THEM
                // THIS DISPLAYS ALL INFORMATION FROM ALL MATCHING NAMES FROM DIFFERENT TEACHERS
                StringBuilder infoMessage = new StringBuilder("Teachers with the same name: \n\n");

                for (int i = 0; i < matchingTeachersName.Count; i++)
                {
                    infoMessage.AppendLine((i + 1) + ") " + matchingTeachersName[i]);
                }

                infoMessage.AppendLine("Select the number of teacher to remove a subject from the list:\n");

                string userInput = Interaction.InputBox(infoMessage.ToString());
                int selectedTeacherIndex;

                if (int.TryParse(userInput, out selectedTeacherIndex) && selectedTeacherIndex > 0 && selectedTeacherIndex <= matchingTeachersName.Count)
                {
                    // GETS THE SELECTED TEACHER INFO AND ID
                    string selectedTeacherInfo = matchingTeachersName[selectedTeacherIndex - 1];
                    string selectedTeacherID = SameNameTeachersID[selectedTeacherIndex - 1];

                    DialogResult result;
                    bool removed = false;
                    do
                    {
                        // ASKS THE USER IF THIS IS THE ACTUAL TEACHER WHOSE INFO WAS REQUIRED
                        result = MessageBox.Show(selectedTeacherInfo + "\nIs this teacher the one that you wanted to remove a subject?", "Remove Subject", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            do
                            {
                                string subjectName = Interaction.InputBox("Introduce the subject's name to remove to this teacher: ");
                                //MultipleSubjectsRemovalFromSelectedTeacher(selectedTeacherID); -- this may work?
                                if (CustomFunctions.RegexName(subjectName))
                                {
                                    if (SubjectExistanceCheck(selectedTeacherID, subjectName))
                                    {
                                        SubjecRemoval(selectedTeacherID, subjectName);
                                        MessageBox.Show("A subject named " + subjectName + " has been removed to this teacher.");

                                        if (SelectedTeacherHasSubject(selectedTeacherID))
                                        {
                                            //THIS RE ASKS IF YOU WANT TO REMOVE MORE SUBJECTS TO THE SAME TEACHER ALREADY SELECTED
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
                                    MessageBox.Show("Subject name format invalid, try again.");
                                }
                            } while (!removed);
                        }
                        else
                        {
                            userInput = Interaction.InputBox(infoMessage.ToString());
                        }
                    } while (!removed);
                }
                else
                {
                    MessageBox.Show("Invalid number input. Please enter a valid number.");
                }
            }
            else
            {
                MessageBox.Show("No teachers found with the given name.");
            }
        }

        // FUNCTION WHICH COLLECTS ALL DATA FROM ALL THE TEACHERS WITH SAME NAME ADDED INTO THE TEACHER LIST TO CLEAR ALL THEIR SUBJECTS
        public void SelectSameNameTeachersToClearSubjects(string teacherName)
        {
            bool found = false;

            // THIS STORES THE TEACHERS WITH THE SAME NAME AS A STRING WITH ALL THEIR DATA FROM TEACHERS LIST
            List<string> matchingTeachersName = new List<string>();

            // THIS STORES THESE TEACHERS ID IN ANOTHER LIST TO REUSE THEIR ID LATER
            List<string> SameNameTeachersID = new List<string>();

            if (teacherList.Count != 0)
            {
                for (int i = 0; i < teacherList.Count; i++)
                {
                    if (teacherName == teacherList[i].Name)
                    {
                        found = true;
                        string teacherData = teacherList[i].ShowsSimplierTeacherData();
                        string teacherID = teacherList[i].ID;
                        matchingTeachersName.Add(teacherData);
                        SameNameTeachersID.Add(teacherID);

                    }
                }
            }

            if (found)
            {
                // I HAD TO SEARCH THIS PART TO SHOW MULTIPLE INFO AND SELECT ONE FROM ALL OF THEM
                // THIS DISPLAYS ALL INFORMATION FROM ALL MATCHING NAMES FROM DIFFERENT TEACHERS
                StringBuilder infoMessage = new StringBuilder("Teachers with the same name: \n\n");

                for (int i = 0; i < matchingTeachersName.Count; i++)
                {
                    infoMessage.AppendLine((i + 1) + ") " + matchingTeachersName[i]);
                }

                infoMessage.AppendLine("Select the number of teacher to clear all the subjects from the list:\n");

                string userInput = Interaction.InputBox(infoMessage.ToString());
                int selectedTeacherIndex;

                if (int.TryParse(userInput, out selectedTeacherIndex) && selectedTeacherIndex > 0 && selectedTeacherIndex <= matchingTeachersName.Count)
                {
                    // GETS THE SELECTED TEACHER INFO AND ID
                    string selectedTeacherInfo = matchingTeachersName[selectedTeacherIndex - 1];
                    string selectedTeacherID = SameNameTeachersID[selectedTeacherIndex - 1];

                    DialogResult result;
                    bool cleared = false;
                    do
                    {
                        // ASKS THE USER IF THIS IS THE ACTUAL TEACHER WHOSE INFO WAS REQUIRED
                        result = MessageBox.Show(selectedTeacherInfo + "\nIs this teacher the one that you wanted to clear all subjects?", "Clear Subjects", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            if (SelectedTeacherHasSubject(selectedTeacherID))
                            {
                                SubjectsClearing(selectedTeacherID);
                                MessageBox.Show("All subjetcs from this teacher has been cleared");
                                cleared = true;
                            }
                            else
                            {
                                MessageBox.Show("This teacher doesn't have any subjects added.");
                                cleared = true;
                            }
                        }
                        else
                        {
                            userInput = Interaction.InputBox(infoMessage.ToString());
                        }
                    } while (!cleared);
                }
                else
                {
                    MessageBox.Show("Invalid number input. Please enter a valid number.");
                }
            }
            else
            {
                MessageBox.Show("No teachers found with the given name.");
            }
        }

        // FUNCTION THAT RETURNS IF THE SELECTED TEACHER IMPARTS A SUBJECT
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

        // FUNCTION WHICH RETURNS IF THERE ARE TEACHERS IMPARTING THE SELECTED SUBJECT
        public int SelectedSubjectHasTeachers(string subjectName)
        {
            int teachersCount = 0;
            for (int i = 0; i < teacherList.Count; i++)
            {
                if (teacherList[i].Subjects.Contains(subjectName))
                {
                    teachersCount++;
                }
            }
            return teachersCount;
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

        // FUNCTION THAT ORDERS ALUMNS IN ALPHABETICAL ORDER
        public void SortTeachersListAlphabetically()
        {
            Teacher auxTeacherList;
            for (int i = 0; i < teacherList.Count; i++)
            {
                for (int j = i + 1; j < teacherList.Count; j++)
                {
                    if (string.Compare(teacherList[i].Name, teacherList[j].Name) > 0)
                    {
                        auxTeacherList = teacherList[i];
                        teacherList[i] = teacherList[j];
                        teacherList[j] = auxTeacherList;
                    }
                }
            }
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
