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

            loadTask();

            label4.MaximumSize = new Size(200, 0);
        }
        //Setting Upper Panel to dragable (refs. initMovable.cs and mousedown event on panel)
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        

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
            else if (label4.Text != "~value~" && label4.Text == "SPES Focal Person")
            {
                button1.Enabled = true;
            }
            else if (label4.Text != "~value~" && label4.Text == "OFW Focal Person")
            {
                button12.Enabled = true;
                button13.Enabled = true;
            }
            else if (label4.Text != "~value~" && label4.Text == "RWA Focal Person")
            {
                button10.Enabled = true;
            }
            else if (label4.Text != "~value~" && label4.Text == "PWD Focal Person")
            {
                button15.Enabled = true;
            }
            else if (label4.Text != "~value~" && label4.Text == "NSRP Focal Person")
            {
                button3.Enabled = true;
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
                button15.Enabled = true;
                button1.Enabled = true;
                button3.Enabled = true;
                button13.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                return;
            }
        }

        private void loadTask()
        {
            string query;
            query = @"select code `CODE`, title `TITLE`, `desc` `DESCRIPTION`, assignee `ASSIGNEE`, flag `FLAG` from todo where flag like '%%{0}%%'";
            string FinalQuery = string.Format(query, comboBox2.Text);
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
            f_spes a = new f_spes();
            a.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f_sra a = new f_sra();
            a.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                f_report a = new f_report();
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
            f_contact_list a = new f_contact_list();
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
            f_child_labor a = new f_child_labor();
            a.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            f_college_scholar a = new f_college_scholar();
            a.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            f_ofw a = new f_ofw();
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
            f_rwa a = new f_rwa();
            a.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            f_hsscholar a = new f_hsscholar();
            a.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            f_job_fair a = new f_job_fair();
            a.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            f_report_panel aa = new f_report_panel();
            aa.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            f_ofw a = new f_ofw();
            a.ShowDialog();
            
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            f_pwd a = new f_pwd();
            a.ShowDialog();
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

        private void button3_Click_1(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            f_contact_list a = new f_contact_list();
            a.ShowDialog();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            _todoAdd a = new _todoAdd();
            a.ShowDialog();
            loadTask();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            f_kasambahay a = new f_kasambahay();
            a.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            f_add_user a = new f_add_user();
            a.ShowDialog();
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            string strPending = "update todo set flag = 'DONE' where code = @code";
            string strDone = "update todo set flag = 'PENDING' where code = @code";
            string messPending = "Task Marked as Done!";
            string messDone = "Task Marked as Pending!";
            string qry = null;
            string mess = null;
            if (comboBox2.Text == "PENDING")
            {
                qry = strPending;
                mess = messPending;
            }
            else if (comboBox2.Text == "DONE")
            {
                f_auth val = new f_auth();
                val.ShowDialog();
                if (val.upflag == "1")
                {
                    qry = strDone;
                    mess = messDone;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

            MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            conn.Open();
            MySqlCommand myCommand = conn.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = conn.BeginTransaction();
            myCommand.Connection = conn;
            myCommand.Transaction = myTrans;
            try
            {
                myCommand = conn.CreateCommand();
                myCommand.Parameters.AddWithValue("@code", label7.Text);
                myCommand.CommandText = qry;
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show(this, mess, "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exg)
            {
                try
                {
                    myTrans.Rollback();
                }
                catch (Exception ex)
                {
                    if (myTrans.Connection != null)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                MessageBox.Show(exg.ToString());
            }
            finally
            {
                label7.Text = string.Empty;
                loadTask();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            label7.Text = string.Empty;
            loadTask();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                MessageBox.Show(this, "Select status group!", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    int index = e.RowIndex;
                    DataGridViewRow selected = dataGridView1.Rows[index];
                    label7.Text = selected.Cells[0].Value.ToString();
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            if (comboBox2.Text == "DONE")
            {
                f_auth val = new f_auth();
                val.ShowDialog();
                if (val.upflag == "1")
                {
                    _todoAdd a = new _todoAdd();
                    a.label2.Text = this.label7.Text;
                    a.ShowDialog();
                    loadTask();
                }
                else
                {
                    return;
                }
            }
            else
            {
                _todoAdd a = new _todoAdd();
                a.label2.Text = this.label7.Text;
                a.ShowDialog();
                loadTask();
            }
        }

        private void delete()
        {
            MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            conn.Open();
            MySqlCommand myCommand = conn.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = conn.BeginTransaction();
            myCommand.Connection = conn;
            myCommand.Transaction = myTrans;
            try
            {
                myCommand = conn.CreateCommand();
                myCommand.Parameters.AddWithValue("@code", label7.Text);
                string query = @"delete from todo where code = @code";
                myCommand.CommandText = query;
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show(this, "Task Deleted!", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exg)
            {
                try
                {
                    myTrans.Rollback();
                }
                catch (Exception ex)
                {
                    if (myTrans.Connection != null)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                MessageBox.Show(exg.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            f_auth val = new f_auth();
            val.ShowDialog();
            if (val.upflag == "1")
            {
                delete();
            }
            else
            {
                return;
            }
            loadTask();
        }
    }
}
