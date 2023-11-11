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

        int MaximoComunDivisor (ref int n1, ref int n2)
        {

        int resto;

            while (n2 != 0)
            {
                resto = n1 % n2;
                n1 = n2;
                n2 = resto;
            }

            return n1;

        }

        private void btnCal_Click(object sender, EventArgs e)
        {

        int n1, n2, r1, r2, resultado;

        n1 = int.Parse(Interaction.InputBox("Introduce el valor 1"));
        n2 = int.Parse(Interaction.InputBox("Introduce el valor 2"));
        r1 = n1;
        r2 = n2;

        resultado = MaximoComunDivisor (ref r1, ref r2);

        MessageBox.Show("El máximo común divisor de " + n1 + " entre " + n2 + " es: " + resultado);


        }
    }
}
