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
    public partial class SquaresForm : Form
    {
        public List<Figure> figureList;
        public SquaresForm(List<Figure> figureList)
        {
            InitializeComponent();
            this.figureList = figureList;
        }

        private void Squares_Load(object sender, EventArgs e)
        {
        }

        private void btnCreateSquare_Click(object sender, EventArgs e)
        {
            int positionX = int.Parse(txtbPositionX.Text);
            int positionY = int.Parse(txtbPositionY.Text);
            double squareHeght = double.Parse(txtbSquareHeight.Text);
            string color = txtbColor.Text;

            if (squareHeght > 0)
            {
                if (!string.IsNullOrEmpty(color))
                {
                    Square newSquare = new Square(positionX, positionY, color, squareHeght);
                    figureList.Add(newSquare);
                    ClearTextBoxes();
                    MessageBox.Show("A square was added!");
                }
            }
            else
            {
                MessageBox.Show("Can't have a negative or null height .");
            }
        }

        public void ClearTextBoxes()
        {
            txtbColor.Text = string.Empty;
            txtbPositionX.Text = string.Empty;
            txtbPositionY.Text = string.Empty;
            txtbSquareHeight.Text = string.Empty;
        }
    }
}
