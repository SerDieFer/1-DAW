using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Exercise_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Person> personList = new List<Person>();

        // BUTTON WHICH ADD A PERSON
        private void btnIntroduceData_Click(object sender, EventArgs e)
        {
            RecallToIntroduceSinglePersonData();
        }

        // ASKS THE DATA FROM A SINGLE PERSON AND THEN ADD THIS OBJECT (PERSON) TO THE LIST
        private void RecallToIntroduceSinglePersonData()
        {
            Person pe = new Person();
            pe.Name = Interaction.InputBox("Introduce the name of this person.");
            pe.Age = int.Parse(Interaction.InputBox("Introduce the age."));
            pe.Phone = Interaction.InputBox("Introduce the phone number (Max 9 digits).");
            pe.Gender = char.Parse(Interaction.InputBox("Introduce the genre of this person (Male or Female)."));

            DialogResult married;
            married = MessageBox.Show("Introduce the civil status if this person is married (Yes or No).", "Married?", MessageBoxButtons.YesNo);
            if (married == DialogResult.Yes)
            {
                pe.Married = true;
            }
            else
            {
                pe.Married = false;
            }
            personList.Add(pe);
        }

        // ADDS ALL THE DATA FROM EVERY PERSON CREATED IN THE LIST
        private string AddAllToList()
        {
            Person pe;
            string txtAll = "The persons in this list are: \n\n";

            for (int i = 0; i < personList.Count; i++)
            {
                pe = personList[i];
                txtAll += pe.ShowData();
            }
            return txtAll;
        }

        // BUTTON WHICH SHOW ALL DATA STORED
        private void brnShowData_Click(object sender, EventArgs e)
        {

            MessageBox.Show(AddAllToList());
        }
    }
}
