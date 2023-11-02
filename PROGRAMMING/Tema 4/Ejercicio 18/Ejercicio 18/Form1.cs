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

        int Potencia(int nPotencia)
        {
            int resultadoP = nPotencia;  
            // Inicializa el resultadoP con el valor original de nPotencia, que vendría precedido por numM.

            for (int i = 1; i < nPotencia; i++)
            {
                nPotencia *= nPotencia;  
                // Multiplica el resultadoP por nPotencia en cada iteración.
            }

            return resultadoP;  
            // Devuelve el resultadoP de elevar nPotencia a sí mismo.
        }

        int Factorial(int nFactorial)
        {
            int resultadoF = 1;  
            // Inicializa el resultadoF con 1, el factorial de 0, que vendría precedido por numN.

            for (int i = 1; i <= nFactorial; i++)
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
            double res, numPotencia, numDivFac;
            string txtN, txtM;

            txtN = Interaction.InputBox("Introduzca el número N para designar el límite operacional de la siguiente serie:" +
                " \n\n\n" + "m + (m^2/ 2!) + (m^3/ 3!) + (m^4/ 4!) + ……… + (m^n/ n!)");

            txtM = Interaction.InputBox("Introduzca el número M para designar el valor que tomará el número a elevar:" +
                " \n\n\n" + "m + (m^2/ 2!) + (m^3/ 3!) + (m^4/ 4!) + ……… + (m^n/ n!)");

            numM = int.Parse(txtM);
            numN = int.Parse(txtN);

            res = numM;  
            // Inicializa res con numM.
            numPotencia = Potencia(numM);  
            // Calcula M elevado a sí mismo.
            numDivFac = Factorial(numN);  
            // Calcula el factorial de numN.

            for (int i = 2; i <= numN; i++)
            {
                numPotencia *= numM;  
                // Actualiza numPotencia en cada iteración.
                numDivFac *= i;  
                // Actualiza numDivFac en cada iteración.

                res += ((numN * numPotencia) / (numDivFac));  
                // Calcula y suma los términos de la serie.
            }

            MessageBox.Show(res.ToString());  
            // Muestra el resultado de la serie.
        }
    }
}