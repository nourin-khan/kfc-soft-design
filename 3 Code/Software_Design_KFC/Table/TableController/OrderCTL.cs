using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TableController.KfcService;


namespace TableController
{
    /* @ convention:
         * _orderStatus: 
         * 0 - deleted
         * 1 - not confirm yet
         * 2 - already confirm
        */

    public class OrderStatus
    {
        public static readonly int DELETED = 0;
        public static readonly int UNCONFIRMED = 1;
        public static readonly int COMFIRMED = 2;
    }

    public class OrderCTL
    {
        /*
        * Description: add new order
        * Input: orderDTO - order obj contains information of new order
        * Output: @true: successfully added
        *          @false: failed
        * Author: vantuanlee@gmail.com
        * Note:
        */
        public bool add(OrderDTO orderDTO)
        {
            ServiceClient wsClient = ConnectionCTL.connectWebService();
            try
            {
                if (orderDTO != null) // get all food
                {
                    wsClient.addOrder(orderDTO);
                    return true;
                }
                else
                {
                    throw new Exception("Order DTO must be not null");
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
                return false;
            }
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
         * Description: do when customer pay for order
         * Input: orderDTO, orderID
         * Output:
         * Author:
         * Note:
         */
        public void payForOrder(OrderDTO orderDTO)
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
        public OrderDTO[] viewOrderInfo(string orderID)
        {
            return null;
        }

        public void add(OrderDTO orderInfo, System.Collections.ArrayList orderDetail)
        {
            try
            {
                ServiceClient wsClient = ConnectionCTL.connectWebService();
                //wsClient.addOrder(orderInfo);
                //foreach (OrderDetailDTO detail in orderDetail)
                //{
                //    wsClient.addOrderDetail(detail);
                //}

                // 
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
