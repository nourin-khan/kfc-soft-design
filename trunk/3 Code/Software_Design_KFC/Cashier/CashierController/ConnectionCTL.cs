using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashierController
{
    public class ConnectionCTL
    {
        /*
         * Description: connect web service
         * Input:
         * Output: @true: connect successfully
         * Author:
         * Note:
         */
        public static bool connectWebService()
        {
            return true;
        }
        /*
         * Description: disconnect web service
         * Input:
         * Output: 
         * Author:
         * Note:
         */
        public static void disconnectWebService()
        {

        }
        /*
         * Description: connect to socket of client (3-client: cashier, table, kitchen)
         * Input: client name (we have default client IP for each client name)
         * Output: @true: connect successfully
         * Author:
         * Note: 
         */
        public static bool connectSocket(string client)
        {
            return true;
        }

        /*
         * Description: disconnect from socket of client (3-client: cashier, table, kitchen)
         * Input: client name (we have default client Ip for each client name)
         * Output: 
         * Author:
         * Note: 
         */
        public static void disconnectSocket(string client)
        {

        }

        /*
         * Description: send message to one of 3 client
         * Input: client name
         * Output: @true: send successfully
         * Author:
         * Note:
         */
        public static bool sendMessage(string client)
        {
            return true;
        }

        /*
        * Description: receive message from one of 3 client
        * Input: client name
        * Output: string: received message
        * Author:
        * Note:
        */
        public static string receiveMessage(string client)
        {
            return null;
        }
    }
}
