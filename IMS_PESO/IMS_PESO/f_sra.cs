using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace IMS_PESO
{
    public partial class f_sra : Form
    {
        DBConn DB = new DBConn();
        public f_sra()
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
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void button16_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void getEvent()
        {
            string query = @"select sra_no `SRA NO.`, event_date `DATE` from sra2 group by sra_no";
            MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                MySqlDataAdapter dgv = new MySqlDataAdapter();
                dgv.SelectCommand = cmd;
                DataTable dbdatasec = new DataTable();
                dgv.Fill(dbdatasec);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdatasec;
                dataGridView2.DataSource = bsource;
                dgv.Update(dbdatasec);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();;
            }
        }
        private void childLabor_Load(object sender, EventArgs e)
        {
            getEvent();
        }

        private void insert()
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
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                        myCommand = conn.CreateCommand();
                        if (row.IsNewRow) continue;
                        myCommand.Parameters.AddWithValue("@acency", textBox1.Text);
                        myCommand.Parameters.AddWithValue("@sra", textBox2.Text);
                        myCommand.Parameters.AddWithValue("@venue", textBox4.Text);
                        myCommand.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                        myCommand.Parameters.AddWithValue("@host", textBox3.Text);
                        myCommand.Parameters.AddWithValue("@branch", textBox5.Text);
                        myCommand.Parameters.AddWithValue("@rep_no", textBox6.Text);
                    
                        myCommand.Parameters.AddWithValue("@surname", row.Cells["surname"].Value);
                        myCommand.Parameters.AddWithValue("@firstname", row.Cells["firstname"].Value);
                        myCommand.Parameters.AddWithValue("@middlename", row.Cells["middlename"].Value);

                        myCommand.Parameters.AddWithValue("@address", row.Cells["address"].Value);
                        myCommand.Parameters.AddWithValue("@age", row.Cells["age"].Value);
                        myCommand.Parameters.AddWithValue("@gender", row.Cells["gender"].Value);

                        myCommand.Parameters.AddWithValue("@position", row.Cells["position"].Value);
                        myCommand.Parameters.AddWithValue("@jobsite", row.Cells["jobsite"].Value);
                        myCommand.Parameters.AddWithValue("@remarks", row.Cells["remarks"].Value);

                        myCommand.Parameters.AddWithValue("@notes", "notes");
                        string query = @"insert ignore into sra
                                        (Agency, sra_no, veneu, event_date, host, address_branch, rep_contact, surname, firstname, middlename, address, age, gender, position, jobsite, remarks, notes)
                                        values
                                        (@acency, @sra, @venue, @date, @host, @branch, @rep_no, @surname, @firstname, @middlename, @address, @age, @gender, @position, @jobsite, @remarks, @notes)";
                        myCommand.CommandText = query;
                        myCommand.ExecuteNonQuery();
                }
                myTrans.Commit();
                MessageBox.Show(this, "Record Added!", "System Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void insertToContact()
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
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    myCommand = conn.CreateCommand();
                    if (row.IsNewRow) continue;
                    myCommand.Parameters.AddWithValue("@surname", row.Cells["surname"].Value);
                    myCommand.Parameters.AddWithValue("@firstname", row.Cells["firstname"].Value);
                    myCommand.Parameters.AddWithValue("@middlename", row.Cells["middlename"].Value);
                    myCommand.Parameters.AddWithValue("@gender", row.Cells["gender"].Value);
                    string query = @"insert ignore into contacts
                                        (code, surname, firstname, middlename, sex)
                                        values
                                        ((select if (count(id) <= 0, 'CON - 1', concat('CON - ', max(id) + 1)) code from contacts as code), @surname, @firstname, @middlename, @gender)";
                    myCommand.CommandText = query;
                    myCommand.ExecuteNonQuery();
                }
                myTrans.Commit();
                MessageBox.Show(this, "Contacts added to masterlist!", "System Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void insertToContact2()
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
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    myCommand = conn.CreateCommand();
                    if (row.IsNewRow) continue;
                    myCommand.Parameters.AddWithValue("@acency", textBox1.Text);
                    myCommand.Parameters.AddWithValue("@sra", textBox2.Text);
                    myCommand.Parameters.AddWithValue("@venue", textBox4.Text);
                    myCommand.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                    myCommand.Parameters.AddWithValue("@host", textBox3.Text);
                    myCommand.Parameters.AddWithValue("@branch", textBox5.Text);
                    myCommand.Parameters.AddWithValue("@rep_no", textBox6.Text);
                    myCommand.Parameters.AddWithValue("@surname", row.Cells["surname"].Value);
                    myCommand.Parameters.AddWithValue("@firstname", row.Cells["firstname"].Value);
                    myCommand.Parameters.AddWithValue("@middlename", row.Cells["middlename"].Value);
                    myCommand.Parameters.AddWithValue("@gender", row.Cells["gender"].Value);
                    myCommand.Parameters.AddWithValue("@dob", row.Cells["dob"].Value);
                    myCommand.Parameters.AddWithValue("@age", row.Cells["age"].Value);
                    myCommand.Parameters.AddWithValue("@civil", row.Cells["civil"].Value);
                    myCommand.Parameters.AddWithValue("@religion", row.Cells["religion"].Value);
                    myCommand.Parameters.AddWithValue("@address", row.Cells["address"].Value);
                    myCommand.Parameters.AddWithValue("@municipality", "MAGSAYSAY");
                    myCommand.Parameters.AddWithValue("@province", "DAVAO DEL SUR");
                    myCommand.Parameters.AddWithValue("@email", row.Cells["email"].Value);
                    myCommand.Parameters.AddWithValue("@contact", row.Cells["contact"].Value);
                    myCommand.Parameters.AddWithValue("@pppp", row.Cells["pppp"].Value);
                    myCommand.Parameters.AddWithValue("@emp_status", row.Cells["emp_status"].Value);
                    myCommand.Parameters.AddWithValue("@job_pre", row.Cells["position"].Value);
                    myCommand.Parameters.AddWithValue("@educ_level", row.Cells["educ_level"].Value);
                    myCommand.Parameters.AddWithValue("@skills", row.Cells["skills"].Value);
                    myCommand.Parameters.AddWithValue("@position", row.Cells["position"].Value);
                    myCommand.Parameters.AddWithValue("@jobsite", row.Cells["jobsite"].Value);
                    myCommand.Parameters.AddWithValue("@remarks", row.Cells["remarks"].Value);
                    myCommand.Parameters.AddWithValue("@from", "SRA");
                    string query = @"insert ignore into sra2
                                        (Agency, sra_no, veneu, event_date, host, address_branch, rep_contact,
                                         surname, firstname, middlename, dob, age, sex, civil_status, religion,
                                         brgy, municipality, province, email, cp_no, 4ps, emp_status, job_pre, educ_level, skills, position, jobsite, remarks, `from`)
                                        values
                                        (@acency, @sra, @venue, @date, @host, @branch, @rep_no,
                                         @surname, @firstname, @middlename, @dob, @age, @gender, @civil, @religion,
                                         @address, @municipality, @province, @email, @contact, @pppp, @emp_status, @job_pre, @educ_level, @skills, @position, @jobsite, @remarks, @from)";
                    myCommand.CommandText = query;
                    myCommand.ExecuteNonQuery();
                }
                myTrans.Commit();
                MessageBox.Show(this, "Contacts Added!", "System Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void update()
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

                myCommand.Parameters.AddWithValue("@sra", label9.Text);
                string qD = @"delete from sra2 where sra_no = @sra;";
                myCommand.CommandText = qD;
                myCommand.ExecuteNonQuery();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    myCommand = conn.CreateCommand();
                    if (row.IsNewRow) continue;
                    myCommand.Parameters.AddWithValue("@acency", textBox1.Text);
                    myCommand.Parameters.AddWithValue("@sra", textBox2.Text);
                    myCommand.Parameters.AddWithValue("@venue", textBox4.Text);
                    myCommand.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                    myCommand.Parameters.AddWithValue("@host", textBox3.Text);
                    myCommand.Parameters.AddWithValue("@branch", textBox5.Text);
                    myCommand.Parameters.AddWithValue("@rep_no", textBox6.Text);
                    myCommand.Parameters.AddWithValue("@surname", row.Cells["surname"].Value);
                    myCommand.Parameters.AddWithValue("@firstname", row.Cells["firstname"].Value);
                    myCommand.Parameters.AddWithValue("@middlename", row.Cells["middlename"].Value);
                    myCommand.Parameters.AddWithValue("@gender", row.Cells["gender"].Value);
                    myCommand.Parameters.AddWithValue("@dob", row.Cells["dob"].Value);
                    myCommand.Parameters.AddWithValue("@age", row.Cells["age"].Value);
                    myCommand.Parameters.AddWithValue("@civil", row.Cells["civil"].Value);
                    myCommand.Parameters.AddWithValue("@religion", row.Cells["religion"].Value);
                    myCommand.Parameters.AddWithValue("@address", row.Cells["address"].Value);
                    myCommand.Parameters.AddWithValue("@municipality", "MAGSAYSAY");
                    myCommand.Parameters.AddWithValue("@province", "DAVAO DEL SUR");
                    myCommand.Parameters.AddWithValue("@email", row.Cells["email"].Value);
                    myCommand.Parameters.AddWithValue("@contact", row.Cells["contact"].Value);
                    myCommand.Parameters.AddWithValue("@pppp", row.Cells["pppp"].Value);
                    myCommand.Parameters.AddWithValue("@emp_status", row.Cells["emp_status"].Value);
                    myCommand.Parameters.AddWithValue("@job_pre", row.Cells["position"].Value);
                    myCommand.Parameters.AddWithValue("@educ_level", row.Cells["educ_level"].Value);
                    myCommand.Parameters.AddWithValue("@skills", row.Cells["skills"].Value);
                    myCommand.Parameters.AddWithValue("@position", row.Cells["position"].Value);
                    myCommand.Parameters.AddWithValue("@jobsite", row.Cells["jobsite"].Value);
                    myCommand.Parameters.AddWithValue("@remarks", row.Cells["remarks"].Value);
                    myCommand.Parameters.AddWithValue("@from", "SRA");
                    string query = @"insert ignore into sra2
                                        (Agency, sra_no, veneu, event_date, host, address_branch, rep_contact,
                                         surname, firstname, middlename, dob, age, sex, civil_status, religion,
                                         brgy, municipality, province, email, cp_no, 4ps, emp_status, job_pre, educ_level, skills, position, jobsite, remarks, `from`)
                                        values
                                        (@acency, @sra, @venue, @date, @host, @branch, @rep_no,
                                         @surname, @firstname, @middlename, @dob, @age, @gender, @civil, @religion,
                                         @address, @municipality, @province, @email, @contact, @pppp, @emp_status, @job_pre, @educ_level, @skills, @position, @jobsite, @remarks, @from)";
                    myCommand.CommandText = query;
                    myCommand.ExecuteNonQuery();
                }
                myTrans.Commit();
                MessageBox.Show(this, "Record Updated!", "System Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrWhiteSpace(textBox2.Text) || String.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show(this, "Looks like some fields are empty :-(", "System Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MySqlConnection conn = new MySqlConnection(DBConn.connstring);
                MySqlDataReader myreader;
                string query = @"select agency from sra2 where agency = '{0}'";
                string q2 = string.Format(query, textBox1.Text);
                MySqlCommand cmdmdlr = new MySqlCommand(q2, conn);
                try
                {
                    conn.Open();
                    myreader = cmdmdlr.ExecuteReader();

                    if (myreader.Read())
                    {
                        MessageBox.Show(this, "This agency already exist please change agency title :-)", "System Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Focus();
                    }
                    else
                    {
                        insertToContact2();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { conn.Close(); }
            }
        }
        
        private void textBox1_Leave(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            MySqlDataReader myreader;
            string query = @"select agency from sra2 where agency = '{0}'";
            string q2 = string.Format(query, textBox1.Text);
            MySqlCommand cmdmdlr = new MySqlCommand(q2, conn);
            try
            {
                conn.Open();
                myreader = cmdmdlr.ExecuteReader();

                if (myreader.Read())
                {
                    MessageBox.Show(this, "This agency already exist please change agency title :-)", "System Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == this.dataGridView1.Columns[3].Index))
            {
                DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "use MM-dd-yyyy format";
            }

            if (e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }


        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           label9.Text = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f_auth a = new f_auth();
            a.ShowDialog();
            if (a.upflag == "1")
            {
                if (String.IsNullOrWhiteSpace(label9.Text) || label9.Text == "~code~")
                {
                    MessageBox.Show(this, "Please select an agency to delete", "System Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
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
                        myCommand.Parameters.AddWithValue("@sra", label9.Text);
                        string qD = @"delete from sra2 where sra_no = @sra;";
                        myCommand.CommandText = qD;
                        myCommand.ExecuteNonQuery();
                        myTrans.Commit();
                        MessageBox.Show(this, "Record Deleted", "System Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    getEvent();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Oops, Wrong Password :P", "System Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void getAttendee()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            string query;
            query = @"SELECT * from sra2 where sra_no = '{0}'";
            string FinalQuery = string.Format(query, label9.Text);
            MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            MySqlCommand cmd = new MySqlCommand(FinalQuery, conn);
            try
            {
                MySqlDataAdapter dgv = new MySqlDataAdapter();
                dgv.SelectCommand = cmd;
                DataTable dbdatasec1 = new DataTable();
                dgv.Fill(dbdatasec1);
                for (int i = 0; i < dbdatasec1.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["surname"].Value = dbdatasec1.Rows[i]["surname"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["firstname"].Value = dbdatasec1.Rows[i]["firstname"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["middlename"].Value = dbdatasec1.Rows[i]["middlename"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["dob"].Value = dbdatasec1.Rows[i]["dob"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["gender"].Value = dbdatasec1.Rows[i]["sex"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["address"].Value = dbdatasec1.Rows[i]["brgy"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["age"].Value = dbdatasec1.Rows[i]["age"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["religion"].Value = dbdatasec1.Rows[i]["religion"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["gender"].Value = dbdatasec1.Rows[i]["sex"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["civil"].Value = dbdatasec1.Rows[i]["civil_status"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["address"].Value = dbdatasec1.Rows[i]["brgy"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["email"].Value = dbdatasec1.Rows[i]["email"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["contact"].Value = dbdatasec1.Rows[i]["cp_no"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["pppp"].Value = dbdatasec1.Rows[i]["4ps"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["emp_status"].Value = dbdatasec1.Rows[i]["emp_status"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["educ_level"].Value = dbdatasec1.Rows[i]["educ_level"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["skills"].Value = dbdatasec1.Rows[i]["skills"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["position"].Value = dbdatasec1.Rows[i]["position"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["jobsite"].Value = dbdatasec1.Rows[i]["jobsite"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["remarks"].Value = dbdatasec1.Rows[i]["remarks"].ToString();
                }
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

        private void label9_TextChanged(object sender, EventArgs e)
        {
            if (label9.Text != "~code~" && !String.IsNullOrWhiteSpace(label9.Text))
            {
                button6.Enabled = false;
                button1.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
            MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            MySqlDataReader myreader;
            string query = @"select
                                agency,
                                sra_no,
                                event_date,
                                veneu,
                                host,
                                address_branch,
                                rep_contact
                                from sra2
                                where sra_no = '{0}'
                                group by sra_no";
            string finalQuery = string.Format(query, label9.Text);
            MySqlCommand cmdmdlr = new MySqlCommand(finalQuery, conn);
            try
            {
                conn.Open();
                myreader = cmdmdlr.ExecuteReader();

                if (myreader.Read())
                {
                    string date = myreader.GetString("event_date");
                    dateTimePicker1.Text = date;

                    string eevent = myreader.GetString("agency");
                    textBox1.Text = eevent;

                    string sra_no = myreader.GetString("sra_no");
                    textBox2.Text = sra_no;

                    string veneu = myreader.GetString("veneu");
                    textBox4.Text = veneu;

                    string host = myreader.GetString("host");
                    textBox3.Text = host;

                    string badress = myreader.GetString("address_branch");
                    textBox5.Text = badress;

                    string rep_contact = myreader.GetString("rep_contact");
                    textBox6.Text = rep_contact;
                }
                getAttendee();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f_auth a = new f_auth();
            a.ShowDialog();
            if (a.upflag == "1")
            {
                if (String.IsNullOrWhiteSpace(label9.Text) || label9.Text == "~code~")
                {
                    MessageBox.Show(this, "Please select an agency to update", "System Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    update();
                    getEvent();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Oops, Wrong Password :P", "System Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            f_sra_filter a = new f_sra_filter();
            a.ShowDialog();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                initMovable.ReleaseCapture();
                initMovable.SendMessage(Handle, initMovable.WM_NCLBUTTONDOWN, initMovable.HT_CAPTION, 0);
            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                initMovable.ReleaseCapture();
                initMovable.SendMessage(Handle, initMovable.WM_NCLBUTTONDOWN, initMovable.HT_CAPTION, 0);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Index == 3)
            {
                for (int i = 0; i <= dataGridView1.Rows.Count - 2; i++)
                {
                    try
                    {
                        DateTime dDate;

                        if (DateTime.TryParse(dataGridView1.Rows[i].Cells[3].Value.ToString(), out dDate))
                        {
                            String.Format("MM-dd-yyyy", dDate);
                            dataGridView1.Rows[i].Cells[3].Value = Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value).ToString("MM-dd-yyyy");
                            int years = DateTime.Now.Year - Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value).Year;
                            if (Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value).AddYears(years) > DateTime.Now) years--;
                            dataGridView1.Rows[i].Cells[4].Value = years.ToString();
                        }
                        else
                        {
                            //dataGridView1.Rows[i].Cells[3].Value = DateTime.Now.ToString("MM-dd-yyyy");
                            MessageBox.Show("Inconnect format, Please use MM-DD-YYYY");
                            dataGridView1.Rows[i].Cells[3].Value = DateTime.Now.ToString("MM-dd-yyyy");
                        }
                    }
                    catch (Exception r)
                    {
                    }
                }
            }
        }

        private void dateTimePicker1_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.dateTimePicker1, "use MM-dd-yyyy format");
        }
        
    }
}
