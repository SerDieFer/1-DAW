using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Ejercicio_28
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double Factorial (double num)
        {
            double fact = 1;

            for(int i = 1; i<= num;i++)
            {
                fact *= i;

            }

            return fact;
        }


        private void btnCal_Click(object sender, EventArgs e)
        {
            double num, suma, res;
            string txtInput, txtSuma;

            txtSuma = "La suma sería: \n\n";
            txtInput = Interaction.InputBox("Esto significará que se realizará la misma serie de cálculos hasta donde " +
            "indique el usuario mediante el número a elegir");

            res = 0;
            num = double.Parse(txtInput);

            if(num > 0)
            {
                suma = 1;
                txtSuma += 1;

                for (double i = 2; i <= num; i++)
                {
                    if(i % 2 == 0)
                    {
                        suma -= 1 / Factorial(i);
                        txtSuma += " - ";
                    }
                    else
                    {
                        suma += 1 / Factorial(i);
                        txtSuma += " + ";
                    }

                    txtSuma += (1 / Factorial(i)).ToString();
                    
                }

                res = suma;

                MessageBox.Show(txtSuma + " = " + res);
            }

        }

    }
}




