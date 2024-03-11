using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Exercise_4;

namespace Exercise_4
{
    public partial class InitialForm : Form
    {
        public InitialForm()
        {
            InitializeComponent();
        }

        private void InitialForm_Load(object sender, EventArgs e)
        {

        }

        List<Figure> figureList = new List<Figure>();
        private void btnIntroduceSquareData_Click(object sender, EventArgs e)
        {
            SquaresForm squaresForm = new SquaresForm(figureList);
            squaresForm.ShowDialog();
        }

        private void btnIntroduceCircleData_Click(object sender, EventArgs e)
        {
            CirclesForm circlesForm = new CirclesForm(figureList);
            circlesForm.ShowDialog();
        }

        private void btnIntroduceEquilateralTriangle_Click(object sender, EventArgs e)
        {
            EquilateralTriangleForm equilateralTriangleForm = new EquilateralTriangleForm(figureList);
            equilateralTriangleForm.ShowDialog();
        }

        private void btnIntroduceRectangle_Click(object sender, EventArgs e)
        {
            RectangleForm rectangleForm = new RectangleForm(figureList);
            rectangleForm.ShowDialog();
        }

        private void btnIntroduceRegularHexagon_Click(object sender, EventArgs e)
        {
            RegularHexagonForm regularHexagonForm = new RegularHexagonForm(figureList);
            regularHexagonForm.ShowDialog();
        }

        private void btnShowAllFigures_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < figureList.Count; i++)
            {
                string type = "";

                if (figureList[i].GetType() == typeof(Circle))
                {
                    type = "Circle";
                }
                else if (figureList[i].GetType() == typeof(Square))
                {
                    type = "Square";
                }

                MessageBox.Show("Figura " + (i + 1) + ":\nType: " + type + "\n" + figureList[i].ToString());
            }
        }

        private void btnShowAllCircles_Click(object sender, EventArgs e)
        {
            string txt = "Circles Data: \n\n";
            for (int i = 0; i < figureList.Count; i++)
            {
                if (figureList[i].GetType() == typeof(Circle))
                {
                    txt += figureList[i].WhoAmI() +  " in position Nº" + (i + 1) + ":\n" + figureList[i].ToString() + "\n";
                }
            }
            MessageBox.Show(txt);
        }

        private void btnShowAllSquares_Click(object sender, EventArgs e)
        {
            string txt = "Squares Data: \n\n";
            for (int i = 0; i < figureList.Count; i++)
            {
                if (figureList[i].GetType() == typeof(Square))
                {
                    txt += figureList[i].WhoAmI() + " in position Nº" + (i + 1) + ":\n" + figureList[i].ToString() + "\n";
                }
            }
            MessageBox.Show(txt);
        }

        private void btnShowAllEquilateralTriangles_Click(object sender, EventArgs e)
        {
            string txt = "Equilateral Triangle Data: \n\n";
            for (int i = 0; i < figureList.Count; i++)
            {
                if (figureList[i].GetType() == typeof(EquilateralTriangle))
                {
                    txt += figureList[i].WhoAmI() + " in position Nº" + (i + 1) + ":\n" + figureList[i].ToString() + "\n";
                }
            }
            MessageBox.Show(txt);
        }

        private void btnShowAllRectangles_Click(object sender, EventArgs e)
        {
            string txt = "Rectangle Data: \n\n";
            for (int i = 0; i < figureList.Count; i++)
            {
                if (figureList[i].GetType() == typeof(Rectangle))
                {
                    txt += figureList[i].WhoAmI() + " in position Nº" + (i + 1) + ":\n" + figureList[i].ToString() + "\n";
                }
            }
            MessageBox.Show(txt);
        }

        private void btnShowAllRegularHexagons_Click(object sender, EventArgs e)
        {
            string txt = "Regular Hexagon Data: \n\n";
            for (int i = 0; i < figureList.Count; i++)
            {
                if (figureList[i].GetType() == typeof(RegularHexagon))
                {
                    txt += figureList[i].WhoAmI() + " in position Nº" + (i + 1) + ":\n" + figureList[i].ToString() + "\n";
                }
            }
            MessageBox.Show(txt);
        }
    }
}
