using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Ejercicio_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        double[] horas = new double[3];
        void leerVector (double[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = double.Parse(Interaction.InputBox("Introduce la temperatura en la hora [" + i + "]:"));
            }
        }  
   
        double temperaturaMedia (double[] vector)
        {
            double media;
            double sumaTemp = vector[0];

            for (int i = 1; i < vector.Length; i++)
            {
                sumaTemp += vector[i];
            }

            media = Math.Round ((sumaTemp / (vector.Length)) , 2);
            return media;
        }

        string esMayorIgualMedia(double[] vector)
        {
            string txt = "";
            double media = temperaturaMedia(horas);

            for (int i = 0; i < vector.Length; i++)
            {
                if (vector[i] >= media)
                {
                    if (!string.IsNullOrEmpty(txt))
                    {
                        // Agrega una coma antes del siguiente número
                        txt += ", ";
                    }

                    // Agrega número al txt
                    txt += vector[i];
                }
            }

            // Agregar punto al final
            txt += ".";

            return txt;
        }

            string mostrarVector (double[] vector)
        {
            string txt = "Los valores del vector son: \n";

            for(int i = 0; i < vector.Length; i++)
            {
            
                if (i == (vector.Length - 1))
                {
                    txt += vector[i] + ".";
                }
                else
                {
                    txt += vector[i] + ", ";
                }
            }

            return txt;
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            leerVector(horas);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            double tMedia;
            string txtMostrar, txtResTemp, tMayorIgual = "";

            tMedia = temperaturaMedia(horas);
            tMayorIgual = esMayorIgualMedia(horas);

            txtMostrar = mostrarVector(horas);
            txtResTemp = "\n\nLa temperatura media será: " + tMedia + "\nLas temperaturas iguales " +
                "o mayores a la media serían: " + tMayorIgual;
                 
            MessageBox.Show(txtMostrar + txtResTemp);

        }
    }
}
