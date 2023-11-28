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

        string Calculo(ref int n1a, ref int n2a, ref string txt)
        {
            int n1b, n2b;

            n2b = n1a;
            n1b = n2a;

            txt = "Los números " + n1a + " " + n2a +" cambiarán a: " + n1b + " " + n2b;
                
            return txt;
    
        }

        private void btnmcm_Click(object sender, EventArgs e)
        {
            int n1a, n2a;
            n1a = int.Parse(Interaction.InputBox("Número 1"));
            n2a = int.Parse(Interaction.InputBox("Número 2"));
            string txt = "";

            Calculo(ref n1a, ref n2a, ref txt);

            MessageBox.Show(txt.ToString());

        }
    }
}
