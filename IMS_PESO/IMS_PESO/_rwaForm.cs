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
    public partial class _rwaForm : Form
    {
        DBConn DB = new DBConn();
        public _rwaForm()
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
            string query = @"select * from rwa where code = '{0}'";
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
                    string name = myreader.GetString("establishment_name");
                    textBox1.Text = name;
                    string acronym = myreader.GetString("acronym");
                    textBox2.Text = acronym;
                    string tin = myreader.GetString("tin");
                    textBox3.Text = tin;
                    string employer_type = myreader.GetString("employer_type");
                    comboBox2.Text = employer_type;
                    string work_force = myreader.GetString("work_force");
                    comboBox3.Text = work_force;
                    string business_line = myreader.GetString("business_line");
                    textBox6.Text = business_line;
                    string address = myreader.GetString("address");
                    textBox7.Text = address;
                    string municipality = myreader.GetString("municipality");
                    textBox8.Text = municipality;
                    string province = myreader.GetString("province");
                    textBox12.Text = province;
                    string contact_person = myreader.GetString("contact_person");
                    textBox10.Text = contact_person;
                    string position = myreader.GetString("position");
                    textBox4.Text = position;
                    string tel = myreader.GetString("tel");
                    textBox5.Text = tel;
                    string fax = myreader.GetString("type");
                    comboBox1.Text = fax;
                    string email = myreader.GetString("email");
                    textBox11.Text = email;
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
                    myCommand.Parameters.AddWithValue("@establishment_name", textBox1.Text);
                    myCommand.Parameters.AddWithValue("@acronym", textBox2.Text);
                    myCommand.Parameters.AddWithValue("@tin", textBox3.Text);
                    myCommand.Parameters.AddWithValue("@employer_type", comboBox2.Text);
                    myCommand.Parameters.AddWithValue("@work_force", comboBox3.Text);
                    myCommand.Parameters.AddWithValue("@business_line", textBox6.Text);
                    myCommand.Parameters.AddWithValue("@address", textBox7.Text);
                    myCommand.Parameters.AddWithValue("@municipality", textBox8.Text);
                    myCommand.Parameters.AddWithValue("@province", textBox12.Text);
                    myCommand.Parameters.AddWithValue("@contact_person", textBox10.Text);
                    myCommand.Parameters.AddWithValue("@position", textBox4.Text);
                    myCommand.Parameters.AddWithValue("@tel", textBox5.Text);
                    myCommand.Parameters.AddWithValue("@type", comboBox1.Text);
                    myCommand.Parameters.AddWithValue("@email", textBox11.Text);
                string query = @"insert into rwa
                                        (date, code, establishment_name, acronym, tin, employer_type, work_force, business_line, address, municipality, province, contact_person, position, tel, type, email)
                                        values
                                        (@date, (select if (count(id) <= 0, 'RWA - 1', concat('RWA - ', max(id) + 1)) code from rwa as code), @establishment_name, @acronym, @tin, @employer_type, @work_force, @business_line, @address, @municipality, @province, @contact_person, @position, @tel, @type, @email)";
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
                string qD = @"delete from rwa where code = @code;";
                myCommand.CommandText = qD;
                myCommand.ExecuteNonQuery();

                myCommand = conn.CreateCommand();
                myCommand.Parameters.AddWithValue("@code", label2.Text);
                myCommand.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                myCommand.Parameters.AddWithValue("@establishment_name", textBox1.Text);
                myCommand.Parameters.AddWithValue("@acronym", textBox2.Text);
                myCommand.Parameters.AddWithValue("@tin", textBox3.Text);
                myCommand.Parameters.AddWithValue("@employer_type", comboBox2.Text);
                myCommand.Parameters.AddWithValue("@work_force", comboBox3.Text);
                myCommand.Parameters.AddWithValue("@business_line", textBox6.Text);
                myCommand.Parameters.AddWithValue("@address", textBox7.Text);
                myCommand.Parameters.AddWithValue("@municipality", textBox8.Text);
                myCommand.Parameters.AddWithValue("@province", textBox12.Text);
                myCommand.Parameters.AddWithValue("@contact_person", textBox10.Text);
                myCommand.Parameters.AddWithValue("@position", textBox4.Text);
                myCommand.Parameters.AddWithValue("@tel", textBox5.Text);
                myCommand.Parameters.AddWithValue("@type", comboBox1.Text);
                myCommand.Parameters.AddWithValue("@email", textBox11.Text);
                string query = @"insert into rwa
                                        (date, code, establishment_name, acronym, tin, employer_type, work_force, business_line, address, municipality, province, contact_person, position, tel, type, email)
                                        values
                                        (@date, @code, @establishment_name, @acronym, @tin, @employer_type, @work_force, @business_line, @address, @municipality, @province, @contact_person, @position, @tel, @type, @email)";
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
