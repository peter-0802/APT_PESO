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
    public partial class _Dashboard : Form
    {
        DBConn DB = new DBConn();
        public _Dashboard()
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
            //button5.BackColor = ColorTranslator.FromHtml("#14213D");

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;
            getContactList();
        }
        //Setting Upper Panel to dragable (refs. initMovable.cs and mousedown event on panel)
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void getContactList()
        {
            string query;
            query = @"select code `CODE`, surname `SURNAME`, firstname `FIRSTNAME`, middlename `MIDDLE NAME` from contacts";
            string FinalQuery = string.Format(query);
            MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            MySqlCommand cmd = new MySqlCommand(FinalQuery, conn);
            try
            {
                MySqlDataAdapter dgv = new MySqlDataAdapter();
                dgv.SelectCommand = cmd;
                DataTable dbdatasec = new DataTable();
                dgv.Fill(dbdatasec);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdatasec;
                dataGridView1.DataSource = bsource;
                dgv.Update(dbdatasec);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (label4.Text != "~value~" && label4.Text == "SRA & Job Fair Focal Person")
            {
                button2.Enabled = true;
                button9.Enabled = true;
            }
            else if (label4.Text != "~value~" && label4.Text == "College Schoolar Focal Person")
            {
                button7.Enabled = true;
            }
            else if (label4.Text != "~value~" && label4.Text == "HS Schoolar Focal Person")
            {
                button8.Enabled = true;
            }
            else if (label4.Text != "~value~" && label4.Text == "Child Labor Focal Person")
            {
                button6.Enabled = true;
            }
            else if (label4.Text != "~value~" && (label4.Text == "Administrator" || label4.Text == "tester"))
            {
                button2.Enabled = true;
                button9.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button12.Enabled = true;
                button10.Enabled = true;
                button6.Enabled = true;
            }
            else
            {
                return;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                initMovable.ReleaseCapture();
                initMovable.SendMessage(Handle, initMovable.WM_NCLBUTTONDOWN, initMovable.HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SPES a = new SPES();
            a.ShowDialog();
            getContactList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _SRA a = new _SRA();
            a.ShowDialog();
            getContactList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                _report a = new _report();
                a.qry = @"select
                            code `CODE`,
                            surname `SURNAME`,
                            firstname `FIRSTNAME`,
                            middlename `MIDDLENAME`,
                            suffix `SUFFIX`,
                            brgy `BARANGAY`
                            from contacts";
                a.ShowDialog();
            }
        private void button4_Click(object sender, EventArgs e)
        {
            contactList a = new contactList();
            a.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Login a = new Login();
            a.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _childLabor a = new _childLabor();
            a.ShowDialog();
            getContactList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _collegeSchoolar a = new _collegeSchoolar();
            a.ShowDialog();
            getContactList();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            _OFW a = new _OFW();
            a.ShowDialog();
            /*
            passport
            country
            address
            contact no
            emp status
            -active
            -inactive
            remarks
            */
        }

        private void button10_Click(object sender, EventArgs e)
        {
            _RWA a = new _RWA();
            a.ShowDialog();
            getContactList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _HSschoolar a = new _HSschoolar();
            a.ShowDialog();
            getContactList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            _jobFair a = new _jobFair();
            a.ShowDialog();
            getContactList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _report a = new _report();
            string iQry = @"select YEAR, BEARS, DOLHINS, WHALES from test";

            dataset ds = new dataset();
            using (MySqlConnection conn = new MySqlConnection(DBConn.connstring))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(iQry, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds, ds.Tables["graph"].TableName);
                _cr_GraphStat rep = new _cr_GraphStat();
                rep.SetDataSource(ds);
                a.crystalReportViewer1.ReportSource = rep;
                a.ShowDialog();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            _OFW a = new _OFW();
            a.ShowDialog();
            getContactList();
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            _PWD a = new _PWD();
            a.Show();
            getContactList();
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }
    }
}
