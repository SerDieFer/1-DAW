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
        private void Circles_Load(object sender, EventArgs e)
        {
        }

        public CirclesForm(List<Figure> figureList)
        {
            InitializeComponent();
            this.figureList = figureList;
        }
        public List<Figure> figureList;

        private void btnCreateCircle_Click(object sender, EventArgs e)
        {
            int positionX = int.Parse(txtbPositionX.Text);
            int positionY = int.Parse(txtbPositionY.Text);
            double radius = double.Parse(txtbCircleRadius.Text);
            string color = txtbColor.Text;

            if (radius > 0)
            {
                if (!string.IsNullOrEmpty(color))
                {
                    Circle newCircle = new Circle(positionX, positionY, color, radius);
                    figureList.Add(newCircle);
                    ClearTextBoxes();
                    MessageBox.Show("A circle was added!");
                }
            }
            else
            {
                MessageBox.Show("Can't have a negative or null radius.");
            }
        }

        public void ClearTextBoxes()
        {
            txtbColor.Text = string.Empty;
            txtbPositionX.Text = string.Empty;
            txtbPositionY.Text = string.Empty;
            txtbCircleRadius.Text = string.Empty;
        }
    }
}
