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
    public partial class Sell : Form
    {

        public Sell()
        {
            InitializeComponent();

        }
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "p2Ac46SpmTF6W0K3tyqtbg8OcoaCjAQgi79VD0YG",
            BasePath = " https://cloud-project-c7e83-default-rtdb.firebaseio.com/ "
        };
        IFirebaseClient client;

        DataTable dt = new DataTable();

        /* public async void Register_Pojo()
         {
             Cursor.Current = Cursors.WaitCursor;
             FirebaseClient fb = new FirebaseClient(FBConfig.url);
             Data obj = new Data();
             obj.Book_Name1 = textBox1.Text;
             obj.Auther_Name1 = textBox2.Text;
             obj.Category1 = comboBox1.Text;
             obj.Year1 = comboBox2.Text;
             obj.Purchese_Date1 = dateTimePicker1.Text;
             obj.Book_Condition1 = comboBox3.Text;
             obj.Prise1 = textBox3.Text;
             obj.Description1 = richTextBox1.Text;


             try
             {
                 await fb.Child("RegisterPojo").PostAsync(obj);
                 MessageBox.Show("Registration Done Successfully");
                 textBox1.Text = "";
                 textBox2.Text = "";
                 comboBox1.Text = "";
                 comboBox2.Text = "";
                 dateTimePicker1.Text = "";
                 comboBox3.Text = "";
                 textBox3.Text = "";
                 richTextBox1.Text = "";

             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error:" + ex);

             }
             Cursor.Current = Cursors.Default;

         }*/


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBox1.Text) == true)

            {
                comboBox1.Focus();
                errorProvider2.SetError(this.comboBox1, "Please select anyone ");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private async void Dataview()
        {
            try
            {
                var firebaseConfig = new FirebaseConfig

                {
                    AuthSecret = "p2Ac46SpmTF6W0K3tyqtbg8OcoaCjAQgi79VD0YG",
                    BasePath = "https://cloud-project-c7e83-default-rtdb.firebaseio.com/"
                };
                var client = new FirebaseClient(firebaseConfig.BasePath);

                // Step 2: Retrieve data from Firebase
                var data = await client.Child("Information").OnceAsync<Data>();

                // Step 3: Create new page
                var newPage = new Form();

                // Step 4: Add datagridview control
                var dataGridView = new DataGridView();
                newPage.Controls.Add(dataGridView);

                // Step 5: Configure datagridview to display data
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = data;

                // Add columns to datagridview for each field you want to display
                dataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Title", HeaderText = "Title" });
                dataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Author", HeaderText = "Author" });
                dataGridView.Columns.Add(new DataGridViewImageColumn { DataPropertyName = "Image", HeaderText = "Image" });

                // Finally, show the new page
                newPage.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(dateTimePicker1.Text) == true)

            {
                dateTimePicker1.Focus();
                errorProvider5.SetError(this.dateTimePicker1, "Please Select Date & time");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            
            ofd.Filter = "jpg|.jpg|png|.png|jpeg|.jpeg|bmp|.bmp|pdf|*.pdf|all|*.*";
            ofd.Filter = "Image Files(*.jpg)|*.jpg";
            //DialogResult dr = ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(ofd.FileName);
                pictureBox1.Image = img.GetThumbnailImage(350, 200, null, new IntPtr());

                //pictureBox1.Image = Bitmap.FromFile(ofd.FileName);
            }

            

        }
       /* private async Task ExportImage()
        {
            // Convert the image to a Base64 encoded string
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);

                // Create an object to store the image data
                Image_Modal data = new Image_Modal
                {
                    Img = base64String
                };

                // Save the image data to the database
                await client.SetAsync("image/", data);
            }

            // Clear the image from the picture box and show a success message
            pictureBox1.Image = null;
            MessageBox.Show("Image inserted successfully.");
        }*/
         private async Task ExportImage()
        {
             MemoryStream ms = new MemoryStream();

             pictureBox1.Image.Save(ms, ImageFormat.Jpeg);

             byte[] a = ms.GetBuffer();

             string output = Convert.ToBase64String(a);

             var data = new Image_Modal
             {
                 Img = output
             };

            

             SetResponse response = await client.SetAsync("Information/Img", data);
             Image_Modal result = response.ResultAs<Image_Modal>();

             //imageBox. Image null;


             MessageBox.Show("Image Inserted");
         }
         
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) == true)

            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please enter a valid Book/Course Name");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBox3.Text) == true)

            {
                comboBox3.Focus();
                errorProvider6.SetError(this.comboBox3, "Please Select Any One");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBox2.Text) == true)

            {
                comboBox2.Focus();
                errorProvider4.SetError(this.comboBox2, "Please Select study of year");
            }
            else
            {
                errorProvider4.Clear();
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text) == true)

            {
                textBox3.Focus();
                errorProvider7.SetError(this.textBox3, "Please enter prize");
            }
            else
            {
                errorProvider7.Clear();
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            
            
            FirebaseResponse resp = await client.GetAsync("Counter/node");
            Counter_class get = resp.ResultAs<Counter_class> ();
            //MessageBox.Show(get.cnd);

            MemoryStream ms = new MemoryStream();

           // pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
            
            

            byte[] a = ms.GetBuffer();

            string output = Convert.ToBase64String(a);


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
                Description = richTextBox1.Text,
                Img = output,
                link = textBox5.Text
            };
            SetResponse response = await client.SetAsync("Information/" + data.ID, data);
            Data result = response.ResultAs<Data>();

            MessageBox.Show("Data Inserted"+ result.ID);

            var obj = new Counter_class
            {
                cnd = data.ID
            };
            response = await client.SetAsync("Counter/node", obj);

         

            ExportImage();

            export();



            /*if (String.IsNullOrEmpty(comboBox1.Text) == true)

             {
                 comboBox1.Focus();
                 errorProvider2.SetError(this.comboBox1, "Please select anyone ");
             }
             else if (String.IsNullOrEmpty(dateTimePicker1.Text) == true)

             {
                 dateTimePicker1.Focus();
                 errorProvider5.SetError(this.dateTimePicker1, "Please Select Date & time");
             }
             else if (String.IsNullOrEmpty(textBox1.Text) == true)

             {
                 textBox1.Focus();
                 errorProvider1.SetError(this.textBox1, "Please enter a valid Book/Course Name");
             }
             else if (String.IsNullOrEmpty(comboBox3.Text) == true)

             {
                 comboBox3.Focus();
                 errorProvider6.SetError(this.comboBox3, "Please Select Any One");
             }
             else if (String.IsNullOrEmpty(textBox3.Text) == true)

             {
                 textBox3.Focus();
                 errorProvider7.SetError(this.textBox3, "Please enter prize");
             }
             else if (String.IsNullOrEmpty(comboBox2.Text) == true)

             {
                 comboBox2.Focus();
                 errorProvider4.SetError(this.comboBox2, "Please Select study of year");
             }
             else
             {
                 Register_Pojo();
             }*/

            //Image Retrive


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {

        }

        private void Sell_Load(object sender, EventArgs e)
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
            dt.Columns.Add("Prise");
            dt.Columns.Add("Description");
            dt.Columns.Add("Image", typeof(Image));


            //dataGridView1.DataSource = dt;

            loadData();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            export();
        }
        private async void export()
        {
           /* dt.Rows.Clear();
            int i = 0;
            FirebaseResponse resp1 = await client.GetAsync("Counter/node");
            if (resp1 != null)
            {
                Counter_class obj1 = resp1.ResultAs<Counter_class>();
                if (obj1 != null)
                {
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
                            row["Prise"] = obj2.Prise;
                            row["Description"] = obj2.Description;

                            byte[] b = Convert.FromBase64String(obj2.Img);
                            MemoryStream ms = new MemoryStream();
                            ms.Write(b, 0, Convert.ToInt32(b.Length));
                            Bitmap bm = new Bitmap(ms, false);

                            row["Image"] = bm;

                            dt.Rows.Add(row);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("error:" + ex);
                        }
                        MessageBox.Show("Done!!");
                    }
                }
                else
                {
                    // Handle the case where obj1 is null
                }
            }
            else
            {
                // Handle the case where resp1 is null
            }
        
       */ 
                
        dt.Rows.Clear();
        int i = 0;
        FirebaseResponse resp1=await client.GetAsync("Counter/node");
        Counter_class obj1 = resp1.ResultAs<Counter_class>();
        int cnd = Convert.ToInt32(obj1.cnd);
            List<Data> list = new List<Data>();
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
                /*row["ID"] = obj2.ID;
                row["Book_Name"] = obj2.Book_Name;
                row["Author_Name"] = obj2.Author_Name;
                row["Category"] = obj2.Category;
                row["Year"] = obj2.Year;
                row["Purchese_Date"] = obj2.Purchese_Date;
                row["Book_Condition"] = obj2.Book_Condition;
                row["Prise"] = obj2.Price;
                row["Description"] = obj2.Description;*/
                    Data c = new Data();
                    c.Author_Name = obj2.Author_Name;
                    c.ID = obj2.ID;
                    c.Book_Name = obj2.Book_Name;
                    c.Author_Name = obj2.Author_Name;
                    c.Category = obj2.Category;
                    c.Year = obj2.Year;
                    c.Purchese_Date = obj2.Purchese_Date;
                    c.Book_Condition = obj2.Book_Condition;
                    c.Price = obj2.Price;
                    c.Description = obj2.Description;
                    c.Img = obj2.Img;


                    list.Add(c);
                //Image code
                byte[] b = Convert.FromBase64String(obj2.Img);
                MemoryStream ms = new MemoryStream();
                ms.Write(b, 0, Convert.ToInt32(b.Length));
                Bitmap bm = new Bitmap(ms, false);
                    bm.Save("d:\\" + i + ".jpg");
              //  row["Image"] = bm;

               // dt.Rows.Add(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show("error:" + ex);
            }


              // dataGridView1.DataSource = list;
        }
        
            MessageBox.Show("Done!!");



        }
        public async void loadData()
        {
            FirebaseResponse resp1 = await client.GetAsync("Counter/node");
            Counter_class obj1 = resp1.ResultAs<Counter_class>();
            int cnd = Convert.ToInt32(obj1.cnd);
            List<Data> list = new List<Data>();
            int i = 0;
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
                    row["Prise"] = obj2.Price;
                    row["Description"] = obj2.Description;
                    Data c = new Data();
                    c.Author_Name = obj2.Author_Name;



                    list.Add(c);
                    /*   //Image code
                       byte[] b = Convert.FromBase64String(obj2.Img);
                       MemoryStream ms = new MemoryStream();
                       ms.Write(b, 0, Convert.ToInt32(b.Length));
                       Bitmap bm = new Bitmap(ms, false);

                       row["Image"] = bm;*/

                    // dt.Rows.Add(row);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error:" + ex);
                }


              ///  dataGridView1.DataSource = list;
            }

           // MessageBox.Show("Done!!");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetAsync("Image");

            Image_Modal image = response.ResultAs<Image_Modal>();

            byte[] b = Convert.FromBase64String(image.Img);

            MemoryStream ms = new MemoryStream();
            ms.Write(b, 0, Convert.ToInt32(b.Length));

            Bitmap bm = new Bitmap(ms, false);
            ms.Dispose();

            pictureBox1.Image = bm;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox5.Text) == true)

            {
                textBox5.Focus();
                errorProvider9.SetError(this.textBox5, "Please enter a valid Drive link");
            }
            else
            {
                errorProvider9.Clear();
            }
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            HomePage Eng = new HomePage();
            Eng.Show();
        }
    }
           
}
