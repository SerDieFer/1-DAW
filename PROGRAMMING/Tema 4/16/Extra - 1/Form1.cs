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

        int CalcularFactorial (int num)
        {
            int fac = 1;

            for(int i = 1; i <= num; i++)
            {
                fac *= i;

            }

            return fac;

        }

        private void btnmcm_Click(object sender, EventArgs e)
        {
            int num = int.Parse(Interaction.InputBox("Introduce el número a elevar"));

            int res = CalcularFactorial(num);

            MessageBox.Show(res.ToString());
       
        }
    }
}
