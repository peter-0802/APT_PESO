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
    public partial class _todoAdd : Form
    {
        DBConn DB = new DBConn();
        public _todoAdd()
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
        public string title;

        private void getTask()
        {
            MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            MySqlDataReader myreader;
            string query = @"select * from todo where code = '{0}'";
            string finalQuery = string.Format(query, label2.Text);
            MySqlCommand cmdmdlr = new MySqlCommand(finalQuery, conn);
            try
            {
                conn.Open();
                myreader = cmdmdlr.ExecuteReader();

                if (myreader.Read())
                {
                    string date = myreader.GetString("title");
                    textBox6.Text = date;

                    string desc = myreader.GetString("desc");
                    textBox2.Text = desc;

                    string assignee = myreader.GetString("assignee");
                    textBox3.Text = assignee;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
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
                myCommand = conn.CreateCommand();

                myCommand.Parameters.AddWithValue("@title", textBox6.Text);
                myCommand.Parameters.AddWithValue("@desc", textBox2.Text);
                myCommand.Parameters.AddWithValue("@assignee", textBox3.Text);
                myCommand.Parameters.AddWithValue("@flag", "PENDING");
                string query = @"insert into todo
                                        (code, title, `desc`, assignee, flag)
                                        values
                                        ((select if (count(id) <= 0, 'TASK - 1', concat('TASK - ', max(id) + 1)) code from todo as code), @title, @desc, @assignee, @flag)";
                myCommand.CommandText = query;
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show(this, "Task Added!", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox6.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
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
            this.Close();
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
                myCommand = conn.CreateCommand();
                myCommand.Parameters.AddWithValue("@code", label2.Text);
                myCommand.Parameters.AddWithValue("@title", textBox6.Text);
                myCommand.Parameters.AddWithValue("@desc", textBox2.Text);
                myCommand.Parameters.AddWithValue("@assignee", textBox3.Text);
                string query = @"update todo set title = @title, `desc` = @desc, assignee = @assignee where code = @code";
                myCommand.CommandText = query;
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show(this, "Task Updated!", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox6.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
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
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(label2.Text == "~code~")
            {
                insert();
            }
            else
            {
                update();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void _todoAdd_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
            getTask();
        }
    }
}
