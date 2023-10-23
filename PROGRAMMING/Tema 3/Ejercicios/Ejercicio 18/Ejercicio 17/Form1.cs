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

        private void btnSuma_Click(object sender, EventArgs e)
        {
            string txt,txtsuma;
            int suma;
            suma = 0;
            txt = "La suma de los números pares desde el 1 hasta el número 50 son: ";
            txtsuma = "\n\n Mientras que la suma total sería: ";

            for (int i = 2; i <= 50; i = i+2)

            {
                if (i % 2 == 0)

                    suma = (suma + i);

                {
                    if (i < 50)

                    {
                          txt = txt + i.ToString() + ", ";
                        
                    }

                    else
                    {

                        txt = txt + i.ToString() + ". ";

                    }
                }
            }

            MessageBox.Show(txt + txtsuma + suma);

        }
    }
}
