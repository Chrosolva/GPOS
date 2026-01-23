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
    /// <summary>
    /// Provides helper methods for establishing and managing connections to both
    /// SQL Server and MySQL databases. Existing SQL Server logic is preserved,
    /// and additional methods handle MySQL connections via MySqlConnector.
    /// </summary>
    public class DBConnect
    {
        #region properties

        // MySQL connection. Use SetMySqlConnectionString to configure.
        public MySqlConnection conn = new MySqlConnection();

        // SQL Server connection. Populated via setConnectionString.
        public SqlConnection con = new SqlConnection();

        // SQL Server connection string.
        public string connectionstring;

        // MySQL connection string.
        public string connectionstring2;

        // Helper classes for MySQL and SQL Server
        public MySqlServerClass objsqlconnectionNew;
        public MySqlServerIUDClass objSqlServerIUDClassNew;
        public SqlServerClass objsqlconnection;
        public SqlServerIUDClass objSqlServerIUDClass;

        // Database and server names used by constructors
        public string DataBase;
        public string Server;

        #endregion

        #region function

        /// <summary>
        /// Creates the SQL Server connection string for the specified database and server.
        /// The MySQL connection string is not modified by this method.
        /// </summary>
        public void setConnectionString(string database, string server)
        {
            // Original MySQL example left in comments for reference.
            //connectionstring2 = @"uid=cradlesp_desktop;Pwd=Meraki888@;Database=" + database + ";Server=" + server;
            connectionstring = @"User ID=sa;Password=Numero1;Database=" + database + ";Server=" + server;
            //connectionstring = @"User ID=sa;Password=Meraki888;Database=" + database + ";Server=" + server;
            con.ConnectionString = connectionstring;
        }

        /// <summary>
        /// Opens the SQL Server connection using the previously configured connection string.
        /// </summary>
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
        /// Closes the SQL Server connection if it is currently open.
        /// </summary>
        public void CloseConnection()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        /// <summary>
        /// Sets the MySQL connection string for this instance without opening the connection.
        /// Call this when you need to read from or write to a MySQL database.
        /// </summary>
        public void SetMySqlConnectionString(string database, string server, string uid, string password, string port)
        {
            connectionstring2 = $"Server={server};Port={port};Database={database};Uid={uid};Pwd={password};";
            conn.ConnectionString = connectionstring2;
        }

        /// <summary>
        /// Opens the MySQL connection using the configured connection string.
        /// This does not affect the SQL Server connection.
        /// </summary>
        public void OpenMySqlConnection()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    // ensure the connection string is assigned before opening
                    conn.ConnectionString = connectionstring2;
                    conn.Open();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Closes the MySQL connection if it is open. Leaves the SQL Server connection untouched.
        /// </summary>
        public void CloseMySqlConnection()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor. Use SetMySqlConnectionString or setConnectionString to configure before use.
        /// </summary>
        public DBConnect() { }

        /// <summary>
        /// Constructs a DBConnect instance and initializes helper classes for both SQL Server and MySQL.
        /// Only the SQL Server connection string is configured by default; call SetMySqlConnectionString
        /// separately to configure MySQL.
        /// </summary>
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

        public DBConnect(string Database, string Server, string dbmysql, string servermysql, string uidmysql, string passmysql)
        {
            this.DataBase = Database;
            this.Server = Server;
            this.setConnectionString(Database, Server);
            this.SetMySqlConnectionString(dbmysql, servermysql, uidmysql, passmysql, "3306");
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
