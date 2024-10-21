using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using System.Text.RegularExpressions;
using System.IO;

namespace Book_Lending
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        //Password
        string patten = @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$";
        //Email
        string patten1 = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        //Mobile Number
        string patten2 = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

        public async void Register_Pojo()
        {
            Cursor.Current = Cursors.WaitCursor;
            FirebaseClient fb = new FirebaseClient(FBConfig.url);
            Registerpojo obj = new Registerpojo();
            obj.Username1 = txtUserID.Text;
            obj.Email1 = txtEmail.Text;
            obj.Contact1 = txtmobile.Text;
            obj.Password1 = txtPassword.Text;

            try
            {
                await fb.Child("RegisterPojo").PostAsync(obj);
                MessageBox.Show("Registration Done Successfully");
                txtUserID.Text = "";
                txtmobile.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);

            }
            Cursor.Current = Cursors.Default;

        }
        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUserID.Text = "";
            txtmobile.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtConfirmPass.Text = "";
        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUserID.Text) == true)

            {
                txtUserID.Focus();
                errorProvider1.SetError(this.txtUserID, "Please enter a valid user name");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtmobile_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtmobile.Text, patten2) == false)
            {
                txtmobile.Focus();
                errorProvider2.SetError(this.txtmobile, "Enter a valid Mobile number");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtEmail.Text, patten1) == false)
            {
                txtEmail.Focus();
                errorProvider3.SetError(this.txtEmail, "Invalid Email !");
            }
            else
            {
                errorProvider3.Clear();
            }
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            /*if (Regex.IsMatch(txtPassword.Text, patten) == false)
            {
                txtPassword.Focus();
                errorProvider4.SetError(this.txtPassword, "Enter a Strong Password");
            }
            else
            {
                errorProvider4.Clear();
            }*/
        }
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtPassword.Text, patten) == false)
            {
                txtPassword.Focus();
                errorProvider4.SetError(this.txtPassword, "Enter a Strong Password");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void txtConfirmPass_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPass.Text)
            {
                txtConfirmPass.Focus();
                errorProvider5.SetError(this.txtConfirmPass, "Password is not same");
            }
            else
            {
                errorProvider5.Clear();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPass.UseSystemPasswordChar = true;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUserID.Text) == true)

            {
                txtUserID.Focus();
                errorProvider1.SetError(this.txtUserID, "Please enter a valid user name");
            }
            else if (Regex.IsMatch(txtmobile.Text, patten2) == false)
            {
                txtmobile.Focus();
                errorProvider2.SetError(this.txtmobile, "Enter a valid Mobile number");
            }
            else if (Regex.IsMatch(txtEmail.Text, patten1) == false)
            {
                txtEmail.Focus();
                errorProvider3.SetError(this.txtEmail, "Invalid Email !");
            }
            else if (Regex.IsMatch(txtPassword.Text, patten) == false)
            {
                txtPassword.Focus();
                errorProvider4.SetError(this.txtPassword, "Enter a Strong Password");
            }
            else if (txtPassword.Text != txtConfirmPass.Text)
            {
                txtConfirmPass.Focus();
                errorProvider5.SetError(this.txtConfirmPass, "Password is not same");
            }


            else
            {

                Register_Pojo();

                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();

            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
