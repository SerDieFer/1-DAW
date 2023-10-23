using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIguales_Click(object sender, EventArgs e)
        {
            //Aqui declaramos las variables
            int num1, num2;

            //Aqui de donde se obtienen su valores
            num1 = int.Parse(txtNum1.Text);
            num2 = int.Parse(txtNum2.Text);

            //En este caso creamos un bloque donde usaremos los siguientes recursos.
            //Con este if creamos un estado en el cual si los numeros son iguales, nos daría un resultado concreto.
            if (num1 == num2)
            {
                //Mostramos un texto en la consola que nos dice que los numeros son iguales.
                MessageBox.Show("Los números introducidos son iguales.");
            }
            //Con este else, indicamos que en caso de que el anterior if no se cumpla, si los numero noson iguales, nos da un resultado erroneo.
            else if (num1 != num2)
            {
                //Mostramos un texto en la consola que nos dice que el número 2 no es el introducido.
                MessageBox.Show("Los número introducidos no son iguales");
            }
            //Mostramos un texto en la consola que nos dice que hemos acabado las operaciones.
            MessageBox.Show("Fin de la comparación.");
                
        }
    }
}
