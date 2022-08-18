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
    public partial class zzold_tester : Form
    {
        public zzold_tester()
        {
            InitializeComponent();
        }
        List<string> cities = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cities.Count; i++)
                MessageBox.Show(cities[i].ToString());
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            cities.Clear();
        }
    }
}
