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

namespace Ejercicio_17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPrimo_Click(object sender, EventArgs e)
        {
            int num = int.Parse(txtNum.Text);
            bool divisorEncontrado = false;
            string txt, txtPrim, txtNoPrim;
            txt = "";
            txtPrim = " Primo";
            txtNoPrim = " No primo";

            if (num > 1)

            {

                for (int i = 2; i < num && divisorEncontrado == false; i++)
                {

                    if (num % i == 0)

                    {
                        txt = txtNoPrim;
                        divisorEncontrado = true;
                    }
                }

                if (divisorEncontrado == false)

                {
                    txt = txtPrim;
                }
            }

            else

            {
                txt = txtNoPrim;
            }
            
            
            MessageBox.Show(txt);
        }
    }
}
