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

        int[] vector1 = new int[5];

        // FORMA CORRECTA CON WHILE
        void LeerVector(int[] vector)
        {

            int i = 1;
            vector[0] = int.Parse(Interaction.InputBox("Introduce el valor [" + (i-1) + "] del vector:"));

            while (i < vector.Length)
            {
                vector[i] = int.Parse(Interaction.InputBox("Introduce el valor [" + i + "] del vector:"));

                if ((i > 0) && !(vector[i] < vector[i-1]))
                {
                    
                    i++;
                }

                else
                {
                    MessageBox.Show("Introduce un número mayor al vector anterior");
                }
            }
        }

        /* FORMA QUE ACABA SI EL NÚMERO NUEVO ES MENOR AL ANTERIOR
        
        void LeerVector(int[] vector)
        {
            bool incorrecto = false;
            
            for (int i = 0; (i < vector.Length) && (!incorrecto); i++)
            {
                vector[i] = int.Parse(Interaction.InputBox("Introduce el valor [" + i + "] del vector:"));

                if ((i > 0) && (vector[i] < vector[i - 1]))
                {
                    incorrecto = true;
                    MessageBox.Show("Introduce un número mayor al vector anterior");
                }
            }
        }

        */

        /* FORMA QUE RELLENE CARÁCTERES RESTANTES AL CERRAR BUCLE
        
        void LeerVector(int[] vector)
        {
            bool incorrecto = false;
            string numVacio;

            for (int i = 0; (i < vector.Length) && (!incorrecto); i++)
            {
                numVacio = Interaction.InputBox("Introduce el valor [" + i + "] del vector:");

                if (numVacio == "")
                {
                    numVacio = "0";
                }

                vector[i] = int.Parse(numVacio);

                if ((i > 0) && (vector[i] < vector[i - 1]))
                {
                    incorrecto = true;
                    MessageBox.Show("Introduce un número mayor al vector anterior");
                }
            }
        }

        */

        string MostrarVector(int[] vector)
        {
            string txt = "Los valores del vector son: ";

            for(int i = 0; i < vector.Length; i++)
            {
            
                if (i == (vector.Length- 1))
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
            txtRes = MostrarVector(vector1);
            MessageBox.Show(txtRes);
        
        }
    }
}
