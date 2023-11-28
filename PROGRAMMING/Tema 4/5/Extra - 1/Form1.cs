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

        string Calculo(ref double n1, ref double n2, ref string txt)
        {
            if (n1 < n2)
                txt = n2.ToString();
            else
                txt = n1.ToString();

            return txt;
    
        }

        private void btnmcm_Click(object sender, EventArgs e)
        {
            double n1, n2;
            n1 = double.Parse(Interaction.InputBox("Número 1"));
            n2 = double.Parse(Interaction.InputBox("Número 2"));
            string txt = "";

            Calculo(ref n1, ref n2, ref txt);

            MessageBox.Show(txt.ToString());

        }
    }
}
