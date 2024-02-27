using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_6
{
    public partial class TeacherForm : Form
    {
        public TeacherForm()
        {
            InitializeComponent();
        }

        public TeacherList teacherList;
        private void TeacherForm_Load(object sender, EventArgs e)
        {
        }
 
        public TeacherForm (TeacherList teacherList)
        {
            InitializeComponent();
            this.teacherList = teacherList;
        }
    }
}
