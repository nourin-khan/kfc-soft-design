using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using DTO;

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
        public int add(BillDTO billDTO)
        {
            return 0;
        }

        /* 
        * Description: delete bill, commit to database
        * Input: BillDTO - bill object, or billID
        * Output: int - number of rows affected
        * Author:
        */
        public int delete(BillDTO billDTO)
        {
            return 0;
        }

        public int delete(string billID)
        {
            return 0;
        }

        /* 
        * Description: update new information of bill into database
        * Input: @ oldInfo - bill obj with old information (old billID)
         *       @ newInfo - new information
         *       @ oldBillID - old billID
        * Output: int - number of rows affected
        * Author:
        */
        public int update(BillDTO oldInfo, BillDTO newInfo)
        {
            return 0;
        }
        public int update(string oldBillID, BillDTO newInfo)
        {
            return 0;
        }

        /* 
         * Description: select list of bill, or one bill information
         * Input: @billDTO - bill obj, null when you want to select all bill
         *          @billID
         * Output: BillDTO[] - list of bill satisfied the requirement
         * Author:
         */
        public BillDTO[] selectInfo(BillDTO billDTO = null)
        {
            return null;
        }

        public BillDTO[] selectInfo(string billID)
        {
            return null;
        }
        #endregion
    }
}
