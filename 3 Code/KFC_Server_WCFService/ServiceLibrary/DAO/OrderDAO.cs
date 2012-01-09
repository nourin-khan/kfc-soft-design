using System;
using DTO;
using System.Linq;
using System.Collections.Generic;
using System.Data;


namespace ServiceLibrary
{
    public class OrderDAO 
    {
        /* 
        * Description: add new order to database
        * Input: OrderDTO - order object
        * Output: int - number of rows affected
        * Author:
        */
        public bool insert(OrderDTO info)
        {
            bool successfull = false;
            try
            {
                var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.ConnectionSettings.ConnectionString);
                ORDER_ order = new ORDER_();
                order.OrderID = info.OrderID;
                order.OrderDate = info.OrderDate;
                order.TableNum = info.TableNum;
                order.OrderStatus = info.OrderStatus;
                order.OrderNote = info.OrderNote;
                db.ORDER_s.InsertOnSubmit(order);
                db.SubmitChanges();
                successfull = true;
            }
            catch
            {
            	successfull = false;
            }
            return successfull;
        }

        /* 
        * Description: delete order, commit to database
        * Input: OrderDTO - order object, or orderID
        * Output: int - number of rows affected
        * Author:
        */
        public bool delete(OrderDTO info)
        {
            bool successfull = false;
            try
            {
                var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.ConnectionSettings.ConnectionString);
                var order = db.ORDER_s.SingleOrDefault(o => o.OrderID == info.OrderID);
                db.ORDER_s.DeleteOnSubmit(order);
                db.SubmitChanges();
                successfull = true;
            }
            catch
            {
            	successfull = false;
            }
            return successfull;
        }

        public bool delete(string orderID)
        {
           return this.delete(new OrderDTO(orderID));
        }

        /* 
        * Description: update new information of order into database
        * Input: @ oldInfo - order obj with old information (old orderID)
         *       @ newInfo - new information
         *       @ oldOrderID - old orderID
        * Author:
        */
        public bool update(OrderDTO newInfo)
        {
            bool successfull = false;
            try
            {
                var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.ConnectionSettings.ConnectionString);
                var order = db.ORDER_s.SingleOrDefault(o => o.OrderID == newInfo.OrderID);
                if (order != null)
                {
                    order.OrderDate = newInfo.OrderDate;
                    order.TableNum = newInfo.TableNum;
                    order.OrderStatus = newInfo.OrderStatus;
                    order.OrderNote = newInfo.OrderNote;
                    db.SubmitChanges();
                    successfull = true;
                } 
                else
                {
                    successfull = false;
                }
            }
            catch
            {
                successfull = false;            	
            }
            return successfull;
        }

        /* 
         * Description: select list of order, or one order information
         * Input: @orderDTO - order obj, null when you want to select all order
         *          @orderID
         * Output: OrderDTO[] - list of order satisfied the requirement
         * Author:
         */
        public OrderDTO[] selectInfo(OrderDTO info = null)
        {
            try
            {
                var db = new KFCDatabaseClassesDataContext(ServiceLibrary.Properties.ConnectionSettings.ConnectionString);
                if (info == null)
                {
                
                    var allOrders = db.ORDER_s;
                    List<OrderDTO> orders = new List<OrderDTO>();
                    foreach(var o in allOrders)
                    {
                        OrderDTO order = new OrderDTO(o.OrderID, o.OrderDate, o.TableNum, o.OrderStatus, o.OrderNote);
                        orders.Add(order);
                    }
                    return orders.ToArray();
                } 
                else
                {
                    var order = db.ORDER_s.SingleOrDefault(o => o.OrderID == info.OrderID);
                    if (order == null)
                    {
                        return null;
                    } 
                    else
                    {
                        List<OrderDTO> orders = new List<OrderDTO>();
                        OrderDTO o = new OrderDTO(order.OrderID, order.OrderDate, order.TableNum, order.OrderStatus, order.OrderNote);
                        orders.Add(o);
                        return orders.ToArray();
                    }
                }
            }
            catch
            {
            	return null;
            }
        }

        public OrderDTO[] selectInfo(string orderID)
        {
            return this.selectInfo(new OrderDTO(orderID));
        }

        /*
        * Description: view food list of Order
        * Input: orderId
        * Output: list of food detail of the order
        * query: select ord.foodId, food.foodName as N'Tên món ăn', ord.quantity as N'Số lượng', food.foodPrice as N'Giá gốc', food.discountPrice as N'Giảm'
                  from ORDER_DETAIL ord JOIN  FOOD food ON (ord.FoodID = food.FoodID)
                    where ord.OrderID = '56929' <- input
        * Author:
        * Note:
        */
        public OrderFoodDTO[] viewFoodDetail(string orderID)
        {
            SQLConnection db = new SQLConnection();
            try
            {
                DataTable data = db.ThucThiCauTruyVan_TraVeBang("select ord.foodId, food.foodName as N'Tên món ăn', ord.quantity as N'Số lượng', food.foodPrice as N'Giá gốc', food.discountPrice as N'Giảm' " +
                                                      " from ORDER_DETAIL ord JOIN  FOOD food ON (ord.FoodID = food.FoodID) " +
                                                      " where ord.OrderID = '" + orderID + "' ");
                if (!(data == null || data.Rows.Count == 0))
                {
                    OrderFoodDTO[] foodList = new OrderFoodDTO[data.Rows.Count];
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        foodList[i] = new OrderFoodDTO();
                        foodList[i].FoodID = data.Rows[i]["foodId"].ToString();
                        foodList[i].FoodName = data.Rows[i]["Tên món ăn"].ToString();
                        foodList[i].quantity = int.Parse(data.Rows[i]["Số lượng"].ToString());
                        foodList[i].FoodPrice = int.Parse(data.Rows[i]["Giá gốc"].ToString());
                        foodList[i].DiscountPrice = int.Parse(data.Rows[i]["Giảm"].ToString());
                    }
                    return foodList;
                }
                else
                    return null;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /*
         * Description: view information of order
         * Input: table number
         * Output: OrderDTO - orderstatus, orderdate, orderID
         * query: SELECT OrderID, OrderDate, OrderStatus, TableNum
                    FROM ORDER_ ord
                    WHERE TableNum = 101 AND ord.OrderID NOT IN (SELECT OrderID FROM dbo.BILL)
         * Author:
         * Note:
         */
        public DTO.OrderDTO viewOrderInfo(int tableNum)
        {
            SQLConnection db = new SQLConnection();
            try
            {
                DataTable data = db.ThucThiCauTruyVan_TraVeBang(" SELECT OrderID, OrderDate, OrderStatus, TableNum " + 
                                                                " FROM ORDER_ ord " + 
                                                                " WHERE TableNum = " + tableNum.ToString() + " AND ord.OrderID NOT IN (SELECT OrderID FROM dbo.BILL) ");
                if (data == null || data.Rows.Count == 0)
                    return null;
                else
                {
                    OrderDTO order = new OrderDTO("");
                    order.OrderID = data.Rows[0]["OrderID"].ToString();
                    order.OrderDate = DateTime.Parse(data.Rows[0]["OrderDate"].ToString());
                    order.OrderStatus = int.Parse(data.Rows[0]["OrderStatus"].ToString());
                    order.TableNum = int.Parse(data.Rows[0]["TableNum"].ToString());
                    return order;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /*
         * Description: get unfree table on a specified floor
         * Input: floor number
         * Output: OrderDTO - orderId, tablenum
         * query: SELECT TableNum, OrderID
                    FROM ORDER_
                    WHERE OrderID NOT IN (SELECT OrderID FROM BILL)
         * Author:
         * Note:
         */
        public DTO.OrderDTO[] getUnfreeTable(int floorNum)
        {
            SQLConnection db = new SQLConnection();
            try
            {
                DataTable data = db.ThucThiCauTruyVan_TraVeBang(" SELECT TableNum, OrderID " + 
                                                                " FROM ORDER_ " + 
                                                                " WHERE OrderID NOT IN (SELECT OrderID FROM BILL) AND TableNum> " + (floorNum*100).ToString() + 
                                                                " AND TableNum < " + ((floorNum + 1)*100).ToString() );
                if (data == null || data.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    OrderDTO[] orderList = new OrderDTO[data.Rows.Count];
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        orderList[i] = new OrderDTO("");
                        orderList[i].TableNum = int.Parse(data.Rows[i]["TableNum"].ToString());
                        orderList[i].OrderID = data.Rows[i]["OrderID"].ToString();
                    }
                    return orderList;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }        
}
