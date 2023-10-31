using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string textoTelegrama;
            char tipoTelegrama = ' ';

            int numPalabras = 0;
            double coste;

            //Leo el telegrama
            textoTelegrama = txtTelegrama.Text;

            // Es el telegrama urgente o no?
            if (cbUrgente.Checked)
            {
            tipoTelegrama = 'u';
            }

            else
            {
            tipoTelegrama = 'o';
            }

            //Obtengo el número de palabras que forma el telegrama 
            numPalabras = textoTelegrama.Split(new char[] {' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;

            //Si el telegrama es ordinario
            if (tipoTelegrama == 'o')
            {

                if (numPalabras <= 10)
                {
                    coste = 2.5;
                }

                else
                {
                    coste = 2.5 + (0.5 * (numPalabras - 10));
                }

            }

            //Si el telegrama es urgente
            else
            {
                
                if (tipoTelegrama == 'u')
                {

                    if (numPalabras <= 10)
                    {
                    coste = 5;
                    }

                    else
                    {
                    coste = 5 + (0.75 * (numPalabras - 10));
                    }

                }

                else
                {
                coste = 0;
                }
            }

        txtPrecio.Text = coste.ToString() + " euros";

        }
    }
}
