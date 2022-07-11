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
    public partial class f_add_user : Form
    {
        public f_add_user()
        {
            InitializeComponent();
            //getDesignation();
            loadUsers();
        }
        private void loadUsers()
        {
            string query;
            query = @"select username `USERNAME`, designation `DESIGNATION` from accounts";
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void getDesignation()
        {
            MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            MySqlDataReader myreader;
            string query = @"select designation from accounts";
            MySqlCommand cmdmdlr = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                myreader = cmdmdlr.ExecuteReader();

                while (myreader.Read())
                {
                    string designation = myreader.GetString("designation");
                    comboBox5.Items.Add(designation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }
        private void button6_Click(object sender, EventArgs e)
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
                myCommand.Parameters.AddWithValue("@username", textBox6.Text);
                myCommand.Parameters.AddWithValue("@password", textBox1.Text);
                myCommand.Parameters.AddWithValue("@designation", textBox2.Text);
                string query = @"insert into accounts
                                        (username, password, designation)
                                        values
                                        (@username, @password, @designation)";
                myCommand.CommandText = query;
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show(this, "User Added!", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                textBox6.Text = string.Empty;
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                comboBox5.SelectedIndex = -1;
            }
        }

        private void _collegeSchoolarFilter_Load(object sender, EventArgs e)
        {

        }
    }
}
