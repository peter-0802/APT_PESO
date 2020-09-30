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
    public partial class ofwForm : Form
    {
        DBConn DB = new DBConn();
        public ofwForm()
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
        private void getContact()
        {
            MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            MySqlDataReader myreader;
            string query = @"select * from ofw where code = '{0}'";
            string finalQuery = string.Format(query, label2.Text);
            MySqlCommand cmdmdlr = new MySqlCommand(finalQuery, conn);
            try
            {
                conn.Open();
                myreader = cmdmdlr.ExecuteReader();

                if (myreader.Read())
                {
                    string date = myreader.GetString("date");
                    dateTimePicker1.Text = date;
                    string surname = myreader.GetString("surname");
                    textBox1.Text = surname;
                    string firstname = myreader.GetString("firstname");
                    textBox2.Text = firstname;
                    string middlename = myreader.GetString("middlename");
                    textBox3.Text = middlename;
                    string gender = myreader.GetString("gender");
                    comboBox2.Text = gender;
                    string address = myreader.GetString("address");
                    textBox5.Text = address;
                    string country = myreader.GetString("country");
                    textBox6.Text = country;
                    string passport = myreader.GetString("passport");
                    textBox7.Text = passport;
                    string contact_no = myreader.GetString("contact_no");
                    textBox8.Text = contact_no;
                    string status = myreader.GetString("status");
                    comboBox1.Text = status;
                    string remarks = myreader.GetString("remarks");
                    textBox10.Text = remarks;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
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
                    myCommand = conn.CreateCommand();
                    myCommand.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                    myCommand.Parameters.AddWithValue("@surname", textBox1.Text);
                    myCommand.Parameters.AddWithValue("@firstname", textBox2.Text);
                    myCommand.Parameters.AddWithValue("@middlename", textBox3.Text);
                    myCommand.Parameters.AddWithValue("@address", textBox5.Text);
                    myCommand.Parameters.AddWithValue("@gender", comboBox2.Text);
                    myCommand.Parameters.AddWithValue("@country", textBox6.Text);
                    myCommand.Parameters.AddWithValue("@passport", textBox7.Text);
                    myCommand.Parameters.AddWithValue("@contact_no", textBox8.Text);
                    myCommand.Parameters.AddWithValue("@status", comboBox1.Text);
                    myCommand.Parameters.AddWithValue("@remarks", textBox10.Text);
                    string query = @"insert ignore into ofw
                                        (date, code, surname, firstname, middlename, address, gender, country, passport, contact_no, status, remarks)
                                        values
                                        (@date, (select if (count(id) <= 0, 'OFW - 1', concat('OFW - ', max(id) + 1)) code from ofw as code), @surname, @firstname, @middlename, @address, @gender, @country, @passport, @contact_no, @status, @remarks)";
                    myCommand.CommandText = query;
                    myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show(this, "Record Added!", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void update()
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
                myCommand = conn.CreateCommand();
                myCommand.Parameters.AddWithValue("@code", label2.Text);
                myCommand.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                myCommand.Parameters.AddWithValue("@surname", textBox1.Text);
                myCommand.Parameters.AddWithValue("@firstname", textBox2.Text);
                myCommand.Parameters.AddWithValue("@middlename", textBox3.Text);
                myCommand.Parameters.AddWithValue("@address", textBox5.Text);
                myCommand.Parameters.AddWithValue("@country", textBox6.Text);
                myCommand.Parameters.AddWithValue("@passport", textBox7.Text);
                myCommand.Parameters.AddWithValue("@contact_no", textBox8.Text);
                myCommand.Parameters.AddWithValue("@status", comboBox1.Text);
                myCommand.Parameters.AddWithValue("@remarks", textBox10.Text);
                string query = @"update ofw set 
                                        date = @date, surname = @surname, firstname = @firstname, middlename = @middlename, address = @address, country = country, passport = @passport, contact_no = @contact_no, status = @status, remarks = @remarks where code = @code";
                myCommand.CommandText = query;
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show(this, "Record updated!", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void button6_Click(object sender, EventArgs e)
        {
            if (label2.Text == "~code~")
            {
                insert();
                utility a = new utility();
                a.ClearTextBoxes(this.Controls);
            }
            else
            {
                update();
                this.Close();
            }
            
        }

        private void ofwForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
            getContact();
        }
    }
}
