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
    public partial class cengi : Form
    {
        public cengi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payment Eng = new Payment();
            Eng.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage Eng = new HomePage();
            Eng.Show();
        }
    }
}
