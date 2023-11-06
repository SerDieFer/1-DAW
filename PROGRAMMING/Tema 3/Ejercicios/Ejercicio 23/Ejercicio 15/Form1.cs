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

        int numAlu, pluma, ligero, medio, pesado;
        double numPeso, pesoMedio, suma, pPluma, pLigero, pMedio, pPesado;
        string txt, txtTotal, txtMedio, txtPorcentajes, txtPl, txtL, txtM, txtPe;

        suma = pesoMedio = 0;
        numAlu = pluma = ligero = medio = pesado = 0;
        txt = txtTotal = txtMedio = txtPorcentajes = txtPl = txtL = txtM = txtPe = "";

        numPeso = double.Parse(Interaction.InputBox("Introduce el peso"));

            while (numPeso >= 0) 
            {

                    if(numPeso >= 0 && numPeso <= 50) 
                    {
                    pluma++;
                    }

                    else if (numPeso <= 65) 
                    { 
                    ligero++;
                    }

                    else if (numPeso <= 80) 
                    {
                    medio++;
                    }

                    else if (numPeso > 80) 
                    { 
                    pesado++;
                    }

            numAlu++;
            suma += numPeso;
            numPeso = double.Parse(Interaction.InputBox("Introduce un número"));
            }

        txtPl = "Hay " + pluma + " alumnos que pesan menos de 50 Kg.\n";
        txtL = "Hay " + ligero + " alumnos que pesan entre 50 Kg y 65 Kg.\n";
        txtM = "Hay " + medio + " alumnos 65 Kg y 80 Kg.\n";
        txtPe = "Hay " + pesado + " alumnos que pesan más de 80 Kg.\n\n";
        txtTotal = "Habría un total de " + numAlu + " de alumnos.\n\n";

        pesoMedio = (double)suma / (double)numAlu;
        txtMedio = "El peso medio es de: " + pesoMedio.ToString("0.00") + " Kg. \n\n";

        pPluma = (double)(pluma / (double)numAlu) * 100;
        pLigero = (double)(ligero / (double)numAlu) * 100;
        pMedio = (double)(medio / (double)numAlu) * 100;
        pPesado = (double)(pesado / (double)numAlu) * 100;
        txtPorcentajes = "El porcentaje de alumnos quedaría así:\n\n" + pPluma.ToString("0.00") 
        + " % de alumnos es de peso pluma.\n" + pLigero.ToString("0.00") + " % de alumnos es de peso ligero. "
        + "\n" + pMedio.ToString("0.00") + " % de alumnos es de peso medio.\n" + pPesado.ToString("0.00")
        + " % es de alumnos de peso pesado.";

        txt = txtPl + txtL + txtM + txtPe + txtTotal + txtMedio + txtPorcentajes;

        MessageBox.Show(txt);

        }
    }
}

    

