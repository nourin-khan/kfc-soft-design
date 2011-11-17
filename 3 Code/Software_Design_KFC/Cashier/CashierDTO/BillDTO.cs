using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashierDTO
{
    public class BillDTO
    {
        /*@convention:
         * billStatus:
         *0 - deleted
         *1 - chua thanh toan
         *2 - da thanh toan
         */
        #region Attributes - private
        private string _billID;
        private DateTime _billDate;
        private float _total;
        private int _billStatus;
        private string _deleteNode;
        private string _empID;
        private string _orderID;
        #endregion
    }
}
