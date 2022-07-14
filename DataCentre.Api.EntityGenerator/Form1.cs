using DataCentre.Api.EntityGenerator.Model;
using DataCentre.Api.EntityGenerator.Utility;
using MySqlConnector;
using Newtonsoft.Json;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataCentre.Api.EntityGenerator
{
    public partial class frmEntityCodeGrenerator : Form
    {
        public frmEntityCodeGrenerator()
        {
            InitializeComponent();
            if(File.Exists(Constant.DB_SET_JSON_PATH))
            {
                DBSetting? dBset = JsonConvert.DeserializeObject<DBSetting>(File.ReadAllText(Constant.DB_SET_JSON_PATH));
                if(dBset != null)
                {
                    txtIP.Text = dBset.DB_IP;
                    txtDBName.Text = dBset.DB_NAME;
                    txtUserName.Text = dBset.DB_USER;
                    txtPassword.Text = dBset.DB_PASS;
                    txtPort.Text = dBset.DB_PORT;
                    cboDBType.Text = dBset.DB_TYPE;
                }
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            IDbConnection conn = null;
            string connString = string.Empty;
            if(string.IsNullOrEmpty(cboDBType.Text))
            {
                MessageBox.Show(Constant.PLEASE_SELECT_DB_TYPE);
                return;
            }
            if(string.IsNullOrEmpty(txtIP.Text.Trim()))
            {
                MessageBox.Show(Constant.PLEASE_INPUT_DB_IP);
                txtIP.Focus();
                return;
            }
            if(string.IsNullOrEmpty(txtDBName.Text.Trim()))
            {
                MessageBox.Show(Constant.PLEASE_INPUT_DB_NAME);
                txtDBName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                MessageBox.Show(Constant.PLEASE_INPUT_DB_USERNAME);
                txtUserName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show(Constant.PLEASE_INPUT_DB_PASSWORD);
                txtPassword.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPort.Text.Trim()))
            {
                MessageBox.Show(Constant.PLEASE_INPUT_DB_PORT);
                txtPort.Focus();
                return;
            }
            if (cboDBType.Text.ToUpper() == Constant.MYSQL)
            {
                connString = string.Format(Constant.DB_CONN_MYSQL, txtIP.Text, txtPort.Text, txtUserName.Text, txtPassword.Text, txtDBName.Text);
                conn = new MySqlConnection(connString);
            }
            else if (cboDBType.Text.ToUpper() == Constant.MS_SQL)
            {
                connString = string.Format(Constant.DB_CONN_MS_SQL, txtIP.Text, txtUserName.Text, txtPassword.Text, txtDBName.Text);
                conn = new SqlConnection(connString);
            }
            try
            {
                if (conn != null)
                {
                    conn.Open();
                    MessageBox.Show(Constant.TEST_OPEN_CONN_OK);
                }
                else
                {
                    MessageBox.Show(Constant.UNDEFINED_DB_TYPE);
                }    
            }
            catch 
            { 
                MessageBox.Show(Constant.TEST_OPEN_CONN_ERROR); 
            }
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            try
            {
                DBSetting dbSet = new DBSetting();
                dbSet.DB_IP = txtIP.Text.Trim();
                dbSet.DB_NAME = txtDBName.Text.Trim();
                dbSet.DB_USER = txtUserName.Text.Trim();
                dbSet.DB_PASS = txtPassword.Text.Trim();
                dbSet.DB_PORT = txtPort.Text.Trim();
                dbSet.DB_TYPE = cboDBType.Text;
                if(File.Exists(@".\dbSet.json"))
                {
                    File.Delete(@".\dbSet.json");
                }
                string jsonStr = JsonConvert.SerializeObject(dbSet);
                File.WriteAllText(@".\dbSet.json", jsonStr);
                MessageBox.Show(Constant.EXECUTE_SUCCESS);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex+ex.StackTrace);
            }
        }

        private void btnListTable_Click(object sender, EventArgs e)
        {
            clbTableList.Items.Clear();
            DataSet ds = GetTabColDataSet(string.Format(Constant.LIST_TABLE_SQL, txtDBName.Text));//new DataSet();
            int idex = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                clbTableList.Items.Add(row["TableName"].ToString());
                clbTableList.SetItemChecked(idex, true);
                idex++;
            }
        }
        public DataSet GetTabColDataSet (string stSQL)
        {
            IDbConnection conn = null;
            IDbDataAdapter dataAdapter = null;
            string connString = string.Empty;
            string strSQL = string.Empty;
            if (cboDBType.Text.ToUpper() == Constant.MYSQL)
            {
                connString = string.Format(Constant.DB_CONN_MYSQL, txtIP.Text, txtPort.Text, txtUserName.Text, txtPassword.Text, txtDBName.Text);
                conn = new MySqlConnection(connString);
                dataAdapter = new MySqlDataAdapter();
                strSQL = stSQL;
            }
            if (cboDBType.Text.ToUpper() == Constant.MS_SQL)
            {
                connString = string.Format(Constant.DB_CONN_MS_SQL, txtIP.Text, txtUserName.Text, txtPassword.Text, txtDBName.Text);
                conn = new SqlConnection(connString);
                dataAdapter = new SqlDataAdapter();
            }
            if(conn != null)
                conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = strSQL;
            DataSet ds = new DataSet();
            if (dataAdapter != null)
            {
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(ds);
            }
            return ds;
        }
        private void btnGenerateModel_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtOutputPath.Text.Trim()))
                {
                    MessageBox.Show(Constant.PLEASE_INPUT_OUT_PATH);
                    return;
                }
                if(clbTableList.Items.Count == 0)
                {
                    MessageBox.Show(Constant.PLEASE_GENERATE_TABLE_LIST);
                    return;
                }
                if (cboDBType.Text.ToUpper() == Constant.MYSQL)
                {
                    for (int i = 0; i < clbTableList.Items.Count; i++)
                    {
                        bool chk = clbTableList.GetItemChecked(i);
                        if (chk)
                        {
                            string tableName = clbTableList.Items[i].ToString();
                            DataSet ds = GetTabColDataSet(string.Format(Constant.SELECT_COLUMN_SQL, txtDBName.Text, tableName));
                            if (File.Exists(txtOutputPath.Text.Trim() + @"\" + tableName + ".cs"))
                            {
                                if(!Directory.Exists(txtOutputPath.Text.Trim() + @"\Backup\"))
                                {
                                    Directory.CreateDirectory(txtOutputPath.Text.Trim() + @"\Backup\");
                                }
                                File.Move(txtOutputPath.Text.Trim() + @"\" + tableName + ".cs", txtOutputPath.Text.Trim() + @"\Backup\" + tableName + ".cs." + DateTime.Now.ToString("yyyyMMddHHmmss"));
                            }
                            using (FileStream str = File.Create(txtOutputPath.Text.Trim() + @"\" + tableName + ".cs"))
                            {
                                using (var sr = new StreamWriter(str))
                                {
                                    sr.WriteLine("using System;");
                                    sr.WriteLine("using Dapper;");
                                    sr.WriteLine("public class " + tableName);
                                    sr.WriteLine("{");
                                    foreach (DataRow row in ds.Tables[0].Rows)
                                    {
                                        if (row["IsPrimaryKey"].ToString() == "PRI")
                                        {
                                            sr.WriteLine("    [Key]");
                                        }
                                        sr.Write("    public ");
                                        if (row["Type"].ToString().IndexOf("varchar") != -1 
                                            || row["Type"].ToString() == "text")
                                        {
                                            sr.WriteLine("string " + row["ColumnName"].ToString() + " { get; set; }");
                                        }
                                        if (row["Type"].ToString() == "smallint")
                                        {
                                            sr.WriteLine("short " + row["ColumnName"].ToString() + " { get; set; }");
                                        }
                                        if (row["Type"].ToString() == "datetime")
                                        {
                                            sr.WriteLine("DateTime " + row["ColumnName"].ToString() + " { get; set; }");
                                        }
                                        if (row["Type"].ToString() == "int")
                                        {
                                            sr.WriteLine("int " + row["ColumnName"].ToString() + " { get; set; }");
                                        }
                                        if (row["Type"].ToString() == "decimal")
                                        {
                                            sr.WriteLine("decimal " + row["ColumnName"].ToString() + " { get; set; }");
                                        }
                                        if (row["Type"].ToString() == "bit")
                                        {
                                            sr.WriteLine("bool " + row["ColumnName"].ToString() + " { get; set; }");
                                        }
                                        if (row["Type"].ToString() == "bigint")
                                        {
                                            sr.WriteLine("long " + row["ColumnName"].ToString() + " { get; set; }");
                                        }
                                        if (row["Type"].ToString() == "tinyint")
                                        {
                                            sr.WriteLine("sbyte " + row["ColumnName"].ToString() + " { get; set; }");
                                        }
                                    }
                                    sr.WriteLine("}");
                                }
                            }
                        }
                    }
                }
                MessageBox.Show(Constant.EXECUTE_SUCCESS);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex+ex.StackTrace);
            }
        }

        private void btnSelectOutPath_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog diag = new FolderBrowserDialog();
                diag.RootFolder = Environment.SpecialFolder.MyComputer;
                diag.ShowDialog();
                txtOutputPath.Text = diag.SelectedPath;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex + ex.StackTrace);
            }
        }
    }
}