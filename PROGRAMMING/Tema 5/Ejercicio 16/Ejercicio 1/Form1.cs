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
        void leerVector (int[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = int.Parse(Interaction.InputBox("Introduce el número de la posición [" + i + "]:"));
            }
        }

        void obtenerNumMayorMenor(int[] vector, out int nMayor, out int nMenor)
        {
            nMayor = nMenor = vector[0];

            for (int i = 1; i < vector.Length; i++)
            {
                if (vector[i] > nMayor)
                {
                    nMayor = vector[i];
                }

                if (vector[i] < nMenor)
                {
                    nMenor = vector[i];
                }
            }
        }
        int contarRepetidos(int[] vector, int numComprobar)
        {
            int repetido = 0;

            for(int i = 0; i < vector.Length;i++)
            {
                if (vector[i] == numComprobar)
                {
                    repetido++;
                }
            }
            repetido--;
            return repetido;
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
            leerVector(num);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            int nMayor, nMenor, repetidoMayor, repetidoMenor;
            obtenerNumMayorMenor(num, out nMayor, out nMenor);

            repetidoMayor = contarRepetidos(num, nMayor);
            repetidoMenor = contarRepetidos(num, nMenor);

            string txtMostrar, txtRes = "";
            txtMostrar = mostrarVector(num);

            if (repetidoMayor > 0 && repetidoMenor > 0)
            {
                txtRes = "\n\nEl número mayor será: " + nMayor +
                         "\nSe repite " + repetidoMayor + " veces" +
                         "\n\nEl número menor será: " + nMenor +
                         "\nSe repite " + repetidoMenor + " veces";
            }

            else if (repetidoMayor == 0 && repetidoMenor > 0)
            {
                txtRes = "\n\nEl número mayor será: " + nMayor + " y no se repite"+
                         "\n\nEl número menor será: " + nMenor +
                         "\nSe repite " + repetidoMenor + " veces";
            }

            else if (repetidoMayor > 0 && repetidoMenor == 0)
            {
                txtRes = "\n\nEl número mayor será: " + nMayor +
                         "\nSe repite " + repetidoMayor + " veces" +
                         "\n\nEl número menor será: " + nMenor + " y no se repite";       
            }

            else
            {
                txtRes = "\n\nEl número mayor será: " + nMayor + " y no se repite" +
                         "\n\nEl número menor será: " + nMenor + " y no se repite";
            }

            MessageBox.Show(txtMostrar + txtRes);

        }
    }
}
