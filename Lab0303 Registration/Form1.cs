using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0303_Registration
{
    public partial class Form1 : Form
    {
        APD65_63011212052Entities context = new APD65_63011212052Entities();
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            studentBindingSource1.DataSource = context.Students.ToList();
            subjectBindingSource.DataSource = context.Subjects.ToList();
            registerBindingSource.DataSource = context.Registers
                .Where(r => r.student_id == comboBox1.Text)
                .Select(r => new {
                    r.subject_id,
                    r.Subject.subject_name,
                    r.Subject.subject_credit
                })
                .ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            registerBindingSource.DataSource = context.Registers
                .Where(r => r.student_id == comboBox1.Text)
                .Select(r => new
                {
                    r.subject_id,
                    r.Subject.subject_name,
                    r.Subject.subject_credit
                })
                .ToList();
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            registerBindingSource.DataSource = context.Registers
                .Where(r => r.student_id == comboBox1.Text)
                .Select(r => new 
                {
                    r.subject_id,
                    r.Subject.subject_name,
                    r.Subject.subject_credit
                })
                .ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string student_id = comboBox1.Text;
            string subject_id = dataGridView2.SelectedRows[0]
                .Cells[0].Value.ToString();

            var toDel = context.Registers
                .Where(r => r.student_id == student_id
                && r.subject_id == subject_id);
            context.Registers.Remove(toDel.First());

            int change = context.SaveChanges();
            MessageBox.Show("Change: " +change+ " records");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string student_id = comboBox1.Text;
            string subject_id = dataGridView1.SelectedRows[0]
                .Cells[0].Value.ToString();

            Register register = new Register();
            register.student_id = student_id;
            register.subject_id = subject_id;

            context.Registers.Add(register);
            int change = context.SaveChanges();
            MessageBox.Show("Change: " + change + " records");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          
        }
    }
}
