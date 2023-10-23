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
            int mult,num1, num2;
            string txt, txtSuma, txtNum1, txtNum2;

            mult = 0;
            txtNum1 = Interaction.InputBox("Introduzca el número a multiplicar");
            txtNum2 = Interaction.InputBox("Introduzca el número a multiplicar");
            txtSuma = "";
            txt = "La multiplicación de " + txtNum1 + " x " + txtNum2 + " sería: \n\n";

            num1 = int.Parse(txtNum1);
            num2 = int.Parse(txtNum2);

            if (num1 < 0 || num2 < 0)

            {

            num1 = -num1;
            num2 = -num2;

                for (int i = 0; i < num2; i++)

                {

                    if (i == num2 - 1)

                    {
                    txtSuma += num1.ToString();
                    }

                    else

                    {
                    txtSuma += num1 + " + ";
                    }

                }

            }

            else

            {

                for (int i = 0; i < num2; i++)

                {
                    if (i == num2 - 1)

                    {
                    txtSuma += num1.ToString(); ;   
                    }

                    else

                    {
                    txtSuma += num1 + " + ";
                    }

                }

            }

            mult = int.Parse(txtNum1) * int.Parse(txtNum2);
            txt += num1 + " * " + num2 + " = " + txtSuma + " = " +  mult;

            MessageBox.Show(txt);




        }
    }
}
