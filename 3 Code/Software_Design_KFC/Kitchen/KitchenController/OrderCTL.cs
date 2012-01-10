using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KitchenController.KfcService;

namespace KitchenController
{
    public class OrderCTL
    {
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

        /*
         * Description: set time for overall order
         * Input: 
         * Output: @true: set time successfully
         * Author:
         * Note: add input when coding
         */
        public bool setTimeForOrder()
        {
            return true;
        }

        public OrderDTO[] getOrderByStatus(string status)
        {
            try
            {
                ServiceClient wsClient = ConnectionCTL.connectWebService();
                return wsClient.getOrderByStatus(status);
            }
            catch (System.Exception ex)
            {
                throw ex;	
            }
        }
    }
}
