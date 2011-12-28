using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
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

        public FoodGroupDTO(string id, string name)
        {
            // TODO: Complete member initialization
            this.FoodGroupID = id;
            this.FoodGroupName = name;
        }
    }
    
}
