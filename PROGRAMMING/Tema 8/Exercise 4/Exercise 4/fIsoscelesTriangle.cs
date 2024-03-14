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

namespace WindowsFormsApp1
{
    public partial class fIsoscelesTriangle : Form
    {
        private void fIsoscelesTriangle_Load(object sender, EventArgs e)
        {
        }

        public fIsoscelesTriangle(List<Figure> figureList)
        {
            InitializeComponent();
            this.figureList = figureList;
        }
        public List<Figure> figureList;

        private void btnCreateIsoscelesTriangle_Click_1(object sender, EventArgs e)
        {
            int positionX = int.Parse(txtbPositionX.Text);
            int positionY = int.Parse(txtbPositionY.Text);
            double side = double.Parse(txtbIsoscelesTriangleSide.Text);
            double triangleBase = double.Parse(txtbIsoscelesTriangleBase.Text);
            string color = txtbColor.Text;

            if (side > 0 && triangleBase > 0)
            {
                if (!string.IsNullOrEmpty(color))
                {
                    IsoscelesTriangle newIsoscelesTriangle = new IsoscelesTriangle(positionX, positionY, color, side, triangleBase);
                    figureList.Add(newIsoscelesTriangle);
                    ClearTextBoxes();
                    MessageBox.Show("An isosceles triangle was added!");
                }
                else
                {
                    MessageBox.Show("A color must be selected!.");
                }
            }
            else
            {
                MessageBox.Show("Can't have a negative or null side or base.");
            }
        }

        public void ClearTextBoxes()
        {
            txtbColor.Text = string.Empty;
            txtbPositionX.Text = string.Empty;
            txtbPositionY.Text = string.Empty;
            txtbIsoscelesTriangleSide.Text = string.Empty;
            txtbIsoscelesTriangleBase.Text = string.Empty;
        }    
    }
}
