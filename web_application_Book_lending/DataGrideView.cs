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
    public partial class DataGrideView : Form
    {
        public DataGrideView()
        {
            InitializeComponent();
        }

        private void DataGrideView_Load(object sender, EventArgs e)
        {

        }

        private async void Dataview()
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

        private void button1_Click(object sender, EventArgs e)
        {
            Dataview();
        }
    }
}
