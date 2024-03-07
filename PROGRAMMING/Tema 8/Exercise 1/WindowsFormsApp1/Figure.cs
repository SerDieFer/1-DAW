using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    public abstract class Figure
    {
        private int positionX, positionY;
        private string figureColor;

        public int PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }
        public int PositionY
        {
            get { return positionY; }
            set { positionY = value; }
        }
        public string Color
        {
            get { return figureColor; }
            set { figureColor = value; }
        }

        public Figure(int x, int y, string color)
        {
            PositionX = x;
            PositionY = y;
            Color = color;
        }


        public virtual string WhoAmI()
        {
            return "I'm a figure";
        }

        public override string ToString()
        {
            string txt;
            txt = "Position X: " + positionX + "\nPosition Y: " + positionY + "\nColor: " + figureColor;
            return txt;
        }

        public abstract double FigureArea();
    }
}
