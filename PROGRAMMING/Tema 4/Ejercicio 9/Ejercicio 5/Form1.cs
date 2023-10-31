using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        int elevar (int numBase, int exponente)
        {

            int res = 1;

            for (int i = 1; i <= exponente; i++)
            {

            res *= numBase;

            }

            return res;


        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            int num1, num2, res;

            num1 = int.Parse(txtBoxN1.Text);
            num2 = int.Parse(txtBoxN2.Text);

            res = elevar(num1, num2);

            MessageBox.Show("El número " + num1 + " elevado al número " + num2 + " sería: " + res);
        }



    }
}

