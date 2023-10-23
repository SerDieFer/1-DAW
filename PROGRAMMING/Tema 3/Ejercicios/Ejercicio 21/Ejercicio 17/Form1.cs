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
            int num;
            string txt;
            num = int.Parse(txtNum.Text);
            txt = "";

            if (num >= 1 && num <= 15)
            {

                for (int i = 1; i <= num; i++)
                {

                        for (int j = 1; j <= 10; j++)
                        {

                            if (j == 10)
                            {

                                txt = txt + j + ".";

                            }

                            else
                            {

                                txt = txt + j + ", ";

                            }

                        }

                    txt = txt + "\n";

                }

                MessageBox.Show(txt);

            }

            else
            {

                MessageBox.Show("El número introducido tiene que estar entre 1 y 15.");

            }
        }
    }
}
