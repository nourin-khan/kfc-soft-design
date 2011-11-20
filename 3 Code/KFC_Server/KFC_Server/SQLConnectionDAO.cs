using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data;

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
        private string _connectionString;
        #endregion

        #region Method
        /* 
         * Description:connect to sql server
         * Input:
         * Output:
         * Author:
         */
        public static void connect()
        {

        }

        /* 
         * Description:disconnect sql server
         * Input:
         * Output:
         * Author:
         */
        public static void disconnect()
        {

        }
        /* 
         * Description:do SQL non query
         * Input: @sqlCommand - string
         * Output: @ int - number of rows affected
         * Author:
         */
        public static int doSQLNonQuery(string sqlCommand)
        {
            return 0;
        }

        /* 
         * Description:do SQL query
         * Input: @sqlCommand - string
         * Output: @ Datatable: table with rows satisfied the requirement
         * Author:
         */
        public static DataTable doSQLQuery(string sqlCommand)
        {
            return null;
        }
        #endregion
    }
}
