using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class ExceltoSql : Form
    {
        public ExceltoSql()
        {
            InitializeComponent();
        }
        public String intAutoIncriment = "int NOT NULL AUTO_INCREMENT PRIMARY KEY";
        public String varchar = "TEXT NULL DEFAULT NULL";
        public String tableString = @"CREATE TABLE IF NOT EXISTS {0}({1})COLLATE= latin1_swedish_ci ENGINE=InnoDB;";
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.DefaultExt = "xls";
            fd.Filter = "ExcelFiles|*.xls";
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = fd.FileName;
                InitCOnnectionString();
                ReadShets();
            }
        }

        private void InitCOnnectionString()
        {
            connectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;ReadOnly=False;$HDR=Yes;IMEX=2';";
        }
        
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        List<String> excepList = new List<string>();
        List<String> list = new List<string>();
        void InsertIntoMariaDB()
        {
            dbConnectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                //Get All Sheets Name
                
                DataTable sheetsName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                //var dbCreation = "CREATE DATABASE `TB`";
                using (MySqlConnection connection = new MySqlConnection(dbConnectionString))
                {
                    connection.Open();
                   // ProicessCommand(list, dbCreation, connection);
                    foreach (var item in wsList)
                    {
                        try
                        {
                            string sql = string.Format("SELECT * FROM [{0}] ", item);
                            OleDbDataAdapter ada = new OleDbDataAdapter(sql, connectionString);
                            DataSet set = new DataSet();
                            ada.Fill(set);
                            DataTable tables = set.Tables[0];
                            LastRow = tables.Rows.Count;
                            var table = set.Tables[0].AsEnumerable();

                            var colCreationScript = GetColumnCreationScript(tables.Columns);
                            var tableCreationScript = String.Format(tableString, item.Replace("$", ""), colCreationScript);
                            var query = "";
                            ProicessCommand(list, tableCreationScript, connection);
                            for (int i = 0; i < LastRow; i++)
                            {
                                try
                                {
                                    var row = tables.Rows[i];
                                    query = GetQueryString(row, tables.Columns, item);
                                    ProicessCommand(list, query, connection);
                                }
                                catch (Exception ex)
                                {
                                    excepList.Add(query + "\r\n" + ex.Message);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }
                if (isSave)
                {
                    File.WriteAllLines(sqlFilePath, list);
                }
            }
            if (excepList.Count > 0)
            {
                File.WriteAllLines(sqlFilePath.Replace(".sql",".log"), excepList);
            }
        }

        private void ProicessCommand(List<String> list, string dbCreation, MySqlConnection connection)
        {
            if (!isSave)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(dbCreation, connection);
                    //Execute command
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    excepList.Add(dbCreation + "\r\n" + ex.Message);
                }
            }
            else
            {
                list.Add(dbCreation);
            }
        }
        String firstColName = "";
        private String GetColumnCreationScript(DataColumnCollection dataColumnCollection)
        {
            var retVal = "";
            for (int i = 0; i < dataColumnCollection.Count; i++)
            {
                if (i == 0)
                {
                    firstColName = dataColumnCollection[i].ColumnName.Trim();
                    retVal = String.Format("{0} {1}", firstColName, intAutoIncriment);
                }
                else
                {
                    retVal += String.Format(",{0} {1}", dataColumnCollection[i].ColumnName.Trim(), varchar);
                }
            }
            return retVal;
        }

        bool isSave;
        private String GetQueryString(DataRow row, DataColumnCollection dataColumnCollection, String item)
        {
            var retval = "";
            var colString = "";
            for (int i = 0; i < dataColumnCollection.Count; i++)
            {
                if (dataColumnCollection[i].ColumnName.ToLower().Contains("no"))
                {
                    retval = row.ItemArray[i].ToString();
                    colString = String.Format("{0}", dataColumnCollection[i].ColumnName);
                }
                else
                {
                    colString += String.Format(",{0}", dataColumnCollection[i].ColumnName);
                    retval += String.Format(",\"{0}\"", row.ItemArray[i].ToString().Replace("\""," "));
                }
            }
            var dbQuery = String.Format("INSERT INTO {0}({1}) VALUES ({2})", item.Replace("$", ""), colString, retval);
            return dbQuery;

        }

        private void ReadShets()
        {
            //string connstring = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1';";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                //Get All Sheets Name
                DataTable sheetsName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                wsList = sheetsName.Rows.OfType<DataRow>().Where(ex => ex["TABLE_NAME"].ToString().EndsWith("$")).Select(ex => ex["TABLE_NAME"].ToString()).ToList();
            }
        }
        public string filePath { get; set; }

        public string connectionString { get; set; }

        public string dbConnectionString { get; set; }

        public List<string> wsList { get; set; }

        public int LastRow { get; set; }
        public string sqlFilePath = @"D:\db.sql";
        private void btnSqlSave_Click(object sender, EventArgs e)
        {
            server = dbIpAddress.Text;
            database = lblDBName.Text;
            uid = lblUID.Text;
            password = lblPwd.Text;
            if (server.Length > 0 && database.Length > 0 && uid.Length > 0 && password.Length > 0)
            {
                SaveFileDialog fd = new SaveFileDialog();
                fd.DefaultExt = "sql";
                fd.Filter = "Sql files|*.sql";
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    filePath = fd.FileName;
                    isSave = true;
                    InsertIntoMariaDB();
                }
            }
            else
            {
                MessageBox.Show("Give Complete Details to Convert");
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            server = dbIpAddress.Text;
            database = lblDBName.Text ;
            uid = lblUID.Text;
            password = lblPwd.Text;
            if (server.Length > 0 && database.Length > 0 && uid.Length > 0 && password.Length > 0)
            {
                InsertIntoMariaDB();
            }
            else
            {
                MessageBox.Show("Give Complete Details to Convert");
            }
        }
    }
}
