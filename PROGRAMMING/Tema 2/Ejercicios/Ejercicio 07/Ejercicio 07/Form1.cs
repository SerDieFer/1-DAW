using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bResultado_Click(object sender, EventArgs e)
        
        {
            //Declaramos las variables.
            int alturacms, metros, cms;

            //Usamos el try para detectar posibles errores.
            try
            {
                //Damos valor a la variable alturacms que se obtiene del texto introducido en la textBoxCms.
                alturacms = int.Parse(textBoxCms.Text);

                //Declaramos el valor de la variable metros, mediante la division de las unidades para obtenerlo en la unidad deseada.
                metros = alturacms / 100;

                //Declaramos el valor de la variable cms, mediante la diferencia entre la division de la alturacms y el valor de la unidad deseada a convertir.
                cms = alturacms % 100;

                //Con esto cambiamos el texto del objeto lResultado y lo adecuamos a las unidades deseadas.
                lResultado.Text = ("Mide " + metros + " metros y " + cms + " cms");
            }
            //Declaramos el catch para clasificar los errores detectados.
            catch(FormatException fEx)
            {
                //Mandamos el mensaje personalizado sobre el error identificado al usuario, mediante una consola de texto.
                MessageBox.Show("Se ha producido un error de: " + fEx.Message);
            }
            {
            }
        }
    }
}
