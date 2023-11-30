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

namespace Ejercicio_15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {

            int pluma, ligero, medio, pesado, alumTotal;
            double sumaPesos, pesoMedio, Ppluma, Pligero, Pmedio, Ppesado;
            double peso = double.Parse(Interaction.InputBox("Introduce el peso de cada Alumno"));


            pluma = ligero = medio = pesado = alumTotal = 0;
            pesoMedio = sumaPesos = 0;

            while (peso>=0)
            {
                if(peso <=50)
                {
                    pluma++;
                }

                else if (peso <= 65)
                {
                    ligero++;
                }

                else if(peso <= 80)
                {
                    medio++;
                }

                else
                {
                    pesado++;
                }

                alumTotal++;
                sumaPesos += peso;
                peso = double.Parse(Interaction.InputBox("Introduce el peso de cada Alumno"));
            }

            string txtAluTotal = "El número total de alumnos es: " + alumTotal;

            pesoMedio = sumaPesos / (double) alumTotal;
            string txtPesoMedio = "La media de peso de los alumnos es: " + pesoMedio;

            string txtTiposPeso = 
            "Alumnos que pesen 50 Kg o menos: " + pluma + "\n" +
            "Alumnos que pesen 65 Kg o menos: " + ligero + "\n" +
            "Alumnos que pesen 80 Kg o menos: " + medio + "\n" +
            "Alumnos que pesen más de 80 Kg: " + pesado + "\n";

            Ppluma = (double) pluma / alumTotal * 100;
            Pligero = (double) ligero / alumTotal * 100;
            Pmedio = (double) medio / alumTotal * 100;
            Ppesado = (double) pesado / alumTotal * 100;

            string txtPorcentajes = 
            "Hay un " + Math.Round(Ppluma, 2) + "% de alumnos de peso pluma\n" +
            "Hay un " + Math.Round(Pligero, 2) + "% de alumnos de peso ligero\n" +
            "Hay un " + Math.Round(Pmedio, 2) + "% de alumnos de peso medio\n" +
            "Hay un " + Math.Round(Ppesado, 2) + "% de alumnos de peso pesado\n";

            string txtResultados = txtAluTotal + "\n" + txtPesoMedio + "\n" + txtTiposPeso + "\n" + txtPorcentajes;

            MessageBox.Show(txtResultados);
        }
    }
}

    

