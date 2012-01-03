﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DTO;

namespace ServiceLibrary
{
    // inter face duplex callback service
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IServiceCallback))]
    public interface IService
    {
        #region FoodDAO
        [OperationContract]
        bool addFood(FoodDTO foodDTO);

        [OperationContract(Name="DeleteFoodByDTO")]
        bool deleteFood(FoodDTO foodDTO);

        [OperationContract(Name = "DeleteFoodByID")]
        bool deleteFood(string foodID);

        [OperationContract]
        bool updateFood(FoodDTO newInfo);

        [OperationContract(Name = "SelectFoodByDTO")]
        FoodDTO[] selectFoodInfo(FoodDTO foodDTO = null);

        [OperationContract(Name = "SelectFoodById")]
        FoodDTO[] selectFoodInfo(string foodID);
        #endregion

        #region FoodGroupDAO
        [OperationContract]
        bool addFoodGroup(FoodGroupDTO foodGroupDTO);

        [OperationContract(Name = "DeleteFoodGroupByDTO")]
        bool deleteFoodGroup(FoodGroupDTO foodGroupDTO);

        [OperationContract(Name = "DeleteFoodGroupById")]
        bool deleteFoodGroup(string foodGroupID);

        [OperationContract]
        bool updateFoodGroup(FoodGroupDTO newInfo);

        [OperationContract(Name = "SelectFoodGroupByDTO")]
        FoodGroupDTO[] selectFoodGroupInfo(FoodGroupDTO foodGroupDTO = null);

        [OperationContract(Name = "SelectFoodGroupById")]
        FoodGroupDTO[] selectFoodGroupInfo(string foodGroupID);
        #endregion

        #region OrderDAO
        [OperationContract]
        bool addOrder(OrderDTO orderDTO);

        [OperationContract(Name = "DeleteOrderByDTO")]
        bool deleteOrder(OrderDTO orderDTO);

        [OperationContract(Name="DeleteOrderById")]
        bool deleteOrder(string orderID);

        [OperationContract]
        bool updateOrder(OrderDTO newInfo);

        [OperationContract(Name="SelectOrderByDTO")]
        OrderDTO[] selectOrderInfo(OrderDTO orderDTO = null);

        [OperationContract(Name="SelectOrderById")]
        OrderDTO[] selectOrderInfo(string orderID);
        #endregion

        #region OrderDetailDAO
        [OperationContract]
        bool addOrderDetail(OrderDetailDTO orderDetailDTO);

        [OperationContract(Name="DeleteOrderDetailByDTO")]
        bool deleteOrderDetail(OrderDetailDTO orderDetailDTO);

        [OperationContract(Name="DeleteOrderDetailById")]
        bool deleteOrderDetail(string orderDetailID);

        [OperationContract(Name="UpdateOrderDetailByDTO")]
        bool updateOrderDetail(OrderDetailDTO newInfo);

        [OperationContract(Name="SelectOrderDetailByDTO")]
        OrderDetailDTO[] selectOrderDetailInfo(OrderDetailDTO orderDetailDTO = null);

        [OperationContract(Name="SelectOrderDetailById")]
        OrderDetailDTO[] selectOrderDetailInfo(string orderId, string foodId);

        #endregion

        #region BillDAO
        [OperationContract]
        bool addBill(BillDTO billDTO);

        [OperationContract(Name="DeleteBillByDTO")]
        bool deleteBill(BillDTO billDTO);

        [OperationContract(Name="DeleteBillById")]
        bool deleteBill(string billID);

        bool updateBill(BillDTO newInfo);

        [OperationContract(Name="SelectBillByDTO")]
        BillDTO[] selectBillInfo(BillDTO billDTO = null);

        [OperationContract(Name="SelectBillById")]
        BillDTO[] selectBillInfo(string billID);
        #endregion

    }
}