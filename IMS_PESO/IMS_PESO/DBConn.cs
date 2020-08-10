using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace IMS_PESO
{
    class DBConn
    {
        public string Datasource;
        public string Port;
        public string Database;
        public string Username;
        public string Password;
        public static string connstring;
        public string addminpass;
        public void getDataSource()
        {
            RegistryKey APT = null;
            try
            {
                APT = Registry.CurrentUser.OpenSubKey(@"APT\SchoolControl\DECLARATIONS");
                if (APT != null)
                {
                    Datasource = APT.GetValue("Datasource").ToString();
                    Port = APT.GetValue("Port").ToString();
                    Database = APT.GetValue("Database").ToString();
                    Username = APT.GetValue("Username").ToString();
                    Password = APT.GetValue("Password").ToString();
                    addminpass = APT.GetValue("adminpass").ToString();
                    string connect = "datasource = '" + Datasource + "'; port = '" + Port + "'; database = '" + Database + "'; username = '" + Username + "'; password = '" + Password + "'; SSL Mode = NONE";
                    connstring = connect;
                    APT.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                APT.Close();
            }

        }
    }
}
