using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashierDTO;

namespace CashierController
{
    public class OrderDetailCTL
    {
        /*
         * Description: add new orderDetail
         * Input: orderDetailDTO - orderDetail obj contains information of new orderDetail
         * Output: @true: successfully added
         *          @false: failed
         * Author:
         * Note:
         */
        public bool add(OrderDetailDTO orderDetailDTO)
        {
            return true;
        }

        /*
         * Description: delete orderDetail
         * Input: orderDetailDTO - orderDetail obj, orderDetailID - id of deleted orderDetail
         * Output: @true: successfully deleted
         *          @false: failed
         * Author:
         * Note:
         */
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
    }
}
