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

        int[] vector1 = new int[8];
        void LeerVector(int[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = int.Parse(Interaction.InputBox("Introduce el valor [" + i + "] del vector:"));
            }
        }


        // Debes de hacerlo aparte o es muy lioso, con este función lo que conseguimos es comparar las posiciones
        // ya declaradas del vector a leer, y lo que hace es comparar la posicion 1 con la siguiente, y en caso
        // de que sean iguales, cambia el número de la posición siguiente.

        // TODO Probar más formas de lograrlo.
        void RecalcularPosicion(int[] vector)
        {

            for (int i = 0; i < vector.Length; i++)
            {
                for (int j = i + 1; j < vector.Length; j++)
                {

                    // No termino de entender como sustituye el vector mostrado.

                    if (vector[j] == vector[i])
                    {
                        vector[j] = -1;
                    }
                }
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
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {

            string txtRes;
            RecalcularPosicion(vector1);
            txtRes = MostrarVector(vector1);
            MessageBox.Show(txtRes);
        
        }
    }
}
