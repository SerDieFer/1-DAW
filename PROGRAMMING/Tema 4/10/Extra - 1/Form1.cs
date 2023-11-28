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

        int CalcularPotencia (int num, int potencia)
        {
            int res = num;

            for (int i = 1; i < potencia; i++)
            {
                res *= num;
            }

            return res;

        }

        private void btnmcm_Click(object sender, EventArgs e)
        {
            int num = int.Parse(Interaction.InputBox("Introduce el número a elevar"));

            int res1 = CalcularPotencia(num, 2);
            int res2 = CalcularPotencia(num, 5);
            int res3 = CalcularPotencia(num, 7);

            string resFinal = "Elevado a 2 sería: " + res1 + "\nMientras que elevado a 5 sería: " +  res2 + "\n" +
            "Finalmente elevado a 7 sería: " + res3;
            MessageBox.Show(resFinal);
       
        }
    }
}
