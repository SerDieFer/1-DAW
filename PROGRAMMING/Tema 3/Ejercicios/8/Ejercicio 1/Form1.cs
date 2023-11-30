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
            string txtViejo, txtNuevo;


            txtViejo = txtTexto.Text;
            txtNuevo = txtViejo;
            lblNuevo.Text += txtNuevo + "\n";

        

            }
        }
    }

