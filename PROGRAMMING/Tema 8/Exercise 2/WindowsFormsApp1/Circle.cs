using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    public class Circle : Figure
    {
        private double circleRadius;

        public double Radius
        {
            get { return circleRadius; }
            set { circleRadius = value; }
        }

        public Circle(int x, int y, string color, double radius) : base(x, y, color)
        {
            Radius = radius;
        }

        public override string WhoAmI()
        {
            return "I'm a circle";
        }

        public override string ToString()
        {
            string txt = base.ToString();
            txt += "\nRadius: " + circleRadius + "\nArea: " + FigureArea() + "\n";
            return txt;
        }
        public override double FigureArea()
        {
            return Math.Round(Math.PI * Math.Pow(circleRadius,2),2);
        }

    }
}
