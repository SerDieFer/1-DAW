using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_12
{
    public partial class Form1 : Form
    {
        //Declaro la constante del IVA y le doy un valor double para simplificar futuras operaciones.
        const double IVA = 1.21;
        public Form1()
        {
            InitializeComponent();
        }

        private void bCalculo_Click(object sender, EventArgs e)
        {

            //Declaro las variables a usar.
            double producto1, producto2, producto3, resultado, resultadoIVA;

            //Con esto detecto los posibles errores.
            try
            {
                //Indico de donde se obtiene cada valor.
                producto1 = double.Parse(textBoxProducto1.Text);
                producto2 = double.Parse(textBoxProducto2.Text);
                producto3 = double.Parse(textBoxProducto3.Text);
                resultado = (producto1 + producto2 + producto3);
                resultadoIVA = (resultado * IVA);

                //Aqui indico donde se mostrará el mensaje de los distintos valores requeridos.
                lCalculo.Text = "El importe total sin IVA resultará en: " + resultado + "\n" + "El importe total con IVA incluido será: " + resultadoIVA;
            }
            //Con esto catalogamos el error.
            catch (FormatException fEX)
            {
                //Aqui le mostramos al usuario con una ventana el error concreto.
                MessageBox.Show("Se ha encontrado el siguiente error: " + fEX.Message);
            }
        }
    }
}
