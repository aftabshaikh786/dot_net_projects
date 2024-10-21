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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = txtcontact.Text;
            pass = txtPassword.Text;
            if(user=="9158552430" && pass=="Ajay@209")
            {
                MessageBox.Show("Login Successfull");
                this.Close();
                Admin_update ad = new Admin_update();
                ad.Show();

            }
            else
            {
                MessageBox.Show("Login error");
            }
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtcontact_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtcontact.Text = "";
            txtPassword.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
            startpage st = new startpage();
            st.Show();
        }
    }
}
