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
    public partial class fRegularHexagon : Form
    {
        private void fRegularHexagon_Load(object sender, EventArgs e)
        {
        }

        public fRegularHexagon(List<Figure> figureList)
        {
            InitializeComponent();
            this.figureList = figureList;
        }
        public List<Figure> figureList;

        private void btnCreateRegularHexagon_Click(object sender, EventArgs e)
        {
            int positionX = int.Parse(txtbPositionX.Text);
            int positionY = int.Parse(txtbPositionY.Text);
            double side = double.Parse(txtbRegularHexagonSide.Text);
            string color = txtbColor.Text;

            if (side > 0)
            {
                if (!string.IsNullOrEmpty(color))
                {
                    RegularHexagon newRegularHexagon = new RegularHexagon(positionX, positionY, color, side);
                    figureList.Add(newRegularHexagon);
                    ClearTextBoxes();
                    MessageBox.Show("A regular hexagon was added!");
                }
                else
                {
                    MessageBox.Show("A color must be selected!.");
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
            txtbRegularHexagonSide.Text = string.Empty;
        }
    }
}
