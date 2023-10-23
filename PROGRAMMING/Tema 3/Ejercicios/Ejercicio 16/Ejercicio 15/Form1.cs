using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Ejercicio_15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            int num, suma;

            num = int.Parse(Interaction.InputBox("Introduce un número"));
            suma = 0;

            lblSuma.Text = "La Suma es: ";

            if (num < 0 || num > 9)

            {
                MessageBox.Show("Error, el número debe ser mayor que 0 y menor que 9.");
            }

            else

            {
                //Introduzco la variabale suma dado que no me interesa que se pueda sumar 0 durante una
                //suma pues no interesa que el programa sume nada, por ende de inicio si te permite
                //introducir el valor 0, pero una vez la suma ya supera ese valor, al no tener sentido
                //sumar 0, lo cuenta como un error pues ya terminaría la suma.
                
                while (num > 0 && num <= 9 || suma == 0)

                {
                    suma = suma + num;
                    lblSuma.Text = "La Suma es: " + suma;
                    num = int.Parse(Interaction.InputBox("Introduce un número"));
                }
            }
        }
    }
}
    

