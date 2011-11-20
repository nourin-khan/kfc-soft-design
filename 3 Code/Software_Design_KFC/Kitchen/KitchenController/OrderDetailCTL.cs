using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KitchenDTO;

namespace KitchenController
{
    public class OrderDetailCTL
    {
        public bool delete(OrderDetailDTO orderDetailDTO)
        {
            return true;
        }

        public bool delete(string orderDetailID)
        {
            return true;
        }

        /* 
       * Description: update new information of orderDetail into database
       * Input: @ oldInfo - orderDetail obj with old information (old orderDetailID)
        *       @ newInfo - new information
        *       @ oldOrderDetailID - old orderDetailID
       * Output: bool - @true: successfully updated
         *              @false: failed
       * Author:
       */
        public bool update(OrderDetailDTO oldInfo, OrderDetailDTO newInfo)
        {
            return true;
        }

        public bool update(string oldOrderDetailID, OrderDetailDTO newinfo)
        {
            return true;
        }

        /*
         * Description: view information of orderDetails
         * Input: OrderDetailDTO - some information of orderDetail, string - orderDetailId
         * Output: list of orderDetail information
         * Author:
         * Note:
         */
        public OrderDetailDTO[] viewOrderDetailInfo(OrderDetailDTO orderDetailInfo)
        {
            return null;
        }
        public OrderDetailDTO[] viewOrderDetailInfo(string orderDetailID)
        {
            return null;
        }

        /*
        * Description: set time for each of food in an order
        * Input:
        * Output: @true: set time successfully
        * Author:
        * Note: add input when coding
        */
        public bool setTimeForFood()
        {
            return true;
        }
    }
}
