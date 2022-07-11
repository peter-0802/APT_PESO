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
    public partial class f_dashboard : Form
    {
        DBConn DB = new DBConn();
        public f_dashboard()
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

            //trimming Logo to sphere
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;
        }

        private void _Dashboard_new_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void addRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_sra a = new f_sra();
            a.ShowDialog();
        }

        private void recordsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
          //  this.recordsToolStripMenuItem.ForeColor = Color.Black;
        }

        private void recordsToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
           // this.recordsToolStripMenuItem.ForeColor = Color.White;
        }

        private void addRecordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            f_child_labor a = new f_child_labor();
            a.ShowDialog();
        }

        private void addRecordToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            f_job_fair a = new f_job_fair();
            a.ShowDialog();
        }

        private void addRecordToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            f_pwd a = new f_pwd();
            a.ShowDialog();
        }

        private void collegeScholarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addRecordToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            f_college_scholar a = new f_college_scholar();
            a.ShowDialog();
        }

        private void addRecordToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            f_spes a = new f_spes();
            a.ShowDialog();
        }

        private void addRecordToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            f_hsscholar a = new f_hsscholar();
            a.ShowDialog();
        }

        private void addRecordToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            f_ofw a = new f_ofw();
            a.ShowDialog();
        }

        private void kasambahayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_kasambahay a = new f_kasambahay();
            a.ShowDialog();
        }

        private void rWAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_rwa a = new f_rwa();
            a.ShowDialog();
        }

        private void addRecordToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            f_contact_list a = new f_contact_list();
            a.ShowDialog();
        }

        public void loadContent()
        {
            //try
            //{
            //    using (MySqlConnection conn = new MySqlConnection(DBConn.connstring))
            //    {
            //        string qry = @"SELECT * FROM v_dashboard";
            //        conn.Open();
            //        MySqlCommand cmd = new MySqlCommand(qry, conn);
            //        MySqlDataReader reader = cmd.ExecuteReader();
            //        if (reader.Read())
            //        {
            //            chart1.Series["data"].Points.AddXY("SRA", int.Parse(reader.GetString("sra")));
            //            chart1.Series["data"].Points.AddXY("PWD", int.Parse(reader.GetString("pwd")));
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void _Dashboard_new_Load(object sender, EventArgs e)
        {
            loadContent();
            if(this.label4.Text == "Administrator")
            {
                this.button4.Enabled = true;
            }
            else
            {
                this.button4.Enabled = false;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Login a = new Login();
            a.Show();
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            f_add_user a = new f_add_user();
            a.ShowDialog();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            loadContent();
        }

        private void addRecordToolStripMenuItem5_Click_1(object sender, EventArgs e)
        {
            f_spes a = new f_spes();
        }
    }
}
