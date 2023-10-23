using System;
using System.Windows.Forms;

namespace Ejercicio_05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bSuma_Click(object sender, EventArgs e)
        {
            //Declaro las variables aqui
            int num1, num2, resultadosuma;

            //Esto captura los posibles errores del programa
            try
            { 
                //Almacenamos la información dada a través de textBoxNum1, en la variable num1.
                num1 = int.Parse(textBoxNum1.Text);

                //Almacenamos la información dada a través de textBoxNum2, en la variable num2.
                num2 = int.Parse(textBoxNum2.Text);

                //Realizamos la suma y la almacenamos en la variable resultadosuma.
                resultadosuma = num1 + num2;

                textBoxResultado.Text = (resultadosuma.ToString());
            }
            //Esto detecta los errores y los clasifica en un mensaje 
            catch (FormatException fEx)
            {
                //Aquí indicamos el tipo de error mediante una ventana de texto
                MessageBox.Show("Se ha producido un error: " + fEx.Message);
            }
        }

        private void bResta_Click(object sender, EventArgs e)
        {
            //Declaro las variables aqui
            int num1, num2, resultadoresta;


            //Esto captura los posibles errores del programa
            try
            {
                //Almacenamos la información dada a través de textBoxNum1, en la variable num1.
                num1 = int.Parse(textBoxNum1.Text);

                //Almacenamos la información dada a través de textBoxNum2, en la variable num2.
                num2 = int.Parse(textBoxNum2.Text);

                //Realizamos la resta y la almacenamos en la variable resultadoresta.
                resultadoresta = num1 - num2;

                //Esto nos cambia el texto del textbox que da el resultado dependiendo de nuestra elección.
                textBoxResultado.Text = (resultadoresta.ToString());
            }
            //Esto detecta los errores y los clasifica en un mensaje 
            catch (FormatException fEx)
            {
                //Aquí indicamos el tipo de error mediante una ventana de texto
                MessageBox.Show("Se ha producido un error: " + fEx.Message);
            }
        }

        private void bMult_Click(object sender, EventArgs e)
        {
            //Declaro las variables aqui
            int num1, num2, resultadomult;


            //Esto captura los posibles errores del programa
            try
            {
                //Almacenamos la información dada a través de textBoxNum1, en la variable num1.
                num1 = int.Parse(textBoxNum1.Text);

                //Almacenamos la información dada a través de textBoxNum2, en la variable num2.
                num2 = int.Parse(textBoxNum2.Text);

                //Realizamos la resta y la almacenamos en la variable resultadoresta.
                resultadomult = num1 * num2;

                //Esto nos cambia el texto del textbox que da el resultado dependiendo de nuestra elección.
                textBoxResultado.Text = (resultadomult.ToString());
            }
            //Esto detecta los errores y los clasifica en un mensaje 
            catch (FormatException fEx)
            {
                //Aquí indicamos el tipo de error mediante una ventana de texto
                MessageBox.Show("Se ha producido un error: " + fEx.Message);
            }
        }

        private void bDiv_Click(object sender, EventArgs e)
        {
            //Declaro las variables aqui
            int num1, num2, resultadodiv;


            //Esto captura los posibles errores del programa
            try
            {
                //Almacenamos la información dada a través de textBoxNum1, en la variable num1.
                num1 = int.Parse(textBoxNum1.Text);

                //Almacenamos la información dada a través de textBoxNum2, en la variable num2.
                num2 = int.Parse(textBoxNum2.Text);

                //Realizamos la resta y la almacenamos en la variable resultadoresta.
                resultadodiv = num1 / num2;

                //Esto nos cambia el texto del textbox que da el resultado dependiendo de nuestra elección.
                textBoxResultado.Text = (resultadodiv.ToString());
            }
            //Esto detecta los errores y los clasifica en un mensaje 
            catch (FormatException fEx)
            {
                //Aquí indicamos el tipo de error mediante una ventana de texto
                MessageBox.Show("Se ha producido un error: " + fEx.Message);
            }
        }

        private void bResto_Click(object sender, EventArgs e)
        {
            //Declaro las variables aqui
            int num1, num2, resultadoresto;


            //Esto captura los posibles errores del programa
            try
            {
                //Almacenamos la información dada a través de textBoxNum1, en la variable num1.
                num1 = int.Parse(textBoxNum1.Text);

                //Almacenamos la información dada a través de textBoxNum2, en la variable num2.
                num2 = int.Parse(textBoxNum2.Text);

                //Realizamos la resta y la almacenamos en la variable resultadoresta.
                resultadoresto = num1 % num2;

                //Esto nos cambia el texto del textbox que da el resultado dependiendo de nuestra elección.
                textBoxResultado.Text = (resultadoresto.ToString());
            }
            //Esto detecta los errores y los clasifica en un mensaje 
            catch (FormatException fEx)
            {
                //Aquí indicamos el tipo de error mediante una ventana de texto
                MessageBox.Show("Se ha producido un error: " + fEx.Message);
            }
        }
    }
    }

