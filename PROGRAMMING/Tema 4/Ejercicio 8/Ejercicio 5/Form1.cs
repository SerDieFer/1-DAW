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

namespace Ejercicio_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double CalcularMedia ()
        {
            double sumaNotas = 0;

            for (int i = 1; i <= 3; i++)
            {
                double nota;
                nota = double.Parse(Interaction.InputBox("Introduzca las notas obtenidas: "));

                if (NumeroCorrecto(nota))
                {
                sumaNotas += nota / 3;
                }

                else
                {
                MessageBox.Show("La nota debe estar entre 0 y 10.");
                i--;
                }
            }

            return sumaNotas;
        }

        //double CalcularMedia(double nota1, double nota2, double nota3)
        //{
        //double sumaNotas;
        //sumaNotas= (nota1 + nota2 + nota3) / 3;
        //return sumaNotas;
        //}

    bool NumeroCorrecto (double nota)
        {
            if (nota >= 0 && nota <= 10)
            {
            return true;
            }

            else
            {
            return false;
            }
        }


        private void btnCal_Click(object sender, EventArgs e)
        {
            string txtRes;
            double res;

            res = CalcularMedia();
            txtRes = res.ToString();

            MessageBox.Show(txtRes);

            //string txtRes;
            //double nota1, nota2, nota 3, media;

            //media = 0;

            //nota1 = double.Parse(Interaction.InputBox("Introduzca la nota número 1: "));
            //nota2 = double.Parse(Interaction.InputBox("Introduzca la nota número 2: "));
            //nota3 = double.Parse(Interaction.InputBox("Introduzca la nota número 3: "));

            //if (NumeroCorrecto(nota1) && NumeroCorrecto(nota2) && NumeroCorrecto(nota3))
            //{
            //media = CalcularMedia(nota1,nota2,nota3);
            //txtRes= ("La media de las notas es: " + media);
            //MessageBox.Show(txtRes);
            //}

            //else
            //{
            //MessageBox.Show("Las notas deben estar entre 0 y 10.");
            //}

        }   
    }
}

