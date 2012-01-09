using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using DTO;

namespace ServiceLibrary
{
    /**
     * Duplex
     * Callback
     * Service
     */
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service : IService
    {
        //private int answer = 0;
        #region Instance fields
        // thread sync lock object
        private static object syncObj = new object();

        // callback interface for clients
        private IServiceCallback callback = null;

        // delegate used for BoradcasetEvent
        public delegate void KfcEventHandler(object sender, KfcEventArgs e);
        public static event KfcEventHandler KfcEvent;
        private KfcEventHandler eventHanler = null;

        // holds a list of client, and a delegate to allow the BroadcastEvent to work
        // out which client delegate to invoke
        static Dictionary<ClientDTO, KfcEventHandler> clients = new Dictionary<ClientDTO, KfcEventHandler>();
        // current client
        private ClientDTO client;
        #endregion

        #region Helper
        /**
         * searchers the internal list of clients for a particular client, and returns true if the client could be found
         * @param <clientType> the type of client 
         * @return true if client was found in the internal list <clients>
         */
        private bool checkIfClientHasExist(string id)
        {
            foreach (ClientDTO client in clients.Keys)
            {
                if (client.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        /**
         * searchers the internal list of clients for a particular client, 
         * and returns the individual client KfcEventHandler delegate in the order that it can be invoked
         * @param <clientType> the type of client 
         * @return The true KfcEventHandler delegate for the clientType
         */
        private KfcEventHandler getKfcHandler(string id)
        {
            foreach (ClientDTO client in clients.Keys)
            {
                if (client.Id == id )
                {
                    KfcEventHandler handler = null;
                    clients.TryGetValue(client, out handler);
                    return handler;
                }
            }
            return null;
        }

        /**
         * searchers the internal list of clients for a particular client, 
         * and returns the actual client who's client type matches the type input
         * @param <clientType> the type of client 
         * @return Client
         */
        private ClientDTO getClient(ClientType clientType)
        {
            foreach (ClientDTO client in clients.Keys)
            {
                if (client.ClientType == clientType)
                {
                    return client;
                }
            }
            return null;
        }
        #endregion

        /**
         * when newly client join to network, it calls this method to register
         * @param <client> newly client
         * @return list clients after newly client added
         */
        public ClientDTO[] Join(ClientDTO client)
        {
            bool clientAdded = false;
            // create kfc event handler
            eventHanler = new KfcEventHandler(ServiceEventHanlder);

            lock (syncObj)
            {
                if (!checkIfClientHasExist(client.Id) && client != null)
                {
                    this.client = client;
                    clients.Add(client, ServiceEventHanlder);
                    clientAdded = true;
                }
            }

            // if the new client successfully added
            // get callback instance
            if (clientAdded)
            {
                callback = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
                // add this newly joined client KfcEventHanlder delegate,
                // multicast delegate for invocation
                KfcEvent += ServiceEventHanlder;
                ClientDTO[] list = new ClientDTO[clients.Count];
                // carry out a critical section that copy all clients to a new list
                lock (syncObj)
                {
                    clients.Keys.CopyTo(list, 0);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        /**
         * Broadcast message
         * loop through all connected client and invoke their KfcEventHanlder delegate asynchronously
         * @param <e> The KfcEventArgs to use to send to all connected client
         */
        private void BroadCastMessage(KfcEventArgs e)
        {
            KfcEventHandler temp = KfcEvent;
            

            // Loop through all connected clients and invoke their KfcEventHandler delegate asynchronously,
            // which will first call the ServiceEventHandler() method and will allow a asynch callback to call the EndAsync() method on completion of the initial call
            if (temp != null)
            {
                foreach (KfcEventHandler handler in temp.GetInvocationList())
                {
                    handler.BeginInvoke(this, e, new AsyncCallback(EndAsync), null);
                }
            }

        }

        /**
         * EndAsync
         * is called as a callback from the asynchronous call, so simply get the delegate
         * and do an EndInvoke on it, to signal the asynchronous call is now completed
         * @param <ar> The asynch result
         */
        private void EndAsync(IAsyncResult ar)
        {
            KfcEventHandler handler = null;
            try
            {
                // get the standard System.Runtime.Remoting.Messaging.AsyncResult, 
                // and  then cast it to the correct delegate type, and do an end invoke
                System.Runtime.Remoting.Messaging.AsyncResult asres = (System.Runtime.Remoting.Messaging.AsyncResult)ar;
                handler = (KfcEventHandler)asres.AsyncDelegate;
                handler.EndInvoke(ar);
            }
            catch
            {
                KfcEvent -= handler;
            }
        }

        private void ServiceEventHanlder(object sender, KfcEventArgs e)
        {

        }


        public bool connect(ClientDTO client)
        {
            try
            {
                Join(client);
                return true;
            }
            catch
            {
                return false;
            }
        }


        #region Food
        public bool addFood(DTO.FoodDTO foodDTO)
        {
            FoodDAO data = new FoodDAO();
            return data.insert(foodDTO);
        }

        public bool deleteFood(DTO.FoodDTO foodDTO)
        {
            FoodDAO data = new FoodDAO();
            return data.delete(foodDTO);
        }

        public bool deleteFood(string foodID)
        {
            FoodDAO data = new FoodDAO();
            return data.delete(foodID);
        }

        public bool updateFood(DTO.FoodDTO newInfo)
        {
            FoodDAO data = new FoodDAO();
            return data.update(newInfo);
        }

        public DTO.FoodDTO[] selectFoodInfo(DTO.FoodDTO foodDTO = null)
        {
            FoodDAO data = new FoodDAO();
            return data.selectInfo(foodDTO);
        }

        public DTO.FoodDTO[] selectFoodInfo(string foodID)
        {
            FoodDAO data = new FoodDAO();
            return data.selectInfo(foodID);
        }
        
        #endregion

        #region Food Group
        public bool addFoodGroup(DTO.FoodGroupDTO foodGroupDTO)
        {
            FoodGroupDAO data = new FoodGroupDAO();
            return data.insert(foodGroupDTO);
        }

        public bool deleteFoodGroup(DTO.FoodGroupDTO foodGroupDTO)
        {
            FoodGroupDAO data = new FoodGroupDAO();
            return data.delete(foodGroupDTO);
        }

        public bool deleteFoodGroup(string foodGroupID)
        {
            FoodGroupDAO data = new FoodGroupDAO();
            return data.delete(foodGroupID);
        }

        public bool updateFoodGroup(DTO.FoodGroupDTO newInfo)
        {
            FoodGroupDAO data = new FoodGroupDAO();
            return data.update(newInfo);
        }

        public DTO.FoodGroupDTO[] selectFoodGroupInfo(DTO.FoodGroupDTO foodGroupDTO = null)
        {
            FoodGroupDAO data = new FoodGroupDAO();
            return data.selectInfo(foodGroupDTO);
        }

        public DTO.FoodGroupDTO[] selectFoodGroupInfo(string foodGroupID)
        {
            FoodGroupDAO data = new FoodGroupDAO();
            return data.selectInfo(foodGroupID);
        }
        
        #endregion

        #region Order
        public bool addOrder(DTO.OrderDTO orderDTO)
        {
            OrderDAO data = new OrderDAO();
            return data.insert(orderDTO);
        }

        public bool deleteOrder(DTO.OrderDTO orderDTO)
        {
            OrderDAO data = new OrderDAO();
            return data.delete(orderDTO);
        }

        public bool deleteOrder(string orderID)
        {
            OrderDAO data = new OrderDAO();
            return data.delete(orderID);
        }

        public bool updateOrder(DTO.OrderDTO newInfo)
        {
            OrderDAO data = new OrderDAO();
            return data.update(newInfo);
        }

        public DTO.OrderDTO[] selectOrderInfo(DTO.OrderDTO orderDTO = null)
        {
            OrderDAO data = new OrderDAO();
            return data.selectInfo(orderDTO);
        }

        public DTO.OrderDTO[] selectOrderInfo(string orderID)
        {
            OrderDAO data = new OrderDAO();
            return data.selectInfo(orderID);
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
            OrderDAO data = new OrderDAO();
            return data.viewFoodDetail(orderID);
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
            OrderDAO data = new OrderDAO();
            return data.viewOrderInfo(tableNum);
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
            OrderDAO data = new OrderDAO();
            return data.getUnfreeTable(floorNum);
        }
        
        #endregion

        #region Order Detail
        public bool addOrderDetail(DTO.OrderDetailDTO orderDetailDTO)
        {
            OrderDetailDAO data = new OrderDetailDAO();
            return data.insert(orderDetailDTO);
        }

        public bool deleteOrderDetail(DTO.OrderDetailDTO orderDetailDTO)
        {
            OrderDetailDAO data = new OrderDetailDAO();
            return data.delete(orderDetailDTO);
        }

        public bool deleteOrderDetail(string orderDetailID)
        {
            // not install yet
            throw new NotImplementedException();
        }

        public bool updateOrderDetail(DTO.OrderDetailDTO newInfo)
        {
            OrderDetailDAO data = new OrderDetailDAO();
            return data.update(newInfo);
        }

        public DTO.OrderDetailDTO[] selectOrderDetailInfo(DTO.OrderDetailDTO orderDetailDTO = null)
        {
            OrderDetailDAO data = new OrderDetailDAO();
            return data.selectInfo(orderDetailDTO);
        }

        public DTO.OrderDetailDTO[] selectOrderDetailInfo(string orderId, string foodId)
        {
            OrderDetailDAO data = new OrderDetailDAO();
            return data.selectInfo(orderId, foodId);
        }
        
        #endregion

        #region Bill
        public bool addBill(DTO.BillDTO billDTO)
        {
            BillDAO data = new BillDAO();
            return data.insert(billDTO);
        }

        public bool deleteBill(DTO.BillDTO billDTO)
        {
            BillDAO data = new BillDAO();
            return data.delete(billDTO);
        }

        public bool deleteBill(string billID)
        {
            BillDAO data = new BillDAO();
            return data.delete(billID);
        }

        public bool updateBill(DTO.BillDTO newInfo)
        {
            BillDAO data = new BillDAO();
            return data.update(newInfo);
        }

        public DTO.BillDTO[] selectBillInfo(DTO.BillDTO billDTO = null)
        {
            BillDAO data = new BillDAO();
            return data.selectInfo(billDTO);
        }

        public DTO.BillDTO[] selectBillInfo(string billID)
        {
            BillDAO data = new BillDAO();
            return data.selectInfo(billID);
        }
        
        #endregion

        #region Employee and Permission
        public string getEmployeeName(string empID)
        {
            EmployeeDAO data = new EmployeeDAO();
            return data.getEmployeeName(empID);
        }


        //new function
        public string[] getEmpIdAndPermission(string username, string password)
        {
            EmployeeDAO data = new EmployeeDAO();
            return data.getEmpIdAndPermission(username, password);
        }

        public string getPermission(string empId)
        {
            EmployeeDAO data = new EmployeeDAO();
            return data.getPermission(empId);
        }
        
        #endregion

        #region Report
        public int getTotalOfDay(DateTime billDate)
        {
            ReportDAO data = new ReportDAO();
            return data.getTotalOfDay(billDate);
        }

        public DTO.DailyReportDTO[] getDailyReport(DateTime billDate)
        {
            ReportDAO data = new ReportDAO();
            return data.getDailyReport(billDate);
        }

        public int getTotalOfMonth(DateTime billDate)
        {
            ReportDAO data = new ReportDAO();
            return data.getTotalOfMonth(billDate);
        }

        public DTO.MonthlyReportDTO[] getMonthlyReport(DateTime billDate)
        {
            ReportDAO data = new ReportDAO();
            return data.getMonthlyReport(billDate);
        }

        public int getTotalOfYear(DateTime billDate)
        {
            ReportDAO data = new ReportDAO();
            return data.getTotalOfYear(billDate);

        }

        public DTO.YearlyReportDTO[] getYearlyReport(DateTime billDate)
        {
            ReportDAO data = new ReportDAO();
            return data.getYearlyReport(billDate);
        }
        #endregion
    }
}
