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
    public partial class f_rwa_filter : Form
    {
        DBConn DB = new DBConn();
        public f_rwa_filter()
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
            f_report a = new f_report();
            string iQry = @"select
                            date `DATE`,
                            code `CODE`,
                            establishment_name `ESTABLISHMENT`,
                            acronym `ACRONYM`,
                            tin `TIN`,
                            contact_person `CONTACT_PERSON`,
                            tel `TEL`,
                            type `TYPE`
                            from rwa
                        where date between '{0}' and '{1}'";
            string qry = string.Format(iQry, dateTimePicker1.Text, dateTimePicker2.Text);

            dataset ds = new dataset();
            using (MySqlConnection conn = new MySqlConnection(DBConn.connstring))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds, ds.Tables["rwaReport"].TableName);
                _cr_rwa rep = new _cr_rwa();
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
