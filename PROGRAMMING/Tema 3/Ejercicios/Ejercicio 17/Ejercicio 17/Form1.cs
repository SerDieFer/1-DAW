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

        private void btnMult_Click(object sender, EventArgs e)
        {
            string txt;
            txt = "Los múltiplos de 3 del número 1 al 100 son: ";

            for(int i = 3; i <= 100; i++)
            {
                if (i % 3 == 0)

                {
                    if (i < 99)

                    {
                        txt = txt + i.ToString() + ", ";
                    }

                    else

                    {
                        txt = txt + i.ToString() + ". ";
                    }

                }
                
            }
            MessageBox.Show(txt);
        }
    }
}
