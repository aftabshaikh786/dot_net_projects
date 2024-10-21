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
namespace Book_Lending
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        //Mobile Number
        string patten2 = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

        public async void Add_Payment()
        {
            Cursor.Current = Cursors.WaitCursor;
            FirebaseClient fb = new FirebaseClient(FBConfig.url);
            AddPayment obj = new AddPayment();
            obj.Contact = textBox1.Text;
            obj.Shipping_Address1 = richTextBox1.Text;
            

            try
            {
                await fb.Child("AddPayment").PostAsync(obj);
                MessageBox.Show("Your order is processing");

                textBox1.Text = "";
                richTextBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);

            }
            Cursor.Current = Cursors.Default;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            OnlinePayment Online = new OnlinePayment();
            Online.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox1.Text, patten2) == false)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Enter a valid Mobile number");
            }
            else if (String.IsNullOrEmpty(richTextBox1.Text) == true)

            {
                richTextBox1.Focus();
                errorProvider2.SetError(this.richTextBox1, "Please enter a valid user name");
            }
            else
            {
                Add_Payment();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox1.Text) == true)

            {
                richTextBox1.Focus();
                errorProvider2.SetError(this.richTextBox1, "Please enter a valid user name");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void Payment_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage Eng = new HomePage();
            Eng.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox1.Text, patten2) == false)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Enter a valid Mobile number");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
