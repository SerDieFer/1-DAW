using Exercise_4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_4
{
    public partial class EquilateralTriangleForm : Form
    {
        public EquilateralTriangleForm()
        {
            InitializeComponent();
        }

        private void EquilateralTriangleForm_Load(object sender, EventArgs e)
        {

        }

        public EquilateralTriangleForm(List<Figure> figureList)
        {
            InitializeComponent();
            this.figureList = figureList;
        }
        public List<Figure> figureList;

        private void btnCreateEquilateralTriangle_Click(object sender, EventArgs e)
        {
            int positionX = int.Parse(txtbPositionX.Text);
            int positionY = int.Parse(txtbPositionY.Text);
            double side = double.Parse(txtbEquilateralTriangleSide.Text);
            string color = txtbColor.Text;

            if (side > 0)
            {
                if (!string.IsNullOrEmpty(color))
                {
                    EquilateralTriangle newEquilateralTriangle = new EquilateralTriangle(positionX, positionY, color, side);
                    figureList.Add(newEquilateralTriangle);
                    ClearTextBoxes();
                    MessageBox.Show("An equilateral triangle was added!");
                }
            }
            else
            {
                MessageBox.Show("Can't have a negative or null side.");
            }
        }

        public void ClearTextBoxes()
        {
            txtbColor.Text = string.Empty;
            txtbPositionX.Text = string.Empty;
            txtbPositionY.Text = string.Empty;
            txtbEquilateralTriangleSide.Text = string.Empty;
        }
    }
}
