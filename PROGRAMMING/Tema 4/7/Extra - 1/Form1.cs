using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

namespace Extra___1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Para calcular el Máximo Común Divisor, necesitamos averiguar que número es el más alto y posteriormente a esto
        // sabremos que el MCD no puede ser menor al número más pequeño, por ende deberemos encontrar un caso en el que
        // el resto de ambos sea un número entero respecto al número del bucle (empezando este por el número más pequeño)
        // mediante las itineraciones posteriores del bucle.
        string Calculo(ref int n1, ref int n2, ref string resultado)
        {
            // Inicialización de variables
            int MCD = 0;
            bool encontrado = false;

            // Verificar cuál número es mayor.
            if (n2 > n1)
            {
                // Bucle para el caso en que n2 es mayor que n1.
                for (int i = n2; encontrado == false; i--)
                {
                    // Verificar si i es divisor común de n2 y n1.
                    if (n2 % i == 0 && n1 % i == 0)
                    {
                        // Asignar el divisor común como MCD.
                        MCD = i;
                        // Marcar como encontrado y salir del bucle.
                        encontrado = true;
                    }
                }
            }
            else
            {
                // Bucle para el caso en que n1 es mayor o igual que n2.
                for (int i = n1; encontrado == false; i--)
                {
                    // Verificar si i es divisor común de n1 y n2.
                    if (n1 % i == 0 && n2 % i == 0)
                    {
                        // Asignar el divisor común como MCD.
                        MCD = i;
                        // Marcar como encontrado y salir del bucle.
                        encontrado = true;
                    }
                }
            }

            // Convertir el resultado a cadena y asignarlo a la variable resultado.
            resultado = MCD.ToString();

            // Devolver el resultado.
            return resultado;
        }

        private void btnmcm_Click(object sender, EventArgs e)
        {
            int n1, n2;
            string resultado;
            resultado = "";
            n1 = int.Parse(Interaction.InputBox("Número 1"));
            n2 = int.Parse(Interaction.InputBox("Número 2"));
    

            Calculo(ref n1, ref n2, ref resultado);

            MessageBox.Show(resultado.ToString());

        }
    }
}
