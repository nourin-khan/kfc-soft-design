using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace DTO
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
        COMFIRMED = 2
    }
    [DataContract]
    public class OrderDTO
    {
        private string _orderID;

        [DataMember]
        public string OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }
        private DateTime _orderDate;

        [DataMember]
        public DateTime OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }
        private int _tableNum;

        [DataMember]
        public int TableNum
        {
            get { return _tableNum; }
            set { _tableNum = value; }
        }
        private int _orderStatus;

        [DataMember]
        public int OrderStatus
        {
            get { return _orderStatus; }
            set { _orderStatus = value; }
        }
        private string _orderNote;

        [DataMember]
        public string OrderNote
        {
            get { return _orderNote; }
            set { _orderNote = value; }
        }

        public OrderDTO(string orderID)
        {
            this.OrderID = orderID;
        }

        public OrderDTO(string id, DateTime? date, int? tableNum, int? status, string note)
        {
            this.OrderID = id;
            this.OrderDate = DateTime.Parse(date.ToString());
            this.TableNum = int.Parse(tableNum.ToString());
            this.OrderStatus = int.Parse(status.ToString());
            this.OrderNote = note;
        }
    }
}
