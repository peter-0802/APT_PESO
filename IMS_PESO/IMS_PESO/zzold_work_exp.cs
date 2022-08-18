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
    public partial class zzold_work_exp : Form
    {
        DBConn DB = new DBConn();
        public zzold_work_exp()
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
                myCommand.Parameters.AddWithValue("@code", label1.Text);
                string qD = @"delete from work_exp where contact_id = (select id from contacts where code = @code)";
                string fqd = string.Format(qD, label1.Text);
                myCommand.CommandText = fqd;
                myCommand.ExecuteNonQuery();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    myCommand = conn.CreateCommand();
                    if (row.IsNewRow) continue;
                    myCommand.Parameters.AddWithValue("@code", label1.Text);
                    myCommand.Parameters.AddWithValue("@company", row.Cells["c1"].Value);
                    myCommand.Parameters.AddWithValue("@address", row.Cells["c2"].Value);
                    myCommand.Parameters.AddWithValue("@position", row.Cells["c3"].Value);
                    myCommand.Parameters.AddWithValue("@inclusive_dates", row.Cells["c4"].Value);
                    myCommand.Parameters.AddWithValue("@status", row.Cells["c5"].Value);
                    string _query2 = @"insert into work_exp
                                        (contact_id, company_name, address, position, inclusive_date, status)
                                        values
                                        ((select id from contacts where code = @code), @company, @address, @position, @inclusive_dates, @status)";
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
            if (String.IsNullOrWhiteSpace(textBox68.Text) || String.IsNullOrWhiteSpace(textBox72.Text) || String.IsNullOrWhiteSpace(textBox77.Text) || String.IsNullOrWhiteSpace(comboBox3.Text))
            {
                MessageBox.Show(this, "Oops! missed something?", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string[] row = { textBox68.Text, textBox72.Text, textBox77.Text, dateTimePicker20.Text + " to " + dateTimePicker18.Text, comboBox3.Text };
                dataGridView1.Rows.Add(row);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            insert();
            this.Close();
        }
    }
}
