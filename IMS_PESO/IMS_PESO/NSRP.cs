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
    public partial class NSRP : Form
    {
        public NSRP()
        {
            InitializeComponent();
        }

        private void NSRP_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox17_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton14.Checked == true)
            {
                radioButton18.Checked = false;
                radioButton19.Checked = false;
                radioButton20.Checked = false;
                radioButton21.Checked = false;
                radioButton22.Checked = false;
                radioButton23.Checked = false;
                radioButton24.Checked = false;
                textBox14.Text = string.Empty;
                textBox15.Text = string.Empty;
                groupBox6.Enabled = true;
                groupBox7.Enabled = false;
            }
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton15.Checked == true)
            {
                radioButton16.Checked = false;
                radioButton17.Checked = false;
                groupBox6.Enabled = false;
                groupBox7.Enabled = true;
            }
        }

        private void radioButton25_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton25.Checked == true)
            {
                textBox25.Text = string.Empty;
                textBox26.Text = string.Empty;
                textBox27.Text = string.Empty;
                textBox25.Enabled = false;
                textBox26.Enabled = false;
                textBox27.Enabled = false;

                textBox22.Enabled = true;
                textBox23.Enabled = true;
                textBox24.Enabled = true;
            }
        }

        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton26.Checked == true)
            {
                textBox22.Text = string.Empty;
                textBox23.Text = string.Empty;
                textBox24.Text = string.Empty;
                textBox22.Enabled = false;
                textBox23.Enabled = false;
                textBox24.Enabled = false;

                textBox25.Enabled = true;
                textBox26.Enabled = true;
                textBox27.Enabled = true;
            }
        }
    }
}
