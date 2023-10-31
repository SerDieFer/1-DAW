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


        int absoluto (int n1)
        {
           int res;

           if (n1 < 0 )
            
           {

             n1 = n1 * (-1);   

           }

            res = n1;

            return res;

        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            int num1, res;

            num1 = int.Parse(txtBoxN1.Text);
            res = absoluto(num1);

            MessageBox.Show("El número " + num1 + " tendría como valor absoluto: " + res);
        }



    }
}

