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

        void Calculo(int n1, int n2, out int division, out int resto)
        {

            division = n1 / n2;
            resto = n1 % n2;

        }

        private void btnmcm_Click(object sender, EventArgs e)
        {
            int n1, n2, division, resto;
            n1 = int.Parse(Interaction.InputBox("Número 1"));
            n2 = int.Parse(Interaction.InputBox("Número 2"));

            Calculo(n1, n2, out division, out resto);

            MessageBox.Show(division + " " + resto);

        }
    }
}
