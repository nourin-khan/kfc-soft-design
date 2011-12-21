using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableDTO
{
    /* @ convention:
     * _orderStatus: 
     * 0 - deleted
     * 1 - not confirm yet
     * 2 - already confirm
    */
    public enum OrderStatus
    {
        DELETED,
        UNCONFIRMED,
        CONFIRMED
    }
    public class OrderDTO
    {
        #region Attributes
        private string _orderID;

        public string OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }
        private DateTime _orderDate;

        public DateTime OrderTime
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }
        private int _tableNum;

        public int TableNum
        {
            get { return _tableNum; }
            set { _tableNum = value; }
        }
        private OrderStatus _orderStatus;

        public OrderStatus OrderStatus
        {
            get { return _orderStatus; }
            set { _orderStatus = value; }
        }
        private string _orderNote;

        public string OrderNote
        {
            get { return _orderNote; }
            set { _orderNote = value; }
        }

        private List<OrderDetailDTO> foodList;

        public List<OrderDetailDTO> FoodList
        {
            get { return foodList; }
            set { foodList = value; }
        }
        #endregion

        public OrderDTO()
        {
            foodList = new List<OrderDetailDTO>();
        }
    }
}
