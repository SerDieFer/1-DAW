using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bDiv_Click(object sender, EventArgs e)
        {
            //Con esto se declaran las variables a usar.
            int num1, num2, div, divrest;

            //Con esto el programa revisa que no haya errores en la introducción de datos.
            try
            {
                //Con esto obtenemos el número introducido en el textBoxNum1, y le asignamos la variable num1.
                num1 = int.Parse(textBoxNum1.Text);

                //Con esto obtenemos el número introducido en el textBoxNum2, y le asignamos la variable num2.
                num2 = int.Parse(textBoxNum2.Text);

                //Con esto dividimos las variables num1 y num2.
                div = num1 / num2;

                //Con esto obtenemos el resto de la división entre las variables num1 y num2.
                divrest = num1 % num2;

                //Con esto mostramos un texto de consola en el cual nos indica el valor de la variable div, así como la variable divrest.
                MessageBox.Show("El valor de la división entera es: " + div + ", mientras que el resto de la division es: " + divrest);
            }
            //Con esto el programa si aparece un error de tipo formato, lo clasifica
            catch (FormatException fEx)
            {
                //Con esto se muestra un texto de consola en el cual nos indica que tipo de error, acompañado con un mensaje identificativo.
                MessageBox.Show("Se ha producido el error: " + fEx.Message);
            }
            }
        }
    }

