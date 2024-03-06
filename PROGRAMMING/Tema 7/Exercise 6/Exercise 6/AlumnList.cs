using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Exercise_6
{
    // TODO ADD A LIST OF GRADES TO SHOW WHEN REMOVING THE GRADES I WOULD LIKE SOME VISUALIZATION ON WHAT I'M REMOVING
    // TODO TRY TO REDUCE CODE AND REUSE OTHER FUNCTIONS IN THE SAMENAME(X) FUNCTIONS

    public class AlumnList
    {
        private List<Alumn> alumnList;

        public AlumnList()
        {
            alumnList = new List<Alumn>();
        }

        // FUNCTION WHICH ADDS AN ALUMN TO THE ALUMN LIST
        public void AddsAlumn(string alumnName, string alumnID, int alumnPhone, int courseCod)
        {
            Alumn newAlumn = new Alumn();
            newAlumn.Name = alumnName;
            newAlumn.ID = alumnID;
            newAlumn.Phone = alumnPhone;
            newAlumn.CourseCod = courseCod;
            alumnList.Add(newAlumn);
        }

        // FUNCTION WHICH REMOVES AN ALUMN FROM THIS LIST
        public void RemovesAlumn(int alumnPosition)
        {
            alumnList.RemoveAt(alumnPosition);
        }

        // FUNCTION THAT SELECTS AN ALUMN FROM THE LIST AND ADDS A SELECTED GRADE
        public bool GradeAdding(string alumnID, double alumnGrade)
        {
            bool gradeAdded = false;
            if (alumnList.Count != 0)
            {
                int position = ReturnsAlumnPositionFromID(alumnID);
                if (position != -1)
                {
                    if (alumnGrade >= 0 && alumnGrade <= 10)
                    {
                        alumnList[position].AddsSelectedAlumnGrade(alumnID, alumnGrade);
                        gradeAdded = true;
                    }
                }
            }
            return gradeAdded;
        }

        //FUNCTION WHICH ADDS MULTIPLE GRADES TO A SELECTED ALUMN
        public void MultipleGradeAddingFromSelectedAlumn(string alumnID)
        {
            bool added = false;
            do
            {
                string gradeValue = Interaction.InputBox("Introduce the alumn's grade to add to this alumn: ");
                if (RegexCustomFunctions.RegexGradeValue(gradeValue))
                {
                    double grade = double.Parse(gradeValue);
                    GradeAdding(alumnID, grade);
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

        // FUNCTION THAT RETURNS IF A GRADE EXIST FROM THE SELECTED ALUMN FROM ALL THE ALUMNS LIST
        public bool GradeExistanceCheck(string alumnID, double alumnGrade)
        {
            bool gradeExist = false;
            if (alumnList.Count != 0)
            {
                int position = ReturnsAlumnPositionFromID(alumnID);
                if (position != -1)
                {
                    if (alumnGrade >= 0 && alumnGrade <= 10)
                    {
                        gradeExist = alumnList[position].ChecksAlumnSelectedGrade(alumnID, alumnGrade);
                    }
                }
            }
            return gradeExist;
        }

        // FUNCTION THAT SELECTS AN ALUMN FROM THE LIST AND REMOVES IT A SELECTED GRADE
        public void GradeRemoval(string alumnID, double alumnGrade)
        {
            if (alumnList.Count != 0)
            {
                int position = ReturnsAlumnPositionFromID(alumnID);
                if (position != -1)
                {
                    if (alumnGrade >= 0 && alumnGrade <= 10)
                    {
                        alumnList[position].RemovesSelectedAlumnGrade(alumnID, alumnGrade);
                    }
                }
            }
        }

        //FUNCTION WHICH REMOVES MULTIPLE GRADES TO A SELECTED ALUMN
        public void MultipleGradeRemovingFromSelectedAlumn(string alumnID)
        {
            if (SelectedAlumnHasGrades(alumnID))
            {
                bool removed = false;
                do
                {
                    string gradeValue = Interaction.InputBox("Introduce the alumn's grade to remove from all the alumn grades: ");
                    if (RegexCustomFunctions.RegexGradeValue(gradeValue))
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

        // FUNCTION THAT SELECTS AN ALUMN FROM THE LIST AND CLEARS ALL THE GRADES FROM IT
        public void GradesClearing(string alumnID)
        {
            if (alumnList.Count != 0)
            {
                int position = ReturnsAlumnPositionFromID(alumnID);
                if (position != -1)
                {
                        alumnList[position].ClearGradesFromAlumn(alumnID);
                }
            }
        }

        // FUNCTION WHICH COLLECTS ALL DATA FROM ALL THE ALUMNS ADDED INTO THE ALUMNS LIST
        public string ShowsAlumnsList()
        {
            string alumnListTxt = "List of alumns: \n\n";
            if (alumnList.Count != 0)
            {
                foreach(Alumn alumn in alumnList)
                {
                    alumnListTxt += alumn.ShowsAlumnData() + "\n";
                }
            }
            return alumnListTxt;
        }

        // FUNCTION WHICH COLLECTS THE SELECTED ALUMN DATA BY ID FROM ALL THE ALUMNS ADDED INTO THE ALUMNS LIST 
        public string ShowsSelectedAlumnDataByID(string alumnID)
        {
            string alumnTxt = "";
            if (alumnList.Count != 0)
            {
                alumnTxt = alumnList[ReturnsAlumnPositionFromID(alumnID)].ShowsAlumnData();
            }
            return alumnTxt;
        }

        // FUNCTION WHICH COUNTS ALL ALUMNS THAT SHARE THE SAME NAME
        public int SameNameCounter(string alumnName)
        {
            int counter = 0;
            if (alumnList.Count != 0)
            {
                for (int i = 0; i < alumnList.Count; i++)
                {
                    if (alumnName == alumnList[i].Name)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        // FUNCTION WHICH COLLECTS ALL DATA FROM ALL THE ALUMNS WITH SAME NAME ADDED INTO THE ALUMNS LIST TO DELETE THE SELECTED ONE
        public void SelectSameNameAlumnsToDelete(string alumnName)
        {
            bool found = false;
            List<string> matchingAlumnsName = new List<string>();

            if (alumnList.Count != 0)
            {
                for (int i = 0; i < alumnList.Count; i++)
                {
                    if (alumnName == alumnList[i].Name)
                    {
                        found = true;
                        string alumnData = alumnList[i].ShowsSimplierAlumnData();
                        matchingAlumnsName.Add(alumnData);
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
                            for (int i = 0; i < alumnList.Count && !deleted; i++)
                            {
                                if (alumnName == alumnList[i].Name)
                                {
                                    RemovesAlumn(i);
                                    MessageBox.Show("Alumn cleared successfully.");
                                    deleted = true;
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

        // FUNCTION WHICH COLLECTS ALL DATA FROM ALL THE ALUMNS WITH SAME NAME ADDED INTO THE ALUMNS LIST TO SHOW THEIR DATA
        public void SelectSameNameAlumnsToShow(string alumnName)
        {
            bool found = false;
            List<string> matchingAlumnsName = new List<string>();

            if (alumnList.Count != 0)
            {
                for (int i = 0; i < alumnList.Count; i++)
                {
                    if (alumnName == alumnList[i].Name)
                    {
                        found = true;
                        string alumnData = alumnList[i].ShowsAlumnData();
                        matchingAlumnsName.Add(alumnData);
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

            if (alumnList.Count != 0)
            {
                for (int i = 0; i < alumnList.Count; i++)
                {
                    if (alumnName == alumnList[i].Name)
                    {
                        found = true;
                        string alumnData = alumnList[i].ShowsSimplierAlumnData();
                        string alumnID = alumnList[i].ID;
                        matchingAlumnsName.Add(alumnData);
                        SameNameAlumnsID.Add(alumnID);

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
                                if (RegexCustomFunctions.RegexGradeValue(gradeValue))
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

        // FUNCTION WHICH COLLECTS ALL DATA FROM ALL THE ALUMNS WITH SAME NAME ADDED INTO THE ALUMNS LIST TO REMOVE THEIR SELECTED GRADES
        public void SelectSameNameAlumnsToRemoveGrade(string alumnName)
        {
            bool found = false;

            // THIS STORES THE ALUMNS WITH THE SAME NAME AS A STRING WITH ALL THEIR DATA FROM ALUMNS LIST
            List<string> matchingAlumnsName = new List<string>();

            // THIS STORES THESE ALUMNS ID IN ANOTHER LIST TO REUSE THEIR ID LATER
            List<string> SameNameAlumnsID = new List<string>();

            if (alumnList.Count != 0)
            {
                    for (int i = 0; i < alumnList.Count; i++)
                    {
                        if (alumnName == alumnList[i].Name)
                        {                     
                            string alumnData = alumnList[i].ShowsSimplierAlumnData();
                            string alumnID = alumnList[i].ID;
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
                    infoMessage.AppendLine((i + 1) + ") " + matchingAlumnsName[i]);
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
                                if (RegexCustomFunctions.RegexGradeValue(gradeValue))
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

        // FUNCTION WHICH COLLECTS ALL DATA FROM ALL THE ALUMNS WITH SAME NAME ADDED INTO THE ALUMNS LIST TO REMOVE THEIR SELECTED GRADES
        public void SelectSameNameAlumnsToClearGrades(string alumnName)
        {
            bool found = false;

            // THIS STORES THE ALUMNS WITH THE SAME NAME AS A STRING WITH ALL THEIR DATA FROM ALUMNS LIST
            List<string> matchingAlumnsName = new List<string>();

            // THIS STORES THESE ALUMNS ID IN ANOTHER LIST TO REUSE THEIR ID LATER
            List<string> SameNameAlumnsID = new List<string>();

            if (alumnList.Count != 0)
            {
                for (int i = 0; i < alumnList.Count; i++)
                {
                    if (alumnName == alumnList[i].Name)
                    {
                        string alumnData = alumnList[i].ShowsSimplierAlumnData();
                        string alumnID = alumnList[i].ID;
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
                    infoMessage.AppendLine((i + 1) + ") " + matchingAlumnsName[i]);
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

        //FUNCTION WHICH RETURNS ALL ALUMNS WHOSE AVERAGE GRADE IS EQUAL OR BIGGER THAN 5
        public string ShowsAlumnsWhoseGradesAvgIsEqualOrBiggerThan5()
        {
            string gradesMoreThan5 = "The alumns with the grade equal or bigger than 5 are: \n\n";
            if (alumnList.Count != 0)
            {
                for (int i = 0; i < alumnList.Count; i++)
                {
                    if (alumnList[i].AlumnGradesAverage() >= 5 && SelectedAlumnHasGrades(alumnList[i].ID))
                    {
                        gradesMoreThan5 += alumnList[i].ShowsAlumnData() + "\n";
                    }
                }
            }
            return gradesMoreThan5;
        }

        // FUNCTION WHICH COUNTS HOW MANY ALUMNS HAS AN AVERAGE EQUAL OR MORE THAN A 5
        public int CountAlumnsWhoseGradeIsEqualOrBiggerThan5()
        {
            int alumnGradesMoreThan5 = 0;
            if (alumnList.Count != 0)
            {
                for (int i = 0; i < alumnList.Count; i++)
                {
                    if (alumnList[i].AlumnGradesAverage() >= 5 && SelectedAlumnHasGrades(alumnList[i].ID))
                    {
                        alumnGradesMoreThan5++;
                    }
                }
            }
            return alumnGradesMoreThan5;
        }

        // FUNCTION WHICH RETURNS ALL ALUMNS WHOSE AVERAGE GRADE IS LOWER THAN 5
        public string ShowsAlumnsWhoseGradesAvgIsLowerThan5()
        {
            string gradesLowerThan5 = "The alumns with the grade lower than 5 are: \n\n";
            if (alumnList.Count != 0)
            {
                for (int i = 0; i < alumnList.Count; i++)
                {
                    if (alumnList[i].AlumnGradesAverage() < 5 && SelectedAlumnHasGrades(alumnList[i].ID))
                    {
                        gradesLowerThan5 += alumnList[i].ShowsAlumnData() + "\n";
                    }
                }
            }
            return gradesLowerThan5;
        }

        // FUNCTION WHICH COUNTS HOW MANY ALUMNS HAS AN AVERAGE LOWER THAN A 5
        public int CountAlumnsWhoseGradeIsLowerThan5()
        {
            int alumnGradesLowerThan5 = 0;
            if (alumnList.Count != 0)
            {
                for (int i = 0; i < alumnList.Count; i++)
                {
                    if (alumnList[i].AlumnGradesAverage() < 5 && SelectedAlumnHasGrades(alumnList[i].ID))
                    {
                        alumnGradesLowerThan5++;
                    }
                }
            }
            return alumnGradesLowerThan5;
        }

        // FUNCTION WHICH RETURNS ALL ALUMNS WHO ARE IN THE SELECTED COURSE
        public string ShowAlumnsBySelectedCourseCod(int courseCod)
        {
            string alumnsInCourse = "The alumns in the course (" + courseCod + ") are: \n\n";
            if (alumnList.Count != 0)
            {
                for (int i = 0; i < alumnList.Count; i++)
                {
                    if (alumnList[i].CourseCod == courseCod)
                    {
                        alumnsInCourse += alumnList[i].ShowsAlumnData() + "\n";
                    }
                }
            }
            return alumnsInCourse;
        }

        // FUNCTION THAT ORDERS ALUMNS IN ALPHABETICAL ORDER
        public void SortAlumnListAlphabetically()
        {
            Alumn auxAlumnList;
            for (int i = 0; i < alumnList.Count; i++)
            {
                for (int j = i + 1; j < alumnList.Count; j++)
                {
                    if (string.Compare(alumnList[i].Name, alumnList[j].Name) > 0)
                    {
                        auxAlumnList = alumnList[i];
                        alumnList[i] = alumnList[j];
                        alumnList[j] = auxAlumnList;
                    }
                }
            }
        }

        // FUNCTION WHICH RETURNS IF THERE ARE ALUMNS IN THE SELECTED COURSE COD
        public bool AlumnsInCourse(int courseCod)
        {
            bool alumnInCourse = false;
            for(int i = 0; i < alumnList.Count && !alumnInCourse; i++)
            {
                if(courseCod == alumnList[i].CourseCod)
                {
                    alumnInCourse = true;
                }
            }
            return alumnInCourse;
        }

        // FUNCTION THAT RETURNS IF THE SELECTED COURSE COD HAS ALUMNS IN IT
        public bool SelectedAlumnHasGrades(string alumnID)
        {
            bool hasGrades = true;
            for (int i = 0; i < alumnList.Count && hasGrades; i++)
            {
                if (alumnID == alumnList[i].ID)
                {
                    if(alumnList[i].Grades.Count() == 0)
                    {
                        hasGrades = false;
                    }
                }
            }
            return hasGrades;
        }

        // FUNCTION WHICH RETURNS HOW MANY ALUMNS HAS GRADES ADDED
        public int AlumnsWithGradesCounter()
        {
            int alumnsWithGrades = 0;
            for (int i = 0; i < alumnList.Count; i++)
            {
                if (alumnList[i].Grades.Count() > 0)
                {
                alumnsWithGrades++;
                }             
            }
            return alumnsWithGrades;
        }

        // FUNCTION WHICH GETS AN UNIQUE ID WHEN THERE'S ONLY AN UNIQUE NAME IN THE LIST
        public int GetUniqueNamePosition(string alumnName)
        {
            int uniqueId = 0;
            for (int i = 0; i < alumnList.Count; i++)
            {
                if (alumnName == alumnList[i].Name)
                {
                    uniqueId = i;
                }
            }
            return uniqueId;
        }

        // FUNCTION WHICH RETURNS IF THE ALUMN ID IS ALREADY USED
        public bool AlreadyUsedID(string alumnID)
        {
            bool used = false;
            for (int i = 0; i < alumnList.Count && !used; i++)
            {
                if (alumnID == alumnList[i].ID)
                {
                    used = true;
                }
            }
            return used;
        }

        // FUNCTION WHICH RETURNS IF THE ALUMN PHONE IS ALREADY USED
        public bool AlreadyUsedPhone(int alumnPhone)
        {
            bool used = false;
            for (int i = 0; i < alumnList.Count && !used; i++)
            {
                if (alumnPhone == alumnList[i].Phone)
                {
                    used = true;
                }
            }
            return used;
        }

        // FUNCTION WHICH RETURNS THE ALUMN NAME FROM THE SELECTED ALUMN ID
        public string ReturnsAlumnName(string alumnID)
        {
            string alumnName = "";
            for (int i = 0; i < alumnList.Count; i++)
            {
                if (alumnID == alumnList[i].ID)
                {
                    alumnName = alumnList[i].Name;
                }
            }
            return alumnName;
        }

        // FUNCTION WHICH RETURNS THE COURSE ID OF THE SELECTED ALUMN         ????????NOT USED???????
        public int ReturnsAlumnCourse(string alumnID)
        {
            int courseCod = -1;
            for (int i = 0; i < alumnList.Count; i++)
            {
                if (alumnID == alumnList[i].ID)
                {
                    courseCod = alumnList[i].CourseCod;
                }
            }
            return courseCod;
        }

        // FUNCTION WHICH RETURNS THE POSITION OF THE ALUMN IN THE LIST, IF IT'S NEGATIVE THE ALUMN IS NOT IN THE LIST
        public int ReturnsAlumnPositionFromID(string alumnID)
        {
            int index = -1;
            for (int i = 0; i < alumnList.Count; i++)
            {
                if (alumnID == alumnList[i].ID)
                {
                    index = i;
                }
            }
            return index;
        }

        // FUNCTION WHICH RETURNS THE ID FROM AN ALUMN IN THE LIST
        public string ReturnsAlumnIDFromPosition(int alumnPosition)
        {
            string alumnID = "";
            for (int i = 0; i < alumnList.Count; i++)
            {
                if (alumnPosition == i)
                {
                    alumnID = alumnList[i].ID;
                }
            }
            return alumnID;
        }

        // FUNCTION WHICH RETURNS THE COUNT OF THE NUMBER OF ALUMNS IN THE LIST
        public int CountsTotalAlumns()
        {
            return alumnList.Count;
        }
    }
}
