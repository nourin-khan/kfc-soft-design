using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashierController
{
    public class OrderDetailCTL
    {
        /* @ convention:
         * _orderStatus: 
         * 0 - deleted
         * 1 - not confirm yet
         * 2 - already confirm
         */
        #region Attributes - private
        private string _orderID;
        private DateTime _orderDate;
        private int _tableNum;
        private int _orderStatus;
        private string _orderNote;
        #endregion

        #region Attributes - public
        #endregion
    }
}
