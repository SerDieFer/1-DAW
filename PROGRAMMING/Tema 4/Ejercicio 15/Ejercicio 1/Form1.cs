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

        // Creamos una función que designa el valorInroducido a un tipo de Billete/Moneda/Céntimo concreto.
        void CalcularBilletes(ref int valorIntroducido, int valorTipo, ref string txtRes)
        {

            double cantidadTipo = valorIntroducido / valorTipo;

            if (cantidadTipo > 0)
            {
                string tipo = "";

                if (valorTipo >= 5) 
                {
                    tipo = " billetes de ";
                    txtRes += cantidadTipo + tipo + valorTipo + "\n";
                    valorIntroducido %= valorTipo;
                }
                else if (valorTipo <= 2)
                {
                    tipo = " monedas de ";
                    txtRes += cantidadTipo + tipo + valorTipo + "\n";
                    valorIntroducido %= valorTipo;
                }
                else
                {   
                    tipo = " céntimos de ";
                    txtRes += cantidadTipo + tipo + valorTipo + "\n";
                    valorIntroducido %= valorTipo;
                }
            }
        }

            private void btnCalcular_Click(object sender, EventArgs e)
            {
                // Con esto igualamos el valor del string al valor introducido en el input.
                string txtValorIntroducido = txtValor.Text;
                string txtRes = "";

                // Esto es debido a que queremos introducir céntimos en el input del valor.
                double valorIntroducido;
                valorIntroducido = double.Parse(txtValorIntroducido);

                // Designamos el valor de los euros (billetes y monedas) en un número entero, dejando los céntimos de lado.
                int valorEuros = (int)valorIntroducido;

                /* Designamos el valor de los céntimos en un número entero, mediante la obtención del valor restante, al hacer la
                  resta entre el ValorIntroducido inicial - el valor de este sin decimales, dejandonos simplemente con los decimales
                  que multiplicaremos por 100, obteniendo nuevamente un valor entero asignado a los decimales (céntimos). */
                int valorCentimos = (int)Math.Round(((double)valorIntroducido - valorEuros) * 100);

                //Aqui calculo el valor de cada tipo distinto de billetes/monedas de euro
                CalcularBilletes(ref valorEuros, 500, ref txtRes);
                CalcularBilletes(ref valorEuros, 200, ref txtRes);
                CalcularBilletes(ref valorEuros, 100, ref txtRes);
                CalcularBilletes(ref valorEuros, 50, ref txtRes);
                CalcularBilletes(ref valorEuros, 20, ref txtRes);
                CalcularBilletes(ref valorEuros, 10, ref txtRes);
                CalcularBilletes(ref valorEuros, 5, ref txtRes);
                CalcularBilletes(ref valorEuros, 2, ref txtRes);
                CalcularBilletes(ref valorEuros, 1, ref txtRes);

                //Aqui calculo el valor de cada tipo distinto de céntimos de euro
                CalcularBilletes(ref valorCentimos, 50/, ref txtRes);
                CalcularBilletes(ref valorCentimos, 20, ref txtRes);
                CalcularBilletes(ref valorCentimos, 10, ref txtRes);
                CalcularBilletes(ref valorCentimos, 5, ref txtRes);
                CalcularBilletes(ref valorCentimos, 2, ref txtRes);
                CalcularBilletes(ref valorCentimos, 1, ref txtRes);
           
                lblResultados.Text = txtRes;

            }
        }
    }

