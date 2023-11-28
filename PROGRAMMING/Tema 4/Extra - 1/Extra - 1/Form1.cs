using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
       
                for (int i = 2; i < num; i++)
                {
                    if (ComprobarPrimo(i, true))
                    {
                        if (num == i + 1)
                        {
                            txt += i;
                        }
                        else
                        {
                            txt += i + " - ";
                        }
                    }

                    else if (num == i + 1)
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
            int num = int.Parse(Interaction.InputBox("Introduzca un número (>= 1) para mostrar " +
            "los números primos que sean menor a este"));

            if (num >= 3)
            {
                bool esPrimo = true;
                esPrimo = ComprobarPrimo(num, esPrimo);
                ImprimirPrimos(num, esPrimo, out txtResultado);
                MessageBox.Show("Los números primos anteriores al " + num + " serían: \n\n" + txtResultado);
            }

            else if (num == 2)
            {
                MessageBox.Show("El número 2 no tiene números primos anteriores");
            }

            else if (num < 2 && num >= 1)
            {
                MessageBox.Show("El número 1 no es un número primo");

            }

            else
            {
                MessageBox.Show("Introduzca un valor válido mayor que 0");
            }

            
        }
    }
}
