using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KitchenDTO
{
    /* @ convention:
     * _orderStatus: 
     * 0 - deleted
     * 1 - not confirm yet
     * 2 - already confirm
    */    
    enum OrderStatus
    {
        DELETED = 0,
        UNCONFIRMED = 1,
        CONFIRMED = 2
    }
    public class OrderDTO
    {

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
