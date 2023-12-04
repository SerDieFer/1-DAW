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

        int[] vector = new int[10];

        void LeerVector(int[] vector)
        {
            for(int i = 0; i < vector.Length; i++)
            {
                vector[i] = int.Parse(Interaction.InputBox("Introduce el valor [" + i + "]:"));
            }
        }

        int MostrarMenor (int[] vector)
        {

            int menor = vector[0];

            for(int i = 1; i < vector.Length;i++)
            {

                if (vector[i] < menor)
                {
                    menor = vector[i];

                }
            }

            return menor;
        }

        string MostrarVector(int[] vector)
        {
            string txt = "Los valores del vector son: ";
            
            for(int i = 0; i < vector.Length; i++)
            {
                if (i == 9)
                {
                    txt += vector[i] + ". ";
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
            LeerVector(vector);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string txtVector = MostrarMenor(vector).ToString();
            MessageBox.Show(txtVector);
        }
    }
}
