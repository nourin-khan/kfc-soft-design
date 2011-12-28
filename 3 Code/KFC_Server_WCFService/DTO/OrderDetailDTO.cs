using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class OrderDetailDTO
    {
        #region Attributes - private
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

        public OrderDetailDTO(string orderId, string foodId, Nullable<int> quantity, Nullable<DateTime> completeTime, Nullable<int> priority, string note)
        {
            this.OrderID = orderId;
            this.FoodID = foodId;
            this.Quantity = quantity.Value;
            this.CompleteTime = completeTime.Value;
            this.Priority = priority.Value;
            this.FoodNote = note;
        }

        public OrderDetailDTO(string orderId, string foodId)
        {
            // TODO: Complete member initialization
            this.OrderID = orderId;
            this.FoodID = foodId;
        }
    }
}
