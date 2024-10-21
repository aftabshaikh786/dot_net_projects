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
    public partial class Engibook : Form
    {
        public Engibook()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            engiphy Eng = new engiphy();
            Eng.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            engimech Eng = new engimech();
            Eng.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            sf Eng = new sf();
            Eng.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            this.Hide();
            Aero Eng = new Aero();
            Eng.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            this.Hide();
            cengi Eng = new cengi();
            Eng.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage Eng = new HomePage();
            Eng.Show();
        }
    }
}
