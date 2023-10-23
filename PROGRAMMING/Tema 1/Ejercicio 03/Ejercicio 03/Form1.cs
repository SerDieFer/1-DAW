using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_03
{
    public partial class fFormulario03 : Form
    {
        public fFormulario03()
        {
            InitializeComponent();
        }

        private void bPrimero_Click(object sender, EventArgs e)
        {
            tCuadrado.Text = ("Se ha apretado el primer botón.");
            }

        private void bSegundo_Click(object sender, EventArgs e)
        {
            tCuadrado.Text = ("Se ha apretado el segundo botón.");
        }

        private void bTercero_Click(object sender, EventArgs e)
        {
            tCuadrado.Text = String.Empty;
        }
    }
    }
