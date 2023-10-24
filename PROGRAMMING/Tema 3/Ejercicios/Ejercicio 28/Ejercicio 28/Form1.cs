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
            int resultado, num1, num2;
            string txt, suma, txtNum1, txtNum2;

            resultado = 0;
            txtNum1 = Interaction.InputBox("Introduzca el número a multiplicar");
            txtNum2 = Interaction.InputBox("Introduzca el número a multiplicar");

            suma = "";
            txt = "La multiplicación de (" + txtNum1 + ") x (" + txtNum2 + ") sería: \n\n";

            num1 = int.Parse(txtNum1);
            num2 = int.Parse(txtNum2);


            if (num1 < 0)

            {
                num1 = -num1;
                num2 = -num2;

            }


            if (num1 > 0)

            {

                for (int i = 0; i < num1; i++)

                {

                    resultado += num2;

                    if (i == (num1 - 1))

                    {
                        suma += "( " + num2 + " )";
                    }

                    else

                    {
                        suma += "( " + num2 + " )" + " + ";
                    }

                }

            }

            txt += "( " + txtNum1 + " )" + " * " + "( " + txtNum2 + " )" + " = " + suma + " = " + resultado;

            MessageBox.Show(txt);

        }
    }
}
