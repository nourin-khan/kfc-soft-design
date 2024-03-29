﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace DTO
{
    [DataContract]
    public class FoodDTO
    {
        #region Attributes - private
        private string _foodID;

        [DataMember]
        public string FoodID
        {
            get { return _foodID; }
            set { _foodID = value; }
        }
        private string _foodName;

        [DataMember]
        public string FoodName
        {
            get { return _foodName; }
            set { _foodName = value; }
        }

        private bool _foodStatus;
        [DataMember]
        public bool FoodStatus
        {
            get { return _foodStatus; }
            set { _foodStatus = value; }
        }

        private float _foodPrice;

        [DataMember]
        public float FoodPrice
        {
            get { return _foodPrice; }
            set { _foodPrice = value; }
        }
        private float _discountPrice;

        [DataMember]
        public float DiscountPrice
        {
            get { return _discountPrice; }
            set { _discountPrice = value; }
        }
        private string _image;

        [DataMember]
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
        private string _description;

        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private string _foodGroupID;

        [DataMember]
        public string FoodGroupID
        {
            get { return _foodGroupID; }
            set { _foodGroupID = value; }
        }
        #endregion

        #region Attributes - public
        #endregion

        public FoodDTO(string foodID)
        {
            // TODO: Complete member initialization
            this.FoodID = foodID;
        }

        public FoodDTO()
        {
            // TODO: Complete member initialization
        }
    }


    [DataContract]
    public class OrderFoodDTO
    {
        #region Attributes - private
        private string _foodID;

        [DataMember]
        public string FoodID
        {
            get { return _foodID; }
            set { _foodID = value; }
        }
        private string _foodName;

        [DataMember]
        public string FoodName
        {
            get { return _foodName; }
            set { _foodName = value; }
        }
        private int _foodPrice;

        [DataMember]
        public int FoodPrice
        {
            get { return _foodPrice; }
            set { _foodPrice = value; }
        }
        private int _discountPrice;

        [DataMember]
        public int DiscountPrice
        {
            get { return _discountPrice; }
            set { _discountPrice = value; }
        }

        private int _quantity;
        [DataMember]
        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        #endregion
        public OrderFoodDTO()
        {
            // TODO: Complete member initialization
        }
    }

}
