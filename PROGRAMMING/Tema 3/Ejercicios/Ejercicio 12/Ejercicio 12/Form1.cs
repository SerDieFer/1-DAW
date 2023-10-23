using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Ejercicio_12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnWhile_Click(object sender, EventArgs e)
        {
            int num, i;
            string txt;
            num = int.Parse(txtNum.Text);
            txt = ("Los números introducidos entre el 1 y el " + num + " son: ");
            i = 1;

            while (i <= num)
            {
                txt = txt + i + ", ";
                i++;
            }
            MessageBox.Show(txt);
        }

        private void btnDoWhile_Click(object sender, EventArgs e)
        {
            int num, i;
            string txt;
            num = int.Parse(txtNum.Text);
            txt = ("Los números introducidos entre el 1 y el " + num + " son: ");
            i = 1;

            do
            {
                txt = txt + i + ", ";
                i++;
            } while (i <= num);

            MessageBox.Show(txt);
        }

        private void btnFor_Click(object sender, EventArgs e)
        {
            int num;
            string txt;
            num = int.Parse(txtNum.Text);
            txt = ("Los números introducidos entre el 1 y el " + num + " son: ");

            for (int i = 1; i <= num; i++)
            {
                txt = txt + i + ", ";
            }
            MessageBox.Show(txt);

        }
    }
}
