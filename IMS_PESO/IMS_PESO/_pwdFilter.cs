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
    public partial class _pwdFilter : Form
    {
        DBConn DB = new DBConn();
        public _pwdFilter()
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
            string iQry = @"select
                        date,
                        code,
                        concat(surname, ', ', firstname, ' ', middlename) name,
                        address,
                        gender,
                        disability,
                        remarks
                        from pwd
                        where date between '{0}' and '{1}'
                        and school like '%%{2}%%'";
            string qry = string.Format(iQry, dateTimePicker1.Text, dateTimePicker2.Text, comboBox5.Text);

            dataset ds = new dataset();
            using (MySqlConnection conn = new MySqlConnection(DBConn.connstring))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds, ds.Tables["pwdReport"].TableName);
                _cr_pwd rep = new _cr_pwd();
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
