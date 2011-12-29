using System;
using DTO;
using System.Linq;
using System.Collections.Generic;

namespace ServiceLibrary
{    
    public class OrderDetailDAO
    {
        /* 
        * Description: add new orderDetail to database
        * Input: OrderDetailDTO - orderDetail object
        * Author:
        */
        public bool insert(OrderDetailDTO info )
        {
            bool successful = false;
            try
            {
                var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.Settings.connectionString);
                ORDER_DETAIL orderDetail = new ORDER_DETAIL();
                orderDetail.OrderID = info.OrderID;
                orderDetail.FoodID = info.FoodID;
                orderDetail.Quantity = info.Quantity;
                orderDetail.CompleteTime = info.CompleteTime;
                orderDetail.FoodNote = info.FoodNote;
                orderDetail.Priority = info.Priority;
                db.ORDER_DETAILs.InsertOnSubmit(orderDetail);
                db.SubmitChanges();
                successful = true;
            }
            catch
            {
            	successful = false;
            }
            return successful;
        }

        /* 
        * Description: delete orderDetail, commit to database
        * Input: OrderDetailDTO - orderDetail object, or orderDetailID
        * Output: int - number of rows affected
        * Author:
        */
        public bool delete(OrderDetailDTO info )
        {
            bool successful = false;
            try
            {
                var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.Settings.connectionString);
                var orderDetail = db.ORDER_DETAILs.SingleOrDefault(o => o.OrderID == info.OrderID && o.FoodID == info.FoodID);
                if (orderDetail != null)
                {
                    db.ORDER_DETAILs.DeleteOnSubmit(orderDetail);
                    db.SubmitChanges();
                    successful = true;
                } 
                else
                {
                    successful = false;
                }
            }
            catch 
            {
            	successful = false;
            }
            return successful;
        }


        /* 
        * Description: update new information of orderDetail into database
        * Input: @ oldInfo - orderDetail obj with old information (old orderDetailID)
         *       @ newInfo - new information
         *       @ oldOrderDetailID - old orderDetailID
        * Output: int - number of rows affected
        * Author:
        */
        public bool update(OrderDetailDTO newInfo)
        {
            bool successful = false;
            try
            {
                var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.Settings.connectionString);
                var orderDetail = db.ORDER_DETAILs.SingleOrDefault(o => o.FoodID == newInfo.FoodID && o.OrderID == newInfo.OrderID);
                if (orderDetail != null)
                {
                    orderDetail.Quantity = newInfo.Quantity;
                    orderDetail.CompleteTime = newInfo.CompleteTime;
                    orderDetail.Priority =  newInfo.Priority;
                    orderDetail.FoodNote = newInfo.FoodNote;
                    db.SubmitChanges();
                    successful = true;
                }
            }
            catch
            {
            	successful = false;
            }
            return successful;
        }

        /* 
         * Description: select list of orderDetail, or one orderDetail information
         * Input: @orderDetailDTO - orderDetail obj, null when you want to select all orderDetail
         *          @orderDetailID
         * Output: OrderDetailDTO[] - list of orderDetail satisfied the requirement
         * Author:
         */
        public OrderDetailDTO[] selectInfo(OrderDetailDTO info = null)
        {
            try
            {
                var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.Settings.connectionString);
                if (info == null)
                {
                    var allOrderDetails = db.ORDER_DETAILs;
                    List<OrderDetailDTO> orderDetails = new List<OrderDetailDTO>();
                    foreach (var item in allOrderDetails)
                    {
                        OrderDetailDTO detail = new OrderDetailDTO(item.OrderID, item.FoodID, item.Quantity, item.CompleteTime, item.Priority, item.FoodNote);
                        orderDetails.Add(detail);
                    }
                    return orderDetails.ToArray();
                } 
                else
                {
                    List<OrderDetailDTO> orderDetails = new List<OrderDetailDTO>();
                    var detail = db.ORDER_DETAILs.SingleOrDefault(o => o.FoodID == info.FoodID && o.OrderID == info.OrderID);
                    if (detail != null)
                    {
                        OrderDetailDTO orderDetail = new OrderDetailDTO(detail.OrderID, detail.FoodID, detail.Quantity, detail.CompleteTime, detail.Priority, detail.FoodNote);
                        orderDetails.Add(orderDetail);                        
                    }
                    return orderDetails.ToArray();
                    
                }
            }
            catch
            {
            	return null;
            }
        }

        public OrderDetailDTO[] selectInfo(string orderId, string foodId)
        {
            return this.selectInfo(new OrderDetailDTO(orderId, foodId));
        }
    }
    
}
