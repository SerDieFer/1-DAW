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
        int[] vectorSuma = new int[3];

        void LeerVectores(int[] vector1, int[] vector2)
        {
            for(int i = 0; i < (vector1.Length) && (i < vector2.Length); i++)
            {
                vector1[i] = int.Parse(Interaction.InputBox("Introduce el valor [" + i + "] del vector 1:"));
                vector2[i] = int.Parse(Interaction.InputBox("Introduce el valor [" + i + "] del vector 2:"));
            }
        }

        void SumaVectores(int[] vector1, int[] vector2)
        {

            for (int i = 0; i < vector1.Length; i++)
            {
                vectorSuma[i] = vector1[i] + vector2[i];

            }
        }

        string MostrarSuma(int[] vectorSuma)
        {
            string txt = "Los valores de los vectores son: ";
            

            for (int i = 0; i < vectorSuma.Length; i++)
            {
                if (i == 2)
                {
                    txt += vectorSuma[i] + ". ";
                }
                else
                {
                    txt += vectorSuma[i] + ", ";
                }
            }
            return txt;
        }


        private void btnLeer_Click(object sender, EventArgs e)
        {

            LeerVectores(vector1, vector2);
            SumaVectores(vector1, vector2);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string txtVector = MostrarSuma(vectorSuma).ToString();
            MessageBox.Show(txtVector);
        }
    }
}
