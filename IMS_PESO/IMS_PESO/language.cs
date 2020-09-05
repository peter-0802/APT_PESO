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
    public partial class language : Form
    {
        DBConn DB = new DBConn();
        public language()
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
        private void validateCheckBox()
        {
            if (checkBox18.Checked == true)
            {
                checkBox18.Text = "Yes";
            }
            else
                checkBox18.Text = "No";
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
                cmd.Parameters.AddWithValue("@code", label1.Text);
                string qD = @"delete from language where contact_id = (select id from contacts where code = @code)";
                string fqd = string.Format(qD, label1.Text);
                cmd.CommandText = fqd;
                cmd.ExecuteNonQuery();

                cmd = conn.CreateCommand();
                cmd.Parameters.AddWithValue("@code", label1.Text);
                cmd.Parameters.AddWithValue("@language", textBox31.Text);
                cmd.Parameters.AddWithValue("@reade", checkBox18.Text);
                cmd.Parameters.AddWithValue("@writee", checkBox19.Text);
                cmd.Parameters.AddWithValue("@speake", checkBox20.Text);
                cmd.Parameters.AddWithValue("@understande", checkBox21.Text);

                cmd.Parameters.AddWithValue("@readf", checkBox25.Text);
                cmd.Parameters.AddWithValue("@writef", checkBox24.Text);
                cmd.Parameters.AddWithValue("@speakf", checkBox23.Text);
                cmd.Parameters.AddWithValue("@understandf", checkBox22.Text);

                cmd.Parameters.AddWithValue("@reado", checkBox29.Text);
                cmd.Parameters.AddWithValue("@writeo", checkBox28.Text);
                cmd.Parameters.AddWithValue("@speako", checkBox27.Text);
                cmd.Parameters.AddWithValue("@understando", checkBox26.Text);
                string q4 = @"insert into language
                                        (contact_id, `language`, `read`, `write`, `speak`, `understand`)
                                        values
                                        ((select id from contacts where code = @code), 'English', @reade, @writee, @speake, @understande),
                                        ((select id from contacts where code = @code), 'Filipino', @readf, @writef, @speakf, @understandf),
                                        ((select id from contacts where code = @code), @language, @reado, @writeo, @speako, @understando)";
                string qq4 = string.Format(q4, label1.Text);
                cmd.CommandText = q4;
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

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked == true)
            {
                checkBox18.Text = "Yes";
            }
            else
                checkBox18.Text = "No";
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox25.Checked == true)
            {
                checkBox25.Text = "Yes";
            }
            else
                checkBox25.Text = "No";
        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox29.Checked == true)
            {
                checkBox29.Text = "Yes";
            }
            else
                checkBox29.Text = "No";
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked == true)
            {
                checkBox19.Text = "Yes";
            }
            else
                checkBox19.Text = "No";
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox24.Checked == true)
            {
                checkBox24.Text = "Yes";
            }
            else
                checkBox24.Text = "No";
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox28.Checked == true)
            {
                checkBox28.Text = "Yes";
            }
            else
                checkBox28.Text = "No";
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked == true)
            {
                checkBox20.Text = "Yes";
            }
            else
                checkBox20.Text = "No";
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked == true)
            {
                checkBox23.Text = "Yes";
            }
            else
                checkBox23.Text = "No";
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox27.Checked == true)
            {
                checkBox27.Text = "Yes";
            }
            else
                checkBox27.Text = "No";
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked == true)
            {
                checkBox21.Text = "Yes";
            }
            else
                checkBox21.Text = "No";
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked == true)
            {
                checkBox22.Text = "Yes";
            }
            else
                checkBox22.Text = "No";
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox26.Checked == true)
            {
                checkBox26.Text = "Yes";
            }
            else
                checkBox26.Text = "No";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            insert();
            this.Close();
        }
    }
}
