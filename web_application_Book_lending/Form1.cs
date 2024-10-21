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
using Newtonsoft.Json;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace Book_Lending
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     /*   IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "p2Ac46SpmTF6W0K3tyqtbg8OcoaCjAQgi79VD0YG",
            BasePath= " https://cloud-project-c7e83-default-rtdb.firebaseio.com/ "
        };
        IFirebaseClient client;
        */

        private void Form1_Load(object sender, EventArgs e)
        {
           /* try
            {
                client = new FireSharp.FirebaseClient(ifc);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex);
            }*/
        }

        public async void DataFromCloud()
        {
            Cursor.Current = Cursors.WaitCursor;
            var fb = new FirebaseClient(FBConfig.url);
            Registerpojo obj = new Registerpojo();

            obj.Contact1 = txtcontact.Text;
            obj.Password1 = txtPassword.Text;
            var fbdata = await fb.Child("RegisterPojo").OnceAsync<Registerpojo>();
            int id = 0;
            foreach (var data in fbdata)
            {
                Registerpojo rg = new Registerpojo();
                rg.Contact1 = data.Object.Contact1;
                rg.Password1 = data.Object.Password1;

                if (rg.Contact1 == txtcontact.Text && rg.Password1 == txtPassword.Text)
                {
                    id = 1;
                    MessageBox.Show("Login is done Successfully");
                    HomePage Home = new HomePage();
                    Home.Show();
                    this.Hide();
                    return;
                }
            }
            if (id == 0)
            {
                MessageBox.Show("Invalid user id");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataFromCloud();

           
           

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtcontact.Text = "";
            txtPassword.Text = "";
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Close();
            Registration R1 = new Registration();
            R1.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
            startpage st = new startpage();
            st.Show();
        }
    }
}
