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
    public partial class f_college_schoolar_form : Form
    {
        DBConn DB = new DBConn();
        public f_college_schoolar_form()
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
            string query = @"select * from schoolar_coll where code = '{0}'";
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
                    this.surname.Text = surname;
                    string firstname = myreader.GetString("firstname");
                    this.firstname.Text = firstname;
                    string middlename = myreader.GetString("middlename");
                    this.middlename.Text = middlename;
                    string dob = myreader.GetString("dob");
                    this.dob.Text = dob;
                    string age = myreader.GetString("age");
                    this.age.Text = age;
                    string gender = myreader.GetString("sex");
                    this.gender.Text = gender;
                    string civil = myreader.GetString("civil_status");
                    this.civil.Text = civil;
                    string religion = myreader.GetString("religion");
                    this.religion.Text = religion;
                    string bplace = myreader.GetString("birthplace");
                    this.birthplace.Text = bplace;
                    string address = myreader.GetString("brgy");
                    this.address.Text = address;
                    string email = myreader.GetString("email");
                    this.email.Text = email;
                    string contact_no = myreader.GetString("cp_no");
                    this.contact.Text = contact_no;
                    string pppp = myreader.GetString("4ps");
                    this.pppp.Text = pppp;
                    string remarks = myreader.GetString("remarks");
                    this.remarks.Text = remarks;
                    string emp_status = myreader.GetString("emp_status");
                    this.emp_status.Text = emp_status;
                    string job_pre = myreader.GetString("job_pre");
                    this.job.Text = job_pre;
                    string educ = myreader.GetString("educ_level");
                    this.educ.Text = educ;
                    string skills = myreader.GetString("skills");
                    this.skills.Text = skills;
                    string mother = myreader.GetString("mother");
                    this.mother.Text = mother;
                    string father = myreader.GetString("father");
                    this.father.Text = father;
                    string school = myreader.GetString("school");
                    this.school.Text = school;
                    string year = myreader.GetString("yearlevel");
                    this.year_level.Text = year;
                    string ave = myreader.GetString("ave");
                    this.average.Text = ave;
                    string status = myreader.GetString("status");
                    this.status.Text = status;

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
                    myCommand.Parameters.AddWithValue("@surname", surname.Text);
                    myCommand.Parameters.AddWithValue("@firstname", firstname.Text);
                    myCommand.Parameters.AddWithValue("@middlename", middlename.Text);
                    myCommand.Parameters.AddWithValue("@address", address.Text);
                    myCommand.Parameters.AddWithValue("@gender", gender.Text);
                    myCommand.Parameters.AddWithValue("@country", contact.Text);
                    myCommand.Parameters.AddWithValue("@passport", emp_status.Text);
                    myCommand.Parameters.AddWithValue("@type", pppp.Text);
                    myCommand.Parameters.AddWithValue("@contact_no", job.Text);
                    //myCommand.Parameters.AddWithValue("@status", comboBox1.Text);
                    myCommand.Parameters.AddWithValue("@remarks", educ.Text);
                    string query = @"insert ignore into ofw
                                        (date, code, surname, firstname, middlename, address, gender, country, passport, type, contact_no, status, remarks)
                                        values
                                        (@date, (select if (count(id) <= 0, 'OFW - 1', concat('OFW - ', max(id) + 1)) code from ofw as code), @surname, @firstname, @middlename, @address, @gender, @country, @passport, @type, @contact_no, @status, @remarks)";
                    myCommand.CommandText = query;
                    myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show(this, "Record Added!", "Sytem Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                myCommand.Parameters.AddWithValue("@mother", mother.Text);
                myCommand.Parameters.AddWithValue("@father", father.Text);
                myCommand.Parameters.AddWithValue("@school", school.Text);
                myCommand.Parameters.AddWithValue("@yearlevel", year_level.Text);
                myCommand.Parameters.AddWithValue("@ave", average.Text);
                myCommand.Parameters.AddWithValue("@status", status.Text);
                myCommand.Parameters.AddWithValue("@pppp", pppp.Text);
                myCommand.Parameters.AddWithValue("@remarks", remarks.Text);
                myCommand.Parameters.AddWithValue("@job", job.Text);
                myCommand.Parameters.AddWithValue("@emp_status", emp_status.Text);
                myCommand.Parameters.AddWithValue("@educ_level", educ.Text);
                myCommand.Parameters.AddWithValue("@skills", skills.Text);
                myCommand.Parameters.AddWithValue("@from", "COLLEGE SCHOOLAR");
                string query = @"insert ignore into schoolar_coll
                                        (date, code, surname, firstname, middlename, dob, age, sex, civil_status, religion, birthplace,
                                         brgy, email, cp_no, mother, father, school, yearlevel, ave, status, 4ps, remarks, emp_status, job_pre,
                                         educ_level, skills, `from`)
                                        values
                                        (@date, (select if (count(id) <= 0, 'S COL - 1', concat('S COL - ', max(id) + 1)) code from schoolar_coll as code), @surname, @firstname, @middlename, @dob, @age, @gender, @civil, @religion, @birthplace,
                                         @address, @email, @cp_no, @mother, @father, @school, @yearlevel, @ave, @status, @pppp, @remarks, @emp_status, @job,
                                         @educ_level, @skills, @from)";
                myCommand.CommandText = query;
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show(this, "Record Added!", "Sytem Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                myCommand.Parameters.AddWithValue("@surname", surname.Text);
                myCommand.Parameters.AddWithValue("@firstname", firstname.Text);
                myCommand.Parameters.AddWithValue("@middlename", middlename.Text);
                myCommand.Parameters.AddWithValue("@gender", gender.Text);
                string query = @"insert ignore into contacts
                                        (code, surname, firstname, middlename, sex)
                                        values
                                        ((select if (count(id) <= 0, 'CON - 1', concat('CON - ', max(id) + 1)) code from contacts as code), @surname, @firstname, @middlename, @gender)";
                myCommand.CommandText = query;
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show(this, "Contacts added to masterlist!", "Sytem Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string qD = @"delete from schoolar_coll where code = @code;";
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
                myCommand.Parameters.AddWithValue("@mother", mother.Text);
                myCommand.Parameters.AddWithValue("@father", father.Text);
                myCommand.Parameters.AddWithValue("@school", school.Text);
                myCommand.Parameters.AddWithValue("@yearlevel", year_level.Text);
                myCommand.Parameters.AddWithValue("@ave", average.Text);
                myCommand.Parameters.AddWithValue("@status", status.Text);
                myCommand.Parameters.AddWithValue("@pppp", pppp.Text);
                myCommand.Parameters.AddWithValue("@remarks", remarks.Text);
                myCommand.Parameters.AddWithValue("@job", job.Text);
                myCommand.Parameters.AddWithValue("@emp_status", emp_status.Text);
                myCommand.Parameters.AddWithValue("@educ_level", educ.Text);
                myCommand.Parameters.AddWithValue("@skills", skills.Text);
                myCommand.Parameters.AddWithValue("@from", "COLLEGE SCHOOLAR");
                string query = @"insert ignore into schoolar_coll
                                        (date, code, surname, firstname, middlename, dob, age, sex, civil_status, religion, birthplace,
                                         brgy, email, cp_no, mother, father, school, yearlevel, ave, status, 4ps, remarks, emp_status, job_pre,
                                         educ_level, skills, `from`)
                                        values
                                        (@date, @code, @surname, @firstname, @middlename, @dob, @age, @gender, @civil, @religion, @birthplace,
                                         @address, @email, @cp_no, @mother, @father, @school, @yearlevel, @ave, @status, @pppp, @remarks, @emp_status, @job,
                                         @educ_level, @skills, @from)";
                myCommand.CommandText = query;
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show(this, "Record Updated!", "Sytem Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                //insertToContact();
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

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
