using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using Renci.SshNet;

namespace MilenialPark.Master
{
    public class DBConnect
    {
        #region properties 

        public MySqlConnection conn = new MySqlConnection();
        public SqlConnection con = new SqlConnection();
        public string connectionstring;
        public string connectionstring2;
        public MySqlServerClass objsqlconnectionNew;
        public MySqlServerIUDClass objSqlServerIUDClassNew;
        public SqlServerClass objsqlconnection;
        public SqlServerIUDClass objSqlServerIUDClass;
        public string DataBase;
        public string Server;

        //string sshHost = "cradlespace.online";
        //string sshUsername = "cradlesp";
        //string sshPassword = "Meraki888@";
        //int sshPort = 64000;

        //string mysqlHost = "localhost"; // MySQL is accessed via the SSH tunnel
        //string mysqlUsername = "cradlesp_desktop";
        //string mysqlPassword = "Meraki888&";
        //string database = "cradlesp_desktop";
        //int mysqlPort = 3306;
        //int localPort = 3307; // Local port for forwarding


        #endregion

        #region function
        /// <summary>
        /// Membuat connection string database
        /// </summary>
        /// <param name="database"></param>
        /// <param name="server"></param>D:\Program\2024\MilenialPark\MilenialPark\Master\DBConnect.cs
        public void setConnectionString(string database, string server)
        {
            //connectionstring2 = @"uid=cradlesp_desktop;Pwd=Meraki888@;Database=" + database + ";Server=" + server;
            connectionstring = @"User ID=sa;Password=Numero1;Database=" + database + ";Server=" + server;
            //connectionstring = @"User ID=sa;Password=Meraki888;Database=" + database + ";Server=" + server;
            //connectionstring = @"User ID=sa;Password=Meraki888;Database=" + database + ";Server=" + server;
            con.ConnectionString = connectionstring;
        }

        /// <summary>
        /// Membuka Koneksi ke database
        /// </summary>
        /// <param name="dBConnection"></param>
        public void OpenConnection()
        {
            try
            {
                con.ConnectionString = connectionstring;
                con.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Menutup Koneksi Database
        /// </summary>
        public void CloseConnection()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor Kosong
        /// </summary>
        public DBConnect() { }

        /// <summary>
        /// Mengisi connection string untuk database dan server melalui constructor
        /// </summary>
        /// <param name="Database"></param>
        /// <param name="Server"></param>
        public DBConnect(string Database, string Server)
        {
            this.DataBase = Database;
            this.Server = Server;
            this.setConnectionString(Database, Server);
            objsqlconnectionNew = new MySqlServerClass(this);
            objSqlServerIUDClassNew = new MySqlServerIUDClass(this);
            objsqlconnection = new SqlServerClass(this);
            objSqlServerIUDClass = new SqlServerIUDClass(this);
            this.conn = new MySqlConnection();
            this.con = new SqlConnection();
        }

        #endregion
    }
}
