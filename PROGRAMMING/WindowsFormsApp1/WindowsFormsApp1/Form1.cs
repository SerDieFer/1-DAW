using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Logging;
using WindowsFormsApp1.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double ElevateNum(double m, double n)
        {
            double res = 1;
            for (int i = 1; i <= n; i++)
            {
                res *= m;
            }
            return res;
        }
        private double FactorialNum(double n)
        {
            double res = 1;
            for (int i = 1; i <= n; i++)
            {
                res *= i;
            }
            return res;
        }

        private double CalculateSerie(double m, double n)
        {
            double res = 0;
            for (int i = 1; i <= n; i++)
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
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Interaction.InputBox("Introduce the number into position Nº" + i));
            }
        }

        private string ShowArray1(int[] array)
        {
            string txt = "";
            int counter = 0;

            foreach (int i in array)
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

        private string ShowArray2(string[] array)
        {
            string txt = "";
            int counter = 0;

            foreach (var i in array)
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

        //Repasar
        private void AddOnlyIfBigger(int[] array)
        {
            int numToIntroduce;
            int i = 1;
            array[0] = int.Parse(Interaction.InputBox("Introduce the value in the position Nº0:"));
            while (i < array.Length)
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
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != -1)
                {
                    for (int j = i + 1; j < array.Length; j++)
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
            for (int i = 1; i < array.Length; i++)
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

        /*
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
            //AddTest();
            //MoveOnlyCompositedThatAreNotInSecondList(listN1, listN2);
            //MessageBox.Show(ShowList(listN3, nameof(listN3)));
        }
        */

        //* EXAMEN N1
        string[] wordsArray = new string[3];
        string[] repeatedWordsArray = { "ana", "juan", "juan", "marta", "marta", "marta", "paloma" };

        private bool ValidateWordRepeated2Times(string word, string[] repeatedWordsArray)
        {
            bool isValid = false;
            int counter = 0;
            foreach (string element in repeatedWordsArray)
            {
                if (element == word)
                {
                    counter++;
                    if (counter == 2)
                    {
                        isValid = true;
                    }
                }
            }
            return isValid;
        }

        private void ReadArrayRepeated(string[] wordsArray, string[] repeatedWordsArray)
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
        //FIN EXAMEN N1 */

        //* EXAMEN N2
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
       
        private void GreaterOrLowerThanAvg(ref double[] array, out double numGreater, out double numLower)
        {
            numGreater = numLower = 0;
            double avg = AvgArray(array);
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= avg)
                {
                    numGreater++;
                }
                else
                {
                    numLower++;
                }
            }
        }

        private bool AllSmall(double[] array)
        {
            bool allSmall = true;
            for (int i = 0; i < array.Length && allSmall; i++)
            {
                if (array[i] > 1.7)
                {
                    allSmall = false;
                }
            }
            return allSmall;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] array3 = { 1.72, 2, 1.57, 1.65, 1.78, 1.9 };
            double numGreater;
            double numLower;

            GreaterOrLowerThanAvg(ref array3, out numGreater, out numLower);
            string txtResults = "";
            string txtBiggerEqualThanAverage = "So the biggest or equals to the average will be: " + numGreater;
            string txtLowerThanAvergage = "So the smaller than the average will be: " + numLower;
            txtResults = "The media in this class will be: " + AvgArray(array3) + "\n\n" + txtBiggerEqualThanAverage +
               "\n\n" + txtLowerThanAvergage + "\n\nAre all classroom mates smaller than 1.7? " + 
               AllSmall(array3);
            MessageBox.Show(txtResults);
        }
        //FIN EXAMEN N2 */

        //* EXAMEN N3
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

       bool isBigger(int previousNum, int actualNum)
       {
           bool bigger = false;
           if (previousNum < actualNum)
           {
               bigger = true;
           }
           return bigger;
       }

       List<int> list1 = new List<int>();
       void ReadNotRepeatedAndGreater(List<int> list)
       {
           int i = 1;
           DialogResult more;
           int num = int.Parse(Interaction.InputBox("Enter the num you want to add", "Add Num"));
           list.Add(num);
           more = MessageBox.Show("Do you want to keep adding more nums?", "Add Num", MessageBoxButtons.YesNo);
           while (more == DialogResult.Yes)
           {
               num = int.Parse(Interaction.InputBox("Enter the num you want to add", "Add Num"));
               bool contained = list.Contains(num);
               if (!contained && isBigger(list[i - 1], num))
               {
                   list.Add(num);
                   //list.Sort();
                   i++;
                   MessageBox.Show("The num (" + num + ") has been added to the list");
               }
               else if (contained)
               {
                   MessageBox.Show("Inserted numbers can't be repeated");
               }
               else
               {
                   MessageBox.Show("Only values bigger than the previous used, try again");
               }
               more = MessageBox.Show("Do you want to keep adding more nums?", "Add Num", MessageBoxButtons.YesNo);
           }
       }

       //FIN EXAMEN N3 */

        //* EXAMEN N4
        List<int> listN1 = new List<int>();
        List<int> listN2 = new List<int>();
        List<int> listN3 = new List<int>();
        private void AddTest()
        {
            listN1.Add(1);
            listN1.Add(2);
            listN1.Add(6);
            listN1.Add(7);
            listN1.Add(28);
            listN1.Add(30);

            listN2.Add(2);
            listN2.Add(3);
            listN2.Add(5);
            listN2.Add(28);
        }

        private bool CompositeNumber(int num)
        {
            bool composited = false;
            int compositedCounter = 0;

            for(int i = 2; i <= num && !composited; i++)
            { 
                if(num % i == 0)
                {
                    compositedCounter++;
                    if(compositedCounter > 2)
                    {
                        composited = true;
                    }
                }
            }
            return composited;
        }

        private void MoveOnlyCompositedThatAreNotInSecondList(List<int> list1, List<int> list2)
        {
            int i = 0;
            while (i < list1.Count)
            {
                bool composited = CompositeNumber(list1[i]);
                if (composited && !list2.Contains(list1[i]))
                {
                    listN3.Add(list1[i]);
                    listN1.Remove(list1[i]);
                }
            }
        }
        //FIN EXAMEN N4 */

        // EXAMEN OTRA CLASE N2
        // Tienes dos listas, si en la lista2 se repite esa palabra más de dos veces la eliminas de la lista1.

        List<string> lista1 = new List<string>();
        List<string> lista2 = new List<string>();

        private void PruebaAñadidas()
        { 
            lista1.Add("carmen");
            lista1.Add("manuel");
            lista1.Add("pepe");
            lista1.Add("pepe");
            lista1.Add("pepe");
            lista1.Add("pepe");
            lista1.Add("pepe");



            lista2.Add("pepe");
            lista2.Add("pepe");
            lista2.Add("pepe");
        }

        private string MostrarLista (List<string> lista)
        {
            string texto = "";

            foreach(string elemento in lista)
            {
                texto += elemento + ", ";
            }
            return texto;
        }

        private int PalabraRepetidaMasDe2Veces(string palabra, List<string> lista2)
        {
            int contador = 0;
            foreach (string elemento in lista2)
            {
                if (elemento == palabra)
                {
                    contador++;
                }
            }
            return contador;
        }

        private void BorrarRepetidas(List<string> lista1, List<string> lista2)
        {
            int i, j;
            i = j = 0;
            while(i < lista1.Count && j < lista2.Count) 
            {
                if (PalabraRepetidaMasDe2Veces(lista1[i], lista2) > 2)
                {
                    lista1.Remove(lista1[i]);
                }
                else
                {
                    i++;
                }
            }

        }
        private void button1b_Click(object sender, EventArgs e)
        {
            PruebaAñadidas();
            BorrarRepetidas(lista1, lista2);
            MessageBox.Show(MostrarLista(lista1));
        }
        //*/

        //* EXAMEN OTRA CLASE N3
        // Tienes una lista de números que tienes que rellenar tú con la condición de que cada número que introduzcas
        // no puede ser menor que la suma de los dos anteriores, el primero lo metes tal cual, el segundo tiene que ser
        // mayor al primero que has metido y ya todos tienen que ser mayor que la suma de los dos números anteriores.

        List<int> listaNums = new List<int>();

        int SumarNumeros(List<int> lista, int i)
        {
            int suma = 0;

            if (lista.Count == 1)
            {
                suma = lista[i];
            }
            else if (lista.Count > 1)
            {
                suma = lista[i - 1] + lista[i];
            }
            return suma;
        }

        void AñadirALista(List<int> lista) 
        {
            int i = 0;
            int num = int.Parse(Interaction.InputBox("Añade el número:"));
            lista.Add(num);
            MessageBox.Show("El número introducido es el:" + num);
            while (i < lista.Count)
            {
                num = int.Parse(Interaction.InputBox("Añade el número:"));
                if (num > SumarNumeros(lista, i))
                {
                    lista.Add(num);
                    i++;
                    MessageBox.Show("El número introducido es el:" + num);
                }
                else
                {
                    MessageBox.Show("El número introducido es menor que la suma de sus anteriores");
                }
            }

        }
        void button1c_Click(object sender, EventArgs e)
        {
            AñadirALista(listaNums);
        }
        //*/

        //* EXAMEN OTRA CLASE N4
        // Te dan una array que tiene edades, las empiezas a leer, tienes que hacer el botón, y luego tienes que hacer dos
        // funciones, la edad mínima y la edad máxima, y luego otra función que te devuelva si hay un menor de edad o no.

        private void LeerEdades(int[] vector) 
        {
            for(int i = 0; i < vector.Length; i++)
            {
                int edad = int.Parse(Interaction.InputBox("Añade la edad: "));
                vector[i] = edad;
            }
        }

        private void EdadMinMax(ref int[] vector, out int minima, out int maxima)
        {
            maxima = minima = vector[0];
            for(int i = 0; i < vector.Length; i++)
            {
                if (vector[i] <= minima)
                {
                    minima = vector[i];
                }
                if (vector[i] >= maxima)
                {
                    maxima = vector[i];
                }
            }
        }

        private bool TodosMayores18(int[] vector)
        {
            bool mayores = true;

            for (int i = 0; i < vector.Length; i++)
            {
                if (vector[i] < 18)
                {
                    mayores = false;
                }
            }
            return mayores;
        }

        private void button1d_Click(object sender, EventArgs e)
        {
            int[] edades = new int[5];
            LeerEdades(edades);

            int minima, maxima;
            EdadMinMax(ref edades, out minima, out maxima);

            string resultado = "La edad máxima sería: " + maxima + "\nLa edad mínima sería: " + minima;

            if (TodosMayores18(edades))
            {
                MessageBox.Show(resultado + "\nSiendo todos mayores de edad");
            }
            else
            {
                MessageBox.Show(resultado + "\nHabiendo entre ellos menores de edad");
            }
        }
        //*/

    }
}
