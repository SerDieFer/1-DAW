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

        bool Bisiesto(int year)
        {
            bool bisiesto = false;

            if (year % 4 == 0)
            {
                bisiesto = true;

                if (year % 400 != 0 && year % 100 == 0)
                {
                    bisiesto = false;
                }
            }
            return bisiesto;
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            int year;

            bool esBisiesto;
            esBisiesto = false;

            string txtY, txtN;
            txtY = " es bisiesto";
            txtN = " no es bisiesto";

            year = int.Parse(Interaction.InputBox("Introduce el año: "));
            esBisiesto = Bisiesto(year);

            if (esBisiesto == true)
            {
            MessageBox.Show("El año " + year + txtY);
            }

            else
            {
            MessageBox.Show("El año " + year + txtN);
            }
        }
    }
}
