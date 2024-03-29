﻿using System;
using System.Windows.Forms;

namespace Ejercicio_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Creamos una función que designa el valorInroducido a un tipo de Billete/Moneda/Céntimo concreto.
        void CalcularResultado(ref int valorIntroducido, int valorTipo, ref string res, char tipoValor)
        {

            /* Inicializamos la cantidad de billetes/monedas/céntimos que tendremos, mediante el valor inicial de euros
             entre el valor que tiene el tipo de billete/moneda/céntimo. */
            int cantidadTipo = valorIntroducido / valorTipo;

            string nombreTipo = "";

            // String del nombre de la divisa (euros/cent)
            string nombreDivisa = " euros";


            // Comprobamos si este valor es mayor que 0 y que no sea uno (Para asignar el nombre en plural).
            if (cantidadTipo > 0 && cantidadTipo != 1)
            {
                // Si es tipo del valor asignado es un billete.
                if (tipoValor == 'b')
                {
                    // String del nombre del tipo.
                    nombreTipo = " billetes de ";

                }

                // Si es tipo del valor asignado es una moneda.
                else if (tipoValor == 'm')
                {

                    // String del nombre del tipo.
                    nombreTipo = " monedas de ";

                    if (valorTipo == 1)
                    {
                        nombreDivisa = " euro";
                    }

                }

                // Si es tipo del valor asignado es un céntimo.
                else
                {
                    // String del nombre del tipo.
                    nombreTipo = " monedas de ";

                    // String del nombre de la divisa (euros/cent)
                    nombreDivisa = " céntimos";

                    if (valorTipo == 1)
                    {
                        nombreDivisa = " céntimo";
                    }


                }
            }

            // Comprobamos si este valor es uno (Para asignar el nombre en singular).
            if (cantidadTipo == 1)
            {

                // Si es tipo del valor asignado es un billete.
                if (tipoValor == 'b')
                {
                    // String del nombre del tipo.
                    nombreTipo = " billete de ";

                }

                // Si es tipo del valor asignado es una moneda.
                else if (tipoValor == 'm')
                {

                    // String del nombre del tipo.
                    nombreTipo = " moneda de ";

                    if (valorTipo == 1)
                    {
                        nombreDivisa = " euro";
                    }

                }

                // Si es tipo del valor asignado es un céntimo.
                else
                {
                    // String del nombre del tipo.
                    nombreTipo = " moneda de ";

                    // String del nombre de la divisa (euros/cent)
                    nombreDivisa = " céntimos";

                    if (valorTipo == 1)
                    {
                        nombreDivisa = " céntimo";
                    }

                }

            }

            // Siempre y cuando tengamos una cantidad de billetes, monedas o céntimos.
            if (cantidadTipo != 0)
            {
                /* Resultado de la suma entre la cantidad de tipo (BILLETE/MONEDA/CENT) + su nombre asignado al string + el
                valor designado para este tipo. */
                res += cantidadTipo + nombreTipo + valorTipo + nombreDivisa +  "\n";

                /* Al valor inicial introducido le dejamos el resto despues de dividirlo entre el valor designado
                al tipo. */
                valorIntroducido %= valorTipo;
            }

        }


            private void btnCalcular_Click(object sender, EventArgs e)
            {

            // Con esto igualamos el valor del string al valor introducido en el input.
            string txtIni = txtValor.Text;
            string res = "";

            // Esto es debido a que queremos introducir céntimos en el input del valor.
            double valorIni;
            valorIni = double.Parse(txtIni);

            // Designamos el valor de los euros (Billetes y Monedas) en un número entero, dejando los céntimos de lado.
            int valorEur = (int)valorIni;

            /* Designamos el valor de los céntimos en un número entero, mediante la obtención del valor restante, al hacer la
              resta entre el valor inicial - el valor de este con decimales a 0 (x.00), dejandonos simplemente con los
              decimales que multiplicaremos por 100, obteniendo nuevamente un valor entero asignado a los decimales (Céntimos).

              En caso de no hacer math round me quita un céntimo por culpa del Int*/
            int valorCent = (int)Math.Round(((double)valorIni - valorEur) * 100);

            // Aqui calculo el valor de cada tipo distinto de billetes/monedas de euro.
            CalcularResultado(ref valorEur, 500, ref res, 'b');
            CalcularResultado(ref valorEur, 200, ref res, 'b');
            CalcularResultado(ref valorEur, 100, ref res, 'b');
            CalcularResultado(ref valorEur, 50, ref res, 'b');
            CalcularResultado(ref valorEur, 20, ref res, 'b');
            CalcularResultado(ref valorEur, 10, ref res, 'b');
            CalcularResultado(ref valorEur, 5, ref res, 'b');
            CalcularResultado(ref valorEur, 2, ref res, 'm');
            CalcularResultado(ref valorEur, 1, ref res, 'm');

            // Aqui calculo el valor de cada tipo distinto de céntimos de euro.
            CalcularResultado(ref valorCent, 50, ref res, 'c');
            CalcularResultado(ref valorCent, 20, ref res, 'c');
            CalcularResultado(ref valorCent, 10, ref res, 'c');
            CalcularResultado(ref valorCent, 5, ref res, 'c');
            CalcularResultado(ref valorCent, 2, ref res, 'c');
            CalcularResultado(ref valorCent, 1, ref res, 'c');

            // Aquí muestra el resultado final.
            lblResultados.Text = res;

        }
    }
}

