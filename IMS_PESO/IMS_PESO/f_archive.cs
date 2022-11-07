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
    public partial class f_archive : Form
    {
        DBConn DB = new DBConn();
        public f_archive()
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

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        
        private void getEvent()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns.Clear();

            string query = @"
                           SELECT id, 'child_labor' as `tab`, 'Child Labor' as `Program`, concat(surname, ', ', firstname, ' ', middlename) `Name` FROM child_labor where archived = 1
                            union
                            SELECT id, 'hsshcoolar' as `tab`, 'HS Scholar' as `Program`, concat(surname, ', ', firstname, ' ', middlename) `Name` FROM hsshcoolar where archived = 1
                            union
                            SELECT id, 'contact2' as `tab`, 'NSRP' as `Program`, concat(surname, ', ', firstname, ' ', middlename) `Name` FROM contact2 where archived = 1
                            union
                            SELECT id, 'jobfair2' as `tab`, 'Job Fair' as `Program`, concat(surname, ', ', firstname, ' ', middlename) `Name` FROM jobfair2 where archived = 1
                            union
                            SELECT id, 'kasambahay2' as `tab`, 'Kasambahay' as `Program`, concat(surname, ', ', firstname, ' ', middlename) `Name` FROM kasambahay2 where archived = 1
                            union
                            SELECT id, 'ofw2' as `tab`, 'OFW' as `Program`, concat(surname, ', ', firstname, ' ', middlename) `Name` FROM ofw2 where archived = 1
                            union
                            SELECT id, 'pwd' as `tab`, 'PWD' as `Program`, concat(surname, ', ', firstname, ' ', middlename) `Name` FROM pwd where archived = 1
                            union
                            SELECT id, 'schoolar_coll' as `tab`, 'College Scholar' as `Program`, concat(surname, ', ', firstname, ' ', middlename) `Name` FROM schoolar_coll where archived = 1
                            union
                            SELECT id, 'sra2' as `tab`, 'SRA' as `Program`, concat(surname, ', ', firstname, ' ', middlename) `Name` FROM sra2 where archived = 1
                            union
                            SELECT id, 'spes' as `tab`, 'SPES' as `Program`, concat(surname, ', ', firstname, ' ', middlename) `Name` FROM spes where archived = 1
                            union
                            SELECT id, 'contact2' as `tab`, 'NSRP' as `Program`, concat(surname, ', ', firstname, ' ', middlename) `Name` FROM contact2 where archived = 1
                                ";
            MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                MySqlDataAdapter dgv = new MySqlDataAdapter();
                dgv.SelectCommand = cmd;
                DataTable dbdatasec = new DataTable();
                dgv.Fill(dbdatasec);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdatasec;
                dataGridView1.DataSource = bsource;

                //Add a CheckBox Column to the DataGridView at the first position.
                DataGridViewButtonColumn pre_test = new DataGridViewButtonColumn();
                pre_test.UseColumnTextForButtonValue = true;
                pre_test.HeaderText = "Retrieve";
                pre_test.Width = 30;
                pre_test.Name = "Retrieve";
                pre_test.Text = "Retrieve";
                dataGridView1.Columns.Insert(4, pre_test);

                DataGridViewButtonColumn remediation = new DataGridViewButtonColumn();
                remediation.UseColumnTextForButtonValue = true;
                remediation.HeaderText = "Delete Permanently";
                remediation.Width = 30;
                remediation.Name = "Delete Permanently";
                remediation.Text = "Delete Permanently";
                dataGridView1.Columns.Insert(5, remediation);

                dgv.Update(dbdatasec);

                try
                {
                    this.dataGridView1.Rows[0].Cells[0].Selected = false;
                }
                catch (Exception)
                {

                    return;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close(); ;
            }
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].Visible = false;
        }

        private void f_archive_Load(object sender, EventArgs e)
        {
            getEvent();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

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

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string option = dataGridView1.Columns[e.ColumnIndex].Name;
                if (option == "Retrieve")
                {
                    if (dataGridView1.SelectedCells.Count > 0)
                    {
                        int selectedidindex = dataGridView1.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedid = dataGridView1.Rows[selectedidindex];
                        string id = Convert.ToString(selectedid.Cells[0].Value);
                        

                        int selectedtableindex = dataGridView1.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedtable = dataGridView1.Rows[selectedtableindex];
                        string table = Convert.ToString(selectedtable.Cells[1].Value);

                        MySqlConnection conn = new MySqlConnection(DBConn.connstring);
                        conn.Open();
                        MySqlCommand myCommand = conn.CreateCommand();
                        MySqlTransaction myTrans;
                        myTrans = conn.BeginTransaction();
                        myCommand.Connection = conn;
                        myCommand.Transaction = myTrans;
                        try
                        {
                            myCommand.Parameters.AddWithValue("@id", id);
                            myCommand.Parameters.AddWithValue("@table", table);
                            string qD = @"update {0} set archived = 0 where id = {1}";
                            string _qD = string.Format(qD, table, id);
                            myCommand.CommandText = _qD;
                            myCommand.ExecuteNonQuery();
                            myTrans.Commit();
                            MessageBox.Show(this, "Record Retrieved", "Sytem Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception exg)
                        {
                            try
                            {
                                myTrans.Rollback();
                            }
                            catch (Exception ex)
                            {
                                if (myTrans.Connection != null)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                            }
                            MessageBox.Show(exg.ToString());
                        }
                        finally
                        {
                            conn.Close();
                        }
                        getEvent();

                    }
                }
                else if (option == "Delete Permanently")
                {
                    if (dataGridView1.SelectedCells.Count > 0)
                    {
                        int selectedidindex = dataGridView1.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedid = dataGridView1.Rows[selectedidindex];
                        string id = Convert.ToString(selectedid.Cells[0].Value);


                        int selectedtableindex = dataGridView1.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedtable = dataGridView1.Rows[selectedtableindex];
                        string table = Convert.ToString(selectedtable.Cells[1].Value);

                        MySqlConnection conn = new MySqlConnection(DBConn.connstring);
                        conn.Open();
                        MySqlCommand myCommand = conn.CreateCommand();
                        MySqlTransaction myTrans;
                        myTrans = conn.BeginTransaction();
                        myCommand.Connection = conn;
                        myCommand.Transaction = myTrans;
                        try
                        {
                            myCommand.Parameters.AddWithValue("@id", id);
                            myCommand.Parameters.AddWithValue("@table", table);
                            string qD = @"delete from {0} where id = {1}";
                            string _qD = string.Format(qD, table, id);
                            myCommand.CommandText = _qD;
                            myCommand.ExecuteNonQuery();
                            myTrans.Commit();
                            MessageBox.Show(this, "Record Deleted Permanently", "Sytem Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception exg)
                        {
                            try
                            {
                                myTrans.Rollback();
                            }
                            catch (Exception ex)
                            {
                                if (myTrans.Connection != null)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                            }
                            MessageBox.Show(exg.ToString());
                        }
                        finally
                        {
                            conn.Close();
                        }
                        getEvent();

                    }
                }
                else
                {
                    return;
                }
            }
        }
        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
