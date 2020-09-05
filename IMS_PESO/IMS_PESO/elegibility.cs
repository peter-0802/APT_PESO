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
    public partial class elegibility : Form
    {
        DBConn DB = new DBConn();
        public elegibility()
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
                    myCommand.Parameters.AddWithValue("@code", label1.Text);
                    myCommand.Parameters.AddWithValue("@eligibility", row.Cells["eligible"].Value);
                    myCommand.Parameters.AddWithValue("@rating", row.Cells["rating"].Value);
                    myCommand.Parameters.AddWithValue("@exp_d", row.Cells["exp_date"].Value);
                    string _query2 = @"insert into eligibility
                                        (contact_id, eligibility, rating, exp_d)
                                        values
                                        ((select id from contacts where code = @code), @eligibility, @rating, @exp_d)";
                    myCommand.CommandText = _query2;
                    myCommand.ExecuteNonQuery();
                }

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    myCommand = conn.CreateCommand();
                    if (row.IsNewRow) continue;
                    myCommand.Parameters.AddWithValue("@code", label1.Text);
                    myCommand.Parameters.AddWithValue("@prc", row.Cells["prc"].Value);
                    myCommand.Parameters.AddWithValue("@valid_til", row.Cells["valid_til"].Value);
                    string _query2 = @"insert into prc
                                        (contact_id, prc, valid_til)
                                        values
                                        ((select id from contacts where code = @code), @prc, @valid_til)";
                    myCommand.CommandText = _query2;
                    myCommand.ExecuteNonQuery();
                }
                myTrans.Commit();
                MessageBox.Show("Record updated");
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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox65.Text) || String.IsNullOrWhiteSpace(textBox56.Text) || String.IsNullOrWhiteSpace(dateTimePicker21.Text))
            {
                MessageBox.Show(this, "Oops! missed something?", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string[] row = { textBox65.Text, textBox56.Text, dateTimePicker21.Text };
                dataGridView1.Rows.Add(row);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox61.Text) || String.IsNullOrWhiteSpace(dateTimePicker16.Text))
            {
                MessageBox.Show(this, "Oops! missed something?", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string[] row = { textBox61.Text, dateTimePicker16.Text };
                dataGridView2.Rows.Add(row);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            insert();
            this.Close();
        }
    }
}
