using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_04
{
    public partial class fFormulario : Form
    {
        public fFormulario()
        {
            InitializeComponent();
        }

        private void bSumar_Click(object sender, EventArgs e)
        {
            // Declarar las dos variables de tipo entero

            int num1,num2,resultado;

            //Esto si nos manda coger los valores mediante un TextBox

            // num1 = int.Parse(tCuadroNum1.Text);
            // num2 = int.Parse(tCuadroNum2.Text);

            //Resultado de la suma de ambas

            num1 = 10;
            num2 = 20;
            resultado = num1 + num2;

            MessageBox.Show("La suma de " + num1 + " y " + num2 + " es igual a " + resultado);
        }
    }
}
