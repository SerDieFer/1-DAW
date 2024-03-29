﻿using System;
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

        double CalcularMedia(double nota1, double nota2, double nota3)
        {
            double sumaNotas;
            sumaNotas= (nota1 + nota2 + nota3) / 3;
            return sumaNotas;
        }

        bool NumeroCorrecto (double nota)
        {
            bool valido = false;

            if (nota >= 0 && nota <= 10)
            {
            valido = true;
            }

            return valido;

        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            string txtRes;
            double nota1, nota2, nota3, media;

            media = 0;

            nota1 = double.Parse(Interaction.InputBox("Introduzca la nota número 1: "));
            nota2 = double.Parse(Interaction.InputBox("Introduzca la nota número 2: "));
            nota3 = double.Parse(Interaction.InputBox("Introduzca la nota número 3: "));

            if (NumeroCorrecto(nota1) && NumeroCorrecto(nota2) && NumeroCorrecto(nota3))
            {
            media = CalcularMedia(nota1,nota2,nota3);
            txtRes= ("La media de las notas es: " + media);
            MessageBox.Show(txtRes);
            }

            else
            {
            MessageBox.Show("Las notas deben estar entre 0 y 10.");
            }
        }   
    }
}

