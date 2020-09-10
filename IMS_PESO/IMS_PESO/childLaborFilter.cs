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
    public partial class childLaborFilter : Form
    {
        public childLaborFilter()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            report a = new report();
            string iQry = @"SELECT
                        event_date,
                        event,
                        host,
                        veneu,
                        surname,
                        firstname,
                        middlename,
                        gender,
                        concat(surname, firstname, middlename) `test`
                        FROM child_labor
                        where event_date between '{0}' and '{1}'
                        and event like '%%{2}%%'
                        and host like '%%{3}%%'
                        and veneu like '%%{4}%%'
                        and concat(surname, firstname, middlename) like '%%{5}%%'";
            string qry = string.Format(iQry, dateTimePicker1.Text, dateTimePicker2.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            string datasetTable = "childLaborReport";

            dataset ds = new dataset();
            using (MySqlConnection conn = new MySqlConnection(DBConn.connstring))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds, ds.Tables[datasetTable].TableName);
                cr_childLaborReport rep = new cr_childLaborReport();
                rep.SetDataSource(ds);
                a.crystalReportViewer1.ReportSource = rep;
                a.ShowDialog();
            }
        }
    }
}
