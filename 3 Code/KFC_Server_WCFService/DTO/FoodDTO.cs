using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class FoodDTO
    {
        #region Attributes - private
        private string _foodID;

        public string FoodID
        {
            get { return _foodID; }
            set { _foodID = value; }
        }
        private string _foodName;

        public string FoodName
        {
            get { return _foodName; }
            set { _foodName = value; }
        }
        private float _foodPrice;

        public float FoodPrice
        {
            get { return _foodPrice; }
            set { _foodPrice = value; }
        }
        private float _discountPrice;

        public float DiscountPrice
        {
            get { return _discountPrice; }
            set { _discountPrice = value; }
        }
        private string _image;

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private string _foodGroupID;

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
}
