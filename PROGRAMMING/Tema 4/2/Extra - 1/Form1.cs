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

        bool Calculo(ref int n1, ref int n2, ref bool esDivisible)
        {

            if(n1 % n2 == 0 || n2 % n1 == 0)
            {
                esDivisible = true;
            }

            else
            {
                esDivisible = false;
            }
                
            return esDivisible;
    
        }

        private void btnmcm_Click(object sender, EventArgs e)
        {
            int n1, n2;
            bool esDivisible = false;
            n1 = int.Parse(Interaction.InputBox("Número 1"));
            n2 = int.Parse(Interaction.InputBox("Número 2"));

            Calculo(ref n1, ref n2, ref esDivisible);

            MessageBox.Show(esDivisible.ToString());
        }
    }
}
