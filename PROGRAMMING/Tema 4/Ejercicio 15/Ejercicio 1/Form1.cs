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

        void CalcularBilletes(ref int valorIntroducido, int valorTipo, ref string txt)
        {
            int cantidadTipo = valorIntroducido / valorTipo;

            string tipoBillete = "";
            string tipoMoneda = "";
            string tipoCentimo = " ";

                if (cantidadTipo > 0)
                {
                    tipoBillete += " billetes de ";
                    tipoMoneda += " monedas de ";
                    tipoCentimo += " céntimos de ";

                    string nombreBillete = tipoBillete + valorTipo;
                    string nombreMoneda = tipoMoneda + valorTipo;
                    string nombreCentimo = tipoCentimo + valorTipo;

                    if (valorIntroducido >= 5)
                    {
                        txt += cantidadTipo + nombreBillete + "\n";
                        valorIntroducido %= valorTipo;
                    }

                    else if (valorIntroducido >= 1)
                    {

                        txt += cantidadTipo + nombreMoneda + "\n";
                        valorIntroducido %= valorTipo;
                    }

                    else
                    {
                        txt += cantidadTipo + nombreCentimo + "\n";
                        valorIntroducido %= valorTipo;
                    }
                }             
            }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string txtValorIntroducido = txtValor.Text;

            double valorIntroducido;
            valorIntroducido = double.Parse(txtValorIntroducido);

            string txt = "";

            int valorEuros = (int)valorIntroducido;
            int valorCentimos = (int)((valorIntroducido - valorEuros) * 100);

                CalcularBilletes(ref valorEuros, 500, ref txt);
                CalcularBilletes(ref valorEuros, 200, ref txt);
                CalcularBilletes(ref valorEuros, 100, ref txt);
                CalcularBilletes(ref valorEuros, 50, ref txt);
                CalcularBilletes(ref valorEuros, 20, ref txt);
                CalcularBilletes(ref valorEuros, 10, ref txt);
                CalcularBilletes(ref valorEuros, 5, ref txt);
                CalcularBilletes(ref valorEuros, 2, ref txt);
                CalcularBilletes(ref valorEuros, 1, ref txt);
            
                CalcularBilletes(ref valorCentimos, 50, ref txt);
                CalcularBilletes(ref valorCentimos, 20, ref txt);
                CalcularBilletes(ref valorCentimos, 10, ref txt);
                CalcularBilletes(ref valorCentimos, 5, ref txt);
                CalcularBilletes(ref valorCentimos, 2, ref txt);
                CalcularBilletes(ref valorCentimos, 1, ref txt);

            lblResultados.Text = txt;

        }
    }
}

