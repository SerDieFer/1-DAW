using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Este programa lee caracteres introducidos por teclado,los almacena en una cadena, calcula cuales son los
                mayores y menores atendiendo a la tabla ASCII * También almacena el número de ellos que son mayúsculas */

            char minLetra = Char.MaxValue;
            char maxLetra = Char.MinValue;

            int numMayusculas = 0;

            bool salir = false;

            while (!salir)
            {
                //Leo una letra

                Console.WriteLine("Introduce una letra. Pulsa 0 si quieres salir: ");

                char letraAux = Console.ReadKey().KeyChar;

                Console.WriteLine("");
                Console.WriteLine("-------");

                if (letraAux == '0') 

                //Lee si la letra es igual a 0 o no, y en caso de ser 0 cambia a verdadero el bool salir.

                {
                    salir = true;
                }

                // Almaceno los menores y mayores (solo para letras entre 'A' y 'Z' en mayúsculas y minúsculas).
                
                if ((letraAux >= 'A' && letraAux <= 'Z') || (letraAux >= 'a' && letraAux <= 'z'))
                {

                    //Almaceno los menores y mayores. 

                    if (minLetra > letraAux)
                    {
                        minLetra = letraAux;
                    }

                    if (maxLetra < letraAux)
                    {
                        maxLetra = letraAux;
                    }

                    //Si la letra es mayusculas la contabiliza

                    if (char.IsUpper(letraAux))

                    //Esto detecta si es true or false directamente, viendo si es mayúscula.
                    //También funcionaría el método anterior ((letraAux > 'A') && (letraAux < 'Z'))

                    {
                        numMayusculas++;

                    }
                }
            }

            //Escribe el resultado

            Console.WriteLine("el Char menor es : " + maxLetra);
            Console.WriteLine("el Char mayor es : " + minLetra);
            Console.WriteLine("Hay " + numMayusculas + " letras mayusculas ");
            Console.ReadKey();

        }


    }
}

