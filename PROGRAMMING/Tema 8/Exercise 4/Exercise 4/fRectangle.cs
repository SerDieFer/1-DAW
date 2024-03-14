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
    public partial class fRectangle : Form
    {
        private void fRectangle_Load(object sender, EventArgs e)
        {
        }
        public fRectangle(List<Figure> figureList)
        {
            InitializeComponent();
            this.figureList = figureList;
        }
        public List<Figure> figureList;

        private void btnCreateRectangle_Click(object sender, EventArgs e)
        {
            int positionX = int.Parse(txtbPositionX.Text);
            int positionY = int.Parse(txtbPositionY.Text);
            double rBase = double.Parse(txtbRectangleBase.Text);
            double rHeight = double.Parse(txtbRectangleHeight.Text);
            string color = txtbColor.Text;

            if (rBase > 0 && rHeight > 0)
            {
                if (!string.IsNullOrEmpty(color))
                {
                    Rectangle newRectangle = new Rectangle(positionX, positionY, color, rBase, rHeight);
                    figureList.Add(newRectangle);
                    ClearTextBoxes();
                    MessageBox.Show("A rectangle was added!");
                }
                else
                {
                    MessageBox.Show("A color must be selected!.");
                }
            }
            else
            {
                MessageBox.Show("Can't have a negative or null base or height.");
            }
        }

        public void ClearTextBoxes()
        {
            txtbColor.Text = string.Empty;
            txtbPositionX.Text = string.Empty;
            txtbPositionY.Text = string.Empty;
            txtbRectangleBase.Text = string.Empty;
            txtbRectangleHeight.Text = string.Empty;
        }
    }
}
