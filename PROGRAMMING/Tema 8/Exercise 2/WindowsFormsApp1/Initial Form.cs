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

        List<Figure> figuresList = new List<Figure>();

        private void btnIntroduceSquareData_Click(object sender, EventArgs e)
        {
            SquaresForm squaresForm = new SquaresForm();
            squaresForm.ShowDialog();
        }

        private void btnIntroduceCircleData_Click(object sender, EventArgs e)
        {
            CirclesForm circlesForm = new CirclesForm();
            circlesForm.ShowDialog();
        }
    }
}
