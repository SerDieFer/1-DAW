using System;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Ejercicio_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        void CalcularBilletes(ref int cantidadPesetas, int valorTipo, ref string txt)
        {
            int cantidadTipos = cantidadPesetas / valorTipo;

            string tipoBillete = "";
            string tipoMoneda = "";
  
   

            if (cantidadTipos > 0 && cantidadTipos != 1)
            {
                tipoBillete += " billetes de ";
                tipoMoneda += " monedas de ";

                string nombreBillete = tipoBillete + valorTipo;
                string nombreMoneda = tipoMoneda + valorTipo;
 

                if (cantidadPesetas < 1000)
                {
                    txt += cantidadTipos + nombreMoneda + "\n";
                    cantidadPesetas %= valorTipo;
                }

                else
                {
                    txt += cantidadTipos + nombreBillete + "\n";
                    cantidadPesetas %= valorTipo;
                }
            }

            if (cantidadTipos == 1)
            {
                tipoBillete += " billete de ";
                tipoMoneda += " moneda de ";

                string nombreBillete = tipoBillete + valorTipo;
                string nombreMoneda = tipoMoneda + valorTipo;


                if (cantidadPesetas < 1000)
                {
                    txt += cantidadTipos + nombreMoneda + "\n";
                    cantidadPesetas %= valorTipo;
                }

                else
                {
                    txt += cantidadTipos + nombreBillete + "\n";
                    cantidadPesetas %= valorTipo;
                }
            }

        }

        private void btnCalcular_Click(object sender, EventArgs e)
            {
             
            int cantidadPesetas;
            string txt ="";
            

            cantidadPesetas = int.Parse(txtValor.Text);

            CalcularBilletes(ref cantidadPesetas, 10000, ref txt);
            CalcularBilletes(ref cantidadPesetas, 5000, ref txt);
            CalcularBilletes(ref cantidadPesetas, 2000, ref txt);
            CalcularBilletes(ref cantidadPesetas, 1000, ref txt);
            CalcularBilletes(ref cantidadPesetas, 100, ref txt);
            CalcularBilletes(ref cantidadPesetas, 25, ref txt);

            lblResultados.Text = txt;

            }
        }
    }


