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
    public partial class NSRP : Form
    {
        DBConn DB = new DBConn();
        public NSRP()
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

        List<string> cities = new List<string>();

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton14.Checked == true)
            {
                radioButton18.Checked = false;
                radioButton19.Checked = false;
                radioButton20.Checked = false;
                radioButton21.Checked = false;
                radioButton22.Checked = false;
                radioButton23.Checked = false;
                radioButton24.Checked = false;
                textBox14.Text = string.Empty;
                textBox15.Text = string.Empty;
                groupBox6.Enabled = true;
                groupBox7.Enabled = false;
            }
            type = null;
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton15.Checked == true)
            {
                radioButton16.Checked = false;
                radioButton17.Checked = false;
                groupBox6.Enabled = false;
                groupBox7.Enabled = true;
            }
            type = null;
        }

        private void radioButton25_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton25.Checked == true)
            {
                textBox25.Text = string.Empty;
                textBox26.Text = string.Empty;
                textBox27.Text = string.Empty;
                textBox25.Enabled = false;
                textBox26.Enabled = false;
                textBox27.Enabled = false;

                textBox22.Enabled = true;
                textBox23.Enabled = true;
                textBox24.Enabled = true;
            }
        }

        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton26.Checked == true)
            {
                textBox22.Text = string.Empty;
                textBox23.Text = string.Empty;
                textBox24.Text = string.Empty;
                textBox22.Enabled = false;
                textBox23.Enabled = false;
                textBox24.Enabled = false;

                textBox25.Enabled = true;
                textBox26.Enabled = true;
                textBox27.Enabled = true;
            }
        }
        public string type = null;
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
                cmd.Parameters.AddWithValue("@surname", this.textBox1.Text);
                cmd.Parameters.AddWithValue("@firstname", this.textBox2.Text);
                cmd.Parameters.AddWithValue("@middlename", this.textBox3.Text);
                cmd.Parameters.AddWithValue("@suffix", this.comboBox1.Text);
                cmd.Parameters.AddWithValue("@dob", this.dateTimePicker1.Text);
                if (radioButton1.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@sex", this.radioButton1.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@sex", this.radioButton2.Text);
                }
                cmd.Parameters.AddWithValue("@civil_status", this.comboBox11.Text);
                cmd.Parameters.AddWithValue("@religion", this.comboBox2.Text);
                cmd.Parameters.AddWithValue("@birthplace", this.textBox4.Text);
                cmd.Parameters.AddWithValue("@house_no", this.textBox5.Text);
                cmd.Parameters.AddWithValue("@brgy", this.comboBox8.Text);
                cmd.Parameters.AddWithValue("@municipality", this.comboBox9.Text);
                cmd.Parameters.AddWithValue("@province", this.comboBox10.Text);
                cmd.Parameters.AddWithValue("@tin", this.textBox83.Text);
                cmd.Parameters.AddWithValue("@gsis_sss", this.textBox82.Text);
                cmd.Parameters.AddWithValue("@pagibig", this.textBox81.Text);
                cmd.Parameters.AddWithValue("@philhealth", this.textBox6.Text);
                cmd.Parameters.AddWithValue("@height", this.textBox12.Text);
                cmd.Parameters.AddWithValue("@email", this.textBox11.Text);
                cmd.Parameters.AddWithValue("@landline_no", this.textBox10.Text);
                cmd.Parameters.AddWithValue("@cp_no", this.textBox9.Text);

                string qry = @"insert into contacts
                                    (
                                    code,
                                    surname,
                                    firstname,
                                    middlename,
                                    suffix,
                                    dob,
                                    sex,
                                    civil_status,
                                    religion,
                                    birthplace,
                                    house_no,
                                    brgy,
                                    municipality,
                                    province,
                                    tin,
                                    gsis_sss,
                                    pagibig,
                                    philhealth,
                                    height,
                                    email,
                                    landline_no,
                                    cp_no
                                    ) values
                                    (
                                       (select if (count(id) <= 0, 'CON - 1', concat('CON - ', max(id) + 1)) code from contacts as code),
                                       @surname,
                                       @firstname,
                                       @middlename,
                                       @suffix,
                                       @dob,
                                       @sex,
                                       @civil_status,
                                       @religion,
                                       @birthplace,
                                       @house_no,
                                       @brgy,
                                       @municipality,
                                       @province,
                                       @tin,
                                       @gsis_sss,
                                       @pagibig,
                                       @philhealth,
                                       @height,
                                       @email,
                                       @landline_no,
                                       @cp_no
                                    )";
                cmd.CommandText = qry;
                cmd.ExecuteNonQuery();
                //---------------------------------------------------
                for (int i = 0; i < cities.Count; i++)
                {
                    cmd = conn.CreateCommand();
                    cmd.Parameters.AddWithValue("@disability", cities[i].ToString());
                    string qry1 = @"insert into disability
                                        (contact_id, disability)
                                        values
                                        ((select id from contacts order by id desc limit 1), @disability)";
                    cmd.CommandText = qry1;
                    cmd.ExecuteNonQuery();
                }
                //---------------------------------------------------
                cmd = conn.CreateCommand();
                if (radioButton14.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@status", this.radioButton14.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@status", this.radioButton15.Text);
                }
                cmd.Parameters.AddWithValue("@type", type.ToString());


                string q2 = @"insert into emp_status_type (contact_id, status, type) values ((select id from contacts order by id desc limit 1), @status, @type)";
                cmd.CommandText = q2;
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
            insert();
            cities.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                cities.Add(checkBox1.Text);
            }
            else if (checkBox1.Checked == false)
            {
                cities.Remove(checkBox1.Text);
            }
            return;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                cities.Add(checkBox2.Text);
            }
            else if (checkBox2.Checked == false)
            {
                cities.Remove(checkBox2.Text);
            }
            return;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                cities.Add(checkBox4.Text);
            }
            else if (checkBox4.Checked == false)
            {
                cities.Remove(checkBox4.Text);
            }
            return;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                cities.Add(checkBox3.Text);
            }
            else if (checkBox3.Checked == false)
            {
                cities.Remove(checkBox3.Text);
            }
            return;
        }


        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                textBox13.Enabled = true;
            }
            else if (checkBox5.Checked == false)
            {
                textBox13.Text = string.Empty;
                textBox13.Enabled = false;
            }
            else
                textBox13.Enabled = false;
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
           if (textBox13.Text == string.Empty || textBox13.Text == "" || textBox13.Text == null || textBox13.Text == " ")
            {
                MessageBox.Show("Please specify other disability");
                cities.RemoveAll(string.IsNullOrWhiteSpace);
                checkBox5.Checked = false;
            }
            else if (textBox13.Text != string.Empty || textBox13.Text != "" || textBox13.Text != null || textBox13.Text != " ")
            {
                cities.Add("Others: " + textBox13.Text);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton22.Checked == true)
            {
                textBox14.Enabled = true;
            }
            else
            {
                textBox14.Enabled = false;
                textBox14.Text = string.Empty;
            }
            
        }

        private void radioButton24_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton24.Checked == true)
            {
                textBox15.Enabled = true;
            }
            else
                textBox15.Enabled = false;
                textBox15.Text = string.Empty;
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            type = radioButton16.Text;
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            type = radioButton17.Text;
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            type = radioButton18.Text;
        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            type = radioButton19.Text;
        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {
            type = radioButton21.Text;
        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            type = radioButton20.Text;
        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {
            type = radioButton23.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            type = "Terminated abroad - " + textBox14.Text;
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            type = "Others - " + textBox15.Text;
        }
    }
}
