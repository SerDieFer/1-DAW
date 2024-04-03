using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_5
{
    public class PersonList
    {
        private List<Person> personList;

        public PersonList()
        {
            personList = new List<Person>();
        }

        // do an alumn grades list to show while you delete them to show the actual ones
        // same as teacher subjects
        // check is a teacher before adding and removing subjects by id

        // TEACHERS RELATED METHODS //

        public void AddsTeacher(string teacherName, string teacherID, int teacherPhone, string teacherEmail, int courseMentorCod)
        {
            Teacher newTeacher = new Teacher();
            newTeacher.Name = teacherName;
            newTeacher.ID = teacherID;
            newTeacher.Phone = teacherPhone;
            newTeacher.Email = teacherEmail;
            newTeacher.TutorCod = courseMentorCod;
            personList.Add(newTeacher);
        }

        public int RemovesTeacher(int teacherPosition)
        {
            string personID = ReturnsPersonIDFromPosition(teacherPosition);
            int personType = CheckTypeOfPerson(personID);

            // TYPE 1 IS A TEACHER
            if (personType == 1)
            {
                personList.RemoveAt(teacherPosition);
            }
            else
            {
                personType = 0;
            }
            return personType;
        }

        public bool SubjectAdding(string teacherID, string subjectName)
        {
            bool subjectAdded = false;
            if (personList.Count != 0)
            {
                int position = ReturnPersonPosition(teacherID);
                int personType = CheckTypeOfPerson(teacherID);

                // TYPE 1 IS A TEACHER
                if (personType == 1 && position != -1)
                {
                    ((Teacher)personList[position]).AddsSelectedTeacherSubject(teacherID, subjectName);
                    subjectAdded = true;
                }
            }
            return subjectAdded;
        }

        public void MultipleSubjectsAddingFromSelectedTeacher(string teacherID)
        {
            bool added = false;
            do
            {
                string subjectName = Interaction.InputBox("Introduce the subject's name to add to this teacher: ");
                if (CustomRegex.RegexName(subjectName))
                {
                    if (SubjectAdding(teacherID, subjectName))
                    {
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
                        MessageBox.Show("The selected ID is not from a teacher");
                        added = true;
                    }
                }
                else
                {
                    MessageBox.Show("Subject name format invalid.");
                }
            } while (!added);
        }

        public bool SubjectExistanceCheck(string teacherID, string subjectName)
        {
            bool subjectExist = false;
            if (personList.Count != 0)
            {
                int position = ReturnPersonPosition(teacherID);
                int personType = CheckTypeOfPerson(teacherID);

                // TYPE 1 IS A TEACHER
                if (position != -1 && personType == 1)
                {
                    subjectExist = ((Teacher)personList[position]).ChecksTeacherSelectedSubject(teacherID, subjectName);
                }
            }
            return subjectExist;
        }

        public void SubjecRemoval(string teacherID, string subjectName)
        {
            if (personList.Count != 0)
            {
                int position = ReturnPersonPosition(teacherID);
                int personType = CheckTypeOfPerson(teacherID);

                // TYPE 1 IS A TEACHER
                if (position != -1 && personType == 1)
                {
                    ((Teacher)personList[position]).RemovesSelectedTeacherSubject(teacherID, subjectName);
                }
            }
        }

        public void MultipleSubjectsRemovalFromSelectedTeacher(string teacherID)
        {
            if (SelectedTeacherHasSubject(teacherID))
            {
                bool removed = false;
                do
                {
                    string subject = Interaction.InputBox("Introduce the subject's name to remove from all the teacher subjects: " + "\n\n" + ((Teacher)personList[ReturnPersonPosition(teacherID)]).StoresTeacherSubjectsInfo());
                    if (CustomRegex.RegexGradeValue(subject))
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

        public void SubjectsClearing(string teacherID)
        {
            if (personList.Count != 0)
            {
                int position = ReturnPersonPosition(teacherID);
                int personType = CheckTypeOfPerson(teacherID);

                // TYPE 1 IS A TEACHER
                if (position != -1 && personType == 1)
                {
                    ((Teacher)personList[position]).ClearSubjectsFromTeacher(teacherID);
                }
            }
        }

        public string ShowsTeachersList()
        {
            string teacherListTxt = "List of teachers: \n\n";
            if (personList.Count != 0)
            {
                foreach (Person person in personList)
                {
                    int personType = CheckTypeOfPerson(person.ID);

                    // TYPE 1 IS A TEACHER
                    if (personType == 1)
                    {
                        teacherListTxt += ((Teacher)person).ShowsPersonData() + "\n";
                    }
                }
            }
            return teacherListTxt;
        }

        public string ShowTeachersBySubjectName(string subjectName)
        {
            string subjectTeachersTxt = "The subject " + subjectName + " has as teachers: \n";
            for (int i = 0; i < personList.Count; i++)
            {
                string teacherID = ReturnsPersonIDFromPosition(i);
                int personType = CheckTypeOfPerson(teacherID);

                // TYPE 1 IS A TEACHER
                if (personType == 1)
                {
                    if (((Teacher)personList[i]).ChecksTeacherSelectedSubject(teacherID, subjectName))
                    {
                        subjectTeachersTxt += personList[i].ShowsSimplierPersonData() + "\n";
                    }
                }
            }
            return subjectTeachersTxt;
        }

        public string ShowsSelectedTeacherDataByID(string teacherID)
        {
            string teacherTxt = "";
            if (personList.Count != 0)
            {
                int position = ReturnPersonPosition(teacherID);
                int personType = CheckTypeOfPerson(teacherID);

                // TYPE 1 IS A TEACHER
                if (position != -1 && personType == 1)
                {
                    teacherTxt = ((Teacher)personList[position]).ShowsPersonData();
                }
            }
            return teacherTxt;
        }

        public int SameTeacherNameCounter(string teacherName)
        {
            int counter = 0;
            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);

                    // TYPE 1 IS A TEACHER
                    if (personType == 1)
                    {
                        if (teacherName == personList[i].Name)
                        {
                            counter++;
                        }
                    }
                }
            }
            return counter;
        }

        public void SelectSameNameTeachersToDelete(string teacherName)
        {
            bool found = false;
            List<string> matchingTeachersName = new List<string>();

            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    if (teacherName == personList[i].Name)
                    {
                        int personType = CheckTypeOfPerson(personList[i].ID);

                        // TYPE 1 IS A TEACHER
                        if (personType == 1)
                        {
                            found = true;
                            string teacherData = personList[i].ShowsSimplierPersonData();
                            matchingTeachersName.Add(teacherData);
                        }
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
                    infoMessage.AppendLine((i + 1) + ") " + matchingTeachersName[i] + "\n");
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
                            for (int i = 0; i < personList.Count && !deleted; i++)
                            {
                                int personType = CheckTypeOfPerson(personList[i].ID);

                                // TYPE 1 IS A TEACHER
                                if (personType == 1)
                                {
                                    if (teacherName == personList[i].Name)
                                    {
                                        RemovesTeacher(i);
                                        MessageBox.Show("Teacher removed successfully.");
                                        deleted = true;
                                    }
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

        public void SelectSameNameTeachersToShow(string teacherName)
        {
            bool found = false;
            List<string> matchingTeachersName = new List<string>();

            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);

                    // TYPE 1 IS A TEACHER
                    if (personType == 1)
                    {
                        if (teacherName == personList[i].Name)
                        {
                            found = true;
                            string teacherData = personList[i].ShowsSimplierPersonData();
                            matchingTeachersName.Add(teacherData);
                        }
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
                    infoMessage.AppendLine((i + 1) + ") " + matchingTeachersName[i] + "\n");
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

        public void SelectSameNameTeachersToAddSubjects(string teacherName)
        {
            bool found = false;

            // THIS STORES THE TEACHERS WITH THE SAME NAME AS A STRING WITH ALL THEIR DATA FROM TEACHERS LIST
            List<string> matchingTeachersName = new List<string>();

            // THIS STORES THESE TEACHERS ID IN ANOTHER LIST TO REUSE THEIR ID LATER
            List<string> SameNameTeachersID = new List<string>();

            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);

                    // TYPE 1 IS A TEACHER
                    if (personType == 1)
                    {
                        if (teacherName == personList[i].Name)
                        {
                            found = true;
                            string teacherData = personList[i].ShowsSimplierPersonData();
                            string teacherID = personList[i].ID;
                            matchingTeachersName.Add(teacherData);
                            SameNameTeachersID.Add(teacherID);
                        }
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
                    infoMessage.AppendLine((i + 1) + ") " + matchingTeachersName[i] + "\n");
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
                                if (CustomRegex.RegexName(subjectName))
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

        public void SelectSameNameTeachersToRemoveSubjects(string teacherName)
        {
            bool found = false;

            // THIS STORES THE TEACHERS WITH THE SAME NAME AS A STRING WITH ALL THEIR DATA FROM TEACHERS LIST
            List<string> matchingTeachersName = new List<string>();

            // THIS STORES THESE TEACHERS ID IN ANOTHER LIST TO REUSE THEIR ID LATER
            List<string> SameNameTeachersID = new List<string>();

            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);

                    // TYPE 1 IS A TEACHER
                    if (personType == 1)
                    {
                        if (teacherName == personList[i].Name)
                        {
                            found = true;
                            string teacherData = personList[i].ShowsSimplierPersonData();
                            string teacherID = personList[i].ID;
                            matchingTeachersName.Add(teacherData);
                            SameNameTeachersID.Add(teacherID);
                        }
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
                    infoMessage.AppendLine((i + 1) + ") " + matchingTeachersName[i] + "\n");
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
                                if (CustomRegex.RegexName(subjectName))
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

        public void SelectSameNameTeachersToClearSubjects(string teacherName)
        {
            bool found = false;

            // THIS STORES THE TEACHERS WITH THE SAME NAME AS A STRING WITH ALL THEIR DATA FROM TEACHERS LIST
            List<string> matchingTeachersName = new List<string>();

            // THIS STORES THESE TEACHERS ID IN ANOTHER LIST TO REUSE THEIR ID LATER
            List<string> SameNameTeachersID = new List<string>();

            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);

                    // TYPE 1 IS A TEACHER
                    if (personType == 1)
                    {
                        if (teacherName == personList[i].Name)
                        {
                            found = true;
                            string teacherData = personList[i].ShowsSimplierPersonData();
                            string teacherID = personList[i].ID;
                            matchingTeachersName.Add(teacherData);
                            SameNameTeachersID.Add(teacherID);
                        }
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
                    infoMessage.AppendLine((i + 1) + ") " + matchingTeachersName[i] + "\n");
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

        public bool SelectedTeacherHasSubject(string teacherID)
        {
            bool hasSubjects = true;
            for (int i = 0; i < personList.Count && hasSubjects; i++)
            {
                int personType = CheckTypeOfPerson(personList[i].ID);

                // TYPE 1 IS A TEACHER
                if (personType == 1)
                {
                    if (teacherID == personList[i].ID)
                    {
                        if (((Teacher)personList[i]).SubjectsList.Count() == 0)
                        {
                            hasSubjects = false;
                        }
                    }
                }
            }
            return hasSubjects;
        }

        public int SelectedSubjectHasTeachers(string subjectName)
        {
            int teachersCount = 0;
            for (int i = 0; i < personList.Count; i++)
            {
                int personType = CheckTypeOfPerson(personList[i].ID);

                // TYPE 1 IS A TEACHER
                if (personType == 1)
                {
                    if (((Teacher)personList[i]).SubjectsList.Contains(subjectName))
                    {
                        teachersCount++;
                    }
                }
            }
            return teachersCount;
        }

        public int TeachersWithSubjectsCounter()
        {
            int teachersWithSubjects = 0;
            for (int i = 0; i < personList.Count; i++)
            {
                int personType = CheckTypeOfPerson(personList[i].ID);

                // TYPE 1 IS A TEACHER
                if (personType == 1)
                {
                    if (((Teacher)personList[i]).SubjectsList.Count() > 0)
                    {
                        teachersWithSubjects++;
                    }
                }
            }
            return teachersWithSubjects;
        }

        public void SortListAlphabeticallyByTeacher()
        {
            Person auxPerson;
            for (int i = 0; i < personList.Count; i++)
            {
                for (int j = i + 1; j < personList.Count; j++)
                {
                    int firstPersonType = CheckTypeOfPerson(personList[i].ID);
                    int secondPersonTypeB = CheckTypeOfPerson(personList[j].ID);

                    // TYPE 1 IS A TEACHER
                    if (firstPersonType == 1 && secondPersonTypeB == 1)
                    {
                        if (string.Compare(personList[i].Name, personList[j].Name) > 0)
                        {
                            auxPerson = personList[i];
                            personList[i] = personList[j];
                            personList[j] = auxPerson;
                        }
                    }
                }
            }
        }

        public bool CourseAlreadyHasTutor(int courseMentorCod)
        {
            bool alreadyHasTutor = false;
            for (int i = 0; i < personList.Count && !alreadyHasTutor; i++)
            {
                int personType = CheckTypeOfPerson(personList[i].ID);

                // TYPE 1 IS A TEACHER
                if (personType == 1)
                {
                    if (((Teacher)personList[i]).TutorCod == courseMentorCod)
                    {
                        alreadyHasTutor = true;
                    }
                }
            }
            return alreadyHasTutor;
        }

        public bool AlreadyUsedEmail(string pEmail)
        {
            bool used = false;
            for (int i = 0; i < personList.Count && !used; i++)
            {
                int personType = CheckTypeOfPerson(personList[i].ID);

                // TYPE 1 IS A TEACHER
                if (personType == 1)
                {
                    if (pEmail == ((Teacher)personList[i]).Email)
                    {
                        used = true;
                    }
                }
            }
            return used;
        }

        public int CountsTotalTeachers()
        {
            int totalTeachers = 0;
            if (CountsTotalPersons() > 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);

                    // TYPE 1 IS A TEACHER
                    if (personType == 1)
                    {
                        totalTeachers++;
                    }
                }
            }
            return totalTeachers;
        }

        // END TEACHERS RELATED METHODS //

        // ALUMNS RELATED METHODS //

        public void AddsAlumn(string alumnName, string alumnID, int alumnPhone, int courseCod)
        {
            Alumn newAlumn = new Alumn();
            newAlumn.Name = alumnName;
            newAlumn.ID = alumnID;
            newAlumn.Phone = alumnPhone;
            newAlumn.CourseCod = courseCod;
            personList.Add(newAlumn);
        }

        public void RemovesAlumn(int alumnPosition)
        {
            string personID = ReturnsPersonIDFromPosition(alumnPosition);
            int personType = CheckTypeOfPerson(personID);

            // TYPE 0 IS AN ALUMN
            if (personType == 0)
            {
                personList.RemoveAt(alumnPosition);
            }
        }

        public bool GradeAdding(string alumnID, double alumnGrade)
        {
            bool gradeAdded = false;
            if (personList.Count != 0)
            {
                int position = ReturnPersonPosition(alumnID);
                int personType = CheckTypeOfPerson(alumnID);

                // TYPE 0 IS AN ALUMN
                if (position != -1 && personType == 0)
                {
                    if (alumnGrade >= 0 && alumnGrade <= 10)
                    {
                        ((Alumn)personList[position]).AddsSelectedAlumnGrade(alumnID, alumnGrade);
                        gradeAdded = true;
                    }
                }
            }
            return gradeAdded;
        }

        public void MultipleGradeAddingFromSelectedAlumn(string alumnID)
        {
            bool added = false;
            do
            {
                string gradeValue = Interaction.InputBox("Introduce the alumn's grade to add to this alumn: ");
                if (CustomRegex.RegexGradeValue(gradeValue))
                {
                    double grade = double.Parse(gradeValue);

                    if (GradeAdding(alumnID, grade))
                    {
                        MessageBox.Show("A grade with a value of " + grade + " has been added to this alumn.");

                        //THIS RE ASKS IF YOU WANT TO ADD MORE GRADES TO THE SAME ALUMN ALREADY SELECTED
                        DialogResult keepAdding = MessageBox.Show("Do you want to keep adding grades?", "Keep Adding Grades", MessageBoxButtons.YesNo);
                        if (keepAdding == DialogResult.No)
                        {
                            added = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The selected ID is not from an alumn");
                        added = true;
                    }
                }
                else
                {
                    MessageBox.Show("Grade value invalid, select a value between 0 and 10.");
                }
            } while (!added);
        }

        public bool GradeExistanceCheck(string alumnID, double alumnGrade)
        {
            bool gradeExist = false;
            if (personList.Count != 0)
            {
                int position = ReturnPersonPosition(alumnID);
                int personType = CheckTypeOfPerson(alumnID);


                if (position != -1 && personType == 0)
                {
                    if (alumnGrade >= 0 && alumnGrade <= 10)
                    {
                        gradeExist = ((Alumn)personList[position]).ChecksAlumnSelectedGrade(alumnID, alumnGrade);
                    }
                }
            }
            return gradeExist;
        }

        public void GradeRemoval(string alumnID, double alumnGrade)
        {
            if (personList.Count != 0)
            {
                int position = ReturnPersonPosition(alumnID);
                int personType = CheckTypeOfPerson(alumnID);

                if (position != -1 && personType == 0)
                {
                    if (alumnGrade >= 0 && alumnGrade <= 10)
                    {
                        ((Alumn)personList[position]).RemovesSelectedAlumnGrade(alumnID, alumnGrade);
                    }
                }
            }
        }

        public void MultipleGradeRemovingFromSelectedAlumn(string alumnID)
        {
            if (SelectedAlumnHasGrades(alumnID))
            {
                bool removed = false;
                do
                {
                    string gradeValue = Interaction.InputBox("Introduce the alumn's grade to remove from all the alumn grades: ");
                    if (CustomRegex.RegexGradeValue(gradeValue))
                    {
                        double grade = double.Parse(gradeValue);
                        if (GradeExistanceCheck(alumnID, grade))
                        {
                            GradeRemoval(alumnID, grade);
                            MessageBox.Show("A grade with a value of " + grade + " has been cleared from this alumn.");

                            if (SelectedAlumnHasGrades(alumnID))
                            {
                                //THIS RE ASKS IF YOU WANT TO ADD MORE GRADES TO THE SAME ALUMN ALREADY SELECTED
                                DialogResult keepRemoving = MessageBox.Show("Do you want to keep removing grades?", "Keep Removing Grades", MessageBoxButtons.YesNo);
                                if (keepRemoving == DialogResult.No)
                                {
                                    removed = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("This alumn doesn't have any grades left to remove.");
                                removed = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("The alumn has not any grade with that value, try another value.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Grade value invalid, select a value between 0 and 10.");
                    }
                } while (!removed);
            }
            else
            {
                MessageBox.Show("The alumn has not any grades added. ");
            }
        }

        public void GradesClearing(string alumnID)
        {
            if (personList.Count != 0)
            {
                int position = ReturnPersonPosition(alumnID);
                int personType = CheckTypeOfPerson(alumnID);

                if (position != -1 && personType == 0)
                {
                    ((Alumn)personList[position]).ClearGradesFromAlumn(alumnID);
                }
            }
        }

        public string ShowsAlumnsList()
        {
            string alumnListTxt = "List of alumns: \n\n";
            if (personList.Count != 0)
            {
                foreach (Person person in personList)
                {
                    int personType = CheckTypeOfPerson(person.ID);

                    if (personType == 0)
                    {
                        alumnListTxt += ((Alumn)person).ShowsPersonData() + "\n";
                    }
                }
            }
            return alumnListTxt;
        }

        public string ShowsSelectedAlumnDataByID(string alumnID)
        {
            string alumnTxt = "";
            if (personList.Count != 0)
            {
                int position = ReturnPersonPosition(alumnID);
                int personType = CheckTypeOfPerson(alumnID);

                if (position != -1 && personType == 0)
                {
                    alumnTxt = ((Alumn)personList[position]).ShowsPersonData();
                }
            }
            return alumnTxt;
        }


        public int SameAlumnNameCounter(string alumnName)
        {
            int counter = 0;
            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);
                    if (personType == 0)
                    {
                        if (alumnName == personList[i].Name)
                        {
                            counter++;
                        }
                    }
                }
            }
            return counter;
        }

        public void SelectSameNameAlumnsToDelete(string alumnName)
        {
            bool found = false;
            List<string> matchingAlumnsName = new List<string>();

            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);
                    if (personType == 0)
                    {
                        if (alumnName == personList[i].Name)
                        {
                            found = true;
                            string alumnData = personList[i].ShowsSimplierPersonData();
                            matchingAlumnsName.Add(alumnData);
                        }
                    }
                }
            }

            if (found)
            {
                // I HAD TO SEARCH THIS PART TO SHOW MULTIPLE INFO AND SELECT ONE FROM ALL OF THEM
                // THIS DISPLAYS ALL INFORMATION FROM ALL MATCHING NAMES FROM DIFFERENT ALUMNS
                StringBuilder infoMessage = new StringBuilder("Alumns with the same name: \n\n");

                for (int i = 0; i < matchingAlumnsName.Count; i++)
                {
                    infoMessage.AppendLine((i + 1) + ") " + matchingAlumnsName[i]);
                }

                infoMessage.AppendLine("Select the number to delete from list:\n");

                string userInput = Interaction.InputBox(infoMessage.ToString());
                int selectedAlumnIndex;

                // THIS MAKES THE INPUT SELECTED TO ASIGN IT TO AN ALUMN INDEX AND NEXT IT WILL DELETE ASK IF YOU WANT TO REMOVE THE SELECTED ONE
                if (int.TryParse(userInput, out selectedAlumnIndex) && selectedAlumnIndex > 0 && selectedAlumnIndex <= matchingAlumnsName.Count)
                {
                    // GETS THE SELECTED ALUMN INFU
                    string selectedAlumnInfo = matchingAlumnsName[selectedAlumnIndex - 1];

                    // ASKS THE USER IF THEY WANT TO REMOVE THE SELECTED ALUMN
                    DialogResult result = MessageBox.Show(selectedAlumnInfo + "Do you want to remove this alumn?", "Remove Alumn", MessageBoxButtons.YesNo);
                    bool deleted = false;
                    do
                    {
                        if (result == DialogResult.Yes)
                        {
                            // FIND THE MATCHING ALUMN IN THE ALUMNLIST AND REMOVE IT
                            for (int i = 0; i < personList.Count && !deleted; i++)
                            {
                                int personType = CheckTypeOfPerson(personList[i].ID);
                                if (personType == 0)
                                {
                                    if (alumnName == personList[i].Name)
                                    {
                                        RemovesAlumn(i);
                                        MessageBox.Show("Alumn cleared successfully.");
                                        deleted = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            userInput = Interaction.InputBox(infoMessage.ToString());
                            result = MessageBox.Show(selectedAlumnInfo + "\nDo you want to remove this alumn?", "Remove Alumn", MessageBoxButtons.YesNo);
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
                MessageBox.Show("No alumns found with the given name.");
            }
        }

        public void SelectSameNameAlumnsToShow(string alumnName)
        {
            bool found = false;
            List<string> matchingAlumnsName = new List<string>();

            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);
                    if (personType == 0)
                    {
                        if (alumnName == personList[i].Name)
                        {
                            found = true;
                            string alumnData = ((Alumn)personList[i]).ShowsPersonData();
                            matchingAlumnsName.Add(alumnData);
                        }
                    }
                }
            }

            if (found)
            {
                // I HAD TO SEARCH THIS PART TO SHOW MULTIPLE INFO AND SELECT ONE FROM ALL OF THEM
                // THIS DISPLAYS ALL INFORMATION FROM ALL MATCHING NAMES FROM DIFFERENT ALUMNS
                StringBuilder infoMessage = new StringBuilder("Alumns with the same name: \n\n");

                for (int i = 0; i < matchingAlumnsName.Count; i++)
                {
                    infoMessage.AppendLine((i + 1) + ") " + matchingAlumnsName[i] + "\n");
                }

                infoMessage.AppendLine("Select the number of alumn to check more data from it:\n");

                string userInput = Interaction.InputBox(infoMessage.ToString());
                int selectedAlumnIndex;

                if (int.TryParse(userInput, out selectedAlumnIndex) && selectedAlumnIndex > 0 && selectedAlumnIndex <= matchingAlumnsName.Count)
                {
                    // GETS THE SELECTED ALUMN INFU
                    string selectedAlumnInfo = matchingAlumnsName[selectedAlumnIndex - 1];

                    // ASKS THE USER IF THIS IS THE ACTUAL ALUMN WHOSE INFO WAS REQUIRED
                    DialogResult result = MessageBox.Show(selectedAlumnInfo + "\nIs this alumn the one that you wanted to see info?", "Check Alumn", MessageBoxButtons.YesNo);
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
                            result = MessageBox.Show(selectedAlumnInfo + "\nIs this alumn the one that you wanted to see info?", "Check Alumn", MessageBoxButtons.YesNo);
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
                MessageBox.Show("No alumns found with the given name.");
            }
        }

        // FUNCTION WHICH COLLECTS ALL DATA FROM ALL THE ALUMNS WITH SAME NAME ADDED INTO THE ALUMNS LIST TO ADD THEM GRADES
        public void SelectSameNameAlumnsToAddGrade(string alumnName)
        {
            bool found = false;

            // THIS STORES THE ALUMNS WITH THE SAME NAME AS A STRING WITH ALL THEIR DATA FROM ALUMNS LIST
            List<string> matchingAlumnsName = new List<string>();

            // THIS STORES THESE ALUMNS ID IN ANOTHER LIST TO REUSE THEIR ID LATER
            List<string> SameNameAlumnsID = new List<string>();

            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);
                    if (personType == 0)
                    {
                        if (alumnName == personList[i].Name)
                        {
                            found = true;
                            string alumnData = ((Alumn)personList[i]).ShowsPersonData();
                            string alumnID = personList[i].ID;
                            matchingAlumnsName.Add(alumnData);
                            SameNameAlumnsID.Add(alumnID);
                        }
                    }
                }
            }

            if (found)
            {
                // I HAD TO SEARCH THIS PART TO SHOW MULTIPLE INFO AND SELECT ONE FROM ALL OF THEM
                // THIS DISPLAYS ALL INFORMATION FROM ALL MATCHING NAMES FROM DIFFERENT ALUMNS
                StringBuilder infoMessage = new StringBuilder("Alumns with the same name: \n\n");

                for (int i = 0; i < matchingAlumnsName.Count; i++)
                {
                    infoMessage.AppendLine((i + 1) + ") " + matchingAlumnsName[i] + "\n");
                }

                infoMessage.AppendLine("Select the number of alumn to add a grade from the list:\n");

                string userInput = Interaction.InputBox(infoMessage.ToString());
                int selectedAlumnIndex;

                if (int.TryParse(userInput, out selectedAlumnIndex) && selectedAlumnIndex > 0 && selectedAlumnIndex <= matchingAlumnsName.Count)
                {
                    // GETS THE SELECTED ALUMN INFU AND ID
                    string selectedAlumnInfo = matchingAlumnsName[selectedAlumnIndex - 1];
                    string selectedAlumnID = SameNameAlumnsID[selectedAlumnIndex - 1];

                    DialogResult result;
                    bool added = false;
                    do
                    {
                        // ASKS THE USER IF THIS IS THE ACTUAL ALUMN WHOSE INFO WAS REQUIRED
                        result = MessageBox.Show(selectedAlumnInfo + "\nIs this alumn the one that you wanted to add a grade?", "Add Grade", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            do
                            {
                                string gradeValue = Interaction.InputBox("Introduce the alumn's grade to add to this alumn: ");
                                if (CustomRegex.RegexGradeValue(gradeValue))
                                {
                                    double grade = double.Parse(gradeValue);
                                    GradeAdding(selectedAlumnID, grade);
                                    MessageBox.Show("A grade with a value of " + grade + " has been added to this alumn.");

                                    //THIS RE ASKS IF YOU WANT TO ADD MORE GRADES TO THE SAME ALUMN ALREADY SELECTED
                                    DialogResult keepAdding = MessageBox.Show("Do you want to keep adding grades?", "Keep Adding Grades", MessageBoxButtons.YesNo);
                                    if (keepAdding == DialogResult.No)
                                    {
                                        added = true;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Grade value invalid, select a value between 0 and 10.");
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
                MessageBox.Show("No alumns found with the given name.");
            }
        }

        public void SelectSameNameAlumnsToRemoveGrade(string alumnName)
        {
            bool found = false;

            // THIS STORES THE ALUMNS WITH THE SAME NAME AS A STRING WITH ALL THEIR DATA FROM ALUMNS LIST
            List<string> matchingAlumnsName = new List<string>();

            // THIS STORES THESE ALUMNS ID IN ANOTHER LIST TO REUSE THEIR ID LATER
            List<string> SameNameAlumnsID = new List<string>();

            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);
                    if (personType == 0)
                    {
                        if (alumnName == personList[i].Name)
                        {
                            string alumnData = personList[i].ShowsSimplierPersonData();
                            string alumnID = personList[i].ID;
                            matchingAlumnsName.Add(alumnData);
                            SameNameAlumnsID.Add(alumnID);
                            found = true;
                        }
                    }
                }

                if (found)
                {
                    // I HAD TO SEARCH THIS PART TO SHOW MULTIPLE INFO AND SELECT ONE FROM ALL OF THEM
                    // THIS DISPLAYS ALL INFORMATION FROM ALL MATCHING NAMES FROM DIFFERENT ALUMNS
                    StringBuilder infoMessage = new StringBuilder("Alumns with the same name: \n\n");

                    for (int i = 0; i < matchingAlumnsName.Count; i++)
                    {
                        infoMessage.AppendLine((i + 1) + ") " + matchingAlumnsName[i] + "\n");
                    }

                    infoMessage.AppendLine("Select the number of alumn to remove a grade from the list:\n");

                    string userInput = Interaction.InputBox(infoMessage.ToString());
                    int selectedAlumnIndex;

                    if (int.TryParse(userInput, out selectedAlumnIndex) && selectedAlumnIndex > 0 && selectedAlumnIndex <= matchingAlumnsName.Count)
                    {
                        // GETS THE SELECTED ALUMN INFU AND ID
                        string selectedAlumnInfo = matchingAlumnsName[selectedAlumnIndex - 1];
                        string selectedAlumnID = SameNameAlumnsID[selectedAlumnIndex - 1];

                        DialogResult result;
                        bool removed = false;
                        do
                        {
                            // ASKS THE USER IF THIS IS THE ACTUAL ALUMN WHOSE INFO WAS REQUIRED
                            result = MessageBox.Show(selectedAlumnInfo + "\nIs this alumn the one that you wanted to remove a grade?", "Add Grade", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                do
                                {
                                    string gradeValue = Interaction.InputBox("Introduce the alumn's grade to remove from all the alumn grades: ");
                                    if (CustomRegex.RegexGradeValue(gradeValue))
                                    {
                                        double grade = double.Parse(gradeValue);
                                        if (GradeExistanceCheck(selectedAlumnID, grade))
                                        {
                                            GradeRemoval(selectedAlumnID, grade);
                                            MessageBox.Show("A grade with a value of " + grade + " has been cleared from this alumn.");

                                            if (SelectedAlumnHasGrades(selectedAlumnID))
                                            {
                                                //THIS RE ASKS IF YOU WANT TO ADD MORE GRADES TO THE SAME ALUMN ALREADY SELECTED
                                                DialogResult keepRemoving = MessageBox.Show("Do you want to keep removing grades?", "Keep Removing Grades", MessageBoxButtons.YesNo);
                                                if (keepRemoving == DialogResult.No)
                                                {
                                                    removed = true;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("This alumn doesn't have any grades left to remove.");
                                                removed = true;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("The alumn has not any grade with that value, try another value.");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Grade value invalid, select a value between 0 and 10.");
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
                    MessageBox.Show("No alumns found with the given name.");
                }
            }
        }


        public void SelectSameNameAlumnsToClearGrades(string alumnName)
        {
            bool found = false;

            // THIS STORES THE ALUMNS WITH THE SAME NAME AS A STRING WITH ALL THEIR DATA FROM ALUMNS LIST
            List<string> matchingAlumnsName = new List<string>();

            // THIS STORES THESE ALUMNS ID IN ANOTHER LIST TO REUSE THEIR ID LATER
            List<string> SameNameAlumnsID = new List<string>();

            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);

                    // TYPE 0 IS ALUMN
                    if (personType == 0)
                    {
                        if (alumnName == personList[i].Name)
                        {
                            string alumnData = personList[i].ShowsSimplierPersonData();
                            string alumnID = personList[i].ID;
                            matchingAlumnsName.Add(alumnData);
                            SameNameAlumnsID.Add(alumnID);
                            found = true;
                        }
                    }
                }
            }

            if (found)
            {
                // I HAD TO SEARCH THIS PART TO SHOW MULTIPLE INFO AND SELECT ONE FROM ALL OF THEM
                // THIS DISPLAYS ALL INFORMATION FROM ALL MATCHING NAMES FROM DIFFERENT ALUMNS
                StringBuilder infoMessage = new StringBuilder("Alumns with the same name: \n\n");

                for (int i = 0; i < matchingAlumnsName.Count; i++)
                {
                    infoMessage.AppendLine((i + 1) + ") " + matchingAlumnsName[i] + "\n");
                }

                infoMessage.AppendLine("Select the number of alumn to clear all its grades from the list:\n");

                string userInput = Interaction.InputBox(infoMessage.ToString());
                int selectedAlumnIndex;

                if (int.TryParse(userInput, out selectedAlumnIndex) && selectedAlumnIndex > 0 && selectedAlumnIndex <= matchingAlumnsName.Count)
                {
                    // GETS THE SELECTED ALUMN INFU AND ID
                    string selectedAlumnInfo = matchingAlumnsName[selectedAlumnIndex - 1];
                    string selectedAlumnID = SameNameAlumnsID[selectedAlumnIndex - 1];

                    DialogResult result;
                    bool cleared = false;
                    do
                    {
                        // ASKS THE USER IF THIS IS THE ACTUAL ALUMN WHOSE INFO WAS REQUIRED
                        result = MessageBox.Show(selectedAlumnInfo + "\nIs this alumn the one that you wanted to clear it's grades?", "Clear Grades", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            if (SelectedAlumnHasGrades(selectedAlumnID))
                            {
                                GradesClearing(selectedAlumnID);
                                MessageBox.Show("All grades from this alumn has been cleared");
                                cleared = true;
                            }
                            else
                            {
                                MessageBox.Show("This alumn doesn't have any grades added.");
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
                MessageBox.Show("No alumns found with the given name.");
            }
        }


        public string ShowsAlumnsWhoseGradesAvgIsEqualOrBiggerThan5()
        {
            string gradesMoreThan5 = "The alumns with the grade equal or bigger than 5 are: \n\n";
            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);

                    // TYPE 0 IS ALUMN
                    if (personType == 0)
                    {
                        if (((Alumn)personList[i]).AlumnGradesAverage() >= 5 && SelectedAlumnHasGrades(personList[i].ID))
                        {
                            gradesMoreThan5 += personList[i].ShowsPersonData() + "\n";
                        }
                    }
                }
            }
            return gradesMoreThan5;
        }

        // FUNCTION WHICH COUNTS HOW MANY ALUMNS HAS AN AVERAGE EQUAL OR MORE THAN A 5
        public int CountAlumnsWhoseGradeIsEqualOrBiggerThan5()
        {
            int alumnGradesMoreThan5 = 0;
            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);

                    // TYPE 0 IS ALUMN
                    if (personType == 0)
                    {
                        if (((Alumn)personList[i]).AlumnGradesAverage() >= 5 && SelectedAlumnHasGrades(personList[i].ID))
                        {
                            alumnGradesMoreThan5++;
                        }
                    }
                }
            }
            return alumnGradesMoreThan5;
        }

        public string ShowsAlumnsWhoseGradesAvgIsLowerThan5()
        {
            string gradesLowerThan5 = "The alumns with the grade lower than 5 are: \n\n";
            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);

                    // TYPE 0 IS ALUMN
                    if (personType == 0)
                    {
                        if (((Alumn)personList[i]).AlumnGradesAverage() < 5 && SelectedAlumnHasGrades(personList[i].ID))
                        {
                            gradesLowerThan5 += personList[i].ShowsPersonData() + "\n";
                        }
                    }
                }
            }
            return gradesLowerThan5;
        }

        public int CountAlumnsWhoseGradeIsLowerThan5()
        {
            int alumnGradesLowerThan5 = 0;
            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);

                    // TYPE 0 IS ALUMN
                    if (personType == 0)
                    {
                        if (((Alumn)personList[i]).AlumnGradesAverage() < 5 && SelectedAlumnHasGrades(personList[i].ID))
                        {
                            alumnGradesLowerThan5++;
                        }
                    }
                }
            }
            return alumnGradesLowerThan5;
        }


        public string ShowAlumnsBySelectedCourseCod(int courseCod)
        {
            string alumnsInCourse = "The alumns in the course (" + courseCod + ") are: \n\n";
            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);

                    // TYPE 0 IS ALUMN
                    if (personType == 0)
                    {
                        if (((Alumn)personList[i]).CourseCod == courseCod)
                        {
                            alumnsInCourse += personList[i].ShowsPersonData() + "\n";
                        }
                    }
                }
            }
            return alumnsInCourse;
        }

        public void SortListAlphabeticallyByAlumn()
        {
            Person auxPerson;
            for (int i = 0; i < personList.Count; i++)
            {
                for (int j = i + 1; j < personList.Count; j++)
                {
                    int firstPersonType = CheckTypeOfPerson(personList[i].ID);
                    int secondPersonTypeB = CheckTypeOfPerson(personList[j].ID);

                    if (firstPersonType == 0 && secondPersonTypeB == 0)
                    {
                        if (string.Compare(personList[i].Name, personList[j].Name) > 0)
                        {
                            auxPerson = personList[i];
                            personList[i] = personList[j];
                            personList[j] = auxPerson;
                        }
                    }
                }
            }
        }

        public bool AlumnInCourse(int aCourseCod)
        {
            bool alumnInCourse = false;

            for (int i = 0; i < personList.Count && !alumnInCourse; i++)
            {
                int personType = CheckTypeOfPerson(personList[i].ID);

                // TYPE 0 IS ALUMN
                if (personType == 0)
                {
                    if (aCourseCod == ((Alumn)personList[i]).CourseCod)
                    {
                        alumnInCourse = true;
                    }
                }
            }
            return alumnInCourse;
        }

        public bool SelectedAlumnHasGrades(string aID)
        {
            bool hasGrades = false;
            int personType = CheckTypeOfPerson(aID);
            int personPosition = ReturnPersonPosition(aID);

            // TYPE 0 IS ALUMN
            if(personType == 0)
            { 
                if (((Alumn)personList[personPosition]).GradesList.Count() != 0)
                {
                    hasGrades = true;
                }
            }
            return hasGrades;
        }

        public int AlumnsWithGradesCounter()
        {
            int alumnsWithGrades = 0;
            for (int i = 0; i < personList.Count; i++)
            {
                int personType = CheckTypeOfPerson(personList[i].ID);

                // TYPE 0 IS ALUMN
                if (personType == 0)
                {
                    if (((Alumn)personList[i]).GradesList.Count() > 0)
                    {
                        alumnsWithGrades++;
                    }
                }
            }
            return alumnsWithGrades;
        }

        public int CountTotalAlumns()
        {
            int totalAlumns = 0;
            if (CountsTotalPersons() > 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);

                    // TYPE 0 IS ALUMN
                    if (personType == 0)
                    {
                        totalAlumns++;
                    }
                }
            }
            return totalAlumns;
        }

        // END ALUMNS RELATED METHODS //

        public int GetPositionFromUniqueName(string pName)
        {
            int uniquePostion = 0;
            for (int i = 0; i < personList.Count; i++)
            {
                if (pName == personList[i].Name)
                {
                    uniquePostion = i;
                }
            }
            return uniquePostion;
        }

        public bool AlreadyUsedID(string pID)
        {
            bool used = false;
            for (int i = 0; i < personList.Count && !used; i++)
            {
                if (pID == personList[i].ID)
                {
                    used = true;
                }
            }
            return used;
        }

        public bool AlreadyUsedPhone(int pPhone)
        {
            bool used = false;
            for (int i = 0; i < personList.Count && !used; i++)
            {
                if (pPhone == personList[i].Phone)
                {
                    used = true;
                }
            }
            return used;
        }

        public string ReturnsPersonName(string pID)
        {
            string alumnName = "";
            bool found = false;
            for (int i = 0; i < personList.Count && !found; i++)
            {
                if (pID == personList[i].ID)
                {
                    alumnName = personList[i].Name;
                }
            }
            return alumnName;
        }

        public int ReturnPersonPosition(string pID)
        {
            int position = -1;
            bool found = false;

            for (int i = 0; i < personList.Count && !found; i++)
            {
                if (personList[i].ID == pID)
                {
                    position = i;
                    found = true;
                }
            }
            return position;
        }

        public string ReturnsPersonIDFromPosition(int pPosition)
        {
            string pID = "";
            bool found = false;
            for (int i = 0; i < personList.Count && !found; i++)
            {
                if (pPosition == i)
                {
                pID = personList[i].ID;
                }
            }
            return pID;
        }

        public int CheckTypeOfPerson(string pID)
        {
            int personPosition = ReturnPersonPosition(pID);
            int personType = -1;

            if (personPosition != -1)
            {
                if (personList[personPosition].GetType() == typeof(Alumn))
                {
                    personType = 0;
                }
                else if (personList[personPosition].GetType() == typeof(Teacher))
                {
                    personType = 1;
                }
            }
            return personType;
        }

        public int CountsTotalPersons()
        {
            return personList.Count;
        }
    }
}
