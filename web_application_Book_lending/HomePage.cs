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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin_update au = new Admin_update();
            au.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            startpage start = new startpage();
            start.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sell sell = new Sell();
            sell.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Engibook Eng = new Engibook();
            Eng.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Engibook Eng = new Engibook();
            Eng.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            myorder Eng = new myorder();
            Eng.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            mybook Eng = new mybook();
            Eng.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            searchbar fa = new searchbar();
            fa.Show();

        }
    }
}
