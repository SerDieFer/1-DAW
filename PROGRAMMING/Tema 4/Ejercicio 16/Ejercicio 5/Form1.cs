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


        int factorial (int num)
        {

            int fac = num;

            for (int i = 1; i < num; i++)
            {
                fac *= i;
            }

            return fac;

        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            int num, fac;

            num = int.Parse(txtBoxN1.Text);
            fac = factorial(num);

            MessageBox.Show("El factorial del  " + num + " sería: " + fac);
        }
    }
}

