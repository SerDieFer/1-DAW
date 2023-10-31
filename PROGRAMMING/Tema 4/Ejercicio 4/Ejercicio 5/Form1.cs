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


        double absoluto (double num)
        {
           double res;
           res = num;

           if (num < 0 )
            
           {

             res = -num;   

           }

            return res;

        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            double num, res;

            num = double.Parse(txtBoxN1.Text);
            res = absoluto(num);

            MessageBox.Show("El número " + num + " tendría como valor absoluto: " + res);
        }



    }
}

