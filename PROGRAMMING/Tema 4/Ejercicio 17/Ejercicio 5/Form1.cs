using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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


        int divisionResta (int n1, int n2)
        {

            int res = 0;

            while (n1 >= n2)
            {
                n1 -= n2;
                res++;
            }
        
            return res;

        }

        int divisionResto(int n1, int n2)
        {

            int resto = n1 % n2;

            return resto;

        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            int num1, num2, resto, res;

            num1 = int.Parse(txtBoxN1.Text);
            num2 = int.Parse(txtBoxN2.Text);

            res = divisionResta(num1,num2);
            resto = divisionResto(num1, num2);

            MessageBox.Show("La división del " + num1 + " entre el número " + num2 + " tendría como divisor el: " + res 
                + " y el resto quedaría en: " + resto );
        }



    }
}

