using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            int num1, num2, resultadosuma;

            try 
            { 
                //Almacenamos la información dada a través de textBoxNum1, en la variable num1.
                num1 = int.Parse(textBoxNum1.Text);

                //Almacenamos la información dada a través de textBoxNum2, en la variable num2.
                num2 = int.Parse(textBoxNum1.Text);

                //Realizamos la suma y la almacenamos en la variable resultadosuma.
                resultadosuma = num1 + num2;

                textBoxResultado.Text = (resultadosuma.ToString());
            }
            catch (FormatException fEx)
            {
                MessageBox.Show("Se ha producido un error: " + fEx.Message);
            }
        }

        private void bResta_Click(object sender, EventArgs e)
        {
            int num1, num2, resultadoresta;

            try
            {
                //Almacenamos la información dada a través de textBoxNum1, en la variable num1.
                num1 = int.Parse(textBoxNum1.Text);

                //Almacenamos la información dada a través de textBoxNum2, en la variable num2.
                num2 = int.Parse(textBoxNum1.Text);

                //Realizamos la resta y la almacenamos en la variable resultadoresta.
                resultadoresta = num1 - num2;

                textBoxResultado.Text = (resultadoresta.ToString());
            }
            catch (FormatException fEx)
            {
                MessageBox.Show("Se ha producido un error: " + fEx.Message);
            }
        }
    }
}
