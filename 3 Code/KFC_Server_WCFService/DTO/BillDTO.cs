using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    /*@convention:
        billStatus:
    */
    enum BillStatus
    {
        DELETED,
        UNPAID,
        PAID
    }
    public class BillDTO
    {
        private string _billID;

        public string BillID
        {
            get { return _billID; }
            set { _billID = value; }
        }
        private DateTime _billDate;

        public DateTime BillDate
        {
            get { return _billDate; }
            set { _billDate = value; }
        }
        private float _total;

        public float Total
        {
            get { return _total; }
            set { _total = value; }
        }
        private int _billStatus;

        public int BillStatus
        {
            get { return _billStatus; }
            set { _billStatus = value; }
        }
        private string _deleteNode;

        public string DeleteNode
        {
            get { return _deleteNode; }
            set { _deleteNode = value; }
        }
        private string _empID;

        public string EmpID
        {
            get { return _empID; }
            set { _empID = value; }
        }
        private string _orderID;

        public string OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }

        public BillDTO(string billID)
        {
            // TODO: Complete member initialization
            this.BillID = billID;
        }

        public BillDTO()
        {
            // TODO: Complete member initialization
        }
    }
}
