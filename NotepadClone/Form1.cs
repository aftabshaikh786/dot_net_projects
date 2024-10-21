using System;
using System.IO;
using System.Windows.Forms;

namespace NotepadClone
{
    public partial class Form1 : Form
    {
        private string currentFile = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        // This method is triggered when the "New" menu item is clicked.
        private void menuNew_Click(object sender, EventArgs e)
        {
            txtContent.Clear();
            currentFile = string.Empty;
        }

        // This method is triggered when the "Open" menu item is clicked.
        private void menuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFile = openFileDialog.FileName;
                txtContent.Text = File.ReadAllText(currentFile);
            }
        }

        // This method is triggered when the "Save" menu item is clicked.
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Save file logic here
            if (string.IsNullOrEmpty(currentFile))
            {
                SaveFileAs();
            }
            else
            {
                File.WriteAllText(currentFile, txtContent.Text);
            }
        }

        // This method is triggered when the "Save As" menu item is clicked.
        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void SaveFileAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFile = saveFileDialog.FileName;
                File.WriteAllText(currentFile, txtContent.Text);
            }
        }

        // This method is triggered when the "Exit" menu item is clicked.
        private void exitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }

        // Cut, Copy, Paste methods (for Edit menu functionality)
        private void menuCut_Click(object sender, EventArgs e)
        {
            txtContent.Cut();
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            txtContent.Copy();
        }

        private void menuPaste_Click(object sender, EventArgs e)
        {
            txtContent.Paste();
        }

        // About Notepad (Help menu functionality)
        private void menuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Notepad Clone - A simple text editor", "About Notepad");
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }
    }
}
