using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_2
{
    public class PersonList
    {
        private List<Person> personList;

        public PersonList()
        {
            personList = new List<Person>();
        }

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
                int personType = CheckTypeOfPerson(teacherID);

                // TYPE 1 IS A TEACHER
                if (personType == 1)
                {
                    int position = ReturnPersonPosition(teacherID);
                    if (position != -1)
                    {
                        ((Teacher)personList[position]).AddsSelectedTeacherSubject(teacherID, subjectName);
                        subjectAdded = true;
                    }
                }
            }
            return subjectAdded;
        }

        public void MultipleSubjectsAddingFromSelectedTeacher(string teacherID)
        {
            bool added = false;
            int position = ReturnPersonPosition(teacherID);
            do
            {
                string subjectName = Interaction.InputBox("Introduce the subject's name to add to this teacher: \n" + ((Teacher)personList[ReturnPersonPosition(teacherID)]).StoresTeacherSubjectsInfo());
                if (CustomRegex.RegexName(subjectName))
                {
                    bool alreadyAdded = SubjectExistanceCheck(teacherID, subjectName);

                    if (!alreadyAdded)
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
                        MessageBox.Show("The selected subject was already added, so there's no point in adding it again.");
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
                int personType = CheckTypeOfPerson(teacherID);

                // TYPE 1 IS A TEACHER
                if (personType == 1)
                {
                    int position = ReturnPersonPosition(teacherID);
                    if (position != -1)
                    {
                        subjectExist = ((Teacher)personList[position]).ChecksTeacherSelectedSubject(teacherID, subjectName);
                    }
                }
            }
            return subjectExist;
        }

        public void SubjectRemoval(string teacherID, string subjectName)
        {
            if (personList.Count != 0)
            {
                int personType = CheckTypeOfPerson(teacherID);

                // TYPE 1 IS A TEACHER
                if (personType == 1)
                {
                    int position = ReturnPersonPosition(teacherID);
                    if (position != -1)
                    {
                        ((Teacher)personList[position]).RemovesSelectedTeacherSubject(teacherID, subjectName);
                    }
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
                    string subject = Interaction.InputBox("Introduce the subject's name to remove from all the teacher subjects: " + "\n" + ((Teacher)personList[ReturnPersonPosition(teacherID)]).StoresTeacherSubjectsInfo());
                    if (CustomRegex.RegexName(subject))
                    {
                        if (SubjectExistanceCheck(teacherID, subject))
                        {
                            SubjectRemoval(teacherID, subject);
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
                int personType = CheckTypeOfPerson(teacherID);


                // TYPE 1 IS A TEACHER
                if (personType == 1)
                {
                    int position = ReturnPersonPosition(teacherID);
                    if (position != -1)
                    {
                        ((Teacher)personList[position]).ClearSubjectsFromTeacher(teacherID);
                    }
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
                        subjectTeachersTxt += "\n" + personList[i].ShowsSimplierPersonData() + "\n";
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
                int personType = CheckTypeOfPerson(teacherID);

                // TYPE 1 IS A TEACHER
                if (personType == 1)
                {
                    int position = ReturnPersonPosition(teacherID);
                    if (position != -1)
                    {
                        teacherTxt = ((Teacher)personList[position]).ShowsPersonData();
                    }
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
            List<string> matchingTeachersName = new List<string>();
            List<string> matchingTeachersNameID = new List<string>();

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
                            string teacherData = personList[i].ShowsSimplierPersonData();
                            matchingTeachersName.Add(teacherData);
                            matchingTeachersNameID.Add(personList[i].ID);
                        }
                    }
                }
            }

            if (matchingTeachersName.Count > 0)
            {
                bool deleted = false;
                int selectedTeacherIndex = 0;

                while (!deleted)
                {
                    StringBuilder infoMessage = new StringBuilder("Teachers with the same name:\n\n");

                    for (int i = 0; i < matchingTeachersName.Count; i++)
                    {
                        infoMessage.AppendLine((i + 1) + ") " + matchingTeachersName[i] + "\n");
                    }

                    infoMessage.AppendLine("Select the number to delete from list:\n");
                    string userInput = Interaction.InputBox(infoMessage.ToString());

                    if (int.TryParse(userInput, out selectedTeacherIndex) && selectedTeacherIndex > 0 && selectedTeacherIndex <= matchingTeachersName.Count)
                    {
                        string selectedTeacherInfo = matchingTeachersName[selectedTeacherIndex - 1];
                        string selectedTeacherID = matchingTeachersNameID[selectedTeacherIndex - 1];

                        DialogResult result = MessageBox.Show(selectedTeacherInfo + "\n\nDo you want to remove this teacher?", "Remove Teacher", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            for (int i = 0; i < personList.Count && !deleted; i++)
                            {
                                int personType = CheckTypeOfPerson(personList[i].ID);
                                if (personType == 1)
                                {
                                    if (teacherName == personList[i].Name && personList[i].ID == selectedTeacherID)
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
                            MessageBox.Show("Please select a different teacher.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid number corresponding to a teacher.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No teachers found with the selected name.");
            }
        }

        public void SelectSameNameTeachersToShow(string teacherName)
        {
            List<string> matchingTeachersName = new List<string>();
            List<string> extraTeachersInfo = new List<string>();

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
                            string teacherData = personList[i].ShowsSimplierPersonData();
                            string extraData = ((Teacher)personList[i]).ShowsPersonData();
                            matchingTeachersName.Add(teacherData);
                            extraTeachersInfo.Add(extraData);
                        }
                    }
                }
            }
            
            if (matchingTeachersName.Count > 0)
            { 
                bool showed = false;
                int selectedTeacherIndex = 0;

                while (!showed)
                {
                    StringBuilder infoMessage = new StringBuilder("Teachers with the same name:\n\n");

                    for (int i = 0; i < matchingTeachersName.Count; i++)
                    {
                        infoMessage.AppendLine((i + 1) + ") " + matchingTeachersName[i] + "\n");
                    }

                    infoMessage.AppendLine("Select the number of the teacher to view more data:");

                    string userInput = Interaction.InputBox(infoMessage.ToString());

                    if (int.TryParse(userInput, out selectedTeacherIndex) && selectedTeacherIndex > 0 && selectedTeacherIndex <= matchingTeachersName.Count)
                    {
                        string selectedTeacherInfo = extraTeachersInfo[selectedTeacherIndex - 1];

                        DialogResult result = MessageBox.Show(selectedTeacherInfo + "\n\nIs this the teacher you want to check info?", "Check Teacher Info", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            showed = true;
                        }
                        else
                        {
                            MessageBox.Show("Please select a different teacher.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid number corresponding to a teacher.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No teachers found with the selected name.");
            }
        }

        public void SelectSameNameTeachersToAddSubjects(string teacherName)
        {

            // THIS STORES THE TEACHERS WITH THE SAME NAME AS A STRING WITH ALL THEIR DATA FROM TEACHERS LIST
            List<string> matchingTeachersName = new List<string>();

            // THIS STORES THESE TEACHERS ID IN ANOTHER LIST TO REUSE THEIR ID LATER
            List<string> matchingTeachersNameID = new List<string>();

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
                            string teacherData = personList[i].ShowsSimplierPersonData();
                            string teacherID = personList[i].ID;
                            matchingTeachersName.Add(teacherData);
                            matchingTeachersNameID.Add(teacherID);
                        }
                    }
                }
            }

            if (matchingTeachersName.Count > 0)
            {
                bool added = false;
                int selectedTeacherIndex = 0;

                while (!added)
                {
                    StringBuilder infoMessage = new StringBuilder("Teachers with the same name:\n\n");

                    for (int i = 0; i < matchingTeachersName.Count; i++)
                    {
                        infoMessage.AppendLine((i + 1) + ") " + matchingTeachersName[i] + "\n");
                    }

                    infoMessage.AppendLine("Select the number to delete from list:\n");
                    string userInput = Interaction.InputBox(infoMessage.ToString());

                    if (int.TryParse(userInput, out selectedTeacherIndex) && selectedTeacherIndex > 0 && selectedTeacherIndex <= matchingTeachersName.Count)
                    {
                        string selectedTeacherInfo = matchingTeachersName[selectedTeacherIndex - 1];
                        string selectedTeacherID = matchingTeachersNameID[selectedTeacherIndex - 1];
                        DialogResult result = MessageBox.Show(selectedTeacherInfo + "\n\nDo you want to add subjects to this teacher?", "Add Subjects", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            do
                            {
                                int position = ReturnPersonPosition(selectedTeacherID);
                                string subjectName = Interaction.InputBox("Introduce the subject's name to add to this teacher: \n\n" + ((Teacher)personList[position]).StoresTeacherSubjectsInfo());
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
                            MessageBox.Show("Please select a different teacher.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid number input. Please enter a valid number.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No teachers found with the given name.");
            }
        }

        public void SelectSameNameTeachersToRemoveSubjects(string teacherName)
        {
            // THIS STORES THE TEACHERS WITH THE SAME NAME AS A STRING WITH ALL THEIR DATA FROM TEACHERS LIST
            List<string> matchingTeachersName = new List<string>();

            // THIS STORES THESE TEACHERS ID IN ANOTHER LIST TO REUSE THEIR ID LATER
            List<string> matchingTeachersNameID = new List<string>();

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
                            if (SelectedTeacherHasSubject(ReturnsPersonIDFromPosition(i)))
                            {
                                string teacherData = personList[i].ShowsSimplierPersonData();
                                string teacherID = personList[i].ID;
                                matchingTeachersName.Add(teacherData);
                                matchingTeachersNameID.Add(teacherID);
                            }
                        }
                    }
                }
            }

            if (matchingTeachersName.Count == 1)
            {
                // STARTS REMOVING THE GRADES FROM THE ONLY ONE IN THE LIST
                string selectedTeacherID = matchingTeachersNameID[0];
                MultipleSubjectsRemovalFromSelectedTeacher(selectedTeacherID);
            }
            else if (matchingTeachersName.Count > 1)
            {
                bool removed = false;

                while (!removed)
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
                        // GETS THE SELECTED ALUMN INFU AND ID
                        string selectedTeacherInfo = matchingTeachersName[selectedTeacherIndex - 1];
                        string selectedTeacherID = matchingTeachersNameID[selectedTeacherIndex - 1];
                        DialogResult result = MessageBox.Show(selectedTeacherInfo + "\nIs this teacher the one that you wanted to remove a subject?", "Remove Subject", MessageBoxButtons.YesNo);

                        // ASKS THE USER IF THIS IS THE ACTUAL TEACHER WHOSE INFO WAS REQUIRED
                        if (result == DialogResult.Yes)
                        {
                            do
                            {
                                int position = ReturnPersonPosition(selectedTeacherID);
                                string subjectName = Interaction.InputBox("Introduce the subject's name to remove to this teacher: \n\n" + ((Teacher)personList[position]).StoresTeacherSubjectsInfo());
                                if (CustomRegex.RegexName(subjectName))
                                {
                                    if (SubjectExistanceCheck(selectedTeacherID, subjectName))
                                    {
                                        SubjectRemoval(selectedTeacherID, subjectName);
                                        MessageBox.Show("A subject named " + subjectName + " has been removed to this teacher.");

                                        if (!SelectedTeacherHasSubject(selectedTeacherID))
                                        {
                                            MessageBox.Show("The selected teacher doesn't have any subjects more to remove.");
                                            removed = true;
                                        }
                                        else
                                        {
                                            //THIS RE ASKS IF YOU WANT TO REMOVE MORE SUBJECTS TO THE SAME TEACHER ALREADY SELECTED
                                            DialogResult keepRemoving = MessageBox.Show("Do you want to keep removing subjects?", "Keep Removing Subjects", MessageBoxButtons.YesNo);
                                            if (keepRemoving == DialogResult.No)
                                            {
                                                removed = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("The selected subject does not exist in this teacher's subjects list.");
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
                            MessageBox.Show("Please select a different teacher.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid number input. Please enter a valid number.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No teachers found with the given name.");
            }
        }

        public void SelectSameNameTeachersToClearSubjects(string teacherName)
        {

            // THIS STORES THE TEACHERS WITH THE SAME NAME AS A STRING WITH ALL THEIR DATA FROM TEACHERS LIST
            List<string> matchingTeachersName = new List<string>();

            // THIS STORES THESE TEACHERS ID IN ANOTHER LIST TO REUSE THEIR ID LATER
            List<string> matchingTeachersNameID = new List<string>();

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
                            if (SelectedTeacherHasSubject(ReturnsPersonIDFromPosition(i)))
                            {
                                string teacherData = personList[i].ShowsSimplierPersonData();
                                string teacherID = personList[i].ID;
                                matchingTeachersName.Add(teacherData);
                                matchingTeachersNameID.Add(teacherID);
                            }
                        }
                    }
                }
            }

            if (matchingTeachersName.Count == 1)
            {
                // CLEAR ALL THE SUBJECTS FROM THE ONLY ONE IN THE LIST
                string selectedTeacherInfo = matchingTeachersName[0];
                string selectedTeacherID = matchingTeachersNameID[0];

                if (SelectedTeacherHasSubject(selectedTeacherID))
                {
                    SubjectsClearing(selectedTeacherID);
                    MessageBox.Show("All subjects for this teacher have been cleared.");
                }
            }
            else if (matchingTeachersName.Count > 1)
            {
                bool cleared = false;
                while (!cleared)
                {
                    // I HAD TO SEARCH THIS PART TO SHOW MULTIPLE INFO AND SELECT ONE FROM ALL OF THEM
                    // THIS DISPLAYS ALL INFORMATION FROM ALL MATCHING NAMES FROM DIFFERENT TEACHERS
                    StringBuilder infoMessage = new StringBuilder("Teachers with the same name: \n\n");

                    for (int i = 0; i < matchingTeachersName.Count; i++)
                    {
                        infoMessage.AppendLine((i + 1) + ") " + matchingTeachersName[i] + "\n");
                    }

                    infoMessage.AppendLine("Select the number of teacher to clear all its subjects from the list:\n");

                    string userInput = Interaction.InputBox(infoMessage.ToString());
                    int selectedTeacherIndex;

                    if (int.TryParse(userInput, out selectedTeacherIndex) && selectedTeacherIndex > 0 && selectedTeacherIndex <= matchingTeachersName.Count)
                    {
                        // GETS THE SELECTED TEACHER INFU AND ID
                        string selectedTeacherInfo = matchingTeachersName[selectedTeacherIndex - 1];
                        string selectedTeacherID = matchingTeachersNameID[selectedTeacherIndex - 1];
                        DialogResult result = MessageBox.Show(selectedTeacherInfo + "\nIs this teacher the one that you wanted to clear all it's subjects?", "Clear Subjects", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            if (SelectedTeacherHasSubject(selectedTeacherID))
                            {
                                SubjectsClearing(selectedTeacherID);
                                MessageBox.Show("All subjects have been removed from this teacher.");
                                cleared = true;
                            }
                            else
                            {
                                MessageBox.Show("The selected teacher doesn't have any subjects more to remove.");
                                cleared = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a different teacher.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid number input. Please enter a valid number.");
                    }
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
                int personType = CheckTypeOfPerson(alumnID);

                // TYPE 0 IS AN ALUMN
                if (personType == 0)
                {
                    int position = ReturnPersonPosition(alumnID);
                    if (position != -1)
                    {
                        if (alumnGrade >= 0 && alumnGrade <= 10)
                        {
                            ((Alumn)personList[position]).AddsSelectedAlumnGrade(alumnID, alumnGrade);
                            gradeAdded = true;
                        }
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
                int position = ReturnPersonPosition(alumnID);
                string gradeValue = Interaction.InputBox("Introduce the alumn's grade to add to this alumn: \n\n" + ((Alumn)personList[position]).StoresAlumnGradesInfo());
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
                int personType = CheckTypeOfPerson(alumnID);

                // TYPE 0 IS AN ALUMN
                if (personType == 0)
                {
                    int position = ReturnPersonPosition(alumnID);
                    if (position != -1)
                    {
                        if (alumnGrade >= 0 && alumnGrade <= 10)
                        {
                            gradeExist = ((Alumn)personList[position]).ChecksAlumnSelectedGrade(alumnID, alumnGrade);
                        }
                    }
                }
            }
            return gradeExist;
        }

        public void GradeRemoval(string alumnID, double alumnGrade)
        {
            if (personList.Count != 0)
            {
                int personType = CheckTypeOfPerson(alumnID);

                // TYPE 0 IS AN ALUMN
                if (personType == 0)
                {
                    int position = ReturnPersonPosition(alumnID);
                    if (position != -1)
                    {
                        if (alumnGrade >= 0 && alumnGrade <= 10)
                        {
                            ((Alumn)personList[position]).RemovesSelectedAlumnGrade(alumnID, alumnGrade);
                        }
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
                    int position = ReturnPersonPosition(alumnID);
                    string gradeValue = Interaction.InputBox("Introduce the alumn's grade to remove from all the alumn grades: " + ((Alumn)personList[position]).StoresAlumnGradesInfo());
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
                int personType = CheckTypeOfPerson(alumnID);

                // TYPE 0 IS AN ALUMN
                if (personType == 0)
                {
                    int position = ReturnPersonPosition(alumnID);
                    if (position != -1)
                    {
                        ((Alumn)personList[position]).ClearGradesFromAlumn(alumnID);
                    }
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
                int personType = CheckTypeOfPerson(alumnID);

                // TYPE 0 IS AN ALUMN
                if (personType == 0)
                {
                    int position = ReturnPersonPosition(alumnID);
                    if (position != -1)
                    {
                        alumnTxt = ((Alumn)personList[position]).ShowsPersonData();
                    }
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
            List<string> matchingAlumnsName = new List<string>();
            List<string> matchingAlumnsID = new List<string>();

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
                            matchingAlumnsName.Add(alumnData);
                            matchingAlumnsID.Add(personList[i].ID);
                        }
                    }
                }
            }

            if (matchingAlumnsName.Count > 0)
            {
                bool deleted = false;
                int selectedAlumnIndex = 0;

                while (!deleted)
                {
                    StringBuilder infoMessage = new StringBuilder("Alumns with the same name:\n\n");

                    for (int i = 0; i < matchingAlumnsName.Count; i++)
                    {
                        infoMessage.AppendLine((i + 1) + ") " + matchingAlumnsName[i] + "\n");
                    }

                    infoMessage.AppendLine("Select the number to delete from list:\n");
                    string userInput = Interaction.InputBox(infoMessage.ToString());

                    if (int.TryParse(userInput, out selectedAlumnIndex) && selectedAlumnIndex > 0 && selectedAlumnIndex <= matchingAlumnsName.Count)
                    {
                        string selectedAlumnInfo = matchingAlumnsName[selectedAlumnIndex - 1];
                        string selectedAlumnID = matchingAlumnsID[selectedAlumnIndex - 1];

                        DialogResult result = MessageBox.Show(selectedAlumnInfo + "\n\nDo you want to remove this alumn?", "Remove Alumn", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            for (int i = 0; i < personList.Count && !deleted; i++)
                            {
                                int personType = CheckTypeOfPerson(personList[i].ID);
                                if (personType == 0)
                                {
                                    if (alumnName == personList[i].Name && personList[i].ID == selectedAlumnID)
                                    {
                                        RemovesAlumn(i);
                                        MessageBox.Show("Alumn removed successfully.");
                                        deleted = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a different alumn.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid number corresponding to an alumn.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No alumns found with the selected name.");
            }
        }
    

        public void SelectSameNameAlumnsToShow(string alumnName)
        {
            List<string> matchingAlumnsName = new List<string>();
            List<string> extraAlumnsInfo = new List<string>();

            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);
                    if (personType == 0)
                    {
                        if (alumnName == personList[i].Name)
                        {
                            string alumnData = ((Alumn)personList[i]).ShowsSimplierPersonData();
                            string extraData = ((Alumn)personList[i]).ShowsPersonData();
                            matchingAlumnsName.Add(alumnData);
                            extraAlumnsInfo.Add(extraData);
                        }
                    }
                }
            }

            if (matchingAlumnsName.Count > 0)
            {
                bool showed = false;
                int selectedAlumnIndex = 0;

                while (!showed)
                {
                    StringBuilder infoMessage = new StringBuilder("Alumns with the same name:\n\n");

                    for (int i = 0; i < matchingAlumnsName.Count; i++)
                    {
                        infoMessage.AppendLine((i + 1) + ") " + matchingAlumnsName[i] + "\n");
                    }

                    infoMessage.AppendLine("Select the number of the alumn to view more data:");

                    string userInput = Interaction.InputBox(infoMessage.ToString());

                    if (int.TryParse(userInput, out selectedAlumnIndex) && selectedAlumnIndex > 0 && selectedAlumnIndex <= matchingAlumnsName.Count)
                    {
                        string selectedAlumnInfo = extraAlumnsInfo[selectedAlumnIndex - 1];

                        DialogResult result = MessageBox.Show(selectedAlumnInfo + "\n\nIs this the alumn you want to check info?", "Check Alumn Info", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            showed = true;
                        }
                        else
                        {
                            MessageBox.Show("Please select a different alumn.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid number corresponding to an alumn.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No alumns found with the selected name.");
            }
        }

        // FUNCTION WHICH COLLECTS ALL DATA FROM ALL THE ALUMNS WITH SAME NAME ADDED INTO THE ALUMNS LIST TO ADD THEM GRADES
        public void SelectSameNameAlumnsToAddGrade(string alumnName)
        {
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
                            string alumnData = ((Alumn)personList[i]).ShowsSimplierPersonData();
                            string alumnID = personList[i].ID;
                            matchingAlumnsName.Add(alumnData);
                            SameNameAlumnsID.Add(alumnID);
                        }
                    }
                }
            }

            if (matchingAlumnsName.Count > 0)
            {
                bool added = false;
                int selectedAlumnIndex = 0;

                while (!added)
                {
                    StringBuilder infoMessage = new StringBuilder("Alumns with the same name:\n\n");

                    for (int i = 0; i < matchingAlumnsName.Count; i++)
                    {
                        infoMessage.AppendLine((i + 1) + ") " + matchingAlumnsName[i] + "\n");
                    }

                    infoMessage.AppendLine("Select the alumn to add grades from list:\n");
                    string userInput = Interaction.InputBox(infoMessage.ToString());

                    if (int.TryParse(userInput, out selectedAlumnIndex) && selectedAlumnIndex > 0 && selectedAlumnIndex <= matchingAlumnsName.Count)
                    {
                        string selectedAlumnInfo = matchingAlumnsName[selectedAlumnIndex - 1];
                        string selectedAlumnID = SameNameAlumnsID[selectedAlumnIndex - 1];

                        DialogResult result = MessageBox.Show(selectedAlumnInfo + "\n\nDo you want to add grades to this alumn?", "Add Grades", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            do
                            {
                                int position = ReturnPersonPosition(selectedAlumnID);
                                string gradeValue = Interaction.InputBox("Introduce the alumn's grade to add to this alumn: \n\n" + ((Alumn)personList[position]).StoresAlumnGradesInfo());
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
                            MessageBox.Show("Please select a different alumn.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid number input. Please enter a valid number.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No alumns found with the given name.");
            }
        }

        public void SelectSameNameAlumnsToRemoveGrade(string alumnName)
        {

            // THIS STORES THE ALUMNS WITH THE SAME NAME AS A STRING WITH ALL THEIR DATA FROM ALUMNS LIST
            List<string> matchingAlumnsName = new List<string>();

            // THIS STORES THESE ALUMNS ID IN ANOTHER LIST TO REUSE THEIR ID LATER
            List<string> matchingAlumnsNameID = new List<string>();

            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    int personType = CheckTypeOfPerson(personList[i].ID);
                    if (personType == 0)
                    {
                        if (alumnName == personList[i].Name)
                        {
                            if (SelectedAlumnHasGrades(ReturnsPersonIDFromPosition(i)))
                            {
                                string alumnData = personList[i].ShowsSimplierPersonData();
                                string alumnID = personList[i].ID;
                                matchingAlumnsName.Add(alumnData);
                                matchingAlumnsNameID.Add(alumnID);
                            }
                        }
                    }
                }
                if (matchingAlumnsName.Count == 1)
                {
                    // STARTS REMOVING THE GRADES FROM THE ONLY ONE IN THE LIST
                    string selectedAlumnID = matchingAlumnsNameID[0];
                    MultipleGradeRemovingFromSelectedAlumn(selectedAlumnID);
                }
                else if (matchingAlumnsName.Count > 1)
                {
                    bool removed = false;

                    while (!removed)
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
                            string selectedAlumnID = matchingAlumnsNameID[selectedAlumnIndex - 1];
                            DialogResult result = MessageBox.Show(selectedAlumnInfo + "\nIs this alumn the one that you wanted to remove a grade?", "Add Grade", MessageBoxButtons.YesNo);

                            if (SelectedAlumnHasGrades(selectedAlumnID))
                            {
                                // ASKS THE USER IF THIS IS THE ACTUAL ALUMN WHOSE INFO WAS REQUIRED
                                if (result == DialogResult.Yes)
                                {
                                    do
                                    {
                                        int position = ReturnPersonPosition(selectedAlumnID);
                                        string gradeValue = Interaction.InputBox("Introduce the alumn's grade to remove from this alumn: \n\n" + ((Alumn)personList[position]).StoresAlumnGradesInfo());
                                        if (CustomRegex.RegexGradeValue(gradeValue))
                                        {
                                            double grade = double.Parse(gradeValue);
                                            if (GradeExistanceCheck(selectedAlumnID, grade))
                                            {
                                                GradeRemoval(selectedAlumnID, grade);
                                                MessageBox.Show("A grade with a value of " + grade + " has been removed from this alumn.");

                                                if (!SelectedAlumnHasGrades(selectedAlumnID))
                                                {
                                                    MessageBox.Show("The selected alumn doesn't have any grade more to remove.");
                                                    removed = true;
                                                }
                                                else
                                                {
                                                    //THIS RE ASKS IF YOU WANT TO REMOVE MORE GRADES TO THE SAME ALUMN ALREADY SELECTED
                                                    DialogResult keepRemoving = MessageBox.Show("Do you want to keep removing grades?", "Keep Adding Grades", MessageBoxButtons.YesNo);
                                                    if (keepRemoving == DialogResult.No)
                                                    {
                                                        removed = true;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("The selected grade does not exist in this alumn's grades list.");
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
                                    MessageBox.Show("Please select a different alumn.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("This alumn doesn't have any grades.");
                                removed = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid number input. Please enter a valid number.");
                        }
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
                            if (SelectedAlumnHasGrades(ReturnsPersonIDFromPosition(i)))
                            {
                                string alumnData = personList[i].ShowsSimplierPersonData();
                                string alumnID = personList[i].ID;
                                matchingAlumnsName.Add(alumnData);
                                SameNameAlumnsID.Add(alumnID);
                            }
                        }
                    }
                }
            }
            if (matchingAlumnsName.Count == 1)
            {
                // CLEAR ALL THE GRADES FROM THE ONLY ONE IN THE LIST
                string selectedAlumnInfo = matchingAlumnsName[0];
                string selectedAlumnID = SameNameAlumnsID[0];

                if (SelectedAlumnHasGrades(selectedAlumnID))
                {
                    GradesClearing(selectedAlumnID);
                    MessageBox.Show("All grades for this alumn have been cleared.");
                }
            }
            else if (matchingAlumnsName.Count > 1)
            {
                bool cleared = false;
                while (!cleared)
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
                        DialogResult result = MessageBox.Show(selectedAlumnInfo + "\nIs this alumn the one that you wanted to clear it's grades?", "Clear Grades", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            if (SelectedAlumnHasGrades(selectedAlumnID))
                            {
                                GradesClearing(selectedAlumnID);
                                MessageBox.Show("All grades have been removed from this alumn.");
                                cleared = true;
                            }
                            else
                            {
                                MessageBox.Show("The selected alumn doesn't have any grades more to remove.");
                                cleared = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a different alumn.");
                        }
                    }   
                    else
                    {
                        MessageBox.Show("Invalid number input. Please enter a valid number.");
                    }
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

            // TYPE 0 IS AN ALUMN
            if (personType == 0)
            {
                int position = ReturnPersonPosition(aID);
                if (position != -1)
                {
                    if (((Alumn)personList[position]).GradesList.Count() != 0)
                    {
                        hasGrades = true;
                    }
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
