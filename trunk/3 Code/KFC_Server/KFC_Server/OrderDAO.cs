using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace KFC_Server
{
    public class OrderDAO : SQLConnectionDAO
    {
        #region Method

        /* 
        * Description: add new order to database
        * Input: OrderDTO - order object
        * Output: int - number of rows affected
        * Author:
        */
        public void insert(OrderDTO orderDTO)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }

        /* 
        * Description: delete order, commit to database
        * Input: OrderDTO - order object, or orderID
        * Output: int - number of rows affected
        * Author:
        */
        public void delete(OrderDTO orderDTO)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }

        public void delete(string orderID)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }

        /* 
        * Description: update new information of order into database
        * Input: @ oldInfo - order obj with old information (old orderID)
         *       @ newInfo - new information
         *       @ oldOrderID - old orderID
        * Output: int - number of rows affected
        * Author:
        */
        public void update(OrderDTO newInfo)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }

        /* 
         * Description: select list of order, or one order information
         * Input: @orderDTO - order obj, null when you want to select all order
         *          @orderID
         * Output: OrderDTO[] - list of order satisfied the requirement
         * Author:
         */
        public OrderDTO[] selectInfo(OrderDTO info = null)
        {
            string cmd = "";
            if (info == null)
            {
                // select all
                cmd = "";
            }
            else
            {
                // select
                cmd = "";
            }
            connect();
            adapter = new SqlDataAdapter(cmd, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);

            DataTable dt = dataset.Tables[0];
            int i, n = dt.Rows.Count;
            OrderDTO[] arr = new OrderDTO[n];
            for (i = 0; i < n; i++)
            {
                object bill = GetDataFromDataRow(dt, i);
                arr[i] = bill as OrderDTO;
            }
            return arr;
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            OrderDTO order = new OrderDTO();
            return order;
        }


        public OrderDTO[] selectInfo(string orderID)
        {
            return null;
        }
        #endregion
    }        
}
