using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using DTO;

namespace KFC_Server
{    
    public class OrderDetailDAO
    {
        #region Method

        /* 
        * Description: add new orderDetail to database
        * Input: OrderDetailDTO - orderDetail object
        * Output: int - number of rows affected
        * Author:
        */
        public int add(OrderDetailDTO orderDetailDTO)
        {
            return 0;
        }

        /* 
        * Description: delete orderDetail, commit to database
        * Input: OrderDetailDTO - orderDetail object, or orderDetailID
        * Output: int - number of rows affected
        * Author:
        */
        public int delete(OrderDetailDTO orderDetailDTO)
        {
            return 0;
        }

        public int delete(string orderDetailID)
        {
            return 0;
        }

        /* 
        * Description: update new information of orderDetail into database
        * Input: @ oldInfo - orderDetail obj with old information (old orderDetailID)
         *       @ newInfo - new information
         *       @ oldOrderDetailID - old orderDetailID
        * Output: int - number of rows affected
        * Author:
        */
        public int update(OrderDetailDTO oldInfo, OrderDetailDTO newInfo)
        {
            return 0;
        }
        public int update(string oldOrderDetailID, OrderDetailDTO newInfo)
        {
            return 0;
        }

        /* 
         * Description: select list of orderDetail, or one orderDetail information
         * Input: @orderDetailDTO - orderDetail obj, null when you want to select all orderDetail
         *          @orderDetailID
         * Output: OrderDetailDTO[] - list of orderDetail satisfied the requirement
         * Author:
         */
        public OrderDetailDTO[] selectInfo(OrderDetailDTO orderDetailDTO = null)
        {
            return null;
        }

        public OrderDetailDTO[] selectInfo(string orderDetailID)
        {
            return null;
        }
        #endregion
    }
    
}
