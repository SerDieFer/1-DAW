using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {

            try
            {
                int horas, minutos, segundos;

                horas = int.Parse(txtHora.Text);
                minutos = int.Parse(txtMin.Text);
                segundos = int.Parse(txtSec.Text);

                //Errores
                if (segundos >= 60 || minutos >= 60 || horas >= 24)
                {
                    MessageBox.Show("Se ha producido un error");
                    txtHora.Text = 0.ToString();
                    txtMin.Text = 0.ToString();
                    txtSec.Text = 0.ToString();
                }

                else
                {
                    if (segundos >= 0 && segundos < 59)
                    {
                        txtSec.Text = (segundos + 1).ToString();
                    }

                    if (segundos >= 59)
                    {
                        txtMin.Text = (minutos + 1).ToString();
                        txtSec.Text = (segundos - 59).ToString();
                    }

                    if (minutos >= 59)
                    {
                        txtHora.Text = (horas + 1).ToString();
                        txtMin.Text = (minutos - 59).ToString();
                    }

                    if (horas >= 23)
                    {
                        txtHora.Text = (horas - 23).ToString();
                    }
                }
            }

            catch (FormatException fEx)
            {
                MessageBox.Show("Se ha producido un error: " + fEx.Message);
            }
        }
    }
}
