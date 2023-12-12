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

        int[] vector1 = new int[3];
        int[] vector2 = new int[3];

        void LeerVector(int[] vector)
        {
            for(int i = 0; i < (vector.Length); i++)
            {
                vector[i] = int.Parse(Interaction.InputBox("Introduce el valor [" + i + "] del vector:"));
            }
        }

        // No hacer strings en funciones, melonsio
        bool ComprobarIgualdad(int[] vector1, int[] vector2)
        {
            bool esIgual = true;

            for (int i = 0; (i < vector1.Length && i < vector2.Length) && esIgual; i++)
            {
                // TIENEN QUE SER DISTINTO PARA PARAR EL BUCLE
                if (vector1[i] != vector2[i])
                {
                    esIgual = false;
                }
            }
            return esIgual;
        }


        private void btnLeer_Click(object sender, EventArgs e)
        {

            LeerVector(vector1);
            LeerVector(vector2);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            bool vectoresIguales = ComprobarIgualdad(vector1, vector2);

            if (vectoresIguales)
            {
                MessageBox.Show("Los vectores son iguales");
            }

            else
            {
                MessageBox.Show("Los vectores no son iguales");
            }
        }
    }
}
