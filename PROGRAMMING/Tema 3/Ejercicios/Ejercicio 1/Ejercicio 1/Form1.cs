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

        private void btnCompar_Click(object sender, EventArgs e)
        {
            //Aqui declaramos la variable
            int num;

            //Aqui de donde se obtiene su valor
            num = int.Parse(txtNum.Text);

            //En este caso creamos un bloque donde usaremos los siguientes recursos.
            //Con este if creamos un estado en el cual si el numero es igual a 2, nos da un resultado concreto.
            if (num == 2)
            {
                //Mostramos un texto en la consola que nos dice que el número 2 es el introducido.
                MessageBox.Show("El número introducido es el 2.");
            }
            //Con este else, indicamos que en caso de que el anterior if no se cumpla, si el número no es igual a 2, nos da un resultado erroneo.
            else if (num != 2)
            {
                //Mostramos un texto en la consola que nos dice que el número 2 no es el introducido.
                MessageBox.Show("El número introducido no es el 2.");
            }
            //Mostramos un texto en la consola que nos dice que hemos acabado las operaciones.
            MessageBox.Show("Fin de la comparación.");
            
        }
    }
}
