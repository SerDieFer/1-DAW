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
    public partial class fSquare : Form
    {
        private void fSquare_Load(object sender, EventArgs e)
        {
        }
       
        public fSquare(List<Figure> figureList)
        {
            InitializeComponent();
            this.figureList = figureList;
        }

        public List<Figure> figureList;

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
                else
                {
                    MessageBox.Show("A color must be selected!.");
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
