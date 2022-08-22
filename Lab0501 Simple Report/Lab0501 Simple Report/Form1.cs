using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0501_Simple_Report
{
    public partial class Form1 : Form
    {
        APD65_63011212052Entities1 context = new APD65_63011212052Entities1();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = context.Orders.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var orders = context.Orders;
            crystalReport11.Database.Tables["Lab0501_Simple_Report_Order"]
                .SetDataSource(orders);
            crystalReportViewer1.ReportSource = crystalReport11;
            crystalReportViewer1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var orders = context.Orders;
            crystalReport21.Database.Tables["Lab0501_Simple_Report_Order"]
                .SetDataSource(orders);
            crystalReportViewer1.ReportSource = crystalReport21;
            crystalReportViewer1.Show();
        }
    }
}
