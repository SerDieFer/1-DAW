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

        private void btnCal_Click(object sender, EventArgs e)
        {
            double num, suma, res, numerador;
            string txtInput, txtSuma;

            txtSuma = "La suma sería: \n\n";
            txtInput = Interaction.InputBox("Esto significará que se realizará la misma serie de cálculos hasta donde " +
            "indique el usuario mediante el número a elegir");

            res = 0;
            num = double.Parse(txtInput);
 

            if (num > 1)

            {
                suma = 0;

                   for (double i = 1; i <= num; i++)

                   {

                    numerador = 1.0 / i;

                        if (i % 2 == 0)

                        {
                            suma -= numerador;
                            txtSuma += " - ";
                        }

                        else

                        {
                            suma += numerador;
                            txtSuma += " + ";
                        }


                    txtSuma += suma.ToString();


                }

                 res = suma;
                 MessageBox.Show("1 " + txtSuma + " = " + res);
            }
        }
    }
}


