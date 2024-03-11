using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4
{
    public class Circle : Figure
    {
        private double circleRadius;

        public double Radius
        {
            get { return circleRadius; }
            set { circleRadius = value; }
        }

        public Circle(int x, int y, string color, double radiusLenght) : base(x, y, color)
        {
            Radius = radiusLenght;
        }

        public override string WhoAmI()
        {
            return "I'm a circle";
        }

        public override string ToString()
        {
            string txt = base.ToString();
            txt += "\nRadius: " + Radius + "\nPerimeter: " + FigurePerimeter() + "\nArea: " + FigureArea() + "\n";
            return txt;
        }
        public override double FigurePerimeter()
        {
            double circleDiameter = Radius * 2;
            return Math.Round((circleDiameter * Math.PI), 2);
        }

        public override double FigureArea()
        {
            return Math.Round(Math.PI * Math.Pow(circleRadius,2),2);
        }

    }
}
