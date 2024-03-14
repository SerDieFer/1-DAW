using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4
{
    public class RegularHexagon : Figure
    {
        private double hexagonSide;

        public double Side
        {
            get { return hexagonSide; }
            set { hexagonSide = value; }
        }

        public RegularHexagon(int x, int y, string color, double sideLenght) : base(x, y, color)
        {
            Side = sideLenght;
        }

        public override string WhoAmI()
        {
            return "I'm a regular hexagon";
        }

        public override string ToString()
        {
            string txt = base.ToString();
            txt += "\nSide: " + Side + "\nPerimeter: " + FigurePerimeter() + "\nArea: " + FigureArea() + "\n";
            return txt;
        }

        private double ApothemCalculus()
        {
            double hypotenuse = Side;
            double cathetus = Side / 2;
            double apothem = Math.Sqrt((hypotenuse * hypotenuse) - (cathetus * cathetus));
            return apothem;
        }

        public override double FigurePerimeter()
        {
            return Math.Round((Side * 6), 2);
        }

        public override double FigureArea()
        {
            return Math.Round(((FigurePerimeter() * ApothemCalculus()) / 2), 2);
        }








    }
}
