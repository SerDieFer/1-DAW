using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Exercise_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Person pe = new Person();
   
        private void btnIntroduceData_Click(object sender, EventArgs e)
        {
            pe.Name = Interaction.InputBox("Introduce the name of this person.");
            pe.Age = int.Parse(Interaction.InputBox("Introduce the age."));
            pe.Phone = int.Parse(Interaction.InputBox("Introduce the phone number (Max 9 digits)."));
            pe.Gender = Interaction.InputBox("Introduce the genre of this person (Male or Female).");
            pe.Married = Interaction.InputBox("Introduce the civil status if this person is married (Yes or No).");
        }

        private void brnShowData_Click(object sender, EventArgs e)
        {
            MessageBox.Show(pe.ShowData());
        }
    }
}
