using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_01
{
    public partial class fFormulario1 : Form
    {
        public fFormulario1()
        {
            InitializeComponent();
        }

        private void bPrimero_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha apretado el primer botón.");
        }

        private void bSegundo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha apretado el segundo botón.");
        }
    }
}
