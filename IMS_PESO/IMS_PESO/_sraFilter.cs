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
    public partial class _sraFilter : Form
    {
        DBConn DB = new DBConn();
        public _sraFilter()
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
            _report a = new _report();
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
                            FROM sra2
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
        private void sraReport()
        {
            _report a = new _report();
            string iQry = @"SELECT
                        (select min(event_date) from sra2 where event_date between '{0}' and '{1}') `min`,
                        (select max(event_date) from sra2 where event_date between '{0}' and '{1}') `max`,
                        agency,
                        sra_no,
                        host,
                        veneu,
                        address_branch,
                        rep_contact,
                        concat(surname, ', ', firstname, ' ', middlename) `name`,
                        brgy `address`,
                        age,
                        sex `gender`,
                        `position`,
                        jobsite,
                        remarks
                        FROM sra2
                        where event_date between '{0}' and '{1}'
                        and agency like '%%{2}%%'
                        and sra_no like '%%{3}%%'
                        group by agency";
            string qry = string.Format(iQry, dateTimePicker1.Text, dateTimePicker2.Text, textBox1.Text, textBox2.Text);
            dataset ds = new dataset();
            using (MySqlConnection conn = new MySqlConnection(DBConn.connstring))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds, ds.Tables["sraReport"].TableName);
                _cr_sraReport rep = new _cr_sraReport();
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
                sraReport();
            }
        }
        
        private void spesFilter_Load(object sender, EventArgs e)
        {

        }
    }
}
