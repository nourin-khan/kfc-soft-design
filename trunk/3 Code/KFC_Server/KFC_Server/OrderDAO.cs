using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using DTO;

namespace KFC_Server
{
    public class OrderDAO
    {
        #region Method

        /* 
        * Description: add new order to database
        * Input: OrderDTO - order object
        * Output: int - number of rows affected
        * Author:
        */
        public int add(OrderDTO orderDTO)
        {
            return 0;
        }

        /* 
        * Description: delete order, commit to database
        * Input: OrderDTO - order object, or orderID
        * Output: int - number of rows affected
        * Author:
        */
        public int delete(OrderDTO orderDTO)
        {
            return 0;
        }

        public int delete(string orderID)
        {
            return 0;
        }

        /* 
        * Description: update new information of order into database
        * Input: @ oldInfo - order obj with old information (old orderID)
         *       @ newInfo - new information
         *       @ oldOrderID - old orderID
        * Output: int - number of rows affected
        * Author:
        */
        public int update(OrderDTO oldInfo, OrderDTO newInfo)
        {
            return 0;
        }
        public int update(string oldOrderID, OrderDTO newInfo)
        {
            return 0;
        }

        /* 
         * Description: select list of order, or one order information
         * Input: @orderDTO - order obj, null when you want to select all order
         *          @orderID
         * Output: OrderDTO[] - list of order satisfied the requirement
         * Author:
         */
        public OrderDTO[] selectInfo(OrderDTO orderDTO = null)
        {
            return null;
        }

        public OrderDTO[] selectInfo(string orderID)
        {
            return null;
        }
        #endregion
    }        
}
