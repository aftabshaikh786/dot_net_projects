using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Student_Grading_System
{
    public partial class Form1 : Form
    {
        private List<Student> students = new List<Student>();

        public Form1()
        {
            InitializeComponent();
        }

        private void lblClassAverage_Click(object sender, EventArgs e)
        {
        }

        private void txtStudentName_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtStudentScore_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string name = txtStudentName.Text;
            if (double.TryParse(txtStudentScore.Text, out double score))
            {
                Student student = new Student(name, score);
                students.Add(student);
                txtStudentName.Clear();
                txtStudentScore.Clear();
                UpdateDataGridView();
                CalculateClassAverage();
            }
            else
            {
                MessageBox.Show("Please enter a valid score.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void UpdateDataGridView()
        {
            dataGridViewResults.DataSource = null;
            dataGridViewResults.DataSource = students;
        }

        private void CalculateClassAverage()
        {
            if (students.Count > 0)
            {
                double average = students.Average(s => s.Score);
                lblClassAverage.Text = $"Class Average: {average:F2}";
            }
            else
            {
                lblClassAverage.Text = "Class Average: N/A";
            }
        }

        private void SaveData()
        {
            using (StreamWriter writer = new StreamWriter("students.txt"))
            {
                foreach (var student in students)
                {
                    writer.WriteLine($"{student.Name},{student.Score}");
                }
            }
            MessageBox.Show("Data saved successfully.");
        }

        private void LoadData()
        {
            if (File.Exists("students.txt"))
            {
                students.Clear();
                using (StreamReader reader = new StreamReader("students.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var data = line.Split(',');
                        if (data.Length == 2 &&
                            !string.IsNullOrWhiteSpace(data[0]) &&
                            double.TryParse(data[1], out double score))
                        {
                            students.Add(new Student(data[0], score));
                        }
                    }
                }
                UpdateDataGridView();
                CalculateClassAverage();
                MessageBox.Show("Data loaded successfully.");
            }
            else
            {
                MessageBox.Show("No saved data found.");
            }
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public double Score { get; set; }

        public Student(string name, double score)
        {
            Name = name;
            Score = score;
        }
    }
}
