using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using WindowsFormsApp1.Properties;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double ElevateNum (double m, double n)
        {
            double res = 1;
            for(int i = 1; i <= n; i++) 
            {
                res *= m;
            }
            return res;
        }
        private double FactorialNum (double n)
        {
            double res = 1;
            for(int i = 1; i <= n; i++)
            {
                res *= i;
            }
            return res;
        }

        private double CalculateSerie(double m, double n)
        {
            double res = 0;
            for(int i = 1; i <= n;i++)
            {
                res += ElevateNum(m, i) / FactorialNum(i); ;
            }
            return res;
        }

        private string InterchangeValues(double m, double n)
        {
            double n1a, n2a, n1b, n2b;
            n1a = m;
            n2a = n;
            n1b = n2a;
            n2b = n1a;

            string res = "El número " + n1a + " ahora será " + n1b + "\n\nMientras que el " + n2a + " daría " + n2b;
            return res;
        }

        //Repasar
        private double MaxCommonDivisor(double m, double n)
        {
            double res = 0;
            bool found = false;

            if (m > n)
            {
                for (double i = m; !found; i--)
                {
                    if (m % i == 0 && n % i == 0)
                    {
                        res = i;
                        found = true;
                    }
                }
            }
            else
            {
                for (double i = n; !found; i--)
                {
                    if (m % i == 0 && n % i == 0)
                    {
                        res = i;
                        found = true;
                    }
                }
            }
            return res;
        }

        //Repasar
        private double MinCommonMultiple(double m, double n)
        {
            double res = 0;
            bool found = false;

            for (double i = 1; !found; i++)
            {
                if ((m * i) % n == 0)
                {
                    res = m * i;
                    found = true;
                }
            }
            return res;
        }

        int[] array2 = new int[3];

        private void ReadArray(int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Interaction.InputBox("Introduce the number into position Nº" + i));
            }
        }

        private string ShowArray1(int[] array)
        {
            string txt = "";
            int counter = 0;

            foreach(int i in array)
            {
                if(counter == array.Length-1)
                {
                    txt += i + ".";
                }
                else
                {
                    txt += i + ", ";
                }
                counter++;
            }
            return txt;
        }

        private string ShowArray2(string[] array)
        {
            string txt = "";
            int counter = 0;

            foreach(var i in array)
            {
                if (counter == array.Length - 1)
                {
                    txt += i + ".";
                }
                else
                {
                    txt += i + ", ";
                }
                counter++;
            }
            return txt;
        }

        // EXAMEN N2
        private double AvgArray(double[] array)
        {
            double avg = 0;

            foreach (double i in array)
            {
                avg += i;
            }
            avg /= array.Length;
            return avg;
        }
        double[] array3 = { 1.72, 2, 1.57, 1.65, 1.78, 1.9 };
        private string GreaterOrLowerThanAvg(double[] array)
        {
            string txtBiggerEqualThanAverage = "So the biggest or equals to the average will be: ";
            string txtLowerThanAvergage = "So the smaller than the average will be: ";
            string txtResults = "";
            double avg = AvgArray(array);
            for (int i = 0; i < array.Length;i++)
            {
                if (array[i] >= avg)
                {
                    txtBiggerEqualThanAverage += array[i] + ", ";
                }
                else
                {
                    txtLowerThanAvergage += array[i] + ", ";
                }
            }
            txtResults = "The media in this class will be: " + avg + "\n\n" +txtBiggerEqualThanAverage + 
                "\n\n" + txtLowerThanAvergage + "\n\nAre all classroom mates smaller than 1.7? " + SmallClassroomStature(array);
            return txtResults;
        }

        private bool SmallClassroomStature(double[] array)
        {
            bool smallClassStature = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 1.7)
                {
                    smallClassStature = true;
                }
                else
                {
                    smallClassStature = false;
                }
            }
            return smallClassStature;
        }
        // FIN EXAMEN N2

        //Repasar
        private void AddOnlyIfBigger (int[] array)
        {
            int numToIntroduce;
            int i = 1;
            array[0] = int.Parse(Interaction.InputBox("Introduce the value in the position Nº0:"));
            while(i<array.Length)
            {
                numToIntroduce = int.Parse(Interaction.InputBox("Introduce the value in the position Nº" + i + ":"));
                if (array[i - 1] < numToIntroduce)
                {
                    array[i] = numToIntroduce;
                    i++;
                }
            }
        }

        // Repasar
        private int RecalculatePosition(int[] array)
        {
            int modified = 0;
            for(int i = 0 ;i < array.Length; i++)
            {
                if (array[i] != -1)
                {
                    for(int j = i + 1; j < array.Length; j++)
                    {
                        if (array[j] == array[i])
                        {
                            array[j] = -1;
                            modified++;
                        }
                    }
                }
            }
            return modified;
        }

        void InvertPosition1(int[] array)
        {
            // Actua sobre la mitad del array
            for (int i = 0; i < array.Length / 2; i++)
            {
                // Guarda temporalmente el valor actual del array en la posición 'i'
                int temporal = array[i];

                // Intercambia el valor actual en la posición 'i' con su equivalente desde el endPosition
                array[i] = array[array.Length - i - 1];

                // Restaura el valor original en la posición desde el endPosition
                array[array.Length - i - 1] = temporal;
            }
        }

        // Forma2
        void InvertPosition2(int[] array)
        {
            // Definir los índices de startPosition y endPosition del array
            int startPosition = 0;
            int endPosition = array.Length - 1;

            // Mientras el índice de startPosition sea menor que el índice de endPosition
            while (startPosition < endPosition)
            {
                // Intercambiar los elementos desde el principio con sus equivalentes desde el endPosition
                int temporal = array[startPosition];
                array[startPosition] = array[endPosition];
                array[endPosition] = temporal;

                // Mover los índices hacia el centro del array para que sus posiciones sean intercambiadas.
                startPosition++;
                endPosition--;
            }

        }

        private string MaxMinAverage(int[] array)
        {
            int min, max, avg;
            avg = min = max = array[0];
            for(int i = 1; i < array.Length;i++)
            {
                if (array[i] <= min)
                {
                    min = array[i];
                    avg += array[i];
                }
                else if (array[i] >= max)
                {
                    max = array[i];
                    avg += array[i];
                }
            }
            avg /= array.Length;
            string txt = "Max temperature: " + max + "\nMin Temperature: " + min + "\nAverage Temperature: " + avg;
            return txt;
        }

        // Repasar
        void MoveToRight(int[] array)
        {

            int lastP = array[array.Length - 1];

            for (int i = array.Length - 1; i >= 1; i--)
            {
                array[i] = array[i - 1];
            }
            array[0] = lastP;

        }

        // Repasar
        void OrderArrayFromSmallestToBiggerValue(int[] array) 
        {
            int auxNum;

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[i])
                    {
                        auxNum = array[i];
                        array[i] = array[j];
                        array[j] = auxNum;
                    }
                }
            }
        }

        // Repasar
        void OrderArrayFromBiggerToSmallestValue(int[] array)
        {
            int auxNum;

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] > array[i])
                    {
                        auxNum = array[i];
                        array[i] = array[j];
                        array[j] = auxNum;
                    }
                }
            }
        }

        // EXAMEN N3
        private string ShowList(List<int> list, string listName)
        {
            string txtList = "The nums in the " + listName + " are: ";
            if (list.Count > 0)
            {
                int elementsCounted = 0;
                foreach (int nums in list)
                {
                    txtList += "(" + nums + ")";
                    if (elementsCounted < list.Count - 1)
                    {
                        txtList += ", ";
                    }
                    elementsCounted++;
                }
                txtList += ".";
            }
            else
            {
                txtList += "(No nums in the list).";
            }
            return txtList;
        }


        List<int> list1 = new List<int>();    
        void ReadNotRepeatedAndGreater(List<int> list)
        {
            int num;
            DialogResult more;
            list.Insert(0, int.Parse(Interaction.InputBox("Enter the num you want to add", "Add Num")));

            do
            {
                bool repeated = false;
                num = int.Parse(Interaction.InputBox("Enter the num you want to add", "Add Num"));

                for (int i = 1; i < list.Count && !repeated; i++)
                {
                    if (!list.Contains(num) && num > list[i-1])
                    {
                        list.Insert(i, num);
                        MessageBox.Show("The num (" + num + ") has been added to the list");
                        repeated = true;
                    }
                }

                if (!repeated)
                {
                    MessageBox.Show("The word (" + num + ") can't be added to the list because it's repeated");
                }

                more = MessageBox.Show("Do you want to keep adding more nums?", "Add Num", MessageBoxButtons.YesNo);
            } while (more == DialogResult.Yes);
        }
  
        // FIN EXAMEN N3

        // Repasar
        int searchArrayPosition(int[] array, int numToSearch)
        {
            bool found = false;
            int position;
            int i = 0;

            while (i < array.Length && !found)
            {
                if (numToSearch == array[i])
                {
                    found = true;
                }
                else
                {
                    i++;
                }
            }

            if (found)
            {
                position = i;
            }

            else
            {
                position = -1;
            }

            return position;
        }

        // EXAMEN N1
        string[] wordsArray = new string[3];
        string[] repeatedWordsArray = { "ana", "juan", "juan", "marta", "marta", "marta", "paloma" };

        private bool ValidateWordRepeated2Times(string word, string[] repeatedWordsArray)
        {
            bool isValid = false;
            int counter = 0;
            foreach(string element in repeatedWordsArray)
            {
                if(element == word)
                {
                    counter++;
                    if(counter == 2)
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                    }
                }
            }
            return isValid;
        }

        private void ReadArrayRepeated (string[] wordsArray, string[] repeatedWordsArray)
        {
            bool repeated = false;
            int i = 0;

            do
            {
                string wordToValidate = Interaction.InputBox("Introduce the word to add: ");
                if (ValidateWordRepeated2Times(wordToValidate, repeatedWordsArray))
                {
                    wordsArray[i] = wordToValidate;
                    i++;
                }
                else
                {
                    MessageBox.Show("Error");
                }
            } while (i < wordsArray.Length && !repeated);

        }
        // FIN EXAMEN N1
        private void button1_Click(object sender, EventArgs e)
        {
            //double m, n;
            //string res;


            //m = int.Parse(Interaction.InputBox("Introduce él número inicial"));
            //n = int.Parse(Interaction.InputBox("Introduce él número secundario"));

            //res = InterchangeValues(m, n);
            //res = "El número " + m + " ahora será " + n + "\n\nMientras que el " + n + " daría " + aux;

            //res = CalculateSerie(m, n).ToString();

            //res = MaxCommonDivisor(m, n).ToString();
            ReadNotRepeatedAndGreater(list1);
            MessageBox.Show(ShowList(list1, nameof(list1)));

        }

    }
}
