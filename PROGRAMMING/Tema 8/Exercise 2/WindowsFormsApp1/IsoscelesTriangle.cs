using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4
{
    public class IsoscelesTriangle : Figure
    {
        private double isoscelesTriangleSide;
        private double isoscelesTriangleBase;

        public double Side
        {
            get { return isoscelesTriangleSide; }
            set { isoscelesTriangleSide = value; }
        }

        public double Base
        {
            get { return isoscelesTriangleBase; }
            set { isoscelesTriangleBase = value; }
        }

        public IsoscelesTriangle(int x, int y, string color, double sideLenght, double baseLenght) : base(x, y, color)
        {
            Side = sideLenght;
            Base = baseLenght;
        }

        public override string WhoAmI()
        {
            return "I'm an isosceles triangle";
        }

        public override string ToString()
        {
            string txt = base.ToString();
            txt += "\nSide: " + Side + "\nBase: " + Base + "\nPerimeter: " + FigurePerimeter() + "\nArea: " + FigureArea() + "\n";
            return txt;
        }

        public override double FigurePerimeter()
        {
            return Math.Round(((Base + (Side *2))/2), 2);
        }

        public override double FigureArea()
        {
            double triangleHeight = Math.Sqrt( Math.Pow(Side,2) - Math.Pow((Base / 2.0),2) );
                
            return Math.Round(((Base * triangleHeight) / 2), 2);
        }
    }
}
