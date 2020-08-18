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
        public NSRP()
        {
            InitializeComponent();
        }
        

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
        private void insert()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConn.connstring))
                {
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
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(qry, conn);
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

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Added");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            insert();
        }
    }
}
