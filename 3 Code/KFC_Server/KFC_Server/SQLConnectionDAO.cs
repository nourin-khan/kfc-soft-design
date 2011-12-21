using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.IO;
using System.Data.SqlClient;

namespace KFC_Server
{
        /* 
         * Description:
         * Input:
         * Output:
         * Author:
         */
    public class SQLConnectionDAO
    {
        #region Attributes
        private static string _connectionString;

        public static string ConnectionString
        {
            get { return SQLConnectionDAO._connectionString; }
            set { SQLConnectionDAO._connectionString = value; }
        }
        protected SqlConnection connection;
        protected SqlDataAdapter adapter;
        protected SqlCommand command;
        
        #endregion

        #region Method
        /* 
         * Description:connect to sql server
         * Input:
         * Output:
         * Author:
         */
        public void connect()
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }

        /* 
         * Description:disconnect sql server
         * Input:
         * Output:
         * Author:
         */
        public void disconnect()
        {
            connection.Close();
        }
        /* 
         * Description:do SQL non query
         * Input: @sqlCommand - string
         * Author:
         */
        public void executeNonQuery(string sqlCommand)
        {
            command = new SqlCommand(sqlCommand, connection);
            command.ExecuteNonQuery();
        }

        /* 
         * Description:do SQL query
         * Input: @sqlCommand - string
         * Author:
         */
        public IDataReader executeQuery(string sqlCommand)
        {
            command = new SqlCommand(sqlCommand, connection);
            return command.ExecuteReader();
        }

        /**
         * execute scalar
         */
        public object executeScalar(string sqlCommand)
        {
            command = new SqlCommand(sqlCommand, connection);
            return command.ExecuteScalar();
        }
                
        protected virtual object GetDataFromDataRow(DataTable dt, int i)
        {
            return null;
        }
        #endregion
    }
}
