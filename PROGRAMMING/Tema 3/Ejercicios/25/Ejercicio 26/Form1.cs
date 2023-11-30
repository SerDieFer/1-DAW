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

namespace Ejercicio_26
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            int num = 1;
            string tabla = "";

            while (num <= 10)
            {
                for (int i = 1; i <= 10; i++)
                {
                    if(i % 10 == 0)
                    {
                        tabla += num * i + "\n\n";
                    }

                    else
                    {
                        tabla += num * i + " - ";
                    }
                }
                num++;
            }
            MessageBox.Show(tabla);
        }
    }
}
