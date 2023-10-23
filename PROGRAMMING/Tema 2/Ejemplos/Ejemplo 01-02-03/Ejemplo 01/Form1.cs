using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo_01
{
    public partial class fFormulario2 : Form
    {
        public fFormulario2()
        {
            InitializeComponent();
        }

        private void bMostrar_Click(object sender, EventArgs e)
        {
            int num1;
            num1 = int.Parse(textBoxNum.Text);


            MessageBox.Show(num1.ToString());

        }

        private void bMostrarEnteras_Click(object sender, EventArgs e)
        {
            int num2;
            num2 = 125;

            MessageBox.Show(num2.ToString());
        }

        private void bMostrarDouble_Click(object sender, EventArgs e)
        {
            double num3;
            num3 = 223.25;

            MessageBox.Show(num3.ToString());
        }

        private void bMostrarFloat_Click(object sender, EventArgs e)
        {
            float num4;
            num4 = 3.1416F;

            MessageBox.Show(num4.ToString());
        }
    }
}
