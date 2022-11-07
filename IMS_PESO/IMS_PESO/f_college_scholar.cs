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
    public partial class f_college_scholar : Form
    {
        DBConn DB = new DBConn();
        public f_college_scholar()
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
            //string query = @"select event_date `DATE` from colschoolar group by event_date";
            //MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            //MySqlCommand cmd = new MySqlCommand(query, conn);
            //try
            //{
            //    MySqlDataAdapter dgv = new MySqlDataAdapter();
            //    dgv.SelectCommand = cmd;
            //    DataTable dbdatasec = new DataTable();
            //    dgv.Fill(dbdatasec);
            //    BindingSource bsource = new BindingSource();

            //    bsource.DataSource = dbdatasec;
            //    dataGridView2.DataSource = bsource;
            //    dgv.Update(dbdatasec);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    conn.Close();;
            //}
        }
        private void childLabor_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    ((Button)ctrl).ForeColor = System.Drawing.SystemColors.Control;
                    ((Button)ctrl).BackColor = System.Drawing.Color.DodgerBlue;
                    ((Button)ctrl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    ((Button)ctrl).FlatAppearance.BorderSize = 0;
                    ((Button)ctrl).Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (ctrl is Label)
                {
                    ((Label)ctrl).Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (ctrl is DateTimePicker)
                {
                    ((DateTimePicker)ctrl).Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
            getAttendee();
            DataGridViewColumnSelector cs = new DataGridViewColumnSelector(dataGridView1);
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
                        myCommand.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                        myCommand.Parameters.AddWithValue("@surname", row.Cells["surname"].Value);
                        myCommand.Parameters.AddWithValue("@firstname", row.Cells["firstname"].Value);
                        myCommand.Parameters.AddWithValue("@middlename", row.Cells["middlename"].Value);
                        myCommand.Parameters.AddWithValue("@gender", row.Cells["gender"].Value);
                        myCommand.Parameters.AddWithValue("@school", row.Cells["school"].Value);
                        myCommand.Parameters.AddWithValue("@yearlevel", row.Cells["yearlevel"].Value);
                        myCommand.Parameters.AddWithValue("@barangay", row.Cells["barangay"].Value);
                        myCommand.Parameters.AddWithValue("@notes", "notes");
                        string query = @"insert into colschoolar
                                        (event_date, surname, firstname, middlename, gender, school, yearlevel, barangay, notes)
                                        values
                                        (@date, @surname, @firstname, @middlename, @gender, @school, @yearlevel, @barangay, @notes)";
                        myCommand.CommandText = query;
                        myCommand.ExecuteNonQuery();
                }
                myTrans.Commit();
                MessageBox.Show(this, "Record Added!", "Sytem Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            //conn.Open();
            //MySqlCommand myCommand = conn.CreateCommand();
            //MySqlTransaction myTrans;
            //myTrans = conn.BeginTransaction();
            //myCommand.Connection = conn;
            //myCommand.Transaction = myTrans;
            //try
            //{

            //    myCommand.Parameters.AddWithValue("@event", label9.Text);
            //    string qD = @"delete from spes where event = @event;";
            //    myCommand.CommandText = qD;
            //    myCommand.ExecuteNonQuery();

            //    foreach (DataGridViewRow row in dataGridView1.Rows)
            //    {
            //        myCommand = conn.CreateCommand();
            //        if (row.IsNewRow) continue;
            //        myCommand.Parameters.AddWithValue("@event", textBox1.Text);
            //        myCommand.Parameters.AddWithValue("@date", dateTimePicker1.Text);
            //        myCommand.Parameters.AddWithValue("@veneu", textBox2.Text);
            //        myCommand.Parameters.AddWithValue("@host", textBox3.Text);
            //        myCommand.Parameters.AddWithValue("@surname", row.Cells["surname"].Value);
            //        myCommand.Parameters.AddWithValue("@firstname", row.Cells["firstname"].Value);
            //        myCommand.Parameters.AddWithValue("@middlename", row.Cells["middlename"].Value);
            //        myCommand.Parameters.AddWithValue("@gender", row.Cells["gender"].Value);
            //        myCommand.Parameters.AddWithValue("@notes", "notes");
            //        string query = @"insert ignore into spes
            //                            (event, event_date, host, veneu, surname, firstname, middlename, gender, notes)
            //                            values
            //                            (@event, @date, @host, @veneu, @surname, @firstname, @middlename, @gender, @notes)";
            //        myCommand.CommandText = query;
            //        myCommand.ExecuteNonQuery();
            //    }
            //    myTrans.Commit();
            //    MessageBox.Show(this, "Record Added!", "Sytem Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception exg)
            //{
            //    try
            //    {
            //        myTrans.Rollback();
            //    }
            //    catch (Exception ex)
            //    {
            //        if (myTrans.Connection != null)
            //        {
            //            MessageBox.Show(ex.ToString());
            //        }
            //    }
            //    MessageBox.Show(exg.ToString());
            //}
            //finally
            //{
            //    conn.Close();
            //}
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
                MessageBox.Show(this, "Contacts added to masterlist!", "Sytem Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            f_college_schoolar_form a = new f_college_schoolar_form();
            a.ShowDialog();
            getAttendee();
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
                        MessageBox.Show(this, "Looks like some fields are empty :-(", "Sytem Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            //MySqlDataReader myreader;
            //string query = @"select code from colschoolar where event = '{0}'";
            //string q2 = string.Format(query, label9.Text);
            //MySqlCommand cmdmdlr = new MySqlCommand(q2, conn);
            //try
            //{
            //    conn.Open();
            //    myreader = cmdmdlr.ExecuteReader();

            //    if (myreader.Read())
            //    {
            //        MessageBox.Show(this, "This code already exist please change event title :-)", "Sytem Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        label9.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally { conn.Close(); }
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
            f_auth a = new f_auth();
            a.ShowDialog();
            if (a.upflag == "1")
            {
                if (String.IsNullOrWhiteSpace(label9.Text) || label9.Text == "~code~")
                {
                    MessageBox.Show(this, "Please select an event to delete", "Sytem Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        myCommand.Parameters.AddWithValue("@code", label9.Text);
                        string qD = @"update schoolar_coll set archived = 1 where code = @code;";
                        myCommand.CommandText = qD;
                        myCommand.ExecuteNonQuery();
                        myTrans.Commit();
                        MessageBox.Show(this, "Record Deleted", "Sytem Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    getAttendee();
                    label9.Text = "~code~";
                }
            }
            else
            {
                MessageBox.Show(this, "Oops, Wrong Password", "Sytem Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string query = @"SELECT
                            code `CODE`,
                            surname `SURNAME`,
                            firstname `FIRST NAME`,
                            middlename `MIDDLE NAME`,
                            sex `GENDER`,
                            dob `BIRTH DATE`,
                            mother `MOTHERS NAME`,
                            father `FATHERS NAME`,
                            brgy `ADDRESS`,
                            cp_no `CONTACT`,
                            school `SCHOOL`,
                            yearlevel `YEAR LEVEL`,
                            ave `AVERAGE`,
                            status `STATUS`,
                            remarks `REMARKS`
                            FROM schoolar_coll
                            where archived = 0
                            order by code asc";
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
                dataGridView1.DataSource = bsource;
                dgv.Update(dbdatasec);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close(); ;
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
            //MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            //MySqlDataReader myreader;
            //string query = @"select
            //                    event,
            //                    event_date,
            //                    host,
            //                    veneu
            //                    from spes
            //                    where event = '{0}'
            //                    group by event";
            //string finalQuery = string.Format(query, label9.Text);
            //MySqlCommand cmdmdlr = new MySqlCommand(finalQuery, conn);
            //try
            //{
            //    conn.Open();
            //    myreader = cmdmdlr.ExecuteReader();

            //    if (myreader.Read())
            //    {
            //        string eevent = myreader.GetString("event");
            //        textBox1.Text = eevent;

            //        string date = myreader.GetString("event_date");
            //        dateTimePicker1.Text = date;

            //        string host = myreader.GetString("host");
            //        textBox3.Text = host;

            //        string veneu = myreader.GetString("veneu");
            //        textBox2.Text = veneu;
            //    }
            //    getAttendee();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally { conn.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f_auth a = new f_auth();
            a.ShowDialog();
            if (a.upflag == "1")
            {
                if (String.IsNullOrWhiteSpace(label9.Text) || label9.Text == "~code~")
                {
                    MessageBox.Show(this, "Please select an event to update", "Sytem Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    f_college_schoolar_form b = new f_college_schoolar_form();
                    b.label2.Text = label9.Text;
                    b.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show(this, "Oops, Wrong Password", "Sytem Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            getAttendee();
            label9.Text = "~code~";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            f_college_scholar_filter a = new f_college_scholar_filter();
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

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            label9.Text = this.dataGridView1.CurrentRow.Cells["CODE"].Value.ToString();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.dateTimePicker1, "use MM-dd-yyyy format");
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
