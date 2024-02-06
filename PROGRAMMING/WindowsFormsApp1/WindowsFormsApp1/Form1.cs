using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;


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


        int[] array1 = new int[3];
        int[] array2 = new int[3];
        private void ReadArray(int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Interaction.InputBox("Introduce the number into position Nº" + i));
            }
        }

        private string ShowArray(int[] array)
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

        private double MediaArray(int[] array)
        {
            double media = 0;

            foreach (int i in array)
            {
                media += i;
            }
            media /= array.Length;
            return media;
        }

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
        private void RecalculatePosition(int[] array)
        {
            int modified = 0;
            for(int i = 0;i < array.Length;i++)
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
        
        //Repasar
        void ReadNotRepeated(int[] array)
        {
            int numToIntroduce;
            int i = 1;
            array[0] = int.Parse(Interaction.InputBox("Enter the value at position Nº0:"));
            while (i < array.Length)
            {
                numToIntroduce = int.Parse(Interaction.InputBox("Enter the value at position Nº" + i + ":"));

                bool repeated = false;
                for (int j = 0; j < i && !repeated; j++)
                {
                    if (array[j] == numToIntroduce)
                    {
                        repeated = true;
                    }
                }

                if (!repeated)
                {
                    array[i] = numToIntroduce;
                    i++;
                    repeated = false;
                }
            }
        }

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
        ReadNotRepeated(array1);
        

        MessageBox.Show(ShowArray(array1));

        }

    }
}
