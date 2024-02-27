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
    public partial class AlumnForm : Form
    {
        public AlumnForm()
        {
            InitializeComponent();
        }

        public AlumnList alumnList;
        private void AlumnForm_Load(object sender, EventArgs e)
        {
        }

        public AlumnForm(AlumnList alumnList)
        {
            InitializeComponent();
            this.alumnList = alumnList;
        }
    }
}
