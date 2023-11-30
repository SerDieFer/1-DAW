using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            int suma;
            string txt, txtsuma;
            suma = 0;
            txtsuma = "\n\nLa suma es: ";
            txt = "Serie : \n";

           for(int i = 3; i <= 99; i+=3)
           {
                if(i % 7 == 0)
                {
                    txt += i + ", "+ "\n";
                }
                else
                {
                    txt += i + ", ";
                }

                if (i == 99)
                {
                    txt += i + ".";
                }


                suma += i;
           }


            MessageBox.Show(txt + txtsuma + suma);

        }
    }
}
