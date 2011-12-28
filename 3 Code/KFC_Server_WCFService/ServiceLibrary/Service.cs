using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceLibrary
{
    public class Service : IService
    {
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
    }
}
