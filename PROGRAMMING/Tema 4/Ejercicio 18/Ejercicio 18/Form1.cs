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

namespace Ejercicio_18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double Serie(int m, int n)
        {

            double resultadoS = 0;

            for (int i = 1; i <= n; i++)

            {
                resultadoS += (double) Potencia(m, i) / Factorial(i);

            }

            return resultadoS;

        }

        int Potencia(int m, int n)
        {
            int resultadoP = 1;
            // Inicializa el resultadoP con el valor original de nPotenciaBase, que vendría precedido por numM.

            for (int i = 1; i <= n; i++)
            {

                resultadoP *= m;
                // Multiplica el resultadoP iniciado en 1 y posteriormente repetido
                // en cada itineracion, siendo este multiplicado por el resultado siguiente, continuando las itineraciones.

            }

            return resultadoP;  
            // Devuelve el resultadoP de elevar nPotencia a sí mismo.
        }

        int Factorial(int n)
        {
            int resultadoF = 1;  
            // Inicializa el resultadoF con 1, el factorial de 0, que vendría precedido por numN.

            for (int i = 1; i <= n; i++)
            {
                resultadoF *= i;  
                // Calcula el factorial multiplicando por cada número de 1 a nFactorial.
            }

            return resultadoF;  
            // Devuelve el factorial de nFactorial.
        }

        private void btnSerie_Click(object sender, EventArgs e)
        {
            int numN, numM;
            double res;
            string txtN, txtM;

            txtM = Interaction.InputBox("Introduzca el número M para designar el valor que tomará el número a elevar:" +
            " \n\n\n" + "m + (m^2/ 2!) + (m^3/ 3!) + (m^4/ 4!) + (m^n/ n!)");

            txtN = Interaction.InputBox("Introduzca el número N para designar el límite operacional de la siguiente serie:" +
                " \n\n\n" + "m + (m^2/ 2!) + (m^3/ 3!) + (m^4/ 4!) + (m^n/ n!)");


            numM = int.Parse(txtM);
            numN = int.Parse(txtN);


            res = Serie(numM,numN);
            // Inicializa el valor del resultado con el numM.


            MessageBox.Show(res.ToString());  
            // Muestra el resultado de la serie.
        }
    }
}