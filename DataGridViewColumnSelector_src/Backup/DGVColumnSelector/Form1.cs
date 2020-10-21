using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DGVColumnSelector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Reading the data
            DataSet ds = new DataSet();
            ds.ReadXml(@"Quarterly_orders.xml");
            // Databinding
            dataGridView1.DataSource = ds.Tables[0];

            // Use of the DataGridViewColumnSelector
            DataGridViewColumnSelector cs = new DataGridViewColumnSelector(dataGridView1);
            cs.MaxHeight = 100;
            cs.Width = 110;
        }
    }
}