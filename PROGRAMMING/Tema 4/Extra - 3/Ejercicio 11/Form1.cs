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

namespace Ejercicio_11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        int calcularNúmeroMenor (int n1, int n2, int n3)
        {
            int menor = 0;

            if(n1 > n2)
            {
                menor = n2;
            }

            if(n2 > n3)
            {
                menor = n3;
            }

            if(n3 > n1)
            {
                menor = n1;

            }

            return menor;
        }


        int calcularMCD(int n1, int n2, int n3)
        {
            int divisor = 0;
            bool encontrado = false;

          
                for (int i = calcularNúmeroMenor(n1,n2,n3); !encontrado; i--)
                {
                    if (n1 % i == 0 && n2 % i == 0 && n3 % i == 0)
                    {
                        divisor = i;
                        encontrado = true;
                    }
                }

            return divisor;

        }


            private void btnCal_Click(object sender, EventArgs e)
            {
            int n1, n2, n3;
            string MCD = "";
            string menor = "";
   
            n1 = int.Parse(Interaction.InputBox("Introduce n1: "));
            n2 = int.Parse(Interaction.InputBox("Introduce n2: "));
            n3 = int.Parse(Interaction.InputBox("Introduce n3: "));

            menor = "El número introducido más pequeño sería: " + calcularNúmeroMenor(n1, n2, n3).ToString() +"\n\n";
            MCD = "Siendo el MCD de estos: " + calcularMCD(n1, n2, n3).ToString();

            MessageBox.Show(menor + MCD);
            }
    }
}
