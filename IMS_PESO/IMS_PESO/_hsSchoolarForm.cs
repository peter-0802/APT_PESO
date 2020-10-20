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
    public partial class _hsSchoolarForm : Form
    {
        DBConn DB = new DBConn();
        public _hsSchoolarForm()
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
            string query = @"select * from hsshcoolar where code = '{0}'";
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
                    string dob = myreader.GetString("dob");
                    dateTimePicker2.Text = dob;
                    string mother = myreader.GetString("mother");
                    textBox9.Text = mother;

                    string father = myreader.GetString("father");
                    textBox4.Text = father;

                    string address = myreader.GetString("address");
                    textBox5.Text = address;
                    string contact_no = myreader.GetString("contact");
                    textBox8.Text = contact_no;
                    string school = myreader.GetString("school");
                    comboBox3.Text = school;
                    string year = myreader.GetString("yearlevel");
                    comboBox4.Text = year;
                    string ave = myreader.GetString("ave");
                    textBox10.Text = ave;
                    string status = myreader.GetString("status");
                    comboBox1.Text = status;
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
                myCommand.Parameters.AddWithValue("@gender", comboBox2.Text);
                myCommand.Parameters.AddWithValue("@dob", dateTimePicker2.Text);
                myCommand.Parameters.AddWithValue("@mother", textBox9.Text);
                myCommand.Parameters.AddWithValue("@father", textBox4.Text);
                myCommand.Parameters.AddWithValue("@address", textBox5.Text);
                myCommand.Parameters.AddWithValue("@contact", textBox8.Text);
                myCommand.Parameters.AddWithValue("@school", comboBox3.Text);
                myCommand.Parameters.AddWithValue("@yearlevel", comboBox4.Text);
                myCommand.Parameters.AddWithValue("@ave", textBox10.Text);
                myCommand.Parameters.AddWithValue("@status", comboBox1.Text);
                string query = @"insert into hsshcoolar
                                        (code, date ,surname, firstname, middlename, gender, dob, mother, father, address, contact, school, yearlevel, ave, status)
                                        values
                                        ((select if (count(id) <= 0, 'HSS - 1', concat('HSS - ', max(id) + 1)) code from hsshcoolar as code), @date, @surname, @firstname, @middlename, @gender, @dob, @mother, @father, @address, @contact, @school, @yearlevel, @ave, @status)";
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
        private void insertToContact()
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
                myCommand.Parameters.AddWithValue("@surname", textBox1.Text);
                myCommand.Parameters.AddWithValue("@firstname", textBox2.Text);
                myCommand.Parameters.AddWithValue("@middlename", textBox3.Text);
                myCommand.Parameters.AddWithValue("@gender", comboBox2.Text);
                string query = @"insert into contacts
                                        (code, surname, firstname, middlename, sex)
                                        values
                                        ((select if (count(id) <= 0, 'CON - 1', concat('CON - ', max(id) + 1)) code from contacts as code), @surname, @firstname, @middlename, @gender)";
                myCommand.CommandText = query;
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show(this, "Contacts added to masterlist!", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                myCommand.Parameters.AddWithValue("@code", label2.Text);
                string qD = @"delete from hsshcoolar where code = @code;";
                myCommand.CommandText = qD;
                myCommand.ExecuteNonQuery();

                myCommand = conn.CreateCommand();
                myCommand.Parameters.AddWithValue("@code", label2.Text);
                myCommand.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                myCommand.Parameters.AddWithValue("@surname", textBox1.Text);
                myCommand.Parameters.AddWithValue("@firstname", textBox2.Text);
                myCommand.Parameters.AddWithValue("@middlename", textBox3.Text);
                myCommand.Parameters.AddWithValue("@gender", comboBox2.Text);
                myCommand.Parameters.AddWithValue("@dob", dateTimePicker2.Text);
                myCommand.Parameters.AddWithValue("@mother", textBox9.Text);
                myCommand.Parameters.AddWithValue("@father", textBox4.Text);
                myCommand.Parameters.AddWithValue("@address", textBox5.Text);
                myCommand.Parameters.AddWithValue("@contact", textBox8.Text);
                myCommand.Parameters.AddWithValue("@school", comboBox3.Text);
                myCommand.Parameters.AddWithValue("@yearlevel", comboBox4.Text);
                myCommand.Parameters.AddWithValue("@ave", textBox10.Text);
                myCommand.Parameters.AddWithValue("@status", comboBox1.Text);
                string query = @"insert into hsshcoolar
                                        (code, date ,surname, firstname, middlename, gender, dob, mother, father, address, contact, school, yearlevel, ave, status)
                                        values
                                        (@code, @date, @surname, @firstname, @middlename, @gender, @dob, @mother, @father, @address, @contact, @school, @yearlevel, @ave, @status)";
                myCommand.CommandText = query;
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show(this, "Record Updated!", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            utility a = new utility();
            if (label2.Text == "~code~")
            {
                insert();
                insertToContact();
                a.ClearTextBoxes(this.Controls);
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
            }
            else
            {
                update();
                a.ClearTextBoxes(this.Controls);
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
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
