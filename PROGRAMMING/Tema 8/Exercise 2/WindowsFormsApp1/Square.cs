using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    internal class Square : Figure
    {
        private double squareHeight;

        public double Height
        {
            get { return squareHeight; }
            set { squareHeight = value; }
        }

        public Square(int x, int y, string color, double height) : base(x, y, color)
        {
            Height = height;
        }

        public override string WhoAmI()
        {
            return "I'm a square";
        }

        public override string ToString()
        {
            string txt = base.ToString();
            txt += "\nHeight: " + squareHeight +"\n Area: " + FigureArea();
            return txt;
        }
        public override double FigureArea()
        {
            return Math.Round(Math.Pow(squareHeight, 2),2);
        }

    }
}
