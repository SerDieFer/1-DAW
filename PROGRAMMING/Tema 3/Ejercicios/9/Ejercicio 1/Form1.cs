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
            string txt = "";


            valorIntroducido = int.Parse(txtValor.Text);


            if(valorIntroducido >= 10000)
            {
                billetes = valorIntroducido / 10000;
                txt += billetes + " billetes de 10000\n";
                valorIntroducido %= 10000;
            }

            if (valorIntroducido >= 5000)
            {
                billetes = valorIntroducido / 5000;
                txt += billetes + " billetes de 5000\n";
                valorIntroducido %= 5000;
            }

            if (valorIntroducido >= 2000)
            {
                billetes = valorIntroducido / 2000;
                txt += billetes + " billetes de 2000\n";
                valorIntroducido %= 2000;
            }

            if (valorIntroducido >= 1000)
            {
                billetes = valorIntroducido / 1000;
                txt += billetes + " billetes de 1000\n";
                valorIntroducido %= 1000;
            }

            if (valorIntroducido >= 100)
            {
                monedas = valorIntroducido / 100;
                txt += monedas + " monedas de 100\n";
                valorIntroducido %= 100;
            }

            if (valorIntroducido >= 25)
            {
                monedas = valorIntroducido / 25;
                txt += monedas + " monedas de 25";
                valorIntroducido %= 25;
            }

            MessageBox.Show(txt);

        }
    }
}

