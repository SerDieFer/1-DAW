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

        private void btnCal_Click(object sender, EventArgs e)
        {
            int num, elevado, res;
            elevado = int.Parse(txtElevar.Text);
            num = int.Parse(txtNum.Text);
            res = 1;

            for (int i = 1; i <= elevado; i++)
            {
                    res = res * num;
            }

            MessageBox.Show("El número " + num + " elevado a " + elevado + " daría como resultado: " + res);
        }
    }
}
