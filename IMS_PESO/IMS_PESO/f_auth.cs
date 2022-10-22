using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IMS_PESO
{
    public partial class f_auth : Form
    {
        DBConn DB = new DBConn();
        public f_auth()
        {
            try
            {
                DB.getDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Opps! It seems like Something is Wrong with your Datasourse!");
                MessageBox.Show(ex.GetType().ToString());
            }
            InitializeComponent();
            panel1.BackColor = ColorTranslator.FromHtml("#FCA311");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string upflag;
        private void auth_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBox3.Text != DB.addminpass)
            {
                upflag = "0";
            }
            else
            {
                upflag = "1";
            }
        }


        private void auth_Load(object sender, EventArgs e)
        {
            //trimming Logo to sphere
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;

            this.BackColor = System.Drawing.Color.DodgerBlue;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    //((TextBox)ctrl).ForeColor = System.Drawing.Color.DodgerBlue;
                }
                else if (ctrl is Label)
                {
                    ((Label)ctrl).ForeColor = System.Drawing.SystemColors.Control;
                }
                else if (ctrl is Button)
                {
                    ((Button)ctrl).ForeColor = System.Drawing.Color.DodgerBlue;
                    ((Button)ctrl).BackColor = System.Drawing.SystemColors.Control;
                }
            }
        }
    }
}
