using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using System.Drawing.Imaging;

namespace Book_Lending
{
    public partial class searchbar : Form
    {
        public searchbar()
        {
            InitializeComponent();
        }

        private void searchbar_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*  DataTable dt = new DataTable();
              dt.Columns.Add("Author_Name");
              dt.Columns.Add(" Book_Name ");
              dt.Columns.Add("Price");
              dt.Columns.Add("Category");

              FirebaseResponse res = client.Get(@"Counter");

              int Counter = int.Parse(res.Results<string>());

              for (int i = 1; i <= Counter; i++)
              {
                  FirebaseResponse res2 client.Get(@"Snolist/" + i + "/Ro11No");

                  string RollNo res2.Results < string();

                  FirebaseResponse res) client.Get(@"Students/" + RollNo);

                  Student std res3.ResultAscstudent > ();


              if (std.FullName")

          }*/
        }
    }
}
