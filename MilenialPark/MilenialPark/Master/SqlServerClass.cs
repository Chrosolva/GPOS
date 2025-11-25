using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace MilenialPark.Master
{
    public class SqlServerClass
    {
        #region properties

        private DBConnect objConnection;
        private SqlDataAdapter da;
        private DataTable dt;
        public DataSet ds;
        public DataColumn[] dc = new DataColumn[1];
        public DataColumn[] dc2pk = new DataColumn[2];
        public SqlCommand cmd;  // public karena bisa menggunakan parameter
        public DataRow dr;
        public SqlCommandBuilder cb;
        public string[] cari = new string[2];

        #endregion

        #region function

        //get Data
        /// <summary>
        /// Menjalankan Select query dan mengisi data yang didapat dari tabel ke datatable
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable Filldatatable(string query)
        {
            try
            {
                this.objConnection.OpenConnection();
                da = new SqlDataAdapter(query, this.objConnection.con);
                dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.objConnection.CloseConnection();
            }
        }

        /// <summary>
        /// Menjalankan perintah select untuk mengambil data di kolom pertama baris pertama , hanya mengembalikan 1 nilai (TOP 1)
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public string ExecuteScalar(string query)
        {
            try
            {
                this.objConnection.OpenConnection();
                cmd = new SqlCommand(query, this.objConnection.con);
                object scalar = cmd.ExecuteScalar();
                if (scalar == null)
                    return "";
                else
                    return cmd.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.objConnection.CloseConnection();
            }
        }

        /// <summary>
        /// Menjalankan perintah select untuk mengambil data dan dikembalikan dalam bentuk SqlDatareader
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string query)
        {
            try
            {
                this.objConnection.OpenConnection();
                cmd = new SqlCommand(query, this.objConnection.con);
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// new DBConnection function 

        public DataSet LoadData(string query, string tablename)
        {
            ds = new DataSet();
            this.objConnection.OpenConnection();
            cmd = new SqlCommand(query, this.objConnection.con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, tablename);
            dc[0] = ds.Tables[tablename].Columns[0];
            ds.Tables[tablename].PrimaryKey = dc;
            this.objConnection.CloseConnection();
            return ds;
        }

        public DataSet LoadData2PK(string query, string tablename, int indexpk2)
        {
            ds = new DataSet();
            this.objConnection.OpenConnection();
            cmd = new SqlCommand(query, this.objConnection.con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, tablename);
            dc2pk[0] = ds.Tables[tablename].Columns[0];
            dc2pk[1] = ds.Tables[tablename].Columns[indexpk2];
            ds.Tables[tablename].PrimaryKey = dc2pk;
            this.objConnection.CloseConnection();
            return ds;
        }

        public void setCari(string ID1, string ID2)
        {
            cari[0] = ID1;
            cari[1] = ID2;
        }

        public bool AddData(string query, string tablename, string ID, DataTable data, int primarykeyindex)
        {

            ds = this.LoadData(query, tablename);
            this.objConnection.OpenConnection();
            this.dr = ds.Tables[tablename].Rows.Find(ID);
            if (dr == null)
            {
                dr = ds.Tables[tablename].NewRow();
                for (int i = 0; i < data.Columns.Count; i++)
                {

                    if ((object)data.Rows[0][i] is string)
                    {
                        dr[i] = data.Rows[0][i].ToString();
                    }
                    else if ((object)data.Rows[0][i] is int)
                    {
                        dr[i] = Convert.ToInt32(data.Rows[0][i]);
                    }
                    else if ((object)data.Rows[0][i] is bool)
                    {
                        dr[i] = Convert.ToBoolean(data.Rows[0][i]);
                    }
                    else if ((object)data.Rows[0][i] is decimal)
                    {
                        dr[i] = Convert.ToDecimal(data.Rows[0][i]);
                    }
                    else if ((object)data.Rows[0][i] is DateTime)
                    {
                        dr[i] = Convert.ToDateTime(data.Rows[0][i]);
                    }
                    else if ((object)data.Rows[0][i] is byte[])
                    {
                        dr[i] = ((byte[])data.Rows[0][i]);
                    }
                }
                ds.Tables[tablename].Rows.Add(dr);
                this.Update(tablename);

                this.objConnection.CloseConnection();
                return true;


            }
            else
            {
                this.objConnection.CloseConnection();
                return false;
            }
        }

        public bool AddData2PK(string query, string tablename, string ID1, string ID2, DataTable data, int primarykeyindex, int primarykeyIndex2)
        {

            ds = this.LoadData2PK(query, tablename, primarykeyIndex2);
            this.setCari(ID1, ID2);
            this.objConnection.OpenConnection();
            this.dr = ds.Tables[tablename].Rows.Find(cari);
            if (dr == null)
            {
                dr = ds.Tables[tablename].NewRow();
                for (int i = 0; i < data.Columns.Count; i++)
                {

                    if ((object)data.Rows[0][i] is string)
                    {
                        dr[i] = data.Rows[0][i].ToString();
                    }
                    else if ((object)data.Rows[0][i] is int)
                    {
                        dr[i] = Convert.ToInt32(data.Rows[0][i]);
                    }
                    else if ((object)data.Rows[0][i] is bool)
                    {
                        dr[i] = Convert.ToBoolean(data.Rows[0][i]);
                    }
                    else if ((object)data.Rows[0][i] is decimal)
                    {
                        dr[i] = Convert.ToDecimal(data.Rows[0][i]);
                    }
                    else if ((object)data.Rows[0][i] is DateTime)
                    {
                        dr[i] = Convert.ToDateTime(data.Rows[0][i]);
                    }
                    else if ((object)data.Rows[0][i] is byte[])
                    {
                        dr[i] = ((byte[])data.Rows[0][i]);
                    }
                }
                ds.Tables[tablename].Rows.Add(dr);
                this.Update(tablename);

                this.objConnection.CloseConnection();
                return true;


            }
            else
            {
                this.objConnection.CloseConnection();
                return false;
            }
        }

        public void Update(string tablename)
        {
            cb = new SqlCommandBuilder(this.da);
            da = cb.DataAdapter;
            da.Update(ds.Tables[tablename]);
        }

        public bool UpdateData(string query, string tablename, string ID, DataTable data, int primarykeyindex)
        {
            ds = this.LoadData(query, tablename);
            this.objConnection.OpenConnection();
            this.dr = ds.Tables[tablename].Rows.Find(ID);
            if (dr != null)
            {

                for (int i = 0; i < data.Columns.Count; i++)
                {

                    if (i != primarykeyindex)
                    {
                        if ((object)data.Rows[0][i] is string)
                        {
                            dr[i] = data.Rows[0][i].ToString();
                        }
                        else if ((object)data.Rows[0][i] is int)
                        {
                            dr[i] = Convert.ToInt32(data.Rows[0][i]);
                        }
                        else if ((object)data.Rows[0][i] is bool)
                        {
                            dr[i] = Convert.ToBoolean(data.Rows[0][i]);
                        }
                        else if ((object)data.Rows[0][i] is decimal)
                        {
                            dr[i] = Convert.ToDecimal(data.Rows[0][i]);
                        }
                        else if ((object)data.Rows[0][i] is DateTime)
                        {
                            dr[i] = Convert.ToDateTime(data.Rows[0][i]);
                        }
                        else if ((object)data.Rows[0][i] is byte[])
                        {
                            dr[i] = ((byte[])data.Rows[0][i]);
                        }
                    }
                }
                this.Update(tablename);

                this.objConnection.CloseConnection();
                return true;
            }
            else
            {
                this.objConnection.CloseConnection();
                return false;
            }
        }

        public bool UpdateData2PK(string query, string tablename, string ID1, string ID2, DataTable data, int primarykeyindex, int primaryindex2)
        {
            ds = this.LoadData2PK(query, tablename, primaryindex2);
            this.setCari(ID1, ID2);
            this.objConnection.OpenConnection();
            this.dr = ds.Tables[tablename].Rows.Find(cari);
            if (dr != null)
            {

                for (int i = 0; i < data.Columns.Count; i++)
                {

                    if (i != primarykeyindex)
                    {
                        if ((object)data.Rows[0][i] is string)
                        {
                            dr[i] = data.Rows[0][i].ToString();
                        }
                        else if ((object)data.Rows[0][i] is int)
                        {
                            dr[i] = Convert.ToInt32(data.Rows[0][i]);
                        }
                        else if ((object)data.Rows[0][i] is bool)
                        {
                            dr[i] = Convert.ToBoolean(data.Rows[0][i]);
                        }
                        else if ((object)data.Rows[0][i] is decimal)
                        {
                            dr[i] = Convert.ToDecimal(data.Rows[0][i]);
                        }
                        else if ((object)data.Rows[0][i] is DateTime)
                        {
                            dr[i] = Convert.ToDateTime(data.Rows[0][i]);
                        }
                        else if ((object)data.Rows[0][i] is byte[])
                        {
                            dr[i] = ((byte[])data.Rows[0][i]);
                        }
                    }
                }
                this.Update(tablename);

                this.objConnection.CloseConnection();
                return true;
            }
            else
            {
                this.objConnection.CloseConnection();
                return false;
            }
        }

        public bool DeleteData(string query, string tablename, string ID)
        {
            this.LoadData(query, tablename);
            this.objConnection.OpenConnection();
            dr = ds.Tables[tablename].Rows.Find(ID);
            if (dr != null)
            {
                dr.Delete();
                Update(tablename);
                this.objConnection.CloseConnection();
                return true;
            }
            else
            {
                this.objConnection.CloseConnection();
                return false;
            }
        }

        public bool DeleteData2PK(string query, string tablename, string ID1, string ID2, int indexpk2)
        {
            this.setCari(ID1, ID2);
            this.LoadData2PK(query, tablename, indexpk2);
            this.objConnection.OpenConnection();
            dr = ds.Tables[tablename].Rows.Find(cari);
            if (dr != null)
            {
                dr.Delete();
                Update(tablename);
                this.objConnection.CloseConnection();
                return true;
            }
            else
            {
                this.objConnection.CloseConnection();
                return false;
            }
        }

        public bool FindData2PK(string query, string tablename, string ID1, string ID2, int index2PK)
        {
            this.setCari(ID1, ID2);
            this.LoadData2PK(query, tablename, index2PK);
            this.objConnection.OpenConnection();
            this.dr = ds.Tables[tablename].Rows.Find(cari);
            if (dr != null)
            {
                this.objConnection.CloseConnection();
                return true;
            }
            else
            {
                this.objConnection.CloseConnection();
                return false;
            }
        }

        public bool FindData(string query, string tablename, string ID)
        {
            this.LoadData(query, tablename);
            this.objConnection.OpenConnection();
            this.dr = ds.Tables[tablename].Rows.Find(ID);
            if (dr != null)
            {
                this.objConnection.CloseConnection();
                return true;
            }
            else
            {
                this.objConnection.CloseConnection();
                return false;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor Kosong
        /// </summary>
        public SqlServerClass() { }

        public SqlServerClass(DBConnect ObjConnection)
        {
            objConnection = ObjConnection;
        }

        #endregion
    }

    /// <summary>
    /// Class untuk Modify Data
    /// </summary>
    public class SqlServerIUDClass
    {
        #region properties

        private DBConnect objConnection;
        public SqlCommand cmd;  // public karena bisa menggunakan parameter
        public SqlTransaction transaction;

        #endregion

        #region functions

        //insert/Update/Delete to database 
        /// <summary>
        /// Insert/Update/Delete Data menggunakan query dan transaction
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Int32 ExecuteNonQuery(string query)
        {
            Int32 Hasil;
            try
            {
                this.objConnection.OpenConnection();
                transaction = this.objConnection.con.BeginTransaction("ExecNonQue");
                cmd = new SqlCommand(query, this.objConnection.con);
                cmd.Transaction = transaction;
                Hasil = Convert.ToInt32(cmd.ExecuteNonQuery());

                transaction.Commit();
                return Hasil;
            }
            catch (Exception e)
            {
                transaction.Rollback("ExecNonQue");
                throw e;
            }
            finally
            {
                this.objConnection.CloseConnection();
            }
        }

        /// <summary>
        /// Insert/Update/Delete Data menggunakan query tanpa transaction
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Int32 ExecuteNonQueryWithoutTransaction(string query)
        {
            Int32 Hasil;
            cmd = new SqlCommand(query, this.objConnection.con);
            try
            {
                this.objConnection.OpenConnection();
                Hasil = Convert.ToInt32(cmd.ExecuteNonQuery());
                return Hasil;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.objConnection.CloseConnection();
            }
        }

        public string ImportDataFromExcel(string filepath, string tablename, string sheetname)
        {
            string sheet = "[" + sheetname + "$]";
            string myexceldataquery = "select * from " + sheet;
            try
            {
                string sexcelconnectionstring = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + filepath +
                ";extended properties=Excel 12.0;";
                this.objConnection.OpenConnection();
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                oledbconn.Open();
                OleDbDataReader dr = oledbcmd.ExecuteReader();
                SqlBulkCopy bulkCopy = new SqlBulkCopy(this.objConnection.con);
                bulkCopy.DestinationTableName = tablename;
                while (dr.Read())
                {
                    bulkCopy.WriteToServer(dr);
                }
                dr.Close();
                oledbconn.Close();
                this.objConnection.CloseConnection();
                return "File imported into sql server.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ImportDataFromExcelShopItem(string filepath, string tablename, string sheetname)
        {
            string sheet = "[" + sheetname + "$]";
            string myexceldataquery = "select [ItemID],[ShopID], [ItemName], [Price], [ItemDesc], [ImageFilePath] from " + sheet;
            try
            {
                string sexcelconnectionstring = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + filepath +
                ";extended properties=Excel 12.0;";
                this.objConnection.OpenConnection();
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                oledbcmd.CommandTimeout = 0;
                oledbconn.Open();

                DataSet ds = new DataSet();
                OleDbDataAdapter oda = new OleDbDataAdapter(myexceldataquery, oledbconn);
                oledbconn.Close();
                oda.Fill(ds);
                DataTable Exceldt = ds.Tables[0];

                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["ItemID"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                }
                Exceldt.AcceptChanges();

                //creating object of SqlBulkCopy
                SqlBulkCopy objbulk = new SqlBulkCopy(this.objConnection.con);
                //assigning Destination table name
                objbulk.DestinationTableName = tablename;
                //Mapping Table column
                objbulk.ColumnMappings.Add("[ItemID]", "ItemID");
                objbulk.ColumnMappings.Add("[ShopID]", "ShopID");
                objbulk.ColumnMappings.Add("[ItemName]", "ItemName");
                objbulk.ColumnMappings.Add("[Price]", "Price");
                objbulk.ColumnMappings.Add("[ItemDesc]", "ItemDesc");
                objbulk.ColumnMappings.Add("[ImageFilePath]", "ImageFilePath");
                objbulk.BulkCopyTimeout = 0;

                objbulk.WriteToServer(Exceldt);
                oledbconn.Close();
                this.objConnection.CloseConnection();
                return "File imported into sql server.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor Kosong
        /// </summary>
        public SqlServerIUDClass() { }

        public SqlServerIUDClass(DBConnect ObjConnection)
        {
            this.objConnection = ObjConnection;
        }

        #endregion

    }
}
