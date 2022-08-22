using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0302_Data_Binding
{
    public partial class Form1 : Form
    {
        StudentEntities context = new StudentEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            studentBindingSource.DataSource = context.Students.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                studentBindingSource.EndEdit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int change = context.SaveChanges();
            MessageBox.Show("Change on " + change + " records");
        }
    }
}
