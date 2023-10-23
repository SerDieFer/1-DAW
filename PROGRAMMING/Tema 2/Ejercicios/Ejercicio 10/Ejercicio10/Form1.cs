using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        //Con esta estructura const + TIPO DE DATO = Valor, conseguimos crear una constante.
        const double PESETAS = 166.386;

        private void bEuros_Click(object sender, EventArgs e)
        {
            //Con esto declaramos una variable con decimales.
            double euros, resultadoconversion;

            //Con este comando nos detecta cualquier error en la función.
            try
            {
                //Con esto elegimos el valor de los euros.
                euros = double.Parse(textBoxEuros.Text);
              
                //El resultado de la conversion viene dado por esta operación.
                resultadoconversion = euros * PESETAS;

                //Aqui nos convierte el resultado double a string y lo introduce en el textbox de pesetas
                textBoxPesetas.Text = (resultadoconversion.ToString());
            }
            //Con este comando le ponemos formato y catalogamos los errores.
            catch (FormatException fEx)
            {
                //Con este comando se abre una ventana de consola indicando el mensaje de error.
                MessageBox.Show("Se ha producido el error: " + fEx.Message);
            }
        }

        private void bPesetas_Click(object sender, EventArgs e)
        {
            //Con este comando nos detecta cualquier error en la función.
            try
            {
                //Con esto declaramos una variable con decimales.
                double  pesetas, resultadoconversion;

                //Con esto elegimos el valor de las pesetas.
                pesetas = double.Parse(textBoxPesetas.Text);

                //El resultado de la conversion viene dado por esta operación.
                resultadoconversion = pesetas / PESETAS;

                //Aqui nos convierte el resultado double a string y lo introduce en el textbox de euros
                textBoxEuros.Text = (resultadoconversion.ToString());

            }
            //Con este comando le ponemos formato y catalogamos los errores.
            catch (FormatException fEx)
            {
                //Con este comando se abre una ventana de consola indicando el mensaje de error.
                MessageBox.Show("Se ha producido el error: " + fEx.Message);
            }
        }
    }
    }
    

