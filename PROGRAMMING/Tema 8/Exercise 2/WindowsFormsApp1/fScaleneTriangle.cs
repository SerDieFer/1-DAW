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
    public partial class fScaleneTriangle : Form
    {
        private void fScaleneTriangle_Load(object sender, EventArgs e)
        {
        }

        public fScaleneTriangle(List<Figure> figureList)
        {
            InitializeComponent();
            this.figureList = figureList;
        }
        public List<Figure> figureList;

        private void btnCreateScaleneTriangle_Click(object sender, EventArgs e)
        {
            int positionX = int.Parse(txtbPositionX.Text);
            int positionY = int.Parse(txtbPositionY.Text);
            double sideA = double.Parse(txtbScaleneTriangleSideA.Text);
            double sideB = double.Parse(txtbScaleneTriangleSideB.Text);
            double sideC = double.Parse(txtbScaleneTriangleSideC.Text);
            string color = txtbColor.Text;

            if (sideA > 0 && sideB > 0 && sideC > 0)
            {
                if (!string.IsNullOrEmpty(color))
                {
                    ScaleneTriangle newScaleneTriangle = new ScaleneTriangle(positionX, positionY, color, sideA, sideB, sideC);
                    figureList.Add(newScaleneTriangle);
                    ClearTextBoxes();
                    MessageBox.Show("A scalene triangle was added!");
                }
                else
                {
                    MessageBox.Show("A color must be selected!.");
                }
            }
            else
            {
                MessageBox.Show("Can't have any negative or null side.");
            }
        }
        public void ClearTextBoxes()
        {
            txtbColor.Text = string.Empty;
            txtbPositionX.Text = string.Empty;
            txtbPositionY.Text = string.Empty;
            txtbScaleneTriangleSideA.Text = string.Empty;
            txtbScaleneTriangleSideB.Text = string.Empty;
            txtbScaleneTriangleSideC.Text = string.Empty;
        }
    }
}
