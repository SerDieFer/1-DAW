using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Ejercicio_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void calcularDivResto (int num1, int num2, out  int div, out int resto)
        {
            div = num1 / num2;
            resto = num1 % num2;

        }


        private void btnCal_Click(object sender, EventArgs e)
        {
            int num1, num2, div, resto;
            string res;


            num1 = int.Parse(Interaction.InputBox("Introduce él número inicial"));
            num2 = int.Parse(Interaction.InputBox("Introduce él número secundario"));

            calcularDivResto(num1, num2, out resto, out div);
            res= "La división dará como resultado: " +  resto + "\n\nMientras que de resto daría: " + div;
            MessageBox.Show(res);
        }
    }
}
