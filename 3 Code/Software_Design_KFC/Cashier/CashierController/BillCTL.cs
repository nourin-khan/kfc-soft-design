using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierDTO;

namespace CashierController
{
    /*
     * Description:
     * Input:
     * Output:
     * Author:
     * Note:
     */
    public class BillCTL
    {
        /*
         * Description: add new bill
         * Input: billDTO - bill obj contains information of new bill
         * Output: @true: successfully added
         *          @false: failed
         * Author:
         * Note:
         */
        public bool add(BillDTO billDTO)
        {
            return true;
        }

        /*
         * Description: delete bill
         * Input: billDTO - bill obj, billID - id of deleted bill
         * Output: @true: successfully deleted
         *          @false: failed
         * Author:
         * Note:
         */
        public bool delete(BillDTO billDTO)
        {
            return true;
        }

        public bool delete(string billID)
        {
            return true;
        }

        /* 
       * Description: update new information of bill into database
       * Input: @ oldInfo - bill obj with old information (old billID)
        *       @ newInfo - new information
        *       @ oldBillID - old billID
       * Output: bool - @true: successfully updated
         *              @false: failed
       * Author:
       */
        public bool update(BillDTO oldInfo, BillDTO newInfo)
        {
            return true;
        }

        public bool update(string oldBillID, BillDTO newinfo)
        {
            return true;
        }

        /*
         * Description: view information of bills
         * Input: BillDTO - some information of bill, string - billId
         * Output: list of bill information
         * Author:
         * Note:
         */
        public BillDTO[] viewBillInfo(BillDTO billInfo)
        {
            return null;
        }
        public BillDTO[] viewBillInfo(string billID)
        {
            return null;
        }

        /*
         * Description:print bill for Customer
         * Input: billDTO, billID
         * Output:
         * Author:
         * Note:
         */
        public void printBill(BillDTO billDTO)
        {
            
        }

        public void printBill(string billID)
        {

        }

        /*
         * Description: do when customer pay for bill
         * Input: billDTO, billID
         * Output:
         * Author:
         * Note:
         */
        public void payForBill(BillDTO billDTO)
        {

        }
        public void payForBill(string billID)
        {

        }
    }
}
