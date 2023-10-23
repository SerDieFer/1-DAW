using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bResultado_Click(object sender, EventArgs e)
        {
            
            //Declaramos aquí las variables que vamos a usar en el programa
            int num1, num2, num3, suma, multiplicacion;

            //Usamos el try para detectar posibles errores.
            try
            {
                //Declaramos aquí de donde saca el valor las variables, en estos casos de los datos introducidos en el textbox correspondiente.
                num1 = int.Parse(textBoxNum1.Text);
                num2 = int.Parse(textBoxNum2.Text);
                num3 = int.Parse(textBoxNum3.Text);

                //Con estas operaciones declaramos el valor de una suma y una multiplicación
                suma = num1 + num2 + num3;
                multiplicacion = num1 * num2 * num3;

                //Con esto cambiamos las propiedades del texcto propio del label, haciendo que nos indique los resultados (el \n sirve para saltar el párrafo).
               lResultado.Text = ("La suma es: " + suma + "\n" + "La multiplicación es: " + multiplicacion);
            }
            //Declaramos el catch para clasificar los errores detectados.
            catch (FormatException fEx)
            {
                //Mandamos el mensaje personalizado sobre el error identificado al usuario, mediante una consola de texto.
                MessageBox.Show("Se ha producido un error de: " + fEx.Message);
            }
        }
    }
}
