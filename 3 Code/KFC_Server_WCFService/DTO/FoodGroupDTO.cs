using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace DTO
{
    [DataContract]
    public class FoodGroupDTO
    {
        #region Attributes - private
        private string _foodGroupID;

        [DataMember]
        public string FoodGroupID
        {
            get { return _foodGroupID; }
            set { _foodGroupID = value; }
        }
        private string _foodGroupName;

        [DataMember]
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
