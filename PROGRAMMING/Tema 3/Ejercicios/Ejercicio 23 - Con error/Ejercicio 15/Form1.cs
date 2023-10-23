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
            double numPeso, pesoMedio,suma, numAlu, pluma, ligero, medio, pesado, pPluma, pLigero, pMedio, pPesado;
            string txt, txtTotal, txtMedio, txtPorcentajes, txtPl, txtL, txtM, txtPe;

            numAlu = suma = pesoMedio = pluma = ligero = medio = pesado = 0;
            txt = txtTotal = txtMedio = txtPorcentajes = txtPl = txtL = txtM = txtPe = "";

            numPeso = int.Parse(Interaction.InputBox("Introduce el peso"));

                while (numPeso >= 0)

                {

                        if(numPeso >= 0 && numPeso <= 50)

                        {
                        pluma++;
                        }

                        if (numPeso > 50 && numPeso <= 65)

                        {
                        ligero++;
                        }

                        if (numPeso > 65 && numPeso <= 80)

                        {
                        medio++;
                        }

                        if (numPeso > 80)

                        {
                        pesado++;
                        }


                numAlu++;
                suma += numPeso;
                numPeso = int.Parse(Interaction.InputBox("Introduce un número"));

                txtPl = "Hay " + pluma + " alumnos que pesan menos de 50 Kg.\n";
                txtL = "Hay " + ligero + " alumnos que pesan entre 50 Kg y 65 Kg.\n";
                txtM = "Hay " + medio + " alumnos 65 Kg y 80 Kg.\n";
                txtPe = "Hay " + pesado + " alumnos que pesan más de 80 Kg.\n\n";

                pesoMedio = (double)suma / (double) numAlu;
                txtMedio = "El peso medio es de: " + pesoMedio + " Kg.\n\n";

                pPluma = (pluma / numAlu) * 100;
                pLigero = (ligero / numAlu) * 100;
                pMedio = (medio / numAlu) * 100;
                pPesado = (pesado / numAlu) * 100;
                txtPorcentajes = "El porcentaje de alumnos quedaría así:\n\n" + pPluma + " % de alumnos es de peso pluma.\n" + pLigero +
                " % es de alumnos de peso ligero. \n" + pMedio + " % es de alumnos de peso medio.\n" + pPesado + " % es de alumnos de peso pesado.";

                //Si coloco aquí el txt me muestra mal el número total de alumnos, pero no termino entender
                //de manera lógica el porque me muestra solo el resultado de la anterior itineración si hago esto.
                    txt = txtPl + txtL + txtM + txtPe + txtTotal + txtMedio + txtPorcentajes;

                txtTotal = "Habría un total de " + numAlu + " de alumnos.\n\n";

                //Si coloco aquí el txt lo muestra bien al ser la itineración final del bucle
                    // txt = txtPl + txtL + txtM + txtPe + txtTotal + txtMedio + txtPorcentajes;
        
            }

            //Entiendo que si saco fuera del bucle todo lo anterior, no ocurriría este error,
            //debido a que los cálculos los hace fuera del bucle, quedando de manera mucho más correcta, así:

            // txtPl = "Hay " + pluma + " alumnos que pesan menos de 50 Kg.\n";
            // txtL = "Hay " + ligero + " alumnos que pesan entre 50 Kg y 65 Kg.\n";
            // txtM = "Hay " + medio + " alumnos 65 Kg y 80 Kg.\n";
            // txtPe = "Hay " + pesado + " alumnos que pesan más de 80 Kg.\n\n";
            // txtTotal = "Habría un total de " + numAlu + " de alumnos.\n\n";

            // pesoMedio = (double)suma / (double)numAlu;
            // txtMedio = "El peso medio es de: " + pesoMedio + "\n\n";

            // pPluma = (pluma / numAlu) * 100;
            // pLigero = (ligero / numAlu) * 100;
            // pMedio = (medio / numAlu) * 100;
            // pPesado = (pesado / numAlu) * 100;
            // txtPorcentajes = "El porcentaje de alumnos quedaría así:\n\n" + pPluma + " % de alumnos de peso pluma.\n" + pLigero +
            // " % de alumnos de peso ligero. \n" + pMedio + " % de alumnos de peso medio.\n" + pPesado + " % de alumnos de peso pesado.";
           
            // txt = txtPl + txtL + txtM + txtPe + txtTotal + txtMedio + txtPorcentajes;

            MessageBox.Show(txt);

            }
        }
    }

    

