using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4
{
    internal class Square : Figure
    {
        private double squareSide;

        public double Side
        {
            get { return squareSide; }
            set { squareSide = value; }
        }

        public Square(int x, int y, string color, double sideLenght) : base(x, y, color)
        {
            Side = sideLenght;
        }

        public override string WhoAmI()
        {
            return "I'm a square";
        }

        public override string ToString()
        {
            string txt = base.ToString();
            txt += "\nSide: " + Side + "\nPerimeter: " + FigurePerimeter() + "\nArea: " + FigureArea() + "\n";
            return txt;
        }
        public override double FigurePerimeter()
        {
            return Math.Round((Side * 4), 2);
        }


        public override double FigureArea()
        {
            return Math.Round(Math.Pow(Side, 2),2);
        }

    }
}
