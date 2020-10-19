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
    public partial class _report : Form
    {
        DBConn DB = new DBConn();
        public _report()
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

        

        public string qry = null;
        public string datasetTable = null;
        //public void bindreport()
        //{
        //    dataset ds = new dataset();
        //    using (MySqlConnection conn = new MySqlConnection(DBConn.connstring))
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand(qry, conn);
        //        MySqlDataAdapter adapter = new MySqlDataAdapter();
        //        adapter.SelectCommand = cmd;
        //        adapter.Fill(ds, ds.Tables[datasetTable].TableName);
        //        cr_childLaborReport rep = new cr_childLaborReport();
        //        rep.SetDataSource(ds);
        //        this.crystalReportViewer1.ReportSource = rep;
        //    }
        //}
        private void report_Load(object sender, EventArgs e)
        {
        }
        }
    }