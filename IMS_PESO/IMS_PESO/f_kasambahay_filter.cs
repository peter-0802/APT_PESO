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
    public partial class f_kasambahay_filter : Form
    {
        DBConn DB = new DBConn();
        public f_kasambahay_filter()
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

        private void nsrpReport()
        {
            f_report a = new f_report();
            string iQry = @"SELECT
                            date `DATE`,
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
                            FROM kasambahay2
                            where date between '{0}' and '{1}'
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

        private void kasReport()
        {
            f_report a = new f_report();
            string iQry = @"select
                        date,
                        code,
                        concat(surname, ', ', firstname, ' ', middlename) name,
                        brgy,
                        sex,
                        cp_no,
                        status,
                        remarks
                        from kasambahay2
                        where date between '{0}' and '{1}'
                        and brgy like '%%{2}%%'";
            string qry = string.Format(iQry, dateTimePicker1.Text, dateTimePicker2.Text, comboBox5.Text);

            dataset ds = new dataset();
            using (MySqlConnection conn = new MySqlConnection(DBConn.connstring))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds, ds.Tables["kasReport"].TableName);
                _cr_kasReport rep = new _cr_kasReport();
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
                kasReport();
            }
        }
        
        private void spesFilter_Load(object sender, EventArgs e)
        {

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
