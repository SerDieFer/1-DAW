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
    public partial class InitialForm : Form
    {
        public InitialForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateSquare_Click(object sender, EventArgs e)
        {
            Square aSquare = new Square(5,5,"red", 5.25);
            MessageBox.Show(aSquare.WhoAmI());
            MessageBox.Show(aSquare.ToString());
            MessageBox.Show("The square area is: " + aSquare.FigureArea());
        }

        private void btnCreateCircle_Click(object sender, EventArgs e)
        {
            Circle aCircle = new Circle(5, 5, "yellow", 2.5);
            MessageBox.Show(aCircle.WhoAmI());
            MessageBox.Show(aCircle.ToString());
            MessageBox.Show("The circle area is: " + aCircle.FigureArea());
        }
    }
}
