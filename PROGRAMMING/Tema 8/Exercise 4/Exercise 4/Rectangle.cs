using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4
{
    public class Rectangle : Figure
    {
        private double rectangleBase;
        private double rectangleHeight;

        public double Base
        {
            get { return rectangleBase; }
            set { rectangleBase = value; }
        }

        public double Height
        {
            get { return rectangleHeight; }
            set { rectangleHeight = value; }
        }

        public Rectangle(int x, int y, string color, double baseLenght , double heightLenght) : base(x, y, color)
        {
            Base = baseLenght;
            Height = heightLenght;
        }

        public override string WhoAmI()
        {
            return "I'm a rectangle";
        }

        public override string ToString()
        {
            string txt = base.ToString();
            txt += "\nBase: " + Base + "\nHeight: " + Height + "\nPerimeter: " + FigurePerimeter() + "\nArea: " + FigureArea() + "\n";
            return txt;
        }
        public override double FigurePerimeter()
        {
            return Math.Round(((Base * 2) + (Height * 2)), 2);
        }

        public override double FigureArea()
        {
            return Math.Round((Base * Height), 2);
        }

    }
}

