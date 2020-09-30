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
    public partial class _jobFairFilter : Form
    {
        DBConn DB = new DBConn();
        public _jobFairFilter()
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

        private void button6_Click(object sender, EventArgs e)
        {
            report a = new report();
            string iQry = @"SELECT
                        (select min(event_date) from jobfair where event_date between '{0}' and '{1}') `min`,
                        (select max(event_date) from jobfair where event_date between '{0}' and '{1}') `max`,
                        host,
                        concat(surname, ', ', firstname, ' ', middlename) `name`,
                        address,
                        gender,
                        tel_no,
                        job_position,
                        hiring_company,
                        location,
                        `status`,
                        remarks
                        FROM jobfair
                        where event_date between '{0}' and '{1}'
                        and host like '%%{2}%%'
                        group by event_date";
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
        
        private void spesFilter_Load(object sender, EventArgs e)
        {

        }
    }
}
