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
    public partial class _hsSchoolarFilter : Form
    {
        public _hsSchoolarFilter()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            _report a = new _report();
            string iQry = @"SELECT
                            date `DATE`,
                            code `CODE`,
                            concat(surname, ', ', firstname, ' ', middlename) `NAME`,
                            gender `GENDER`,
                            dob `BOD`,
                            mother `MOTHERNAME`,
                            father `FATHERNAME`,
                            address `ADDRESS`,
                            contact `CONTACT`,
                            school `SCHOOL`,
                            yearlevel `YEAR`,
                            ave `AVE`,
                            status `STATUS`
                            FROM hsshcoolar
                            where date between '{0}' and '{1}'
                            and address like '%%{2}%%'
                            and school like '%%{3}%%'
                            and status like '%%{4}%%'
                            group by code";
            string qry = string.Format(iQry, dateTimePicker1.Text, dateTimePicker2.Text, comboBox5.Text, textBox6.Text, comboBox1.Text);
            string datasetTable = "hsReport";

            dataset ds = new dataset();
            using (MySqlConnection conn = new MySqlConnection(DBConn.connstring))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds, ds.Tables[datasetTable].TableName);
                _cr_shReport rep = new _cr_shReport();
                rep.SetDataSource(ds);
                a.crystalReportViewer1.ReportSource = rep;
                a.ShowDialog();
            }
        }
    }
}
