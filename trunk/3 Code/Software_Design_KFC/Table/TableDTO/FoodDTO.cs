using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableDTO
{
    public class FoodDTO
    {
        #region Attributes
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

        public float FoodDiscountPrice
        {
            get { return _discountPrice; }
            set { _discountPrice = value; }
        }
        
        private string _image;
        public string FoodImageSource
        {
            get { return _image; }
            set { _image = value; }
        }
        private string _description;

        public string FoodDescription
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
    }
}
