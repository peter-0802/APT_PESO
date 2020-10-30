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
    public partial class _ofwForm2 : Form
    {
        DBConn DB = new DBConn();
        public _ofwForm2()
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
            string query = @"select * from ofw2 where code = '{0}'";
            string finalQuery = string.Format(query, label2.Text);
            MySqlCommand cmdmdlr = new MySqlCommand(finalQuery, conn);
            try
            {
                conn.Open();
                myreader = cmdmdlr.ExecuteReader();

                if (myreader.Read())
                {
                    //string date = myreader.GetString("date");
                    //dateTimePicker1.Text = date;
                    //string surname = myreader.GetString("surname");
                    //textBox1.Text = surname;
                    //string firstname = myreader.GetString("firstname");
                    //textBox2.Text = firstname;
                    //string middlename = myreader.GetString("middlename");
                    //textBox3.Text = middlename;
                    //string gender = myreader.GetString("gender");
                    //comboBox2.Text = gender;
                    //string address = myreader.GetString("address");
                    //comboBox5.Text = address;
                    //string country = myreader.GetString("country");
                    //this.country.Text = country;
                    //string passport = myreader.GetString("passport");
                    //this.passport.Text = passport;
                    //string type = myreader.GetString("type");
                    //this.type.Text = type;
                    //string contact_no = myreader.GetString("contact_no");
                    //cont.Text = contact_no;
                    //string status = myreader.GetString("status");
                    //this.status.Text = status;
                    //string remarks = myreader.GetString("remarks");
                    //this.remarks.Text = remarks;
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
                    //myCommand = conn.CreateCommand();
                    //myCommand.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                    //myCommand.Parameters.AddWithValue("@surname", textBox1.Text);
                    //myCommand.Parameters.AddWithValue("@firstname", textBox2.Text);
                    //myCommand.Parameters.AddWithValue("@middlename", textBox3.Text);
                    //myCommand.Parameters.AddWithValue("@address", comboBox5.Text);
                    //myCommand.Parameters.AddWithValue("@gender", comboBox2.Text);
                    //myCommand.Parameters.AddWithValue("@country", country.Text);
                    //myCommand.Parameters.AddWithValue("@passport", passport.Text);
                    //myCommand.Parameters.AddWithValue("@type", type.Text);
                    //myCommand.Parameters.AddWithValue("@contact_no", cont.Text);
                    //myCommand.Parameters.AddWithValue("@status", status.Text);
                    //myCommand.Parameters.AddWithValue("@remarks", remarks.Text);
                    string query = @"insert ignore into ofw
                                        (date, code, surname, firstname, middlename, address, gender, country, passport, type, contact_no, status, remarks)
                                        values
                                        (@date, (select if (count(id) <= 0, 'OFW - 1', concat('OFW - ', max(id) + 1)) code from ofw as code), @surname, @firstname, @middlename, @address, @gender, @country, @passport, @type, @contact_no, @status, @remarks)";
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
                //myCommand = conn.CreateCommand();
                //myCommand.Parameters.AddWithValue("@surname", textBox1.Text);
                //myCommand.Parameters.AddWithValue("@firstname", textBox2.Text);
                //myCommand.Parameters.AddWithValue("@middlename", textBox3.Text);
                //myCommand.Parameters.AddWithValue("@gender", comboBox2.Text);
                string query = @"insert ignore into contacts
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


        private void insertToContact2()
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
                myCommand.Parameters.AddWithValue("@surname", surname.Text);
                myCommand.Parameters.AddWithValue("@firstname", firstname.Text);
                myCommand.Parameters.AddWithValue("@middlename", middlename.Text);
                myCommand.Parameters.AddWithValue("@dob", dob.Text);
                myCommand.Parameters.AddWithValue("@age", age.Text);
                myCommand.Parameters.AddWithValue("@gender", gender.Text);
                myCommand.Parameters.AddWithValue("@civil", civil.Text);
                myCommand.Parameters.AddWithValue("@religion", religion.Text);
                myCommand.Parameters.AddWithValue("@birthplace", birthplace.Text);
                myCommand.Parameters.AddWithValue("@address", address.Text);
                myCommand.Parameters.AddWithValue("@email", email.Text);
                myCommand.Parameters.AddWithValue("@cp_no", contact.Text);
                myCommand.Parameters.AddWithValue("@pppp", pppp.Text);
                myCommand.Parameters.AddWithValue("@emp_status", emp_status.Text);
                myCommand.Parameters.AddWithValue("@job", job.Text);
                myCommand.Parameters.AddWithValue("@educ_level", educ.Text);
                myCommand.Parameters.AddWithValue("@skills", skills.Text);
                myCommand.Parameters.AddWithValue("@from", "OFW");

                myCommand.Parameters.AddWithValue("@status", status.Text);
                myCommand.Parameters.AddWithValue("@country", country.Text);
                myCommand.Parameters.AddWithValue("@passport", passport.Text);
                myCommand.Parameters.AddWithValue("@type", type.Text);
                myCommand.Parameters.AddWithValue("@remarks", remarks.Text);


                string query = @"insert ignore into ofw2
                                        (date, code, surname, firstname, middlename, dob, age, sex, civil_status, religion, birthplace,
                                         brgy, email, cp_no, 4ps, emp_status, job_pre, educ_level, skills, country, passport, type, status, remarks, `from`)
                                        values
                                        (@date, (select if (count(id) <= 0, 'OFW - 1', concat('OFW - ', max(id) + 1)) code from ofw2 as code), @surname, @firstname, @middlename, @dob, @age, @gender, @civil, @religion, @birthplace,
                                         @address, @email, @cp_no, @pppp, @emp_status, @job, @educ_level, @skills, @country, @passport, @type, @status, @remarks, @from)";
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
                myCommand.Parameters.AddWithValue("@code", label2.Text);
                string qD = @"delete from ofw2 where code = @code;";
                myCommand.CommandText = qD;
                myCommand.ExecuteNonQuery();

                myCommand = conn.CreateCommand();
                myCommand.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                myCommand.Parameters.AddWithValue("@code", label2.Text);
                myCommand.Parameters.AddWithValue("@surname", surname.Text);
                myCommand.Parameters.AddWithValue("@firstname", firstname.Text);
                myCommand.Parameters.AddWithValue("@middlename", middlename.Text);
                myCommand.Parameters.AddWithValue("@dob", dob.Text);
                myCommand.Parameters.AddWithValue("@age", age.Text);
                myCommand.Parameters.AddWithValue("@gender", gender.Text);
                myCommand.Parameters.AddWithValue("@civil", civil.Text);
                myCommand.Parameters.AddWithValue("@religion", religion.Text);
                myCommand.Parameters.AddWithValue("@birthplace", birthplace.Text);
                myCommand.Parameters.AddWithValue("@address", address.Text);
                myCommand.Parameters.AddWithValue("@email", email.Text);
                myCommand.Parameters.AddWithValue("@cp_no", contact.Text);
                myCommand.Parameters.AddWithValue("@pppp", pppp.Text);
                myCommand.Parameters.AddWithValue("@emp_status", emp_status.Text);
                myCommand.Parameters.AddWithValue("@job", job.Text);
                myCommand.Parameters.AddWithValue("@educ_level", educ.Text);
                myCommand.Parameters.AddWithValue("@skills", skills.Text);
                myCommand.Parameters.AddWithValue("@from", "OFW");

                myCommand.Parameters.AddWithValue("@status", status.Text);
                myCommand.Parameters.AddWithValue("@country", country.Text);
                myCommand.Parameters.AddWithValue("@passport", passport.Text);
                myCommand.Parameters.AddWithValue("@type", type.Text);
                myCommand.Parameters.AddWithValue("@remarks", remarks.Text);


                string query = @"insert ignore into ofw2
                                        (date, code, surname, firstname, middlename, dob, age, sex, civil_status, religion, birthplace,
                                         brgy, email, cp_no, 4ps, emp_status, job_pre, educ_level, skills, country, passport, type, status, remarks, `from`)
                                        values
                                        (@date, @code, @surname, @firstname, @middlename, @dob, @age, @gender, @civil, @religion, @birthplace,
                                         @address, @email, @cp_no, @pppp, @emp_status, @job, @educ_level, @skills, @country, @passport, @type, @status, @remarks, @from)";
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
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (label2.Text == "~code~")
            {
                //insert();
                insertToContact2();
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
