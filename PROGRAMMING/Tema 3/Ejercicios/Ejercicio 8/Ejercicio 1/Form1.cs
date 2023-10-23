using System;
using System.Windows.Forms;

namespace Ejercicio_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            //Aqui declaramos las variables
            string textoNuevo, textoExtra;

            //Aqui de donde se obtienen sus valores

            //En este caso sacamos el texto del textBox
            textoNuevo = txtTexto.Text;
            //Aquí sacamos el texto del texto que se colocaría ya en el label, guardandolo como un valor.
            textoExtra = lblNuevo.Text;

            //Hacemos que el label le añada al texto añadido previamente, el texto extra introducido.
            lblNuevo.Text = textoExtra + "\n" + textoNuevo;

            }
        }
    }

