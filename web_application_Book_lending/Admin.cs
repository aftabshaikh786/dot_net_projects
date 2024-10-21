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
    public partial class Admin : Form
    {
        public Admin()
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

        private void Admin_Load(object sender, EventArgs e)
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
            dt.Columns.Add("Yaer");
            dt.Columns.Add("Purchese_Date");
            dt.Columns.Add("Book_Condition");
            dt.Columns.Add("Prise");
            dt.Columns.Add("Description");
            dt.Columns.Add("Image", typeof(Image));


            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private async void export()
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

            byte[] a= ms.GetBuffer();

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
                    row["Auther_Name"] = obj2.Author_Name;
                    row["Category"] = obj2.Category;
                    row["Year"] = obj2.Year;
                    row["Purchese_Date"] = obj2.Purchese_Date;
                    row["Book_Condition"] = obj2.Book_Condition;
                    row["Prise"] = obj2.Price;
                    row["Description"] = obj2.Description;

                   // Image code
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

    }
}
