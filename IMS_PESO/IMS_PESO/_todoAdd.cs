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

        private void button4_Click(object sender, EventArgs e)
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
                string query = @"insert into todo
                                        (title, `desc`, assignee)
                                        values
                                        (@title, @desc, @assignee)";
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

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
