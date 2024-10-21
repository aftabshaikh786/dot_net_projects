using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book_Lending
{
    public partial class myorder : Form
    {
        public myorder()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {

            this.Hide();
            HomePage Eng = new HomePage();
            Eng.Show();
        }
    }
}
