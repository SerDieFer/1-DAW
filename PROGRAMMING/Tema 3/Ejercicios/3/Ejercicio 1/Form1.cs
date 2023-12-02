using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIguales_Click(object sender, EventArgs e)
        {
            //Aqui declaramos las variables
            int num1, num2;

            num1 = int.Parse(txtNum1.Text);
            num2 = int.Parse(txtNum2.Text);

            if(num1 > num2) { MessageBox.Show("El número " + num1 + " es el mayor."); }
            else if (num1 == num2) { MessageBox.Show("Los números son iguales."); }
            else { MessageBox.Show("El número " + num2 + " es el mayor."); }
        }
    }
}
