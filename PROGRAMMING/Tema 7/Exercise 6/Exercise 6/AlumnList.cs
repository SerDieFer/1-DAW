using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Exercise_6
{
    public class AlumnList
    {
        private List<Alumn> alumnList;

        public AlumnList()
        {
            alumnList = new List<Alumn>();
        }

        //FUNCTION WHICH ADDS AN ALUMN TO THE ALUMN LIST
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

        // FUNCTION WHICH CALCULATES THE AVERAGE GRADES FROM A SELECTED ALUMN
        public double SelectAlumnGradesAverage(string alumnName)
        {
            double alumnGradesAvg = 0;
            if (alumnList.Count != 0)
            {
                for (int i = 0; i < alumnList.Count; i++)
                {
                    alumnGradesAvg = alumnList[i].AlumnGradesAverage(); 
                }
            }  
            return alumnGradesAvg;
        }

        // FUNCTION WHICH COLLECTS ALL DATA FROM ALL THE ALUMNS ADDED INTO THE ALUMNS LIST
        public string ShowsAlumnsList()
        {
            string alumnListTxt = "List of alumns: \n";
            if (alumnList.Count != 0)
            {
                foreach(Alumn alumn in alumnList)
                {
                    alumnListTxt += alumn.ShowsAlumnData();
                }
            }
            return alumnListTxt;
        }

        // FUNCTION WHICH COLLECTS ALL DATA FROM ALL THE ALUMNS ADDED INTO THE ALUMNS LIST
        public string ShowsSelectedAlumnsData(string alumnID)
        {
            string alumnTxt = "";
            bool found = false;
            if (alumnList.Count != 0)
            {
                for (int i = 0; i < alumnList.Count && !found; i++)
                {
                    alumnTxt = alumnList[i].ShowsAlumnData();
                }
            }
            return alumnTxt;
        }

        // FUNCTION WHICH COLLECTS ALL DATA FROM ALL THE ALUMNS ADDED INTO THE ALUMNS LIST
        public string ShowsSelectedAlumnsDataByID(string alumnID)
        {
            string alumnTxt = "";
            if (alumnList.Count != 0)
            {
                alumnTxt = alumnList[ReturnsAlumnPositionFromID(alumnID)].ShowsAlumnData();
            }
            return alumnTxt;
        }

        // FUNCTION WHICH COLLECTS ALL DATA FROM ALL THE ALUMNS ADDED INTO THE ALUMNS LIST
        public string ShowsAlumnsByCourse(int courseCod)
        {
            string alumnByCourseTxt = "The alumns in the course [" + courseCod +"] are: \n\n";
            if (alumnList.Count != 0)
            {
                for(int i = 0; i < alumnList.Count; i++)
                {
                    if (courseCod == alumnList[i].CourseCod)
                    {
                        alumnByCourseTxt = alumnList[i].Name + "\n";
                    }
                }
            }
            return alumnByCourseTxt;
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
                StringBuilder infoMessage = new StringBuilder("Alumns with the same name: \n");

                for (int i = 0; i < matchingAlumnsName.Count; i++)
                {
                    infoMessage.AppendLine((i + 1) + ") " + matchingAlumnsName[i]);
                }

                infoMessage.AppendLine("Select the number to delete from list:");

                string userInput = Interaction.InputBox(infoMessage.ToString());
                int selectedAlumnIndex = 0;

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
                                    MessageBox.Show("Alumn removed successfully.");
                                    deleted = true;
                                }
                            }
                        }
                        else
                        {
                            userInput = Interaction.InputBox(infoMessage.ToString());
                            result = MessageBox.Show(selectedAlumnInfo + "Do you want to remove this alumn?", "Remove Alumn", MessageBoxButtons.YesNo);
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
                        string alumnData = alumnList[i].ShowsSimplierAlumnData();
                        matchingAlumnsName.Add(alumnData);
                    }
                }
            }

            if (found)
            {
                // I HAD TO SEARCH THIS PART TO SHOW MULTIPLE INFO AND SELECT ONE FROM ALL OF THEM
                // THIS DISPLAYS ALL INFORMATION FROM ALL MATCHING NAMES FROM DIFFERENT ALUMNS
                StringBuilder infoMessage = new StringBuilder("Alumns with the same name: \n");

                for (int i = 0; i < matchingAlumnsName.Count; i++)
                {
                    infoMessage.AppendLine((i + 1) + ") " + matchingAlumnsName[i]);
                }

                infoMessage.AppendLine("Select the number of alumn to check more data from it:");

                string userInput = Interaction.InputBox(infoMessage.ToString());
                int selectedAlumnIndex = 0;

                if (int.TryParse(userInput, out selectedAlumnIndex) && selectedAlumnIndex > 0 && selectedAlumnIndex <= matchingAlumnsName.Count)
                {
                    // GETS THE SELECTED ALUMN INFU
                    string selectedAlumnInfo = matchingAlumnsName[selectedAlumnIndex - 1];

                    // ASKS THE USER IF THEY WANT TO REMOVE THE SELECTED ALUMN
                    DialogResult result = MessageBox.Show(selectedAlumnInfo + "Is this alumn the one that you wanted to see info?", "Check Alumn", MessageBoxButtons.YesNo);
                    bool show = false;
                    do
                    {
                        if (result == DialogResult.Yes)
                        {
                            // FIND THE MATCHING ALUMN IN THE ALUMNLIST AND REMOVE IT
                            for (int i = 0; i < alumnList.Count && !show; i++)
                            {
                                if (alumnName == alumnList[i].Name)
                                {
                                    show = true;
                                }
                            }
                        }
                        else
                        {
                            userInput = Interaction.InputBox(infoMessage.ToString());
                            result = MessageBox.Show(selectedAlumnInfo + "Is this alumn the one that you wanted to see info?", "Check Alumn", MessageBoxButtons.YesNo);
                        }
                    } while (!show);
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
                    if (alumnList[i].AlumnGradesAverage() >= 5)
                    {
                        gradesMoreThan5 += alumnList[i].ShowsAlumnData() + "\n";
                    }
                }
            }
            return gradesMoreThan5;
        }

        //FUNCTION WHICH RETURNS ALL ALUMNS WHOSE AVERAGE GRADE IS LOWER THAN 5
        public string ShowsAlumnsWhoseGradesAvgIsLowerThan5()
        {
            string gradesLowerThan5 = "The alumns with the grade lower than 5 are: \n\n";
            if (alumnList.Count != 0)
            {
                for (int i = 0; i < alumnList.Count; i++)
                {
                    if (alumnList[i].AlumnGradesAverage() < 5)
                    {
                        gradesLowerThan5 += alumnList[i].ShowsAlumnData() + "\n";
                    }
                }
            }
            return gradesLowerThan5;
        }

        //FUNCTION WHICH RETURNS ALL ALUMNS WHO ARE IN THE SELECTED COURSE
        public string ShowAlumnsByCourseCod(int courseCod)
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

        //FUNCTION THAT ORDERS ALUMNS IN ALPHABETICAL ORDER
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

        // FUNCTION WHICH RETURNS THE COURSE ID OF THE SELECTED ALUMN
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

        // FUNCTION WHICH RETURNS THE COUNT OF THE NUMBER OF ALUMNS IN THE LIST
        public int CountsTotalAlumns()
        {
            return alumnList.Count;
        }
    }
}
