using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Exercise_1
{
    public partial class fHighSchool : Form
    {
        public fHighSchool()
        {
            InitializeComponent();
        }

        DataSet dataSetTeachers;
        SqlDataAdapter dataAdapaterTeachers;
        private int pos;
        private int maxRegistries;

        private void showRegistry(int pos)
        {
            // Objeto que nos permite recoger un registro de la tabla.
            DataRow dRegistry;

            // Cogemos el registro de la posición pos en la tabla Profesores
            dRegistry = dataSetTeachers.Tables["TEACHERS"].Rows[pos];

            // Cogemos el valor de cada una de las columnas del registro
            // y lo ponemos en el textBox correspondiente.

            txtbID.Text = dRegistry[0].ToString();
            txtbName.Text = dRegistry[1].ToString();
            txtbSurnames.Text = dRegistry[2].ToString();
            txtbPhone.Text = dRegistry[3].ToString();
            txtbEmail.Text = dRegistry[4].ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectLink = "Data Source =(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=C:\\Users\\serdiefer\\Desktop\\1-DAW\\PROGRAMMING\\Tema 9\\Exercise 1\\Exercise 1\\App_Data\\Highschool.mdf;" +
            "Integrated Security=True";

            SqlConnection con = new SqlConnection(connectLink);

            // OPENS CONNECTION
            con.Open();

            dataSetTeachers = new DataSet();
            string stringSQL = "SELECT * FROM TEACHERS";

            dataAdapaterTeachers = new SqlDataAdapter(stringSQL, con);

            dataAdapaterTeachers.Fill(dataSetTeachers, "TEACHERS");

            // SETS FIRST POSITION
            pos = 0;
            showRegistry(pos);

            // GETS TOTAL REGISTRIES
            maxRegistries = dataSetTeachers.Tables["TEACHERS"].Rows.Count;

            // CLOSES CONNECTION
            con.Close();

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            pos = 0;
            showRegistry(pos);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            pos = maxRegistries - 1;
            showRegistry(pos);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pos < maxRegistries)
            {
                pos++;
                showRegistry(pos);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pos >= 0)
            {
                pos--;
                showRegistry(pos);
            }
        }
    }
}
