using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0301_Linq
{
    public partial class Form1 : Form
    {
        StudenProjectEntities context = new StudenProjectEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Linq Query
            //var result = from s in context.Students
            //             select s;
            //dataGridView1.DataSource = result.ToList();

            //Linq Methods
            var result = context.Students;
            dataGridView1.DataSource = result.ToList();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Linq Query
            
            
            var result = context.Students
                .Where(s => s.student_id == textBox1.Text)
                .Select(s => s);
            dataGridView1.DataSource = result.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = context.Students
                .Where(s => s.student_id == textBox1.Text 
                && s.student_password == textBox2.Text)
                .Select(s => s);
            dataGridView1.DataSource = result.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var result = context.Students
                .OrderByDescending(s => s.student_fullname);
            dataGridView1.DataSource = result.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var result = context.Students
                .Select(s => new { s.student_id, 
                    s.student_fullname })
                .OrderBy(d => d.student_id);
            dataGridView1.DataSource = result.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Number of records: " 
                + context.Students.Count());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            context.Students.Where(s => s.student_id == textBox3.Text)
                .First().student_fullname = textBox7.Text;

            int change = context.SaveChanges();
            MessageBox.Show("Change: " + change + " records");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.student_id = textBox4.Text;
            student.student_fullname = textBox8.Text;

            context.Students.Add(student);
            int change = context.SaveChanges();
            MessageBox.Show("Change: " + change + " records");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            var result = context.Students
                .Where(s => s.student_id == textBox5.Text);
            context.Students.Remove(result.First());
            
            int change = context.SaveChanges();
            MessageBox.Show("Change: " + change + " records");
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var result = context.Students
                .Where(s => s.student_id == textBox6.Text)
                .First().student_image = ImageToByteArray(pictureBox1.Image);

            int change = context.SaveChanges();
            MessageBox.Show("Change: " + change + " records");
        }

        public byte[] ImageToByteArray(Image image)
        {
            var ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }
    }
}
