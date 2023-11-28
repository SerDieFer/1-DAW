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

        int Calculo(ref int n1, ref int n2, ref int res)
        {
            res = n1 + n2;
            return res;
    
        }

        private void btnmcm_Click(object sender, EventArgs e)
        {
            int n1, n2, res;
            res = 0;
            n1 = int.Parse(Interaction.InputBox("Número 1"));
            n2 = int.Parse(Interaction.InputBox("Número 2"));

            Calculo(ref n1, ref n2, ref res);

            MessageBox.Show(res.ToString());
        }
    }
}
