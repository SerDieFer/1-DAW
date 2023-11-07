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

        void Bisiesto (out int fecha, out bool esBisiesto)
        {
    
            fecha = int.Parse(Interaction.InputBox("Introduce el año, para saber si este es bisiesto"));
            esBisiesto = false;

            if (fecha % 4 == 0)
            {
            esBisiesto = true;

                if (fecha % 400 != 0 && fecha % 100 == 0)
                { 
                esBisiesto = false;
                }
            }
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            int fecha;
            bool esBisiesto;
            string txtY, txtN;
            txtY = " es bisiesto";
            txtN = " no es bisiesto";

            Bisiesto(out fecha, out esBisiesto);

            if (esBisiesto == true)
            {
            MessageBox.Show("El año " + fecha + txtY);
            }

            else
            {
            MessageBox.Show("El año " + fecha + txtN);
            }
        }
    }
}
