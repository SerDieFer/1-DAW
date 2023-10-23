using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFac_Click(object sender, EventArgs e)
        {
            int num, fac;
            num = int.Parse(txtFac.Text);
            fac = 1;

            for (int i = 1; i <= num; i++)

            {
                fac = fac * i;
            }

            MessageBox.Show("El factorial de " + num + " es: " + fac);
        }
    }
}
