using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

        // Muy rara esta forma, no usar.
        int FormaDemasiadoComplejaCalculoMCM(int n1, int n2)
        {
            // Olvida este método, muy retorcido.

            // Para averiguar el mcm necesitamos obtener el número común más cercano, siempre que los numeros aportados se multipliquen x2.
            int mcm, div;
            // Por esto el primer valor del m.c.m es 1.
            mcm = 1;
            // El primer divisor empezará por 2.
            div = 2;

            //Por si n1 y/o n2 son negativos,.
            if (n1 < 0)
            {
                n1 = -n1;
            }
            if (n2 < 0)
            {
                n2 = -n2;
            }

            // Mientras que los divisores sean menores o iguales a los números designados.
            while (div <= n1 || div <= n2)
            {
                // Mientras que los divisores sean menores o iguales a los números designados además de que la division
                // del número entre el divisor tenga como resto un número entero, siendo por ende div un factor común en n1 o n2.
                while (div <= n1 && n1 % div == 0 || div <= n2 && n2 % div == 0)
                {
                    // El m.c.m será igual a la multiplicación de este por el divisor que cumpla las condiciones.
                    mcm = mcm * div;

                    // Mientras que el divisor sea igual o menor que el n1, además de que el resto del n1 entre el divisor concreto sea 
                    // un número entero.
                    if(div <= n1 && n1 % div == 0)
                    {
                        // Actualiza el n1 dependiendo del divisor, que da como resultado un nuevo n1, que se reutilizará en la siguiente
                        // itineración del bucle hasta que el divisor sea mayor que el número.
                        n1 = n1 / div;
                    }
                    // Mientras que el divisor sea igual o menor que el n2, además de que el resto del n2 entre el divisor concreto sea 
                    // un número entero.
                    if (div <= n2 && n2 % div == 0)
                    {
                        // Actualiza el n2 dependiendo del divisor, que da como resultado un nuevo n2, que se reutilizará en la siguiente
                        // itineración del bucle hasta que el divisor sea mayor que el número.
                        n2 = n2 / div;
                    }

                }

                // esto aumenta el divisor en 1 en 1 hasta que las condiciones del bucle no se puedan seguir cumpliendo.
                div++;
            }
            return mcm;
        }

        // Hayas el MCD para calcular con este el MCM.
        int FormaHayarMCDCalculoMCM(int n1, int n2)
        {
            // Hayamos el MCD (Máximo común divisor)
            int MCD = 1;

            if (n1 > n2)
            {
                // Si n1 es mayor, realiza un bucle desde 2 hasta n2-1
                for (int i = 2; i < n2; i++)
                {
                    // Comprueba si i es un divisor común de n1 y n2
                    if (n1 % i == 0 && n2 % i == 0)
                    {
                        // Si i es divisor común, actualiza el MCD
                        MCD = i;
                    }
                }
            }
            else
            {
                // Si n2 es mayor o igual a n1, realiza un bucle desde 2 hasta n1-1
                for (int i = 2; i < n1; i++)
                {
                    // Comprueba si i es un divisor común de n1 y n2
                    if (n1 % i == 0 && n2 % i == 0)
                    {
                        // Si i es divisor común, actualiza el MCD
                        MCD = i;
                    }
                }
            }
            return MCD;
        }

        // Calculas el MCM.
        int FormaMedianteMCDCalculoMCM(int n1, int n2)
        {
            // A continuación mediante el MCD obtenemos el resultado del MCM.
            int MCD = FormaHayarMCDCalculoMCM(n1, n2);

            int MCM = (n1 * n2) / MCD;

            return MCM;
        }

        // Forma con 2 bucles.
        int Forma2CalculoMCM(int n1, int n2)
        {

            //Método Santi con 2 bucles
            int mcm = 0;
            bool encontrado = false;

            // Comienza un bucle que se ejecuta hasta que se encuentra el MCM.
            for (int i = 1; !encontrado; i++)
            {
                /* Dentro del bucle externo, se inicia otro bucle con 'j'.
                 Este bucle se ejecuta mientras 'j' sea menor o igual a (i * n1)
                 y mientras no se haya encontrado aún el MCM. */
                for (int j = 1; j <= (n1 * i) && !encontrado; j++)
                {
                    // Comprueba si 'n1 * i' es igual a 'n2 * j'.
                    // Si es así, significa que ha encontrado el MCM.
                    if ((n1 * i) == (n2 * j))
                    {
                        // Asigna el valor del MCM a la variable 'mcm'.
                        mcm = (n1 * i);
                        encontrado = true;
                    }
                }
            }
            return mcm;
        }

        // Forma con 1 sólo bucle.
        int Forma1CalculoMCM(int n1, int n2)
        {
            //Método más corto
            int mcm = 0;
            bool encontrado = false;

            // Comienza un bucle que se ejecuta hasta que se encuentra el MCM.
            for (int i = 1; !encontrado; i++)
            {
                // Verifica si al multiplicar 'n1' por 'i' se obtiene un número divisible por 'n2'.
                if ((n1 * i) % n2 == 0)
                {
                    // Si es divisible, asigna ese número a la variable 'mcm'.
                    mcm = n1 * i;
                    encontrado = true;
                    }
                }
            return mcm;
        }



        private void btnmcm_Click(object sender, EventArgs e)
        {
            int n1, n2;
            n1 = int.Parse(Interaction.InputBox("Número 1 a calcular el m.c.m"));
            n2 = int.Parse(Interaction.InputBox("Número 2 a calcular el m.c.m"));

            string mcm = Forma1CalculoMCM(n1, n2).ToString();

            MessageBox.Show(mcm.ToString());
        }
    }
}
