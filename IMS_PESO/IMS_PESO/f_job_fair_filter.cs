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
    public partial class f_job_fair_filter : Form
    {
        DBConn DB = new DBConn();
        public f_job_fair_filter()
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void jfReport()
        {
            f_report a = new f_report();
            string iQry = @"SELECT
                        (select min(event_date) from jobfair2 where event_date between '{0}' and '{1}') `min`,
                        (select max(event_date) from jobfair2 where event_date between '{0}' and '{1}') `max`,
                        event_date,
                        host,
                        concat(surname, ', ', firstname, ' ', middlename) `name`,
                        brgy `address`,
                        sex `gender`,
                        cp_no `tel_no`,
                        position `job_position`,
                        hiring_company,
                        jobsite `location`,
                        `status`,
                        remarks
                        FROM jobfair2
                        where event_date between '{0}' and '{1}'
                        and host like '%%{2}%%'";
            string qry = string.Format(iQry, dateTimePicker1.Text, dateTimePicker2.Text, textBox1.Text);
            dataset ds = new dataset();
            using (MySqlConnection conn = new MySqlConnection(DBConn.connstring))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds, ds.Tables["jobFair"].TableName);
                _cr_jobFair rep = new _cr_jobFair();
                rep.SetDataSource(ds);
                a.crystalReportViewer1.ReportSource = rep;
                a.ShowDialog();
            }
        }

        private void nsrpReport()
        {
            f_report a = new f_report();
            string iQry = @"SELECT
                            event_date `DATE`,
                            concat(surname, ', ', firstname, ' ', middlename) `NAME`,
                            dob `BIRTHDAY`,
                            age `AGE`,
                            IF(sex = 'MALE','M','F') `GENDER`,
                            civil_status `CIVIL STATUS`,
                            religion `RELIGION`,
                            'BIRTHPLACE' `BIRTHPLACE`,
                            concat(brgy, ', ' , municipality, ', ', province) `ADDRESS`,
                            email `EMAIL`,
                            cp_no `CONTACT`,
                            `4ps` `4Ps`,
                            emp_status `EMP. STATUS`,
                            job_pre `JOB PREF.`,
                            educ_level `EDUC. LEVEL`,
                            skills `SKILLS`,
                            `from` `FROM`
                            FROM jobfair2
                            where event_date between '{0}' and '{1}'
                            order by date";
            dataset ds = new dataset();
            string qry = string.Format(iQry, dateTimePicker1.Text, dateTimePicker2.Text);
            using (MySqlConnection conn = new MySqlConnection(DBConn.connstring))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds, ds.Tables["nsrpReport"].TableName);
                _cr_nsrp rep = new _cr_nsrp();
                rep.SetDataSource(ds);
                a.crystalReportViewer1.ReportSource = rep;
                a.ShowDialog();
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "NSRP Report")
            {
                nsrpReport();
            }
            else
            {
                jfReport();
            }
            
        }
        
        private void spesFilter_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    ((Button)ctrl).ForeColor = System.Drawing.SystemColors.Control;
                    ((Button)ctrl).BackColor = System.Drawing.Color.DodgerBlue;
                    ((Button)ctrl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    ((Button)ctrl).FlatAppearance.BorderSize = 0;
                    ((Button)ctrl).Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (ctrl is Label)
                {
                    ((Label)ctrl).Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else if (ctrl is DateTimePicker)
                {
                    ((DateTimePicker)ctrl).Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void dateTimePicker1_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.dateTimePicker1, "use MM-dd-yyyy format");
        }

        private void dateTimePicker2_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.dateTimePicker2, "use MM-dd-yyyy format");
        }
    }
}
