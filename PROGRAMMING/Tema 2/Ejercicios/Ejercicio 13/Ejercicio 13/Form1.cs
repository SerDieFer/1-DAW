using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_13
{
    public partial class Form1 : Form
    {
        //Declaramos los variables constantes.
        const double RETENCION = (1-0.18), VALOREXTRA = 2;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void bNomina_Click(object sender, EventArgs e)
        {
            //Aqui declaramos las variables a usar.
            double horas, horasextra, pagahoraria, nomina;

            //Con esto detecto los posibles errores.
            try
            {
                //Aqui declaro de donde obtienen las variables sus valores.
                horas = double.Parse(textBoxHoras.Text);
                horasextra = double.Parse(textBoxExtras.Text);
                pagahoraria = double.Parse(textBoxPagaHoraria.Text);
                nomina = (((horas * pagahoraria) + ((horasextra * VALOREXTRA) * pagahoraria))) * RETENCION;

                //Aqui mostramos al usuario un mensaje en el cual indica su nómina ya calculada.
                lNomina.Text = ("Tu nómina mensual con todas las horas, extras \ny retenciones calculadas serían: " + nomina + " euros");
            }
            //Con esto catalogamos el error.
            catch(FormatException fEX)
            {
                //Aqui se le muestra en una venta al usuario el susodicho error.
                MessageBox.Show("Se ha detectado el siguiente error: " + fEX.Message);
            }
        }
    }
}
