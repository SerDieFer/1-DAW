using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Exercise_2
{
    public partial class InitialForm : Form
    {
        public InitialForm()
        {
            InitializeComponent();
        }

        private void InitialForm_Load(object sender, EventArgs e)
        {

        }

        List<Figure> figureList = new List<Figure>();
        private void btnIntroduceSquareData_Click(object sender, EventArgs e)
        {
            SquaresForm squaresForm = new SquaresForm(figureList);
            squaresForm.ShowDialog();
        }

        private void btnIntroduceCircleData_Click(object sender, EventArgs e)
        {
            CirclesForm circlesForm = new CirclesForm(figureList);
            circlesForm.ShowDialog();
        }

        private void btnShowAllFigures_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < figureList.Count; i++)
            {
                string type = "";

                if (figureList[i].GetType() == typeof(Circle))
                {
                    type = "Circle";
                }
                else if (figureList[i].GetType() == typeof(Square))
                {
                    type = "Square";
                }

                MessageBox.Show("Figura " + (i + 1) + ":\nType: " + type + "\n" + figureList[i].ToString());
            }
        }

        private void btnShowAllCircles_Click(object sender, EventArgs e)
        {
            string txt = "Circles Data: \n\n";
            for (int i = 0; i < figureList.Count; i++)
            {
                if (figureList[i].GetType() == typeof(Circle))
                {
                    txt += figureList[i].WhoAmI() +  " in position Nº" + (i + 1) + ":\n" + figureList[i].ToString() + "\n";
                }
            }
            MessageBox.Show(txt);
        }

        private void btnShowAllSquares_Click(object sender, EventArgs e)
        {
            string txt = "Squares Data: \n\n";
            for (int i = 0; i < figureList.Count; i++)
            {
                if (figureList[i].GetType() == typeof(Square))
                {
                    txt += figureList[i].WhoAmI() + " in position Nº" + (i + 1) + ":\n" + figureList[i].ToString() + "\n";
                }
            }
            MessageBox.Show(txt);
        }
    }
}
