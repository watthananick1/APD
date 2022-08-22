using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Amz
{
    public partial class Form1 : Form
    {
        APD65_63011212052Entities1 context = new APD65_63011212052Entities1();
        int T_id = 2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            aTypeBindingSource2.DataSource = context.AType.ToList();
            aDtypeBindingSource.DataSource = context.ADtype.ToList();
            aOrderItemBindingSource.DataSource = context.AOrderItem.ToList();
            orderProductBindingSource.DataSource = context.OrderProduct.ToList();
            Console.WriteLine(T_id);
            aPrductBindingSource.DataSource = context.APrduct
                .Where(p => p.AType.Id == T_id)
                .Select(p => new
                {
                    p.Id,
                    p.P_Name,
                    p.UnitPrice,
                })
                .OrderByDescending(p => p.P_Name)
                .ToList();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void aTypeBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Console.WriteLine(T_id);
            aPrductBindingSource.DataSource = context.APrduct
                .Where(p => p.AType.Id == T_id)
                .Select(p => new
                {
                    p.Id,
                    p.P_Name,
                    p.UnitPrice,
                })
                .ToList();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Console.WriteLine(T_id);
            aPrductBindingSource.DataSource = context.APrduct
                .Where(p => p.AType.Id == T_id)
                .Select(p => new
                {
                    p.Id,
                    p.P_Name,
                    p.UnitPrice,
                })
                .ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Console.WriteLine(dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e != null) {
                numericUpDown1.Focus();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                int id = int.Parse(textBox1.Text);
                var result = context.APrduct.Where(p => p.Id == id).First();
                string[] item = new string[] {
                    result.Id.ToString(),
                    result.P_Name,
                    result.UnitPrice.ToString(),
                    numericUpDown1.Value.ToString(),
                    (result.UnitPrice * numericUpDown1.Value).ToString()
                };
                listView1.Items.Add(new ListViewItem(item));
                decimal sum = calculateTotal(listView1.Items);
                label8.Text = sum.ToString();
            }
        }

        private decimal calculateTotal(ListView.ListViewItemCollection items)
        {
            decimal sum = 0;
            foreach (ListViewItem item in items)
            {
                sum += decimal.Parse(item.SubItems[4].Text);
            }
            return sum;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OrderProduct order = new OrderProduct();
            order.OrderDate = DateTime.Now;
            order.TotalPrice = decimal.Parse(label8.Text);

            context.OrderProduct.Add(order);
            int count = context.SaveChanges();
            if (count > 0)
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    AOrderItem O_Item = new AOrderItem();
                    O_Item.O_id = order.Id;
                    O_Item.P_id = int.Parse(item.SubItems[0].Text);
                    O_Item.Quantity = int.Parse(item.SubItems[3].Text);
                    O_Item.U_price = decimal.Parse(item.SubItems[2].Text);
                    O_Item.P_name = item.SubItems[1].Text;
                    context.AOrderItem.Add(O_Item);
                    context.SaveChanges();
                }
                orderProductBindingSource.DataSource = context.OrderProduct.ToList();
                listView1.Items.Clear();
                label8.Text = "0.00";
            }
            else
            {
                MessageBox.Show("Order Failed");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(dataGridView2.SelectedRows[0]
                .Cells[0].Value.ToString());
            int id = int.Parse(dataGridView2.SelectedRows[0]
                .Cells[0].Value.ToString());
            aOrderItemBindingSource1.DataSource = context.AOrderItem.Where(p => p.O_id == id).ToList();
            label11.Text = context.OrderProduct.Where(p => p.Id == id).First().TotalPrice.ToString();


        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                OrderProduct order = new OrderProduct();
                order.OrderDate = DateTime.Now;
                order.TotalPrice = decimal.Parse(label8.Text);

                context.OrderProduct.Add(order);
                int count = context.SaveChanges();
                if (count > 0)
                {
                    foreach (ListViewItem item in listView1.Items)
                    {
                        AOrderItem O_Item = new AOrderItem();
                        O_Item.O_id = order.Id;
                        O_Item.P_id = int.Parse(item.SubItems[0].Text);
                        O_Item.Quantity = int.Parse(item.SubItems[3].Text);
                        O_Item.U_price = decimal.Parse(item.SubItems[2].Text);
                        O_Item.P_name = item.SubItems[1].Text;
                        context.AOrderItem.Add(O_Item);
                        context.SaveChanges();
                    }
                    orderProductBindingSource.DataSource = context.OrderProduct.ToList();
                    MessageBox.Show("Order Successfully");
                }
                else
                {
                    MessageBox.Show("Order Failed");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            T_id = 1;
            Console.WriteLine(T_id);
            
            aPrductBindingSource.DataSource = context.APrduct
                .Where(p => p.AType.Id == T_id)
                .Select(p => new
                {
                    p.Id,
                    p.P_Name,
                    p.UnitPrice,
                })
                .ToList();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            T_id = 2;
            Console.WriteLine(T_id);
            aPrductBindingSource.DataSource = context.APrduct
                .Where(p => p.AType.Id == T_id)
                .Select(p => new
                {
                    p.Id,
                    p.P_Name,
                    p.UnitPrice,
                })
                .ToList();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            T_id = 3;
            Console.WriteLine(T_id);
            aPrductBindingSource.DataSource = context.APrduct
                .Where(p => p.AType.Id == T_id)
                .Select(p => new
                {
                    p.Id,
                    p.P_Name,
                    p.UnitPrice,
                })
                .ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            label8.Text = "0.00";
        }
    }
}
