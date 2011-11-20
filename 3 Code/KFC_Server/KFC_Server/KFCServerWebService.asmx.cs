using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using DTO;

namespace KFC_Server
{
    /// <summary>
    /// Summary description for KFCServerWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public partial class KFCServerWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        #region FoodDAO
        [WebMethod]
        public int addFood(FoodDTO foodDTO)
        {
            return 0;
        }

        [WebMethod]
        public int deleteFood(FoodDTO foodDTO)
        {
            return 0;
        }

        [WebMethod]
        public int deleteFood(string foodID)
        {
            return 0;
        }

        [WebMethod]
        public int updateFood(FoodDTO oldInfo, FoodDTO newInfo)
        {
            return 0;
        }

        [WebMethod]
        public int updateFood(string oldFoodID, FoodDTO newInfo)
        {
            return 0;
        }

        [WebMethod]
        public FoodDTO[] selectFoodInfo(FoodDTO foodDTO = null)
        {
            return null;
        }

        [WebMethod]
        public FoodDTO[] selectFoodInfo(string foodID)
        {
            return null;
        }
        #endregion

        #region FoodGroupDAO
        [WebMethod]
        public int addFoodGroup(FoodGroupDTO foodGroupDTO)
        {
            return 0;
        }

        [WebMethod]
        public int deleteFoodGroup(FoodGroupDTO foodGroupDTO)
        {
            return 0;
        }

        [WebMethod]
        public int deleteFoodGroup(string foodGroupID)
        {
            return 0;
        }

        [WebMethod]
        public int updateFoodGroup(FoodGroupDTO oldInfo, FoodGroupDTO newInfo)
        {
            return 0;
        }

        [WebMethod]
        public int updateFoodGroup(string oldFoodGroupID, FoodGroupDTO newInfo)
        {
            return 0;
        }

        [WebMethod]
        public FoodGroupDTO[] selectFoodGroupInfo(FoodGroupDTO foodGroupDTO = null)
        {
            return null;
        }

        [WebMethod]
        public FoodGroupDTO[] selectFoodGroupInfo(string foodGroupID)
        {
            return null;
        }
        #endregion

        #region OrderDAO
        [WebMethod]
        public int addOrder(OrderDTO orderDTO)
        {
            return 0;
        }

        [WebMethod]
        public int deleteOrder(OrderDTO orderDTO)
        {
            return 0;
        }

        [WebMethod]
        public int deleteOrder(string orderID)
        {
            return 0;
        }

        [WebMethod]
        public int updateOrder(OrderDTO oldInfo, OrderDTO newInfo)
        {
            return 0;
        }

        [WebMethod]
        public int updateOrder(string oldOrderID, OrderDTO newInfo)
        {
            return 0;
        }

        [WebMethod]
        public OrderDTO[] selectOrderInfo(OrderDTO orderDTO = null)
        {
            return null;
        }

        [WebMethod]
        public OrderDTO[] selectOrderInfo(string orderID)
        {
            return null;
        }
        #endregion

        #region OrderDetailDAO
        [WebMethod]
        public int addOrderDetail(OrderDetailDTO orderDetailDTO)
        {
            return 0;
        }

        [WebMethod]
        public int deleteOrderDetail(OrderDetailDTO orderDetailDTO)
        {
            return 0;
        }

        [WebMethod]
        public int deleteOrderDetail(string orderDetailID)
        {
            return 0;
        }

        [WebMethod]
        public int updateOrderDetail(OrderDetailDTO oldInfo, OrderDetailDTO newInfo)
        {
            return 0;
        }

        [WebMethod]
        public int updateOrderDetail(string oldOrderDetailID, OrderDetailDTO newInfo)
        {
            return 0;
        }

        [WebMethod]
        public OrderDetailDTO[] selectOrderDetailInfo(OrderDetailDTO orderDetailDTO = null)
        {
            return null;
        }

        [WebMethod]
        public OrderDetailDTO[] selectOrderDetailInfo(string orderDetailID)
        {
            return null;
        }
        
        #endregion

        #region BillDAO
        [WebMethod]
        public int addBill(BillDTO billDTO)
        {
            return 0;
        }

        [WebMethod]
        public int deleteBill(BillDTO billDTO)
        {
            return 0;
        }

        [WebMethod]
        public int deleteBill(string billID)
        {
            return 0;
        }

        [WebMethod]
        public int updateBill(BillDTO oldInfo, BillDTO newInfo)
        {
            return 0;
        }

        [WebMethod]
        public int updateBill(string oldBillID, BillDTO newInfo)
        {
            return 0;
        }

        [WebMethod]
        public BillDTO[] selectBillInfo(BillDTO billDTO = null)
        {
            return null;
        }

        [WebMethod]
        public BillDTO[] selectBillInfo(string billID)
        {
            return null;
        }
        #endregion


    }
}
