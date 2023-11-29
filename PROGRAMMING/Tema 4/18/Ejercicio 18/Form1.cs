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

namespace Ejercicio_18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        double Serie (int m, int n)
        {
            double suma = 0;

            for(int i = 1; i <= n;i++)
            {
                suma += (double) Potencia(m, i) / Factorial(i);

            }
            return suma;
        }

        int Potencia (int m, int n)
        {
            int pot = 1;

            for(int i = 1; i <= n; i++)
            {
                pot *= m;

            }
            return pot;
        }

        int Factorial (int n)
        {
            int resfact = 1;

            for(int i = 1; i <= n; i++)
            {
                resfact *= i;

            }
            return resfact;
        }

        private void btnSerie_Click(object sender, EventArgs e)
        {
            int m, n;
            m = int.Parse(Interaction.InputBox("Introduce el número m para la siguiente serie:\nm + m^2/ 2! + m^3/ 3! + m^4/ 4! + ….+m^n/n!"));
            n = int.Parse(Interaction.InputBox("Introduce el número n para la siguiente serie:\nm + m^2/ 2! + m^3/ 3! + m^4/ 4! + ….+m^n/n!"));
            string res = "";

            res = Serie(m , n).ToString();

            MessageBox.Show(res);
        }
    }
}