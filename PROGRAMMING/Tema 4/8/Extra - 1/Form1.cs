using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

namespace Extra___1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool NotasValidas (ref double n1, ref double n2, ref double n3, ref bool validez)
        { 

            if((n1 <= 10 && n1 >= 0) && (n2 <= 10 && n2 >= 0) && (n3 <= 10 && n3 >= 0))
            {
                validez = true;
            }
            else
            {
                validez = false;
            }

        return validez;
        }


    
        string CalculoMedia(ref double n1, ref double n2, ref double n3, ref bool validez, ref string resultado)
        {
            bool comprobar = NotasValidas(ref n1, ref n2, ref n3, ref validez);

            if (comprobar == true)
            {
                double calculo = ((n1 + n2 + n3) / 3);
                resultado = calculo.ToString();
            }

            else
            {
                resultado = "Las notas introducidas no son válidas, introduce valores válidos (>= 0 & <= 10)";
            }
            
            return resultado;
        }

        private void btnmcm_Click(object sender, EventArgs e)
        {
            double n1, n2, n3;
            n1 = double.Parse(Interaction.InputBox("Nota 1"));
            n2 = double.Parse(Interaction.InputBox("Nota 2"));
            n3 = double.Parse(Interaction.InputBox("Nota 3"));

            bool validez = false;
            string resultado = "";

            validez = NotasValidas(ref n1, ref n2, ref n3, ref validez);
            CalculoMedia(ref n1, ref n2, ref n3, ref validez, ref resultado);
            MessageBox.Show(resultado.ToString());
       
        }
    }
}
