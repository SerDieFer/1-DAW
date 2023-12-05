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
        int[] vector2 = new int[10];

        void LeerVector(int[] vector)
        {
            for(int i = 0; i < (vector.Length); i++)
            {
                vector[i] = int.Parse(Interaction.InputBox("Introduce el valor [" + i + "] del vector:"));
            }
        }

        string ComprobarIgualdad(int[] vector1, int[] vector2)
        {
            string txt = "";

            for (int i = 0; i < vector1.Length && i < vector2.Length; i++)
            {
                if (vector1[i] == vector2[i])
                {
                    txt = "Son iguales";
                }
                else
                {
                    txt = "No son iguales";
                }
            }
            return txt;
        }


        private void btnLeer_Click(object sender, EventArgs e)
        {

            LeerVector(vector1);
            LeerVector(vector2);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string txtVector = ComprobarIgualdad(vector1, vector2);
            MessageBox.Show(txtVector);
        }
    }
}
