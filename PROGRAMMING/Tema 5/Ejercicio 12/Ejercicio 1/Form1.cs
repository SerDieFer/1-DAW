using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace Ejercicio_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        double[] horas = new double[24];
        void LeerVector(double[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = double.Parse(Interaction.InputBox("Introduce la temperatura en la hora [" + i + "]:"));
            }
        }  
   
        void TemperaturasMedia(double[] vector, out double tMax, out double tMin, out double tMedia)
        {
            tMedia = tMin = tMax = vector[0];
        
            double sumaTemp = 0;


            for (int i = 1; i < vector.Length; i++)
            {

                if (vector[i] > tMax)
                {
                    tMax = vector[i];
                }

                else if (vector[i] < tMin)
                {
                    tMin = vector[i];
                }

                sumaTemp += vector[i];
            }

            tMedia = Math.Round ((sumaTemp / (vector.Length - 1)) , 2);

        }

        string MostrarVector(double[] vector)
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
            double tMin, tMax, tMedia;

            TemperaturasMedia(horas, out tMax, out tMin, out tMedia);

            string txtMostrar, txtResTemp;

            txtMostrar = MostrarVector(horas);
            txtResTemp = "\n\nLa temperatura mínima será: " + tMin + "\nLa temperatura máxima será: " + tMax +
                "\nLa temperatura media será: " + tMedia;
                 
            MessageBox.Show(txtMostrar + txtResTemp);

        }
    }
}
