using System;
using System.Web;
using System.ComponentModel;

using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace KFC_Server
{
    public class BillDAO
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
        public void insert()
        {
        }

        /* 
        * Description: delete bill, commit to database
        * Input: BillDTO - bill object, or billID
        * Output: int - number of rows affected
        * Author:
        */
        public void delete()
        {
        }

        public void delete(string billID)
        {
        }

        /* 
        * Description: update new information of bill into database
        * Input: @ oldInfo - bill obj with old information (old billID)
         *       @ newInfo - new information
         *       @ oldBillID - old billID
        * Output: void
        * Author:
        */
        public void update()
        {
        }

        /* 
         * Description: select list of bill, or one bill information
         * Input: @billDTO - bill obj, null when you want to select all bill
         *          @billID
         * Output: BillDTO[] - list of bill satisfied the requirement
         * Author:
         */
        public void selectInfo()
        {
        }

        public void selectInfo(string billID)
        {
        }
        #endregion
    }
}
