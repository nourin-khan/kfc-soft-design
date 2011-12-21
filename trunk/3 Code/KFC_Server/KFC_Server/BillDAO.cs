using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using DTO;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace KFC_Server
{
    public class BillDAO : SQLConnectionDAO
    {
        /* 
         * Description:
         * Input:
         * Output:
         * Author:
         */
        #region Method

        /* 
        * Description: add new bill to database
        * Input: BillDTO - bill object
        * Output: int - number of rows affected
        * Author:
        */
        public void insert(BillDTO info)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }

        /* 
        * Description: delete bill, commit to database
        * Input: BillDTO - bill object, or billID
        * Output: int - number of rows affected
        * Author:
        */
        public void delete(BillDTO billDTO)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }

        public void delete(string billID)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }

        /* 
        * Description: update new information of bill into database
        * Input: @ oldInfo - bill obj with old information (old billID)
         *       @ newInfo - new information
         *       @ oldBillID - old billID
        * Output: void
        * Author:
        */
        public void update(BillDTO newInfo)
        {
            connect();
            string cmd = "";
            executeNonQuery(cmd);
        }

        /* 
         * Description: select list of bill, or one bill information
         * Input: @billDTO - bill obj, null when you want to select all bill
         *          @billID
         * Output: BillDTO[] - list of bill satisfied the requirement
         * Author:
         */
        public BillDTO[] selectInfo(BillDTO info = null)
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
            BillDTO[] arr = new BillDTO[n];
            for (i = 0; i < n; i++ )
            {
                object bill = GetDataFromDataRow(dt, i);
                arr[i] = bill as BillDTO;
            }
            return arr;
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            BillDTO bill = new BillDTO();
            return bill;
        }

        public BillDTO[] selectInfo(string billID)
        {
            return null;
        }
        #endregion
    }
}
