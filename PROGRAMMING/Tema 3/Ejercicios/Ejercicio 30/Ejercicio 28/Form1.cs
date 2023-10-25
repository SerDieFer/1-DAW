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

namespace Ejercicio_28
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            int numIntentos, sumaIntentos;
            string inputNombre, inputContraseña, usuario, contraseña;


            numIntentos = 4;

            inputNombre = Interaction.InputBox("Introduzca el nombre del Usuario: ");
            inputContraseña = Interaction.InputBox("Introduzca la contraseña del Usuario: ");

            usuario = "root";
            contraseña = "1234";

            while(numIntentos > 0)

            {

                while (inputNombre != usuario || inputContraseña != contraseña)

                {
                  
                    MessageBox.Show("Te quedan: " + numIntentos);
                    numIntentos --;

                    inputNombre = Interaction.InputBox("Introduzca el nombre del Usuario: ");
                    inputContraseña = Interaction.InputBox("Introduzca la contraseña del Usuario: ");

                    if (numIntentos == 0 ) 

                    {

                        MessageBox.Show("No te quedan más intentos");

                    }

                }
                 
                if (inputNombre == usuario && inputContraseña == contraseña)

                {

                    MessageBox.Show("Bienvenido al sistema");
                    numIntentos = 0;

                }

            }
          
        }
    }
}


