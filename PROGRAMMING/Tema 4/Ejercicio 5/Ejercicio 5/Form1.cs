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

        private void btnCal_Click(object sender, EventArgs e)
        {
            int num1, num2, numMayor;

            num1 = int.Parse(txtBoxN1.Text);
            num2 = int.Parse(txtBoxN2.Text);

            numMayor = mayor(num1, num2);

            MessageBox.Show("El mayor es: " + numMayor);
        }

        int mayor(int n1, int n2)
        {
            int numMayor = n2;

            if(n1>n2)
            {
            numMayor = n1;
            }

            return numMayor;
        }
    }
}
