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
    public partial class contactList : Form
    {
        DBConn DB = new DBConn();
        public contactList()
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

        private void getContactList()
        {
            string query;
            query = @"select code `CODE`, surname `SURNAME`, firstname `FIRSTNAME`, middlename `MIDDLE NAME` from contacts";
            string FinalQuery = string.Format(query);
            MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            MySqlCommand cmd = new MySqlCommand(FinalQuery, conn);
            try
            {
                MySqlDataAdapter dgv = new MySqlDataAdapter();
                dgv.SelectCommand = cmd;
                DataTable dbdatasec = new DataTable();
                dgv.Fill(dbdatasec);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdatasec;
                dataGridView1.DataSource = bsource;
                dgv.Update(dbdatasec);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void contactList_Load(object sender, EventArgs e)
        {
            getContactList();
        }
       
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(label1.Text) || label1.Text == "~code~")
            {
                return;
            }
            NSRPUpdate a = new NSRPUpdate();
            a.label26.Text = label1.Text;
            a.ShowDialog();
        }
        private void contactList_Activated(object sender, EventArgs e)
        {
            getContactList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(label1.Text) || label1.Text == "~code~")
            {
                return;
            }
            jobPreference a = new jobPreference();
            a.label1.Text = label1.Text;
            a.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(label1.Text) || label1.Text == "~code~")
            {
                return;
            }
            language a = new language();
            a.label1.Text = label1.Text;
            a.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(label1.Text) || label1.Text == "~code~")
            {
                return;
            }
            education a = new education();
            a.label2.Text = label1.Text;
            a.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(label1.Text) || label1.Text == "~code~")
            {
                return;
            }
            techvoc a = new techvoc();
            a.label1.Text = label1.Text;
            a.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(label1.Text) || label1.Text == "~code~")
            {
                return;
            }
            elegibility a = new elegibility();
            a.label1.Text = label1.Text;
            a.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(label1.Text) || label1.Text == "~code~")
            {
                return;
            }
            work_exp a = new work_exp();
            a.label1.Text = label1.Text;
            a.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(label1.Text) || label1.Text == "~code~")
            {
                return;
            }
            skill a = new skill();
            a.label1.Text = label1.Text;
            a.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string query;
                query = @"select code `CODE`, surname `SURNAME`, firstname `FIRSTNAME`, middlename `MIDDLE NAME` from contacts where surname like '%%{0}%%' or code like '%%{0}%%' or firstname like '%%{0}%%' or middlename like '%%{0}%%'";
                string FinalQuery = string.Format(query, textBox5.Text);
                MySqlConnection conn = new MySqlConnection(DBConn.connstring);
                MySqlCommand cmd = new MySqlCommand(FinalQuery, conn);
                try
                {
                    MySqlDataAdapter dgv = new MySqlDataAdapter();
                    dgv.SelectCommand = cmd;
                    DataTable dbdatasec = new DataTable();
                    dgv.Fill(dbdatasec);
                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = dbdatasec;
                    dataGridView1.DataSource = bsource;
                    dgv.Update(dbdatasec);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void delete()
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
                myCommand.Parameters.AddWithValue("@code", label1.Text);
                string qD = @"delete
                                contacts,
                                emp_status_type,
                                contacts_job,
                                `language`,
                                elementary,
                                hs,
                                college,
                                grad,
                                disability,
                                eligibility,
                                prc,
                                skills,
                                tech_voc,
                                work_exp
                                from contacts
                                left join emp_status_type on contacts.id = emp_status_type.contact_id
                                left join contacts_job on contacts.id = contacts_job.contact_id
                                left join elementary on contacts.id = elementary.contact_id
                                left join `language` on contacts.id = `language`.contact_id
                                left join hs on contacts.id = hs.contact_id
                                left join college on contacts.id = college.contact_id
                                left join grad on contacts.id = grad.contact_id
                                left join disability on contacts.id = disability.contact_id
                                left join eligibility on contacts.id = eligibility.contact_id
                                left join prc on contacts.id = prc.contact_id
                                left join skills on contacts.id = skills.contact_id
                                left join tech_voc on contacts.id = tech_voc.contact_id
                                left join work_exp on contacts.id = work_exp.contact_id
                                where contacts.code = @code";
                myCommand.CommandText = qD;
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show("Record Deleted");
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
        private void button6_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(label1.Text) || label1.Text == "~code~")
            {
                return;
            }
            delete();
        }
    }
}
