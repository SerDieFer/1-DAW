using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_02
{
    public partial class fFormulario1 : Form
    {
        public fFormulario1()
        {
            InitializeComponent();
        }

        private void bPrimero_Click(object sender, EventArgs e)
        {
            MessageBox.Show(tCuadro.Text);
        }

        private void bSegundo_Click(object sender, EventArgs e)
        {
            BackColor = Color.CadetBlue;
        }

        private void bTercero_Click(object sender, EventArgs e)
        {
            tCuadro.ForeColor = Color.Red;
        }
    }
}
