using System;
using System.Windows.Forms;

namespace Ejercicio_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            //Aqui declaramos las variables
            int valorIntroducido, billetes, monedas;

            valorIntroducido = int.Parse(txtValor.Text);

            lblResultados.Text = "Le corresponden:\n\n";

                    if (valorIntroducido >= 10000)
                    {
                        billetes = valorIntroducido / 10000;
                        valorIntroducido = valorIntroducido % 10000;
                        lblResultados.Text = lblResultados.Text + (billetes + " billetes de 10000\n");
                    }

                    if (valorIntroducido >= 5000)
                    {
                        billetes = valorIntroducido / 5000;
                        valorIntroducido = valorIntroducido % 5000;
                        lblResultados.Text = lblResultados.Text + (billetes + " billetes de 5000\n");
                    }

                    if (valorIntroducido >= 2000)
                    {
                        billetes = valorIntroducido / 2000;
                        valorIntroducido = valorIntroducido % 2000;
                        lblResultados.Text = lblResultados.Text + (billetes + " billetes de 2000\n");
                    }

                    if (valorIntroducido >= 1000)
                    {
                        billetes = valorIntroducido / 1000;
                        valorIntroducido = valorIntroducido % 1000;
                        lblResultados.Text = lblResultados.Text + (billetes + " billetes de 1000\n");
                    }

                    if (valorIntroducido >= 100)
                    {
                        monedas = valorIntroducido / 100;
                        valorIntroducido = valorIntroducido % 100;
                        lblResultados.Text = lblResultados.Text + (monedas + " monedas de 100\n");
                    }

                    if (valorIntroducido >= 25)
                    {
                        monedas = valorIntroducido / 25;
                        valorIntroducido = valorIntroducido % 25;
                        lblResultados.Text = lblResultados.Text + (monedas + " monedas de 25\n");
                    }
                }
            }
}

