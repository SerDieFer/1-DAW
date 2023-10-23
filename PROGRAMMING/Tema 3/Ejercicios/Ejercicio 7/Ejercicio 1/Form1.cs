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

        private void btnResultado_Click(object sender, EventArgs e)
        {
            //Aqui declaramos las variables
            int resultado;

            //Aqui de donde se obtienen sus valores
            resultado = int.Parse(txtNum.Text);

            switch (resultado)
            {
                case 1:
                    resultado = 1;
                    MessageBox.Show("Se ha apretado el: " + resultado);
                    break;
                case 2:
                    resultado = 2;
                    MessageBox.Show("Se ha apretado el: " + resultado);
                    break;
                case 3:
                    resultado = 3;
                    MessageBox.Show("Se ha apretado el: " + resultado);
                    break;
                case 4:
                    resultado = 4;
                    MessageBox.Show("Se ha apretado el: " + resultado);
                    break;
                case 5:
                    resultado = 5;
                    MessageBox.Show("Se ha apretado el: " + resultado);
                    break;
                default:
                    MessageBox.Show("Él " + resultado + " no sería válido");
                    break;

            }
        }
    }
}
