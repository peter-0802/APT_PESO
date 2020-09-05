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
    public partial class auth : Form
    {
        DBConn DB = new DBConn();
        public auth()
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string upflag;
        private void auth_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBox3.Text != DB.addminpass)
            {
                upflag = "0";
            }
            else
            {
                upflag = "1";
            }
        }
    }
}
