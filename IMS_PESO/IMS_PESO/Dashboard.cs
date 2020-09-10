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
    public partial class Dashboard : Form
    {
        DBConn DB = new DBConn();
        public Dashboard()
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
            button4.BackColor = ColorTranslator.FromHtml("#14213D");
            button3.BackColor = ColorTranslator.FromHtml("#14213D");
            button5.BackColor = ColorTranslator.FromHtml("#14213D");
            
        }
        //Setting Upper Panel to dragable (refs. initMovable.cs and mousedown event on panel)
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        //
        //private void getCount()
        //{
        //    MySqlConnection conn = new MySqlConnection(DBConn.connstring);
        //    MySqlDataReader myreader;
        //    string query = @"select count(id) `con_count` from contacts";
        //    string finalQuery = string.Format(query);
        //    MySqlCommand cmdmdlr = new MySqlCommand(finalQuery, conn);
        //    try
        //    {
        //        conn.Open();
        //        myreader = cmdmdlr.ExecuteReader();

        //        while (myreader.Read())
        //        {
        //            string contact_count = myreader.GetString("con_count");
        //            label2.Text = contact_count;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally { conn.Close(); }
        //}
        private void Form1_Load(object sender, EventArgs e)
        {
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SRA a = new SRA();
            a.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                report a = new report();
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
            childLabor a = new childLabor();
            a.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HSchoolar a = new HSchoolar();
            a.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
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
            /*
            Remarks
            */
        }
    }
}
