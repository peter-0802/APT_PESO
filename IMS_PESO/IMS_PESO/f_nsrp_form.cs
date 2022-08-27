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
    public partial class f_nsrp_form : Form
    {
        DBConn DB = new DBConn();
        public f_nsrp_form()
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
            string query = @"select * from contact2 where code = '{0}'";
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
                    string emp_status = myreader.GetString("emp_status");
                    this.emp_status.Text = emp_status;
                    string job_pre = myreader.GetString("job_pre");
                    this.job_pref.Text = job_pre;
                    string educ = myreader.GetString("educ_level");
                    this.educ_level.Text = educ;
                    string skills = myreader.GetString("skills");
                    this.skills.Text = skills;
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
                myCommand.Parameters.AddWithValue("@job", job_pref.Text);
                myCommand.Parameters.AddWithValue("@educ_level", educ_level.Text);
                myCommand.Parameters.AddWithValue("@skills", skills.Text);
                myCommand.Parameters.AddWithValue("@from", "NSRP MODULE");
                string query = @"insert ignore into contact2
                                        (date, code, surname, firstname, middlename, dob, age, sex, civil_status, religion, birthplace,
                                         brgy, email, cp_no, 4ps, emp_status, job_pre, educ_level, skills, `from`)
                                        values
                                        (@date, (select if (count(id) <= 0, 'NSRP - 1', concat('NSRP - ', max(id) + 1)) code from contact2 as code), @surname, @firstname, @middlename, @dob, @age, @gender, @civil, @religion, @birthplace,
                                         @address, @email, @cp_no, @pppp, @emp_status, @job, @educ_level, @skills, @from)";
                myCommand.CommandText = query;
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show(this, "Record Added!", "System Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string qD = @"delete from contact2 where code = @code;";
                myCommand.CommandText = qD;
                myCommand.ExecuteNonQuery();

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
                myCommand.Parameters.AddWithValue("@job", job_pref.Text);
                myCommand.Parameters.AddWithValue("@educ_level", educ_level.Text);
                myCommand.Parameters.AddWithValue("@skills", skills.Text);
                myCommand.Parameters.AddWithValue("@from", "NSRP MODULE");
                string query = @"insert ignore into contact2
                                        (date, code, surname, firstname, middlename, dob, age, sex, civil_status, religion, birthplace,
                                         brgy, email, cp_no, 4ps, emp_status, job_pre, educ_level, skills, `from`)
                                        values
                                        (@date, (select if (count(id) <= 0, 'NSRP - 1', concat('NSRP - ', max(id) + 1)) code from contact2 as code), @surname, @firstname, @middlename, @dob, @age, @gender, @civil, @religion, @birthplace,
                                         @address, @email, @cp_no, @pppp, @emp_status, @job, @educ_level, @skills, @from)";
                myCommand.CommandText = query;
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show(this, "Record Updated!", "System Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dob_ValueChanged(object sender, EventArgs e)
        {
            int years = DateTime.Now.Year - Convert.ToDateTime(dob.Text).Year;
            if (Convert.ToDateTime(dob.Text).AddYears(years) > DateTime.Now) years--;
            this.age.Text = years.ToString();
        }

        private void dateTimePicker1_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.dateTimePicker1, "use MM-dd-yyyy format");
        }

        private void dob_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.dob, "use MM-dd-yyyy format");
        }
    }
}
