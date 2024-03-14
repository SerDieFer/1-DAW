using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4
{
    public class EquilateralTriangle : Figure
    {
        private double equilateralTriangleSide;

        public double Side
        {
            get { return equilateralTriangleSide; }
            set { equilateralTriangleSide = value; }
        }

        public EquilateralTriangle(int x, int y, string color, double sideLenght) : base(x, y, color)
        {
            Side = sideLenght;
        }

        public override string WhoAmI()
        {
            return "I'm an equilateral triangle";
        }

        public override string ToString()
        {
            string txt = base.ToString();
            txt += "\nSide: " + Side + "\nPerimeter: " + FigurePerimeter() + "\nArea: " + FigureArea() + "\n";
            return txt;
        }

        public override double FigurePerimeter()
        {
            return Math.Round((Side * 3), 2);
        }

        public override double FigureArea()
        {
            double triangleHeight = (Side * Math.Sqrt(3)) / 2;
            return Math.Round(((Side * triangleHeight) / 2), 2);
        }
    }
}
