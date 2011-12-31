using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierController.KFCService;
using System.Data;

namespace CashierController
{
    public class OrderCTL
    {
        /*
         * Description: add new order
         * Input: orderDTO - order obj contains information of new order
         * Output: @true: successfully added
         *          @false: failed
         * Author:
         * Note:
         */
        public bool add(OrderDTO orderDTO)
        {
            return true;
        }

        /*
         * Description: delete order
         * Input: orderDTO - order obj, orderID - id of deleted order
         * Output: @true: successfully deleted
         *          @false: failed
         * Author:
         * Note:
         */
        public bool delete(OrderDTO orderDTO)
        {
            return true;
        }

        public bool delete(string orderID)
        {
            return true;
        }

        /* 
       * Description: update new information of order into database
       * Input: @ oldInfo - order obj with old information (old orderID)
        *       @ newInfo - new information
        *       @ oldOrderID - old orderID
       * Output: bool - @true: successfully updated
         *              @false: failed
       * Author:
       */
        public bool update(OrderDTO oldInfo, OrderDTO newInfo)
        {
            return true;
        }

        public bool update(string oldOrderID, OrderDTO newinfo)
        {
            return true;
        }

        /*
         * Description: view food list of Order
         * Input: orderDTO - order obj, orderID - id of deleted order
         * Output: FoodDTO[] - list of food
         * Author:
         * Note:
         */
        public FoodDTO[] viewFoodList(OrderDTO orderDTO)
        {
            return null;
        }

        public FoodDTO[] viewFoodList(string orderID)
        {
            return null;
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
        public DataTable viewFoodDetail(string orderID)
        {
            return null;
        }
        /*
         * Description: do when customer pay for order
         * Input: orderDTO, orderID
         * Output:
         * Author:
         * Note:
         */
        public void payForOrder(BillDTO billDTO)
        {

        }
        public void payForOrder(string billID)
        {

        }

        /*
         * Description: view information of order
         * Input: orderDTO - some information of order, string - order
         * Output: list of food information
         * Author:
         * Note:
         */
        public OrderDTO[] viewOrderInfo(OrderDTO orderInfo)
        {
            return null;
        }
        public OrderDTO viewOrderInfo(string orderID)
        {
            return null;
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
        public OrderDTO viewOrderInfo(int tableNum)
        {
            return null;
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
        public OrderDTO[] getUnfreeTable(int floorNum)
        {
            return null;
        }
    }
}
