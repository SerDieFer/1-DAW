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
using static System.Net.Mime.MediaTypeNames;

namespace Ejercicio_12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnWhile_Click(object sender, EventArgs e)
        {
            int num,i, suma;
            string txt;
            num = int.Parse(txtNum.Text);
            txt = ("La suma del 1 hasta el " + num + ", daría: ");
            i = 1;
            suma = 0;

            while (i <= num)
            {
                suma = suma + i;
                i++;
            }

            MessageBox.Show(txt + suma);
        }

        private void btnFor_Click(object sender, EventArgs e)
        {
            int num, suma;
            string txt;
            num = int.Parse(txtNum.Text);
            txt = ("La suma del 1 hasta el " + num + ", daría: ");
            suma = 0;

            for (int i = 1; i <= num; i++)
            {
                suma = suma + i;
            }

            MessageBox.Show(txt + suma);

        }
    }
}
