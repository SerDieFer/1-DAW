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

        private void btnMayores_Click(object sender, EventArgs e)
        {
            //Aqui declaramos las variables
            int num1, num2, num3;

            //Aqui de donde se obtienen su valores
            num1 = int.Parse(txtNum1.Text);
            num2 = int.Parse(txtNum2.Text);
            num3 = int.Parse(txtNum3.Text);

            //En este caso creamos un bloque donde usaremos los siguientes recursos.
            //Con este if creamos un estado en el cual si el num1 es mayor que el num2 y num3, nos daría un resultado concreto.
            if (num1 > num2 && num1 > num3)
            {
                //Mostramos un texto en la consola que nos dice que el num1 es el mayor.
                MessageBox.Show("El número " + num1 + " es el mayor.");
            }
            //Con este else, indicamos que en caso de que el anterior if no se cumpla, si el num2 es mayor que el num2 y num3, nos daría un resultado.
            else if (num2 > num3 && num2 > num3)
            {
                //Mostramos un texto en la consola que nos dice que el num2 es el mayuor.
                MessageBox.Show("El número " + num2 + " es el mayor.");
            }
            //Con este else, indicamos que en caso de que no se cumpla ninguna de las condiciones anteriores nos mostraría un resultado concreto.
            else
            {
                //Mostramos un texto en la consola que nos dice que el num3 es el mayor.
                MessageBox.Show("El número " + num3 + " es el mayor.");
            }
           
            //Mostramos un texto en la consola que nos dice que hemos acabado las operaciones.
            MessageBox.Show("Fin de la comparación.");
                
        }
    }
}
