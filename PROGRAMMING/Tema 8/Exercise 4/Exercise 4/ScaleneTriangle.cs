using Exercise_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ScaleneTriangle : Figure
    {
        private double scaleneTriangleSideA;
        private double scaleneTriangleSideB;
        private double scaleneTriangleSidec;

        public double SideA
        {
            get { return scaleneTriangleSideA; }
            set { scaleneTriangleSideA = value; }
        }

        public double SideB
        {
            get { return scaleneTriangleSideB; }
            set { scaleneTriangleSideB = value; }
        }

        public double SideC
        {
            get { return scaleneTriangleSideB; }
            set { scaleneTriangleSideB = value; }
        }

        public ScaleneTriangle(int x, int y, string color, double sideALenght, double sideBLenght, double sideCLenght) : base(x, y, color)
        {
            SideA = sideALenght;
            SideB = sideBLenght;
            SideC = sideCLenght;
        }

        public override string WhoAmI()
        {
            return "I'm an scalene triangle";
        }

        public override string ToString()
        {
            string txt = base.ToString();
            txt += "\nSide A: " + SideA + "\nSide B: " + SideB + "\nSide C: " + SideC + "\nPerimeter: " + FigurePerimeter() + "\nArea: " + FigureArea() + "\n";
            return txt;
        }

        public override double FigurePerimeter()
        {
            return Math.Round((SideA + SideB + SideC), 2);
        }

        public override double FigureArea()
        {
            return Math.Round((FigurePerimeter() / 2), 2);
        }
    }
}
