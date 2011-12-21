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
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

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
        public void addFood(FoodDTO foodDTO)
        {
            FoodDAO data = new FoodDAO();
            data.insert(foodDTO);
        }

        [WebMethod]
        public void deleteFood(FoodDTO foodDTO)
        {
            FoodDAO data = new FoodDAO();
            data.delete(foodDTO);
        }

        [WebMethod (MessageName="DeleteFoodByID")]
        public void deleteFood(string foodID)
        {
            FoodDAO data = new FoodDAO();
            data.delete(foodID);
        }

        [WebMethod]
        public void updateFood(FoodDTO newInfo)
        {
            FoodDAO data = new FoodDAO();
            data.update(newInfo);
        }

        [WebMethod]
        public FoodDTO[] selectFoodInfo(FoodDTO foodDTO = null)
        {
            FoodDAO data = new FoodDAO();
            return data.selectInfo(foodDTO);
        }

        [WebMethod(MessageName="SelectFoodByID")]
        public FoodDTO[] selectFoodInfo(string foodID)
        {
            FoodDAO data = new FoodDAO();
            return data.selectInfo(foodID);
        }
        #endregion

        #region FoodGroupDAO
        [WebMethod]
        public void addFoodGroup(FoodGroupDTO foodGroupDTO)
        {
            FoodGroupDAO data = new FoodGroupDAO();
            data.insert(foodGroupDTO);
        }

        [WebMethod]
        public void deleteFoodGroup(FoodGroupDTO foodGroupDTO)
        {
            FoodGroupDAO data = new FoodGroupDAO();
            data.delete(foodGroupDTO);
        }

        [WebMethod(MessageName = "DeleteGroupByID")]
        public void deleteFoodGroup(string foodGroupID)
        {
            FoodGroupDAO data = new FoodGroupDAO();
            data.delete(foodGroupID);
        }

        [WebMethod]
        public void updateFoodGroup(FoodGroupDTO newInfo)
        {
            FoodGroupDAO data = new FoodGroupDAO();
            data.update(newInfo);
        }

        [WebMethod]
        public FoodGroupDTO[] selectFoodGroupInfo(FoodGroupDTO foodGroupDTO = null)
        {
            FoodGroupDAO data = new FoodGroupDAO();
            return data.selectInfo(foodGroupDTO);
        }

        [WebMethod(MessageName = "SelectGroupByID")]
        public FoodGroupDTO[] selectFoodGroupInfo(string foodGroupID)
        {
            FoodGroupDAO data = new FoodGroupDAO();
            return data.selectInfo(foodGroupID);
        }
        #endregion

        #region OrderDAO
        [WebMethod]
        public void addOrder(OrderDTO orderDTO)
        {
            OrderDAO data = new OrderDAO();
            data.insert(orderDTO);
        }

        [WebMethod]
        public void deleteOrder(OrderDTO orderDTO)
        {
            OrderDAO data = new OrderDAO();
            data.delete(orderDTO);
        }

        [WebMethod(MessageName = "DeleteOrderByID")]
        public void deleteOrder(string orderID)
        {
            OrderDAO data = new OrderDAO();
            data.delete(orderID);
        }

        [WebMethod]
        public void updateOrder(OrderDTO newInfo)
        {
            OrderDAO data = new OrderDAO();
            data.update(newInfo);
        }

        [WebMethod]
        public OrderDTO[] selectOrderInfo(OrderDTO orderDTO = null)
        {
            OrderDAO data = new OrderDAO();
            return data.selectInfo(orderDTO);
        }

        [WebMethod(MessageName = "SelectOrderByID")]
        public OrderDTO[] selectOrderInfo(string orderID)
        {
            OrderDAO data = new OrderDAO();
            return data.selectInfo(orderID);
        }
        #endregion

        #region OrderDetailDAO
        [WebMethod]
        public void addOrderDetail(OrderDetailDTO orderDetailDTO)
        {
            OrderDetailDAO data = new OrderDetailDAO();
            data.insert(orderDetailDTO);
        }

        [WebMethod]
        public void deleteOrderDetail(OrderDetailDTO orderDetailDTO)
        {
            OrderDetailDAO data = new OrderDetailDAO();
            data.delete(orderDetailDTO);
        }

        [WebMethod(MessageName = "DeleteOrderDetailByID")]
        public void deleteOrderDetail(string orderDetailID)
        {
            OrderDetailDAO data = new OrderDetailDAO();
            data.delete(orderDetailID);
        }

        [WebMethod]
        public void updateOrderDetail( OrderDetailDTO newInfo)
        {
            OrderDetailDAO data = new OrderDetailDAO();
            data.update(newInfo);
        }

        [WebMethod]
        public OrderDetailDTO[] selectOrderDetailInfo(OrderDetailDTO orderDetailDTO = null)
        {
            OrderDetailDAO data = new OrderDetailDAO();
            return data.selectInfo(orderDetailDTO);
        }

        [WebMethod(MessageName = "SelectOrderDetailByID")]
        public OrderDetailDTO[] selectOrderDetailInfo(string orderDetailID)
        {
            OrderDetailDAO data = new OrderDetailDAO();
            return data.selectInfo(orderDetailID);
        }
        
        #endregion

        #region BillDAO
        [WebMethod]
        public void addBill(BillDTO billDTO)
        {
            BillDAO data = new BillDAO();
            data.insert(billDTO);
        }

        [WebMethod]
        public void deleteBill(BillDTO billDTO)
        {
            BillDAO data = new BillDAO();
            data.delete(billDTO);
        }

        [WebMethod(MessageName = "DeleteBillByID")]
        public void deleteBill(string billID)
        {
            BillDAO data = new BillDAO();
            data.delete(billID);
        }

        [WebMethod]
        public void updateBill( BillDTO newInfo)
        {
            BillDAO data = new BillDAO();
            data.update(newInfo);
        }

        [WebMethod]
        public BillDTO[] selectBillInfo(BillDTO billDTO = null)
        {
            BillDAO data = new BillDAO();
            return data.selectInfo(billDTO);
        }

        [WebMethod(MessageName = "SelectBillByID")]
        public BillDTO[] selectBillInfo(string billID)
        {
            BillDAO data = new BillDAO();
            return data.selectInfo(billID);
        }
        #endregion


    }
}
