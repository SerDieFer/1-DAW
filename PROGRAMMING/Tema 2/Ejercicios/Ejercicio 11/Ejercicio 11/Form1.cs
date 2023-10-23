using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bCalculo_Click(object sender, EventArgs e)
        {
            //Declaro las variables que voy a usar.
            double dinero, tasa, resultado;

            //Con esto hacemos al programa detectar los posibles fallos.
            try
            {
                //Asigno el valor designado a las variables mediante textBox.Text adecuado.
                dinero = double.Parse(textBoxDinero.Text);
                tasa = double.Parse(textBoxTasa.Text);

                //Hago el cálculo adecuado del dinero + la tasa anual.
                resultado = (dinero * (tasa / 100)) + dinero;

                //Aqui situo en un label el resultado, cambiando su texto y mostrándolo al usuario.
                lResultado.Text = ("Tus ingresos anuales ascienden a: " + resultado);
            }

            //Con esto clasificamos el error y le asignamos un mensaje
            catch(FormatException fEX)
            {
                //Aquí mostramos un mensaje en la consola de usuario
                MessageBox.Show("Se ha encontrado el siguiente error: " + fEX.Message);
            }
        }
    }
}
