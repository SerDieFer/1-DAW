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

namespace Ejercicio_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] vector1 = new int[10];
        void LeerVector(int[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = int.Parse(Interaction.InputBox("Introduce el valor [" + i + "] del vector:"));
            }
        }
        // Forma 1
        void InvertirPosicion1(int[] vector)
        {
            // Actua sobre la mitad del array
            for (int i = 0; i < vector.Length / 2; i++)
            {
                // Guarda temporalmente el valor actual del array en la posición 'i'
                int temporal = vector[i];

                // Intercambia el valor actual en la posición 'i' con su equivalente desde el final
                vector[i] = vector[vector.Length - i - 1];

                // Restaura el valor original en la posición desde el final
                vector[vector.Length - i - 1] = temporal;
            }
        }

        // Forma2
        void InvertirPosicion2(int[] vector)
        {
            // Definir los índices de inicio y final del vector
            int inicio = 0;
            int final = vector.Length - 1;

            // Mientras el índice de inicio sea menor que el índice de final
            while (inicio < final)
            {
                // Intercambiar los elementos desde el principio con sus equivalentes desde el final
                int temporal = vector[inicio];
                vector[inicio] = vector[final];
                vector[final] = temporal;

                // Mover los índices hacia el centro del array para que sus posiciones sean intercambiadas.
                inicio++;
                final--;
            }

        }

        string MostrarVector(int[] vector)
        {
            string txt = "Los valores del vector son: ";

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
            LeerVector(vector1);
            InvertirPosicion2(vector1);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            

            string txtRes;
            txtRes = MostrarVector(vector1);
            MessageBox.Show(txtRes);
        
        }
    }
}
