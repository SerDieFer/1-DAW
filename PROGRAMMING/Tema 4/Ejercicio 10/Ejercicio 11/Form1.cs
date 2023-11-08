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

namespace Ejercicio_11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Elevar (int num, int numpot)
        {
            int res = 1;

            for(int i = 1; i <= numpot; i++)
            {
            res *= num;
            }
            return res;
   
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            int num, pot2, pot5, pot7;
            string txt1, txt2, txt3, txtTotal;

            num = int.Parse(Interaction.InputBox("Introduce el número a elevar"));
        

            pot2 = Elevar(num, 2);
            pot5 = Elevar(num, 5);
            pot7 = Elevar(num, 7);

            txt1 = "El resultado de " + num + " elevado a 2 es: " + pot2 + "\n";
            txt2 = "El resultado de " + num + " elevado a 5 es: " + pot5 + "\n";
            txt3 = "El resultado de " + num + " elevado a 7 es: " + pot7;
            txtTotal = txt1 + txt2 + txt3;

            MessageBox.Show(txtTotal);

        }

    }
}
