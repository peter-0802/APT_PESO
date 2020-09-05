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
    public partial class NSRPUpdate : Form
    {
        DBConn DB = new DBConn();
        public NSRPUpdate()
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
        private void update()
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
                cmd.Parameters.AddWithValue("code", this.label26.Text);
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
                cmd.Parameters.AddWithValue("@mother", this.textBox20.Text);
                cmd.Parameters.AddWithValue("@father", this.textBox21.Text);
                cmd.Parameters.AddWithValue("@house_no", this.textBox5.Text);
                cmd.Parameters.AddWithValue("@brgy", this.textBox7.Text);
                cmd.Parameters.AddWithValue("@municipality", this.textBox8.Text);
                cmd.Parameters.AddWithValue("@province", this.textBox19.Text);
                cmd.Parameters.AddWithValue("@tin", this.textBox83.Text);
                cmd.Parameters.AddWithValue("@gsis_sss", this.textBox82.Text);
                cmd.Parameters.AddWithValue("@pagibig", this.textBox81.Text);
                cmd.Parameters.AddWithValue("@philhealth", this.textBox6.Text);
                cmd.Parameters.AddWithValue("@height", this.textBox12.Text);
                cmd.Parameters.AddWithValue("@email", this.textBox11.Text);
                cmd.Parameters.AddWithValue("@landline_no", this.textBox10.Text);
                cmd.Parameters.AddWithValue("@cp_no", this.textBox9.Text);

                if (radioButton8.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@activeseek", this.radioButton8.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@activeseek", this.radioButton9.Text);
                }
                cmd.Parameters.AddWithValue("@period", this.textBox16.Text);

                if (radioButton11.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@willtoworkem", this.radioButton11.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@willtoworkem", this.radioButton10.Text);
                }
                cmd.Parameters.AddWithValue("@nowhen", this.textBox17.Text);
                cmd.Parameters.AddWithValue("@pppp", this.textBox18.Text);
                string update = @"update contacts set 
                                    surname = @surname,
                                    firstname = @firstname,
                                    middlename = @middlename,
                                    suffix = @suffix,   
                                    dob = @dob,
                                    sex = @sex,
                                    civil_status = @civil_status,
                                    religion = @religion,
                                    birthplace = @birthplace,
                                    mother = @mother,
                                    father = @father,   
                                    house_no = @house_no,
                                    brgy = @brgy,
                                    municipality = @municipality,
                                    province = @province,
                                    tin = @tin,
                                    gsis_sss = @gsis_sss,
                                    pagibig = @pagibig,
                                    philhealth = @philhealth,
                                    height = @height,
                                    email = @email,
                                    landline_no = @landline_no,
                                    cp_no = @cp_no,
                                    activeseek = @activeseek,
                                    period = @period,
                                    willtoworkem = @willtoworkem,
                                    nowhen = @nowhen,
                                    pppp = @pppp
                                  where code = @code";
                cmd.CommandText = update;
                cmd.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show(this, "Record Updated", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void button2_Click(object sender, EventArgs e)
        {
            update();
            this.Close();
        }
    }
}
