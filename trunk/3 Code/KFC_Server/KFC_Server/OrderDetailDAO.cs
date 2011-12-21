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
    public class OrderDetailDAO : SQLConnectionDAO
    {
        #region Method

        /* 
        * Description: add new orderDetail to database
        * Input: OrderDetailDTO - orderDetail object
        * Output: int - number of rows affected
        * Author:
        */
        public void insert(OrderDetailDTO orderDetailDTO)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }

        /* 
        * Description: delete orderDetail, commit to database
        * Input: OrderDetailDTO - orderDetail object, or orderDetailID
        * Output: int - number of rows affected
        * Author:
        */
        public void delete(OrderDetailDTO orderDetailDTO)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }

        public void delete(string orderDetailID)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }

        /* 
        * Description: update new information of orderDetail into database
        * Input: @ oldInfo - orderDetail obj with old information (old orderDetailID)
         *       @ newInfo - new information
         *       @ oldOrderDetailID - old orderDetailID
        * Output: int - number of rows affected
        * Author:
        */
        public void update(OrderDetailDTO newInfo)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }

        /* 
         * Description: select list of orderDetail, or one orderDetail information
         * Input: @orderDetailDTO - orderDetail obj, null when you want to select all orderDetail
         *          @orderDetailID
         * Output: OrderDetailDTO[] - list of orderDetail satisfied the requirement
         * Author:
         */
        public OrderDetailDTO[] selectInfo(OrderDetailDTO info = null)
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
            OrderDetailDTO[] arr = new OrderDetailDTO[n];
            for (i = 0; i < n; i++)
            {
                object bill = GetDataFromDataRow(dt, i);
                arr[i] = bill as OrderDetailDTO;
            }
            return arr;
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            OrderDetailDTO orderDetail = new OrderDetailDTO();
            return orderDetail;
        }


        public OrderDetailDTO[] selectInfo(string orderDetailID)
        {
            return null;
        }
        #endregion
    }
    
}
