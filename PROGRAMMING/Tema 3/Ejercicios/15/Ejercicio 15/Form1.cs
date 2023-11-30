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

namespace Ejercicio_15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            int num, mayor, menor;

            num = int.Parse(Interaction.InputBox("Introduce el número: "));
            menor = mayor = num;

            lblMayor.Text = "Mayor: " + mayor;
            lblMenor.Text = "Menor: " + menor;

            if (num < 0)
            {
                MessageBox.Show("Error, el número deberá ser positivo.");

            }

            else
            {
                mayor = num;

                while (num >= 1)
                {
                    if (num > mayor)
                    {
                        mayor = num;
                        lblMayor.Text = "Mayor: " + mayor.ToString();
                    }

                    else
                    {
                        menor = num;
                        lblMenor.Text = "Menor: " + menor.ToString();
                    }

                    num = int.Parse(Interaction.InputBox("Introduce el número: "));
                }

            }
        }
    }
}
    

