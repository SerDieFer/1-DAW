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
using static System.Net.Mime.MediaTypeNames;

namespace Extra___1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string ImprimirPrimos(int num, bool esPrimo, out string txtResultado)
        {
            string txt = "";
       
                for (int i = 1; i <= num; i++)
                {
                    if (ComprobarPrimo(i, true))
                    {
                        if (num == i)
                        {
                            txt += i;
                        }
                        else
                        {
                            txt += i + " - ";
                        }
                    }

                    else if (i == num)
                    {
                        // He tenido que buscar como
                        txt = txt.TrimEnd('-', ' ');
                    }
                    
                }

            txtResultado = txt;
            return txtResultado;
        }

        bool ComprobarPrimo(int num, bool esPrimo)
        {
            for (int i = 2; i < num && esPrimo; i++)
            {
                if (num % i == 0)
                {
                    esPrimo = false;
                }
            }

            return esPrimo;
        }

        private void btnPrimo_Click(object sender, EventArgs e)
        {
            string txtResultado;
            string numInicial = Interaction.InputBox("Introduzca un número (>= 1) para mostrar " +
            "los números primos que sean menor a este");
            int numCalculable = int.Parse(numInicial);

            bool esPrimo = true;

            esPrimo = ComprobarPrimo(numCalculable, esPrimo);
            ImprimirPrimos(numCalculable, esPrimo, out txtResultado);

            if (numCalculable >= 1)
            { 
                MessageBox.Show("Los números primos serían: \n\n" + txtResultado);
            }

            else
            {
                MessageBox.Show("Introduzca un valor válido");
            }
        }
    }
}
