using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] matricula = new string[5];
            int nota;
            bool matriculaNula = false;
            bool notaCorrecta = false;

            for (int i = 0; i < 5 && !matriculaNula; i++)
            {
                Console.WriteLine("Introduzca el valor Nº" + (i + 1) + " de la matrícula: ");
                matricula[i] = Console.ReadLine();

                if (!char.IsLetter(matricula[0][0]))
                {
                    Console.WriteLine("\nEl primer carácter debe ser una letra.");
                    i--;
                    matriculaNula = true;
                }
            }

            if (!matriculaNula)
            {
                do
                {
                    Console.WriteLine("Introduzca el valor de la nota de esta matrícula: ");
                    nota = int.Parse(Console.ReadLine());
                    if (nota < 0 || nota > 10)
                    {
                        Console.WriteLine("\nLa nota debe de estar entre 0 y 10");
                    }
                    else
                    {
                        notaCorrecta = true;
                    }
                } while (!notaCorrecta);
            }
        }
    }
}
