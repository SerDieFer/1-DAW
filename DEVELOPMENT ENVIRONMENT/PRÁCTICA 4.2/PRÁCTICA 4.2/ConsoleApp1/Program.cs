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
            bool matriculaCorrecta = false;
            bool notaCorrecta = false;


            if (!matriculaCorrecta)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("Introduzca el valor Nº" + (i + 1) + " de la matrícula: ");
                    matricula[i] = Console.ReadLine();

                    if (!char.IsLetter(matricula[0][0]))
                    {
                        Console.WriteLine("\nEl primer carácter debe ser una letra.\n");
                        i--;
                    }
                    else if(i == 4)
                    {
                        Console.WriteLine("\nLa matrícula ha sido almacenada correctamente.\n");
                        matriculaCorrecta = true;
                    }   
                }
            }

            if (matriculaCorrecta)
            {
                do
                {
                    Console.Write("Introduzca el valor de la nota de esta matrícula: ");
                    nota = int.Parse(Console.ReadLine());
                    if (nota < 0 || nota > 10)
                    {
                        Console.WriteLine("\nLa nota debe de estar entre 0 y 10.\n");
                    }
                    else
                    {
                        notaCorrecta = true;
                        Console.WriteLine("\nLa nota de la matrícula ha sido almacenada correctamente.\n");
                        Console.ReadKey();
                    }
                } while (!notaCorrecta);
            }
        }
    }
}
