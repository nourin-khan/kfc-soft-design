using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableDTO
{
    public class FoodGroupDTO
    {
        #region Attributes - private
        private string _foodGroupID;

        public string FoodGroupID
        {
            get { return _foodGroupID; }
            set { _foodGroupID = value; }
        }
        private string _foodGroupName;

        public string FoodGroupName
        {
            get { return _foodGroupName; }
            set { _foodGroupName = value; }
        }
        #endregion
    }
}
