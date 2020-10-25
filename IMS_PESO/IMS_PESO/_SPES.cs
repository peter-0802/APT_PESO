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
    public partial class _SPES : Form
    {
        DBConn DB = new DBConn();
        public _SPES()
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
            string query = @"select event `EVENT`, event_date `DATE` from spes group by event";
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
                        myCommand.Parameters.AddWithValue("@event", textBox1.Text);
                        myCommand.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                        myCommand.Parameters.AddWithValue("@veneu", textBox2.Text);
                        myCommand.Parameters.AddWithValue("@host", textBox3.Text);
                        myCommand.Parameters.AddWithValue("@surname", row.Cells["surname"].Value);
                        myCommand.Parameters.AddWithValue("@firstname", row.Cells["firstname"].Value);
                        myCommand.Parameters.AddWithValue("@middlename", row.Cells["middlename"].Value);
                        myCommand.Parameters.AddWithValue("@address", row.Cells["address"].Value);
                        myCommand.Parameters.AddWithValue("@gender", row.Cells["gender"].Value);
                        myCommand.Parameters.AddWithValue("@age", row.Cells["age"].Value);
                        myCommand.Parameters.AddWithValue("@contact", row.Cells["contact"].Value);
                        myCommand.Parameters.AddWithValue("@type", row.Cells["type"].Value);

                    
                        myCommand.Parameters.AddWithValue("@notes", "notes");
                        string query = @"insert ignore into spes
                                        (event, event_date, host, veneu, surname, firstname, middlename, address,  gender, age, contact, type)
                                        values
                                        (@event, @date, @host, @veneu, @surname, @firstname, @middlename, @address,  @gender, @age, @contact, @type)";
                        myCommand.CommandText = query;
                        myCommand.ExecuteNonQuery();
                }
                myTrans.Commit();
                MessageBox.Show(this, "Record Added!", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                myCommand.Parameters.AddWithValue("@event", label9.Text);
                string qD = @"delete from spes where event = @event;";
                myCommand.CommandText = qD;
                myCommand.ExecuteNonQuery();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    myCommand = conn.CreateCommand();
                    if (row.IsNewRow) continue;
                    myCommand.Parameters.AddWithValue("@event", textBox1.Text);
                    myCommand.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                    myCommand.Parameters.AddWithValue("@veneu", textBox2.Text);
                    myCommand.Parameters.AddWithValue("@host", textBox3.Text);
                    myCommand.Parameters.AddWithValue("@surname", row.Cells["surname"].Value);
                    myCommand.Parameters.AddWithValue("@firstname", row.Cells["firstname"].Value);
                    myCommand.Parameters.AddWithValue("@middlename", row.Cells["middlename"].Value);
                    myCommand.Parameters.AddWithValue("@address", row.Cells["address"].Value);
                    myCommand.Parameters.AddWithValue("@gender", row.Cells["gender"].Value);
                    myCommand.Parameters.AddWithValue("@age", row.Cells["age"].Value);
                    myCommand.Parameters.AddWithValue("@contact", row.Cells["contact"].Value);
                    myCommand.Parameters.AddWithValue("@type", row.Cells["type"].Value);


                    myCommand.Parameters.AddWithValue("@notes", "notes");
                    string query = @"insert ignore into spes
                                        (event, event_date, host, veneu, surname, firstname, middlename, address,  gender, age, contact, type)
                                        values
                                        (@event, @date, @host, @veneu, @surname, @firstname, @middlename, @address,  @gender, @age, @contact, @type)";
                    myCommand.CommandText = query;
                    myCommand.ExecuteNonQuery();
                }
                myTrans.Commit();
                MessageBox.Show(this, "Record Added!", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(this, "Contacts Added to masterlist!", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(this, "Looks like some fields are empty :-(", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MySqlConnection conn = new MySqlConnection(DBConn.connstring);
                MySqlDataReader myreader;
                string query = @"select event from spes where event = '{0}'";
                string q2 = string.Format(query, textBox1.Text);
                MySqlCommand cmdmdlr = new MySqlCommand(q2, conn);
                try
                {
                    conn.Open();
                    myreader = cmdmdlr.ExecuteReader();

                    if (myreader.Read())
                    {
                        MessageBox.Show(this, "This event already exist please change event title :-)", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Focus();
                    }
                    else
                    {
                        insert();
                        insertToContact();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow rw in this.dataGridView1.Rows)
            {
                if (rw.IsNewRow) continue;
                for (int i = 0; i < rw.Cells.Count - 1; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                        MessageBox.Show(this, "Looks like some fields are empty :-(", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {

                    }
                }
            }
        }
        
        private void textBox1_Leave(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            MySqlDataReader myreader;
            string query = @"select event from spes where event = '{0}'";
            string q2 = string.Format(query, textBox1.Text);
            MySqlCommand cmdmdlr = new MySqlCommand(q2, conn);
            try
            {
                conn.Open();
                myreader = cmdmdlr.ExecuteReader();

                if (myreader.Read())
                {
                    MessageBox.Show(this, "This event already exist please change event title :-)", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
                    label9.Text = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _auth a = new _auth();
            a.ShowDialog();
            if (a.upflag == "1")
            {
                if (String.IsNullOrWhiteSpace(label9.Text) || label9.Text == "~code~")
                {
                    MessageBox.Show(this, "Please select an event to delete", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        myCommand.Parameters.AddWithValue("@event", label9.Text);
                        string qD = @"delete from spes where event = @event;";
                        myCommand.CommandText = qD;
                        myCommand.ExecuteNonQuery();
                        myTrans.Commit();
                        MessageBox.Show(this, "Record Deleted", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(this, "Oops, Wrong Password :P", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            
        }
        private void getAttendee()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            string query;
            query = @"SELECT
                        surname,
                        firstname,
                        middlename,
                        gender,
                        address,
                        age,
                        contact,
                        type
                        from spes
                        where event = '{0}'";
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
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["gender"].Value = dbdatasec1.Rows[i]["gender"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["address"].Value = dbdatasec1.Rows[i]["address"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["age"].Value = dbdatasec1.Rows[i]["age"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["contact"].Value = dbdatasec1.Rows[i]["contact"].ToString();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["type"].Value = dbdatasec1.Rows[i]["type"].ToString();
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
                                event,
                                event_date,
                                host,
                                veneu
                                from spes
                                where event = '{0}'
                                group by event";
            string finalQuery = string.Format(query, label9.Text);
            MySqlCommand cmdmdlr = new MySqlCommand(finalQuery, conn);
            try
            {
                conn.Open();
                myreader = cmdmdlr.ExecuteReader();

                if (myreader.Read())
                {
                    string eevent = myreader.GetString("event");
                    textBox1.Text = eevent;

                    string date = myreader.GetString("event_date");
                    dateTimePicker1.Text = date;

                    string host = myreader.GetString("host");
                    textBox3.Text = host;

                    string veneu = myreader.GetString("veneu");
                    textBox2.Text = veneu;
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
            _auth a = new _auth();
            a.ShowDialog();
            if (a.upflag == "1")
            {
                if (String.IsNullOrWhiteSpace(label9.Text) || label9.Text == "~code~")
                {
                    MessageBox.Show(this, "Please select an event to update", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(this, "Oops, Wrong Password :P", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _spesFilter a = new _spesFilter();
            a.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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
    }
}
