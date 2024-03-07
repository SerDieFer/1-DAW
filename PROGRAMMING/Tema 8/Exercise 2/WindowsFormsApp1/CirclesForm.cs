using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_2
{
    public partial class CirclesForm : Form
    {
        public CirclesForm()
        {
            InitializeComponent();
        }

        public FigureList figureList;

        private void Circles_Load(object sender, EventArgs e)
        {

        }

        public CirclesForm(FigureList figureList)
        {
            InitializeComponent();
            this.figureList = figureList;
        }
    }
}
