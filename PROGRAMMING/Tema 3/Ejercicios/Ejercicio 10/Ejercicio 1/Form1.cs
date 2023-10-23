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
            double valorIntroducido;
            int billetes,monedas,cents;

            valorIntroducido = double.Parse(txtValor.Text);
         

            lblResultados.Text = "Le corresponden:\n\n";

                    if (valorIntroducido >= 500)
                    {
                        billetes = (int)valorIntroducido / 500;
                        valorIntroducido = valorIntroducido % 500;
                        lblResultados.Text = lblResultados.Text + (billetes + " billetes de 500 de euros\n");
                    }

                    if (valorIntroducido >= 200)
                    {
                        billetes = (int)valorIntroducido / 200;
                        valorIntroducido = valorIntroducido % 200;
                        lblResultados.Text = lblResultados.Text + (billetes + " billetes de 200 de euros\n");
                    }

                    if (valorIntroducido >= 100)
                    {
                        billetes = (int)valorIntroducido / 100;
                        valorIntroducido = valorIntroducido % 100;
                        lblResultados.Text = lblResultados.Text + (billetes + " billetes de 100 de euros\n");
                    }

                    if (valorIntroducido >= 10)
                    {
                        billetes = (int)valorIntroducido / 10;
                        valorIntroducido = valorIntroducido % 10;
                        lblResultados.Text = lblResultados.Text + (billetes + " billetes de 10 euros\n");
                    }

                    if (valorIntroducido >= 5)
                    {
                        billetes = (int)valorIntroducido / 5;
                        valorIntroducido = valorIntroducido % 5;
                        lblResultados.Text = lblResultados.Text + (billetes + " billetes de 5 euros\n");
                    }

                    if (valorIntroducido >= 2)
                    {
                        monedas = (int)valorIntroducido / 2;
                        valorIntroducido = valorIntroducido % 2;
                        lblResultados.Text = lblResultados.Text + (monedas + " monedas de 2 euros\n");
                    }

                    if (valorIntroducido >= 1)
                    {
                        monedas = (int)valorIntroducido / 1;
                        valorIntroducido = valorIntroducido % 1;
                        lblResultados.Text = lblResultados.Text + (monedas + " monedas de 1 euro\n");
                    }

                    Math.Round(valorIntroducido * 10);

                    if (valorIntroducido >= 50)
                    {
                        cents = (int)valorIntroducido / 50;
                        valorIntroducido = valorIntroducido % 50;
                        lblResultados.Text = lblResultados.Text + ((int)cents + " monedas de 50 céntimos\n");
                    }

                    if (valorIntroducido >= 20)
                    {
                        cents = (int)valorIntroducido / 20;
                        valorIntroducido = valorIntroducido % 20;
                        lblResultados.Text = lblResultados.Text + ((int)cents + " monedas de 20 céntimos\n");
                    }

                    if (valorIntroducido >= 10)
                    {
                        cents = (int)valorIntroducido / 10;
                        valorIntroducido = valorIntroducido % 10;
                        lblResultados.Text = lblResultados.Text + ((int)cents + " monedas de 10 céntimos\n");
                    }

                    if (valorIntroducido >= 5)
                    {
                        cents = (int)valorIntroducido / 5;
                        valorIntroducido = valorIntroducido % 5;
                        lblResultados.Text = lblResultados.Text + ((int)cents + " monedas de 5 céntimos\n");
                    }

                    if (valorIntroducido >= 2)
                    {
                        cents = (int)valorIntroducido / 2;
                        valorIntroducido = valorIntroducido % 2;
                        lblResultados.Text = lblResultados.Text + ((int)cents + " monedas de 2 céntimos\n");
                    }

                    if (valorIntroducido >= 1)
                    {
                        cents = (int)valorIntroducido / 1;
                        valorIntroducido = valorIntroducido % 1;
                        lblResultados.Text = lblResultados.Text + ((int)cents + " monedas de 1 céntimo\n");
                    }
        }
    }
}

