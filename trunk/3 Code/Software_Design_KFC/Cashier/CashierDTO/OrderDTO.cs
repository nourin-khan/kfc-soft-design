using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashierDTO
{
    /* @ convention:
     * _orderStatus: 
     * 0 - deleted
     * 1 - not confirm yet
     * 2 - already confirm
    */
    public enum OrderStatus
    {
        DELETED = 0,
        UNCONFIRMED = 1,
        COMFIRMED = 2
    }
    public class OrderDTO
    {
        #region Attributes - private
        private string _orderID;
        private DateTime _orderDate;
        private int _tableNum;
        private OrderStatus _orderStatus;
        private string _orderNote;
        #endregion

        #region Attributes - public
        public string orderId
        {
            get { return _orderID; }
            set { _orderID = value; }
        }
        public DateTime orderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }
        public int tableNum
        {
            get { return _tableNum; }
            set { _tableNum = value; }
        }
        public OrderStatus orderStatus
        {
            get { return _orderStatus; }
            set { _orderStatus = value; }
        }
        public string orderNote
        {
            get { return _orderNote; }
            set { _orderNote = value; }
        }
        #endregion
    }
}
