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

        double CalcularPotencia (double num, int potencia)
        {
            for (int i = 1; i < potencia; i++)
            {
                num *= num;
            }

            return num;


        }

        private void btnmcm_Click(object sender, EventArgs e)
        {
            double num = double.Parse(Interaction.InputBox("Introduce el número a elevar"));
            int potencia = int.Parse(Interaction.InputBox("Introduce el valor de la potencia que elevará al número"));

            string resultado = CalcularPotencia(num, potencia).ToString();

            MessageBox.Show(resultado.ToString());
       
        }
    }
}
