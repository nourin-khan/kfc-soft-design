using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

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
    
    [DataContract]
    public class BillDTO
    {
        private string _billID;

        [DataMember]
        public string BillID
        {
            get { return _billID; }
            set { _billID = value; }
        }
        private DateTime _billDate;

        [DataMember]
        public DateTime BillDate
        {
            get { return _billDate; }
            set { _billDate = value; }
        }
        private float _total;

        [DataMember]
        public float Total
        {
            get { return _total; }
            set { _total = value; }
        }

        private int _billStatus;

        [DataMember]
        public int BillStatus
        {
            get { return _billStatus; }
            set { _billStatus = value; }
        }
        private string _deleteNode;

        [DataMember]
        public string DeleteNode
        {
            get { return _deleteNode; }
            set { _deleteNode = value; }
        }
        private string _empID;

        [DataMember]
        public string EmpID
        {
            get { return _empID; }
            set { _empID = value; }
        }
        private string _orderID;

        [DataMember]
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
