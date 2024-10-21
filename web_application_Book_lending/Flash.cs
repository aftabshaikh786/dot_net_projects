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
    public partial class Flash : Form
    {
        int ticks;
        public Flash()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks++;
            if (ticks == 2)
            {
                startpage Home = new startpage();
                Home.Show();
                this.Hide();
                timer1.Stop();
            }
        }

        private void Flash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
