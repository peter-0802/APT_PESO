﻿using System;
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
    public partial class ofwFilter : Form
    {
        DBConn DB = new DBConn();
        public ofwFilter()
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
            _report a = new _report();
            string iQry = @"SELECT
                        (select min(event_date) from sra where event_date between '{0}' and '{1}') `min`,
                        (select max(event_date) from sra where event_date between '{0}' and '{1}') `max`,
                        agency,
                        sra_no,
                        host,
                        veneu,
                        address_branch,
                        rep_contact,
                        concat(surname, ', ', firstname, ' ', middlename) `name`,
                        address,
                        age,
                        gender,
                        `position`,
                        jobsite,
                        remarks
                        FROM sra
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
        
        private void spesFilter_Load(object sender, EventArgs e)
        {

        }
    }
}
