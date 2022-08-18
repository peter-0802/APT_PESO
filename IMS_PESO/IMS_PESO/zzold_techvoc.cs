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
    public partial class zzold_techvoc : Form
    {
        DBConn DB = new DBConn();
        public zzold_techvoc()
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
            MySqlCommand cmd = conn.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTrans;
            try
            {
                cmd.Parameters.AddWithValue("@code", this.label1.Text);
                string qD = @"delete from tech_voc where contact_id = (select id from contacts where code = @code)";
                cmd.CommandText = qD;
                cmd.ExecuteNonQuery();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    cmd = conn.CreateCommand();
                    if (row.IsNewRow) continue;
                    cmd.Parameters.AddWithValue("@code", this.label1.Text);
                    cmd.Parameters.AddWithValue("@course", row.Cells["c1"].Value);
                    cmd.Parameters.AddWithValue("@duration", row.Cells["c2"].Value);
                    cmd.Parameters.AddWithValue("@training_ins", row.Cells["c3"].Value);
                    cmd.Parameters.AddWithValue("@cert", row.Cells["c4"].Value);
                    string _query2 = @"insert into tech_voc
                                        (contact_id, course, duration, training_ins, cert)
                                        values
                                        ((select id from contacts where code = @code), @course, @duration, @training_ins, @cert)";
                    string query2 = string.Format(_query2, label1.Text);
                    cmd.CommandText = query2;
                    cmd.ExecuteNonQuery();
                }
                myTrans.Commit();

                MessageBox.Show("Record Added");

            }
            catch (Exception e)
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
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox58.Text) || String.IsNullOrWhiteSpace(textBox51.Text) || String.IsNullOrWhiteSpace(textBox49.Text))
            {
                MessageBox.Show(this, "Oops! missed something?", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string[] row = { textBox58.Text, dateTimePicker17.Text + " to " + dateTimePicker10.Text, textBox51.Text, textBox49.Text };
                dataGridView1.Rows.Add(row);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            insert();
            this.Close();
        }
    }
}
