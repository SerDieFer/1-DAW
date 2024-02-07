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
      
        int[] serie = new int[3];
        void leerVector(int[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = int.Parse(Interaction.InputBox("Introduce el número de la posición [" + i + "]:"));
            }
        }

        private void btnIntroducirVector_Click(object sender, EventArgs e)
        {
            leerVector(serie);
        }

        int buscarVector(int[] vector, int numBusqueda)
        {
            bool encontrado = false;
            int posicion;
            int buscado = numBusqueda;
            int i = 0;
           
            while(i < vector.Length && !encontrado)
            {
                if (buscado == vector[i])
                {
                    encontrado = true;
                }
                else
                {
                    i++;
                }
            }

            if (encontrado)
            {
                posicion = i;
            }

            else
            {
                posicion = -1;
            }

            return posicion;
        }


        private void btnBuscarVector_Click(object sender, EventArgs e)
        {
            int numBusqueda = int.Parse(Interaction.InputBox("Introduce el número a buscar:"));
            int numEncontrado = buscarVector(serie, numBusqueda);

            if (numEncontrado == -1)
            {
                MessageBox.Show("El número " + numBusqueda + " no está en el vector");
            }
                
            else
            {                                                         
                MessageBox.Show("El número " + numBusqueda + " tiene la posición " 
                    + ((numEncontrado+1).ToString())); // Esto para que lo entienda un NO programador
            }
        }

        void ordenarVector(int[] vector)
        {
            int numSustituto;

            for (int i = 0; i < (vector.Length - 1); i++)
            {
                for (int j = i + 1; j < vector.Length; j++)
                {
                    if (vector[j] > vector[i])
                    {
                        numSustituto = vector[i];
                        vector[i] = vector[j];
                        vector[j] = numSustituto;
                    }
                }
            }
        }

        private void btnOrdenarVector_Click(object sender, EventArgs e)
        {
            ordenarVector(serie);
        }

        string mostrarVector(int[] vector)
        {
            string txt = "Los valores del vector son: \n";

            for (int i = 0; i < vector.Length; i++)
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

            private void btnMostrarVector_Click(object sender, EventArgs e)
            {
     
                string txtMostrar = "";
                txtMostrar = mostrarVector(serie);

                MessageBox.Show(txtMostrar);

            }
    }
}
