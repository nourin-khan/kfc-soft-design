using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableDTO
{
    public class OrderDetailDTO
    {
        #region Attributes
        private string _orderID;

        public string OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }
        private string _foodID;

        public string FoodID
        {
            get { return _foodID; }
            set { _foodID = value; }
        }
        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        private DateTime _completeTime;

        public DateTime CompleteTime
        {
            get { return _completeTime; }
            set { _completeTime = value; }
        }
        private int _priority;

        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        private string _foodNote;

        public string FoodNote
        {
            get { return _foodNote; }
            set { _foodNote = value; }
        }
        #endregion
    }
}
