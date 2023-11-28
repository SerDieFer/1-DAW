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

        double Calculo(ref double n1)
        {
            if (n1 < 0)
                n1 = (-n1);

            return n1;
    
        }

        private void btnmcm_Click(object sender, EventArgs e)
        {
            double n1;
            n1 = double.Parse(Interaction.InputBox("Número 1"));

            Calculo(ref n1);

            MessageBox.Show(n1.ToString());

        }
    }
}
