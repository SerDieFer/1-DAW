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
using WindowsFormsApp1;

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
            fSquare squaresForm = new fSquare(figureList);
            squaresForm.ShowDialog();
        }

        private void btnIntroduceCircleData_Click(object sender, EventArgs e)
        {
            fCircle circlesForm = new fCircle(figureList);
            circlesForm.ShowDialog();
        }

        private void btnIntroduceRectangle_Click(object sender, EventArgs e)
        {
            fRectangle rectangleForm = new fRectangle(figureList);
            rectangleForm.ShowDialog();
        }

        private void btnIntroduceRegularHexagon_Click(object sender, EventArgs e)
        {
            fRegularHexagon regularHexagonForm = new fRegularHexagon(figureList);
            regularHexagonForm.ShowDialog();
        }

        private void btnIntroduceIsoscelesTriangle_Click(object sender, EventArgs e)
        {
            fIsoscelesTriangle isoscelesTriangleForm = new fIsoscelesTriangle(figureList);
            isoscelesTriangleForm.ShowDialog();
        }

        private void btnIntroduceEquilateralTriangle_Click(object sender, EventArgs e)
        {
            fEquilateralTriangle equilateralTriangleForm = new fEquilateralTriangle(figureList);
            equilateralTriangleForm.ShowDialog();
        }

        private void btnIntroduceScaleneTriangle_Click(object sender, EventArgs e)
        {
            fScaleneTriangle scaleneTriangleForm = new fScaleneTriangle(figureList);
            scaleneTriangleForm.ShowDialog();
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
                else if(figureList[i].GetType() == typeof(Rectangle))
                {
                    type = "Rectangle";
                }
                else if (figureList[i].GetType() == typeof(EquilateralTriangle))
                {
                    type = "Equilateral Triangle";
                }
                else if (figureList[i].GetType() == typeof(IsoscelesTriangle))
                {
                    type = "Isosceles Triangle";
                }
                else if (figureList[i].GetType() == typeof(ScaleneTriangle))
                {
                    type = "Scalene Triangle";
                }
                else if (figureList[i].GetType() == typeof(RegularHexagon))
                {
                    type = "Regular Hexagon";
                }

                MessageBox.Show("Figure Nº" + (i + 1) + ":\nType: " + type + "\n" + figureList[i].ToString());
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

        private void btnShowAllIsoscelesTriangles_Click(object sender, EventArgs e)
        {
            string txt = "Isosceles Triangle Data: \n\n";
            for (int i = 0; i < figureList.Count; i++)
            {
                if (figureList[i].GetType() == typeof(IsoscelesTriangle))
                {
                    txt += figureList[i].WhoAmI() + " in position Nº" + (i + 1) + ":\n" + figureList[i].ToString() + "\n";
                }
            }
            MessageBox.Show(txt);
        }

        private void btnShowAllScaleneTriangles_Click(object sender, EventArgs e)
        {
            string txt = "Scalene Triangle Data: \n\n";
            for (int i = 0; i < figureList.Count; i++)
            {
                if (figureList[i].GetType() == typeof(ScaleneTriangle))
                {
                    txt += figureList[i].WhoAmI() + " in position Nº" + (i + 1) + ":\n" + figureList[i].ToString() + "\n";
                }
            }
            MessageBox.Show(txt);
        }

        private void btnShowAllTriangles_Click(object sender, EventArgs e)
        {
            bool isTriangle = true;

            for (int i = 0; i < figureList.Count; i++)
            {
                string type = "";

                if (figureList[i].GetType() == typeof(EquilateralTriangle))
                {
                    type = "Equilateral Triangle";
                    isTriangle = true;
                }
                else if (figureList[i].GetType() == typeof(IsoscelesTriangle))
                {
                    type = "Isosceles Triangle";
                    isTriangle = true;
                }
                else if (figureList[i].GetType() == typeof(ScaleneTriangle))
                {
                    type = "Scalene Triangle";
                    isTriangle = true;
                }
                else
                {
                    isTriangle = false;
                }

                if (isTriangle)
                {
                    MessageBox.Show("Figure Nº" + (i + 1) + ":\nType: " + type + "\n" + figureList[i].ToString());
                }
            }
        }
    }
}
