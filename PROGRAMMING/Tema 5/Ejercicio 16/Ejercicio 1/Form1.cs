using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Ejercicio_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        int[] num = new int[3];
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
                }
            }
        }

        string mostrarVector (int[] vector)
        {
            string txt = "Los valores del vector son: \n";

            for(int i = 0; i < vector.Length; i++)
            {
            
                if (i == (vector.Length - 1))
                {
                    txt += vector[i] + ".";
                }
                else
                {
                    txt += vector[i] + ", ";
                }
            }
            return txt;
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            ReadNotRepeated(num);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {

            MessageBox.Show(mostrarVector(num));

        }
    }
}
