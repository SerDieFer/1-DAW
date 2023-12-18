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
       
        double[] horas = new double[8];
        void LeerVector (double[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = double.Parse(Interaction.InputBox("Introduce la temperatura en la hora [" + i + "]:"));
            }
        }  
   
        void TemperaturasMedia (double[] vector, out double tMedia)
        {
            tMedia = vector[0];
            double sumaTemp = vector[0];

            for (int i = 1; i < vector.Length; i++)
            {
                sumaTemp += vector[i];

            }

            tMedia = Math.Round ((sumaTemp / (vector.Length)) , 2);
        }

        string EsMayorIgualMedia(double[] vector, double tMedia)
        {
            string txt = "";

            for (int i = 0; i < vector.Length; i++)
            {
                if (vector[i] >= tMedia)
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

            string MostrarVector (double[] vector)
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
            LeerVector(horas);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            double tMedia;
            string txtMostrar, txtResTemp, tMayorIgual = "";

            TemperaturasMedia(horas, out tMedia);
            tMayorIgual = EsMayorIgualMedia(horas, tMedia);

            txtMostrar = MostrarVector(horas);
            txtResTemp = "\n\nLa temperatura media será: " + tMedia + "\nLas temperaturas iguales " +
                "o mayores a la media serían: " + tMayorIgual;
                 
            MessageBox.Show(txtMostrar + txtResTemp);

        }
    }
}
