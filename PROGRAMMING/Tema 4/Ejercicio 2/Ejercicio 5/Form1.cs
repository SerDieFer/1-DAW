using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        bool division(int n1, int n2)
        {
            bool numDivision = false;

            if (n1 % n2 == 0)
            {
            numDivision = true;
            }

            return numDivision;
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            int num1, num2;
            bool numDivisible;

            num1 = int.Parse(txtBoxN1.Text);
            num2 = int.Parse(txtBoxN2.Text);

            numDivisible = division(num1, num2);


            if(numDivisible)
            {
            MessageBox.Show("El número " + num1 + " es divisible entre el número " + num2);
            }

            else
            {
            MessageBox.Show("El número " + num1 + " no es divisible entre el número " + num2);
            }


        }
    }
}
