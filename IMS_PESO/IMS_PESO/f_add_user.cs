using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing.Imaging;

namespace IMS_PESO
{
    public partial class f_add_user : Form
    {
        public f_add_user()
        {
            InitializeComponent();
            //getDesignation();
            loadUsers();
        }
        private void loadUsers()
        {
            string query;
            query = @"select username `USERNAME`, designation `DESIGNATION` from accounts";
            string FinalQuery = string.Format(query);
            MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            MySqlCommand cmd = new MySqlCommand(FinalQuery, conn);
            try
            {
                MySqlDataAdapter dgv = new MySqlDataAdapter();
                dgv.SelectCommand = cmd;
                DataTable dbdatasec = new DataTable();
                dgv.Fill(dbdatasec);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdatasec;
                dataGridView1.DataSource = bsource;
                dgv.Update(dbdatasec);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void getDesignation()
        {
            MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            MySqlDataReader myreader;
            string query = @"select designation from accounts";
            MySqlCommand cmdmdlr = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                myreader = cmdmdlr.ExecuteReader();

                while (myreader.Read())
                {
                    string designation = myreader.GetString("designation");
                    comboBox5.Items.Add(designation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(comboBox5.Text))
            {
                MessageBox.Show(this, "Fields Cannot be empty!", "System Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (button6.Text == "Save")
                {
                    insert();
                }
                else
                {
                    update();
                }
            }
            
        }

        private void _collegeSchoolarFilter_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    //((TextBox)ctrl).ForeColor = System.Drawing.Color.DodgerBlue;
                }
                else if (ctrl is Label)
                {
                    ((Label)ctrl).ForeColor = System.Drawing.SystemColors.Control;
                }
                else if (ctrl is Button)
                {
                    ((Button)ctrl).ForeColor = System.Drawing.Color.DodgerBlue;
                }
            }
        }
        private void update()
        {
            MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            conn.Open();
            MySqlCommand myCommand = conn.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = conn.BeginTransaction();
            myCommand.Connection = conn;
            myCommand.Transaction = myTrans;

            //this is the code for adding image
            Image image = pictureBox1.Image;
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Png);
            byte[] imageBt = memoryStream.ToArray();

            try
            {
                myCommand = conn.CreateCommand();
                myCommand.Parameters.AddWithValue("@username", textBox6.Text);
                myCommand.Parameters.AddWithValue("@password", textBox1.Text);
                myCommand.Parameters.AddWithValue("@designation", comboBox5.Text);
                myCommand.Parameters.AddWithValue("@image", imageBt);
                myCommand.Parameters.AddWithValue("@g_code", g_code);
                string query = @"update accounts set username = @username, password = @password, designation = @designation, image = @image where username = @g_code";
                myCommand.CommandText = query;
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show(this, "User Saved!", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button6.Text = "Save";
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
                textBox6.Text = string.Empty;
                textBox1.Text = string.Empty;
                comboBox5.SelectedIndex = -1;
                imageBt = null;
                loadUsers();
            }
        }

        private void insert()
        {
            MySqlConnection conn = new MySqlConnection(DBConn.connstring);
            conn.Open();
            MySqlCommand myCommand = conn.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = conn.BeginTransaction();
            myCommand.Connection = conn;
            myCommand.Transaction = myTrans;

            //this is the code for adding image
            Image image = pictureBox1.Image;
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Png);
            byte[] imageBt = memoryStream.ToArray();

            try
            {
                myCommand = conn.CreateCommand();
                myCommand.Parameters.AddWithValue("@username", textBox6.Text);
                myCommand.Parameters.AddWithValue("@password", textBox1.Text);
                myCommand.Parameters.AddWithValue("@designation", comboBox5.Text);
                myCommand.Parameters.AddWithValue("@image", imageBt);
                string query = @"insert into accounts
                                        (username, password, designation, image)
                                        values
                                        (@username, @password, @designation, @image)";
                myCommand.CommandText = query;
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show(this, "User Saved!", "Peter Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                textBox6.Text = string.Empty;
                textBox1.Text = string.Empty;
                comboBox5.SelectedIndex = -1;
                imageBt = null;
                loadUsers();
            }
        }
        public string g_code = null;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //it checks if the row index of the cell is greater than or equal to zero
            if (e.RowIndex >= 0)
            {
                button6.Text = "Update / Reset Password";
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                textBox6.Text = row.Cells[0].Value.ToString();
                comboBox5.Text = row.Cells[1].Value.ToString();
                g_code = row.Cells[0].Value.ToString();

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(DBConn.connstring))
                    {
                        string qry = @"SELECT image FROM accounts where username = @username";
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(qry, conn);
                        cmd.Parameters.AddWithValue("@username", g_code);
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        try
                        {
                            byte[] img = (byte[])dataTable.Rows[0][0];
                            MemoryStream ms = new MemoryStream(img);
                            pictureBox1.Image = Image.FromStream(ms);
                            adapter.Dispose();
                            img = null;
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            //return;
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image files | *.jpg";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cellMouseMove(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hhmm, Are you sure you want to delete this User?", "System Says", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                delete();
                loadUsers();
            }
            else
            {
                MessageBox.Show("Delete operation Cancelled.");
            }
        }

        private void delete()
        {
            MySqlConnection myConnection = new MySqlConnection(DBConn.connstring);
            myConnection.Open();

            MySqlCommand myCommand = myConnection.CreateCommand();
            MySqlTransaction myTrans;

            // Start a local transaction
            myTrans = myConnection.BeginTransaction();
            // Must assign both transaction object and connection
            // to Command object for a pending local transaction
            myCommand.Connection = myConnection;
            myCommand.Transaction = myTrans;

            try
            {
                myCommand.CommandText = @"DELETE FROM accounts where username = @code;";
                myCommand.Parameters.AddWithValue("@code", selected_code);
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show("User Deleted!");
                loadUsers();
            }
            catch (Exception e)
            {
                try
                {
                    myTrans.Rollback();
                }
                catch (MySqlException ex)
                {
                    if (myTrans.Connection != null)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                MessageBox.Show(e.ToString());
            }
            finally
            {
                myConnection.Close();
                selected_code = null;
            }
        }

        string selected_code;
        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            // function for getting the mouse hovered cell value
            try
            {
                if ((e.RowIndex >= 0 && e.ColumnIndex >= 0))
                {
                    selected_code = dataGridView1[0, e.RowIndex].Value.ToString();
                }
            }
            catch (NullReferenceException err)
            {
                return;
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();

                int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    m.MenuItems.Add(new MenuItem(string.Format("Delete User: \"{0}\"", selected_code), cellMouseMove));
                }

                m.Show(dataGridView1, new Point(e.X, e.Y));

            }
        }

        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {
           
        }
    }
}
