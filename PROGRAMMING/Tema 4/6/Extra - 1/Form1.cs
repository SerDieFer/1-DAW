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

        string Calculo(ref int n1, ref int n2, ref string resultado)
        {
            int division = n1 / n2;
            int resto = n1 % n2;

            resultado = "La división da como resultado: " + division + "\n\nMientras que su resto sería: " + resto;

            return resultado;
        }

        private void btnmcm_Click(object sender, EventArgs e)
        {
            int n1, n2;
            string resultado;
            resultado = "";
            n1 = int.Parse(Interaction.InputBox("Número 1"));
            n2 = int.Parse(Interaction.InputBox("Número 2"));
    

            Calculo(ref n1, ref n2, ref resultado);

            MessageBox.Show(resultado.ToString());

        }
    }
}
