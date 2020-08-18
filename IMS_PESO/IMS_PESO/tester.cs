using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IMS_PESO
{
    public partial class tester : Form
    {
        public tester()
        {
            InitializeComponent();
        }
        List<string> cities = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cities.Count; i++)
                MessageBox.Show(cities[i].ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                MessageBox.Show("t");
            }
            else
            { MessageBox.Show("f"); }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                cities.Add(checkBox1.Text);
            }
            else if (checkBox1.Checked == false)
            {
                cities.Remove(checkBox1.Text);
            }
            return;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                cities.Add(checkBox2.Text);
            }
            else if (checkBox2.Checked == false)
            {
                cities.Remove(checkBox2.Text);
            }
            return;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cities.Clear();
        }
    }
}
