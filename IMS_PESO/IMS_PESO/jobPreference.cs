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
    public partial class jobPreference : Form
    {
        DBConn DB = new DBConn();
        public jobPreference()
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
            jobs.Clear();
            jobs_location.Clear();
        }

        List<string> jobs = new List<string>();
        List<string> jobs_location = new List<string>();
        private void getContactList()
        {
            string query;
            query = @"select code, surname, firstname, middlename from contacts";
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
                string qD = @"delete from contacts_job where contact_id = (select id from contacts where code = @code)";
                string fqd = string.Format(qD, label1.Text);
                myCommand.CommandText = fqd;
                myCommand.ExecuteNonQuery();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    myCommand = conn.CreateCommand();
                    if (row.IsNewRow) continue;
                    myCommand.Parameters.AddWithValue("@code", label1.Text);
                    if (radioButton25.Checked == true)
                    {
                        myCommand.Parameters.AddWithValue("@Local_abroad", "Local");
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Local_abroad", "Abroad");
                    }
                    myCommand.Parameters.AddWithValue("@job", row.Cells["preferedOccupation"].Value);
                    myCommand.Parameters.AddWithValue("@location", row.Cells["location"].Value);
                    myCommand.Parameters.AddWithValue("@expectedsal", textBox28.Text);
                    myCommand.Parameters.AddWithValue("@passportno", textBox29.Text);
                    myCommand.Parameters.AddWithValue("@expirydate", textBox30.Text);
                    string _query2 = @"insert into contacts_job
                                        (contact_id, Local_abroad, job, location, expectedsal, passportno, expirydate)
                                        values
                                        ((select id from contacts where code = '{0}'), @Local_abroad, @job, @location, @expectedsal, @passportno, @expirydate)";
                    string query2 = string.Format(_query2, label1.Text);
                    myCommand.CommandText = query2;
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
            if (String.IsNullOrWhiteSpace(textBox21.Text) || String.IsNullOrWhiteSpace(textBox24.Text))
            {
                MessageBox.Show(this, "Oops! missed something?", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string[] row = { textBox21.Text, textBox24.Text };
                dataGridView1.Rows.Add(row);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            insert();
            this.Close();
        }

        private void jobPreference_Load(object sender, EventArgs e)
        {

        }
    }
}
