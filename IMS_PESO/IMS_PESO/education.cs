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
    public partial class education : Form
    {
        DBConn DB = new DBConn();
        public education()
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
                cmd.Parameters.AddWithValue("@code", label2.Text);
                string qD = @"delete from elementary where contact_id = (select id from contacts where code = @code);
                              delete from hs where contact_id = (select id from contacts where code = @code);
                              delete from college where contact_id = (select id from contacts where code = @code);
                              delete from grad where contact_id = (select id from contacts where code = @code)";
                string fqd = string.Format(qD, label2.Text);
                cmd.CommandText = fqd;
                cmd.ExecuteNonQuery();

                cmd = conn.CreateCommand();
                cmd.Parameters.AddWithValue("@school", textBox32.Text);
                if (checkBox6.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@underg", 1);
                    cmd.Parameters.AddWithValue("@yearlvl", textBox41.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@underg", 0);
                    cmd.Parameters.AddWithValue("@yearlvl", "N/A");
                }
                cmd.Parameters.AddWithValue("@yearg", dateTimePicker9.Text);
                cmd.Parameters.AddWithValue("@awards", textBox45.Text);

                string q5 = @"insert into elementary (contact_id, school, underg, yearlvl, yearg, awards) values ((select id from contacts order by id desc limit 1), @school, @underg, @yearlvl, @yearg, @awards)";
                cmd.CommandText = q5;
                cmd.ExecuteNonQuery();
                //----------------------------------------------------------------------------------------------------
                cmd = conn.CreateCommand();
                cmd.Parameters.AddWithValue("@schoolh", textBox33.Text);
                if (checkBox7.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@undergh", 1);
                    cmd.Parameters.AddWithValue("@yearlvlh", textBox43.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@undergh", 0);
                    cmd.Parameters.AddWithValue("@yearlvlh", "N/A");
                }
                cmd.Parameters.AddWithValue("@yeargh", dateTimePicker8.Text);
                cmd.Parameters.AddWithValue("@awardsh", textBox47.Text);

                string q6 = @"insert into hs (contact_id, school, underg, yearlvl, yearg, awards) values ((select id from contacts order by id desc limit 1), @schoolh, @undergh, @yearlvlh, @yeargh, @awardsh)";
                cmd.CommandText = q6;
                cmd.ExecuteNonQuery();
                //----------------------------------------------------------------------------------------------------
                cmd = conn.CreateCommand();
                cmd.Parameters.AddWithValue("@schoolc", textBox33.Text);
                if (checkBox8.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@undergc", 1);
                    cmd.Parameters.AddWithValue("@yearlvlc", textBox42.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@undergc", 0);
                    cmd.Parameters.AddWithValue("@yearlvlc", "N/A");
                }
                cmd.Parameters.AddWithValue("@yeargc", dateTimePicker7.Text);
                cmd.Parameters.AddWithValue("@awardsc", textBox46.Text);
                cmd.Parameters.AddWithValue("coursec", textBox37.Text);

                string q7 = @"insert into college (contact_id, school, course, underg, yearlvl, yearg, awards) values ((select id from contacts order by id desc limit 1), @schoolc, @coursec, @undergc, @yearlvlc, @yeargc, @awardsc)";
                cmd.CommandText = q7;
                cmd.ExecuteNonQuery();
                //----------------------------------------------------------------------------------------------------
                cmd = conn.CreateCommand();
                cmd.Parameters.AddWithValue("@schoolu", textBox33.Text);
                if (checkBox9.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@undergu", 1);
                    cmd.Parameters.AddWithValue("@yearlvlu", textBox40.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@undergu", 0);
                    cmd.Parameters.AddWithValue("@yearlvlu", "N/A");
                }
                cmd.Parameters.AddWithValue("@yeargu", dateTimePicker6.Text);
                cmd.Parameters.AddWithValue("@awardsu", textBox44.Text);
                cmd.Parameters.AddWithValue("courseg", textBox36.Text);

                string q8 = @"insert into grad (contact_id, school, course, underg, yearlvl, yearg, awards) values ((select id from contacts order by id desc limit 1), @schoolu, @courseg, @undergu, @yearlvlu, @yeargu, @awardsu)";
                cmd.CommandText = q8;
                cmd.ExecuteNonQuery();
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
            
            
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                textBox41.Enabled = true;
                dateTimePicker9.Enabled = true;
                textBox45.Enabled = true;
            }
            else
            {
                textBox41.Enabled = false;
                dateTimePicker9.Enabled = false;
                textBox45.Enabled = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                textBox43.Enabled = true;
                dateTimePicker8.Enabled = true;
                textBox47.Enabled = true;
            }
            else
            {
                textBox43.Enabled = false;
                dateTimePicker8.Enabled = false;
                textBox47.Enabled = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                textBox42.Enabled = true;
                dateTimePicker7.Enabled = true;
                textBox46.Enabled = true;
            }
            else
            {
                textBox42.Enabled = false;
                dateTimePicker7.Enabled = false;
                textBox46.Enabled = false;
            }

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                textBox40.Enabled = true;
                dateTimePicker6.Enabled = true;
                textBox44.Enabled = true;
            }
            else
            {
                textBox40.Enabled = false;
                dateTimePicker6.Enabled = false;
                textBox44.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            insert();
            this.Close();
        }
    }
}
