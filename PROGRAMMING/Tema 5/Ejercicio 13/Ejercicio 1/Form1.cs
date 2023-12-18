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

        int[] numeros = new int[10];
        void LeerVector(int[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = int.Parse(Interaction.InputBox("Introduce el valor de la posición [" + i + "] en el vector:"));
            }
        }

        bool Comprobar(int[] vector)
        {

            bool estaDentro = false;
            int numComparar = int.Parse(Interaction.InputBox("Introduce el número a comprobar en el vector"));
           
            for(int i = 0; i < vector.Length && !estaDentro;i++)
            {
                if(numComparar == vector[i])
                {
                    estaDentro = true;
                }
            }

            return estaDentro;
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
            LeerVector(numeros);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {

            string txtRes;
            txtRes = MostrarVector(numeros);
            MessageBox.Show(txtRes);

            if (Comprobar(numeros))
            {
                MessageBox.Show("El número está dentro del vector");
            }

            else
            {
                MessageBox.Show("El número NO está dentro del vector");
            }
        }
    }
}
