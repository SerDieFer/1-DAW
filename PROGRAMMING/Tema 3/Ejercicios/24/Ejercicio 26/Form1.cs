using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Ejercicio_26
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            int num = int.Parse(txtNum.Text);
            int res = num;
            string txt = "";

            if (num > 0 && num <= 100)
            {
                txt = "La tabla del " + num + "\n\n";

                for (int i = 1; i <= 10; i++)
                {
                    res = num * i;
                    txt += num + " * " + i + " = " + res + "\n";
                }

                MessageBox.Show(txt);
            }

            else
            {
                MessageBox.Show("Introduce un valor válido");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
