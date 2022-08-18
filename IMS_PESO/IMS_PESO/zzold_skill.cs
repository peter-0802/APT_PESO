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
    public partial class zzold_skill : Form
    {
        DBConn DB = new DBConn();
        public zzold_skill()
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
        List<string> skills = new List<string>();
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
                cmd = conn.CreateCommand();
                cmd.Parameters.AddWithValue("@code", label1.Text);
                string qry = @"delete from skills where contact_id = (select id from contacts where code = @code)";
                cmd.CommandText = qry;
                cmd.ExecuteNonQuery();
                for (int i = 0; i < skills.Count; i++)
                {
                    cmd = conn.CreateCommand();
                    cmd.Parameters.AddWithValue("@code", label1.Text);
                    cmd.Parameters.AddWithValue("@skills", skills[i].ToString());
                    string qry2 = @"insert into skills (contact_id, skills) values ((select id from contacts where code = @code), @skills)";
                    cmd.CommandText = qry2;
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
            
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox30.Checked == true)
            {
                skills.Add(checkBox30.Text);
            }
            else
            {
                skills.Remove(checkBox30.Text);
            }
        }

        private void checkBox42_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox42.Checked == true)
            {
                textBox78.Enabled = true;
            }
            else
            {
                textBox78.Text = string.Empty;
                textBox78.Enabled = false;
            }
        }

        private void textBox78_Leave(object sender, EventArgs e)
        {
        }

        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox31.Checked == true)
            {
                skills.Add(checkBox31.Text);
            }
            else
            {
                skills.Remove(checkBox31.Text);
            }
        }

        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox33.Checked == true)
            {
                skills.Add(checkBox33.Text);
            }
            else
            {
                skills.Remove(checkBox33.Text);
            }
        }

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox32.Checked == true)
            {
                skills.Add(checkBox32.Text);
            }
            else
            {
                skills.Remove(checkBox32.Text);
            }
        }

        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox31.Checked == true)
            {
                skills.Add(checkBox35.Text);
            }
            else
            {
                skills.Remove(checkBox35.Text);
            }
        }

        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox34.Checked == true)
            {
                skills.Add(checkBox34.Text);
            }
            else
            {
                skills.Remove(checkBox34.Text);
            }
        }

        private void checkBox41_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox41.Checked == true)
            {
                skills.Add(checkBox41.Text);
            }
            else
            {
                skills.Remove(checkBox41.Text);
            }
        }

        private void checkBox40_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox40.Checked == true)
            {
                skills.Add(checkBox40.Text);
            }
            else
            {
                skills.Remove(checkBox40.Text);
            }
        }

        private void checkBox39_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox39.Checked == true)
            {
                skills.Add(checkBox39.Text);
            }
            else
            {
                skills.Remove(checkBox39.Text);
            }
        }

        private void checkBox38_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox38.Checked == true)
            {
                skills.Add(checkBox38.Text);
            }
            else
            {
                skills.Remove(checkBox38.Text);
            }
        }

        private void checkBox37_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox37.Checked == true)
            {
                skills.Add(checkBox37.Text);
            }
            else
            {
                skills.Remove(checkBox37.Text);
            }
        }

        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox36.Checked == true)
            {
                skills.Add(checkBox36.Text);
            }
            else
            {
                skills.Remove(checkBox36.Text);
            }
        }

        private void checkBox47_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox47.Checked == true)
            {
                skills.Add(checkBox47.Text);
            }
            else
            {
                skills.Remove(checkBox47.Text);
            }
        }

        private void checkBox46_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox46.Checked == true)
            {
                skills.Add(checkBox46.Text);
            }
            else
            {
                skills.Remove(checkBox46.Text);
            }
        }

        private void checkBox45_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox45.Checked == true)
            {
                skills.Add(checkBox45.Text);
            }
            else
            {
                skills.Remove(checkBox45.Text);
            }
        }

        private void checkBox44_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox44.Checked == true)
            {
                skills.Add(checkBox44.Text);
            }
            else
            {
                skills.Remove(checkBox44.Text);
            }
        }

        private void checkBox43_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox43.Checked == true)
            {
                skills.Add(checkBox43.Text);
            }
            else
            {
                skills.Remove(checkBox43.Text);
            }
        }

        private void skill_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox78.Text))
            {
                skills.Add(textBox78.Text);
            }
            insert();
            textBox78.Text = string.Empty;
            this.Close();
        }
    }
}
