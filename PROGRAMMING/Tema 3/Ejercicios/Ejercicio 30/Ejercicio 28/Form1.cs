using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Ejercicio_30
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAcceso_Click(object sender, EventArgs e)
        {
            int numIntentos;
            string inputNombre, inputContraseña, usuario, contraseña;
            bool sistema = false;

            numIntentos = 5;

            inputNombre = Interaction.InputBox("Introduzca el nombre del Usuario: ");
            inputContraseña = Interaction.InputBox("Introduzca la contraseña del Usuario: ");


            // Asi sería si lo realizamos con un bucle do/while:

            while (numIntentos > 0 && sistema == false)
            {
                usuario = "root";
                contraseña = "1234";

                numIntentos--;

                if (inputNombre == usuario && inputContraseña == contraseña)
                {
                    MessageBox.Show("Bienvenido al sistema");
                    sistema = true;
                }

                else
                {
                    if (numIntentos == 0 && sistema == false)
                    {
                        MessageBox.Show("No te quedan más intentos, el acceso esta bloqueado.");
                    }

                    else if (numIntentos == 1)
                    {
                        MessageBox.Show("Te queda: " + numIntentos + " intento");
                        inputNombre = Interaction.InputBox("Introduzca el nombre del Usuario: ");
                        inputContraseña = Interaction.InputBox("Introduzca la contraseña del Usuario: ");
                    }

                    else
                    {
                        MessageBox.Show("Te quedan: " + numIntentos + " intentos");
                        inputNombre = Interaction.InputBox("Introduzca el nombre del Usuario: ");
                        inputContraseña = Interaction.InputBox("Introduzca la contraseña del Usuario: ");
                    }
                }   
            }
        }
    }
}



