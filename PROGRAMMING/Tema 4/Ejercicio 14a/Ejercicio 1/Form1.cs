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

            string CalcularPesetas(ref int valorIntroducido, ref int cantidadBilletes)
            {

                string txt = "Le corresponden:\n\n";


                while (valorIntroducido > 25)
                {
                    cantidadBilletes = valorIntroducido / 10000;

                    if (cantidadBilletes > 0)
                    {
                        txt += cantidadBilletes + " billetes de 10000\n";
                    }

                    valorIntroducido = valorIntroducido % 10000;

                    if (valorIntroducido < 10000)
                    {
                        cantidadBilletes = valorIntroducido / 5000;

                        if (cantidadBilletes > 0)
                        {
                            txt += cantidadBilletes + " billetes de 5000\n";
                        }
                   
                        valorIntroducido = valorIntroducido % 5000;

                        if (valorIntroducido < 5000)
                        {
                            cantidadBilletes = valorIntroducido / 2000;

                            if (cantidadBilletes > 0)
                            {
                                txt += cantidadBilletes + " billetes de 2000\n";
                            }

                            valorIntroducido = valorIntroducido % 2000;

                            if (valorIntroducido < 2000)
                            {
                                cantidadBilletes = valorIntroducido / 1000;

                                if (cantidadBilletes > 0)
                                {
                                    txt += cantidadBilletes + " billetes de 1000\n";
                                }

                                valorIntroducido = valorIntroducido % 1000;

                                if (valorIntroducido < 1000)
                                {
                                    cantidadBilletes = valorIntroducido / 100;

                                    if (cantidadBilletes > 0)
                                    {
                                        txt += cantidadBilletes + " moneda de 100\n";
                                    }

                                    valorIntroducido = valorIntroducido % 100;

                                    if (valorIntroducido < 100)
                                    {
                                        cantidadBilletes = valorIntroducido / 25;

                                        if (cantidadBilletes > 0)
                                        {
                                            txt += cantidadBilletes + " monedas de 25\n";
                                        }

                                        valorIntroducido = valorIntroducido % 25;
                                    }
                                }
                            }
                        }
                    }
                }

                return txt;
            }

            private void btnCalcular_Click(object sender, EventArgs e)
            {
                //Aqui declaramos las variables
                int valorIntroducido, cantidadBilletes;

                valorIntroducido = int.Parse(txtValor.Text);
                cantidadBilletes = valorIntroducido;

                lblResultados.Text = CalcularPesetas(ref valorIntroducido, ref cantidadBilletes);

            }
        }
    }


