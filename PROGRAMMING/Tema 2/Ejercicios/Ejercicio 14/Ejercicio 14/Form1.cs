using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bMenor_Click(object sender, EventArgs e)
        {
            //Declaramos las variables que usaremos.
            double num1, num2;
            bool resultado;

            //Con esto detectaremos los posibles errores.
            try
            {
                //Aquí indicamos el valor de las variables.
                num1 = double.Parse(textBoxNum1.Text);
                num2 = double.Parse(textBoxNum2.Text);
                resultado = num1 < num2;

                //Aquí le mostramos al usuario mediante un label el resultado.
                lResultado.Text = resultado.ToString();
            }
            //Con esto catalogamos los errores.
            catch(FormatException fEX)
            {
                //Aqui le mostramos al usuario el susodicho error.
                MessageBox.Show("Se ha detectado el siguiente error: " + fEX.Message);

            }
        }

        private void bMayor_Click(object sender, EventArgs e)
        {
            //Declaramos las variables que usaremos.
            double num1, num2;
            bool resultado;

            //Con esto detectaremos los posibles errores.
            try
            {
                //Aquí indicamos el valor de las variables.
                num1 = double.Parse(textBoxNum1.Text);
                num2 = double.Parse(textBoxNum2.Text);
                resultado = num1 > num2;

                //Aquí le mostramos al usuario mediante un label el resultado.
                lResultado.Text = resultado.ToString();
            }
            //Con esto catalogamos los errores.
            catch (FormatException fEX)
            {
                //Aqui le mostramos al usuario el susodicho error.
                MessageBox.Show("Se ha detectado el siguiente error: " + fEX.Message);

            }
        }

        private void bIgual_Click(object sender, EventArgs e)
        {
            //Declaramos las variables que usaremos.
            double num1, num2;
            bool resultado;

            //Con esto detectaremos los posibles errores.
            try
            {
                //Aquí indicamos el valor de las variables.
                num1 = double.Parse(textBoxNum1.Text);
                num2 = double.Parse(textBoxNum2.Text);
                resultado = num1 == num2;

                //Aquí le mostramos al usuario mediante un label el resultado.
                lResultado.Text = resultado.ToString();
            }
            //Con esto catalogamos los errores.
            catch (FormatException fEX)
            {
                //Aqui le mostramos al usuario el susodicho error.
                MessageBox.Show("Se ha detectado el siguiente error: " + fEX.Message);

            }
        }

        private void bNoIgual_Click(object sender, EventArgs e)
        {
            //Declaramos las variables que usaremos.
            double num1, num2;
            bool resultado;

            //Con esto detectaremos los posibles errores.
            try
            {
                //Aquí indicamos el valor de las variables.
                num1 = double.Parse(textBoxNum1.Text);
                num2 = double.Parse(textBoxNum2.Text);
                resultado = num1 != num2;

                //Aquí le mostramos al usuario mediante un label el resultado.
                lResultado.Text = resultado.ToString();
            }
            //Con esto catalogamos los errores.
            catch (FormatException fEX)
            {
                //Aqui le mostramos al usuario el susodicho error.
                MessageBox.Show("Se ha detectado el siguiente error: " + fEX.Message);

            }
        }
    }
}
