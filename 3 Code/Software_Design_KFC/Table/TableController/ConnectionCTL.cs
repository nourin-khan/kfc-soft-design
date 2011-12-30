using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TableController.KfcService;
using System.ServiceModel;

namespace TableController
{
    public class ConnectionCTL
    {
        /**
         * get service client from service channel
         */
        public static KfcService.ServiceClient connectWebService()
        {
            System.ServiceModel.EndpointAddress endpoint = 
                new System.ServiceModel.EndpointAddress(string.IsNullOrWhiteSpace(ConfigurationCTL.ServiceAddress) ? @"http://localhost:8090/KFC_Server/ServiceLibrary/Service/" : ConfigurationCTL.ServiceAddress);
            KfcService.ServiceClient wsClient = new KfcService.ServiceClient(new WSHttpBinding(), endpoint);
            return wsClient;
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
