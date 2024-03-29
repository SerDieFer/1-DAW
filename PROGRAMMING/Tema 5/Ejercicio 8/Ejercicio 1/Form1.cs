﻿using System;
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

        int[] vector1 = new int[4];
        void LeerVector(int[] vector)
        {
            // Forma 1

            int i = 0;
            int num;

            while( i < vector.Length)
            {
                num = int.Parse(Interaction.InputBox("Introduce el valor [" + i + "] del vector:"));

                if(num <= 0)
                {
                    MessageBox.Show("Tiene que ser positivo");
                }

                else
                {
                    vector[i] = num;
                    i++;
                }
            }


            /* Forma 2 

            int i = 0;

            while (i < vector.Length)
            {
                vector[i] = int.Parse(Interaction.InputBox("Introduce el valor [" + i + "] del vector:"));

                if (vector[i] <= 0)
                {
                    MessageBox.Show("Tiene que ser positivo");
                }

                else
                {
                    i++;
                }
            } 

            */

        }

        // Debes de hacerlo aparte o es muy lioso, con este función lo que conseguimos es comparar las posiciones
        // ya declaradas del vector a leer, y lo que hace es comparar la posicion 1 con la siguiente, y en caso
        // de que sean iguales, cambia el número de la posición siguiente.

        // TODO Probar más formas de lograrlo.
        int RecalcularPosicion(int[] vector)
        {
            int modificado = 0;

            // Realiza iteraciones sobre el vector recorriendo su totalidad
            for (int i = 0; i < vector.Length; i++)
            {
                // Verifica si la posición actual no ha sido marcada como duplicada (-1 en este caso)
                if (vector[i] != -1)
                {
                    // Realiza iteraciones sobre las posiciones siguientes (respecto a la i) para buscar duplicados
                    for (int j = i + 1; j < vector.Length; j++)
                    {
                        // Si se encuentra un duplicado, marcar la posición duplicada como -1
                        if (vector[j] == vector[i])
                        {
                            vector[j] = -1;
                            modificado++;
                        }
                    }
                }
            }
            return modificado;
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

 
            string numModificados = "\n\nEl número de modificados es: " + RecalcularPosicion(vector1); 
            string txtRes;
            txtRes = MostrarVector(vector1) + numModificados;
            MessageBox.Show(txtRes);
        
        }
    }
}
