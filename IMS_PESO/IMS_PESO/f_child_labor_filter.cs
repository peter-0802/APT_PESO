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
    public partial class f_child_labor_filter : Form
    {
        public f_child_labor_filter()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            f_report a = new f_report();
            string iQry = @"SELECT
                        event_date,
                        event,
                        host,
                        veneu,
                        concat(surname, ', ', firstname, ' ', middlename) `name`,
                        gender,
                        purok,
                        address,
                        dob,
                        contact,
                        work_type
                        FROM child_labor
                        where event_date between '{0}' and '{1}'
                        and event like '%%{2}%%'
                        and host like '%%{3}%%'
                        and veneu like '%%{4}%%'
                        and address like '%%{6}%%'
                        and concat(surname, firstname, middlename) like '%%{5}%%'
                        and archived = 0";
            string qry = string.Format(iQry, dateTimePicker1.Text, dateTimePicker2.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, comboBox5.Text);
            string datasetTable = "childLaborReport";

            dataset ds = new dataset();
            using (MySqlConnection conn = new MySqlConnection(DBConn.connstring))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(qry, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds, ds.Tables[datasetTable].TableName);
                _cr_childLaborReport rep = new _cr_childLaborReport();
                rep.SetDataSource(ds);
                a.crystalReportViewer1.ReportSource = rep;
                a.ShowDialog();
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

        private void f_child_labor_filter_Load(object sender, EventArgs e)
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
    }
}
