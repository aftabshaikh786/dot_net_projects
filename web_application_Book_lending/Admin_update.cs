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
    public partial class Admin_update : Form
    {
        public Admin_update()
        {
            InitializeComponent();
        }
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "p2Ac46SpmTF6W0K3tyqtbg8OcoaCjAQgi79VD0YG",
            BasePath = " https://cloud-project-c7e83-default-rtdb.firebaseio.com/ "
        };
        IFirebaseClient client;

        DataTable dt = new DataTable();

        private void Admin_update_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                MessageBox.Show("Connection is established");
            }
            dt.Columns.Add("ID");
            dt.Columns.Add("Book_Name");
            dt.Columns.Add("Author_Name");
            dt.Columns.Add("Category");
            dt.Columns.Add("Year");
            dt.Columns.Add("Purchese_Date");
            dt.Columns.Add("Book_Condition");
            dt.Columns.Add("Price");
            dt.Columns.Add("Description");
            dt.Columns.Add("Image", typeof(Image));


            dataGridView1.DataSource = dt;
        }


       /* private async void insert()

        {
            var data = new Data
            {
                //Id = (Convert.ToInt32(get.cnd)+1).ToString(),
                ID = textBox4.Text,
                Book_Name = textBox1.Text,
                Auther_Name = textBox2.Text,
                Category = comboBox1.Text,
                Year = comboBox2.Text,
                Purchese_Date = dateTimePicker1.Text,
                Book_Condition = comboBox3.Text,
                Price = textBox3.Text,
                Description = richTextBox1.Text
                
            };
            SetResponse response = await client.SetAsync("Information/" + textBox4.Text, data);
            Data result = response.ResultAs<Data>();

            MessageBox.Show("Data Inserted" + result.ID);
        }*/

        //retrive a data firebase to c#
        private async void retrive()
        {
            /*FirebaseResponse response = await client.GetTaskAsync("Information/" + textBox1.Text);

            Data obj = response.ResultAs<Data>();

            textBox1.Text = obj.Id;
            textBox2.Text = obj.Name;
            textBox3.Text = obj.Address;
            textBox4.Text = obj.Age;

            MessageBox.Show("Data Retrieved successfully");*/
        }


        //update database
        private async void update()
        {
            /*var data = new Data
            {
                1d = textBox1.Text,
                Name =textBox2.Text,
                Address = textBox3.Text,
                Age = textBox4.Text
            };
            FirebaseResponse response = await client.updateTaskAsync("Information/"+textBox1.Text, data);
            Data result = response.ResultAs<Data>();
            MessageBox.Show("Data updated at ID: " + result.ID );*/
        }



        //Delete ID Form database
        private async void delete()
        {
           // FirebaseResponse response = await client.DeleteTaskAsync("Information/" + textBox1.Text);
           // MessageBox.Show("Deleted REcord of ID: " + textBox1.Text);
        }

        //Delete all elements
        private async void delete_all()
        {
           // FirebaseResponse response = await client.DeleteAsync("Information");
           // MessageBox.Show("All Elements Deleted/ Information node has been deleted");
        }



        //Otomatically id increamented
        private async void IncrementIdomatically()
        {
          /*  FirebaseResponse resp = await client.GetAsync("Counter/node");
            Counter_class get = resp.ResultAs<Counter_class>();

            var data = new Data
            {
                //Id = (Convert.ToInt32(get.cnd)+1).ToString(),
                ID = (Convert.ToInt32(get.cnd) + 1).ToString(),
                Book_Name = textBox1.Text,
                Auther_Name = textBox2.Text,
                Category = comboBox1.Text,
                Year = comboBox2.Text,
                Purchese_Date = dateTimePicker1.Text,
                Book_Condition = comboBox3.Text,
                Price = textBox3.Text,
                Description = richTextBox1.Text

            };
            SetResponse response = await client.SetAsync("Information/" + data.ID, data);
            Data result = response.ResultAs<Data>();

            MessageBox.Show("Data Inserted" + result.ID);

            var obj = new Counter_class
            {
                cnd=data.ID
            };
            SetResponse responses = await client.SetAsync("Counter/node", obj);*/

            
        }



        //Datagrideview
        private async void export()
        {
            dt.Rows.Clear();
            int i = 0;
            FirebaseResponse resp1 = await client.GetAsync("Counter/node");
            Counter_class obj1 = resp1.ResultAs<Counter_class>();
            int cnd = Convert.ToInt32(obj1.cnd);

            while (true)
            {
                if (i == cnd)
                {
                    break;
                }
                i++;
                try
                {
                    FirebaseResponse resp2 = await client.GetAsync("Information/" + i);
                    Data obj2 = resp2.ResultAs<Data>();

                    DataRow row = dt.NewRow();
                    row["ID"] = obj2.ID;
                    row["Book_Name"] = obj2.Book_Name;
                    row["Author_Name"] = obj2.Author_Name;
                    row["Category"] = obj2.Category;
                    row["Year"] = obj2.Year;
                    row["Purchese_Date"] = obj2.Purchese_Date;
                    row["Book_Condition"] = obj2.Book_Condition;
                    row["Price"] = obj2.Price;
                    row["Description"] = obj2.Description;

                    dt.Rows.Add(row);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error:" + ex);
                }
                MessageBox.Show("Done!!");


            }




        }


        //Browse button code for image
        private async void Browse()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image Files(*.jpg) |*.jpg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(ofd.FileName);

                // imageBox.Image = img.GetThumbnailImage(350, 200, null, new IntPtr());
            }
        }


        //image insert to database
        private async void imageinsert()
        {
            //INSERT PictureBox into ms -> byte Array => toBase64String 
            MemoryStream ms = new MemoryStream();
            //      imageBox.Image.Save(ms, ImageFormat.Jpeg);

            byte[] a = ms.GetBuffer();

            string output = Convert.ToBase64String(a);

            var data = new Image_Modal
            {
                Img = output
            };


            SetResponse response = await client.SetAsync("Image/", data);
            Image_Modal result = response.ResultAs<Image_Modal>();
        }


        //image retrived from database
        private async void imageretrive()
        {
            //RETRIEVE base64 -> byte [] -> ms -> BitmMap

            FirebaseResponse response = await client.GetAsync("Image/");

            Image_Modal image = response.ResultAs<Image_Modal>();

            byte[] b = Convert.FromBase64String(image.Img);

            MemoryStream ms = new MemoryStream();
            ms.Write(b, 0, Convert.ToInt32(b.Length));

            Bitmap bm = new Bitmap(ms, false);
            ms.Dispose();

            pictureBox1.Image = bm;
        }

        //insert
        private void button2_Click(object sender, EventArgs e)
        {
            imageretrive();
        }


        //
        private async void exported()
        {

            dt.Rows.Clear();
            int i = 0;
            FirebaseResponse resp1 = await client.GetAsync("Counter/node");
            Counter_class obj1 = resp1.ResultAs<Counter_class>();
            int cnd = Convert.ToInt32(obj1.cnd);

            while (true)
            {
                if (i == cnd)
                {
                    break;
                }
                i++;
                try
                {
                    FirebaseResponse resp2 = await client.GetAsync("Information/" + i);
                    Data obj2 = resp2.ResultAs<Data>();

                    DataRow row = dt.NewRow();
                    row["ID"] = obj2.ID;
                    row["Book_Name"] = obj2.Book_Name;
                    row["Author_Name"] = obj2.Author_Name;
                    row["Category"] = obj2.Category;
                    row["Year"] = obj2.Year;
                    row["Purchese_Date"] = obj2.Purchese_Date;
                    row["Book_Condition"] = obj2.Book_Condition;
                    row["Price"] = obj2.Price;
                    row["Description"] = obj2.Description;
                  //  row["Image"] = obj2.Img;

                    // Image code
                   /* byte[] b = Convert.FromBase64String(obj2.Img);
                    MemoryStream ms = new MemoryStream();
                    ms.Write(b, 0, Convert.ToInt32(b.Length));
                    Bitmap bm = new Bitmap(ms, false);

                    row["Image"] = bm;*/

                    dt.Rows.Add(row);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error:" + ex);
                    break;
                }
                
            }
            MessageBox.Show("Done!!");
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            FirebaseResponse resp = await client.GetAsync("Counter/node");

            Counter_class get = resp.ResultAs<Counter_class>();

            var data = new Data
            {
                //Id = (Convert.ToInt32(get.cnd)+1).ToString(),
                ID = (Convert.ToInt32(get.cnd) + 1).ToString(),
                Book_Name = textBox1.Text,
                Author_Name = textBox2.Text,
                Category = comboBox1.Text,
                Year = comboBox2.Text,
                Purchese_Date = dateTimePicker1.Text,
                Book_Condition = comboBox3.Text,
                Price = textBox3.Text,
                Description = richTextBox1.Text
                

            };
            SetResponse response = await client.SetAsync("Information/" + data.ID, data);
            Data result = response.ResultAs<Data>();

            MessageBox.Show("Data Inserted" + result.ID);

            var obj = new Counter_class
            {
                cnd = data.ID
            };
            SetResponse responses = await client.SetAsync("Counter/node", obj); 



        
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetAsync("Information" + textBox1.Text);

            Data obj = response.ResultAs<Data>();

            textBox4.Text = obj.ID;
            textBox1.Text = obj.Book_Name;
            textBox2.Text = obj.Author_Name;
            comboBox1.Text = obj.Category;
            comboBox2.Text = obj.Year;
            comboBox3.Text = obj.Book_Condition;
            textBox3.Text = obj.Price;
            richTextBox1.Text = obj.Description;



            MessageBox.Show("Data Retrieved successfully");
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var data = new Data
            {
                ID = textBox4.Text,
                Book_Name = textBox1.Text,
                Author_Name = textBox2.Text,
                Category = comboBox1.Text,
                Year = comboBox2.Text,
                Purchese_Date = dateTimePicker1.Text,
                Book_Condition = comboBox3.Text,
                Price = textBox3.Text,
                Description = richTextBox1.Text,
                
            };
            FirebaseResponse response = await client.UpdateAsync("Information/" + textBox4.Text, data);
            Data result = response.ResultAs<Data>();
            MessageBox.Show("Data updated at ID: " + result.ID);
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.DeleteAsync("Information/" + textBox1.Text);
            MessageBox.Show("Deleted REcord of ID: " + textBox1.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            exported();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.DeleteAsync("Information");
            MessageBox.Show("All Elements Deleted/ Information node has been deleted");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image Files(*.jpg) |*.jpg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(ofd.FileName);

                pictureBox1.Image = img.GetThumbnailImage(350, 200, null, new IntPtr());
            }
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            //INSERT PictureBox into ms -> byte Array => toBase64String 
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, ImageFormat.Jpeg);

            byte[] a = ms.GetBuffer();

            string output = Convert.ToBase64String(a);

            var data = new Image_Modal
            {
                Img = output
            };


            SetResponse response = await client.SetAsync("Image/", data);
            Image_Modal result = response.ResultAs<Image_Modal>();
        }

        private async void button7_Click(object sender, EventArgs e)
        {/*
            //RETRIEVE base64 -> byte [] -> ms -> BitmMap

            FirebaseResponse response = await client.GetAsync("Image/");

            Image_Modal image = response.ResultAs<Image_Modal>();

            byte[] b = Convert.FromBase64String(image.Img);

            MemoryStream ms = new MemoryStream();
            ms.Write(b, 0, Convert.ToInt32(b.Length));

            Bitmap bm = new Bitmap(ms, false);
            ms.Dispose();

            pictureBox1.Image = bm;*/
            FirebaseResponse response = await client.GetAsync("Image/");

            Image_Modal image = response.ResultAs<Image_Modal>();

            byte[] b = Convert.FromBase64String(image.Img);

            MemoryStream ms = new MemoryStream();
            ms.Write(b, 0, Convert.ToInt32(b.Length));

            Bitmap bm = new Bitmap(ms, false);
            ms.Dispose();

            pictureBox1.Image = bm;
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void button11_Click(object sender, EventArgs e)
        {

            this.Hide();
            HomePage Eng = new HomePage();
            Eng.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void VisitLink()
        {
            // Change the color of the link text by setting LinkVisited
            // to true.
            linkLabel1.LinkVisited = true;
            //Call the Process.Start method to open the default browser
            //with a URL:
            System.Diagnostics.Process.Start("https://console.firebase.google.com/u/0/project/cloud-project-c7e83/database/cloud-project-c7e83-default-rtdb/data");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
            startpage st = new startpage();
            st.Show();
        }
    }
}
