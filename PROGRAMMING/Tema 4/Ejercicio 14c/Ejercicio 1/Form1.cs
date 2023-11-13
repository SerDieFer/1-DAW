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



        string CalcularBilletes(ref int cantidadPesetas, int valorBillete, string nombreBillete)
        {
            int cantidadBilletes = cantidadPesetas / valorBillete;
            string resultado = "";

            if (cantidadBilletes > 0)
            {
                resultado = cantidadBilletes + nombreBillete;
                cantidadPesetas %= valorBillete;
            }

            return resultado;
        }

        string ValorBilletes (ref int cantidadPesetas)
            {

                string txt = "Le corresponden:\n\n";

                txt += CalcularBilletes(ref cantidadPesetas, 10000, " billetes de 10000\n");
                txt += CalcularBilletes(ref cantidadPesetas, 5000, " billetes de 5000\n");
                txt += CalcularBilletes(ref cantidadPesetas, 2000, " billetes de 2000\n");
                txt += CalcularBilletes(ref cantidadPesetas, 1000, " billetes de 1000\n");
                txt += CalcularBilletes(ref cantidadPesetas, 100, " monedas de 100\n");
                txt += CalcularBilletes(ref cantidadPesetas, 25, " monedas de 25\n");

                return txt;

            }
            
        private void btnCalcular_Click(object sender, EventArgs e)
            {
             
                int cantidadPesetas;

                cantidadPesetas = int.Parse(txtValor.Text);
               
                lblResultados.Text = ValorBilletes(ref cantidadPesetas);

            }
        }
    }


