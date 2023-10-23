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
            int num1, num2;

            //Aqui de donde se obtienen su valores
            num1 = int.Parse(txtNum1.Text);
            num2 = int.Parse(txtNum2.Text);

            //En este caso creamos un bloque donde usaremos los siguientes recursos.
            //Con este if creamos un estado en el cual si el num1 es mayor, nos daría un resultado concreto.
            if (num1 > num2)
            {
                //Mostramos un texto en la consola que nos dice que el numero 1 es el mayor.
                MessageBox.Show("El número " + num1 + " es el mayor.");
            }
            //Con este else, indicamos que en caso de que el anterior if no se cumpla, si el num1 es igual que el num2, nos dice que son iguales.
            else if (num1 == num2)
            {
                //Mostramos un texto en la consola que nos dice que los numeros son iguales.
                MessageBox.Show("Son iguales.");
            }

           if (num2 > num1)
            {
                //Mostramos un texto en la consola que nos dice que el numero 2 es el mayor.
                MessageBox.Show("El número " + num2 + " es el mayor.");
            }

            //Mostramos un texto en la consola que nos dice que hemos acabado las operaciones.
            MessageBox.Show("Fin de la comparación.");
                
        }
    }
}
